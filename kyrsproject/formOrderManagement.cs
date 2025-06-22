using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kyrsproject
{
	public partial class formOrderManagement : Form
	{
		public formOrderManagement()
		{
			InitializeComponent();
		}
		public string connString = "NoData";//строку подключения должны видеть все методы 
		public static void ColorizeStatusColumn(DataGridView daGV)//окрашивание заказов по их статусу
		{

			for (int i = 0; i < daGV.Rows.Count; i++)
			{

				var cell = daGV.Rows[i].Cells[5];//подготовка состояния заказа к анализу
				string cellValue = cell.Value?.ToString()?.Trim();

				switch (cellValue)//Назначение цвета от статуса 
				{
					case "+":
						// Завершён - зелёный цвет
						cell.Style.BackColor = ColorTranslator.FromHtml("#32b76c");
						cell.Style.ForeColor = Color.Black;
						break;

					case "0":
						// В ожидании - жёлтый цвет
						cell.Style.BackColor = ColorTranslator.FromHtml("#f1e899");
						cell.Style.ForeColor = Color.Black;
						break;

					case "X":
						// Отменён - красный цвет
						cell.Style.BackColor = ColorTranslator.FromHtml("#f26065");
						cell.Style.ForeColor = Color.Black;
						break;

					default:
						// Сброс стиля для неопознанных значений
						cell.Style.BackColor = Color.Empty;
						cell.Style.ForeColor = Color.Empty;
						break;
				}
			}
		}

		public void setUI(string userRole)//определение отображаемых снизу панелей в зависимости от роли пользователя
		{
			panlWorker.Visible = false;
			panlAdmin.Visible = false;

			switch (userRole)//выбираем панель в зависимости от роли
			{
				case "Worker":
					panlWorker.Visible = true;
					break;

				case "Admin":
					panlAdmin.Visible = true;
					break;

				default:
				//дефолт есть, т.к. может войти менеджер, но он может только смотреть, т.е. без панелей
					break;
			}
		}

		private string getRole()//получаем роль пользователя
		{
			NpgsqlConnection nc = new NpgsqlConnection(connString);
			try
			{
				nc.Open();
				var dataSource = NpgsqlDataSource.Create(connString);
				var command = dataSource.CreateCommand("SELECT Privelege FROM Priveleges WHERE CURRENT_USER = Login;");
				var reader = command.ExecuteReader();
				reader.Read();
				string WhoAmI = reader.GetString(0);
				reader.Close();
				nc.Close();


				switch (WhoAmI)//выбор по типу узера
				{
					case "Admin":
						return "Admin";
					case "Manager":
						return "Manager";
					case "Worker":
						return "Worker";
					default:
						this.Close();//смысла в форме без пользователя нет
						return "Error";//иначе жалуется компилятор
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Получение роли текущего пользователя не удалось", "Ошибка");
				this.Close();//смысла в форме без пользователя нет
				return "Error";
			}
		}


		private void formOrderManagement_Load(object sender, EventArgs e)//загрузка этой формы
		{
			// Получаем тип родительской формы (изначально он неизвестен)
			Type ownerType = this.Owner.GetType();
			FieldInfo connStringField = ownerType.GetField("connString");//забираем строку подключения
			connString = connStringField.GetValue(this.Owner) as string;
			setUI(getRole());
			UpdateTable();
		}

		private void formOrderManagement_FormClosing(object sender, FormClosingEventArgs e)
		//возврат работника на авторизацию по закрытии формы
		{
			if (getRole() == "Worker")
			{
				formAuthorization FormAccess = this.Owner as formAuthorization;//нужно чтобы сделать форму авторизации видимой
				FormAccess.Show();
			}
		}

		public void UpdateTable()//обновление списка заказов 
		{
			NpgsqlConnection nc = new NpgsqlConnection(connString);
			try
			{
				this.dagvOrderList.Columns.Clear();//очистка дагв
				this.dagvOrderList.Rows.Clear();
				nc.Open();
				var dataSource = NpgsqlDataSource.Create(connString);
				var command = dataSource.CreateCommand("SELECT OrderID, CustomerFirstName AS \"Имя\", CustomerLastName AS \"Фамилия\", " +
					"CustomerSurName AS \"Отчество\", CreationDate AS \"Дата создания\", IsCompleted AS \"Статус заказа\"," +
					"  CompCancDate AS \"Дата Завершения/Отмены\", TotalPrice AS \"Сумма\" FROM Orders;");
				var reader = command.ExecuteReader();
				DataTable dataTable = new DataTable();
				dataTable.Load(reader);
				//заполнение столбцов
				for (int i = 0; i < dataTable.Columns.Count; i++)
					this.dagvOrderList.Columns.Add($"column{i}", $"{dataTable.Columns[i].ColumnName}");
				//заполнение строк
				for (int j = 0; j < dataTable.Rows.Count; j++)
					this.dagvOrderList.Rows.Insert(j, dataTable.Rows[j].ItemArray);
				this.dagvOrderList.Columns[0].Visible = false;//прячу ненужный в отображении столбец
				reader.Close();
				nc.Close();
				ColorizeStatusColumn(dagvOrderList);
				emptinessFiller(this.dagvOrderList);
			}
			catch (Exception)
			{
				MessageBox.Show("Получение списка заказов не удалось", "Ошибка");
				this.Close();//смысла в форме без заказов нет
			}
		}

		private void loadVars()//загрузка содержимого заказа
		{
			this.dagvOrderPartList.Columns.Clear();//очистка дагв
			this.dagvOrderPartList.Rows.Clear();
			string varID = "NoData";
			if (this.dagvOrderList.CurrentCell != null)//проверка того что выбрано хоть что то
				varID = this.dagvOrderList.CurrentRow.Cells[0].Value.ToString();
			else
				return;
			NpgsqlConnection nc = new NpgsqlConnection(connString);
			try
			{
				nc.Open();
				var dataSource = NpgsqlDataSource.Create(connString);
				var command = dataSource.CreateCommand($"SELECT g.GoodsName AS \"Название товара/услуги\", g.ShortDescription AS \"Описание\"," +
					$"v.VariantName AS \"Вариант товара\", v.Price AS \"Цена за ед.\", op.Quantity AS \"Количество\", op.PositionPrice AS \"Сумма за позицию\" " +
					$" FROM OrderParts op INNER JOIN Goods g ON op.GoodsID = g.GoodsID INNER JOIN VariantsOfGoods v ON op.VariantID = v.VariantID WHERE op.OrderID = {varID};");
				var reader = command.ExecuteReader();
				DataTable dataTable = new DataTable();
				dataTable.Load(reader);
				//заполнение столбцов
				for (int i = 0; i < dataTable.Columns.Count; i++)
					this.dagvOrderPartList.Columns.Add($"column{i}", $"{dataTable.Columns[i].ColumnName}");
				//заполнение строк
				for (int j = 0; j < dataTable.Rows.Count; j++)
					this.dagvOrderPartList.Rows.Insert(j, dataTable.Rows[j].ItemArray);
				reader.Close();
				nc.Close();
				emptinessFiller(this.dagvOrderPartList);
			}
			catch (Exception)
			{
				MessageBox.Show("Загрузка содержимого заказа не удалась", "Ошибка");
			}
		}

		void moveToRowByID(DataGridView dagv, object value)//поиск и перемещение к строке по ИД
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


		private void dagvOrderList_SelectionChanged(object sender, EventArgs e)//при смене выбора заказа грузим его содержимое
		{
			loadVars();
		}

		private void butnOrderCancel_Click(object sender, EventArgs e)//отмена заказа 
		{
			if (this.dagvOrderList.CurrentCell != null)//проверка того что выбрано хоть что то
			{
				if (this.dagvOrderList.CurrentRow.Cells[5].Value.ToString() == "0")
				{
					NpgsqlConnection nc = new NpgsqlConnection(connString);
					try
					{
						string selectedID = this.dagvOrderList.CurrentRow.Cells[0].Value.ToString();
						nc.Open();
						var dataSource = NpgsqlDataSource.Create(connString);
						var command = dataSource.CreateCommand($"UPDATE Orders SET IsCompleted = 'X', " +
							$"CompCancDate = CURRENT_DATE " +
							$"WHERE OrderID = {this.dagvOrderList.CurrentRow.Cells[0].Value.ToString()};");
						command.ExecuteNonQuery();
						nc.Close();
						UpdateTable();
						moveToRowByID(this.dagvOrderList, Convert.ToInt32(selectedID));
					}
					catch (Exception)
					{
						UpdateTable();//при ошибке сбрасываем состояние таблицы, т.к. иначе реальная и грид не совпадут
						MessageBox.Show("Отмена заказа не удалась", "Ошибка");
					}
				}
				else
					{ MessageBox.Show("Невозможно отменить уже завершённый/отменённый заказ", "Внимание"); return; }
			}
			else
				return;
		}

		private void butnOrderComplete_Click(object sender, EventArgs e)//завершение заказа 
		{
			if (this.dagvOrderList.CurrentCell != null)//проверка того что выбрано хоть что то
			{
				if (this.dagvOrderList.CurrentRow.Cells[5].Value.ToString() == "0")
				{
					NpgsqlConnection nc = new NpgsqlConnection(connString);
					try
					{
						string selectedID = this.dagvOrderList.CurrentRow.Cells[0].Value.ToString();
						nc.Open();
						var dataSource = NpgsqlDataSource.Create(connString);
						var command = dataSource.CreateCommand($"UPDATE Orders SET IsCompleted = '+', " +
							$"CompCancDate = CURRENT_DATE " +
							$"WHERE OrderID = {this.dagvOrderList.CurrentRow.Cells[0].Value.ToString()};");
						command.ExecuteNonQuery();
						nc.Close();
						UpdateTable();
						moveToRowByID(this.dagvOrderList, Convert.ToInt32(selectedID));
					}
					catch (Exception)
					{
						UpdateTable();//при ошибке сбрасываем состояние таблицы, т.к. иначе реальная и грид не совпадут
						MessageBox.Show("Завершение заказа не удалось", "Ошибка");
					}
				}
				else
				{ MessageBox.Show("Невозможно завершить уже завершённый/отменённый заказ", "Внимание"); return; }
			}
			else
				return;
		}

		private void butnOrderAdd_Click(object sender, EventArgs e)//переход на форму создания заказа 
		{
			formOrderBuilder FOB = new formOrderBuilder();
			FOB.Owner = this;//нужно для вызова обратно
			FOB.ShowDialog();
		}

		private void removeRowsById(DataGridView dgv, int idToRemove)//поиск и удаление строк по ид
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

		private void butnOrderDelete_Click(object sender, EventArgs e)//удаление заказа 
		{
			DialogResult result = DialogResult.No;
			if (this.dagvOrderList.CurrentCell != null)//проверка того что выбрано хоть что то
			{
				result = MessageBox.Show(//Подтверждение удаления заказа 
				"Заказ будет удалён, вы уверены?", 
				"Предупреждение", 
				MessageBoxButtons.YesNo, 
				MessageBoxIcon.Warning, 
				MessageBoxDefaultButton.Button2 // Кнопка по умолчанию (Нет)
			);
			}

			if (result == DialogResult.Yes)//если да -- выполнение, если нет -- ничего не происходит
			{
				NpgsqlConnection nc = new NpgsqlConnection(connString);
				try
				{
					if (this.dagvOrderList.CurrentCell != null)//проверка того что выбрано хоть что то
					{
						nc.Open();
						var dataSource = NpgsqlDataSource.Create(connString);
						var command = dataSource.CreateCommand($"DELETE FROM Orders WHERE OrderID = {this.dagvOrderList.CurrentRow.Cells[0].Value.ToString()};");//удалялка по ид
						command.ExecuteNonQuery();
						removeRowsById(this.dagvOrderList, Convert.ToInt32(this.dagvOrderList.CurrentRow.Cells[0].Value.ToString()));
						nc.Close();
					}
					else
						return;
				}
				catch (Exception)
				{
					MessageBox.Show("Удаление заказа не удалось", "Ошибка");
				}
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

		private void dagvOrderList_SortCompare(object sender, DataGridViewSortCompareEventArgs e)//своя сортировка для столбцов с датой, где пустые значения
		{
			if (e.Column.Index == 6)//проверка что выбран именно столбец с датой
			{
				bool value1IsEmpty = e.CellValue1 == null || e.CellValue1 == DBNull.Value ||
									string.IsNullOrEmpty(e.CellValue1?.ToString()) ||
									string.IsNullOrWhiteSpace(e.CellValue1?.ToString());
				bool value2IsEmpty = e.CellValue2 == null || e.CellValue2 == DBNull.Value ||
									string.IsNullOrEmpty(e.CellValue2?.ToString()) ||
									string.IsNullOrWhiteSpace(e.CellValue2?.ToString());

				if (value1IsEmpty && value2IsEmpty)
				{
					e.SortResult = 0;
					e.Handled = true;//отдаём контроль сортировки этому методу
					return;
				}

				if (value1IsEmpty)
				{
					e.SortResult = 1; // пустые значения в конец
					e.Handled = true;
					return;
				}

				if (value2IsEmpty)
				{
					e.SortResult = -1; // пустые значения в конец
					e.Handled = true;
					return;
				}

				// Получаем строковые значения 
				string dateString1 = e.CellValue1?.ToString()?.Trim();
				string dateString2 = e.CellValue2?.ToString()?.Trim();

				// Дополнительная проверка после trim - если остались только пробелы
				if (string.IsNullOrEmpty(dateString1) && string.IsNullOrEmpty(dateString2))
				{
					e.SortResult = 0;
					e.Handled = true;
					return;
				}

				if (string.IsNullOrEmpty(dateString1))
				{
					e.SortResult = 1; // пустые значения в конец
					e.Handled = true;
					return;
				}

				if (string.IsNullOrEmpty(dateString2))
				{
					e.SortResult = -1; // пустые значения в конец
					e.Handled = true;
					return;
				}

				// Попытка преобразования в DateTime
				bool date1Parsed = DateTime.TryParse(dateString1, out DateTime date1);
				bool date2Parsed = DateTime.TryParse(dateString2, out DateTime date2);

				if (date1Parsed && date2Parsed)//сортировка по дате
				{
					e.SortResult = date1.CompareTo(date2);
				}
				else if (date1Parsed && !date2Parsed)
				{
					e.SortResult = -1; 
				}
				else if (!date1Parsed && date2Parsed)
				{
					e.SortResult = 1; 
				}
				else
				{
					// в особом случае (которого быть не должно) сравниваем даты как текст
					e.SortResult = string.Compare(dateString1, dateString2);
				}

				e.Handled = true;
				return;
			}
		}
	}
}
