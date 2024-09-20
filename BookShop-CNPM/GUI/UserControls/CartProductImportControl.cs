using BookShop_CNPM.BUS;
using BookShop_CNPM.DTO;
using BookShop_CNPM.GUI.Modal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing.QrCode.Internal;
using static Guna.UI2.Native.WinApi;
using static ZXing.QrCode.Internal.Mode;

namespace BookShop_CNPM.GUI.UserControls
{
    public partial class CartProductImportControl : UserControl
    {
        //public static Action<string> OnDeleteBook;
        public static Action<string> OnDeleteRefundBook;
        public static Action OnChange;
        private int stock = 0;
        private int mode = 0; // 0: Vendor; 1: Import
        public static bool AmountChanged = false;
        public static string AmountChangedId = "";
        private int Amount = 1;
        private int Price = 0;
        private int id = 0;
        private decimal gia2=0;

        public CartProductImportControl(int mode)
        {
            InitializeComponent();
            this.mode = mode;
        }

        public void details(BookDTO book,int soLuong,decimal gia=0,int id1=0)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(book.HinhAnh))
                {
                    Image image = Image.FromStream(ms);
                    BookImage.Image = image;
                }
            }
			catch (Exception ex)
			{
				BookImage.Image = BookImage.ErrorImage;
			}

			if (mode == 0)
                {
                    StockLb.Text = "SL: " + book.SoLuongConLai;
                    stock = book.SoLuongConLai;
                    PriceLb.Text = string.Format("{0:N0} đ", book.GiaBan);
                    Price = Convert.ToInt32(book.GiaBan);
                }
                else
                {
                    StockLb.Text = "SL: " + book.SoLuongConLai;
                    PriceLb.Text = string.Format("{0:N0} đ", book.GiaNhap);
                    Price = Convert.ToInt32(book.GiaNhap);
                }
                soluong.Text = soLuong.ToString();
                IdLb.Text = book.MaSach.ToString();
                NameLb.Text = book.TenSach;
                gia2 = gia;
                id = id1;
                toolTip1.SetToolTip(NameLb, NameLb.Text);
        }

        public void ChangeAmountBook(int soluongcandoi)
        {
            soluong.Text = soluongcandoi.ToString();
        }

        private void PlusBtn_Click(object sender, EventArgs e)
        {
            if (mode == 0)
            {
                if (Convert.ToInt32(AmountTxt.Text) < stock)
                {
                    if (Convert.ToInt32(AmountTxt.Text) < Convert.ToInt32(soluong.Text))
                    {

                        AmountTxt.Text = (int.Parse(AmountTxt.Text) + 1).ToString();
                        CartProductImportControl.OnChange();
                        ChangeAmount();
                    }
                    else
                    {
                        MessageBox.Show("Không thể đổi quá số lượng sách cần đổi");
                    }
                }
                else
                {
                    MessageBox.Show("Không thể đổi quá số lượng sách còn lại");
                }
            }
            else
            {
                if (Convert.ToInt32(AmountTxt.Text) < Convert.ToInt32(soluong.Text))
                {
                    AmountTxt.Text = (int.Parse(AmountTxt.Text) + 1).ToString();
                    CartProductImportControl.OnChange();
                    ChangeAmount();
                }
                else
                {
                    MessageBox.Show("Không thể đổi quá số lượng sách cần đổi");
                }
            }
        }

        private void MinusBtn_Click(object sender, EventArgs e)
        {
            if (!AmountTxt.Text.Equals("1"))
            {
                AmountTxt.Text = (int.Parse(AmountTxt.Text) - 1).ToString();
                ChangeAmount();
            }
        }

        private void AmountTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                NameLb.Focus();
                return;
            }

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancel the key press event
            }
        }

        private void AmountTxt_MouseLeave(object sender, EventArgs e)
        {
            NameLb.Focus();
        }

        private void AmountTxt_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(AmountTxt.Text) || Convert.ToInt32(AmountTxt.Text)==0)
            {
                AmountTxt.Text = "1";
                return;
            }
            if (mode == 0)
            {
                if (Convert.ToInt32(AmountTxt.Text) > stock)
                {
                    MessageBox.Show("Không thể đổi quá số lượng sách còn lại");
                    AmountTxt.Text = Amount.ToString();
                }
                else
                {
                    if (Convert.ToInt32(AmountTxt.Text) > Convert.ToInt32(soluong.Text))
                    {
                        MessageBox.Show("Không thể đổi quá số lượng sách cần đổi");
                        AmountTxt.Text = Amount.ToString();

                    }
                    else
                    {
                        Amount = Convert.ToInt32(AmountTxt.Text);
                        ChangeAmount();
                    }
                }
            }
            else
            {
                if (Convert.ToInt32(AmountTxt.Text) > Convert.ToInt32(soluong.Text))
                {
                    MessageBox.Show("Không thể đổi quá số lượng sách cần đổi");
                    AmountTxt.Text = Amount.ToString();
                }
                else
                {
                    Amount = Convert.ToInt32(AmountTxt.Text);
                    ChangeAmount();
                }
            }
            
        }

        private void ChangeAmount()
        {
            AmountChanged = true;
            AmountChangedId = IdLb.Text;
        }

        /*private void DeleteBtn_Click(object sender, EventArgs e)
        {
            CartProductImportControl.OnDeleteBook(this.IdLb.Text);
        }*/

        public int getId()
        {
            return Convert.ToInt32(IdLb.Text);
        }

        public int GetBookAmount()
        {
            return Convert.ToInt32(this.AmountTxt.Text);
        }

        public String GetBookName()
        {
            return this.NameLb.Text;
        }
        public void setIndex(int i)
        {
            index.Text=i.ToString();
        }
        public int GetIndex() 
        { 
            return  Convert.ToInt32(this.index.Text);
        }

        public int GetPrice()
        {
            return Price;
        }
        public decimal GetGia()
        {
            return gia2;
        }

        public int Getid1()
        {
            return id;
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            using (ChangeBookModal AuthorModal = new ChangeBookModal(mode))
            {
                AuthorModal.priceBook = GetPrice();
                AuthorModal.index = GetIndex();
                AuthorModal.price = GetGia();
                AuthorModal.id= Getid1();
                AuthorModal.ShowDialog();
            }
        }
    }
}
