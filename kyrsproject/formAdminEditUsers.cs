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
	public partial class formAdminEditUsers : Form
	{
		public formAdminEditUsers()
		{
			InitializeComponent();
		}
		public string connString = "NoData";//строка должа быть видима для всех методов
		private void formAdminEditUsers_Load(object sender, EventArgs e)//загрузка этой формы
		{
			formAdminActSel FormAccess = this.Owner as formAdminActSel;//забираем текущую строку подключения
			connString = FormAccess.connString;
			loadUserList();
		}

		public void loadUserList()//загрузка списка пользователей 
		{
			NpgsqlConnection nc = new NpgsqlConnection(connString);
			try
			{
				this.dagvUserList.Columns.Clear();//очистка дагв
				this.dagvUserList.Rows.Clear();
				nc.Open();
				var dataSource = NpgsqlDataSource.Create(connString);
				var command = dataSource.CreateCommand("SELECT Login AS \"Логин\", Privelege AS \"Роль\" FROM Priveleges;");
				var reader = command.ExecuteReader();
				DataTable dataTable = new DataTable();
				dataTable.Load(reader);
				//заполнение столбцов
				for (int i = 0; i < dataTable.Columns.Count; i++)
					this.dagvUserList.Columns.Add($"column{i}", $"{dataTable.Columns[i].ColumnName}");
				//заполнение строк
				for (int j = 0; j < dataTable.Rows.Count; j++)
					this.dagvUserList.Rows.Insert(j, dataTable.Rows[j].ItemArray);
				reader.Close();//обязательно закрываем соединения
				nc.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Загрузка списка пользователей не удалась", "Ошибка");
				this.Close();//смысла в существовании формы при отсутствии списка пользователей нет
			}
		}

		private void removeRowsByLogin(DataGridView dgv, string loginToRemove)//удалялка строк по логину (логин здесь выполняет функцию ид)
		{
			foreach (DataGridViewRow row in dgv.Rows)//ищет перебором нужную строку
			{
				if (row.Cells[0].Value.ToString() == loginToRemove.ToString())
				{
					dgv.Rows.Remove(row);//удаляет
					return;
				}
			}
		}

		private void butnUserDelete_Click(object sender, EventArgs e)//удаление пользователя
		{
			DialogResult result = DialogResult.No;
			if (this.dagvUserList.CurrentCell != null)//проверка того что выбрано хоть что то
			{
				result = MessageBox.Show(//Окно запроса подтверждения
				"Выбранный пользователь будет удалён, продолжить?", 
				"Предупреждение", 
				MessageBoxButtons.YesNo, 
				MessageBoxIcon.Warning, 
				MessageBoxDefaultButton.Button2 // Кнопка по умолчанию (Нет)
			);
			}

			if (result == DialogResult.Yes)//в случае да выполняется всё, в случае нет ничего
			{
				NpgsqlConnection nc = new NpgsqlConnection(connString);
				try
				{
					if (this.dagvUserList.CurrentCell != null)//проверка того что выбрано хоть что то
					{
						nc.Open();
						var dataSource = NpgsqlDataSource.Create(connString);
						var command = dataSource.CreateCommand($"SELECT pg_terminate_backend(pid) FROM pg_stat_activity WHERE usename = '{this.dagvUserList.CurrentRow.Cells[0].Value.ToString()}';;");//уничтожение пользователя акт 1 (смерть подключения)
						command.ExecuteNonQuery();
						command = dataSource.CreateCommand($"DROP OWNED BY \"{this.dagvUserList.CurrentRow.Cells[0].Value.ToString()}\";");//уничтожение пользователя акт 2 (раскулачивание)
						command.ExecuteNonQuery();
						command = dataSource.CreateCommand($"DROP USER \"{this.dagvUserList.CurrentRow.Cells[0].Value.ToString()}\";;");//уничтожение пользователя акт 3 (расщепление пользователя на атомы)
						command.ExecuteNonQuery();
						command = dataSource.CreateCommand($"DELETE FROM Priveleges WHERE Login = '{this.dagvUserList.CurrentRow.Cells[0].Value.ToString()}';");//удалялка по логину
						command.ExecuteNonQuery();
						removeRowsByLogin(this.dagvUserList, this.dagvUserList.CurrentRow.Cells[0].Value.ToString());//убирание пользователя из списка
						nc.Close();
					}
					else
						return;
				}
				catch (Exception)
				{
					MessageBox.Show("Удалить пользователя не удалось", "Ошибка");
				}
			}
		}

		private void butnUserAdd_Click(object sender, EventArgs e)//открытие формы добавления пользователей
		{
			formAdminUserBuild FAUB = new formAdminUserBuild();
			FAUB.Owner = this;//нужно для вызова обратно
			FAUB.ShowDialog();
		}

		private string getLoginFromConnString(string connectString)//извлекалка логина из строки подключения
		{
			var builder = new NpgsqlConnectionStringBuilder(connectString);

			// Возвращаем логин (имя пользователя)
			return builder.Username;
		}



		private void dagvUserList_SelectionChanged(object sender, EventArgs e)//при выборе ячейки проверяем что выбрали не сами себя (самого себя удалить нельзя)
		{
			string UserLogin = "NoData";
			if (this.dagvUserList.CurrentCell != null)//проверка того что выбрано хоть что то
				UserLogin = this.dagvUserList.CurrentRow.Cells[0].Value.ToString();
			else
				return;

			if (UserLogin != getLoginFromConnString(connString))
			{
				butnUserDelete.Enabled = true;
			}
			else
			{
				butnUserDelete.Enabled = false;
			}
		}
	}
}
