

--создание таблиц для работы беде
CREATE TABLE Goods (
	GoodsID SERIAL PRIMARY KEY,
	GoodsName VARCHAR(50) NOT NULL,
	ShortDescription VARCHAR(100)
);

CREATE TABLE VariantsOfGoods (
	VariantID SERIAL PRIMARY KEY,
	GoodsID INT NOT NULL,
	VariantName VARCHAR (50) NOT NULL,
	Price NUMERIC(9,2) NOT NULL,--не думаю что понадобится нумерик больше, ибо странно иметь товар с ценой более 99999 тыс. р. за ед. в фотосалоне

	CONSTRAINT FK_VarsOfGoods_Goods_GoodsID
	FOREIGN KEY (GoodsID) REFERENCES Goods(GoodsID)
	ON DELETE CASCADE
);

CREATE TABLE Orders (
	OrderID SERIAL PRIMARY KEY,
	CustomerFirstName VARCHAR(75) NOT NULL,
	CustomerLastName VARCHAR(75) NOT NULL,
	CustomerSurName VARCHAR(75),
	CreationDate DATE NOT NULL,
	CompCancDate DATE,
	IsCompleted VARCHAR(1) NOT NULL,--по умолчанию сюды прога ставит "О"
	TotalPrice NUMERIC(14,2) NOT NULL
);

CREATE TABLE OrderParts (
	OrderPartID SERIAL PRIMARY KEY,
	OrderID INT NOT NULL,
	GoodsID INT NOT NULL,
	VariantID INT NOT NULL,
	Quantity INT NOT NULL,
	PositionPrice NUMERIC(12,2) NOT NULL,
	
	-- Внешние ключи для связи с другими таблицами
	CONSTRAINT FK_OrderParts_Orders_OrderID
	FOREIGN KEY (OrderID) REFERENCES Orders(OrderID)
	ON DELETE CASCADE,
		
	CONSTRAINT FK_OrderParts_Goods_GoodsID
	FOREIGN KEY (GoodsID) REFERENCES Goods(GoodsID)
	ON DELETE CASCADE,
		
	CONSTRAINT FK_OrderParts_Variants_VariantID
	FOREIGN KEY (VariantID) REFERENCES VariantsOfGoods(VariantID)
	ON DELETE CASCADE
);



--заполню таблицы тестовыми данными чтоб не грустно было пока
INSERT INTO Goods (GoodsName, ShortDescription) VALUES
('Печать документов','Стандартное качество'),
('Печать документов','Высокое качество'),
('Печать документов','Черновое качество');

INSERT INTO VariantsOfGoods (GoodsID, VariantName, Price) VALUES
(1, 'Формат А4', 100),
(1, 'Формат А5', 100),
(2, 'Формат А4', 100),
(2, 'Формат А5', 100),
(3, 'Формат А4', 100),
(3, 'Формат А5', 100);

INSERT INTO Orders (CustomerFirstName, CustomerLastName, CustomerSurName, CreationDate, CompCancDate, IsCompleted, TotalPrice) VALUES
('Иван', 'Петров', 'Сидорович', '2024-12-01', '2024-12-03', '+', 300.00),
('Мария', 'Иванова', 'Александровна', '2024-12-05', '2024-12-07', '+', 400.00),
('Алексей', 'Смирнов', NULL, '2024-12-10', NULL, '0', 200.00),
('Елена', 'Козлова', 'Дмитриевна', '2024-12-12', '2024-12-13', 'X', 300.00),
('Дмитрий', 'Морозов', 'Викторович', '2024-12-15', NULL, '0', 200.00);

INSERT INTO OrderParts (OrderID, GoodsID, VariantID, Quantity, PositionPrice) VALUES
(1, 1, 1, 1, 100.00), 
(1, 1, 2, 2, 200.00), 
(2, 2, 3, 2, 200.00),  
(2, 2, 4, 2, 200.00),  
(3, 3, 5, 2, 200.00),  
(4, 1, 1, 1, 100.00),  
(4, 2, 3, 2, 200.00),  
(5, 2, 4, 2, 200.00);  

SELECT 
    g.GoodsName AS "Название товара/услуги", 
    g.ShortDescription AS "Описание", 
    v.VariantName AS "Вариант товара", 
    v.Price AS "Цена за ед.", 
    op.Quantity AS "Количество", 
    op.PositionPrice AS "Сумма за позицию" 
FROM OrderParts op
INNER JOIN Goods g ON op.GoodsID = g.GoodsID
INNER JOIN VariantsOfGoods v ON op.VariantID = v.VariantID;


--проверка таблиц
SELECT * FROM Goods;

SELECT * FROM variantsofgoods;

SELECT * FROM Orders;

SELECT * FROM OrderParts;

--создание таблицы с отношением узеров к их доступу
CREATE TABLE Priveleges (
	Login VARCHAR(25) PRIMARY KEY,
	Privelege VARCHAR(50) NOT NULL 
);

--заполнение этой таблицы
INSERT INTO Priveleges (Login, Privelege) VALUES
('postgres','Admin'),
('Odmen','Admin'),
('Mannco','Manager'),
('Workyta','Worker'),
('Willka','Worker');

--проверка таблички
SELECT * FROM Priveleges;

--создание узеров
--одмен
CREATE USER "Odmen" WITH PASSWORD 'AdminTest';
GRANT USAGE ON SCHEMA public TO "Odmen";
GRANT ALL PRIVILEGES ON ALL TABLES IN SCHEMA public TO "Odmen";
GRANT ALL PRIVILEGES ON ALL SEQUENCES IN SCHEMA public TO "Odmen";
GRANT ALL PRIVILEGES ON ALL FUNCTIONS IN SCHEMA public TO "Odmen";
GRANT ALL PRIVILEGES ON SCHEMA public TO "Odmen";
ALTER USER "Odmen" SUPERUSER;
--изначально планировалось умнее дать возможность менять пользователей, но как оказалось 1 опция без суперузер не робит
--ALTER USER "Odmen" CREATEROLE;--эти 3 привилегии докинуты для управления узерами
--GRANT pg_read_all_data, pg_write_all_data TO "Odmen" WITH ADMIN OPTION;
--GRANT pg_signal_backend TO "Odmen";
--ALTER SCHEMA public OWNER TO "Odmen";
--маннко
CREATE USER "Mannco" WITH PASSWORD 'ManagerTest';
GRANT USAGE ON SCHEMA public TO "Mannco";
GRANT SELECT ON TABLE Priveleges TO "Mannco";
GRANT INSERT, SELECT, UPDATE, DELETE ON TABLE Goods TO "Mannco";
GRANT INSERT, SELECT, UPDATE, DELETE ON TABLE VariantsOfGoods TO "Mannco";
GRANT SELECT, UPDATE ON SEQUENCE public.goods_goodsid_seq TO "Mannco";
GRANT SELECT, UPDATE ON SEQUENCE public.variantsofgoods_variantid_seq TO "Mannco";
GRANT SELECT ON TABLE Orders TO "Mannco";
GRANT SELECT ON TABLE OrderParts TO "Mannco";
--воркута
CREATE USER "Workyta" WITH PASSWORD 'WorkerTes';
GRANT USAGE ON SCHEMA public TO "Workyta";
GRANT SELECT ON TABLE Priveleges TO "Workyta";
GRANT SELECT ON TABLE Goods TO "Workyta";
GRANT SELECT ON TABLE VariantsOfGoods TO "Workyta";
GRANT INSERT, SELECT, UPDATE, DELETE ON TABLE Orders TO "Workyta";
GRANT INSERT, SELECT, UPDATE, DELETE ON TABLE OrderParts TO "Workyta";
GRANT SELECT, UPDATE ON SEQUENCE public.orders_orderid_seq TO "Workyta";
GRANT SELECT, UPDATE ON SEQUENCE public.orderparts_orderpartid_seq TO "Workyta";

--виллка
CREATE USER "Willka" WITH PASSWORD 'WorkerTest';
GRANT USAGE ON SCHEMA public TO "Willka";
GRANT SELECT ON TABLE Priveleges TO "Willka";
GRANT SELECT ON TABLE Goods TO "Willka";
GRANT SELECT ON TABLE VariantsOfGoods TO "Willka";
GRANT INSERT, SELECT, UPDATE, DELETE ON TABLE Orders TO "Willka";
GRANT INSERT, SELECT, UPDATE, DELETE ON TABLE OrderParts TO "Willka";
GRANT SELECT, UPDATE ON SEQUENCE public.orders_orderid_seq TO "Willka";
GRANT SELECT, UPDATE ON SEQUENCE public.orderparts_orderpartid_seq TO "Willka";

--проверка проверки привелегии
SELECT Privelege FROM Priveleges WHERE CURRENT_USER = Login;