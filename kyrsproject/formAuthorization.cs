using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.IO;

namespace kyrsproject
{
	public partial class formAuthorization : Form
	{
		public formAuthorization()
		{
			InitializeComponent();
		}
		string baseConnString = "NoData";//базовая строка подключения, к которой добавляют узера и пароль

		public string connString = "NoData";//строка которая в итоге будет передаваться дочерним формам
		private void butnLogon_Click(object sender, EventArgs e)//Вход в ИС
		{
			if (string.IsNullOrWhiteSpace(tboxLogin.Text) || string.IsNullOrWhiteSpace(tboxPassword.Text))//проверка на пустой логин/пароль
			{
				MessageBox.Show("Ни логин, ни пароль не должны быть пустыми","Предупреждение");
				return;
			}
			connString = $"{baseConnString}Username={tboxLogin.Text};Password={tboxPassword.Text};";
			NpgsqlConnection nc = new NpgsqlConnection(connString);
			try
			{
				//Открываем соединение.
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
						Hide();
						formAdminActSel AdmMF = new formAdminActSel();
						AdmMF.Owner = this;//нужно для вызова обратно
						AdmMF.Show();
						break;
					case "Manager":
						Hide();
						formManagerActSel ManMF = new formManagerActSel();
						ManMF.Owner = this;
						ManMF.Show();
						break;
					case "Worker":
						Hide();
						formOrderManagement WarMF = new formOrderManagement();
						WarMF.Owner = this;
						WarMF.Show();
						break;
					default:
						MessageBox.Show("Пользователя \"" + WhoAmI + "\" не существует.", "Ошибка.");
						break;
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Неверные данные для входа / проблемы с подключением", "Ошибка");
			}
		}

		private void formAutorization_Load(object sender, EventArgs e)//забирание базовой строки подключения из файла
		{
			string filename = "ConString.sav";
			if (File.Exists(filename))
			{
				string[] FileText = File.ReadAllLines(filename);//считываем весь файл
				baseConnString = FileText[0];
			}
			else//присвоение значения по умолчанию конфиг файлу и базовой строке подключения
			{
				File.WriteAllText(filename, "Host= 127.0.0.1;Port=37856;Database=BDPhotoSalon;Pooling=false;");//создаём его с настройкой по умолчанию без пользователя
				baseConnString = "Host= 127.0.0.1;Port=37856;Database=BDPhotoSalon;Pooling=false;";//присваивание настройки по умолчанию самой строке
			}
		}

		private void chkbShowPassword_CheckedChanged(object sender, EventArgs e)//изменение видимости пароля
		{
			tboxPassword.UseSystemPasswordChar = !chkbShowPassword.Checked;
		}
	}
}
