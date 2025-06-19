namespace kyrsproject
{
	partial class formManagerActSel
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formManagerActSel));
			this.lablActSelAsk = new System.Windows.Forms.Label();
			this.butnEditOrders = new System.Windows.Forms.Button();
			this.butnEditGoods = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lablActSelAsk
			// 
			this.lablActSelAsk.AutoSize = true;
			this.lablActSelAsk.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lablActSelAsk.Location = new System.Drawing.Point(112, 15);
			this.lablActSelAsk.Name = "lablActSelAsk";
			this.lablActSelAsk.Size = new System.Drawing.Size(192, 24);
			this.lablActSelAsk.TabIndex = 11;
			this.lablActSelAsk.Text = "Выберите действие";
			// 
			// butnEditOrders
			// 
			this.butnEditOrders.AutoSize = true;
			this.butnEditOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
			this.butnEditOrders.Location = new System.Drawing.Point(45, 135);
			this.butnEditOrders.Name = "butnEditOrders";
			this.butnEditOrders.Size = new System.Drawing.Size(314, 50);
			this.butnEditOrders.TabIndex = 10;
			this.butnEditOrders.Text = "Просмотр заказов";
			this.butnEditOrders.UseVisualStyleBackColor = true;
			this.butnEditOrders.Click += new System.EventHandler(this.butnEditOrders_Click);
			// 
			// butnEditGoods
			// 
			this.butnEditGoods.AutoSize = true;
			this.butnEditGoods.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
			this.butnEditGoods.Location = new System.Drawing.Point(45, 55);
			this.butnEditGoods.Name = "butnEditGoods";
			this.butnEditGoods.Size = new System.Drawing.Size(314, 50);
			this.butnEditGoods.TabIndex = 9;
			this.butnEditGoods.Text = "Управление товарами/услугами";
			this.butnEditGoods.UseVisualStyleBackColor = true;
			this.butnEditGoods.Click += new System.EventHandler(this.butnEditGoods_Click);
			// 
			// formManagerActSel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(404, 201);
			this.Controls.Add(this.lablActSelAsk);
			this.Controls.Add(this.butnEditOrders);
			this.Controls.Add(this.butnEditGoods);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "formManagerActSel";
			this.Text = "Вы вошли под ролью менеджера";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formManagerActSel_FormClosing);
			this.Load += new System.EventHandler(this.formManagerActSel_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lablActSelAsk;
		private System.Windows.Forms.Button butnEditOrders;
		private System.Windows.Forms.Button butnEditGoods;
	}
}