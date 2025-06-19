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
	public partial class formAdminUserBuild : Form
	{
		public formAdminUserBuild()
		{
			InitializeComponent();
		}
		string connString = "NoData";
		private void butnAdd_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(tboxLogin.Text) && !string.IsNullOrWhiteSpace(tboxPassword.Text))
			{
				NpgsqlConnection nc = new NpgsqlConnection(connString);
				try
				{
					nc.Open();
					var dataSource = NpgsqlDataSource.Create(connString);
					var command = dataSource.CreateCommand("");
					switch (combRole.Text)
					{
						case "Worker":
							command = dataSource.CreateCommand($"CREATE USER \"{tboxLogin.Text}\" WITH PASSWORD '{tboxPassword.Text}'; " +
								$"GRANT USAGE ON SCHEMA public TO \"{tboxLogin.Text}\"; " +
								$"GRANT SELECT ON TABLE Priveleges TO \"{tboxLogin.Text}\"; " +
								$"GRANT INSERT, SELECT, UPDATE, DELETE ON TABLE Goods TO \"{tboxLogin.Text}\"; " +
								$"GRANT INSERT, SELECT, UPDATE, DELETE ON TABLE VariantsOfGoods TO \"{tboxLogin.Text}\"; " +
								$"GRANT SELECT, UPDATE ON SEQUENCE public.goods_goodsid_seq TO \"{tboxLogin.Text}\"; " +
								$"GRANT SELECT, UPDATE ON SEQUENCE public.variantsofgoods_variantid_seq TO \"{tboxLogin.Text}\"; " +
								$"GRANT SELECT ON TABLE Orders TO \"{tboxLogin.Text}\"; " +
								$"GRANT SELECT ON TABLE OrderParts TO \"{tboxLogin.Text}\";");
							command.ExecuteNonQuery();
							command = dataSource.CreateCommand($"INSERT INTO Priveleges (Login, Privelege) VALUES ('{tboxLogin.Text}','Worker')");
							command.ExecuteNonQuery();
							break;
						case "Manager":
							command = dataSource.CreateCommand($"CREATE USER \"{tboxLogin.Text}\" WITH PASSWORD '{tboxPassword.Text}'; " +
								$"GRANT SELECT ON TABLE Priveleges TO \"{tboxLogin.Text}\"; " +
								$"GRANT SELECT ON TABLE Goods TO \"{tboxLogin.Text}\"; " +
								$"GRANT SELECT ON TABLE VariantsOfGoods TO \"{tboxLogin.Text}\"; " +
								$"GRANT INSERT, SELECT, UPDATE, DELETE ON TABLE Orders TO \"{tboxLogin.Text}\"; " +
								$"GRANT INSERT, SELECT, UPDATE, DELETE ON TABLE OrderParts TO \"{tboxLogin.Text}\"; " +
								$"GRANT SELECT, UPDATE ON SEQUENCE public.orders_orderid_seq TO \"{tboxLogin.Text}\"; " +
								$"GRANT SELECT, UPDATE ON SEQUENCE public.orderparts_orderpartid_seq TO \"{tboxLogin.Text}\";");
							command.ExecuteNonQuery();
							command = dataSource.CreateCommand($"INSERT INTO Priveleges (Login, Privelege) VALUES ('{tboxLogin.Text}','Manager')");
							command.ExecuteNonQuery();
							break;
						case "Admin":
							command = dataSource.CreateCommand($"CREATE USER \"{tboxLogin.Text}\" WITH PASSWORD '{tboxPassword.Text}'; " +
								$"GRANT USAGE ON SCHEMA public TO \"{tboxLogin.Text}\"; " +
								$"GRANT ALL PRIVILEGES ON ALL TABLES IN SCHEMA public TO \"{tboxLogin.Text}\"; " +
								$"GRANT ALL PRIVILEGES ON ALL SEQUENCES IN SCHEMA public TO \"{tboxLogin.Text}\"; " +
								$"GRANT ALL PRIVILEGES ON ALL FUNCTIONS IN SCHEMA public TO \"{tboxLogin.Text}\"; " +
								$"GRANT ALL PRIVILEGES ON SCHEMA public TO \"{tboxLogin.Text}\"; " +
								$"ALTER USER \"{tboxLogin.Text}\" SUPERUSER;");
							command.ExecuteNonQuery();
							command = dataSource.CreateCommand($"INSERT INTO Priveleges (Login, Privelege) VALUES ('{tboxLogin.Text}','Admin')");
							command.ExecuteNonQuery();
							break;
					}
					nc.Close();    //соединение более не нужно, закрываю
					formAdminEditUsers FormAccess = this.Owner as formAdminEditUsers;//забираем текущую строку подключения
					FormAccess.loadUserList();
					this.Close();//после успешного сохранения закрываем форму
				}
				catch (Exception)
				{
					MessageBox.Show("Добавить пользователя не удалось", "Ошибка");
				}
			}
			else
			{
				MessageBox.Show("Ни логин, ни пароль не должны быть пустыми","Предупреждение");
				return;
			}
		}

		private void formAdminUserBuild_Load(object sender, EventArgs e)
		{
			combRole.SelectedIndex = 0;//ставим значение по умолчанию
			formAdminEditUsers FormAccess = this.Owner as formAdminEditUsers;//нужно чтобы забрать строку подключения
			connString = FormAccess.connString;
		}
	}
}
