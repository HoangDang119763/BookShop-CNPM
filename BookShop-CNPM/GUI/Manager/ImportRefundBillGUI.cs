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
	public partial class ImportRefundBillGUI : Form
	{
		public ImportRefundBillGUI()
		{
			InitializeComponent();
		}

		private void closeBtn_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void ImportRefundBillGUI_FormClosed(object sender, FormClosedEventArgs e)
		{

		}
		private void loadDataToDGV(List<ImportRefundBillDTO> importRefundBills)
		{
				this.dgvImportRefund.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 210, 192);
				this.dgvImportRefund.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

				this.dgvImportRefund.Rows.Clear();
			if (importRefundBills != null)
				{
					foreach(var importRefundBill in importRefundBills)
					{
					    ImportBillDTO importBillDTO = ImportBillBUS.Instance.getById(importRefundBill.MaDonNhapHang.ToString());
						dgvImportRefund.Rows.Add(new object[]
						{
							importRefundBill.MaPhieu,
							importRefundBill.MaDonNhapHang,
							StaffBUS.Instance.getById(importRefundBill.MaNhanVien.ToString()).Ten,
							importRefundBill.LiDo,
                            string.Format("{0:N0} VNĐ", importRefundBill.TongTien),
							importRefundBill.NgayLap,
						});
					}	
				}	
		}
		private void ImportRefundBillGUI_Load(object sender, EventArgs e)
		{
            this.fromPriceTxt.Enabled = this.gunaMediumCheckBox1.Checked;
            this.toPriceTxt.Enabled = this.gunaMediumCheckBox1.Checked;
			this.dateTimeFrom.Enabled = this.filterCkx.Checked;
			this.dateTimeTo.Enabled = this.filterCkx.Checked;
			List<ImportRefundBillDTO> importRefundBills = ImportRefundBillBUS.Instance.getAllData();
			loadDataToDGV(importRefundBills);
            this.loadStaffCbx();
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
								ImportRefundBillBUS.Instance.delete(row.Cells[0].Value.ToString());
							}
							catch (Exception ex)
							{
								Console.WriteLine(ex.Message);
							}
						}
					}
					List<ImportRefundBillDTO> importRefundBillDTOs = this.handleFilter(this.searchInput.Text);
					loadDataToDGV(importRefundBillDTOs);

				}
			}
			catch
			{

			}
		
			
		}

		private void addBtn_Click(object sender, EventArgs e)
		{
			try
			{
				using (var modal = new ImportRefundBillModal(ManagerGUI.currentStaff.Ma))
				{
					modal.ShowDialog();
					if (modal.isSubmitSucces)
					{
						List<ImportRefundBillDTO> importRefundBills = this.handleFilter(this.searchInput.Text);
						loadDataToDGV(importRefundBills);
					}
				}
			}
			catch
			{

			}
			
		}


		public List<ImportRefundBillDTO> handleFilter(string searchInput)
		{
			try
			{
                List<ImportRefundBillDTO> importRefundBills = ImportRefundBillBUS.Instance.search(searchInput);
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
                            importRefundBills = importRefundBills.FindAll(
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
						importRefundBills = importRefundBills.Where(item =>

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

                List<ImportRefundBillDTO> newImportRefundBillList = importRefundBills.FindAll(importRefundBill =>
                {
                    if (staffId != 0)
                    {
                        return importRefundBill.MaNhanVien == staffId;
                    }

                    return true;
                });
                return newImportRefundBillList;
            }
            catch (Exception ex) {

                return new List<ImportRefundBillDTO>();

            }

		}
		private void btnRefresh_Click(object sender, EventArgs e)
		{
			try
			{
                this.fromPriceTxt.Clear();
                this.toPriceTxt.Clear();
                this.searchInput.Clear();
                this.gunaMediumCheckBox1.Checked = false;
                this.filterCkx.Checked = false;
                this.fromPriceTxt.Clear();
                this.toPriceTxt.Clear();
                this.fromPriceTxt.Enabled = false;
                this.toPriceTxt.Enabled = false;
                this.filterCkx.Checked = false;
                this.staffCbx.SelectedIndex = 0;
                List<ImportRefundBillDTO> importRefundBills = ImportRefundBillBUS.Instance.getAllData();
				this.loadDataToDGV(importRefundBills);
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
				using (var modal = new ImportRefundBillModal(ManagerGUI.currentStaff.Ma, "Xem chi tiết phiếu trả nhập hàng"))
				{
					DataGridViewRow selectedRow = dgvImportRefund.Rows[dgvImportRefund.CurrentCell.RowIndex];
					ImportRefundBillDTO importRefundBill = ImportRefundBillBUS.Instance.getById(selectedRow.Cells[0].Value.ToString());
					modal.importRefundBill = importRefundBill;
					modal.ShowDialog();
				}
			}
			catch
			{

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
                using (var modal = new ImportRefundBillModal(ManagerGUI.currentStaff.Ma, "Xem chi tiết phiếu trả nhập hàng"))
                {
                    DataGridViewRow selectedRow = dgvImportRefund.Rows[dgvImportRefund.CurrentCell.RowIndex];
                    ImportRefundBillDTO importRefundBill = ImportRefundBillBUS.Instance.getById(selectedRow.Cells[0].Value.ToString());
                    modal.importRefundBill = importRefundBill;
                    modal.ShowDialog();
                }
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

				var importRefundBills = handleFilter(this.searchInput.Text);
				loadDataToDGV(importRefundBills);
			}
			catch
			{

			}
	
		}

		private void dateTimeFrom_ValueChanged(object sender, EventArgs e)
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
				List<ImportRefundBillDTO> importRefundBills = this.handleFilter(this.searchInput.Text);
				loadDataToDGV(importRefundBills);
			}
			catch
			{

			}
		
		}

		private void dateTimeTo_ValueChanged(object sender, EventArgs e)
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
				List<ImportRefundBillDTO> importRefundBills = this.handleFilter(this.searchInput.Text);
				loadDataToDGV(importRefundBills);
			}
			catch
			{

			}
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
                List<ImportRefundBillDTO> importRefundBillList = handleFilter(this.searchInput.Text.ToString());

                this.loadDataToDGV(importRefundBillList);
            }
            catch (Exception er)
            {

                Console.WriteLine(er);
            }
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
                string[] headerList = new string[] { "Mã phiếu", "Mã đơn nhập hàng", "Nhân viên", "Lý do", "Tổng tiền", "Ngày lập" };

                DataTable dt = CustomExcel.Instance.ConvertDataGridViewToDataTable(dgvImportRefund);

                CustomExcel.Instance.ExportFileDatagridView(dt, "Book Manage", 0, "Cửa hàng bán sách", headerList);
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

                using (ImportRefundBillPrintForm importChangeBillPrintForm = new ImportRefundBillPrintForm(Convert.ToInt32(row.Cells[0].Value)))
                {

                    importChangeBillPrintForm.ShowDialog();

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

        private void fromPriceTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void toPriceTxt_TextChanged(object sender, EventArgs e)
        {

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
                    List<ImportRefundBillDTO> customerBillList = handleFilter(this.searchInput.Text.ToString());

                    this.loadDataToDGV(customerBillList);
                }
            }
        }

        private void searchInput_TextChanged(object sender, EventArgs e)
        {
            List<ImportRefundBillDTO> customerBillList = handleFilter(this.searchInput.Text.ToString());

            this.loadDataToDGV(customerBillList);
        }
    }
}
