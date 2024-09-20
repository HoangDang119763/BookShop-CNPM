using BookShop_CNPM.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop_CNPM.GUI.UserControls
{
	public partial class ImportBookControl : UserControl
	{
		public bool check = false;
		int soLuong1 = 0;
        private decimal Price = 0;
        public ImportBookControl()
		{
			InitializeComponent();
		}
		
		public void details(BookDTO book,int soLuong,int soLuongDoiTra, decimal donGia)
		{
            try
            {
				using (var stream = new System.IO.MemoryStream(book.HinhAnh))
				{
					Bitmap bitmap = new Bitmap(stream);
					BookImage.Image = bitmap;
				}
			}
			catch (Exception ex)
			{
				BookImage.Image = BookImage.ErrorImage;
			}
            IdLb.Text = book.MaSach.ToString();
			NameLb.Text = book.TenSach;
			soLuong1 = soLuong - soLuongDoiTra;
            if (soLuong1 == soLuong)
			{
                StockLb.Text = "SL: " + soLuong;
                PriceLb.Text = string.Format("{0:N0} VND", donGia);
                toolTip1.SetToolTip(NameLb, NameLb.Text);
				Price = donGia;

            }
			else
			{
				if((soLuong - soLuongDoiTra) >= 0)
				{
                   
                    StockLb.Text = "SL: " + (soLuong - soLuongDoiTra);
                }
                else
				{
                    StockLb.Text = "SL: " + 0;
                }
                PriceLb.Text = string.Format("{0:N0} VND", donGia);
                Price = donGia;
                toolTip1.SetToolTip(NameLb, NameLb.Text);
                label1.Text = soLuong.ToString();
                label1.Visible = true;
            }
		}
		private void ImportBookControl_Click(object sender, EventArgs e)
		{
			CheckStatus();
		}

		private void CheckStatus()
		{
			this.check = true;
		}
		public void UncheckStatus()
		{
			this.check = false;
		}
		public bool getCheckStatus()
		{
			return this.check;
		}

		public int getId()
		{
			return Convert.ToInt32(IdLb.Text);	
		}
        public decimal getPrice()
        {
			return Price;
        }
        public int getSoLuong()
        {
            return soLuong1;
        }
    }
}
