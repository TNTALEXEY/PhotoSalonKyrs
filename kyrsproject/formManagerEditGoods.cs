using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kyrsproject
{
	public partial class formManagerEditGoods : Form
	{
		public formManagerEditGoods()
		{
			InitializeComponent();
		}
		private string connString = "NoData";//строка подключения должна быть видима всем методам
		private void UpdateTableGoods()//обновление списка товаров и услуг 
		{
			NpgsqlConnection nc = new NpgsqlConnection(connString);
			try
			{
				this.dagvGoodsList.Columns.Clear();//очистка дагв
				this.dagvGoodsList.Rows.Clear();
				nc.Open();
				var dataSource = NpgsqlDataSource.Create(connString);
				var command = dataSource.CreateCommand("SELECT GoodsID, GoodsName AS \"Название товара\", ShortDescription AS \"Краткое описание\" FROM Goods;");
				var reader = command.ExecuteReader();
				DataTable dataTable = new DataTable();
				dataTable.Load(reader);
				//заполнение столбцов
				for (int i = 0; i < dataTable.Columns.Count; i++)
					this.dagvGoodsList.Columns.Add($"column{i}", $"{dataTable.Columns[i].ColumnName}");
				//заполнение строк
				for (int j = 0; j < dataTable.Rows.Count; j++)
					this.dagvGoodsList.Rows.Insert(j, dataTable.Rows[j].ItemArray);
				this.dagvGoodsList.Columns[0].Visible = false;//прячу ненужный в отображении столбец
				reader.Close();
				nc.Close();
				emptinessFiller(this.dagvGoodsList);
			}
			catch (Exception)
			{
				MessageBox.Show("Обновление списка товаров не удалось", "Ошибка");
				this.Close();//смысла в форме без товаров нет
			}
		}

		private void formManagerEditGoods_Load(object sender, EventArgs e)//загрузка этой формы
		{
			formManagerActSel FormAccess = this.Owner as formManagerActSel;//забираем текущую строку подключения
			connString = FormAccess.connString;
			UpdateTableGoods();
		}

		private void loadVars()//загрузка списка вариантов товаров
		{
			this.dagvGoodsVars.Columns.Clear();//очистка дагв
			this.dagvGoodsVars.Rows.Clear();
			string GoodsID = "NoData";
			if (this.dagvGoodsList.CurrentCell != null)//проверка того что выбрано хоть что то
				GoodsID = this.dagvGoodsList.CurrentRow.Cells[0].Value.ToString();
			else
				return;
			NpgsqlConnection nc = new NpgsqlConnection(connString);
			try
			{
				nc.Open();
				var dataSource = NpgsqlDataSource.Create(connString);
				var command = dataSource.CreateCommand($"SELECT VariantID, GoodsID, VariantName AS \"Название варианта товара\", Price AS \"Цена за ед.\" FROM VariantsOfGoods WHERE GoodsID = {GoodsID};");
				var reader = command.ExecuteReader();
				DataTable dataTable = new DataTable();
				dataTable.Load(reader);
				//заполнение столбцов
				for (int i = 0; i < dataTable.Columns.Count; i++)
					this.dagvGoodsVars.Columns.Add($"column{i}", $"{dataTable.Columns[i].ColumnName}");
				//заполнение строк
				for (int j = 0; j < dataTable.Rows.Count; j++)
					this.dagvGoodsVars.Rows.Insert(j, dataTable.Rows[j].ItemArray);
				this.dagvGoodsVars.Columns[0].Visible = false;//прячу ненужные в отображении столбцы (ИД)
				this.dagvGoodsVars.Columns[1].Visible = false;//
				reader.Close();
				nc.Close();
				emptinessFiller(this.dagvGoodsVars);
			}
			catch (Exception)
			{
				MessageBox.Show("Получение списка вариантов товара/услуги не удалось", "Ошибка");
			}
		}


		private void dagvOrderList_SelectionChanged(object sender, EventArgs e)//загрузка вариантов выбранного товара/услуги
		{
			loadVars();
		}

		void moveToRowByID(DataGridView dagv, object value)//поиск и перемещение к строке в датагриде с некоторым ИД
		{
			foreach (DataGridViewRow row in dagv.Rows)
			{
				if (row.Cells[0].Value != null && row.Cells[0].Value.Equals(value))
				{
					dagv.CurrentCell = row.Cells[2];
					dagv.FirstDisplayedScrollingRowIndex = row.Index;
					break;
				}
			}
		}


		private void removeRowsById(DataGridView dgv, int idToRemove)//поиск и удаление строк из датагрида по ИД
		{
			foreach (DataGridViewRow row in dgv.Rows)
			{
				if (row.Cells[0].Value.ToString() == idToRemove.ToString())
				{
					dgv.Rows.Remove(row);
					return;
				}
			}
		}

		private void butnGoodsDelete_Click(object sender, EventArgs e)//удаление выбранного товара/услуги
		{
			DialogResult result = DialogResult.No;
			if (this.dagvGoodsList.CurrentCell != null)//проверка того что выбрано хоть что то
			{
				result = MessageBox.Show(//подтверждение удаления
				"Кроме товара будут удалены все заказы, содержащие этот товар, вы уверены?", 
				"Предупреждение", 
				MessageBoxButtons.YesNo, 
				MessageBoxIcon.Warning, 
				MessageBoxDefaultButton.Button2 // Кнопка по умолчанию (Нет)
			);
			}

			if (result == DialogResult.Yes)//если да -- удаляет если нет -- ничего не делает
			{
				NpgsqlConnection nc = new NpgsqlConnection(connString);
				try
				{
					if (this.dagvGoodsList.CurrentCell != null)//проверка того что выбрано хоть что то
					{
						nc.Open();
						var dataSource = NpgsqlDataSource.Create(connString);
						var command = dataSource.CreateCommand($"DELETE FROM Goods WHERE GoodsID = {this.dagvGoodsList.CurrentRow.Cells[0].Value.ToString()};");//удалялка по ид
						command.ExecuteNonQuery();
						removeRowsById(this.dagvGoodsList, Convert.ToInt32(this.dagvGoodsList.CurrentRow.Cells[0].Value.ToString()));
						nc.Close();
					}
					else
						return;
				}
				catch (Exception)
				{
					MessageBox.Show("Удаление товара не удалось", "Ошибка");
				}
			}

		}

		private void butnGoodsAdd_Click(object sender, EventArgs e)//добавляет товар/услугу 
		{
			NpgsqlConnection nc = new NpgsqlConnection(connString);
			try
			{
				UpdateTableGoods();//одновляем таблицу, чтобы викинуть пользователя из редактирования (иначе оно ломает весь процесс)
				nc.Open();
				var dataSource = NpgsqlDataSource.Create(connString);
				var command = dataSource.CreateCommand($"INSERT INTO Goods (GoodsName) VALUES ('Новый товар');");//создаём товар
				command.ExecuteNonQuery();
				command = dataSource.CreateCommand($"SELECT last_value FROM public.goods_goodsid_seq;");//забираем его номер для перехода потом
				var reader = command.ExecuteReader();
				reader.Read();
				Int64 lastvalue = reader.GetInt64(0);
				reader.Close();
				nc.Close();   
				UpdateTableGoods();
				moveToRowByID(this.dagvGoodsList, Convert.ToInt32(lastvalue));//переходим на строку которую добавили
			}
			catch (Exception)
			{
				MessageBox.Show("Добавление товара не удалось", "Ошибка");
			}
		}

		private void butnVariantsDelete_Click(object sender, EventArgs e)//удаление варианта товара
		{
			DialogResult result = DialogResult.No;
			if (this.dagvGoodsVars.CurrentCell != null)//проверка того что выбрано хоть что то
			{
				result = MessageBox.Show(//запрос подтверждения удаления 
				"Кроме варианта товара будут удалены все заказы, содержащие этот вариант товара, вы уверены?", 
				"Предупреждение", 
				MessageBoxButtons.YesNo, 
				MessageBoxIcon.Warning, 
				MessageBoxDefaultButton.Button2 // Кнопка по умолчанию (Нет)
			);
			}

			if (result == DialogResult.Yes)//если да -- удаляет, если нет -- ничего не делает
			{
				NpgsqlConnection nc = new NpgsqlConnection(connString);
				try
				{
					if (this.dagvGoodsVars.CurrentCell != null)//проверка того что выбрано хоть что то
					{
						nc.Open();
						var dataSource = NpgsqlDataSource.Create(connString);
						var command = dataSource.CreateCommand($"DELETE FROM VariantsOfGoods WHERE VariantID = {this.dagvGoodsVars.CurrentRow.Cells[0].Value.ToString()};");//удалялка по ид
						command.ExecuteNonQuery();
						removeRowsById(this.dagvGoodsVars, Convert.ToInt32(this.dagvGoodsVars.CurrentRow.Cells[0].Value.ToString()));
						nc.Close();
					}
				else
					return;
				}
				catch (Exception)
				{
					MessageBox.Show("Удаление варианта товара не удалось", "Ошибка");
				}
			}
		}

		private void butnVariantsAdd_Click(object sender, EventArgs e)//добавление варианта выбранного товара 
		{
			NpgsqlConnection nc = new NpgsqlConnection(connString);
			try
			{
				loadVars();//одновляем таблицу, чтобы выкинуть пользователя из редактирования (иначе оно ломает весь процесс)
				nc.Open();
				var dataSource = NpgsqlDataSource.Create(connString);
				var command = dataSource.CreateCommand($"INSERT INTO VariantsOfGoods (GoodsID, VariantName, Price) VALUES ({this.dagvGoodsList.CurrentRow.Cells[0].Value.ToString()},'Новый вариант товара',0);");//создаём вариант товара
				command.ExecuteNonQuery();
				command = dataSource.CreateCommand($"SELECT last_value FROM public.variantsofgoods_variantid_seq;");//забираем его номер для перехода потом
				var reader = command.ExecuteReader();
				reader.Read();
				Int64 lastvalue = reader.GetInt64(0);
				reader.Close();
				nc.Close();    
				loadVars();
				moveToRowByID(this.dagvGoodsVars, Convert.ToInt32(lastvalue));//переходим на строку которую добавили
			}
			catch (Exception)
			{
				MessageBox.Show("Добавление варианта товара не удалось", "Ошибка");
			}
		}

		private void dagvGoodsList_CellEndEdit(object sender, DataGridViewCellEventArgs e)//обновление строки товара по факту окончания её редактирования 
		{
			NpgsqlConnection nc = new NpgsqlConnection(connString);
			try
			{
				nc.Open();
				var dataSource = NpgsqlDataSource.Create(connString);
				var command = dataSource.CreateCommand($"UPDATE Goods SET GoodsName = '{this.dagvGoodsList.CurrentRow.Cells[1].Value.ToString()}', " +
					$"ShortDescription = '{this.dagvGoodsList.CurrentRow.Cells[2].Value.ToString()}' " +
					$"WHERE GoodsID = {this.dagvGoodsList.CurrentRow.Cells[0].Value.ToString()};");//мегакоманда чтобы обновить товар по изменённой строке
				command.ExecuteNonQuery();
				nc.Close();    
			}
			catch (Exception)
			{
				UpdateTableGoods();//при ошибке обновляем датагрид, т.к. иначе реальная таблица и грид не совпадут
				MessageBox.Show("Сохранение изменений товара не удалось", "Ошибка");
			}
		}

		private void dagvGoodsVars_CellEndEdit(object sender, DataGridViewCellEventArgs e)//обновление строки варианта товара по факту окончания её редактирования 
		{
			NpgsqlConnection nc = new NpgsqlConnection(connString);
			try
			{
				nc.Open();
				string pricenumber = this.dagvGoodsVars.CurrentRow.Cells[3].Value.ToString();
				pricenumber = pricenumber.Replace(',', '.');//замена запятых на точки, чтобы запрос не ломался
				var dataSource = NpgsqlDataSource.Create(connString);
				var command = dataSource.CreateCommand($"UPDATE VariantsOfGoods SET VariantName = '{this.dagvGoodsVars.CurrentRow.Cells[2].Value.ToString()}', " +
					$"Price = {pricenumber} " +
					$"WHERE VariantID = {this.dagvGoodsVars.CurrentRow.Cells[0].Value.ToString()};");//мегакоманда чтобы обновить товар по изменённой строке
				command.ExecuteNonQuery();
				nc.Close();
			}
			catch (Exception)
			{
				loadVars();//при ошибке обновляем датагрид, т.к. иначе реальная таблица и грид не совпадут
				MessageBox.Show("Сохранение изменений варианта товара не удалось", "Ошибка");
			}
		}

		public void emptinessFiller(DataGridView dataGridView)//заменяет все пустые ячейки на пробелы (предотвращает кучу проблем в других методах)
		{
			foreach (DataGridViewRow row in dataGridView.Rows)
			{
				foreach (DataGridViewCell cell in row.Cells)
				{
					// Проверяем различные варианты пустых значений и заменяем на пробел
					if (cell.Value == null ||
						cell.Value == DBNull.Value ||
						string.IsNullOrEmpty(cell.Value.ToString()) ||
						string.IsNullOrWhiteSpace(cell.Value.ToString()))
					{
						cell.Value = " "; 
					}
				}
			}
		}
	}
}
