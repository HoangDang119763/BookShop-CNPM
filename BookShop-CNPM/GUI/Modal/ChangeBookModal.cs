using BookShop_CNPM.BUS;
using BookShop_CNPM.DAO;
using BookShop_CNPM.DTO;
using BookShop_CNPM.GUI.UserControls;
using BookShop_CNPM.GUI.Vendor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace BookShop_CNPM.GUI.Modal
{
    public partial class ChangeBookModal : Form
    {
        public static Action<string,int> OnChangeBook;
        public int priceBook = 0;
        public int index = 0;
        public int mode = 0;
        public int id = 0;
        public decimal price = 0;


        public ChangeBookModal(int mode=0)
        {
            InitializeComponent();
            this.mode = mode;
        }

        private void BookInput_TextChanged(object sender, EventArgs e)
        {
            try
            {
                timer1.Start();
                if (BookInput.Text != "")
                {
                    List<BookDTO> Booklist = BookBUS.Instance.getBookList(this.BookInput.Text);

                    if (Booklist != null)
                    {
                        this.loadDataToBook(Booklist);
                    }
                    else
                    {
                        BookContainer.Controls.Clear();
                    }
                }
                else 
                {
                    BookContainer.Controls.Clear();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void loadDataToBook(List<BookDTO> Booklist)
        {
            try
            {
                BookContainer.Controls.Clear();
                if (Booklist != null)
                {
                    foreach (BookDTO bookDTO in Booklist)
                    {
                        BookDTO book = BookBUS.Instance.getById(bookDTO.MaSach.ToString());
                        BookUserControl control = new BookUserControl(mode);
                        control.details(book);
                        this.BookContainer.Controls.Add(control);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            BookUserControl lastControl = (BookUserControl)bookChange.Controls[0];
            if (lastControl.getId()!=id)
            {
                if (price == lastControl.GetPrice())
                {
                    ChangeBookModal.OnChangeBook(lastControl.getId().ToString(), index);
                    this.Close();
                }
                else
                {
                    MessageBox.Show($"Hãy chọn sản phẩm đổi cùng giá ({price})");
                    BookInput.Clear();
                    bookChange.Controls.Clear();
                }
            }
            else
            {
                ChangeBookModal.OnChangeBook(lastControl.getId().ToString(), index);
                this.Close();
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            List<ImportBillDetailDTO> listImportBillDetail = new List<ImportBillDetailDTO>();
                if (this.BookContainer.Controls.Count > 0)
                {
                    foreach (BookUserControl control in BookContainer.Controls)
                    {
                        if (control.check)
                        {
                            BookDTO book = BookBUS.Instance.getById(control.getId().ToString());
                            ImportBillDetailDTO importBillDetail = new ImportBillDetailDTO(0, book.MaSach, 0, 0);
                            listImportBillDetail.Add(importBillDetail);
                        }
                    }
                }
            loadDataToBookList2(listImportBillDetail);
        }
        private void loadDataToBookList2(List<ImportBillDetailDTO> list)
        {
            if (list == null) return;
              
            try
            {
                if (list.Count > 0)
                {
                    if (bookChange.Controls.Count > 0)
                    {
                        bookChange.Controls.Clear();
                    }
                    foreach (var item in list)
                    {
                        BookDTO book = BookBUS.Instance.getById(item.MaSach.ToString());
                        if (book.SoLuongConLai <= 0 && mode == 0)
                        {
                            timer1.Stop();
                            MessageBox.Show($"Sản phẩm đã hết hàng");
                            BookInput.Clear();
                            BookContainer.Controls.Clear();
                            return;
                        }
                        BookUserControl control = new BookUserControl(mode);
                        control.details(book);
                        this.bookChange.Controls.Add(control);
                    }
                    BookInput.Clear();
                    BookContainer.Controls.Clear();
                    timer1.Stop();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
