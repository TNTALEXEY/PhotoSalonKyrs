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
	public partial class formManagerActSel : Form
	{
		public formManagerActSel()
		{
			InitializeComponent();
		}
		public string connString = "NoData";

		private void formManagerActSel_Load(object sender, EventArgs e)
		{
			formAuthorization FormAccess = this.Owner as formAuthorization;//нужно чтобы забрать строку подключения
			connString = FormAccess.connString;
		}

		private void butnEditGoods_Click(object sender, EventArgs e)
		{
			//форма скрываться не будет ибо манагер имеет право в любой момент вызвать другие окна управления
			formManagerEditGoods ManGE = new formManagerEditGoods();
			ManGE.Owner = this;//нужно для вызова обратно
			ManGE.Show();
		}

		private void butnEditOrders_Click(object sender, EventArgs e)
		{
			//форма скрываться не будет ибо манагер имеет право в любой момент вызвать другие окна управления
			formOrderManagement OrdM = new formOrderManagement();
			OrdM.Owner = this;//нужно для вызова обратно
			OrdM.Show();
		}

		private void formManagerActSel_FormClosing(object sender, FormClosingEventArgs e)
			//по закрытию формы пользователю даётся возможность выбрать другой аккаунт
		{
			formAuthorization FormAccess = this.Owner as formAuthorization;//нужно чтобы сделать форму авторизации видимой
			FormAccess.Show();
		}
	}
}
