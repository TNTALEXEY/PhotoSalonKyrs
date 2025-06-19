namespace kyrsproject
{
	partial class formAdminEditUsers
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formAdminEditUsers));
			this.butnUserDelete = new System.Windows.Forms.Button();
			this.butnUserAdd = new System.Windows.Forms.Button();
			this.dagvUserList = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dagvUserList)).BeginInit();
			this.SuspendLayout();
			// 
			// butnUserDelete
			// 
			this.butnUserDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.butnUserDelete.Location = new System.Drawing.Point(230, 12);
			this.butnUserDelete.Name = "butnUserDelete";
			this.butnUserDelete.Size = new System.Drawing.Size(110, 110);
			this.butnUserDelete.TabIndex = 1;
			this.butnUserDelete.Text = "Удалить выбранного пользователя";
			this.butnUserDelete.UseVisualStyleBackColor = true;
			this.butnUserDelete.Click += new System.EventHandler(this.butnUserDelete_Click);
			// 
			// butnUserAdd
			// 
			this.butnUserAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.butnUserAdd.Location = new System.Drawing.Point(230, 182);
			this.butnUserAdd.Name = "butnUserAdd";
			this.butnUserAdd.Size = new System.Drawing.Size(110, 110);
			this.butnUserAdd.TabIndex = 2;
			this.butnUserAdd.Text = "Добавить нового пользователя";
			this.butnUserAdd.UseVisualStyleBackColor = true;
			this.butnUserAdd.Click += new System.EventHandler(this.butnUserAdd_Click);
			// 
			// dagvUserList
			// 
			this.dagvUserList.AllowUserToAddRows = false;
			this.dagvUserList.AllowUserToDeleteRows = false;
			this.dagvUserList.AllowUserToResizeColumns = false;
			this.dagvUserList.AllowUserToResizeRows = false;
			this.dagvUserList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dagvUserList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dagvUserList.Location = new System.Drawing.Point(12, 12);
			this.dagvUserList.MultiSelect = false;
			this.dagvUserList.Name = "dagvUserList";
			this.dagvUserList.ReadOnly = true;
			this.dagvUserList.Size = new System.Drawing.Size(212, 280);
			this.dagvUserList.TabIndex = 3;
			this.dagvUserList.SelectionChanged += new System.EventHandler(this.dagvUserList_SelectionChanged);
			// 
			// formAdminEditUsers
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(344, 301);
			this.Controls.Add(this.dagvUserList);
			this.Controls.Add(this.butnUserAdd);
			this.Controls.Add(this.butnUserDelete);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "formAdminEditUsers";
			this.Text = "Управление пользователями";
			this.Load += new System.EventHandler(this.formAdminEditUsers_Load);
			((System.ComponentModel.ISupportInitialize)(this.dagvUserList)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button butnUserDelete;
		private System.Windows.Forms.Button butnUserAdd;
		private System.Windows.Forms.DataGridView dagvUserList;
	}
}