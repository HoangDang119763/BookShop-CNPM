﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookShop_CNPM.BUS;
using BookShop_CNPM.DTO;

namespace BookShop_CNPM.GUI.Modal
{
    public partial class AddBookToImportBillModal : Form
    {
        public bool isSaved = false;
        private CheckBox headerCheckbox;
        private CheckBox headerCheckboxBillList;
        private List<BookDTO> bookList = BookBUS.Instance.getAllData();

        public List<ImportBillDetailDTO> selectedImportBillDetailList = new List<ImportBillDetailDTO>();
        public List<ImportBillDetailDTO> prevSelectedImportBillDetailList = new List<ImportBillDetailDTO>();

        public AddBookToImportBillModal(List<ImportBillDetailDTO> importBillDetailList)
        {
            InitializeComponent();

            this.selectedImportBillDetailList.Clear();
            this.selectedImportBillDetailList = importBillDetailList.GetRange(0, importBillDetailList.Count);
            this.prevSelectedImportBillDetailList = importBillDetailList.GetRange(0, importBillDetailList.Count);
        }

        private void renderCheckBoxDgvBook()
        {
            try
            {
                int size = 25;

                Rectangle rect = this.dgvBook.GetCellDisplayRectangle(0, -1, false);

                headerCheckbox = new CheckBox();

                headerCheckbox.BackColor = Color.FromArgb(45, 210, 192);
                headerCheckbox.Name = "chkHeader";
                headerCheckbox.Size = new Size(size, size);

                rect.X = (rect.Width / 2) - (size / 4);
                rect.Y = (rect.Height / 2) - (size / 2);

                headerCheckbox.Location = rect.Location;

                this.dgvBook.Controls.Add(headerCheckbox);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void renderCheckBoxDgvBookBillList()
        {
            try
            {
                int size = 25;

                Rectangle rect = this.dgvBook.GetCellDisplayRectangle(0, -1, false);

                headerCheckboxBillList = new CheckBox();

                headerCheckboxBillList.BackColor = Color.FromArgb(45, 210, 192);
                headerCheckboxBillList.Name = "chkHeader";
                headerCheckboxBillList.Size = new Size(size, size);

                rect.X = (rect.Width / 2) - (size / 4);
                rect.Y = (rect.Height / 2) - (size / 2);

                headerCheckboxBillList.Location = rect.Location;

                this.dgvAddBookToBillList.Controls.Add(headerCheckboxBillList);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void loadNewBookListToDataView(string searchText)
        {
            try
            {
                this.dgvBook.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 210, 192);
                this.dgvBook.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

                this.dgvBook.Rows.Clear();

                List<BookDTO> filterBookList = handleFilter(searchText);

                foreach (BookDTO book in filterBookList)
                {
                    ImportBillDetailDTO importBillDetail = selectedImportBillDetailList.Find(b => b.MaSach == book.MaSach);

                    if (importBillDetail == null)
                    {
                        this.dgvBook.Rows.Add(new object[] {
                            false,
                            book.MaSach,
                            book.TenSach,
                            book.HinhAnh,
                            book.GiaNhap,
                            book.SoLuongConLai,
                        });
                    }
                    else
                    {
                        Console.WriteLine(book.SoLuongConLai + importBillDetail.SoLuong);
                        this.dgvBook.Rows.Add(new object[] {
                            false,
                            book.MaSach,
                            book.TenSach,
                            book.HinhAnh,
                            book.GiaNhap,
                            book.SoLuongConLai + importBillDetail.SoLuong,
                        });
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void loadAddBookBillListToDataView()
        {
            try
            {
                this.dgvAddBookToBillList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 210, 192);
                this.dgvAddBookToBillList.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

                this.dgvAddBookToBillList.Rows.Clear();

                foreach (ImportBillDetailDTO importBillDetail in this.selectedImportBillDetailList)
                {
                    this.dgvAddBookToBillList.Rows.Add(new object[] {
                        false,
                        importBillDetail.MaSach,
                        importBillDetail.SoLuong,
                        importBillDetail.DonGia,
                        importBillDetail.SoLuong * importBillDetail.DonGia,
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void loadAuthorCbx()
        {
            try
            {
                List<AuthorDTO> authorList = AuthorBUS.Instance.getAllData();

                authorList.Insert(0, new AuthorDTO(0, "Tất cả tác giả", "", 0));

                this.authorCbx.ValueMember = "Ma";
                this.authorCbx.DisplayMember = "Ten";
                this.authorCbx.DataSource = authorList;

                this.authorCbx.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void loadBookTypeCbx()
        {
            try
            {
                List<BookTypeDTO> bookTypeList = BookTypeBUS.Instance.getAllData();

                bookTypeList.Insert(0, new BookTypeDTO(0, "Tất cả thể loại"));

                this.bookTypeCbx.ValueMember = "MaTheLoai";
                this.bookTypeCbx.DisplayMember = "TenTheLoai";
                this.bookTypeCbx.DataSource = bookTypeList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void loadPublisherCbx()
        {
            try
            {
                List<PublisherDTO> publisherList = PublisherBUS.Instance.getAllData();

                publisherList.Insert(0, new PublisherDTO(0, "Tất cả nhà xuất bản", "", ""));

                this.publisherCbx.ValueMember = "MaNhaXuatBan";
                this.publisherCbx.DisplayMember = "TenNhaXuatBan";
                this.publisherCbx.DataSource = publisherList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void headerCheckbox_Clicked(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in this.dgvBook.Rows)
                {
                    row.Cells[0].Value = headerCheckbox.Checked;
                }

                this.dgvBook.RefreshEdit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void headerCheckboxBillList_Clicked(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in this.dgvAddBookToBillList.Rows)
                {
                    row.Cells[0].Value = headerCheckboxBillList.Checked;
                }

                this.dgvAddBookToBillList.RefreshEdit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private List<BookDTO> handleFilter(string searchText)
        {
            try
            {
                List<BookDTO> newBookList = this.bookList.FindAll(
                        (book) => book.TenSach.ToLower().Contains(searchText.ToLower()) || book.MaSach.ToString().ToLower().Contains(searchText.ToLower())
                    );

                if (this.priceFrom.Text.ToString() != string.Empty
                    && this.priceTo.Text.ToString() != string.Empty)
                {
                    Regex isNum = new Regex(@"^\d+$");

                    if (!isNum.IsMatch(this.priceFrom.Text.ToString()) || !isNum.IsMatch(this.priceFrom.Text.ToString()))
                    {
                        this.priceFrom.Clear();
                        this.priceTo.Clear();
                        MessageBox.Show("Giá là một số");
                    }
                    else
                    {

                        if (Convert.ToDecimal(this.priceFrom.Text.ToString()) > Convert.ToDecimal(this.priceTo.Text.ToString()))
                        {
                            MessageBox.Show("Giá nhập từ phải bé hơn hoặc bằng giá nhập đến");
                            this.priceFrom.Clear();
                            this.priceTo.Clear();
                        }
                        else
                        {
                            newBookList = newBookList.FindAll(
                                item => item.GiaNhap >= Convert.ToDecimal(this.priceFrom.Text.ToString())
                                        && item.GiaNhap <= Convert.ToDecimal(this.priceTo.Text.ToString()
                            ));
                        }
                        
                    }
                }

                int authorId = Convert.ToInt32(this.authorCbx.SelectedValue);
                int bookTypeId = Convert.ToInt32(this.bookTypeCbx.SelectedValue);
                int publisherId = Convert.ToInt32(this.publisherCbx.SelectedValue);

                List<BookDTO> filterBookList = newBookList.FindAll(book =>
                {
                    if (authorId != 0 && bookTypeId != 0 && publisherId != 0)
                    {
                        return book.MaTacGia == authorId &&
                               book.MaTheLoai == bookTypeId &&
                               book.MaNhaXuatBan == publisherId;
                    }

                    if (authorId == 0 && bookTypeId != 0 && publisherId != 0)
                    {
                        return book.MaTheLoai == bookTypeId &&
                               book.MaNhaXuatBan == publisherId;
                    }

                    if (authorId == 0 && bookTypeId == 0 && publisherId != 0)
                    {
                        return book.MaNhaXuatBan == publisherId;
                    }

                    if (authorId == 0 && bookTypeId != 0 && publisherId == 0)
                    {
                        return book.MaTheLoai == bookTypeId;
                    }

                    if (authorId != 0 && bookTypeId == 0 && publisherId == 0)
                    {
                        return book.MaTacGia == authorId;
                    }

                    if (authorId != 0 && bookTypeId != 0 && publisherId == 0)
                    {
                        return book.MaTacGia == authorId &&
                               book.MaTheLoai == bookTypeId;
                    }

                    if (authorId != 0 && bookTypeId == 0 && publisherId != 0)
                    {
                        return book.MaTacGia == authorId &&
                               book.MaNhaXuatBan == publisherId;
                    }

                    return true;
                });


                return filterBookList;
            }
            catch (Exception)
            {
                return new List<BookDTO>();
            }
        }

        private void searchInput_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.loadNewBookListToDataView(this.searchInput.Text.Trim());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void authorCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.loadNewBookListToDataView(this.searchInput.Text.Trim());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void bookTypeCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.loadNewBookListToDataView(this.searchInput.Text.Trim());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void publisherCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.loadNewBookListToDataView(this.searchInput.Text.Trim());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void priceTo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.loadNewBookListToDataView(this.searchInput.Text.Trim());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void priceFrom_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.loadNewBookListToDataView(this.searchInput.Text.Trim());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.searchInput.Clear();

                this.priceFrom.Clear();
                this.priceTo.Clear();

                this.authorCbx.SelectedIndex = 0;
                this.bookTypeCbx.SelectedIndex = 0;
                this.publisherCbx.SelectedIndex = 0;

                this.loadNewBookListToDataView("");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void barcodeBtn_Click(object sender, EventArgs e)
        {
            using (ScannerModal scannerModal = new ScannerModal())
            {
                scannerModal.ShowDialog();

                if (scannerModal.scannedBook != null)
                {
                    try
                    {
                        int idx = this.selectedImportBillDetailList.FindIndex(
                                        book => book.MaSach == scannerModal.scannedBook.MaSach
                                    );

                        if (idx == -1)
                        {
                            ImportBillDetailDTO importBillDetail = new ImportBillDetailDTO(
                                0,
                                scannerModal.scannedBook.MaSach,
                                1,
                                scannerModal.scannedBook.GiaNhap
                            );

                            this.selectedImportBillDetailList.Add(importBillDetail);
                        }
                        else
                        {
                            ImportBillDetailDTO importBillDetail = new ImportBillDetailDTO(
                                0,
                                scannerModal.scannedBook.MaSach,
                                this.selectedImportBillDetailList[idx].SoLuong + 1,
                                scannerModal.scannedBook.GiaNhap
                            );

                            this.selectedImportBillDetailList[idx] = importBillDetail;
                        }

                        MessageBox.Show("Đã thêm sách có mã " + scannerModal.scannedBook.MaSach + " vào danh sách thêm");
                        this.loadAddBookBillListToDataView();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            }
        }

        private void addToProductList_Click(object sender, EventArgs e)
        {
            try
            {
                bool isHaveSelect = false;

                foreach (DataGridViewRow row in this.dgvBook.Rows)
                {
                    if ((bool)row.Cells[0].Value)
                    {
                        isHaveSelect = true;
                        break;
                    }
                }

                if (!isHaveSelect)
                {
                    MessageBox.Show("Bạn chưa chọn những sách cần thêm vào danh sách sản phẩm cả");
                    return;
                }

                DialogResult dlgResult = MessageBox.Show(
                    "Bạn chắc chắn muốn thêm các sách đã chọn vào danh sách sản phẩm chứ?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1
                );

                if (dlgResult == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in this.dgvBook.Rows)
                    {
                        if ((bool)row.Cells[0].Value == true)
                        {
                            int maSach = Convert.ToInt32(row.Cells[1].Value.ToString());
                            decimal giaNhap = Convert.ToDecimal(row.Cells[4].Value.ToString());

                            int idx = this.selectedImportBillDetailList.FindIndex(
                                book => book.MaSach == maSach
                            );

                            if (idx == -1)
                            {
                                ImportBillDetailDTO importBillDetail = new ImportBillDetailDTO(
                                    0,
                                    maSach,
                                    1,
                                    giaNhap
                                );

                                this.selectedImportBillDetailList.Add(importBillDetail);
                            }
                            else
                            {
                                ImportBillDetailDTO importBillDetail = new ImportBillDetailDTO(
                                    0,
                                    maSach,
                                    this.selectedImportBillDetailList[idx].SoLuong + 1,
                                    giaNhap
                                );

                                this.selectedImportBillDetailList[idx] = importBillDetail;
                            }
                        }
                    }

                    this.loadNewBookListToDataView((this.searchInput.Text.Trim()));
                    this.loadAddBookBillListToDataView();

                    headerCheckbox.Checked = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.isSaved = true;
            this.Close();
        }

        private void dgvAddBookToBillList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dgvAddBookToBillList.Columns[e.ColumnIndex].Name == "soLuong")
                {
                    BookDTO book = this.bookList.Find(
                        (b) => b.MaSach == Convert.ToInt32(this.dgvAddBookToBillList.Rows[e.RowIndex].Cells[1].Value)
                    );

                    Regex isNum = new Regex(@"^\d+$");

                    if (!isNum.IsMatch(this.dgvAddBookToBillList[e.ColumnIndex, e.RowIndex].Value.ToString()))
                    {
                        this.dgvAddBookToBillList[e.ColumnIndex, e.RowIndex].Value = this.selectedImportBillDetailList[e.RowIndex].SoLuong;
                        this.dgvAddBookToBillList.RefreshEdit();
                        MessageBox.Show("Số lượng là một số");
                        return;
                    }

                    int soLuong = Convert.ToInt32(this.dgvAddBookToBillList[e.ColumnIndex, e.RowIndex].Value);

                    if (soLuong <= 0)
                    {
                        this.dgvAddBookToBillList[e.ColumnIndex, e.RowIndex].Value = this.selectedImportBillDetailList[e.RowIndex].SoLuong;
                        this.dgvAddBookToBillList.RefreshEdit();
                        return;
                    }

                    int tmp = this.selectedImportBillDetailList[e.RowIndex].SoLuong;

                    this.selectedImportBillDetailList[e.RowIndex].SoLuong = soLuong;

                    this.dgvAddBookToBillList[4, e.RowIndex].Value = soLuong * Convert.ToDouble(this.dgvAddBookToBillList[3, e.RowIndex].Value);

                    this.loadNewBookListToDataView(this.searchInput.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }



        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                bool isHaveSelect = false;

                foreach (DataGridViewRow row in this.dgvAddBookToBillList.Rows)
                {
                    if ((bool)row.Cells[0].Value)
                    {
                        isHaveSelect = true;
                        break;
                    }
                }

                if (!isHaveSelect)
                {
                    MessageBox.Show("Bạn chưa chọn những sách cần xóa khỏi danh sách mua hàng");
                    return;
                }

                DialogResult dlgResult = MessageBox.Show(
                    "Bạn chắc chắn muốn xóa các sách đã chọn khỏi danh sách mua hàng chứ?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1
                );

                if (dlgResult == DialogResult.Yes)
                {
                    for (int i = dgvAddBookToBillList.Rows.Count - 1; i >= 0; i--)
                    {
                        DataGridViewRow row = dgvAddBookToBillList.Rows[i];

                        if ((bool)row.Cells[0].Value == true)
                        {
                            int idx = selectedImportBillDetailList.FindIndex(
                                book => book.MaSach == Convert.ToInt32(row.Cells[1].Value)
                            );

                            if (idx >= 0)
                            {
                                selectedImportBillDetailList.RemoveAt(idx);
                            }

                            dgvAddBookToBillList.Rows.RemoveAt(i);
                        }
                    }

                    this.loadNewBookListToDataView(this.searchInput.Text.Trim());

                    headerCheckbox.Checked = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void AddBookToImportBillModal_Load(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("123");
                this.loadNewBookListToDataView("");
                this.loadAddBookBillListToDataView();

                this.loadAuthorCbx();
                this.loadBookTypeCbx();
                this.loadPublisherCbx();
                this.renderCheckBoxDgvBook();
                headerCheckbox.MouseClick += new MouseEventHandler(headerCheckbox_Clicked);

                this.renderCheckBoxDgvBookBillList();
                headerCheckboxBillList.MouseClick += new MouseEventHandler(headerCheckboxBillList_Clicked);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            this.isSaved = true;
            this.Close();
        }

        private void AddBookToImportBillModal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isSaved)
            {
                this.selectedImportBillDetailList = prevSelectedImportBillDetailList;
            }
        }

        private readonly int debounceInterval = 500; // Đặt khoảng thời gian debounce là 500 milliseconds
        private DateTime lastTextChanged = DateTime.MinValue;
        private readonly object debounceLock = new object();

        private async void DebounceTextBox_TextChanged(object sender, EventArgs e)
        {
            lock (debounceLock)
            {
                lastTextChanged = DateTime.Now;
            }

            await Task.Delay(debounceInterval);

            lock (debounceLock)
            {
                var now = DateTime.Now;
                if ((now - lastTextChanged).TotalMilliseconds >= debounceInterval)
                {
                    this.loadNewBookListToDataView(this.searchInput.Text.Trim());
                }
            }
        }

        private void priceFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ngăn chặn ký tự nhập vào TextBox
            }
        }

        private void priceTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ngăn chặn ký tự nhập vào TextBox
            }
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = CustomExcel.Instance.ImportFile();

                if (dt == null)
                {
                    MessageBox.Show("Lỗi chưa chọn file hoặc file excel không đúng dữ liệu!");
                    return;
                }

                foreach (DataRow row in dt.Rows)
                {
                    if (!int.TryParse(row[0].ToString(), out int maSach) || !int.TryParse(row[2].ToString(), out int soLuong) || !decimal.TryParse(row[3].ToString(), out decimal giaNhap))
                    {
                        MessageBox.Show("Lỗi chưa chọn file hoặc file excel không đúng format dữ liệu nhập!");
                        return;
                    }
                }

                this.selectedImportBillDetailList.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    BookDTO newBook = BookBUS.Instance.getById(row[0].ToString());
                    int soLuong = Convert.ToInt32(row[2].ToString());
                    decimal giaNhap = Convert.ToDecimal(row[3].ToString());

                    if (newBook == null) continue;

                    try
                    {
                        ImportBillDetailDTO importBillDetail = new ImportBillDetailDTO(
                            0,
                            newBook.MaSach,
                            soLuong,
                            giaNhap
                        );

                        this.selectedImportBillDetailList.Add(importBillDetail);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }

                this.loadAddBookBillListToDataView();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
