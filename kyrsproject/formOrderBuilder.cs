using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kyrsproject
{
	public partial class formOrderBuilder : Form
	{
		public formOrderBuilder()
		{
			InitializeComponent();
		}
		string connString = "NoData";
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
		int IDcounter = 1;//счётчик чтобы ид в OrderBuild управлять
		private void OrderBuildInit()//создаёт табличку для построения заказов
		{
			dagvOrderBuild.Columns.Add("ID", "ID");
			dagvOrderBuild.Columns.Add("GoodsID", "GoodsID");
			dagvOrderBuild.Columns.Add("VariantID", "VariantID");
			dagvOrderBuild.Columns.Add("GoodsName", "Товар");
			dagvOrderBuild.Columns.Add("VariantName", "Вариант");
			dagvOrderBuild.Columns.Add("Quantity", "Количество");
			dagvOrderBuild.Columns.Add("PositionPrice", "Сумма за позицию");
			this.dagvOrderBuild.Columns[0].Visible = false;//прячу ненужный в отображении столбец
			this.dagvOrderBuild.Columns[1].Visible = false;//прячу ненужный в отображении столбец
			this.dagvOrderBuild.Columns[2].Visible = false;//прячу ненужный в отображении столбец
		}
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
				MessageBox.Show("Не удалось загрузить список товаров", "Ошибка");
				this.Close();//смысла в форме без товаров нет
			}
		}
		private void formOrderBuilder_Load(object sender, EventArgs e)
		{
			// Получаем тип родительской формы
			Type ownerType = this.Owner.GetType();
			FieldInfo connStringField = ownerType.GetField("connString");//забираем строку подключения
			connString = connStringField.GetValue(this.Owner) as string;
			UpdateTableGoods();
			OrderBuildInit();
		}

		public void KeyBannerInt(object sender, KeyPressEventArgs e)//блокировалка не цифр (2 аргумента чтоб его мог использовать текстбох как метод)
		{
			if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 127)//проверка на цифру или удалялку
			{
				e.Handled = true;//блокируем ввод
			}
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
				MessageBox.Show("Загрузка вариантов товара не удалась", "Ошибка");
			}
		}

		private void dagvGoodsList_SelectionChanged(object sender, EventArgs e)
		{
			loadVars();
		}

		private void butnAddToOrder_Click(object sender, EventArgs e)
		{
			if(this.dagvGoodsList.CurrentCell != null || this.dagvGoodsList.CurrentCell != null)
			{
				if (tboxAmount.Text == "" || tboxAmount.Text[0] == '0')
				{
					MessageBox.Show("Вы не можете добавить 0 предметов", "Предупреждение");
				}
				else
				{
					// Получение данных
					string Id = Convert.ToString(IDcounter++);
					string goodsId = this.dagvGoodsList.CurrentRow.Cells[0].Value.ToString();
					string variantId = this.dagvGoodsVars.CurrentRow.Cells[0].Value.ToString();
					string goodsName = this.dagvGoodsList.CurrentRow.Cells[1].Value.ToString();
					string variantName = this.dagvGoodsVars.CurrentRow.Cells[2].Value.ToString();
					string quantity = tboxAmount.Text;
					string price = (Convert.ToInt32(tboxAmount.Text) * float.Parse(this.dagvGoodsVars.CurrentRow.Cells[3].Value.ToString())).ToString();

					// Добавление строки
					dagvOrderBuild.Rows.Add(Id, goodsId, variantId, goodsName, variantName, quantity, price);
				}
			}
			else
			{
				MessageBox.Show("Не выбран товар или вариант","Предупреждение");
				return;
			}
		}

		private void butnDelOrderBuild_Click(object sender, EventArgs e)
		{
			if (this.dagvOrderBuild.CurrentCell != null)//проверка того что выбрано хоть что то
				removeRowsById(dagvOrderBuild, Convert.ToInt32(this.dagvOrderBuild.CurrentRow.Cells[0].Value.ToString()));
			else
				return;
		}

		public string calcPrice()
		{
			decimal totalSum = 0;

			// Перебираем все строки
			foreach (DataGridViewRow row in dagvOrderBuild.Rows)
			{
				var cellValue = row.Cells["PositionPrice"].Value;

				if (cellValue != null)
				{
					string priceString = cellValue.ToString();

					// Пытаемся конвертировать строку в decimal
					if (decimal.TryParse(priceString, out decimal price))
					{
						totalSum += price;
					}
				}
			}

			// Возвращаем результат в строковом виде с двумя знаками после запятой
			return totalSum.ToString("F2");
		}

		private void butnSave_Click(object sender, EventArgs e)
		{
			if(!string.IsNullOrWhiteSpace(tboxFam.Text) && !string.IsNullOrWhiteSpace(tboxFam.Text))
			{
				if(dagvOrderBuild.Rows.Count > 0)
				{
					NpgsqlConnection nc = new NpgsqlConnection(connString);
					try
					{
						string pricestorage = "NoData";
						UpdateTableGoods();//одновляем таблицу, чтобы викинуть пользователя из редактирования (иначе оно ломает весь процесс)
						nc.Open();
						var dataSource = NpgsqlDataSource.Create(connString);
						pricestorage = calcPrice();
						pricestorage = pricestorage.Replace(',', '.');//замена запятых на точки, чтобы запрос не ругался
						var command = dataSource.CreateCommand($"INSERT INTO Orders (CustomerFirstName, CustomerLastName, CustomerSurName, CreationDate, IsCompleted, TotalPrice) VALUES " +
							$"('{tboxFam.Text}', '{tboxNam.Text}', '{tboxOtc.Text}', CURRENT_DATE, '0', {pricestorage});");//создаём товар
						command.ExecuteNonQuery();
						command = dataSource.CreateCommand($"SELECT last_value FROM public.orders_orderid_seq;");//забираем его номер для перехода потом
						var reader = command.ExecuteReader();
						reader.Read();
						Int64 lastvalue = reader.GetInt64(0);
						reader.Close();
						// Перебираем все строки
						foreach (DataGridViewRow row in dagvOrderBuild.Rows)
						{
							pricestorage = row.Cells[6].Value.ToString();
							pricestorage = pricestorage.Replace(',', '.');//замена запятых на точки, чтобы запрос не ругался
							command = dataSource.CreateCommand($"INSERT INTO OrderParts (OrderID, GoodsID, VariantID, Quantity, PositionPrice) VALUES " +
							$"({lastvalue}, {row.Cells[1].Value.ToString()}, {row.Cells[2].Value.ToString()}, {row.Cells[5].Value.ToString()}, {pricestorage});");//создаём товар
							command.ExecuteNonQuery();
						}
						nc.Close();    //соединение более не нужно, закрываю
						formOrderManagement FormAccess = this.Owner as formOrderManagement;//забираем текущую строку подключения
						FormAccess.UpdateTable();
						this.Close();//после успешного сохранения закрываем форму
					}
					catch (Exception)
					{
						MessageBox.Show("Создание заказа не удалось", "Ошибка");
					}
				}
				else
				{
					MessageBox.Show("Заказ не может быть пустым.", "Предупреждение");
					return;
				}
			}
			else
			{
				MessageBox.Show("Фамилия, имя не могут быть пустыми.","Предупреждение");
				return;
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
