﻿using BookShop_CNPM.BUS;
using BookShop_CNPM.DTO;
using BookShop_CNPM.GUI.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.TextFormatting;

namespace BookShop_CNPM.GUI.Modal
{
	public partial class ImportRefundBillModal : Form
	{	
		public bool isSubmitSucces = false;
		public ImportRefundBillDTO importRefundBill = null;
		public int maNhaCungCap;
        private int staffId;

        public ImportRefundBillModal(int staffId, string title ="Thêm phiếu trả nhập hàng")
		{
			InitializeComponent();
			this.Text = title;	
			this.staffId = staffId;
		}

		private void ImportRefundBillModal_Load(object sender, EventArgs e)
		{

		   this.Location = new Point(
			   (Screen.PrimaryScreen.Bounds.Size.Width / 2) - (this.Size.Width / 2),
			   (Screen.PrimaryScreen.Bounds.Size.Height / 2) - (this.Size.Height / 2)
		   );
			RefundBookControl.OnChangeRefundBookAmount = CaculateTotalMoney;
			RefundBookControl.OnDeleteRefundBook = DeleteRefundBook;
			if(importRefundBill != null)
			{
                label4.Text = "Xem Chi Tiết Phiếu Trả Nhập Hàng";
                this.submitBtn.Visible = false;
                this.cancelBtn.Visible = false;
                this.importBillInput.Text = importRefundBill.MaDonNhapHang.ToString();
				this.importBillInput.Enabled = false;
				this.totalMoney.Text=importRefundBill.TongTien.ToString();
				this.staffTxt.Text = StaffBUS.Instance.getById(importRefundBill.MaNhanVien.ToString()).Ten;
				this.dateTimeTo.Value = importRefundBill.NgayLap;
				this.reasonTxt.Text = importRefundBill.LiDo;
				this.reasonTxt.Enabled = false;
				List<ImportBillDetailDTO> importBillDetail = ImportBillBUS.Instance.getImportBillDetailList(importRefundBill.MaDonNhapHang.ToString());
				loadDataToImportBookDetail(importBillDetail);
				List<ImportRefundBillDetailDTO> importRefundBillDetail = ImportRefundBillBUS.Instance.getImportRefundBillDetailList(importRefundBill.MaPhieu.ToString());
				loadDataToBookDetailList(importRefundBillDetail);
			}
			else
			{
				this.dateTimeTo.Value = DateTime.Now;
                // tìm cách lấy thông tin user hiện tại đăng nhập
                this.staffTxt.Text = StaffBUS.Instance.getById(staffId.ToString()).Ten;
                timer1.Start();
			}
		}

		private void loadDataToImportBookDetail(List<ImportBillDetailDTO> importBillDetail)
		{
			if (importBillDetail != null)
			{
				importBookContainer.Controls.Clear();
				foreach (ImportBillDetailDTO importBillDetailDTO in importBillDetail) 
				 {
					BookDTO book = BookBUS.Instance.getById(importBillDetailDTO.MaSach.ToString());
					ImportBookControl control = new ImportBookControl();
					control.details(book, importBillDetailDTO.SoLuong, importBillDetailDTO.SoLuongDoiTra, importBillDetailDTO.DonGia);
					this.importBookContainer.Controls.Add(control);
				}
			}
		}

		private void loadDataToBookList(List<ImportRefundBillDetailDTO> list)
		{
			if (list == null) return;
			try
			{
				if (list.Count > 0)
				{
					foreach (var item in list)
					{
						BookDTO book = BookBUS.Instance.getById(item.MaSach.ToString());
						Type targetType = typeof(RefundBookControl);
						List<RefundBookControl> bookControls = refundBookContainer.Controls.OfType<RefundBookControl>()
																.Where(i => targetType.IsAssignableFrom(i.GetType()))
																.ToList();
						if (!bookControls.Any(a => a.getId() == book.MaSach))
						{
							ImportBillDetailDTO importBillDetail = ImportBillBUS.Instance.getImportBillDetailList(this.importBillInput.Text).Where(c => c.MaSach == book.MaSach).FirstOrDefault();
							RefundBookControl control = new RefundBookControl();
							control.details(book,importBillDetail.SoLuong - importBillDetail.SoLuongDoiTra,importBillDetail.DonGia);
							this.refundBookContainer.Controls.Add(control);
							CaculateTotalMoney();
						};
					}
				}
				else
				{
					refundBookContainer.Controls.Clear();
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

		}

        private void loadDataToBookDetailList(List<ImportRefundBillDetailDTO> list)
        {
            if (list == null) return;
            try
            {
                if (list.Count > 0)
                {

                    foreach (var item in list)
                    {
                        BookDTO book = BookBUS.Instance.getById(item.MaSach.ToString());
                        Type targetType = typeof(ImportBookControl);
                        List<ImportBookControl> bookControls = refundBookContainer.Controls.OfType<ImportBookControl>()
                                                                .Where(i => targetType.IsAssignableFrom(i.GetType()))
                                                                .ToList();
                        if (!bookControls.Any(a => a.getId() == book.MaSach))
                        {
                            ImportRefundBillDetailDTO importBillDetail = ImportRefundBillBUS.Instance.getImportRefundBillDetailList(item.MaDon.ToString()).Where(c => c.MaSach == book.MaSach).FirstOrDefault();
                            ImportBookControl control = new ImportBookControl();
                            control.details(book, importBillDetail.SoLuong, 0, importBillDetail.DonGia);
                            this.refundBookContainer.Controls.Add(control);
                            CaculateTotalMoney();
                        };

                    }
                }
                else
                {
                    refundBookContainer.Controls.Clear();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void importBillInput_TextChanged(object sender, EventArgs e)
		{ 
			try
			{
				List<ImportBillDetailDTO> importBillDetail;
				var importBill = ImportBillBUS.Instance.getById(this.importBillInput.Text);
				if (importBill != null)
				{
					importBillDetail = ImportBillBUS.Instance.getImportBillDetailList(importBill.MaDonNhapHang.ToString());
					this.supplierNameTxt.Text = SupplierBUS.Instance.getById(importBill.MaNhaCungCap.ToString()).TenNhaCungCap;	
					this.maNhaCungCap = importBill.MaNhaCungCap;	
				}
				else
				{
					importBillDetail = new List<ImportBillDetailDTO>();
					this.supplierNameTxt.Text = "";
					this.totalMoney.Text = "0";
				}
                importBookContainer.Controls.Clear();
                this.loadDataToImportBookDetail(importBillDetail);
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			try
			{
				List<ImportRefundBillDetailDTO> listRefundBillDetail = new List<ImportRefundBillDetailDTO>();
				if (this.importBookContainer.Controls.Count > 0)
				{
					foreach (ImportBookControl control in importBookContainer.Controls)
					{
						if (control.check)
						{
							if (control.getSoLuong() <= 0)
							{
								control.UncheckStatus();
								MessageBox.Show("Số lượng không đủ");
							}
							else
							{
								BookDTO book = BookBUS.Instance.getById(control.getId().ToString());
								ImportRefundBillDetailDTO importRefundBillDetail = new ImportRefundBillDetailDTO(0, book.MaSach, 1, book.GiaNhap);
								listRefundBillDetail.Add(importRefundBillDetail);
							}
						}
					}
				}
				loadDataToBookList(listRefundBillDetail);
			}
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

		private void cancelBtn_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void submitBtn_Click(object sender, EventArgs e)
		{
			try
			{
				if (importRefundBill == null)
				{
					if (this.validateForm())
					{
						ImportRefundBillDTO importRefundBill = new ImportRefundBillDTO(
								0,
								Convert.ToDecimal(this.totalMoney.Text),
								this.reasonTxt.Text,
								Convert.ToInt32(this.importBillInput.Text),
								this.dateTimeTo.Value,
                                this.staffId
                            );
						ImportRefundBillDTO newImportRefundBill = ImportRefundBillBUS.Instance.insertReturnBill(importRefundBill);
						if (newImportRefundBill == null)
						{
							MessageBox.Show("Có lỗi xảy ra");
							this.isSubmitSucces = false;
						}
						else
						{
							foreach (RefundBookControl control in this.refundBookContainer.Controls)
							{
								ImportRefundBillDetailDTO item = new ImportRefundBillDetailDTO(
											newImportRefundBill.MaPhieu,
											control.getId(),
											control.GetBookAmount(),
											Convert.ToDecimal(control.getPrice())
									);
								ImportRefundBillBUS.Instance.createImportRefundBillDetail(item, this.importBillInput.Text);

							}
							this.isSubmitSucces = true;
							this.Close();
						}


					}
				}
				else
				{
					this.Close();
				}
			}
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

		private bool validateForm()
		{
			try
			{
				/*bool isSupplier = CustomValidation.Instance.checkTextbox(
									this.supplierNameTxt,
									this.supplierNameMsg,
									this.supplierNameLine,
									new string[] { "custom-supplier-required" }
								);*/
				bool isReasonValid = CustomValidation.Instance.checkTextbox(
						this.reasonTxt,
						this.reasonMsg,
						this.reasonLine,
						new string[] { "required" }
					);
				bool hasRefundBookSeletected = refundBookContainer.Controls.Count > 0 ? true : false;
				if (!hasRefundBookSeletected) MessageBox.Show("Vui lòng chọn ít nhất một sản phẩm để trả");
				return isReasonValid && hasRefundBookSeletected;
			}
			catch
			{
				return false;
			}
		}

		private void CaculateTotalMoney()
		{
			try
			{
				if (refundBookContainer.Controls.Count > 0)
				{
					double totalMoney = 0;
					foreach (RefundBookControl control in refundBookContainer.Controls)
					{
						int sl = control.GetBookAmount();
						totalMoney += control.getPrice() * sl;
					}
					this.totalMoney.Text = totalMoney.ToString();
				}
				else
				{
					this.totalMoney.Text = "0";
				}
			}
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void DeleteRefundBook(string id)
		{
			try
			{
				ImportBookControl importControl = importBookContainer.Controls.OfType<ImportBookControl>()
				.Where(c => c.getId().ToString() == id)
				.FirstOrDefault();
				if (importControl != null)
				{
					importControl.UncheckStatus();
				}
				RefundBookControl bookControl = refundBookContainer.Controls.OfType<RefundBookControl>()
						.Where(c => c.getId().ToString() == id)
						.FirstOrDefault();
				refundBookContainer.Controls.Remove(bookControl);
				refundBookContainer.Refresh();
				CaculateTotalMoney();
			}
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void reasonTxt_TextChanged(object sender, EventArgs e)
        {
            CustomValidation.Instance.checkTextbox(
                        this.reasonTxt,
                        this.reasonMsg,
                        this.reasonLine,
                        new string[] { "required" }
                    );
        }
    }
}
