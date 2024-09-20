using BookShop_CNPM.BUS;
using BookShop_CNPM.DTO;
using BookShop_CNPM.GUI.Modal;
using BookShop_CNPM.GUI.Report;
using BookShop_CNPM.GUI.UserControls;
using BookShop_CNPM.GUI.Vendor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BookShop_CNPM.GUI.Importer
{
    public partial class ImportGUI : Form
    {
        private bool search = false;
        private bool printBtnAllowed = false;
        private int supplierID = 0;
        private int staffID;
        private decimal total = 0;
        private bool importExcel = false;
		private int importBillId = Convert.ToInt32(ImportBillBUS.Instance.getLatestId()) + 1;
		private List<ImportBillDetailDTO> importBillDetails = new List<ImportBillDetailDTO>();

        public ImportGUI(int staffID)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            this.staffID = staffID;
        }

        private void Import_Load(object sender, EventArgs e)
        {
            try
            {
                List<BookDTO> books = BookBUS.Instance.getAllData();
                foreach (var book in books)
                {

						BookUserControl product = new BookUserControl(1);
						product.details(book);
						product.TabStop = false;
						BookContainer.Controls.Add(product);
					
                }
                FilterUserControl filter = new FilterUserControl();
                filter.TabStop = false;

                List<AuthDetailDTO> authDetails;
                authDetails = AuthDetailBUS.Instance.getByPositionId(MenuGUI.staff.MaChucVu.ToString());
                if (authDetails != null)
                {
                    // check quyen Nhà Cung Cấp
                    if (!authDetails.Any(c => c.maQuyenHan == 3 && c.TrangThai))
                    {
                        this.AddCustomerBtn.Enabled = false;
                    }
                    else
                    {
                        this.AddCustomerBtn.Enabled = true;
                    }
                    // check quyen Sách
                    if (!authDetails.Any(c => c.maQuyenHan == 1 && c.TrangThai))
                    {
                        this.CreateBookBtn.Enabled = false;
                    }
                    else
                    {
                        this.CreateBookBtn.Enabled = true;
                    }
                    // check quyen đổi trả
                }
                else
                {
                    this.AddCustomerBtn.Enabled = false;
                    this.CreateBookBtn.Enabled = false;

                }
            }

            catch (Exception ex) { Console.WriteLine(ex); }
        }

        private void RenderBookContainer()
        {
            try
            {
                BookContainer.Controls.Clear();
                List<BookDTO> books = BookBUS.Instance.getAllData();
                foreach (var book in books)
                {
                    BookUserControl product = new BookUserControl(1);
                    product.details(book);
                    product.TabStop = false;
					BookContainer.Controls.Add(product);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }

        private void ProductSearchInp_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (ProductSearchInp.Focused && !string.IsNullOrEmpty(ProductSearchInp.Text))
                {
                    search = true;
                    BookContainer.Controls.Clear();
                    List<BookDTO> books = BookBUS.Instance.search(ProductSearchInp.Text);
					foreach (var book in books)
					{

						
							BookUserControl product = new BookUserControl(1);
							product.details(book);
							product.TabStop = false;
							BookContainer.Controls.Add(product);
						
                    }
                }
                else if (search)
                {
                    RenderBookContainer();
                    search = false;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }

        private void FilterBtn_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex) { Console.WriteLine(ex); }

        }

        private void NameInp_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (NameInp.Focused && !string.IsNullOrEmpty(NameInp.Text))
                {
                    NameResultContainer.Controls.Clear();
                    String query = NameInp.Text;
                    List<SupplierDTO> suppliers = SupplierBUS.Instance.search(query);
                    if (suppliers != null)
                    {
                        foreach (var supplier in suppliers)
                        {
                            SearchResultControl res = new SearchResultControl();
                            res.details_Import(supplier);
                            res.TabStop = false;
							NameResultContainer.Controls.Add(res);
                        }
                    }
                    if (NameResultContainer.Controls.Count <= 4)
                    {
                        NameResultContainer.Width = 244;
                    }
                    else
                    {
                        NameResultContainer.Width = 261;
                    }
                    NameResultContainer.Height = NameResultContainer.Controls.Count * 45;
                }
                else
                {
                    NameResultContainer.Height = 0;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }

        private void AddSupplierBtn_Click(object sender, EventArgs e)
        {
            try
            {
                NameInp.Text = "";
                NameResultContainer.Height = 0;
                SupplierNameLb.Text = "";

                using (SupplierModal modal = new SupplierModal())
                {
                    modal.ShowDialog();
                }
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }

        private void QRScanBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var modal = new ScannerModal();
                modal.ShowDialog();
                BookDTO book = modal.scannedBook;
                if (book != null)
                {
                    AddProductToCart(book);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }

		private void AddProductToCart(BookDTO book, decimal importPrice = -1, int amount = 1, bool disabled = false)
		{
			try
			{
				if (importBillDetails.Count == 0 || !importBillDetails.Any(item => item.MaSach == book.MaSach))
				{
					ImportCartProductUserControl product = new ImportCartProductUserControl(1);
					product.details(book, amount);
					product.BillIdDetailLb.Text = importBillId.ToString();

					product.ImportPriceTxb.MouseLeave += (object sender, EventArgs e) =>
					{
						panel1.Focus();
						ImportBillDetailDTO match = importBillDetails.Find(item => item.MaSach == Convert.ToInt32(product.IdLb.Text));
						if (match != null)
						{
							match.DonGia = Convert.ToDecimal(product.ImportPriceTxb.Text);
						}
						CartHandler();
					};

					if (importPrice != -1)
					{
						product.ImportPriceTxb.Text = importPrice.ToString();
					}

					if (disabled)
					{
						product.amountPanel.Enabled = false;
						product.ImportPriceTxb.Enabled = false;
						product.DeleteBtn.Enabled = false;
					}

					CartContainer.Controls.Add(product);

					ImportBillDetailDTO importBillDetail = new ImportBillDetailDTO(0, book.MaSach, amount, Convert.ToDecimal(product.ImportPriceTxb.Text));
					importBillDetails.Add(importBillDetail);
				}
				else
				{
					int idx = 0;

					foreach (var importBillDetail in importBillDetails)
					{
						if (importBillDetail.MaSach == book.MaSach)
						{
							importBillDetail.SoLuong += 1;
							ImportCartProductUserControl cartProduct = CartContainer.Controls[idx] as ImportCartProductUserControl;
							cartProduct.AmountTxt.Text = (Convert.ToInt32(cartProduct.AmountTxt.Text) + 1).ToString();
							break;
						}
						idx++;
					}
				}

				CartHandler();
				BookUserControl.ChoseId = "";
				BookUserControl.clicked = false;
			}
			catch (Exception ex) { Console.WriteLine(ex); }
		}

		private void checkUser_Tick(object sender, EventArgs e)
        {
			try
			{
				if (BookUserControl.clicked)
				{
					if (!importExcel)
					{
						int ChoseId_int = Convert.ToInt32(BookUserControl.ChoseId);
						BookDTO book = BookBUS.Instance.getById(BookUserControl.ChoseId);
						AddProductToCart(book);
					}
					else
					{
						BookUserControl.clicked = false;
					}
				}

				if (ImportCartProductUserControl.deletePress)
				{
					Console.WriteLine(1);
					int idx = 0;

					foreach (var importBillDetail in importBillDetails)
					{
						if (importBillDetail.MaSach == Convert.ToInt32(ImportCartProductUserControl.deleteId))
						{
							importBillDetails.RemoveAt(idx);

							ImportCartProductUserControl cartProduct = CartContainer.Controls[idx] as ImportCartProductUserControl;
							CartContainer.Controls.RemoveAt(idx);
							cartProduct.Dispose();
							break;
						}
						idx++;
					}

					CartHandler();
					ImportCartProductUserControl.deleteId = "";
					ImportCartProductUserControl.deletePress = false;
				}

				if (ImportCartProductUserControl.AmountChanged)
				{
					int idx = 0;

					foreach (var importBillDetail in importBillDetails)
					{
						if (importBillDetail.MaSach == Convert.ToInt32(ImportCartProductUserControl.AmountChangedId))
						{
							ImportCartProductUserControl cartProduct = CartContainer.Controls[idx] as ImportCartProductUserControl;
							importBillDetail.SoLuong = Convert.ToInt32(cartProduct.AmountTxt.Text);
							break;
						}
						idx++;
					}
					CartHandler();
					ImportCartProductUserControl.AmountChanged = false;
				}

				if (SearchResultControl.clicked)
				{
					supplierID = SearchResultControl.id;
					SupplierDTO supplier = SupplierBUS.Instance.getById(SearchResultControl.id.ToString());
					SupplierNameLb.Text = supplier.TenNhaCungCap;
					NameResultContainer.Height = 0;
					NameInp.Text = "";
					CartHandler();
					SearchResultControl.clicked = false;
				}

			}
			catch (Exception ex) { Console.WriteLine(ex); }
        }

        private void CartHandler()
        {
            try
            {
                total = 0;
                foreach (var importBillDetail in importBillDetails)
                {
					if (!string.IsNullOrEmpty(ProfitPercentTxb.Text)) {
						/*decimal giaNhap = importBillDetail.DonGia - Convert.ToDecimal(Convert.ToDecimal(importBillDetail.DonGia * Convert.ToDecimal(Convert.ToInt32(ProfitPercentTxb.Text) / 100.0)).ToString().Split('.')[0]);*/
						decimal giaNhap = importBillDetail.DonGia - importBillDetail.DonGia * Convert.ToDecimal(Convert.ToInt32(ProfitPercentTxb.Text) / 100.0);
                        total += importBillDetail.SoLuong * giaNhap;
                    }
                    else
					{
                        decimal giaNhap = importBillDetail.DonGia;
                        total += importBillDetail.SoLuong * giaNhap;
                    }
               
                }

                TotalMoneyLb.Text = string.Format("{0:N0} VND", total);

				if (CartContainer.Controls.Count > 0 && supplierID != 0 && !string.IsNullOrEmpty(ProfitPercentTxb.Text) && Convert.ToInt32(ProfitPercentTxb.Text) <= 100)
				{
					PrintBtn.Cursor = Cursors.Hand;
					printBtnAllowed = true;
					PrintBtn.BackColor = Color.FromArgb(45, 210, 192);
				}
				else
				{
					PrintBtn.Cursor = Cursors.No;
					printBtnAllowed = false;
					PrintBtn.BackColor = Color.Silver;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }
		private void ProductSearchInp_MouseLeave(object sender, EventArgs e)
		{
			panel1.Focus();
		}

		private void PrintBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (printBtnAllowed)
                {
					ImportBillDTO importBill = new ImportBillDTO();
					importBill.TongTien = total;
					importBill.MaNhanVien = staffID;
					importBill.MaNhaCungCap = supplierID;
					importBill.NgayLap = DateTime.Now;
                    importBill.PhanTramLoiNhuan = Convert.ToInt32(ProfitPercentTxb.Text);

                    ImportBillDTO newImportBill = ImportBillBUS.Instance.insertReturnBill(importBill);

					if (newImportBill == null)
					{
						MessageBox.Show("Thất bại");
						return;
					}
					else
					{
						foreach (var importBillDetail in importBillDetails)
						{
                           
                            ImportBillDetailDTO newImportBillDetail = new ImportBillDetailDTO(
								newImportBill.MaDonNhapHang,
								importBillDetail.MaSach,
								importBillDetail.SoLuong,
								importBillDetail.DonGia
							);
							ImportBillBUS.Instance.createImportBillDetail(newImportBillDetail, importBill.PhanTramLoiNhuan);
                         
						}

						MessageBox.Show("Thành công");
					
                    }
                    using (ImportBillPrintForm importBillPrintForm = new ImportBillPrintForm(newImportBill.MaDonNhapHang))
					{
						importBillPrintForm.ShowDialog();
					}

					refresh();
				}
				else
				{
					panel1.Focus();
				}
			}
            catch (Exception ex) { Console.WriteLine(ex); }
        }

        private void LogOutBtn_Click(object sender, EventArgs e)
        {
            Close();
            MenuGUI menu = new MenuGUI(staffID);
            menu.Show();
        }

		private void RefundBtn_Click(object sender, EventArgs e)
		{
			using (var modal = new ImportRefundBillModal(staffID))
			{
				modal.ShowDialog();
			}
		}

		private void ChangeBtn_Click(object sender, EventArgs e)
		{
			using (var modal = new ImportChangeBillModal(staffID))
			{
				modal.ShowDialog();
			}
		}

		private byte[] BitmapToByteArray(Bitmap bitmap)
		{
			using (MemoryStream stream = new MemoryStream())
			{
				// Save the Bitmap into the MemoryStream
				bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);

				// Return the byte array from the MemoryStream
				return stream.ToArray();
			}
		}

		private void ExcelImportBtn_Click(object sender, EventArgs e)
		{
            try
            {
				DataTable dt = CustomExcel.Instance.ImportFile();

				if (dt == null)
				{
					MessageBox.Show("Lỗi chưa chọn file hoặc file excel không đúng dữ liệu!");
					return;
				}

				int count = 1;
				List<int> id = new List<int>();

				//Validate loop
				foreach (DataRow row in dt.Rows)
				{
					if (count == 1)
					{
						if (!int.TryParse(row[1].ToString(), out int maNhaCungCap))
						{
							MessageBox.Show("Lỗi chưa chọn file hoặc file excel không đúng format dữ liệu nhập!");
							return;
						}

						count++;
						continue;
					}

					if (count == 2)
					{
						count++;
						continue;
					}

					if (!int.TryParse(row[2].ToString(), out int soLuong) || soLuong < 0 || !decimal.TryParse(row[3].ToString(), out decimal giaNhap) || giaNhap < 0)
					{
						MessageBox.Show("Lỗi chưa chọn file hoặc file excel không đúng format dữ liệu nhập!");
						return;
					}

/*Thử nghiệm*/
					if (BookBUS.Instance.checkDuplicateName(row[1].ToString()))
					{
						int maSach = BookBUS.Instance.getIdByName(row[1].ToString());
                        Console.WriteLine(id.Contains(maSach));
                        BookDTO book = BookBUS.Instance.getById(maSach.ToString());
                        if (book == null || id.Contains(maSach))
                        {
                            MessageBox.Show("Lỗi chưa chọn file hoặc file excel không đúng format dữ liệu nhập!");
                            return;
                        }
                        id.Add(maSach);
                    }
					/*if (int.TryParse(row[0].ToString(), out int maSach))
					{
                        Console.WriteLine(id.Contains(maSach));
                        BookDTO book = BookBUS.Instance.getById(maSach.ToString());
                        if (book == null || id.Contains(maSach))
                        {
							MessageBox.Show("Lỗi chưa chọn file hoặc file excel không đúng format dữ liệu nhập!");
							return;
						}
						id.Add(maSach);
                    }*/
				}

				CartContainer.Controls.Clear();
				importBillDetails.Clear();
				NameInp.Enabled = false;
				QRScanBtn.Enabled = false;
				QRScanBtn.Cursor = Cursors.No;
				importExcel = true;
				count = 1;

				//Add books loop
				foreach (DataRow row in dt.Rows)
				{
					if (count == 1)
					{
						SupplierDTO supplier = SupplierBUS.Instance.getById(row[1].ToString());
						supplierID = supplier.MaNhaCungCap;
						SupplierNameLb.Text = supplier.TenNhaCungCap;
						count++;
						continue;
					}

					if (count == 2)
					{
						count++;
						continue;
					}

					bool created = false;
					int quantity = Convert.ToInt32(row[2].ToString());
					/*==========================*/
					if (!BookBUS.Instance.checkDuplicateName(row[1].ToString()) && quantity > 0)
					{
						byte[] defaultImg = BitmapToByteArray(Properties.Resources.book_cover);
						BookDTO newBook = new BookDTO();
						newBook.TenSach = row[1].ToString();
                        newBook.HinhAnh = defaultImg;
						newBook.GiaBan = Convert.ToDecimal(row[3].ToString());
						newBook.GiaNhap = Convert.ToDecimal(row[3].ToString());
						created = BookBUS.Instance.insert(newBook);
                        if (created)
                        {
							MessageBox.Show("Đã tạo sách mới có tên là: \"" + row[1].ToString() + " \"!");
						}
					}
					BookDTO book = created ? BookBUS.Instance.getLatestBook() : BookBUS.Instance.getById(BookBUS.Instance.getIdByName(row[1].ToString()).ToString());
					if (quantity > 0)
					{
						AddProductToCart(book, Convert.ToDecimal(row[3].ToString()), quantity, disabled: true);
					}
				}
			}
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

		private void refresh()
		{
			CartContainer.Controls.Clear();
			importBillDetails.Clear();
			ErrorLb.Visible = false;
			PrintBtn.Cursor = Cursors.No;
			printBtnAllowed = false;
            importExcel = false;
			NameInp.Enabled = true;
			QRScanBtn.Enabled = true;
			QRScanBtn.Cursor = Cursors.Hand;
			PrintBtn.BackColor = Color.Silver;
			SupplierNameLb.Text = "";
			ProfitPercentTxb.Text = "";
			supplierID = 0;
			CartHandler();
			RenderBookContainer();
			label1.Focus();
		}

		private void NameInp_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
				{
					e.Handled = true; // Cancel the key press event
				}
			}
			catch (Exception ex) { Console.WriteLine(ex); }
		}

		private void CreateBookBtn_Click(object sender, EventArgs e)
		{
			using (BookModal bookM = new BookModal())
			{
				bookM.ShowDialog();

				if (bookM.isSubmitSuccess)
				{
					RenderBookContainer();
				}
			}
		}
		private void ProfitPercentTxb_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
				{
					e.Handled = true; // Cancel the key press event
				}
			}
			catch (Exception ex) { Console.WriteLine(ex); }
		}

		private void ProfitPercentTxb_MouseLeave(object sender, EventArgs e)
		{
			panel1.Focus();
			if (ProfitPercentTxb.Text.Length > 6)
			{
				ProfitPercentTxb.Text = "100";
			}
			if (!string.IsNullOrEmpty(ProfitPercentTxb.Text))
			{
				ErrorLb.Visible = Convert.ToInt32(ProfitPercentTxb.Text) > 100;
			}
			CartHandler();
		}

		private void refreshBtn_Click(object sender, EventArgs e)
		{
            refresh();
		}

        private void FilterContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ProfitPercentTxb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CartContainer_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
