﻿namespace BookShop_CNPM.GUI.Manager
{
    partial class CustomerChangeBillGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerChangeBillGUI));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.staffCbx = new Guna.UI.WinForms.GunaComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.detailsBtn = new Guna.UI.WinForms.GunaAdvenceButton();
            this.printPdfBtn = new Guna.UI.WinForms.GunaAdvenceButton();
            this.exportBtn = new Guna.UI.WinForms.GunaAdvenceButton();
            this.refreshBtn = new Guna.UI.WinForms.GunaAdvenceButton();
            this.addBtn = new Guna.UI.WinForms.GunaAdvenceButton();
            this.dgvCustomerChangeBill = new Guna.UI.WinForms.GunaDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.line1 = new System.Windows.Forms.Panel();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dateTimeFrom = new Guna.UI.WinForms.GunaDateTimePicker();
            this.panel5 = new System.Windows.Forms.Panel();
            this.filterCkx = new Guna.UI.WinForms.GunaMediumCheckBox();
            this.dateTimeTo = new Guna.UI.WinForms.GunaDateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.searchInput = new Guna.UI2.WinForms.Guna2TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.closeBtn = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerChangeBill)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeBtn)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // staffCbx
            // 
            this.staffCbx.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.staffCbx.BackColor = System.Drawing.Color.Transparent;
            this.staffCbx.BaseColor = System.Drawing.Color.White;
            this.staffCbx.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.staffCbx.BorderSize = 1;
            this.staffCbx.Cursor = System.Windows.Forms.Cursors.Hand;
            this.staffCbx.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.staffCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.staffCbx.FocusedColor = System.Drawing.Color.Empty;
            this.staffCbx.Font = new System.Drawing.Font("#9Slide03 Cabin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staffCbx.ForeColor = System.Drawing.Color.Black;
            this.staffCbx.FormattingEnabled = true;
            this.staffCbx.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.staffCbx.ItemHeight = 30;
            this.staffCbx.Location = new System.Drawing.Point(357, 12);
            this.staffCbx.Margin = new System.Windows.Forms.Padding(3, 3, 100, 3);
            this.staffCbx.Name = "staffCbx";
            this.staffCbx.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.staffCbx.OnHoverItemForeColor = System.Drawing.Color.White;
            this.staffCbx.Radius = 6;
            this.staffCbx.Size = new System.Drawing.Size(181, 36);
            this.staffCbx.TabIndex = 38;
            this.staffCbx.TabStop = false;
            this.staffCbx.SelectedIndexChanged += new System.EventHandler(this.staffCbx_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.panel1.Controls.Add(this.detailsBtn);
            this.panel1.Controls.Add(this.printPdfBtn);
            this.panel1.Controls.Add(this.exportBtn);
            this.panel1.Controls.Add(this.refreshBtn);
            this.panel1.Controls.Add(this.addBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 630);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1044, 54);
            this.panel1.TabIndex = 2;
            // 
            // detailsBtn
            // 
            this.detailsBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.detailsBtn.AnimationHoverSpeed = 0.07F;
            this.detailsBtn.AnimationSpeed = 0.03F;
            this.detailsBtn.BackColor = System.Drawing.Color.Transparent;
            this.detailsBtn.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.detailsBtn.BorderColor = System.Drawing.Color.Black;
            this.detailsBtn.CheckedBaseColor = System.Drawing.Color.Gray;
            this.detailsBtn.CheckedBorderColor = System.Drawing.Color.Black;
            this.detailsBtn.CheckedForeColor = System.Drawing.Color.White;
            this.detailsBtn.CheckedImage = ((System.Drawing.Image)(resources.GetObject("detailsBtn.CheckedImage")));
            this.detailsBtn.CheckedLineColor = System.Drawing.Color.DimGray;
            this.detailsBtn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.detailsBtn.FocusedColor = System.Drawing.Color.PaleTurquoise;
            this.detailsBtn.Font = new System.Drawing.Font("#9Slide03 Cabin Condensed Bold", 10.2F, System.Drawing.FontStyle.Bold);
            this.detailsBtn.ForeColor = System.Drawing.Color.White;
            this.detailsBtn.Image = ((System.Drawing.Image)(resources.GetObject("detailsBtn.Image")));
            this.detailsBtn.ImageSize = new System.Drawing.Size(20, 20);
            this.detailsBtn.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.detailsBtn.Location = new System.Drawing.Point(914, 6);
            this.detailsBtn.Name = "detailsBtn";
            this.detailsBtn.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.detailsBtn.OnHoverBorderColor = System.Drawing.Color.Transparent;
            this.detailsBtn.OnHoverForeColor = System.Drawing.Color.White;
            this.detailsBtn.OnHoverImage = null;
            this.detailsBtn.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.detailsBtn.OnPressedColor = System.Drawing.Color.Black;
            this.detailsBtn.Radius = 6;
            this.detailsBtn.Size = new System.Drawing.Size(118, 42);
            this.detailsBtn.TabIndex = 4;
            this.detailsBtn.Text = "Xem chi tiết";
            this.detailsBtn.Click += new System.EventHandler(this.detailsBtn_Click);
            // 
            // printPdfBtn
            // 
            this.printPdfBtn.AnimationHoverSpeed = 0.07F;
            this.printPdfBtn.AnimationSpeed = 0.03F;
            this.printPdfBtn.BackColor = System.Drawing.Color.Transparent;
            this.printPdfBtn.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.printPdfBtn.BorderColor = System.Drawing.Color.Black;
            this.printPdfBtn.CheckedBaseColor = System.Drawing.Color.Gray;
            this.printPdfBtn.CheckedBorderColor = System.Drawing.Color.Black;
            this.printPdfBtn.CheckedForeColor = System.Drawing.Color.White;
            this.printPdfBtn.CheckedImage = null;
            this.printPdfBtn.CheckedLineColor = System.Drawing.Color.DimGray;
            this.printPdfBtn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.printPdfBtn.FocusedColor = System.Drawing.Color.PaleTurquoise;
            this.printPdfBtn.Font = new System.Drawing.Font("#9Slide03 Cabin Condensed Bold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printPdfBtn.ForeColor = System.Drawing.Color.White;
            this.printPdfBtn.Image = ((System.Drawing.Image)(resources.GetObject("printPdfBtn.Image")));
            this.printPdfBtn.ImageSize = new System.Drawing.Size(20, 20);
            this.printPdfBtn.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.printPdfBtn.Location = new System.Drawing.Point(251, 6);
            this.printPdfBtn.Name = "printPdfBtn";
            this.printPdfBtn.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.printPdfBtn.OnHoverBorderColor = System.Drawing.Color.Transparent;
            this.printPdfBtn.OnHoverForeColor = System.Drawing.Color.White;
            this.printPdfBtn.OnHoverImage = null;
            this.printPdfBtn.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.printPdfBtn.OnPressedColor = System.Drawing.Color.Black;
            this.printPdfBtn.Radius = 6;
            this.printPdfBtn.Size = new System.Drawing.Size(92, 42);
            this.printPdfBtn.TabIndex = 2;
            this.printPdfBtn.Text = "In PDF";
            this.printPdfBtn.Click += new System.EventHandler(this.printPdfBtn_Click);
            // 
            // exportBtn
            // 
            this.exportBtn.AnimationHoverSpeed = 0.07F;
            this.exportBtn.AnimationSpeed = 0.03F;
            this.exportBtn.BackColor = System.Drawing.Color.Transparent;
            this.exportBtn.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.exportBtn.BorderColor = System.Drawing.Color.Black;
            this.exportBtn.CheckedBaseColor = System.Drawing.Color.Gray;
            this.exportBtn.CheckedBorderColor = System.Drawing.Color.Black;
            this.exportBtn.CheckedForeColor = System.Drawing.Color.White;
            this.exportBtn.CheckedImage = null;
            this.exportBtn.CheckedLineColor = System.Drawing.Color.DimGray;
            this.exportBtn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.exportBtn.FocusedColor = System.Drawing.Color.PaleTurquoise;
            this.exportBtn.Font = new System.Drawing.Font("#9Slide03 Cabin Condensed Bold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportBtn.ForeColor = System.Drawing.Color.White;
            this.exportBtn.Image = ((System.Drawing.Image)(resources.GetObject("exportBtn.Image")));
            this.exportBtn.ImageSize = new System.Drawing.Size(20, 20);
            this.exportBtn.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.exportBtn.Location = new System.Drawing.Point(124, 6);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.exportBtn.OnHoverBorderColor = System.Drawing.Color.Transparent;
            this.exportBtn.OnHoverForeColor = System.Drawing.Color.White;
            this.exportBtn.OnHoverImage = null;
            this.exportBtn.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.exportBtn.OnPressedColor = System.Drawing.Color.Black;
            this.exportBtn.Radius = 6;
            this.exportBtn.Size = new System.Drawing.Size(121, 42);
            this.exportBtn.TabIndex = 1;
            this.exportBtn.Text = "Xuất excel";
            this.exportBtn.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // refreshBtn
            // 
            this.refreshBtn.AnimationHoverSpeed = 0.07F;
            this.refreshBtn.AnimationSpeed = 0.03F;
            this.refreshBtn.BackColor = System.Drawing.Color.Transparent;
            this.refreshBtn.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.refreshBtn.BorderColor = System.Drawing.Color.Black;
            this.refreshBtn.CheckedBaseColor = System.Drawing.Color.Gray;
            this.refreshBtn.CheckedBorderColor = System.Drawing.Color.Black;
            this.refreshBtn.CheckedForeColor = System.Drawing.Color.White;
            this.refreshBtn.CheckedImage = null;
            this.refreshBtn.CheckedLineColor = System.Drawing.Color.DimGray;
            this.refreshBtn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.refreshBtn.FocusedColor = System.Drawing.Color.PaleTurquoise;
            this.refreshBtn.Font = new System.Drawing.Font("#9Slide03 Cabin Condensed Bold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshBtn.ForeColor = System.Drawing.Color.White;
            this.refreshBtn.Image = ((System.Drawing.Image)(resources.GetObject("refreshBtn.Image")));
            this.refreshBtn.ImageSize = new System.Drawing.Size(20, 20);
            this.refreshBtn.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.refreshBtn.Location = new System.Drawing.Point(11, 6);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.refreshBtn.OnHoverBorderColor = System.Drawing.Color.Transparent;
            this.refreshBtn.OnHoverForeColor = System.Drawing.Color.White;
            this.refreshBtn.OnHoverImage = null;
            this.refreshBtn.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.refreshBtn.OnPressedColor = System.Drawing.Color.Black;
            this.refreshBtn.Radius = 6;
            this.refreshBtn.Size = new System.Drawing.Size(107, 42);
            this.refreshBtn.TabIndex = 0;
            this.refreshBtn.Text = "Làm mới";
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.addBtn.AnimationHoverSpeed = 0.07F;
            this.addBtn.AnimationSpeed = 0.03F;
            this.addBtn.BackColor = System.Drawing.Color.Transparent;
            this.addBtn.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.addBtn.BorderColor = System.Drawing.Color.Black;
            this.addBtn.CheckedBaseColor = System.Drawing.Color.Gray;
            this.addBtn.CheckedBorderColor = System.Drawing.Color.Black;
            this.addBtn.CheckedForeColor = System.Drawing.Color.White;
            this.addBtn.CheckedImage = null;
            this.addBtn.CheckedLineColor = System.Drawing.Color.DimGray;
            this.addBtn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.addBtn.FocusedColor = System.Drawing.Color.PaleTurquoise;
            this.addBtn.Font = new System.Drawing.Font("#9Slide03 Cabin Condensed Bold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBtn.ForeColor = System.Drawing.Color.White;
            this.addBtn.Image = ((System.Drawing.Image)(resources.GetObject("addBtn.Image")));
            this.addBtn.ImageSize = new System.Drawing.Size(20, 20);
            this.addBtn.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.addBtn.Location = new System.Drawing.Point(791, 6);
            this.addBtn.Name = "addBtn";
            this.addBtn.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.addBtn.OnHoverBorderColor = System.Drawing.Color.Transparent;
            this.addBtn.OnHoverForeColor = System.Drawing.Color.White;
            this.addBtn.OnHoverImage = null;
            this.addBtn.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.addBtn.OnPressedColor = System.Drawing.Color.Black;
            this.addBtn.Radius = 6;
            this.addBtn.Size = new System.Drawing.Size(117, 42);
            this.addBtn.TabIndex = 3;
            this.addBtn.Text = "Thêm mới";
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // dgvCustomerChangeBill
            // 
            this.dgvCustomerChangeBill.AllowUserToAddRows = false;
            this.dgvCustomerChangeBill.AllowUserToDeleteRows = false;
            this.dgvCustomerChangeBill.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvCustomerChangeBill.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCustomerChangeBill.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomerChangeBill.BackgroundColor = System.Drawing.Color.White;
            this.dgvCustomerChangeBill.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCustomerChangeBill.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCustomerChangeBill.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("#9Slide03 Cabin", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCustomerChangeBill.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCustomerChangeBill.ColumnHeadersHeight = 50;
            this.dgvCustomerChangeBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCustomerChangeBill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column10,
            this.Column3,
            this.Column5,
            this.Column8,
            this.Column4});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("#9Slide03 Cabin", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCustomerChangeBill.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCustomerChangeBill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustomerChangeBill.EnableHeadersVisualStyles = false;
            this.dgvCustomerChangeBill.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCustomerChangeBill.Location = new System.Drawing.Point(0, 69);
            this.dgvCustomerChangeBill.Name = "dgvCustomerChangeBill";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("#9Slide03 Cabin", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCustomerChangeBill.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCustomerChangeBill.RowHeadersVisible = false;
            this.dgvCustomerChangeBill.RowHeadersWidth = 51;
            this.dgvCustomerChangeBill.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCustomerChangeBill.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCustomerChangeBill.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvCustomerChangeBill.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCustomerChangeBill.RowTemplate.Height = 75;
            this.dgvCustomerChangeBill.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCustomerChangeBill.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvCustomerChangeBill.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomerChangeBill.Size = new System.Drawing.Size(1044, 615);
            this.dgvCustomerChangeBill.TabIndex = 1;
            this.dgvCustomerChangeBill.TabStop = false;
            this.dgvCustomerChangeBill.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna;
            this.dgvCustomerChangeBill.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCustomerChangeBill.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvCustomerChangeBill.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvCustomerChangeBill.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvCustomerChangeBill.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvCustomerChangeBill.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvCustomerChangeBill.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCustomerChangeBill.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.dgvCustomerChangeBill.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvCustomerChangeBill.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("#9Slide03 Cabin", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCustomerChangeBill.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvCustomerChangeBill.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCustomerChangeBill.ThemeStyle.HeaderStyle.Height = 50;
            this.dgvCustomerChangeBill.ThemeStyle.ReadOnly = false;
            this.dgvCustomerChangeBill.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCustomerChangeBill.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCustomerChangeBill.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("#9Slide03 Cabin", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCustomerChangeBill.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvCustomerChangeBill.ThemeStyle.RowsStyle.Height = 75;
            this.dgvCustomerChangeBill.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCustomerChangeBill.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvCustomerChangeBill.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomerChangeBill_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.FillWeight = 61.60671F;
            this.Column1.HeaderText = "Mã Phiếu";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.ToolTipText = "Mã Phiếu";
            // 
            // Column10
            // 
            this.Column10.FillWeight = 61.60671F;
            this.Column10.HeaderText = "Mã Hóa Đơn";
            this.Column10.MinimumWidth = 6;
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column10.ToolTipText = "Mã Hóa Đơn";
            // 
            // Column3
            // 
            this.Column3.FillWeight = 61.60671F;
            this.Column3.HeaderText = "Nhân Viên Lập";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column3.ToolTipText = "Nhân Viên Lập";
            // 
            // Column5
            // 
            this.Column5.FillWeight = 61.60671F;
            this.Column5.HeaderText = "Tình Trạng Sản Phẩm";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column5.ToolTipText = "Tình Trạng Sản Phẩm";
            // 
            // Column8
            // 
            this.Column8.FillWeight = 61.60671F;
            this.Column8.HeaderText = "Lý Do";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.ToolTipText = "Lý Do";
            // 
            // Column4
            // 
            this.Column4.FillWeight = 61.60671F;
            this.Column4.HeaderText = "Ngày Lập";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column4.ToolTipText = "Ngày Lập";
            // 
            // Column6
            // 
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Width = 125;
            // 
            // Column2
            // 
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // Column7
            // 
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.Width = 125;
            // 
            // line1
            // 
            this.line1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(212)))), ((int)(((byte)(191)))));
            this.line1.Location = new System.Drawing.Point(18, 46);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(255, 1);
            this.line1.TabIndex = 32;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Hình Ảnh";
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.dataGridViewImageColumn1.MinimumWidth = 100;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 106;
            // 
            // dateTimeFrom
            // 
            this.dateTimeFrom.BackColor = System.Drawing.Color.Transparent;
            this.dateTimeFrom.BaseColor = System.Drawing.Color.White;
            this.dateTimeFrom.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.dateTimeFrom.BorderSize = 1;
            this.dateTimeFrom.CustomFormat = null;
            this.dateTimeFrom.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dateTimeFrom.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.dateTimeFrom.Font = new System.Drawing.Font("#9Slide03 Cabin", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeFrom.ForeColor = System.Drawing.Color.Black;
            this.dateTimeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeFrom.Location = new System.Drawing.Point(81, 0);
            this.dateTimeFrom.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dateTimeFrom.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dateTimeFrom.Name = "dateTimeFrom";
            this.dateTimeFrom.OnHoverBaseColor = System.Drawing.Color.White;
            this.dateTimeFrom.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.dateTimeFrom.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.dateTimeFrom.OnPressedColor = System.Drawing.Color.Black;
            this.dateTimeFrom.Radius = 6;
            this.dateTimeFrom.Size = new System.Drawing.Size(130, 36);
            this.dateTimeFrom.TabIndex = 40;
            this.dateTimeFrom.Text = "8/30/2023";
            this.dateTimeFrom.Value = new System.DateTime(2023, 8, 30, 19, 55, 8, 854);
            this.dateTimeFrom.ValueChanged += new System.EventHandler(this.dateTimeFrom_ValueChanged);
            // 
            // panel5
            // 
            this.panel5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.panel5.Controls.Add(this.filterCkx);
            this.panel5.Controls.Add(this.dateTimeTo);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.dateTimeFrom);
            this.panel5.Location = new System.Drawing.Point(551, 12);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(400, 36);
            this.panel5.TabIndex = 1;
            // 
            // filterCkx
            // 
            this.filterCkx.BaseColor = System.Drawing.Color.White;
            this.filterCkx.CheckedOffColor = System.Drawing.Color.LightGray;
            this.filterCkx.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.filterCkx.FillColor = System.Drawing.Color.White;
            this.filterCkx.Location = new System.Drawing.Point(17, 9);
            this.filterCkx.Name = "filterCkx";
            this.filterCkx.Size = new System.Drawing.Size(20, 20);
            this.filterCkx.TabIndex = 1;
            this.filterCkx.CheckedChanged += new System.EventHandler(this.filterCkx_CheckedChanged);
            // 
            // dateTimeTo
            // 
            this.dateTimeTo.BackColor = System.Drawing.Color.Transparent;
            this.dateTimeTo.BaseColor = System.Drawing.Color.White;
            this.dateTimeTo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.dateTimeTo.BorderSize = 1;
            this.dateTimeTo.CustomFormat = null;
            this.dateTimeTo.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dateTimeTo.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.dateTimeTo.Font = new System.Drawing.Font("#9Slide03 Cabin", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeTo.ForeColor = System.Drawing.Color.Black;
            this.dateTimeTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeTo.Location = new System.Drawing.Point(270, 0);
            this.dateTimeTo.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dateTimeTo.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dateTimeTo.Name = "dateTimeTo";
            this.dateTimeTo.OnHoverBaseColor = System.Drawing.Color.White;
            this.dateTimeTo.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.dateTimeTo.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.dateTimeTo.OnPressedColor = System.Drawing.Color.Black;
            this.dateTimeTo.Radius = 6;
            this.dateTimeTo.Size = new System.Drawing.Size(130, 36);
            this.dateTimeTo.TabIndex = 42;
            this.dateTimeTo.Text = "8/30/2023";
            this.dateTimeTo.Value = new System.DateTime(2023, 8, 30, 19, 55, 8, 854);
            this.dateTimeTo.ValueChanged += new System.EventHandler(this.dateTimeTo_ValueChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("#9Slide03 Cabin", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(217, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 36);
            this.label3.TabIndex = 41;
            this.label3.Text = "- Đến :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("#9Slide03 Cabin", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, -1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 37);
            this.label2.TabIndex = 0;
            this.label2.Text = "Từ :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // searchInput
            // 
            this.searchInput.BackColor = System.Drawing.Color.Transparent;
            this.searchInput.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.searchInput.BorderThickness = 0;
            this.searchInput.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.searchInput.DefaultText = "";
            this.searchInput.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.searchInput.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.searchInput.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.searchInput.DisabledState.Parent = this.searchInput;
            this.searchInput.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.searchInput.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.searchInput.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.searchInput.FocusedState.Parent = this.searchInput;
            this.searchInput.Font = new System.Drawing.Font("#9Slide03 Cabin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchInput.ForeColor = System.Drawing.Color.Black;
            this.searchInput.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.searchInput.HoverState.Parent = this.searchInput;
            this.searchInput.Location = new System.Drawing.Point(11, 11);
            this.searchInput.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.searchInput.Name = "searchInput";
            this.searchInput.PasswordChar = '\0';
            this.searchInput.PlaceholderText = "Tìm kiếm theo mã phiếu đổi";
            this.searchInput.SelectedText = "";
            this.searchInput.ShadowDecoration.Parent = this.searchInput;
            this.searchInput.Size = new System.Drawing.Size(219, 30);
            this.searchInput.TabIndex = 0;
            this.searchInput.TextChanged += new System.EventHandler(this.searchInput_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(237, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 33;
            this.pictureBox1.TabStop = false;
            // 
            // closeBtn
            // 
            this.closeBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.closeBtn.Image = ((System.Drawing.Image)(resources.GetObject("closeBtn.Image")));
            this.closeBtn.Location = new System.Drawing.Point(958, 9);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(69, 40);
            this.closeBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.closeBtn.TabIndex = 50;
            this.closeBtn.TabStop = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.line1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.staffCbx);
            this.panel2.Controls.Add(this.closeBtn);
            this.panel2.Controls.Add(this.searchInput);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1044, 69);
            this.panel2.TabIndex = 0;
            // 
            // CustomerChangeBillGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1044, 684);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvCustomerChangeBill);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("#9Slide03 Cabin", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CustomerChangeBillGUI";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustomerChangeBillGUI";
            this.Load += new System.EventHandler(this.CustomerChangeBillGUI_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerChangeBill)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeBtn)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI.WinForms.GunaComboBox staffCbx;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI.WinForms.GunaAdvenceButton exportBtn;
        private Guna.UI.WinForms.GunaAdvenceButton refreshBtn;
        private Guna.UI.WinForms.GunaAdvenceButton addBtn;
        private Guna.UI.WinForms.GunaDataGridView dgvCustomerChangeBill;
        private System.Windows.Forms.Panel line1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private Guna.UI.WinForms.GunaDateTimePicker dateTimeFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.Panel panel5;
        private Guna.UI.WinForms.GunaDateTimePicker dateTimeTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Guna.UI.WinForms.GunaMediumCheckBox filterCkx;
        private Guna.UI2.WinForms.Guna2TextBox searchInput;
        private Guna.UI.WinForms.GunaAdvenceButton printPdfBtn;
        private System.Windows.Forms.PictureBox closeBtn;
        private Guna.UI.WinForms.GunaAdvenceButton detailsBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}