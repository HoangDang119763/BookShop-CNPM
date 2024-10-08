﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Google.Protobuf.WellKnownTypes;
using BookShop_CNPM.BUS;
using BookShop_CNPM.DTO;
using BookShop_CNPM.GUI.Modal;
using BookShop_CNPM.GUI.Report;
using BookShop_CNPM.GUI.UserControls;
using BookShop_CNPM.GUI.Vendor;

namespace BookShop_CNPM.GUI
{
    public partial class VendorGUI : Form
    {
        private bool CustomerEnabled = false;
        private bool PointEnabled = false;
        private bool search = false;
        private bool PrintBtnAllowed = false;
        private int customerID = 0;
        private int staffID;
        private decimal finalTotalMoney = 0;
        private decimal totalMoneyNoPointDiscount = 0;
        private int percent = 0;
        private List<CustomerBillDetailDTO> customerBillDetails = new List<CustomerBillDetailDTO>();

        public VendorGUI(int staffID)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            this.staffID = staffID;

            DiscountCb.MaxDropDownItems = 10;
        }

        private void Vendor_Load(object sender, EventArgs e)
        {
            try
            {
                List<BookDTO> books = BookBUS.Instance.getAllData();
                foreach (var book in books)
                {
  
                        BookUserControl product = new BookUserControl(0);
                        product.details(book);
                        product.TabStop = false;
                        BookContainer.Controls.Add(product);
                  

                }
                FilterUserControl filter = new FilterUserControl();
                filter.TabStop = false;
                FilterContainer.Controls.Add(filter);

                List<SaleDTO> discounts = SaleBUS.Instance.getAllNotExpired() ?? new List<SaleDTO>();
                discounts.Insert(0, new SaleDTO(0, "Không có khuyến mãi", 0, new DateTime(), new DateTime()));
                DiscountCb.DataSource = discounts;
                DiscountCb.DisplayMember = "tenKhuyenMai";
                DiscountCb.ValueMember = "maKhuyenMai";
                DiscountCb.SelectedIndex = 0;
                List<AuthDetailDTO> authDetails;
                authDetails = AuthDetailBUS.Instance.getByPositionId(MenuGUI.staff.MaChucVu.ToString());
                if (authDetails != null)
                {
                    // check quyen khách hàng
                    if (!authDetails.Any(c => c.maQuyenHan == 9 && c.TrangThai))
                    {
                        this.AddCustomerBtn.Enabled = false;
                    }
                    else
                    {
                        this.AddCustomerBtn.Enabled = true;
                    }
                }
                else
                {
                    this.AddCustomerBtn.Enabled = false;
                    this.RefundBtn.Enabled = false;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }

        private void CustomerToggleBtn_CheckedChanged(object sender, EventArgs e)
        {
            CustomerEnabled = CustomerToggleBtn.Checked;
            PhoneInp.Enabled = CustomerEnabled;
            AddCustomerBtn.Enabled = CustomerEnabled;
            PointAmountLb.Text = "";
            if (!CustomerEnabled)
            {
                RecipientNameLb.Text = "Vãng lai";
                PhoneInp.Text = "";
                PhoneResultContainer.Height = 0;
                PointToggleBtn.Checked = false;
                PointToggleBtn.Enabled = false;
            }
            else
            {
                RecipientNameLb.Text = "";
                PointToggleBtn.Enabled = false;
            }
            List<AuthDetailDTO> authDetails;
            authDetails = AuthDetailBUS.Instance.getByPositionId(MenuGUI.staff.MaChucVu.ToString());
            if (authDetails != null)
            {
                // check quyen khách hàng
                if (!authDetails.Any(c => c.maQuyenHan == 8 && c.TrangThai))
                {
                    this.AddCustomerBtn.Enabled = false;
                }
                else
                {
                    this.AddCustomerBtn.Enabled = true;
                }
            }
            else
            {
                this.AddCustomerBtn.Enabled = false;
            }
        }

        private void RenderBookContainer()
        {
            try
            {
                BookContainer.Controls.Clear();
                List<BookDTO> books = BookBUS.Instance.getAllData();
                foreach (var book in books)
                {
                    if (book.SoLuongConLai != 0)
                    { 
                    BookUserControl product = new BookUserControl(0);
                    product.details(book);
                    product.TabStop = false;
                    BookContainer.Controls.Add(product);
                }
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
                        if (book.SoLuongConLai != 0)
                        {
                        BookUserControl product = new BookUserControl(0);
                        product.details(book);
                        product.TabStop = false;
                        BookContainer.Controls.Add(product);
                    }
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
                if (!FilterContainer.Visible)
                {
                    FilterContainer.Visible = true;
                }
                else
                {
                    FilterContainer.Visible = false;
                }
                label1.Focus();
            }
            catch (Exception ex) { Console.WriteLine(ex); }

        }

        private void PhoneInp_KeyPress(object sender, KeyPressEventArgs e)
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


        private void PhoneInp_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (CustomerEnabled)
                {
                    if (PhoneInp.Focused && !string.IsNullOrEmpty(PhoneInp.Text))
                    {
                        PhoneResultContainer.Controls.Clear();
                        String query = PhoneInp.Text;
                        if (query != "0")
                        {
                            List<CustomerDTO> customers = CustomerBUS.Instance.SearchByPhoneNum(query);
                            if (customers != null)
                            {
                                foreach (var customer in customers)
                                {
                                    SearchResultControl res = new SearchResultControl();
                                    res.details_Vendor(customer);
                                    res.TabStop = false;
                                    PhoneResultContainer.Controls.Add(res);
                                }
                            }
                            if (PhoneResultContainer.Controls.Count <= 4)
                            {
                                PhoneResultContainer.Width = 244;
                            }
                            else
                            {
                                PhoneResultContainer.Width = 261;
                            }
                            PhoneResultContainer.Height = PhoneResultContainer.Controls.Count * 45;
                        }
                    }
                    else
                    {
                        PhoneResultContainer.Height = 0;
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }

        private void AddCustomerBtn_Click(object sender, EventArgs e)
        {
            try
            {
                PhoneResultContainer.Height = 0;
                RecipientNameLb.Text = "";
                PointToggleBtn.Checked = false;

                using (CustomerModal modal = new CustomerModal())
                {
                    modal.ShowDialog();
                }
                label1.Focus();
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
                else
                {
                    MessageBox.Show("Không tìm được sách đã quét");
                }
                label1.Focus();
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }

        private void AddProductToCart(BookDTO book)
        {
            try
            {
                if (customerBillDetails.Count == 0 || !customerBillDetails.Any(item => item.MaSach == book.MaSach))
                {
                    int stock = BookBUS.Instance.getById(book.MaSach.ToString()).SoLuongConLai;
                    if (stock != 0)
                    {
                        CustomerBillDetailDTO customerBillDetail = new CustomerBillDetailDTO(0, book.MaSach, 1, book.GiaBan);
                        customerBillDetails.Add(customerBillDetail);
                        VendorCartProductUserControl product = new VendorCartProductUserControl();
                        product.details(book);
                        CartContainer.Controls.Add(product);
                    }
                    else
                    {
                        MessageBox.Show("Hết hàng");
                    }
                }
                else
                {
                    int idx = 0;

                    foreach (var customerBillDetail in customerBillDetails)
                    {
                        if (customerBillDetail.MaSach == book.MaSach)
                        {
                            int stock = BookBUS.Instance.getById(book.MaSach.ToString()).SoLuongConLai;
                            if (customerBillDetail.SoLuong >= stock)
                            {
                                BookUserControl.ChoseId = "";
                                BookUserControl.clicked = false;
                                MessageBox.Show("Hết hàng");
                                return;
                            }
                            else
                            {
                                customerBillDetail.SoLuong += 1;

                                VendorCartProductUserControl cartProduct = CartContainer.Controls[idx] as VendorCartProductUserControl;
                                cartProduct.AmountTxt.Text = (Convert.ToInt32(cartProduct.AmountTxt.Text) + 1).ToString();
                                break;
                            }
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
                    int ChoseId_int = Convert.ToInt32(BookUserControl.ChoseId);
                    BookDTO book = BookBUS.Instance.getById(BookUserControl.ChoseId);
                    AddProductToCart(book);
                }

                if (VendorCartProductUserControl.deletePress)
                {
                    int idx = 0;

                    foreach (var customerBillDetail in customerBillDetails)
                    {
                        if (customerBillDetail.MaSach == Convert.ToInt32(VendorCartProductUserControl.deleteId))
                        {
                            customerBillDetails.RemoveAt(idx);

                            VendorCartProductUserControl cartProduct = CartContainer.Controls[idx] as VendorCartProductUserControl;
                            CartContainer.Controls.RemoveAt(idx);
                            cartProduct.Dispose();
                            break;
                        }
                        idx++;
                    }

                    CartHandler();
                    VendorCartProductUserControl.deleteId = "";
                    VendorCartProductUserControl.deletePress = false;
                }

                if (VendorCartProductUserControl.AmountChanged)
                {
                    int idx = 0;

                    foreach (var customerBillDetail in customerBillDetails)
                    {
                        if (customerBillDetail.MaSach == Convert.ToInt32(VendorCartProductUserControl.AmountChangedId))
                        {
                            VendorCartProductUserControl cartProduct = CartContainer.Controls[idx] as VendorCartProductUserControl;
                            customerBillDetail.SoLuong = Convert.ToInt32(cartProduct.AmountTxt.Text);
                            break;
                        }
                        idx++;
                    }
                    CartHandler();
                    VendorCartProductUserControl.AmountChanged = false;
                }

                if (SearchResultControl.clicked)
                {
                    customerID = SearchResultControl.id;
                    CustomerDTO customer = CustomerBUS.Instance.getById(SearchResultControl.id.ToString());
                    RecipientNameLb.Text = customer.Ten;
                    PhoneResultContainer.Height = 0;
                    PhoneInp.Text = "";
                    CartHandler();
                    int pointDiscount = CustomerBUS.Instance.getById(customerID.ToString()).Diem;
                    PointAmountLb.Text = $@"{pointDiscount} điểm";
                    if (pointDiscount > 0) PointToggleBtn.Enabled = true;
                    SearchResultControl.clicked = false;
                }

                if (FilterUserControl.ApplyClicked)
                {
                    FilterContainer.Visible = false;
                    List<BookDTO> books = BookBUS.Instance.getAllDataFiltered(FilterUserControl.Sort, FilterUserControl.TypeID, FilterUserControl.AuthorID, FilterUserControl.PublisherID, false);
                    BookContainer.Controls.Clear();
                    foreach (var book in books)
                    {
                        if (book.SoLuongConLai != 0) {
                        BookUserControl product = new BookUserControl(0);
                        product.details(book);
                        product.TabStop = false;
                        BookContainer.Controls.Add(product);
                    }
                    }
                    FilterUserControl.ApplyClicked = false;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }

        private void CartHandler()
        {
            try
            {
                decimal total = 0;
                foreach (var customerBillDetail in customerBillDetails)
                {
                    total += customerBillDetail.SoLuong * customerBillDetail.DonGia;
                }

                TotalMoneyLb.Text = string.Format("{0:N0} VND", total);
                decimal pointDiscount = 0;
                if (PointEnabled)
                {
                    pointDiscount = CustomerBUS.Instance.getById(customerID.ToString()).Diem * 1000;
                }
                decimal discount = total * (percent / Convert.ToDecimal(100.0));
                totalMoneyNoPointDiscount = total - discount;
                finalTotalMoney = Math.Max(total - discount - pointDiscount, 0);

                DiscountMoneyLb.Text = string.Format("{0:N0} VND", discount);
                FinalTotalMoneyLb.Text = string.Format("{0:N0} VND", finalTotalMoney);

                decimal CustommerCash = 0;
                decimal Change = 0;
                if (CustomerCashTxb.Text.Length > 0 && total > 0)
                {
                    CustommerCash = Convert.ToDecimal(CustomerCashTxb.Text);
                    Change = CustommerCash - finalTotalMoney;
                }
                else
                {
                    Change = -finalTotalMoney;
                }
                ChangeMoneyLb.Text = string.Format("{0:N0} VND", Change);

                if (Change < 0)
                {
                    ChangeMoneyLb.ForeColor = Color.Red;
                }
                else
                {
                    ChangeMoneyLb.ForeColor = Color.Black;
                }

                if (CartContainer.Controls.Count > 0 && !String.IsNullOrEmpty(RecipientNameLb.Text) && CustomerCashTxb.Text.Length > 0 && Change >= 0)
                {
                    PrintBtn.Cursor = Cursors.Hand;
                    PrintBtnAllowed = true;
                }
                else
                {
                    PrintBtn.Cursor = Cursors.No;
                    PrintBtnAllowed = false;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }

        private void DiscountCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (DiscountCb.SelectedIndex != 0)
                {
                    string discountID = DiscountCb.SelectedValue.ToString();
                    percent = SaleBUS.Instance.getById(discountID).PhanTram;
                    decimal total = Convert.ToDecimal(TotalMoneyLb.Text.Replace(".", "").Replace(" VND", ""));
                    DiscountPercentLb.Text = $@"{percent}%";
                    CartHandler();
                }
                else
                {
                    DiscountPercentLb.Text = "";
                    percent = 0;
                    CartHandler();
                }
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }

        private void PointToggleBtn_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (CustomerEnabled)
                {
                    PointEnabled = PointToggleBtn.Checked;
                }
                else
                {
                    PointEnabled = false;
                }

                CartHandler();
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }


        private void CustomerCashTxb_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == '\r')
                {
                    TotalLb.Focus();
                    return;
                }

                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // Cancel the key press event
                }
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }

        private void CustomerCashTxb_MouseLeave(object sender, EventArgs e)
        {
            VndLb.Focus();
            CartHandler();
        }

        private decimal RoundMoney(decimal money)
        {
            decimal baseMoney = 50000; // Số tiền cơ sở để làm tròn
            return Convert.ToDecimal(Math.Floor(money / baseMoney) * baseMoney);
        }

        private void PrintBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (PrintBtnAllowed)
                {
                    CustomerBillDTO customerBill = new CustomerBillDTO();
                    customerBill.TongTien = finalTotalMoney;
                    customerBill.TienKhachDua = Convert.ToDecimal(CustomerCashTxb.Text);
                    customerBill.MaNhanVien = staffID;
                    customerBill.MaKhachHang = CustomerEnabled ? customerID : 0;
                    customerBill.MaKhuyenMai = Convert.ToInt32(DiscountCb.SelectedValue);
                    /*List<SaleDTO> checkIfExistSaleId = SaleBUS.Instance.search("Không có khuyến mãi");
                        if (checkIfExistSaleId == null)
                        {
                            SaleDTO newSale = new SaleDTO(
                                customerBill.MaKhuyenMai,
                                "Không có khuyến mãi",
                                0,
                                customerBill.NgayLap,
                                customerBill.NgayLap.AddDays(1)
                            );
                            customerBill.MaKhuyenMai = newSale.MaKhuyenMai;
                            SaleBUS.Instance.insert(newSale);
                        }
                        else
                        {
                            customerBill.MaKhuyenMai = checkIfExistSaleId[0].MaKhuyenMai;
                        }*/
                    customerBill.NgayLap = DateTime.Now;
                    if (DiscountCb.SelectedIndex != 0)
                    {
                        string discountID = DiscountCb.SelectedValue.ToString();
                        int percent = SaleBUS.Instance.getById(discountID).PhanTram;
                        customerBill.PhanTramKhuyenMai = percent;
                    }
                    if (customerBill.MaKhachHang != 0 && PointEnabled)
                    {
                        if (finalTotalMoney == 0)
                        {
                            if (totalMoneyNoPointDiscount % 1000 != 0)
                            {
                                totalMoneyNoPointDiscount = Convert.ToDecimal(Convert.ToInt64(totalMoneyNoPointDiscount - (totalMoneyNoPointDiscount % 1000)) + 1000);
                            }
                            customerBill.DoiDiem = Convert.ToInt32(totalMoneyNoPointDiscount / 1000);
                        }
                        else
                        {
                            customerBill.DoiDiem = CustomerBUS.Instance.getById(customerID.ToString()).Diem;
                        }
                    }


                    // Debug
                    Console.WriteLine("Tổng tiền: " + customerBill.TongTien);
                    Console.WriteLine("Tiền khách đưa: " + customerBill.TienKhachDua);
                    Console.WriteLine("Mã nhân viên: " + customerBill.MaNhanVien);
                    Console.WriteLine("Mã khách hàng: " + customerBill.MaKhachHang);
                    Console.WriteLine("Mã khuyến mãi: " + customerBill.MaKhuyenMai);
                    Console.WriteLine("Ngày lập: " + customerBill.NgayLap);

                    CustomerBillDTO newCustomerBill = CustomerBillBUS.Instance.insertReturnBill(customerBill);


                    if (newCustomerBill == null)
                    {
                        MessageBox.Show("Thất bại");
                    }
                    else
                    {
                        foreach (var customerBillDetail in customerBillDetails)
                        {
                            CustomerBillDetailDTO newCustomerBillDetail = new CustomerBillDetailDTO(
                                newCustomerBill.MaDonKhachHang,
                                customerBillDetail.MaSach,
                                customerBillDetail.SoLuong,
                                customerBillDetail.DonGia
                            );

                            CustomerBillBUS.Instance.createCustomerBillDetail(newCustomerBillDetail);
                        }

                        MessageBox.Show("Thành công");
                    }

                    if (CustomerEnabled)
                    {
                        if (PointEnabled)
                        {
                            CustomerDTO customer_Point = CustomerBUS.Instance.getById(customerID.ToString());
                            customer_Point.Diem -= Convert.ToInt32(totalMoneyNoPointDiscount) / 1000;
                            if (customer_Point.Diem < 0) customer_Point.Diem = 0;
                            CustomerBUS.Instance.update(customer_Point);
                        }

                        decimal baseMoney = 50000;
                        int point = Convert.ToInt32(RoundMoney(finalTotalMoney) / baseMoney);
                        CustomerDTO customer_addPoint = CustomerBUS.Instance.getById(customerID.ToString());
                        customer_addPoint.Diem += point;
                        CustomerBUS.Instance.update(customer_addPoint);
                        if (point > 0)
                        {
                            MessageBox.Show("Khách hàng " + customer_addPoint.Ten + " được cộng: " + point + " điểm");
                        }
                    }

                    using (CustomerBillPrintForm customerBillPrintForm = new CustomerBillPrintForm(newCustomerBill.MaDonKhachHang))
                    {
                        customerBillPrintForm.ShowDialog();
                    }

                    CustomerEnabled = false;
                    PointEnabled = false;
                    PointToggleBtn.Checked = false;
                    PointToggleBtn.Enabled = false;
                    CustomerToggleBtn.Checked = false;
                    CustomerCashTxb.Text = "";
                    PhoneInp.Text = "";
                    ProductSearchInp.Text = "";
                    percent = 0;
                    DiscountMoneyLb.Text = "0 VND";
                    DiscountCb.SelectedIndex = 0;
                    RecipientNameLb.Text = "Vãng lai";
                    PointAmountLb.Text = string.Empty;
                    DiscountPercentLb.Text = string.Empty;
                    customerID = 0;
                    CartContainer.Controls.Clear();
                    customerBillDetails.Clear();
                    CartHandler();
                    RenderBookContainer();
                    label1.Focus();
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
            using (var modal = new CustomerRefundBillModal(staffID))
            {
                modal.ShowDialog();
            }
        }

        private void ChangeBtn_Click(object sender, EventArgs e)
        {
            using (var modal = new CustomerChangeBillModal(staffID))
            {
                modal.ShowDialog();
            }
        }

        private void RecipientNameLb_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FilterContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BookContainer_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}