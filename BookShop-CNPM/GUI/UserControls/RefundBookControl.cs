using BookShop_CNPM.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop_CNPM.GUI.UserControls
{
	public partial class RefundBookControl : UserControl
	{
		public static Action OnChangeRefundBookAmount;
		public static Action<string> OnDeleteRefundBook;
		private int stock = 100;
		private int Amount = 1;

		public RefundBookControl()
		{
			InitializeComponent();
		}
		public void details(BookDTO book, int stock, decimal donGia)
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
			IdLb.Text = book.MaSach.ToString();
			NameLb.Text = book.TenSach;
			StockLb.Text = stock.ToString();
			PriceLb.Text = string.Format("{0:N0} đ", donGia);
			toolTip1.SetToolTip(NameLb, NameLb.Text);

		}
		public bool checkValidStock()
		{
			return GetBookAmount() <= Convert.ToInt32(StockLb.Text);
		}
		public int getId()
		{
			return Convert.ToInt32(IdLb.Text);
		}
		public double getPrice()
		{
			return Convert.ToDouble(PriceLb.Text.Split(' ')[0]);
		}
		private void PlusBtn_Click(object sender, EventArgs e)
		{
			if (Convert.ToInt32(AmountTxt.Text) < stock)
			{
				AmountTxt.Text = (int.Parse(AmountTxt.Text) + 1).ToString();
				Amount = (int.Parse(AmountTxt.Text));
				ChangeAmount();
			}
			else
			{
				MessageBox.Show("Không thể đổi quá số lượng sách đã đặt");
				AmountTxt.Text = stock.ToString();
			}
		}

		private void ChangeAmount()
		{
			if (checkValidStock())
			{
				RefundBookControl.OnChangeRefundBookAmount();
			}
			else
			{
				MessageBox.Show("Không thể trả quá số lượng sách đã đặt");
				AmountTxt.Text = (int.Parse(StockLb.Text)).ToString();
			}
		}
		public int GetBookAmount()
		{
			return Convert.ToInt32(this.AmountTxt.Text);
		}

		private void MinusBtn_Click(object sender, EventArgs e)
		{
			if (!AmountTxt.Text.Equals("1"))
			{
				AmountTxt.Text = (int.Parse(AmountTxt.Text) - 1).ToString();
				ChangeAmount();
			}
		}

		private void DeleteBtn_Click(object sender, EventArgs e)
		{
			RefundBookControl.OnDeleteRefundBook(this.IdLb.Text);
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
			if (String.IsNullOrEmpty(AmountTxt.Text) || Convert.ToInt32(AmountTxt.Text) <= 0)

			{
				AmountTxt.Text = "1";
			}
			if (int.Parse(AmountTxt.Text) > stock)
			{
				MessageBox.Show("Không thể trả quá số lượng sách đã đặt");
				AmountTxt.Text = Amount.ToString();
			}
			else
			{
				Amount = Convert.ToInt32(AmountTxt.Text);
				ChangeAmount();
			}
		}
	}
}