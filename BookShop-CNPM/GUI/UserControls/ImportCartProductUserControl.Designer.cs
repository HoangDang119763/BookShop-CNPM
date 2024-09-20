namespace BookShop_CNPM.GUI.Vendor
{
	partial class ImportCartProductUserControl
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

		#region Component Designer generated code
      
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportCartProductUserControl));
            this.NameLb = new System.Windows.Forms.Label();
            this.amountPanel = new System.Windows.Forms.Panel();
            this.PlusBtn = new System.Windows.Forms.PictureBox();
            this.MinusBtn = new System.Windows.Forms.PictureBox();
            this.AmountTxt = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.DeleteBtn = new Guna.UI2.WinForms.Guna2CircleButton();
            this.BookImage = new System.Windows.Forms.PictureBox();
            this.IdLb = new System.Windows.Forms.Label();
            this.StockLb = new System.Windows.Forms.Label();
            this.ImportPriceTxb = new Guna.UI2.WinForms.Guna2TextBox();
            this.VndLb = new System.Windows.Forms.Label();
            this.BillIdLb = new System.Windows.Forms.Label();
            this.BillIdDetailLb = new System.Windows.Forms.Label();
            this.amountPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlusBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinusBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BookImage)).BeginInit();
            this.SuspendLayout();
            // 
            // NameLb
            // 
            this.NameLb.AutoEllipsis = true;
            this.NameLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.NameLb.Location = new System.Drawing.Point(143, 50);
            this.NameLb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NameLb.Name = "NameLb";
            this.NameLb.Size = new System.Drawing.Size(228, 26);
            this.NameLb.TabIndex = 1;
            this.NameLb.Text = "Book Name";
            // 
            // amountPanel
            // 
            this.amountPanel.BackColor = System.Drawing.Color.White;
            this.amountPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.amountPanel.Controls.Add(this.PlusBtn);
            this.amountPanel.Controls.Add(this.MinusBtn);
            this.amountPanel.Controls.Add(this.AmountTxt);
            this.amountPanel.Location = new System.Drawing.Point(147, 122);
            this.amountPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.amountPanel.Name = "amountPanel";
            this.amountPanel.Size = new System.Drawing.Size(123, 32);
            this.amountPanel.TabIndex = 0;
            // 
            // PlusBtn
            // 
            this.PlusBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PlusBtn.Image = ((System.Drawing.Image)(resources.GetObject("PlusBtn.Image")));
            this.PlusBtn.Location = new System.Drawing.Point(88, 0);
            this.PlusBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PlusBtn.Name = "PlusBtn";
            this.PlusBtn.Size = new System.Drawing.Size(33, 31);
            this.PlusBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PlusBtn.TabIndex = 1;
            this.PlusBtn.TabStop = false;
            this.PlusBtn.Click += new System.EventHandler(this.PlusBtn_Click);
            // 
            // MinusBtn
            // 
            this.MinusBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MinusBtn.Image = ((System.Drawing.Image)(resources.GetObject("MinusBtn.Image")));
            this.MinusBtn.Location = new System.Drawing.Point(0, 0);
            this.MinusBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinusBtn.Name = "MinusBtn";
            this.MinusBtn.Size = new System.Drawing.Size(33, 31);
            this.MinusBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MinusBtn.TabIndex = 0;
            this.MinusBtn.TabStop = false;
            this.MinusBtn.Click += new System.EventHandler(this.MinusBtn_Click);
            // 
            // AmountTxt
            // 
            this.AmountTxt.BackColor = System.Drawing.Color.White;
            this.AmountTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AmountTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.AmountTxt.Location = new System.Drawing.Point(35, 4);
            this.AmountTxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AmountTxt.MaxLength = 999;
            this.AmountTxt.Name = "AmountTxt";
            this.AmountTxt.Size = new System.Drawing.Size(51, 19);
            this.AmountTxt.TabIndex = 0;
            this.AmountTxt.Text = "1";
            this.AmountTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AmountTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AmountTxt_KeyPress);
            this.AmountTxt.Leave += new System.EventHandler(this.AmountTxt_Leave);
            this.AmountTxt.MouseLeave += new System.EventHandler(this.AmountTxt_MouseLeave);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.CheckedState.Parent = this.DeleteBtn;
            this.DeleteBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeleteBtn.CustomImages.Parent = this.DeleteBtn;
            this.DeleteBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.DeleteBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DeleteBtn.ForeColor = System.Drawing.Color.White;
            this.DeleteBtn.HoverState.Parent = this.DeleteBtn;
            this.DeleteBtn.Image = ((System.Drawing.Image)(resources.GetObject("DeleteBtn.Image")));
            this.DeleteBtn.ImageOffset = new System.Drawing.Point(0, -1);
            this.DeleteBtn.ImageSize = new System.Drawing.Size(23, 23);
            this.DeleteBtn.Location = new System.Drawing.Point(333, 5);
            this.DeleteBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.DeleteBtn.ShadowDecoration.Parent = this.DeleteBtn;
            this.DeleteBtn.Size = new System.Drawing.Size(40, 37);
            this.DeleteBtn.TabIndex = 1;
            this.DeleteBtn.TabStop = false;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // BookImage
            // 
            this.BookImage.ErrorImage = global::BookShop_CNPM.Properties.Resources.book_cover;
            this.BookImage.InitialImage = global::BookShop_CNPM.Properties.Resources.book_cover;
            this.BookImage.Location = new System.Drawing.Point(1, 11);
            this.BookImage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BookImage.Name = "BookImage";
            this.BookImage.Size = new System.Drawing.Size(133, 146);
            this.BookImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BookImage.TabIndex = 0;
            this.BookImage.TabStop = false;
            // 
            // IdLb
            // 
            this.IdLb.Location = new System.Drawing.Point(359, 156);
            this.IdLb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.IdLb.Name = "IdLb";
            this.IdLb.Size = new System.Drawing.Size(19, 12);
            this.IdLb.TabIndex = 10;
            this.IdLb.Visible = false;
            // 
            // StockLb
            // 
            this.StockLb.AutoSize = true;
            this.StockLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.StockLb.ForeColor = System.Drawing.Color.Gray;
            this.StockLb.Location = new System.Drawing.Point(144, 90);
            this.StockLb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StockLb.Name = "StockLb";
            this.StockLb.Size = new System.Drawing.Size(33, 18);
            this.StockLb.TabIndex = 2;
            this.StockLb.Text = "SL:";
            // 
            // ImportPriceTxb
            // 
            this.ImportPriceTxb.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.ImportPriceTxb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ImportPriceTxb.DefaultText = "";
            this.ImportPriceTxb.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.ImportPriceTxb.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.ImportPriceTxb.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ImportPriceTxb.DisabledState.Parent = this.ImportPriceTxb;
            this.ImportPriceTxb.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ImportPriceTxb.Enabled = false;
            this.ImportPriceTxb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ImportPriceTxb.FocusedState.Parent = this.ImportPriceTxb;
            this.ImportPriceTxb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ImportPriceTxb.ForeColor = System.Drawing.Color.Black;
            this.ImportPriceTxb.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ImportPriceTxb.HoverState.Parent = this.ImportPriceTxb;
            this.ImportPriceTxb.Location = new System.Drawing.Point(11, 172);
            this.ImportPriceTxb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ImportPriceTxb.Name = "ImportPriceTxb";
            this.ImportPriceTxb.PasswordChar = '\0';
            this.ImportPriceTxb.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.ImportPriceTxb.PlaceholderText = "Giá nhập ...";
            this.ImportPriceTxb.SelectedText = "";
            this.ImportPriceTxb.ShadowDecoration.Parent = this.ImportPriceTxb;
            this.ImportPriceTxb.Size = new System.Drawing.Size(287, 37);
            this.ImportPriceTxb.TabIndex = 1;
            this.ImportPriceTxb.TextChanged += new System.EventHandler(this.ImportPriceTxb_TextChanged);
            this.ImportPriceTxb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ImportPriceTxb_KeyPress);
            // 
            // VndLb
            // 
            this.VndLb.AutoSize = true;
            this.VndLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.VndLb.Location = new System.Drawing.Point(311, 175);
            this.VndLb.Margin = new System.Windows.Forms.Padding(27, 37, 4, 6);
            this.VndLb.Name = "VndLb";
            this.VndLb.Size = new System.Drawing.Size(57, 25);
            this.VndLb.TabIndex = 28;
            this.VndLb.Text = "VND";
            this.VndLb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BillIdLb
            // 
            this.BillIdLb.AutoSize = true;
            this.BillIdLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.BillIdLb.ForeColor = System.Drawing.Color.Gray;
            this.BillIdLb.Location = new System.Drawing.Point(145, 16);
            this.BillIdLb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.BillIdLb.Name = "BillIdLb";
            this.BillIdLb.Size = new System.Drawing.Size(69, 18);
            this.BillIdLb.TabIndex = 30;
            this.BillIdLb.Text = "Mã đơn:";
            // 
            // BillIdDetailLb
            // 
            this.BillIdDetailLb.AutoEllipsis = true;
            this.BillIdDetailLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.BillIdDetailLb.ForeColor = System.Drawing.Color.Gray;
            this.BillIdDetailLb.Location = new System.Drawing.Point(208, 16);
            this.BillIdDetailLb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.BillIdDetailLb.Name = "BillIdDetailLb";
            this.BillIdDetailLb.Size = new System.Drawing.Size(120, 22);
            this.BillIdDetailLb.TabIndex = 31;
            // 
            // ImportCartProductUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BillIdDetailLb);
            this.Controls.Add(this.BillIdLb);
            this.Controls.Add(this.ImportPriceTxb);
            this.Controls.Add(this.VndLb);
            this.Controls.Add(this.IdLb);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.amountPanel);
            this.Controls.Add(this.StockLb);
            this.Controls.Add(this.NameLb);
            this.Controls.Add(this.BookImage);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ImportCartProductUserControl";
            this.Size = new System.Drawing.Size(377, 222);
            this.amountPanel.ResumeLayout(false);
            this.amountPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlusBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinusBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BookImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox BookImage;
		private System.Windows.Forms.Label NameLb;
		private System.Windows.Forms.PictureBox PlusBtn;
		private System.Windows.Forms.PictureBox MinusBtn;
		private System.Windows.Forms.ToolTip toolTip1;
		internal System.Windows.Forms.Label IdLb;
		internal System.Windows.Forms.TextBox AmountTxt;
		private System.Windows.Forms.Label StockLb;
		private System.Windows.Forms.Label VndLb;
		private System.Windows.Forms.Label BillIdLb;
		public System.Windows.Forms.Label BillIdDetailLb;
		public System.Windows.Forms.Panel amountPanel;
		public Guna.UI2.WinForms.Guna2TextBox ImportPriceTxb;
		public Guna.UI2.WinForms.Guna2CircleButton DeleteBtn;
	}
}
