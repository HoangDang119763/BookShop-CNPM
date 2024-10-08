﻿using BookShop_CNPM.BUS;
using BookShop_CNPM.DTO;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BookShop_CNPM.GUI.Modal
{
    public partial class CustomerModal : Form
    {
        public CustomerDTO currentCustomer = null;
        public bool isSubmitSuccess = false;
        public CustomerModal(string title = "Thêm khách hàng")
        {
            InitializeComponent();
            this.title.Text = title;    
            this.Text = title;
        }
   

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
				if (this.validateForm())
				{
					string customerName = this.customerNameTxtBox.Text;
					int birthYear = Convert.ToInt32(this.birthYearTxtBox.Text);
					string phoneNumber = this.phoneNumberTxtBox.Text;
					string gender = this.genderCbx.SelectedItem.ToString();
					int id = this.currentCustomer != null ? currentCustomer.Ma : 0;
					int score = this.currentCustomer != null ? currentCustomer.Diem : 0;
					CustomerDTO customer = new CustomerDTO(ma: id, ten: customerName, soDienThoai: phoneNumber, gioiTinh: gender, namSinh: birthYear, diem: score);
					bool isSuccess = currentCustomer != null ? CustomerBUS.Instance.update(customer) : CustomerBUS.Instance.insert(customer);
					if (isSuccess)
					{
						this.isSubmitSuccess = isSuccess;
						MessageBox.Show(id != 0 ? "Cập nhật thành công" : "Thêm dữ liệu thành công");
						this.Close();
						return;
					}

				}
			}
            catch
            {

            }
        }
        private void CustomerModal_Load(object sender, EventArgs e)
        {
            this.Location = new Point(
                (Screen.PrimaryScreen.Bounds.Size.Width / 2) - (this.Size.Width / 2),
                (Screen.PrimaryScreen.Bounds.Size.Height / 2) - (this.Size.Height / 2)
            );

            string[] genders = { "Chọn giới tính", "Nam", "Nữ" };
            this.genderCbx.Items.AddRange(genders);
            this.genderCbx.SelectedItem = genders[0];
            genderCbx.SelectedIndexChanged += genderCbx_SelectedIndexChanged;

			try
            {
				if (currentCustomer != null)
				{
					this.customerNameTxtBox.Text = currentCustomer.Ten;
					this.phoneNumberTxtBox.Text = currentCustomer.SoDienThoai;
					this.birthYearTxtBox.Text = currentCustomer.NamSinh.ToString();
					this.genderCbx.Text = currentCustomer.GioiTinh == "Nam" ? genders[1] : genders[2];
				}

                this.genderCbx.SelectedIndexChanged += genderCbx_SelectedIndexChanged;
            }
            catch
            {

            }
            
        }
        private bool validateForm()
        {
            try
            {
				bool isCustomerNameValid = CustomValidation.Instance.checkTextbox(
					this.customerNameTxtBox,
					this.errorCustomerNameMsg,
					this.customerNameLine,
					new string[] {"required", "name", "space" }
				);

				bool isBirthYearValid = CustomValidation.Instance.checkTextbox(
					this.birthYearTxtBox,
					this.errorBirthYearMsg,
					this.birthYearLine,
					new string[] { "required", "positive-number", "max-current-year", "space" , "age-restrict-customer" }
                );

                bool isPhone = CustomValidation.Instance.checkTextbox(
                    this.phoneNumberTxtBox,
                    this.errorPhoneNumberMsg,
                    this.phoneNumberLine,
                    new string[] { "required", "phone-number", "space" }
                );

                if (isPhone)
                {
                    if (currentCustomer == null)
                    {
                        isPhone = CustomValidation.Instance.checkDuplicateName(
                            this.errorPhoneNumberMsg,
                            this.phoneNumberLine,
                            CustomerBUS.Instance.checkDuplicateName(this.phoneNumberTxtBox.Text),
                            "Số điện thoại đã có trong hệ thống"
                        );
                    }
                    else
                    {
                        isPhone = CustomValidation.Instance.checkDuplicateName(
                            this.errorPhoneNumberMsg,
                            this.phoneNumberLine,
                            CustomerBUS.Instance.checkDuplicateName(this.phoneNumberTxtBox.Text, currentCustomer.Ma),
                            "Số điện thoại đã có trong hệ thống"
                        );
                    }
                }

                bool isGenderValid = CustomValidation.Instance.checkCombobox(
					this.genderCbx,
					this.errorGenderMsg,
					new string[] { "required" }
				);

				return isBirthYearValid && isCustomerNameValid && isGenderValid && isPhone;
			}
            catch
            {
				return false;
            }
            
        }

        private void customerNameTxtBox_TextChanged(object sender, EventArgs e)
        {
            CustomValidation.Instance.checkTextbox(
                    this.customerNameTxtBox,
                    this.errorCustomerNameMsg,
                    this.customerNameLine,
                    new string[] {"required", "name", "space" }
                );
        }

        private void birthYearTxtBox_TextChanged(object sender, EventArgs e)
        {
            CustomValidation.Instance.checkTextbox(
                    this.birthYearTxtBox,
                    this.errorBirthYearMsg,
                    this.birthYearLine,
                    new string[] { "required", "positive-number", "space" , "max-current-year", "age-restrict-customer" }
                );
        }

        private void phoneNumberTxtBox_TextChanged(object sender, EventArgs e)
        {
            bool isPhone = CustomValidation.Instance.checkTextbox(
                this.phoneNumberTxtBox,
                this.errorPhoneNumberMsg,
                this.phoneNumberLine,
                new string[] { "required", "phone-number", "space" }
            );

            if (isPhone)
            {
                if (currentCustomer == null)
                {
                    isPhone = CustomValidation.Instance.checkDuplicateName(
                        this.errorPhoneNumberMsg,
                        this.phoneNumberLine,
                        CustomerBUS.Instance.checkDuplicateName(this.phoneNumberTxtBox.Text),
                        "Số điện thoại đã có trong hệ thống"
                    );
                } else
                {
                    isPhone = CustomValidation.Instance.checkDuplicateName(
                        this.errorPhoneNumberMsg,
                        this.phoneNumberLine,
                        CustomerBUS.Instance.checkDuplicateName(this.phoneNumberTxtBox.Text, currentCustomer.Ma),
                        "Số điện thoại đã có trong hệ thống"
                    );
                }
            }
        }

        private void genderCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            CustomValidation.Instance.checkCombobox(
                this.genderCbx,
                this.errorGenderMsg,
                new string[] { "required" }
            );
        }
	}
}
