namespace kyrsproject
{
	partial class formOrderBuilder
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formOrderBuilder));
			this.butnAddToOrder = new System.Windows.Forms.Button();
			this.lablVariants = new System.Windows.Forms.Label();
			this.lablGoods = new System.Windows.Forms.Label();
			this.dagvGoodsVars = new System.Windows.Forms.DataGridView();
			this.lablAmount = new System.Windows.Forms.Label();
			this.lablOrderBuild = new System.Windows.Forms.Label();
			this.dagvOrderBuild = new System.Windows.Forms.DataGridView();
			this.tboxAmount = new System.Windows.Forms.TextBox();
			this.butnSave = new System.Windows.Forms.Button();
			this.butnDelOrderBuild = new System.Windows.Forms.Button();
			this.lablFam = new System.Windows.Forms.Label();
			this.tboxFam = new System.Windows.Forms.TextBox();
			this.tboxNam = new System.Windows.Forms.TextBox();
			this.lablNam = new System.Windows.Forms.Label();
			this.tboxOtc = new System.Windows.Forms.TextBox();
			this.lablOtc = new System.Windows.Forms.Label();
			this.dagvGoodsList = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dagvGoodsVars)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dagvOrderBuild)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dagvGoodsList)).BeginInit();
			this.SuspendLayout();
			// 
			// butnAddToOrder
			// 
			this.butnAddToOrder.AutoSize = true;
			this.butnAddToOrder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.butnAddToOrder.Location = new System.Drawing.Point(649, 242);
			this.butnAddToOrder.Name = "butnAddToOrder";
			this.butnAddToOrder.Size = new System.Drawing.Size(109, 23);
			this.butnAddToOrder.TabIndex = 16;
			this.butnAddToOrder.Text = "Добавить в заказ";
			this.butnAddToOrder.UseVisualStyleBackColor = true;
			this.butnAddToOrder.Click += new System.EventHandler(this.butnAddToOrder_Click);
			// 
			// lablVariants
			// 
			this.lablVariants.AutoSize = true;
			this.lablVariants.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lablVariants.Location = new System.Drawing.Point(467, 18);
			this.lablVariants.Name = "lablVariants";
			this.lablVariants.Size = new System.Drawing.Size(98, 24);
			this.lablVariants.TabIndex = 18;
			this.lablVariants.Text = "Варианты";
			// 
			// lablGoods
			// 
			this.lablGoods.AutoSize = true;
			this.lablGoods.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lablGoods.Location = new System.Drawing.Point(12, 18);
			this.lablGoods.Name = "lablGoods";
			this.lablGoods.Size = new System.Drawing.Size(157, 24);
			this.lablGoods.TabIndex = 17;
			this.lablGoods.Text = "Товары и услуги";
			// 
			// dagvGoodsVars
			// 
			this.dagvGoodsVars.AllowUserToAddRows = false;
			this.dagvGoodsVars.AllowUserToDeleteRows = false;
			this.dagvGoodsVars.AllowUserToResizeRows = false;
			this.dagvGoodsVars.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dagvGoodsVars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dagvGoodsVars.Location = new System.Drawing.Point(471, 45);
			this.dagvGoodsVars.MultiSelect = false;
			this.dagvGoodsVars.Name = "dagvGoodsVars";
			this.dagvGoodsVars.ReadOnly = true;
			this.dagvGoodsVars.Size = new System.Drawing.Size(355, 193);
			this.dagvGoodsVars.TabIndex = 15;
			// 
			// lablAmount
			// 
			this.lablAmount.AutoSize = true;
			this.lablAmount.Location = new System.Drawing.Point(468, 249);
			this.lablAmount.Name = "lablAmount";
			this.lablAmount.Size = new System.Drawing.Size(69, 13);
			this.lablAmount.TabIndex = 19;
			this.lablAmount.Text = "Количество:";
			// 
			// lablOrderBuild
			// 
			this.lablOrderBuild.AutoSize = true;
			this.lablOrderBuild.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lablOrderBuild.Location = new System.Drawing.Point(12, 241);
			this.lablOrderBuild.Name = "lablOrderBuild";
			this.lablOrderBuild.Size = new System.Drawing.Size(139, 24);
			this.lablOrderBuild.TabIndex = 20;
			this.lablOrderBuild.Text = "Состав заказа";
			// 
			// dagvOrderBuild
			// 
			this.dagvOrderBuild.AllowUserToAddRows = false;
			this.dagvOrderBuild.AllowUserToDeleteRows = false;
			this.dagvOrderBuild.AllowUserToResizeColumns = false;
			this.dagvOrderBuild.AllowUserToResizeRows = false;
			this.dagvOrderBuild.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dagvOrderBuild.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dagvOrderBuild.Location = new System.Drawing.Point(12, 268);
			this.dagvOrderBuild.MultiSelect = false;
			this.dagvOrderBuild.Name = "dagvOrderBuild";
			this.dagvOrderBuild.ReadOnly = true;
			this.dagvOrderBuild.Size = new System.Drawing.Size(355, 193);
			this.dagvOrderBuild.TabIndex = 21;
			// 
			// tboxAmount
			// 
			this.tboxAmount.Location = new System.Drawing.Point(543, 244);
			this.tboxAmount.Name = "tboxAmount";
			this.tboxAmount.Size = new System.Drawing.Size(100, 20);
			this.tboxAmount.TabIndex = 22;
			this.tboxAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyBannerInt);
			// 
			// butnSave
			// 
			this.butnSave.AutoSize = true;
			this.butnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
			this.butnSave.Location = new System.Drawing.Point(654, 428);
			this.butnSave.Name = "butnSave";
			this.butnSave.Size = new System.Drawing.Size(172, 34);
			this.butnSave.TabIndex = 23;
			this.butnSave.Text = "Сохранить заказ";
			this.butnSave.UseVisualStyleBackColor = true;
			this.butnSave.Click += new System.EventHandler(this.butnSave_Click);
			// 
			// butnDelOrderBuild
			// 
			this.butnDelOrderBuild.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.butnDelOrderBuild.Location = new System.Drawing.Point(373, 402);
			this.butnDelOrderBuild.Name = "butnDelOrderBuild";
			this.butnDelOrderBuild.Size = new System.Drawing.Size(109, 57);
			this.butnDelOrderBuild.TabIndex = 24;
			this.butnDelOrderBuild.Text = "Удалить выбранный пункт из заказа";
			this.butnDelOrderBuild.UseVisualStyleBackColor = true;
			this.butnDelOrderBuild.Click += new System.EventHandler(this.butnDelOrderBuild_Click);
			// 
			// lablFam
			// 
			this.lablFam.AutoSize = true;
			this.lablFam.Location = new System.Drawing.Point(533, 330);
			this.lablFam.Name = "lablFam";
			this.lablFam.Size = new System.Drawing.Size(115, 13);
			this.lablFam.TabIndex = 25;
			this.lablFam.Text = "Фамилия заказчика:";
			// 
			// tboxFam
			// 
			this.tboxFam.Location = new System.Drawing.Point(654, 327);
			this.tboxFam.Name = "tboxFam";
			this.tboxFam.Size = new System.Drawing.Size(169, 20);
			this.tboxFam.TabIndex = 26;
			// 
			// tboxNam
			// 
			this.tboxNam.Location = new System.Drawing.Point(654, 353);
			this.tboxNam.Name = "tboxNam";
			this.tboxNam.Size = new System.Drawing.Size(169, 20);
			this.tboxNam.TabIndex = 28;
			// 
			// lablNam
			// 
			this.lablNam.AutoSize = true;
			this.lablNam.Location = new System.Drawing.Point(560, 358);
			this.lablNam.Name = "lablNam";
			this.lablNam.Size = new System.Drawing.Size(88, 13);
			this.lablNam.TabIndex = 27;
			this.lablNam.Text = "Имя заказчика:";
			// 
			// tboxOtc
			// 
			this.tboxOtc.Location = new System.Drawing.Point(654, 379);
			this.tboxOtc.Name = "tboxOtc";
			this.tboxOtc.Size = new System.Drawing.Size(169, 20);
			this.tboxOtc.TabIndex = 30;
			// 
			// lablOtc
			// 
			this.lablOtc.AutoSize = true;
			this.lablOtc.Location = new System.Drawing.Point(536, 382);
			this.lablOtc.Name = "lablOtc";
			this.lablOtc.Size = new System.Drawing.Size(113, 13);
			this.lablOtc.TabIndex = 29;
			this.lablOtc.Text = "Отчество заказчика:";
			// 
			// dagvGoodsList
			// 
			this.dagvGoodsList.AllowUserToAddRows = false;
			this.dagvGoodsList.AllowUserToDeleteRows = false;
			this.dagvGoodsList.AllowUserToResizeColumns = false;
			this.dagvGoodsList.AllowUserToResizeRows = false;
			this.dagvGoodsList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dagvGoodsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dagvGoodsList.Location = new System.Drawing.Point(12, 45);
			this.dagvGoodsList.MultiSelect = false;
			this.dagvGoodsList.Name = "dagvGoodsList";
			this.dagvGoodsList.Size = new System.Drawing.Size(355, 193);
			this.dagvGoodsList.TabIndex = 31;
			this.dagvGoodsList.SelectionChanged += new System.EventHandler(this.dagvGoodsList_SelectionChanged);
			// 
			// formOrderBuilder
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(838, 474);
			this.Controls.Add(this.dagvGoodsList);
			this.Controls.Add(this.tboxOtc);
			this.Controls.Add(this.lablOtc);
			this.Controls.Add(this.tboxNam);
			this.Controls.Add(this.lablNam);
			this.Controls.Add(this.tboxFam);
			this.Controls.Add(this.lablFam);
			this.Controls.Add(this.butnDelOrderBuild);
			this.Controls.Add(this.butnSave);
			this.Controls.Add(this.tboxAmount);
			this.Controls.Add(this.dagvOrderBuild);
			this.Controls.Add(this.lablOrderBuild);
			this.Controls.Add(this.lablAmount);
			this.Controls.Add(this.butnAddToOrder);
			this.Controls.Add(this.lablVariants);
			this.Controls.Add(this.lablGoods);
			this.Controls.Add(this.dagvGoodsVars);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "formOrderBuilder";
			this.Text = "Построение заказа";
			this.Load += new System.EventHandler(this.formOrderBuilder_Load);
			((System.ComponentModel.ISupportInitialize)(this.dagvGoodsVars)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dagvOrderBuild)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dagvGoodsList)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button butnAddToOrder;
		private System.Windows.Forms.Label lablVariants;
		private System.Windows.Forms.Label lablGoods;
		private System.Windows.Forms.DataGridView dagvGoodsVars;
		private System.Windows.Forms.Label lablAmount;
		private System.Windows.Forms.Label lablOrderBuild;
		private System.Windows.Forms.DataGridView dagvOrderBuild;
		private System.Windows.Forms.TextBox tboxAmount;
		private System.Windows.Forms.Button butnSave;
		private System.Windows.Forms.Button butnDelOrderBuild;
		private System.Windows.Forms.Label lablFam;
		private System.Windows.Forms.TextBox tboxFam;
		private System.Windows.Forms.TextBox tboxNam;
		private System.Windows.Forms.Label lablNam;
		private System.Windows.Forms.TextBox tboxOtc;
		private System.Windows.Forms.Label lablOtc;
		private System.Windows.Forms.DataGridView dagvGoodsList;
	}
}