namespace kyrsproject
{
	partial class formAdminUserBuild
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formAdminUserBuild));
			this.lablLogin = new System.Windows.Forms.Label();
			this.tboxLogin = new System.Windows.Forms.TextBox();
			this.lablPassword = new System.Windows.Forms.Label();
			this.tboxPassword = new System.Windows.Forms.TextBox();
			this.lablRole = new System.Windows.Forms.Label();
			this.combRole = new System.Windows.Forms.ComboBox();
			this.butnAdd = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lablLogin
			// 
			this.lablLogin.AutoSize = true;
			this.lablLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lablLogin.Location = new System.Drawing.Point(12, 9);
			this.lablLogin.Name = "lablLogin";
			this.lablLogin.Size = new System.Drawing.Size(177, 24);
			this.lablLogin.TabIndex = 0;
			this.lablLogin.Text = "Имя пользователя";
			// 
			// tboxLogin
			// 
			this.tboxLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tboxLogin.Location = new System.Drawing.Point(16, 36);
			this.tboxLogin.Name = "tboxLogin";
			this.tboxLogin.Size = new System.Drawing.Size(249, 29);
			this.tboxLogin.TabIndex = 1;
			// 
			// lablPassword
			// 
			this.lablPassword.AutoSize = true;
			this.lablPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lablPassword.Location = new System.Drawing.Point(12, 68);
			this.lablPassword.Name = "lablPassword";
			this.lablPassword.Size = new System.Drawing.Size(76, 24);
			this.lablPassword.TabIndex = 2;
			this.lablPassword.Text = "Пароль";
			// 
			// tboxPassword
			// 
			this.tboxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tboxPassword.Location = new System.Drawing.Point(16, 95);
			this.tboxPassword.Name = "tboxPassword";
			this.tboxPassword.Size = new System.Drawing.Size(249, 29);
			this.tboxPassword.TabIndex = 3;
			// 
			// lablRole
			// 
			this.lablRole.AutoSize = true;
			this.lablRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lablRole.Location = new System.Drawing.Point(288, 9);
			this.lablRole.Name = "lablRole";
			this.lablRole.Size = new System.Drawing.Size(54, 24);
			this.lablRole.TabIndex = 4;
			this.lablRole.Text = "Роль";
			// 
			// combRole
			// 
			this.combRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.combRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.combRole.FormattingEnabled = true;
			this.combRole.Items.AddRange(new object[] {
            "Worker",
            "Manager",
            "Admin"});
			this.combRole.Location = new System.Drawing.Point(292, 33);
			this.combRole.Name = "combRole";
			this.combRole.Size = new System.Drawing.Size(137, 32);
			this.combRole.TabIndex = 5;
			// 
			// butnAdd
			// 
			this.butnAdd.AutoSize = true;
			this.butnAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.butnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.butnAdd.Location = new System.Drawing.Point(332, 95);
			this.butnAdd.Name = "butnAdd";
			this.butnAdd.Size = new System.Drawing.Size(97, 34);
			this.butnAdd.TabIndex = 6;
			this.butnAdd.Text = "Создать";
			this.butnAdd.UseVisualStyleBackColor = true;
			this.butnAdd.Click += new System.EventHandler(this.butnAdd_Click);
			// 
			// formAdminUserBuild
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(444, 141);
			this.Controls.Add(this.butnAdd);
			this.Controls.Add(this.combRole);
			this.Controls.Add(this.lablRole);
			this.Controls.Add(this.tboxPassword);
			this.Controls.Add(this.lablPassword);
			this.Controls.Add(this.tboxLogin);
			this.Controls.Add(this.lablLogin);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "formAdminUserBuild";
			this.Text = "Создание нового пользователя";
			this.Load += new System.EventHandler(this.formAdminUserBuild_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lablLogin;
		private System.Windows.Forms.TextBox tboxLogin;
		private System.Windows.Forms.Label lablPassword;
		private System.Windows.Forms.TextBox tboxPassword;
		private System.Windows.Forms.Label lablRole;
		private System.Windows.Forms.ComboBox combRole;
		private System.Windows.Forms.Button butnAdd;
	}
}