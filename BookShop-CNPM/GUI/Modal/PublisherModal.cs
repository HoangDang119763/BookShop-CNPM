﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Markup;
using Guna.UI2.WinForms.Suite;
using BookShop_CNPM.BUS;
using BookShop_CNPM.DTO;
using static Guna.UI2.Native.WinApi;
using LiveCharts;

namespace BookShop_CNPM.GUI.Modal
{
    public partial class PublisherModal : Form
    {
        public PublisherDTO updatePublisher = null;
        public bool isSubmitSuccess = false;
        public bool isGenderCbx = false;
        public PublisherModal(string title = "Thêm nhà xuất bản")
        {
            InitializeComponent();
            this.label1.Text = title;
            this.Text = title;
        }

        private void bookNameTxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bool isPublisher = CustomValidation.Instance.checkTextbox(
                    this.Publishertxt,
                    this.PublisherNameMsg,
                    this.nameLine,
                    new string[] { "required" , "name" , "space" }
                );

                if (isPublisher)
                {
                    if (updatePublisher == null)
                    {
                        isPublisher = CustomValidation.Instance.checkDuplicateName(
                            this.PublisherNameMsg,
                            this.nameLine,
                            PublisherBUS.Instance.checkDuplicateName(this.Publishertxt.Text)
                        );
                    }
                    else
                    {
                        isPublisher = CustomValidation.Instance.checkDuplicateName(
                            this.PublisherNameMsg,
                            this.nameLine,
                            PublisherBUS.Instance.checkDuplicateName(this.Publishertxt.Text, updatePublisher.MaNhaXuatBan)
                        );
                    }
                }
            }
            catch (Exception er)
            {

                Console.WriteLine(er);
            }
        }

        private bool validateForm()
        {
            try
            {
                bool isPublisher = CustomValidation.Instance.checkTextbox(
                    this.Publishertxt,
                    this.PublisherNameMsg,
                    this.nameLine,
                    new string[] { "required" , "name" , "space" }
                );

                if (isPublisher)
                {
                    if (updatePublisher == null)
                    {
                        isPublisher = CustomValidation.Instance.checkDuplicateName(
                            this.PublisherNameMsg,
                            this.nameLine,
                            PublisherBUS.Instance.checkDuplicateName(this.Publishertxt.Text)
                        );
                    }
                    else
                    {
                        isPublisher = CustomValidation.Instance.checkDuplicateName(
                            this.PublisherNameMsg,
                            this.nameLine,
                            PublisherBUS.Instance.checkDuplicateName(this.Publishertxt.Text, updatePublisher.MaNhaXuatBan)
                        );
                    }
                }

                bool isCheckTxt2 = CustomValidation.Instance.checkTextbox(
                        this.phoneNumbertxt,
                        this.phoneNumberMsg,
                        this.phoneNumberLine,
                        new string[] { "required", "phone-number", "space" }
                );
				if (isCheckTxt2)
				{
					if (updatePublisher == null)
					{
						isCheckTxt2 = CustomValidation.Instance.checkDuplicateName(
								this.phoneNumberMsg,
								this.phoneNumberLine,
								PublisherBUS.Instance.checkDuplicatePhoneNumber(this.phoneNumbertxt.Text),
								"Số điện thoại đã có trong hệ thống"
							);
					}
					else
					{
						isCheckTxt2 = CustomValidation.Instance.checkDuplicateName(
							   this.phoneNumberMsg,
							   this.phoneNumberLine,
							   PublisherBUS.Instance.checkDuplicatePhoneNumber(this.phoneNumbertxt.Text, updatePublisher.MaNhaXuatBan),
							   "Số điện thoại đã có trong hệ thống"
						   );
					}
				}
				bool isCheckTxt3 = CustomValidation.Instance.checkTextbox(
                        this.addressTxt,
                        this.addressMsg,
                        this.addressLine,
                        new string[] { "required", "space" }
                    );



                return isPublisher && isCheckTxt2 && isCheckTxt3;
            }
            catch (Exception)
            {

                return false;
            }
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            try
            {
                bool isValid = this.validateForm();

                if (!isValid) return;

                string PublisherName = this.Publishertxt.Text;
                string phoneNumbertxt = this.phoneNumbertxt.Text;
                string addressTxt = this.addressTxt.Text;

                int id = updatePublisher != null ? updatePublisher.MaNhaXuatBan : 0;

                PublisherDTO book = new PublisherDTO(id, PublisherName, addressTxt, phoneNumbertxt);

                bool isSuccess = updatePublisher != null ? PublisherBUS.Instance.update(book) : PublisherBUS.Instance.insert(book);


                if (isSuccess)
                {
                    this.isSubmitSuccess = isSuccess;
                    MessageBox.Show(updatePublisher != null ? "Sửa thành công" : "Thêm thành công");
                    this.Close();
                    return;
                }

                this.isSubmitSuccess = isSuccess;

                MessageBox.Show(updatePublisher != null ? "Sửa thất bại" : "Thêm thất bại");
            }
            catch (Exception er)
            {

                Console.WriteLine(er);
            }
        }

        private void birthYear_TextChanged(object sender, EventArgs e)
        {
            try
            {
               bool isPhoneNumberValid = CustomValidation.Instance.checkTextbox(
                    this.phoneNumbertxt,
                    this.phoneNumberMsg,
                    this.phoneNumberLine,
                    new string[] { "required", "phone-number", "space" }
                );
                if ( isPhoneNumberValid ) 
                {
                    if(updatePublisher == null)
                    {
                        isPhoneNumberValid = CustomValidation.Instance.checkDuplicateName(
                                this.phoneNumberMsg,
                                this.phoneNumberLine,
                                PublisherBUS.Instance.checkDuplicatePhoneNumber(this.phoneNumbertxt.Text),
                                "Số điện thoại đã có trong hệ thống"
                            );
                    }
                    else
                    {
						isPhoneNumberValid = CustomValidation.Instance.checkDuplicateName(
							   this.phoneNumberMsg,
							   this.phoneNumberLine,
							   PublisherBUS.Instance.checkDuplicatePhoneNumber(this.phoneNumbertxt.Text,updatePublisher.MaNhaXuatBan),
							   "Số điện thoại đã có trong hệ thống"
						   );
					} 
                }
            }
            catch (Exception er)
            {

                Console.WriteLine(er);
            }
        }

        private void PublisherModal_Load(object sender, EventArgs e)
        {
            try
            {
                this.Location = new Point(
                       (Screen.PrimaryScreen.Bounds.Size.Width / 2) - (this.Size.Width / 2),
                       (Screen.PrimaryScreen.Bounds.Size.Height / 2) - (this.Size.Height / 2)
                   );
                if (updatePublisher != null)
                {

                    this.Publishertxt.Text = updatePublisher.TenNhaXuatBan;
                    this.addressTxt.Text = updatePublisher.DiaChi;
                    this.phoneNumbertxt.Text = updatePublisher.SoDienThoai;

                }
            }
            catch (Exception er)
            {

                Console.WriteLine(er);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addressTxt_TextChanged(object sender, EventArgs e)
        {

            CustomValidation.Instance.checkTextbox(
                this.addressTxt,
                this.addressMsg,
                this.addressLine,
                new string[] { "required", "space" }
            );
        }

        private void PublisherModal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gunaButton1_Click(sender, e);
            }
        }
    }
}
