namespace kyrsproject
{
	partial class formAuthorization
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formAuthorization));
			this.lablAuthorization = new System.Windows.Forms.Label();
			this.lablLogin = new System.Windows.Forms.Label();
			this.lablPassword = new System.Windows.Forms.Label();
			this.tboxLogin = new System.Windows.Forms.TextBox();
			this.tboxPassword = new System.Windows.Forms.TextBox();
			this.butnLogon = new System.Windows.Forms.Button();
			this.chkbShowPassword = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// lablAuthorization
			// 
			this.lablAuthorization.AutoSize = true;
			this.lablAuthorization.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lablAuthorization.Location = new System.Drawing.Point(146, 19);
			this.lablAuthorization.Name = "lablAuthorization";
			this.lablAuthorization.Size = new System.Drawing.Size(129, 24);
			this.lablAuthorization.TabIndex = 0;
			this.lablAuthorization.Text = "Авторизация";
			// 
			// lablLogin
			// 
			this.lablLogin.AutoSize = true;
			this.lablLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
			this.lablLogin.Location = new System.Drawing.Point(89, 56);
			this.lablLogin.Name = "lablLogin";
			this.lablLogin.Size = new System.Drawing.Size(69, 24);
			this.lablLogin.TabIndex = 1;
			this.lablLogin.Text = "Логин:";
			// 
			// lablPassword
			// 
			this.lablPassword.AutoSize = true;
			this.lablPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
			this.lablPassword.Location = new System.Drawing.Point(89, 145);
			this.lablPassword.Name = "lablPassword";
			this.lablPassword.Size = new System.Drawing.Size(81, 24);
			this.lablPassword.TabIndex = 2;
			this.lablPassword.Text = "Пароль:";
			// 
			// tboxLogin
			// 
			this.tboxLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
			this.tboxLogin.Location = new System.Drawing.Point(93, 83);
			this.tboxLogin.Name = "tboxLogin";
			this.tboxLogin.Size = new System.Drawing.Size(224, 29);
			this.tboxLogin.TabIndex = 3;
			// 
			// tboxPassword
			// 
			this.tboxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
			this.tboxPassword.Location = new System.Drawing.Point(93, 172);
			this.tboxPassword.Name = "tboxPassword";
			this.tboxPassword.Size = new System.Drawing.Size(224, 29);
			this.tboxPassword.TabIndex = 4;
			this.tboxPassword.UseSystemPasswordChar = true;
			// 
			// butnLogon
			// 
			this.butnLogon.AutoSize = true;
			this.butnLogon.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
			this.butnLogon.Location = new System.Drawing.Point(169, 225);
			this.butnLogon.Name = "butnLogon";
			this.butnLogon.Size = new System.Drawing.Size(82, 34);
			this.butnLogon.TabIndex = 5;
			this.butnLogon.Text = "Войти";
			this.butnLogon.UseVisualStyleBackColor = true;
			this.butnLogon.Click += new System.EventHandler(this.butnLogon_Click);
			// 
			// chkbShowPassword
			// 
			this.chkbShowPassword.Location = new System.Drawing.Point(323, 172);
			this.chkbShowPassword.Name = "chkbShowPassword";
			this.chkbShowPassword.Size = new System.Drawing.Size(78, 33);
			this.chkbShowPassword.TabIndex = 6;
			this.chkbShowPassword.Text = "Показать пароль";
			this.chkbShowPassword.UseVisualStyleBackColor = true;
			this.chkbShowPassword.CheckedChanged += new System.EventHandler(this.chkbShowPassword_CheckedChanged);
			// 
			// formAuthorization
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(404, 281);
			this.Controls.Add(this.chkbShowPassword);
			this.Controls.Add(this.butnLogon);
			this.Controls.Add(this.tboxPassword);
			this.Controls.Add(this.tboxLogin);
			this.Controls.Add(this.lablPassword);
			this.Controls.Add(this.lablLogin);
			this.Controls.Add(this.lablAuthorization);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "formAuthorization";
			this.Text = "Авторизация";
			this.Load += new System.EventHandler(this.formAutorization_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lablAuthorization;
		private System.Windows.Forms.Label lablLogin;
		private System.Windows.Forms.Label lablPassword;
		private System.Windows.Forms.TextBox tboxLogin;
		private System.Windows.Forms.TextBox tboxPassword;
		private System.Windows.Forms.Button butnLogon;
		private System.Windows.Forms.CheckBox chkbShowPassword;
	}
}

