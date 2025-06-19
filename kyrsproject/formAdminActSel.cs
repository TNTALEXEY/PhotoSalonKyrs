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
	public partial class formAdminActSel : Form
	{
		public formAdminActSel()
		{
			InitializeComponent();
		}
		
		public string connString = "NoData";//нужно чтоб передать строку подключения форме дальше
		private void butnEditUsers_Click(object sender, EventArgs e)
		{
			//форма скрываться не будет ибо админ имеет право в любой момент вызвать другие окна управления
			formAdminEditUsers AdmUE = new formAdminEditUsers();
			AdmUE.Owner = this;//нужно для вызова обратно
			AdmUE.Show();
		}

		private void butnEditOrders_Click(object sender, EventArgs e)//открытие формы редактирования заказов
		{
			//форма скрываться не будет ибо админ имеет право в любой момент вызвать другие окна управления
			formOrderManagement OrdM = new formOrderManagement();
			OrdM.Owner = this;//нужно для вызова обратно
			OrdM.Show();
		}

		private void formAdminActSel_Load(object sender, EventArgs e)//загрузка этой формы
		{
			formAuthorization FormAccess = this.Owner as formAuthorization;//нужно чтобы забрать строку подключения из родителя
			connString = FormAccess.connString;
		}

		private void formAdminActSel_FormClosing(object sender, FormClosingEventArgs e)
			//на закрытии формы пользователю даётся возможность выбрать другой аккаунт
		{
			formAuthorization FormAccess = this.Owner as formAuthorization;//нужно чтобы сделать форму авторизации (родительскую форму) видимой
			FormAccess.Show();
		}
	}
}
