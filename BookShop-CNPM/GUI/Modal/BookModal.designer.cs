﻿namespace BookShop_CNPM.GUI.Modal
{
    partial class BookModal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookModal));
            this.label1 = new System.Windows.Forms.Label();
            this.cancelBtn = new Guna.UI.WinForms.GunaButton();
            this.submitBtn = new Guna.UI.WinForms.GunaButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.errorImageMsg = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.addBookTypeBtn = new System.Windows.Forms.Button();
            this.errorBookTypeMsg = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.bookTypeCbx = new Guna.UI.WinForms.GunaComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAddTacGia = new System.Windows.Forms.Button();
            this.errorAuthorMsg = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.authorCbx = new Guna.UI.WinForms.GunaComboBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.addPublisherBtn = new System.Windows.Forms.Button();
            this.errorPublisherMsg = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.publisherCbx = new Guna.UI.WinForms.GunaComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bookNameTxt = new Guna.UI2.WinForms.Guna2TextBox();
            this.errorBookNameMsg = new System.Windows.Forms.Label();
            this.nameLine = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(629, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thêm Sách";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Animated = true;
            this.cancelBtn.AnimationHoverSpeed = 0.05F;
            this.cancelBtn.AnimationSpeed = 0.05F;
            this.cancelBtn.BackColor = System.Drawing.Color.Transparent;
            this.cancelBtn.BaseColor = System.Drawing.Color.White;
            this.cancelBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.cancelBtn.BorderSize = 2;
            this.cancelBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cancelBtn.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(159)))), ((int)(((byte)(147)))));
            this.cancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.cancelBtn.Image = null;
            this.cancelBtn.ImageSize = new System.Drawing.Size(20, 20);
            this.cancelBtn.Location = new System.Drawing.Point(90, 707);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.cancelBtn.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.cancelBtn.OnHoverForeColor = System.Drawing.Color.White;
            this.cancelBtn.OnHoverImage = null;
            this.cancelBtn.OnPressedColor = System.Drawing.Color.White;
            this.cancelBtn.Radius = 22;
            this.cancelBtn.Size = new System.Drawing.Size(200, 50);
            this.cancelBtn.TabIndex = 8;
            this.cancelBtn.Text = "Hủy";
            this.cancelBtn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // submitBtn
            // 
            this.submitBtn.Animated = true;
            this.submitBtn.AnimationHoverSpeed = 0.05F;
            this.submitBtn.AnimationSpeed = 0.05F;
            this.submitBtn.BackColor = System.Drawing.Color.Transparent;
            this.submitBtn.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.submitBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.submitBtn.BorderSize = 2;
            this.submitBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.submitBtn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.submitBtn.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(159)))), ((int)(((byte)(147)))));
            this.submitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitBtn.ForeColor = System.Drawing.Color.White;
            this.submitBtn.Image = null;
            this.submitBtn.ImageSize = new System.Drawing.Size(20, 20);
            this.submitBtn.Location = new System.Drawing.Point(334, 707);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.OnHoverBaseColor = System.Drawing.Color.White;
            this.submitBtn.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.submitBtn.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.submitBtn.OnHoverImage = null;
            this.submitBtn.OnPressedColor = System.Drawing.Color.Black;
            this.submitBtn.Radius = 22;
            this.submitBtn.Size = new System.Drawing.Size(200, 50);
            this.submitBtn.TabIndex = 9;
            this.submitBtn.Text = "Lưu";
            this.submitBtn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.submitBtn.Click += new System.EventHandler(this.gunaButton1_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.errorImageMsg);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.guna2PictureBox1);
            this.panel5.Controls.Add(this.guna2PictureBox2);
            this.panel5.Location = new System.Drawing.Point(3, 379);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(594, 249);
            this.panel5.TabIndex = 4;
            // 
            // errorImageMsg
            // 
            this.errorImageMsg.AutoSize = true;
            this.errorImageMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.errorImageMsg.ForeColor = System.Drawing.Color.Red;
            this.errorImageMsg.Location = new System.Drawing.Point(165, 219);
            this.errorImageMsg.Name = "errorImageMsg";
            this.errorImageMsg.Size = new System.Drawing.Size(0, 20);
            this.errorImageMsg.TabIndex = 11;
            this.errorImageMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(3, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 49);
            this.label2.TabIndex = 34;
            this.label2.Text = "Hình ảnh:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BorderRadius = 16;
            this.guna2PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.Location = new System.Drawing.Point(266, 12);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.ShadowDecoration.Parent = this.guna2PictureBox1;
            this.guna2PictureBox1.Size = new System.Drawing.Size(149, 193);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 13;
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.Click += new System.EventHandler(this.guna2PictureBox1_Click);
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.BorderRadius = 16;
            this.guna2PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2PictureBox2.Image = global::BookShop_CNPM.Properties.Resources.book_cover;
            this.guna2PictureBox2.InitialImage = null;
            this.guna2PictureBox2.Location = new System.Drawing.Point(266, 11);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.ShadowDecoration.Parent = this.guna2PictureBox2;
            this.guna2PictureBox2.Size = new System.Drawing.Size(149, 193);
            this.guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox2.TabIndex = 14;
            this.guna2PictureBox2.TabStop = false;
            this.guna2PictureBox2.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.addBookTypeBtn);
            this.panel3.Controls.Add(this.errorBookTypeMsg);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.bookTypeCbx);
            this.panel3.Location = new System.Drawing.Point(3, 285);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(594, 88);
            this.panel3.TabIndex = 3;
            // 
            // addBookTypeBtn
            // 
            this.addBookTypeBtn.Enabled = false;
            this.addBookTypeBtn.Image = ((System.Drawing.Image)(resources.GetObject("addBookTypeBtn.Image")));
            this.addBookTypeBtn.Location = new System.Drawing.Point(536, 12);
            this.addBookTypeBtn.Margin = new System.Windows.Forms.Padding(4);
            this.addBookTypeBtn.Name = "addBookTypeBtn";
            this.addBookTypeBtn.Size = new System.Drawing.Size(38, 38);
            this.addBookTypeBtn.TabIndex = 31;
            this.addBookTypeBtn.UseVisualStyleBackColor = true;
            this.addBookTypeBtn.Click += new System.EventHandler(this.addBookTypeBtn_Click);
            // 
            // errorBookTypeMsg
            // 
            this.errorBookTypeMsg.AutoSize = true;
            this.errorBookTypeMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.errorBookTypeMsg.ForeColor = System.Drawing.Color.Red;
            this.errorBookTypeMsg.Location = new System.Drawing.Point(163, 52);
            this.errorBookTypeMsg.Name = "errorBookTypeMsg";
            this.errorBookTypeMsg.Size = new System.Drawing.Size(0, 20);
            this.errorBookTypeMsg.TabIndex = 30;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label16.Location = new System.Drawing.Point(3, 3);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(145, 49);
            this.label16.TabIndex = 28;
            this.label16.Text = "Thể loại:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bookTypeCbx
            // 
            this.bookTypeCbx.BackColor = System.Drawing.Color.Transparent;
            this.bookTypeCbx.BaseColor = System.Drawing.Color.White;
            this.bookTypeCbx.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.bookTypeCbx.BorderSize = 1;
            this.bookTypeCbx.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bookTypeCbx.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.bookTypeCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bookTypeCbx.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(159)))), ((int)(((byte)(147)))));
            this.bookTypeCbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookTypeCbx.ForeColor = System.Drawing.Color.Black;
            this.bookTypeCbx.FormattingEnabled = true;
            this.bookTypeCbx.IntegralHeight = false;
            this.bookTypeCbx.ItemHeight = 30;
            this.bookTypeCbx.Location = new System.Drawing.Point(160, 12);
            this.bookTypeCbx.MaxDropDownItems = 10;
            this.bookTypeCbx.Name = "bookTypeCbx";
            this.bookTypeCbx.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.bookTypeCbx.OnHoverItemForeColor = System.Drawing.Color.White;
            this.bookTypeCbx.Radius = 6;
            this.bookTypeCbx.Size = new System.Drawing.Size(369, 36);
            this.bookTypeCbx.TabIndex = 3;
            this.bookTypeCbx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bookNameTxt_KeyDown);
            this.bookTypeCbx.Leave += new System.EventHandler(this.bookTypeCbx_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnAddTacGia);
            this.panel2.Controls.Add(this.errorAuthorMsg);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.authorCbx);
            this.panel2.Location = new System.Drawing.Point(3, 191);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(594, 88);
            this.panel2.TabIndex = 2;
            // 
            // btnAddTacGia
            // 
            this.btnAddTacGia.Enabled = false;
            this.btnAddTacGia.Image = ((System.Drawing.Image)(resources.GetObject("btnAddTacGia.Image")));
            this.btnAddTacGia.Location = new System.Drawing.Point(536, 10);
            this.btnAddTacGia.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddTacGia.Name = "btnAddTacGia";
            this.btnAddTacGia.Size = new System.Drawing.Size(38, 38);
            this.btnAddTacGia.TabIndex = 29;
            this.btnAddTacGia.UseVisualStyleBackColor = true;
            this.btnAddTacGia.Click += new System.EventHandler(this.btnAddTacGia_Click);
            // 
            // errorAuthorMsg
            // 
            this.errorAuthorMsg.AutoSize = true;
            this.errorAuthorMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.errorAuthorMsg.ForeColor = System.Drawing.Color.Red;
            this.errorAuthorMsg.Location = new System.Drawing.Point(163, 52);
            this.errorAuthorMsg.Name = "errorAuthorMsg";
            this.errorAuthorMsg.Size = new System.Drawing.Size(0, 20);
            this.errorAuthorMsg.TabIndex = 27;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label13.Location = new System.Drawing.Point(3, 3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(145, 49);
            this.label13.TabIndex = 9;
            this.label13.Text = "Tác giả:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // authorCbx
            // 
            this.authorCbx.BackColor = System.Drawing.Color.Transparent;
            this.authorCbx.BaseColor = System.Drawing.Color.White;
            this.authorCbx.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.authorCbx.BorderSize = 1;
            this.authorCbx.Cursor = System.Windows.Forms.Cursors.Hand;
            this.authorCbx.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.authorCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.authorCbx.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(159)))), ((int)(((byte)(147)))));
            this.authorCbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.authorCbx.ForeColor = System.Drawing.Color.Black;
            this.authorCbx.FormattingEnabled = true;
            this.authorCbx.IntegralHeight = false;
            this.authorCbx.ItemHeight = 30;
            this.authorCbx.Location = new System.Drawing.Point(160, 12);
            this.authorCbx.MaxDropDownItems = 10;
            this.authorCbx.Name = "authorCbx";
            this.authorCbx.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.authorCbx.OnHoverItemForeColor = System.Drawing.Color.White;
            this.authorCbx.Radius = 6;
            this.authorCbx.Size = new System.Drawing.Size(369, 36);
            this.authorCbx.TabIndex = 2;
            this.authorCbx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bookNameTxt_KeyDown);
            this.authorCbx.Leave += new System.EventHandler(this.authorCbx_SelectedIndexChanged);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.addPublisherBtn);
            this.panel6.Controls.Add(this.errorPublisherMsg);
            this.panel6.Controls.Add(this.label18);
            this.panel6.Controls.Add(this.publisherCbx);
            this.panel6.Location = new System.Drawing.Point(3, 97);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(594, 88);
            this.panel6.TabIndex = 1;
            // 
            // addPublisherBtn
            // 
            this.addPublisherBtn.Enabled = false;
            this.addPublisherBtn.Image = ((System.Drawing.Image)(resources.GetObject("addPublisherBtn.Image")));
            this.addPublisherBtn.Location = new System.Drawing.Point(536, 14);
            this.addPublisherBtn.Margin = new System.Windows.Forms.Padding(4);
            this.addPublisherBtn.Name = "addPublisherBtn";
            this.addPublisherBtn.Size = new System.Drawing.Size(38, 38);
            this.addPublisherBtn.TabIndex = 34;
            this.addPublisherBtn.UseVisualStyleBackColor = true;
            this.addPublisherBtn.Click += new System.EventHandler(this.addPublisherBtn_Click);
            // 
            // errorPublisherMsg
            // 
            this.errorPublisherMsg.AutoSize = true;
            this.errorPublisherMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.errorPublisherMsg.ForeColor = System.Drawing.Color.Red;
            this.errorPublisherMsg.Location = new System.Drawing.Point(163, 52);
            this.errorPublisherMsg.Name = "errorPublisherMsg";
            this.errorPublisherMsg.Size = new System.Drawing.Size(0, 20);
            this.errorPublisherMsg.TabIndex = 33;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label18.Location = new System.Drawing.Point(3, 3);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(145, 49);
            this.label18.TabIndex = 31;
            this.label18.Text = "Nhà xuất bản:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // publisherCbx
            // 
            this.publisherCbx.BackColor = System.Drawing.Color.Transparent;
            this.publisherCbx.BaseColor = System.Drawing.Color.White;
            this.publisherCbx.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.publisherCbx.BorderSize = 1;
            this.publisherCbx.Cursor = System.Windows.Forms.Cursors.Hand;
            this.publisherCbx.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.publisherCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.publisherCbx.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(159)))), ((int)(((byte)(147)))));
            this.publisherCbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.publisherCbx.ForeColor = System.Drawing.Color.Black;
            this.publisherCbx.FormattingEnabled = true;
            this.publisherCbx.IntegralHeight = false;
            this.publisherCbx.ItemHeight = 30;
            this.publisherCbx.Location = new System.Drawing.Point(160, 12);
            this.publisherCbx.MaxDropDownItems = 10;
            this.publisherCbx.Name = "publisherCbx";
            this.publisherCbx.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.publisherCbx.OnHoverItemForeColor = System.Drawing.Color.White;
            this.publisherCbx.Radius = 6;
            this.publisherCbx.Size = new System.Drawing.Size(369, 36);
            this.publisherCbx.TabIndex = 5;
            this.publisherCbx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bookNameTxt_KeyDown);
            this.publisherCbx.Leave += new System.EventHandler(this.publisherCbx_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bookNameTxt);
            this.panel1.Controls.Add(this.errorBookNameMsg);
            this.panel1.Controls.Add(this.nameLine);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(594, 88);
            this.panel1.TabIndex = 0;
            // 
            // bookNameTxt
            // 
            this.bookNameTxt.BackColor = System.Drawing.Color.Transparent;
            this.bookNameTxt.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.bookNameTxt.BorderThickness = 0;
            this.bookNameTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.bookNameTxt.DefaultText = "";
            this.bookNameTxt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.bookNameTxt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.bookNameTxt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.bookNameTxt.DisabledState.Parent = this.bookNameTxt;
            this.bookNameTxt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.bookNameTxt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.bookNameTxt.FocusedState.Parent = this.bookNameTxt;
            this.bookNameTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookNameTxt.ForeColor = System.Drawing.Color.Black;
            this.bookNameTxt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.bookNameTxt.HoverState.Parent = this.bookNameTxt;
            this.bookNameTxt.Location = new System.Drawing.Point(149, 8);
            this.bookNameTxt.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.bookNameTxt.Name = "bookNameTxt";
            this.bookNameTxt.PasswordChar = '\0';
            this.bookNameTxt.PlaceholderText = "Nhập tên sách";
            this.bookNameTxt.SelectedText = "";
            this.bookNameTxt.ShadowDecoration.Parent = this.bookNameTxt;
            this.bookNameTxt.Size = new System.Drawing.Size(425, 36);
            this.bookNameTxt.TabIndex = 1;
            this.bookNameTxt.TextChanged += new System.EventHandler(this.bookNameTxt_TextChanged);
            this.bookNameTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bookNameTxt_KeyDown);
            this.bookNameTxt.Leave += new System.EventHandler(this.bookNameTxt_TextChanged);
            // 
            // errorBookNameMsg
            // 
            this.errorBookNameMsg.AutoSize = true;
            this.errorBookNameMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.errorBookNameMsg.ForeColor = System.Drawing.Color.Red;
            this.errorBookNameMsg.Location = new System.Drawing.Point(163, 50);
            this.errorBookNameMsg.Name = "errorBookNameMsg";
            this.errorBookNameMsg.Size = new System.Drawing.Size(0, 20);
            this.errorBookNameMsg.TabIndex = 7;
            // 
            // nameLine
            // 
            this.nameLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(212)))), ((int)(((byte)(191)))));
            this.nameLine.Location = new System.Drawing.Point(160, 45);
            this.nameLine.Name = "nameLine";
            this.nameLine.Size = new System.Drawing.Size(414, 1);
            this.nameLine.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 49);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tên sách:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.panel6);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this.panel3);
            this.flowLayoutPanel1.Controls.Add(this.panel5);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 48);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(605, 642);
            this.flowLayoutPanel1.TabIndex = 4;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // BookModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(629, 769);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BookModal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm và cập nhật sách";
            this.Load += new System.EventHandler(this.AddBookModal_Load);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaButton cancelBtn;
        private Guna.UI.WinForms.GunaButton submitBtn;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label errorImageMsg;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button addBookTypeBtn;
        private System.Windows.Forms.Label errorBookTypeMsg;
        private System.Windows.Forms.Label label16;
        private Guna.UI.WinForms.GunaComboBox bookTypeCbx;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAddTacGia;
        private System.Windows.Forms.Label errorAuthorMsg;
        private System.Windows.Forms.Label label13;
        private Guna.UI.WinForms.GunaComboBox authorCbx;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button addPublisherBtn;
        private System.Windows.Forms.Label errorPublisherMsg;
        private System.Windows.Forms.Label label18;
        private Guna.UI.WinForms.GunaComboBox publisherCbx;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2TextBox bookNameTxt;
        private System.Windows.Forms.Label errorBookNameMsg;
        private System.Windows.Forms.Panel nameLine;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}