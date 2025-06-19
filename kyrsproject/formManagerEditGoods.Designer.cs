namespace kyrsproject
{
	partial class formManagerEditGoods
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formManagerEditGoods));
			this.dagvGoodsList = new System.Windows.Forms.DataGridView();
			this.dagvGoodsVars = new System.Windows.Forms.DataGridView();
			this.lablGoods = new System.Windows.Forms.Label();
			this.lablVariants = new System.Windows.Forms.Label();
			this.butnGoodsDelete = new System.Windows.Forms.Button();
			this.butnVariantsDelete = new System.Windows.Forms.Button();
			this.butnGoodsAdd = new System.Windows.Forms.Button();
			this.butnVariantsAdd = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dagvGoodsList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dagvGoodsVars)).BeginInit();
			this.SuspendLayout();
			// 
			// dagvGoodsList
			// 
			this.dagvGoodsList.AllowUserToAddRows = false;
			this.dagvGoodsList.AllowUserToDeleteRows = false;
			this.dagvGoodsList.AllowUserToResizeColumns = false;
			this.dagvGoodsList.AllowUserToResizeRows = false;
			this.dagvGoodsList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dagvGoodsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dagvGoodsList.Location = new System.Drawing.Point(16, 36);
			this.dagvGoodsList.MultiSelect = false;
			this.dagvGoodsList.Name = "dagvGoodsList";
			this.dagvGoodsList.Size = new System.Drawing.Size(355, 349);
			this.dagvGoodsList.TabIndex = 0;
			this.dagvGoodsList.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dagvGoodsList_CellEndEdit);
			this.dagvGoodsList.SelectionChanged += new System.EventHandler(this.dagvOrderList_SelectionChanged);
			// 
			// dagvGoodsVars
			// 
			this.dagvGoodsVars.AllowUserToAddRows = false;
			this.dagvGoodsVars.AllowUserToDeleteRows = false;
			this.dagvGoodsVars.AllowUserToResizeRows = false;
			this.dagvGoodsVars.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dagvGoodsVars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dagvGoodsVars.Location = new System.Drawing.Point(471, 36);
			this.dagvGoodsVars.MultiSelect = false;
			this.dagvGoodsVars.Name = "dagvGoodsVars";
			this.dagvGoodsVars.Size = new System.Drawing.Size(355, 349);
			this.dagvGoodsVars.TabIndex = 1;
			this.dagvGoodsVars.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dagvGoodsVars_CellEndEdit);
			// 
			// lablGoods
			// 
			this.lablGoods.AutoSize = true;
			this.lablGoods.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lablGoods.Location = new System.Drawing.Point(12, 9);
			this.lablGoods.Name = "lablGoods";
			this.lablGoods.Size = new System.Drawing.Size(157, 24);
			this.lablGoods.TabIndex = 12;
			this.lablGoods.Text = "Товары и услуги";
			// 
			// lablVariants
			// 
			this.lablVariants.AutoSize = true;
			this.lablVariants.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lablVariants.Location = new System.Drawing.Point(467, 9);
			this.lablVariants.Name = "lablVariants";
			this.lablVariants.Size = new System.Drawing.Size(212, 24);
			this.lablVariants.TabIndex = 13;
			this.lablVariants.Text = "Варианты выбранного";
			// 
			// butnGoodsDelete
			// 
			this.butnGoodsDelete.AutoSize = true;
			this.butnGoodsDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.butnGoodsDelete.Location = new System.Drawing.Point(16, 391);
			this.butnGoodsDelete.Name = "butnGoodsDelete";
			this.butnGoodsDelete.Size = new System.Drawing.Size(190, 23);
			this.butnGoodsDelete.TabIndex = 2;
			this.butnGoodsDelete.Text = "Удалить выбранный товар/услугу";
			this.butnGoodsDelete.UseVisualStyleBackColor = true;
			this.butnGoodsDelete.Click += new System.EventHandler(this.butnGoodsDelete_Click);
			// 
			// butnVariantsDelete
			// 
			this.butnVariantsDelete.AutoSize = true;
			this.butnVariantsDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.butnVariantsDelete.Location = new System.Drawing.Point(471, 391);
			this.butnVariantsDelete.Name = "butnVariantsDelete";
			this.butnVariantsDelete.Size = new System.Drawing.Size(165, 23);
			this.butnVariantsDelete.TabIndex = 4;
			this.butnVariantsDelete.Text = "Удалить выбранный вариант";
			this.butnVariantsDelete.UseVisualStyleBackColor = true;
			this.butnVariantsDelete.Click += new System.EventHandler(this.butnVariantsDelete_Click);
			// 
			// butnGoodsAdd
			// 
			this.butnGoodsAdd.AutoSize = true;
			this.butnGoodsAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.butnGoodsAdd.Location = new System.Drawing.Point(235, 391);
			this.butnGoodsAdd.Name = "butnGoodsAdd";
			this.butnGoodsAdd.Size = new System.Drawing.Size(136, 23);
			this.butnGoodsAdd.TabIndex = 3;
			this.butnGoodsAdd.Text = "Добавить товар/услугу";
			this.butnGoodsAdd.UseVisualStyleBackColor = true;
			this.butnGoodsAdd.Click += new System.EventHandler(this.butnGoodsAdd_Click);
			// 
			// butnVariantsAdd
			// 
			this.butnVariantsAdd.AutoSize = true;
			this.butnVariantsAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.butnVariantsAdd.Location = new System.Drawing.Point(715, 391);
			this.butnVariantsAdd.Name = "butnVariantsAdd";
			this.butnVariantsAdd.Size = new System.Drawing.Size(111, 23);
			this.butnVariantsAdd.TabIndex = 5;
			this.butnVariantsAdd.Text = "Добавить вариант";
			this.butnVariantsAdd.UseVisualStyleBackColor = true;
			this.butnVariantsAdd.Click += new System.EventHandler(this.butnVariantsAdd_Click);
			// 
			// formManagerEditGoods
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(838, 441);
			this.Controls.Add(this.butnVariantsAdd);
			this.Controls.Add(this.butnGoodsAdd);
			this.Controls.Add(this.butnVariantsDelete);
			this.Controls.Add(this.butnGoodsDelete);
			this.Controls.Add(this.lablVariants);
			this.Controls.Add(this.lablGoods);
			this.Controls.Add(this.dagvGoodsVars);
			this.Controls.Add(this.dagvGoodsList);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "formManagerEditGoods";
			this.Text = "Управление товарами и услугами";
			this.Load += new System.EventHandler(this.formManagerEditGoods_Load);
			((System.ComponentModel.ISupportInitialize)(this.dagvGoodsList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dagvGoodsVars)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dagvGoodsList;
		private System.Windows.Forms.DataGridView dagvGoodsVars;
		private System.Windows.Forms.Label lablGoods;
		private System.Windows.Forms.Label lablVariants;
		private System.Windows.Forms.Button butnGoodsDelete;
		private System.Windows.Forms.Button butnVariantsDelete;
		private System.Windows.Forms.Button butnGoodsAdd;
		private System.Windows.Forms.Button butnVariantsAdd;
	}
}