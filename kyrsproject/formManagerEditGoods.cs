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
		private string connString = "NoData";
		private void UpdateTableGoods()
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

		private void formManagerEditGoods_Load(object sender, EventArgs e)
		{
			formManagerActSel FormAccess = this.Owner as formManagerActSel;//забираем текущую строку подключения
			connString = FormAccess.connString;
			UpdateTableGoods();
		}

		private void loadVars()
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
				this.dagvGoodsVars.Columns[0].Visible = false;//прячу ненужные в отображении столбцы
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


		private void dagvOrderList_SelectionChanged(object sender, EventArgs e)//по выбору пользователя будут подгружаться варианты товара/услуги
		{
			loadVars();
		}

		void moveToRowByID(DataGridView dagv, object value)
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


		private void removeRowsById(DataGridView dgv, int idToRemove)//удалялка строк по ид
		{
			foreach (DataGridViewRow row in dgv.Rows)//ищет перебором нужную строку
			{
				if (row.Cells[0].Value.ToString() == idToRemove.ToString())
				{
					dgv.Rows.Remove(row);//удаляет
					return;
				}
			}
		}

		private void butnGoodsDelete_Click(object sender, EventArgs e)
		{
			DialogResult result = DialogResult.No;
			if (this.dagvGoodsList.CurrentCell != null)//проверка того что выбрано хоть что то
			{
				result = MessageBox.Show(
				"Кроме товара будут удалены все заказы, содержащие этот товар, вы уверены?", // Текст сообщения
				"Предупреждение", // Заголовок окна
				MessageBoxButtons.YesNo, // Тип кнопок (Да/Нет)
				MessageBoxIcon.Warning, // Иконка предупреждения
				MessageBoxDefaultButton.Button2 // Кнопка по умолчанию (Нет)
			);
			}

			if (result == DialogResult.Yes)
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

		private void butnGoodsAdd_Click(object sender, EventArgs e)
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
				nc.Close();    //соединение более не нужно, закрываю
				UpdateTableGoods();//одновляем таблицу, т.к. на данный момент в ней нет новой строки
				moveToRowByID(this.dagvGoodsList, Convert.ToInt32(lastvalue));//переходим на строку которую добавили
			}
			catch (Exception)
			{
				MessageBox.Show("Добавление товара не удалось", "Ошибка");
				//Код обработки ошибок
			}
		}

		private void butnVariantsDelete_Click(object sender, EventArgs e)
		{
			DialogResult result = DialogResult.No;
			if (this.dagvGoodsVars.CurrentCell != null)//проверка того что выбрано хоть что то
			{
				result = MessageBox.Show(
				"Кроме варианта товара будут удалены все заказы, содержащие этот вариант товара, вы уверены?", // Текст сообщения
				"Предупреждение", // Заголовок окна
				MessageBoxButtons.YesNo, // Тип кнопок (Да/Нет)
				MessageBoxIcon.Warning, // Иконка предупреждения
				MessageBoxDefaultButton.Button2 // Кнопка по умолчанию (Нет)
			);
			}

			if (result == DialogResult.Yes)
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
					//Код обработки ошибок
				}
			}
		}

		private void butnVariantsAdd_Click(object sender, EventArgs e)
		{
			NpgsqlConnection nc = new NpgsqlConnection(connString);
			try
			{
				loadVars();//одновляем таблицу, чтобы викинуть пользователя из редактирования (иначе оно ломает весь процесс)
				nc.Open();
				var dataSource = NpgsqlDataSource.Create(connString);
				var command = dataSource.CreateCommand($"INSERT INTO VariantsOfGoods (GoodsID, VariantName, Price) VALUES ({this.dagvGoodsList.CurrentRow.Cells[0].Value.ToString()},'Новый вариант товара',0);");//создаём вариант товара
				command.ExecuteNonQuery();
				command = dataSource.CreateCommand($"SELECT last_value FROM public.variantsofgoods_variantid_seq;");//забираем его номер для перехода потом
				var reader = command.ExecuteReader();
				reader.Read();
				Int64 lastvalue = reader.GetInt64(0);
				reader.Close();
				nc.Close();    //соединение более не нужно, закрываю
				loadVars();//одновляем таблицу, т.к. на данный момент в ней нет новой строки
				moveToRowByID(this.dagvGoodsVars, Convert.ToInt32(lastvalue));//переходим на строку которую добавили
			}
			catch (Exception)
			{
				MessageBox.Show("Добавление варианта товара не удалось", "Ошибка");
				//Код обработки ошибок
			}
		}

		private void dagvGoodsList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
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
				UpdateTableGoods();//при ошибке сбрасываем состояние таблицы, т.к. иначе реальная и грид не совпадут
				MessageBox.Show("Сохранение изменений товара не удалось", "Ошибка");
				//Код обработки ошибок
			}
		}

		private void dagvGoodsVars_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			NpgsqlConnection nc = new NpgsqlConnection(connString);
			try
			{
				nc.Open();
				string pricenumber = this.dagvGoodsVars.CurrentRow.Cells[3].Value.ToString();
				pricenumber = pricenumber.Replace(',', '.');//замена запятых на точки, чтобы запрос не ругался
				var dataSource = NpgsqlDataSource.Create(connString);
				var command = dataSource.CreateCommand($"UPDATE VariantsOfGoods SET VariantName = '{this.dagvGoodsVars.CurrentRow.Cells[2].Value.ToString()}', " +
					$"Price = {pricenumber} " +
					$"WHERE VariantID = {this.dagvGoodsVars.CurrentRow.Cells[0].Value.ToString()};");//мегакоманда чтобы обновить товар по изменённой строке
				command.ExecuteNonQuery();
				nc.Close();
			}
			catch (Exception)
			{
				loadVars();//при ошибке сбрасываем состояние таблицы, т.к. иначе реальная и грид не совпадут
				MessageBox.Show("Сохранение изменений варианта товара не удалось", "Ошибка");
				//Код обработки ошибок
			}
		}

		public void emptinessFiller(DataGridView dataGridView)//заменяет все пустые ячейки на пробелы (предотвращает кучу проблем в других методах)
		{

			// Перебираем все строки
			foreach (DataGridViewRow row in dataGridView.Rows)
			{
				// Перебираем все ячейки в строке
				foreach (DataGridViewCell cell in row.Cells)
				{
					// Проверяем различные варианты пустых значений
					if (cell.Value == null ||
						cell.Value == DBNull.Value ||
						string.IsNullOrEmpty(cell.Value.ToString()) ||
						string.IsNullOrWhiteSpace(cell.Value.ToString()))
					{
						cell.Value = " "; // Заменяем на пробел
					}
				}
			}
		}
	}
}
