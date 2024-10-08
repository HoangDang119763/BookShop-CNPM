﻿namespace BookShop_CNPM.GUI.UserControls
{
    partial class FilterUserControl
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
            this.PriceUpCkb = new Guna.UI2.WinForms.Guna2CheckBox();
            this.PriceDownCkb = new Guna.UI2.WinForms.Guna2CheckBox();
            this.NameAZCkb = new Guna.UI2.WinForms.Guna2CheckBox();
            this.NameZACkb = new Guna.UI2.WinForms.Guna2CheckBox();
            this.ApplyBtn = new Guna.UI2.WinForms.Guna2Button();
            this.TypeCb = new Guna.UI.WinForms.GunaComboBox();
            this.AuthorCb = new Guna.UI.WinForms.GunaComboBox();
            this.PublisherCb = new Guna.UI.WinForms.GunaComboBox();
            this.Typelb = new System.Windows.Forms.Label();
            this.AuthorLb = new System.Windows.Forms.Label();
            this.PublisherLb = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PriceUpCkb
            // 
            this.PriceUpCkb.Animated = true;
            this.PriceUpCkb.AutoSize = true;
            this.PriceUpCkb.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.PriceUpCkb.CheckedState.BorderRadius = 2;
            this.PriceUpCkb.CheckedState.BorderThickness = 0;
            this.PriceUpCkb.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.PriceUpCkb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.PriceUpCkb.Location = new System.Drawing.Point(27, 25);
            this.PriceUpCkb.Margin = new System.Windows.Forms.Padding(4);
            this.PriceUpCkb.Name = "PriceUpCkb";
            this.PriceUpCkb.Size = new System.Drawing.Size(126, 24);
            this.PriceUpCkb.TabIndex = 0;
            this.PriceUpCkb.Text = "Giá tăng dần";
            this.PriceUpCkb.UncheckedState.BorderColor = System.Drawing.Color.DimGray;
            this.PriceUpCkb.UncheckedState.BorderRadius = 2;
            this.PriceUpCkb.UncheckedState.BorderThickness = 1;
            this.PriceUpCkb.UncheckedState.FillColor = System.Drawing.Color.WhiteSmoke;
            this.PriceUpCkb.UseVisualStyleBackColor = true;
            this.PriceUpCkb.CheckedChanged += new System.EventHandler(this.PriceUpCkb_CheckedChanged);
            // 
            // PriceDownCkb
            // 
            this.PriceDownCkb.Animated = true;
            this.PriceDownCkb.AutoSize = true;
            this.PriceDownCkb.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.PriceDownCkb.CheckedState.BorderRadius = 2;
            this.PriceDownCkb.CheckedState.BorderThickness = 0;
            this.PriceDownCkb.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.PriceDownCkb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.PriceDownCkb.Location = new System.Drawing.Point(27, 74);
            this.PriceDownCkb.Margin = new System.Windows.Forms.Padding(4);
            this.PriceDownCkb.Name = "PriceDownCkb";
            this.PriceDownCkb.Size = new System.Drawing.Size(130, 24);
            this.PriceDownCkb.TabIndex = 1;
            this.PriceDownCkb.Text = "Giá giảm dần";
            this.PriceDownCkb.UncheckedState.BorderColor = System.Drawing.Color.DimGray;
            this.PriceDownCkb.UncheckedState.BorderRadius = 2;
            this.PriceDownCkb.UncheckedState.BorderThickness = 1;
            this.PriceDownCkb.UncheckedState.FillColor = System.Drawing.Color.WhiteSmoke;
            this.PriceDownCkb.UseVisualStyleBackColor = true;
            this.PriceDownCkb.CheckedChanged += new System.EventHandler(this.PriceDownCkb_CheckedChanged);
            // 
            // NameAZCkb
            // 
            this.NameAZCkb.Animated = true;
            this.NameAZCkb.AutoSize = true;
            this.NameAZCkb.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.NameAZCkb.CheckedState.BorderRadius = 2;
            this.NameAZCkb.CheckedState.BorderThickness = 0;
            this.NameAZCkb.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.NameAZCkb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.NameAZCkb.Location = new System.Drawing.Point(27, 123);
            this.NameAZCkb.Margin = new System.Windows.Forms.Padding(4);
            this.NameAZCkb.Name = "NameAZCkb";
            this.NameAZCkb.Size = new System.Drawing.Size(109, 24);
            this.NameAZCkb.TabIndex = 2;
            this.NameAZCkb.Text = "Tên từ A-Z";
            this.NameAZCkb.UncheckedState.BorderColor = System.Drawing.Color.DimGray;
            this.NameAZCkb.UncheckedState.BorderRadius = 2;
            this.NameAZCkb.UncheckedState.BorderThickness = 1;
            this.NameAZCkb.UncheckedState.FillColor = System.Drawing.Color.WhiteSmoke;
            this.NameAZCkb.UseVisualStyleBackColor = true;
            this.NameAZCkb.CheckedChanged += new System.EventHandler(this.NameAZCkb_CheckedChanged);
            // 
            // NameZACkb
            // 
            this.NameZACkb.Animated = true;
            this.NameZACkb.AutoSize = true;
            this.NameZACkb.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.NameZACkb.CheckedState.BorderRadius = 2;
            this.NameZACkb.CheckedState.BorderThickness = 0;
            this.NameZACkb.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.NameZACkb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.NameZACkb.Location = new System.Drawing.Point(27, 171);
            this.NameZACkb.Margin = new System.Windows.Forms.Padding(4);
            this.NameZACkb.Name = "NameZACkb";
            this.NameZACkb.Size = new System.Drawing.Size(109, 24);
            this.NameZACkb.TabIndex = 3;
            this.NameZACkb.Text = "Tên từ Z-A";
            this.NameZACkb.UncheckedState.BorderColor = System.Drawing.Color.DimGray;
            this.NameZACkb.UncheckedState.BorderRadius = 2;
            this.NameZACkb.UncheckedState.BorderThickness = 1;
            this.NameZACkb.UncheckedState.FillColor = System.Drawing.Color.WhiteSmoke;
            this.NameZACkb.UseVisualStyleBackColor = true;
            this.NameZACkb.CheckedChanged += new System.EventHandler(this.NameZACkb_CheckedChanged);
            // 
            // ApplyBtn
            // 
            this.ApplyBtn.BorderColor = System.Drawing.Color.Transparent;
            this.ApplyBtn.BorderRadius = 15;
            this.ApplyBtn.CheckedState.Parent = this.ApplyBtn;
            this.ApplyBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ApplyBtn.CustomImages.Parent = this.ApplyBtn;
            this.ApplyBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.ApplyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.ApplyBtn.ForeColor = System.Drawing.Color.White;
            this.ApplyBtn.HoverState.Parent = this.ApplyBtn;
            this.ApplyBtn.Location = new System.Drawing.Point(27, 218);
            this.ApplyBtn.Margin = new System.Windows.Forms.Padding(4);
            this.ApplyBtn.Name = "ApplyBtn";
            this.ApplyBtn.ShadowDecoration.Parent = this.ApplyBtn;
            this.ApplyBtn.Size = new System.Drawing.Size(391, 38);
            this.ApplyBtn.TabIndex = 7;
            this.ApplyBtn.Text = "Áp dụng";
            this.ApplyBtn.Click += new System.EventHandler(this.ApplyBtn_Click);
            // 
            // TypeCb
            // 
            this.TypeCb.BackColor = System.Drawing.Color.Transparent;
            this.TypeCb.BaseColor = System.Drawing.Color.White;
            this.TypeCb.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.TypeCb.BorderSize = 1;
            this.TypeCb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.TypeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeCb.FocusedColor = System.Drawing.Color.Empty;
            this.TypeCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.TypeCb.ForeColor = System.Drawing.Color.Black;
            this.TypeCb.FormattingEnabled = true;
            this.TypeCb.Items.AddRange(new object[] {
            "Tất cả"});
            this.TypeCb.Location = new System.Drawing.Point(212, 38);
            this.TypeCb.Margin = new System.Windows.Forms.Padding(4);
            this.TypeCb.Name = "TypeCb";
            this.TypeCb.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.TypeCb.OnHoverItemForeColor = System.Drawing.Color.White;
            this.TypeCb.Radius = 4;
            this.TypeCb.Size = new System.Drawing.Size(204, 27);
            this.TypeCb.TabIndex = 4;
            this.TypeCb.TabStop = false;
            this.TypeCb.Tag = "";
            this.TypeCb.SelectedIndexChanged += new System.EventHandler(this.TypeCb_SelectedIndexChanged);
            // 
            // AuthorCb
            // 
            this.AuthorCb.BackColor = System.Drawing.Color.Transparent;
            this.AuthorCb.BaseColor = System.Drawing.Color.White;
            this.AuthorCb.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.AuthorCb.BorderSize = 1;
            this.AuthorCb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.AuthorCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AuthorCb.FocusedColor = System.Drawing.Color.Empty;
            this.AuthorCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.AuthorCb.ForeColor = System.Drawing.Color.Black;
            this.AuthorCb.FormattingEnabled = true;
            this.AuthorCb.Items.AddRange(new object[] {
            "Tất cả"});
            this.AuthorCb.Location = new System.Drawing.Point(212, 103);
            this.AuthorCb.Margin = new System.Windows.Forms.Padding(4);
            this.AuthorCb.Name = "AuthorCb";
            this.AuthorCb.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.AuthorCb.OnHoverItemForeColor = System.Drawing.Color.White;
            this.AuthorCb.Radius = 4;
            this.AuthorCb.Size = new System.Drawing.Size(204, 27);
            this.AuthorCb.TabIndex = 5;
            this.AuthorCb.TabStop = false;
            this.AuthorCb.Tag = "";
            this.AuthorCb.SelectedIndexChanged += new System.EventHandler(this.AuthorCb_SelectedIndexChanged);
            // 
            // PublisherCb
            // 
            this.PublisherCb.BackColor = System.Drawing.Color.Transparent;
            this.PublisherCb.BaseColor = System.Drawing.Color.White;
            this.PublisherCb.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.PublisherCb.BorderSize = 1;
            this.PublisherCb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.PublisherCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PublisherCb.FocusedColor = System.Drawing.Color.Empty;
            this.PublisherCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.PublisherCb.ForeColor = System.Drawing.Color.Black;
            this.PublisherCb.FormattingEnabled = true;
            this.PublisherCb.Items.AddRange(new object[] {
            "Tất cả"});
            this.PublisherCb.Location = new System.Drawing.Point(212, 169);
            this.PublisherCb.Margin = new System.Windows.Forms.Padding(4);
            this.PublisherCb.Name = "PublisherCb";
            this.PublisherCb.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(210)))), ((int)(((byte)(192)))));
            this.PublisherCb.OnHoverItemForeColor = System.Drawing.Color.White;
            this.PublisherCb.Radius = 4;
            this.PublisherCb.Size = new System.Drawing.Size(204, 27);
            this.PublisherCb.TabIndex = 6;
            this.PublisherCb.TabStop = false;
            this.PublisherCb.Tag = "";
            this.PublisherCb.SelectedIndexChanged += new System.EventHandler(this.PublisherCb_SelectedIndexChanged);
            // 
            // Typelb
            // 
            this.Typelb.AutoSize = true;
            this.Typelb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Typelb.Location = new System.Drawing.Point(231, 16);
            this.Typelb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Typelb.Name = "Typelb";
            this.Typelb.Size = new System.Drawing.Size(60, 18);
            this.Typelb.TabIndex = 9;
            this.Typelb.Text = "Thể loại";
            // 
            // AuthorLb
            // 
            this.AuthorLb.AutoSize = true;
            this.AuthorLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.AuthorLb.Location = new System.Drawing.Point(231, 81);
            this.AuthorLb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AuthorLb.Name = "AuthorLb";
            this.AuthorLb.Size = new System.Drawing.Size(56, 18);
            this.AuthorLb.TabIndex = 10;
            this.AuthorLb.Text = "Tác giả";
            // 
            // PublisherLb
            // 
            this.PublisherLb.AutoSize = true;
            this.PublisherLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.PublisherLb.Location = new System.Drawing.Point(231, 146);
            this.PublisherLb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PublisherLb.Name = "PublisherLb";
            this.PublisherLb.Size = new System.Drawing.Size(94, 18);
            this.PublisherLb.TabIndex = 11;
            this.PublisherLb.Text = "Nhà xuất bản";
            // 
            // FilterUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(245)))));
            this.Controls.Add(this.PublisherLb);
            this.Controls.Add(this.AuthorLb);
            this.Controls.Add(this.Typelb);
            this.Controls.Add(this.PublisherCb);
            this.Controls.Add(this.AuthorCb);
            this.Controls.Add(this.TypeCb);
            this.Controls.Add(this.ApplyBtn);
            this.Controls.Add(this.NameZACkb);
            this.Controls.Add(this.NameAZCkb);
            this.Controls.Add(this.PriceDownCkb);
            this.Controls.Add(this.PriceUpCkb);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "FilterUserControl";
            this.Size = new System.Drawing.Size(445, 272);
            this.Load += new System.EventHandler(this.FilterUserControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CheckBox PriceUpCkb;
        private Guna.UI2.WinForms.Guna2CheckBox PriceDownCkb;
        private Guna.UI2.WinForms.Guna2CheckBox NameAZCkb;
        private Guna.UI2.WinForms.Guna2CheckBox NameZACkb;
        private Guna.UI2.WinForms.Guna2Button ApplyBtn;
        private System.Windows.Forms.Label Typelb;
        private System.Windows.Forms.Label AuthorLb;
        private System.Windows.Forms.Label PublisherLb;
        public Guna.UI.WinForms.GunaComboBox TypeCb;
        public Guna.UI.WinForms.GunaComboBox AuthorCb;
        public Guna.UI.WinForms.GunaComboBox PublisherCb;
    }
}
