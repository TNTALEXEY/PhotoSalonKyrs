namespace kyrsproject
{
	partial class formAdminActSel
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formAdminActSel));
			this.butnEditUsers = new System.Windows.Forms.Button();
			this.butnEditOrders = new System.Windows.Forms.Button();
			this.lablActSelAsk = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// butnEditUsers
			// 
			this.butnEditUsers.AutoSize = true;
			this.butnEditUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
			this.butnEditUsers.Location = new System.Drawing.Point(44, 49);
			this.butnEditUsers.Name = "butnEditUsers";
			this.butnEditUsers.Size = new System.Drawing.Size(314, 50);
			this.butnEditUsers.TabIndex = 6;
			this.butnEditUsers.Text = "Управление пользователями";
			this.butnEditUsers.UseVisualStyleBackColor = true;
			this.butnEditUsers.Click += new System.EventHandler(this.butnEditUsers_Click);
			// 
			// butnEditOrders
			// 
			this.butnEditOrders.AutoSize = true;
			this.butnEditOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
			this.butnEditOrders.Location = new System.Drawing.Point(44, 129);
			this.butnEditOrders.Name = "butnEditOrders";
			this.butnEditOrders.Size = new System.Drawing.Size(314, 50);
			this.butnEditOrders.TabIndex = 7;
			this.butnEditOrders.Text = "Управление заказами";
			this.butnEditOrders.UseVisualStyleBackColor = true;
			this.butnEditOrders.Click += new System.EventHandler(this.butnEditOrders_Click);
			// 
			// lablActSelAsk
			// 
			this.lablActSelAsk.AutoSize = true;
			this.lablActSelAsk.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lablActSelAsk.Location = new System.Drawing.Point(111, 9);
			this.lablActSelAsk.Name = "lablActSelAsk";
			this.lablActSelAsk.Size = new System.Drawing.Size(192, 24);
			this.lablActSelAsk.TabIndex = 8;
			this.lablActSelAsk.Text = "Выберите действие";
			// 
			// formAdminActSel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(404, 201);
			this.Controls.Add(this.lablActSelAsk);
			this.Controls.Add(this.butnEditOrders);
			this.Controls.Add(this.butnEditUsers);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "formAdminActSel";
			this.Text = "Вы вошли под ролью администратора.";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formAdminActSel_FormClosing);
			this.Load += new System.EventHandler(this.formAdminActSel_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button butnEditUsers;
		private System.Windows.Forms.Button butnEditOrders;
		private System.Windows.Forms.Label lablActSelAsk;
	}
}