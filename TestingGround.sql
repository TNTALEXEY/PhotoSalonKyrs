--удалялка
DROP SCHEMA public CASCADE;

DROP USER "Odmen";
DROP USER "Mannco";
DROP USER "Workyta";
DROP USER "Willka";

CREATE SCHEMA public;
--попытка получения последнего значения SERIAL
SELECT pg_get_serial_sequence('goods', 'goodsid');--узнавание имени последовательности
SELECT last_value FROM public.goods_goodsid_seq;

DELETE FROM Goods WHERE GoodsID = 1 

SELECT pg_get_serial_sequence('variantsofgoods', 'variantid');--узнавание имени последовательности
SELECT last_value FROM public.variantsofgoods_variantid_seq;

SELECT pg_get_serial_sequence('orders', 'orderid');--узнавание имени последовательности
SELECT last_value FROM public.orders_orderid_seq;

--узнаём владельцев
SELECT 
    nspname AS schema_name,
    rolname AS owner
FROM pg_namespace
JOIN pg_roles ON pg_roles.oid = pg_namespace.nspowner
ORDER BY nspname;

--автообновлялка serial до нужного следующего значения
SELECT setval(
  pg_get_serial_sequence('users', 'id'),
  COALESCE(MAX(id), 1),
  false
) 
FROM users;
