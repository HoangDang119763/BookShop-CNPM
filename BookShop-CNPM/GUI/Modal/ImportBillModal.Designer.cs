﻿namespace BookShop_CNPM.GUI.Modal
{
    partial class ImportBillModal
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
            this.submitBtn = new Guna.UI.WinForms.GunaButton();
            this.label1 = new System.Windows.Forms.Label();
            this.gunaButton1 = new Guna.UI.WinForms.GunaButton();
            this.bookList = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.totalPriceTxt = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cancelBtn = new Guna.UI.WinForms.GunaButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.errorCustomerMsg = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.supplierCbx = new Guna.UI.WinForms.GunaComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.benefitTxt = new Guna.UI2.WinForms.Guna2TextBox();
            this.benefitLine = new System.Windows.Forms.Panel();
            this.errorBenefitMsg = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.errorBookListMsg = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
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
            this.submitBtn.FocusedColor = System.Drawing.Color.Empty;
            this.submitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitBtn.ForeColor = System.Drawing.Color.White;
            this.submitBtn.Image = null;
            this.submitBtn.ImageSize = new System.Drawing.Size(20, 20);
            this.submitBtn.Location = new System.Drawing.Point(559, 641);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.OnHoverBaseColor = System.Drawing.Color.White;
            this.submitBtn.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.submitBtn.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.submitBtn.OnHoverImage = null;
            this.submitBtn.OnPressedColor = System.Drawing.Color.Black;
            this.submitBtn.Radius = 22;
            this.submitBtn.Size = new System.Drawing.Size(200, 50);
            this.submitBtn.TabIndex = 2;
            this.submitBtn.TabStop = false;
            this.submitBtn.Text = "Lưu";
            this.submitBtn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1057, 61);
            this.label1.TabIndex = 9;
            this.label1.Text = "Tạo Đơn Nhập Hàng";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gunaButton1
            // 
            this.gunaButton1.Animated = true;
            this.gunaButton1.AnimationHoverSpeed = 0.05F;
            this.gunaButton1.AnimationSpeed = 0.05F;
            this.gunaButton1.BackColor = System.Drawing.Color.Transparent;
            this.gunaButton1.BaseColor = System.Drawing.Color.White;
            this.gunaButton1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.gunaButton1.BorderSize = 1;
            this.gunaButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gunaButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaButton1.FocusedColor = System.Drawing.Color.Empty;
            this.gunaButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.gunaButton1.Image = null;
            this.gunaButton1.ImageSize = new System.Drawing.Size(20, 20);
            this.gunaButton1.Location = new System.Drawing.Point(776, 15);
            this.gunaButton1.Name = "gunaButton1";
            this.gunaButton1.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.gunaButton1.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.gunaButton1.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaButton1.OnHoverImage = null;
            this.gunaButton1.OnPressedColor = System.Drawing.Color.White;
            this.gunaButton1.OnPressedDepth = 0;
            this.gunaButton1.Radius = 12;
            this.gunaButton1.Size = new System.Drawing.Size(214, 50);
            this.gunaButton1.TabIndex = 0;
            this.gunaButton1.TabStop = false;
            this.gunaButton1.Text = "Thêm sách vào danh sách";
            this.gunaButton1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.gunaButton1.Click += new System.EventHandler(this.gunaButton1_Click);
            // 
            // bookList
            // 
            this.bookList.AutoScroll = true;
            this.bookList.Location = new System.Drawing.Point(3, 85);
            this.bookList.Name = "bookList";
            this.bookList.Size = new System.Drawing.Size(1021, 248);
            this.bookList.TabIndex = 29;
            this.bookList.Paint += new System.Windows.Forms.PaintEventHandler(this.bookList_Paint);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(3, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(389, 49);
            this.label2.TabIndex = 28;
            this.label2.Text = "Danh sách các sản phẩm";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.totalPriceTxt);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(3, 486);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1027, 73);
            this.panel1.TabIndex = 0;
            // 
            // totalPriceTxt
            // 
            this.totalPriceTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.totalPriceTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.totalPriceTxt.Location = new System.Drawing.Point(697, 0);
            this.totalPriceTxt.Name = "totalPriceTxt";
            this.totalPriceTxt.Size = new System.Drawing.Size(323, 49);
            this.totalPriceTxt.TabIndex = 33;
            this.totalPriceTxt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(571, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 49);
            this.label3.TabIndex = 28;
            this.label3.Text = "Tổng tiền:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.cancelBtn.FocusedColor = System.Drawing.Color.Empty;
            this.cancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.cancelBtn.Image = null;
            this.cancelBtn.ImageSize = new System.Drawing.Size(20, 20);
            this.cancelBtn.Location = new System.Drawing.Point(260, 641);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.cancelBtn.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.cancelBtn.OnHoverForeColor = System.Drawing.Color.White;
            this.cancelBtn.OnHoverImage = null;
            this.cancelBtn.OnPressedColor = System.Drawing.Color.White;
            this.cancelBtn.Radius = 22;
            this.cancelBtn.Size = new System.Drawing.Size(200, 50);
            this.cancelBtn.TabIndex = 1;
            this.cancelBtn.TabStop = false;
            this.cancelBtn.Text = "Hủy";
            this.cancelBtn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.flowLayoutPanel1.Controls.Add(this.panel3);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this.panel4);
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(11, 64);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1034, 571);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.errorCustomerMsg);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.supplierCbx);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(594, 88);
            this.panel3.TabIndex = 28;
            // 
            // errorCustomerMsg
            // 
            this.errorCustomerMsg.AutoSize = true;
            this.errorCustomerMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.errorCustomerMsg.ForeColor = System.Drawing.Color.Red;
            this.errorCustomerMsg.Location = new System.Drawing.Point(162, 55);
            this.errorCustomerMsg.Name = "errorCustomerMsg";
            this.errorCustomerMsg.Size = new System.Drawing.Size(0, 20);
            this.errorCustomerMsg.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(3, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 49);
            this.label5.TabIndex = 9;
            this.label5.Text = "Nhà cung cấp:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // supplierCbx
            // 
            this.supplierCbx.BackColor = System.Drawing.Color.Transparent;
            this.supplierCbx.BaseColor = System.Drawing.Color.White;
            this.supplierCbx.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.supplierCbx.BorderSize = 1;
            this.supplierCbx.Cursor = System.Windows.Forms.Cursors.Hand;
            this.supplierCbx.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.supplierCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.supplierCbx.FocusedColor = System.Drawing.Color.Empty;
            this.supplierCbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplierCbx.ForeColor = System.Drawing.Color.Black;
            this.supplierCbx.FormattingEnabled = true;
            this.supplierCbx.IntegralHeight = false;
            this.supplierCbx.ItemHeight = 30;
            this.supplierCbx.Location = new System.Drawing.Point(160, 12);
            this.supplierCbx.MaxDropDownItems = 10;
            this.supplierCbx.Name = "supplierCbx";
            this.supplierCbx.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.supplierCbx.OnHoverItemForeColor = System.Drawing.Color.White;
            this.supplierCbx.Radius = 6;
            this.supplierCbx.Size = new System.Drawing.Size(408, 36);
            this.supplierCbx.TabIndex = 26;
            this.supplierCbx.TabStop = false;
            this.supplierCbx.SelectedIndexChanged += new System.EventHandler(this.supplierCbx_SelectedIndexChanged_1);
            this.supplierCbx.Leave += new System.EventHandler(this.supplierCbx_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.benefitTxt);
            this.panel2.Controls.Add(this.benefitLine);
            this.panel2.Controls.Add(this.errorBenefitMsg);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Location = new System.Drawing.Point(603, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(427, 88);
            this.panel2.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(397, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 29);
            this.label6.TabIndex = 31;
            this.label6.Text = "%";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // benefitTxt
            // 
            this.benefitTxt.BackColor = System.Drawing.Color.Transparent;
            this.benefitTxt.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.benefitTxt.BorderThickness = 0;
            this.benefitTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.benefitTxt.DefaultText = "";
            this.benefitTxt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.benefitTxt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.benefitTxt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.benefitTxt.DisabledState.Parent = this.benefitTxt;
            this.benefitTxt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.benefitTxt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.benefitTxt.FocusedState.Parent = this.benefitTxt;
            this.benefitTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.benefitTxt.ForeColor = System.Drawing.Color.Black;
            this.benefitTxt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.benefitTxt.HoverState.Parent = this.benefitTxt;
            this.benefitTxt.Location = new System.Drawing.Point(154, 13);
            this.benefitTxt.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.benefitTxt.Name = "benefitTxt";
            this.benefitTxt.PasswordChar = '\0';
            this.benefitTxt.PlaceholderText = "Nhập tỉ lệ lợi nhuận";
            this.benefitTxt.SelectedText = "";
            this.benefitTxt.ShadowDecoration.Parent = this.benefitTxt;
            this.benefitTxt.Size = new System.Drawing.Size(236, 29);
            this.benefitTxt.TabIndex = 28;
            this.benefitTxt.TextChanged += new System.EventHandler(this.benefitTxt_TextChanged);
            this.benefitTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.benefitTxt_KeyPress);
            this.benefitTxt.Leave += new System.EventHandler(this.benefitTxt_TextChanged);
            // 
            // benefitLine
            // 
            this.benefitLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(212)))), ((int)(((byte)(191)))));
            this.benefitLine.Location = new System.Drawing.Point(162, 44);
            this.benefitLine.Name = "benefitLine";
            this.benefitLine.Size = new System.Drawing.Size(254, 1);
            this.benefitLine.TabIndex = 30;
            // 
            // errorBenefitMsg
            // 
            this.errorBenefitMsg.AutoSize = true;
            this.errorBenefitMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.errorBenefitMsg.ForeColor = System.Drawing.Color.Red;
            this.errorBenefitMsg.Location = new System.Drawing.Point(124, 57);
            this.errorBenefitMsg.Name = "errorBenefitMsg";
            this.errorBenefitMsg.Size = new System.Drawing.Size(0, 20);
            this.errorBenefitMsg.TabIndex = 27;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(3, 3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(150, 49);
            this.label13.TabIndex = 9;
            this.label13.Text = "Tỉ lệ lợi nhuận:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.errorBookListMsg);
            this.panel4.Controls.Add(this.gunaButton1);
            this.panel4.Controls.Add(this.bookList);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(3, 97);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1027, 383);
            this.panel4.TabIndex = 2;
            // 
            // errorBookListMsg
            // 
            this.errorBookListMsg.AutoSize = true;
            this.errorBookListMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.errorBookListMsg.ForeColor = System.Drawing.Color.Red;
            this.errorBookListMsg.Location = new System.Drawing.Point(314, 344);
            this.errorBookListMsg.Name = "errorBookListMsg";
            this.errorBookListMsg.Size = new System.Drawing.Size(0, 20);
            this.errorBookListMsg.TabIndex = 36;
            // 
            // ImportBillModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1057, 709);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ImportBillModal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tạo đơn nhập hàng";
            this.Load += new System.EventHandler(this.ImportBillModal_Load);
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaButton submitBtn;
        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaButton gunaButton1;
        private System.Windows.Forms.FlowLayoutPanel bookList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI.WinForms.GunaButton cancelBtn;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label errorBookListMsg;
        private System.Windows.Forms.Label totalPriceTxt;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label errorCustomerMsg;
        private System.Windows.Forms.Label label5;
        private Guna.UI.WinForms.GunaComboBox supplierCbx;
        private Guna.UI2.WinForms.Guna2TextBox benefitTxt;
        private System.Windows.Forms.Panel benefitLine;
        private System.Windows.Forms.Label errorBenefitMsg;
        private System.Windows.Forms.Label label6;
    }
}