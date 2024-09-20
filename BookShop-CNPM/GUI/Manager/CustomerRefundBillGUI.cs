using BookShop_CNPM.BUS;
using BookShop_CNPM.DTO;
using BookShop_CNPM.GUI.Modal;
using BookShop_CNPM.GUI.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop_CNPM.GUI.Manager
{
	public partial class CustomerRefundBillGUI : Form
	{
		public CustomerRefundBillGUI()
		{
			InitializeComponent();
			dgvImportRefund.StandardTab = true;
		}
		
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void CustomerRefundBillGUI_FormClosed(object sender, FormClosedEventArgs e)
		{
		}
		private void loadDataToDGV(List<CustomerRefundBillDTO> customerRefundBills)
		{
			try
			{
				this.dgvImportRefund.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 210, 192);
				this.dgvImportRefund.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

				this.dgvImportRefund.Rows.Clear();
				if (customerRefundBills != null)
				{
					foreach (var customerRefundBill in customerRefundBills)
					{
						CustomerBillDTO customerBillDTO = CustomerBillBUS.Instance.getById(customerRefundBill.MaDonKhachHang.ToString());
						dgvImportRefund.Rows.Add(new object[]
						{
							customerRefundBill.MaPhieu,
							customerRefundBill.MaDonKhachHang,
							StaffBUS.Instance.getById(customerRefundBill.MaNhanVien.ToString()).Ten,
							customerRefundBill.LiDo,
                            string.Format("{0:N0} VNĐ", customerRefundBill.TongTien),
							customerRefundBill.NgayLap
						});
					}
				}
			}
			catch { 
			}
			
		}
		private void CustomerRefundBillGUI_Load(object sender, EventArgs e)
		{
			try
			{
                this.fromPriceTxt.Enabled = this.gunaMediumCheckBox1.Checked;
                this.toPriceTxt.Enabled = this.gunaMediumCheckBox1.Checked;
				this.dateTimeFrom.Enabled = this.filterCkx.Checked;
				this.dateTimeTo.Enabled = this.filterCkx.Checked;
				List<CustomerRefundBillDTO> customerRefundBills = CustomerRefundBillBUS.Instance.getAllData();
				loadDataToDGV(customerRefundBills);
                this.loadStaffCbx();
            }
			catch
			{

			}
		}

		private void filterCkx_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				this.dateTimeFrom.Enabled = this.filterCkx.Checked;
				this.dateTimeTo.Enabled = this.filterCkx.Checked;

				var customerRefundBills = handleFilter(this.searchInput.Text);
				loadDataToDGV(customerRefundBills);

			}
			catch { 
			}	
		}

        private void loadStaffCbx()
        {
            try
            {
                List<StaffDTO> staffList = StaffBUS.Instance.getAllData();

                staffList.Insert(0, new StaffDTO(0, "Tất cả nhân viên", "", "", 0, 0, 0));

                this.staffCbx.ValueMember = "Ma";
                this.staffCbx.DisplayMember = "Ten";
                this.staffCbx.DataSource = staffList;

                this.staffCbx.SelectedIndex = 0;
            }
            catch (Exception er)
            {

                Console.WriteLine(er);
            }
        }

        private List<CustomerRefundBillDTO> handleFilter(string text)
		{
			try
			{
                List<CustomerRefundBillDTO> customerRefundBills = CustomerRefundBillBUS.Instance.search(text);
                if (this.fromPriceTxt.Text.ToString() != string.Empty
                    && this.toPriceTxt.Text.ToString() != string.Empty && this.gunaMediumCheckBox1.Checked)
                {
                    Regex isNum = new Regex(@"^\d+$");

                    if (!isNum.IsMatch(this.fromPriceTxt.Text.ToString()) || !isNum.IsMatch(this.toPriceTxt.Text.ToString()))
                    {
                        this.fromPriceTxt.Clear();
                        this.toPriceTxt.Clear();
                        MessageBox.Show("Tổng tiền là một số dương");
                    }
                    else
                    {
                        if (Convert.ToDecimal(this.fromPriceTxt.Text.ToString()) > Convert.ToDecimal(this.toPriceTxt.Text.ToString()))
                        {
                            MessageBox.Show("Tổng tiền đến phải bé hơn hoặc bằng tổng tiền từ");
                        }
                        else
                        {
                            customerRefundBills = customerRefundBills.FindAll(
                                item => item.TongTien >= Convert.ToDecimal(this.fromPriceTxt.Text.ToString())
                                        && item.TongTien <= Convert.ToDecimal(this.toPriceTxt.Text.ToString()
                            ));
                        }
                    }
                }
                if (DateTime.Compare(dateTimeTo.Value, dateTimeFrom.Value) >= 0 && filterCkx.Checked)
				{
					try
					{
						customerRefundBills = customerRefundBills.Where(item =>

							 DateTime.Compare(item.NgayLap, dateTimeFrom.Value) >= 0 &&
							 DateTime.Compare(item.NgayLap, dateTimeTo.Value) <= 0
						).ToList();
					}
					catch
					{
						MessageBox.Show("Lọc theo khoảng thời gian không hợp lệ");
					}
				}
                int staffId = Convert.ToInt32(this.staffCbx.SelectedValue);

                List<CustomerRefundBillDTO> newCustomerRefundBillList = customerRefundBills.FindAll(customerRefundBill =>
                {
                    if (staffId != 0)
                    {
                        return customerRefundBill.MaNhanVien == staffId;
                    }

                    return true;
                });
                return newCustomerRefundBillList;
            }
			catch
			{
                return new List<CustomerRefundBillDTO>();
            }
		}

		private void dateTimeFrom_ValueChanged(object sender, EventArgs e)
		{
			try
			{
				bool validateTimeTo = DateTime.Compare(dateTimeTo.Value, dateTimeFrom.Value) >= 0;
				if (!validateTimeTo)
				{

					MessageBox.Show("Bạn không thể chọn ngày nhỏ hơn ngày " + dateTimeFrom.Value.GetDateTimeFormats()[0]);
					dateTimeTo.Value = dateTimeFrom.Value;
					return;
				}
				List<CustomerRefundBillDTO> customerRefundBills = this.handleFilter(this.searchInput.Text);
				loadDataToDGV(customerRefundBills);
			}
			catch 
			{
			}	
			
		}

		private void dateTimeTo_ValueChanged(object sender, EventArgs e)
		{
			try
			{
				bool validateFromTo = DateTime.Compare(dateTimeFrom.Value, dateTimeTo.Value) <= 0;
				if (!validateFromTo)
				{

					MessageBox.Show("Bạn không thể chọn ngày lớn hơn ngày " + dateTimeTo.Value.GetDateTimeFormats()[0]);
					dateTimeFrom.Value = dateTimeTo.Value;
					return;
				}
				List<CustomerRefundBillDTO> customerRefundBills = this.handleFilter(this.searchInput.Text);
				loadDataToDGV(customerRefundBills);
			}
			catch
			{

			}
			
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			try
			{
                this.fromPriceTxt.Enabled = this.gunaMediumCheckBox1.Checked;
                this.toPriceTxt.Enabled = this.gunaMediumCheckBox1.Checked;
                this.searchInput.Clear();
                this.gunaMediumCheckBox1.Checked = false;
                this.filterCkx.Checked = false;
                this.fromPriceTxt.Clear();
                this.toPriceTxt.Clear();
                this.fromPriceTxt.Enabled = false;
                this.toPriceTxt.Enabled = false;
                this.staffCbx.SelectedIndex = 0;
                List<CustomerRefundBillDTO> customerRefundBills = CustomerRefundBillBUS.Instance.getAllData();
				loadDataToDGV(customerRefundBills);
			}
			catch
			{

			}
			
		}

		private void addBtn_Click(object sender, EventArgs e)
		{
			try
			{
				using (var modal = new CustomerRefundBillModal(ManagerGUI.currentStaff.Ma))
				{
					modal.ShowDialog();
					if (modal.isSubmitSuccess)
					{
						List<CustomerRefundBillDTO> customerRefundBills = this.handleFilter(this.searchInput.Text);
						loadDataToDGV(customerRefundBills);
					}
				}
			}
			catch
			{

			}
			
		}

		private void detailsBtn_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.dgvImportRefund.CurrentCell == null)
				{
                    MessageBox.Show("Bảng dữ liệu có thể chưa có dòng dữ liệu nào để xem chi tiết");
					return;
                }
                if (this.dgvImportRefund.CurrentCell.RowIndex < 0)
				{
					MessageBox.Show("Hãy chọn phiếu trả muốn xem");
					return;
				}
				using (var modal = new CustomerRefundBillModal(ManagerGUI.currentStaff.Ma, "Xem chi tiết phiếu trả bán hàng"))
				{
					DataGridViewRow selectedRow = dgvImportRefund.Rows[dgvImportRefund.CurrentCell.RowIndex];
					CustomerRefundBillDTO customerRefundBill = CustomerRefundBillBUS.Instance.getById(selectedRow.Cells[0].Value.ToString());
					modal.customerRefundBill = customerRefundBill;
					modal.ShowDialog();
				}
			}
			catch 
			{ }
			
		}

		private void deleteBtn_Click(object sender, EventArgs e)
		{
			try
			{
				DialogResult deleteDialogResult = MessageBox.Show(
					"Bạn có chắc chắn muốn xóa các phiếu đã chọn",
					"Xác nhận",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.None
				);
				if (deleteDialogResult == DialogResult.Yes)
				{
					foreach (DataGridViewRow row in dgvImportRefund.Rows)
					{
						if ((bool)row.Cells[0].Value)
						{
							try
							{
								CustomerRefundBillBUS.Instance.delete(row.Cells[0].Value.ToString());
							}
							catch (Exception ex)
							{
								Console.WriteLine(ex.Message);
							}
						}
					}
					List<CustomerRefundBillDTO> customerRefundBills = this.handleFilter(this.searchInput.Text);
					loadDataToDGV(customerRefundBills);

				}
			}
			catch
			{

			}
			
		}

		private void closeBtn_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvImportRefund.Rows.Count <= 0)
            {
                MessageBox.Show("Bảng dữ liệu hiện tại chưa có dòng dữ liệu nào để xuất excel!");
                return;
            }

            try
            {
                string[] headerList = new string[] { "Mã phiếu", "Mã hóa đơn", "Nhân viên lập", "Lý do", "Tổng tiền", "Ngày lập" };
                DataTable dt = CustomExcel.Instance.ConvertDataGridViewToDataTable(dgvImportRefund);

                CustomExcel.Instance.ExportFileDatagridView(dt, "Book Manage", 0, "Cửa hàng bán sách", headerList);
            }
            catch (Exception er)
            {

                Console.WriteLine(er);
            }
        }

        private void dgvImportRefund_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dgvImportRefund.CurrentCell.RowIndex < 0)
                {
                    MessageBox.Show("Hãy chọn phiếu trả muốn xem");
                    return;
                }
                using (var modal = new CustomerRefundBillModal(ManagerGUI.currentStaff.Ma,"Xem chi tiết phiếu trả bán hàng"))
                {
                    DataGridViewRow selectedRow = dgvImportRefund.Rows[dgvImportRefund.CurrentCell.RowIndex];
                    CustomerRefundBillDTO customerRefundBill = CustomerRefundBillBUS.Instance.getById(selectedRow.Cells[0].Value.ToString());
                    modal.customerRefundBill = customerRefundBill;
                    modal.ShowDialog();
                }
            }
            catch
            { }
        }

        private void dgvImportRefund_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Index == 4) // Check if sorting the last column
            {
                // Extract the values for sorting from the cell values
                double value1 = GetSortingValue(e.CellValue1);
                double value2 = GetSortingValue(e.CellValue2);

                // Compare the extracted values
                e.SortResult = value1.CompareTo(value2);

                // Mark the comparison as handled to prevent default sorting
                e.Handled = true;
            }
        }

        private double GetSortingValue(object cellValue)
        {
            if (cellValue == null)
                return 0;

            // Extract the numerical value from the string (remove " VNĐ" and parse)
            string stringValue = cellValue.ToString();
            stringValue = stringValue.Replace(".", "").Replace(" VNĐ", "");

            if (double.TryParse(stringValue, out double numericValue))
            {
                // Convert the numeric value to a sortable string
                return numericValue;
            }

            return 0;
        }

        private void staffCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                List<CustomerRefundBillDTO> customerChangeBillList = handleFilter(this.searchInput.Text.ToString());

                this.loadDataToDGV(customerChangeBillList);
            }
            catch (Exception er)
            {

                Console.WriteLine(er);
            }
        }

        private void printPdfBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvImportRefund.CurrentCell == null)
                {
                    MessageBox.Show("Bảng dữ liệu có thể chưa có dòng dữ liệu nào để xem chi tiết");
                    return;
                }
                if (this.dgvImportRefund.CurrentCell.RowIndex < 0 || this.dgvImportRefund.CurrentCell == null)
                {
                    MessageBox.Show("Hãy chọn dòng dữ liệu muốn thao tác");
                    return;
                }

                DataGridViewRow row = this.dgvImportRefund.Rows[this.dgvImportRefund.CurrentCell.RowIndex];

                using (CustomerRefundBillPrintForm customerChangeBillPrintForm = new CustomerRefundBillPrintForm(Convert.ToInt32(row.Cells[0].Value)))
                {

                    customerChangeBillPrintForm.ShowDialog();

                }
            }
            catch (Exception er)
            {

                Console.WriteLine(er);
            }
        }

        private void gunaMediumCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.fromPriceTxt.Enabled = this.gunaMediumCheckBox1.Checked;
            this.toPriceTxt.Enabled = this.gunaMediumCheckBox1.Checked;
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
                    List<CustomerRefundBillDTO> customerBillList = handleFilter(this.searchInput.Text);

                    this.loadDataToDGV(customerBillList);
                }
            }
        }

        private void searchInput_TextChanged(object sender, EventArgs e)
        {
            List<CustomerRefundBillDTO> customerBillList = handleFilter(this.searchInput.Text);

            this.loadDataToDGV(customerBillList);
        }
    }
}
