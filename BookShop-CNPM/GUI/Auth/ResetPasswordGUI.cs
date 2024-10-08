﻿using System;
using System.Drawing;
using System.Windows.Forms;
using BookShop_CNPM.BUS;

namespace BookShop_CNPM.GUI
{
    public partial class ResetPasswordGUI : Form
    {
        
        private string email = SendCodeGUI.to;
        private bool isHiddenNewPwd = true;
        private bool isHiddenConfirmPwd = true;

        public ResetPasswordGUI()
        {
            InitializeComponent();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (this.isHiddenNewPwd)
            {
                this.pictureBox5.Image = BookShop_CNPM.Properties.Resources.eye_icon;
                this.isHiddenNewPwd = false;
            }
            else
            {
                this.pictureBox5.Image = BookShop_CNPM.Properties.Resources.hidden_eye_icon_new;
                this.isHiddenNewPwd = true;
            }
            
            this.newPwdTxt.UseSystemPasswordChar = this.isHiddenNewPwd;
            this.pictureBox5.Refresh();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (this.isHiddenConfirmPwd)
            {
                this.pictureBox6.Image = BookShop_CNPM.Properties.Resources.eye_icon;
                this.isHiddenConfirmPwd = false;
            }
            else
            {
                this.pictureBox6.Image = BookShop_CNPM.Properties.Resources.hidden_eye_icon_new;
                this.isHiddenConfirmPwd = true;
            }

            this.confirmPwdTxt.UseSystemPasswordChar = this.isHiddenConfirmPwd;
            this.pictureBox6.Refresh();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.email = "";
            this.Hide();
            LoginGUI.Instance.Show();
        }

        private bool validateForm()
        {
            bool isCheck1 = CustomValidation.Instance.checkTextbox(
                this.newPwdTxt,
                this.errorMsg1,
                this.line1,
                new string[] { "required", "space", "password" }
            );

            bool isCheck2 = CustomValidation.Instance.checkTextbox(
                this.newPwdTxt,
                this.errorMsg2,
                this.line2,
                new string[] { "required" }
            );

            if (isCheck2)
            {
                isCheck2 = CustomValidation.Instance.checkTextboxMatchWithOtherTextBox(
                    this.confirmPwdTxt,
                    this.newPwdTxt,
                    "Trường này phải khớp với trường 'mật khẩu mới'",
                    this.errorMsg2,
                    this.line2
                );
            }


            return isCheck2 && isCheck1;
        }

        private void handleSubmit()
        {
            bool isValid = this.validateForm();

            if (!isValid) return;

            bool isSuccess = AccountBUS.Instance.resetPassword(this.email, this.newPwdTxt.Text);

            if (isSuccess)
            {
                MessageBox.Show("Lấy lại mật khẩu thành công");
            }
            else
            {
                MessageBox.Show("Lấy lại mật khẩu thất bại");
            }

            this.email = "";
            this.Hide();
            LoginGUI.Instance.Show();
        }

        private void customButton1_Click(object sender, EventArgs e)
        {
            this.handleSubmit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.email = "";
            this.Hide();
            SendCodeGUI sendCode = new SendCodeGUI();
            sendCode.Show();
        }

        private void newPwdTxt_TextChanged(object sender, EventArgs e)
        {
            bool isCheck = CustomValidation.Instance.checkTextbox(
                this.newPwdTxt,
                this.errorMsg1,
                this.line1,
                new string[] { "required", "space","password" }
            );

            if (isCheck && this.confirmPwdTxt.Text != string.Empty)
            {
                CustomValidation.Instance.checkTextboxMatchWithOtherTextBox(
                    this.confirmPwdTxt,
                    this.newPwdTxt,
                    "Trường này phải khớp với trường 'mật khẩu mới'",
                    this.errorMsg2,
                    this.line2
                );
            }
        }

        private void comfirmPwdTxt_TextChanged(object sender, EventArgs e)
        {
            bool isCheck = CustomValidation.Instance.checkTextbox(
                this.confirmPwdTxt,
                this.errorMsg2,
                this.line2,
                new string[] { "required" , "space" }
            );

            if (isCheck)
            {
                CustomValidation.Instance.checkTextboxMatchWithOtherTextBox(
                    this.confirmPwdTxt,
                    this.newPwdTxt,
                    "Trường này phải khớp với trường 'mật khẩu mới'",
                    this.errorMsg2,
                    this.line2
                );
            }
        }

        private void newPwdTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                this.handleSubmit();
            }
        }

        private void confirmPwdTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.handleSubmit();
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void newPwdTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true; // Chặn ký tự nhập vào
            }
        }

        private void confirmPwdTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true; // Chặn ký tự nhập vào
            }
        }
    }
}
