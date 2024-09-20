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
using BookShop_CNPM.BUS;
using BookShop_CNPM.DTO;

namespace BookShop_CNPM.GUI.UserControls
{
    public partial class BookBill : UserControl
    {
        public BookBill()
        {
            InitializeComponent();
        }

        public void addData(int maSach, int soLuong, decimal donGia)
        {
            BookDTO book = BookBUS.Instance.getById(maSach.ToString());
            Image img;
			try
            {
			    MemoryStream ms = new MemoryStream(book.HinhAnh);
                img = Image.FromStream(ms);
            }
			catch (Exception ex)
			{
				img = pictureBook.ErrorImage;
			}

            this.id.Text = "Mã : " + maSach;
            if (book.TenSach.Length > 26)
            {
                string truncatedString = book.TenSach.Substring(0, 26 - 3) + " ...";
                this.name.Text = truncatedString;
            }
            else
            {
                this.name.Text = book.TenSach;
            }
            this.amountInput.Text = soLuong.ToString();
            this.price.Text = string.Format("{0:N0} VND", donGia);
            this.pictureBook.Image = img;

            if (soLuong == 1)
            {
                this.minus.Enabled = false;
            }
        }
    }
}
