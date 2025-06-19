namespace kyrsproject
{
	partial class formOrderManagement
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formOrderManagement));
			this.lablOrderParts = new System.Windows.Forms.Label();
			this.lablOrders = new System.Windows.Forms.Label();
			this.dagvOrderPartList = new System.Windows.Forms.DataGridView();
			this.dagvOrderList = new System.Windows.Forms.DataGridView();
			this.butnOrderDelete = new System.Windows.Forms.Button();
			this.butnOrderComplete = new System.Windows.Forms.Button();
			this.butnOrderCancel = new System.Windows.Forms.Button();
			this.butnOrderAdd = new System.Windows.Forms.Button();
			this.panlWorker = new System.Windows.Forms.Panel();
			this.panlAdmin = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.dagvOrderPartList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dagvOrderList)).BeginInit();
			this.panlWorker.SuspendLayout();
			this.panlAdmin.SuspendLayout();
			this.SuspendLayout();
			// 
			// lablOrderParts
			// 
			this.lablOrderParts.AutoSize = true;
			this.lablOrderParts.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lablOrderParts.Location = new System.Drawing.Point(637, 18);
			this.lablOrderParts.Name = "lablOrderParts";
			this.lablOrderParts.Size = new System.Drawing.Size(302, 24);
			this.lablOrderParts.TabIndex = 21;
			this.lablOrderParts.Text = "Компоненты выбранного заказа";
			// 
			// lablOrders
			// 
			this.lablOrders.AutoSize = true;
			this.lablOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lablOrders.Location = new System.Drawing.Point(12, 18);
			this.lablOrders.Name = "lablOrders";
			this.lablOrders.Size = new System.Drawing.Size(75, 24);
			this.lablOrders.TabIndex = 20;
			this.lablOrders.Text = "Заказы";
			// 
			// dagvOrderPartList
			// 
			this.dagvOrderPartList.AllowUserToAddRows = false;
			this.dagvOrderPartList.AllowUserToDeleteRows = false;
			this.dagvOrderPartList.AllowUserToResizeRows = false;
			this.dagvOrderPartList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dagvOrderPartList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dagvOrderPartList.Location = new System.Drawing.Point(641, 45);
			this.dagvOrderPartList.MultiSelect = false;
			this.dagvOrderPartList.Name = "dagvOrderPartList";
			this.dagvOrderPartList.ReadOnly = true;
			this.dagvOrderPartList.Size = new System.Drawing.Size(611, 587);
			this.dagvOrderPartList.TabIndex = 2;
			// 
			// dagvOrderList
			// 
			this.dagvOrderList.AllowUserToAddRows = false;
			this.dagvOrderList.AllowUserToDeleteRows = false;
			this.dagvOrderList.AllowUserToResizeColumns = false;
			this.dagvOrderList.AllowUserToResizeRows = false;
			this.dagvOrderList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dagvOrderList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dagvOrderList.Location = new System.Drawing.Point(16, 45);
			this.dagvOrderList.MultiSelect = false;
			this.dagvOrderList.Name = "dagvOrderList";
			this.dagvOrderList.ReadOnly = true;
			this.dagvOrderList.Size = new System.Drawing.Size(611, 587);
			this.dagvOrderList.TabIndex = 1;
			this.dagvOrderList.SelectionChanged += new System.EventHandler(this.dagvOrderList_SelectionChanged);
			this.dagvOrderList.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.dagvOrderList_SortCompare);
			// 
			// butnOrderDelete
			// 
			this.butnOrderDelete.AutoSize = true;
			this.butnOrderDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.butnOrderDelete.Location = new System.Drawing.Point(3, 5);
			this.butnOrderDelete.Name = "butnOrderDelete";
			this.butnOrderDelete.Size = new System.Drawing.Size(154, 23);
			this.butnOrderDelete.TabIndex = 5;
			this.butnOrderDelete.Text = "Удалить выбранный заказ";
			this.butnOrderDelete.UseVisualStyleBackColor = true;
			this.butnOrderDelete.Click += new System.EventHandler(this.butnOrderDelete_Click);
			// 
			// butnOrderComplete
			// 
			this.butnOrderComplete.AutoSize = true;
			this.butnOrderComplete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.butnOrderComplete.Location = new System.Drawing.Point(171, 3);
			this.butnOrderComplete.Name = "butnOrderComplete";
			this.butnOrderComplete.Size = new System.Drawing.Size(167, 23);
			this.butnOrderComplete.TabIndex = 4;
			this.butnOrderComplete.Text = "Завершить выбранный заказ";
			this.butnOrderComplete.UseVisualStyleBackColor = true;
			this.butnOrderComplete.Click += new System.EventHandler(this.butnOrderComplete_Click);
			// 
			// butnOrderCancel
			// 
			this.butnOrderCancel.AutoSize = true;
			this.butnOrderCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.butnOrderCancel.Location = new System.Drawing.Point(4, 3);
			this.butnOrderCancel.Name = "butnOrderCancel";
			this.butnOrderCancel.Size = new System.Drawing.Size(161, 23);
			this.butnOrderCancel.TabIndex = 3;
			this.butnOrderCancel.Text = "Отменить выбранный заказ";
			this.butnOrderCancel.UseVisualStyleBackColor = true;
			this.butnOrderCancel.Click += new System.EventHandler(this.butnOrderCancel_Click);
			// 
			// butnOrderAdd
			// 
			this.butnOrderAdd.AutoSize = true;
			this.butnOrderAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.butnOrderAdd.Location = new System.Drawing.Point(344, 3);
			this.butnOrderAdd.Name = "butnOrderAdd";
			this.butnOrderAdd.Size = new System.Drawing.Size(127, 23);
			this.butnOrderAdd.TabIndex = 5;
			this.butnOrderAdd.Text = "Создать новый заказ";
			this.butnOrderAdd.UseVisualStyleBackColor = true;
			this.butnOrderAdd.Click += new System.EventHandler(this.butnOrderAdd_Click);
			// 
			// panlWorker
			// 
			this.panlWorker.Controls.Add(this.butnOrderAdd);
			this.panlWorker.Controls.Add(this.butnOrderCancel);
			this.panlWorker.Controls.Add(this.butnOrderComplete);
			this.panlWorker.Location = new System.Drawing.Point(16, 638);
			this.panlWorker.Name = "panlWorker";
			this.panlWorker.Size = new System.Drawing.Size(1240, 31);
			this.panlWorker.TabIndex = 23;
			// 
			// panlAdmin
			// 
			this.panlAdmin.Controls.Add(this.butnOrderDelete);
			this.panlAdmin.Location = new System.Drawing.Point(16, 638);
			this.panlAdmin.Name = "panlAdmin";
			this.panlAdmin.Size = new System.Drawing.Size(1240, 31);
			this.panlAdmin.TabIndex = 24;
			// 
			// formOrderManagement
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1264, 681);
			this.Controls.Add(this.panlAdmin);
			this.Controls.Add(this.panlWorker);
			this.Controls.Add(this.dagvOrderList);
			this.Controls.Add(this.dagvOrderPartList);
			this.Controls.Add(this.lablOrderParts);
			this.Controls.Add(this.lablOrders);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "formOrderManagement";
			this.Text = "Управление заказами";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formOrderManagement_FormClosing);
			this.Load += new System.EventHandler(this.formOrderManagement_Load);
			((System.ComponentModel.ISupportInitialize)(this.dagvOrderPartList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dagvOrderList)).EndInit();
			this.panlWorker.ResumeLayout(false);
			this.panlWorker.PerformLayout();
			this.panlAdmin.ResumeLayout(false);
			this.panlAdmin.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label lablOrderParts;
		private System.Windows.Forms.Label lablOrders;
		private System.Windows.Forms.DataGridView dagvOrderPartList;
		private System.Windows.Forms.DataGridView dagvOrderList;
		private System.Windows.Forms.Button butnOrderDelete;
		private System.Windows.Forms.Button butnOrderAdd;
		private System.Windows.Forms.Button butnOrderCancel;
		private System.Windows.Forms.Button butnOrderComplete;
		private System.Windows.Forms.Panel panlWorker;
		private System.Windows.Forms.Panel panlAdmin;
	}
}