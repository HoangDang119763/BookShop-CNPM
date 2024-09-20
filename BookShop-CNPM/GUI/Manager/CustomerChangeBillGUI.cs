using BookShop_CNPM.BUS;
using BookShop_CNPM.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BookShop_CNPM.GUI.Modal;
using BookShop_CNPM.GUI.Report;

namespace BookShop_CNPM.GUI.Manager
{
    public partial class CustomerChangeBillGUI : Form
    {
        public CustomerChangeBillGUI()
        {
            InitializeComponent();
			dgvCustomerChangeBill.StandardTab = true;
		}

        private void loadCustomerChangeBillListToDataView(List<CustomerChangeBillDTO> CustomerChangeBillList)
        {
            try
            {
                this.dgvCustomerChangeBill.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 210, 192);
                this.dgvCustomerChangeBill.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                this.dgvCustomerChangeBill.Rows.Clear();


                foreach (CustomerChangeBillDTO CustomerChangeBill in CustomerChangeBillList)
                {
                    this.dgvCustomerChangeBill.Rows.Add(new object[] {
                    CustomerChangeBill.MaPhieu,
                    CustomerChangeBill.MaDonKhachHang,
                    StaffBUS.Instance.getById(CustomerChangeBill.MaNhanVien.ToString()).Ten,
                    CustomerChangeBill.TinhTrangSanPham,
                    CustomerChangeBill.LiDo,
                    CustomerChangeBill.NgayLap,
                });
                }
            }
            catch (Exception er)
            {

                Console.WriteLine(er);
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

        private void CustomerChangeBillGUI_Load(object sender, EventArgs e)
        {

            try
            {
                this.dateTimeFrom.Enabled = this.filterCkx.Checked;
                this.dateTimeTo.Enabled = this.filterCkx.Checked;
                List<CustomerChangeBillDTO> CustomerChangeBillList = CustomerChangeBillBUS.Instance.getAllData();
                this.loadCustomerChangeBillListToDataView(CustomerChangeBillList);
                this.loadStaffCbx();
            }
            catch (Exception er)
            {

                Console.WriteLine(er);
            }
        }

        private void searchInput_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.searchInput.ForeColor = Color.Black;

                List<CustomerChangeBillDTO> CustomerChangeBillList = CustomerChangeBillBUS.Instance.search(this.searchInput.Text.ToString());

                this.loadCustomerChangeBillListToDataView(CustomerChangeBillList);
            }
            catch (Exception er)
            {

                Console.WriteLine(er);
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.searchInput.Clear();
                this.staffCbx.SelectedIndex = 0;
                this.dateTimeFrom.Enabled = false;
                this.dateTimeTo.Enabled = false;
                List<CustomerChangeBillDTO> CustomerChangeBillList = CustomerChangeBillBUS.Instance.search("");
                this.loadCustomerChangeBillListToDataView(CustomerChangeBillList);
            }
            catch (Exception er)
            {

                Console.WriteLine(er);
            }
        }

        private void exportBtn_Click(object sender, EventArgs e)
        {
            if (dgvCustomerChangeBill.Rows.Count <= 0)
            {
                MessageBox.Show("Bảng dữ liệu hiện tại chưa có dòng dữ liệu nào để xuất excel!");
                return;
            }
            try
            {
                string[] headerList = new string[] { "Mã phiếu", "Mã đơn khách hàng", "Mã nhân viên", "Tình trạng đổi hàng", "Lý do", "Ngày lập" };
                DataTable dt = CustomExcel.Instance.ConvertDataGridViewToDataTable(dgvCustomerChangeBill);

                CustomExcel.Instance.ExportFileDatagridView(dt, "Book Manage", 0, "Cửa hàng bán sách", headerList);
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
                bool isHaveSelect = false;

                foreach (DataGridViewRow row in this.dgvCustomerChangeBill.Rows)
                {
                    if ((bool)row.Cells[0].Value)
                    {
                        isHaveSelect = true;
                        break;
                    }
                }

                if (!isHaveSelect)
                {
                    MessageBox.Show("Bạn chưa chọn những phiếu cần xóa");
                    return;
                }

                DialogResult dlgResult = MessageBox.Show(
                    "Bạn chắc chắn muốn xóa các phiếu đã chọn chứ?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1
                );

                if (dlgResult == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in this.dgvCustomerChangeBill.Rows)
                    {
                        if ((bool)row.Cells[0].Value == true)
                        {
                            CustomerChangeBillBUS.Instance.delete(row.Cells[1].Value.ToString());
                        }

                    }
                    List<CustomerChangeBillDTO> CustomerChangeBillList = CustomerChangeBillBUS.Instance.search(this.searchInput.Text.ToString());

                    this.loadCustomerChangeBillListToDataView(CustomerChangeBillList);

                    MessageBox.Show("Delete successful");
                }
            }
            catch (Exception er)
            {

                Console.WriteLine(er);
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (CustomerChangeBillModal CustomerChangeBillModal = new CustomerChangeBillModal(ManagerGUI.currentStaff.Ma))
                {
                    CustomerChangeBillModal.ShowDialog();


                    if (CustomerChangeBillModal.isSubmitSuccess)
                    {
                        List<CustomerChangeBillDTO> CustomerChangeBillList = CustomerChangeBillBUS.Instance.search(this.searchInput.Text.ToString());

                        this.loadCustomerChangeBillListToDataView(CustomerChangeBillList);
                    }
                }
            }
            catch (Exception er)
            {

                Console.WriteLine(er);
            }
        }

        private bool isCheckSeletedRows()
        {
            try
            {
                foreach (DataGridViewRow row in this.dgvCustomerChangeBill.Rows)
                {
                    if ((bool)row.Cells[0].Value)
                    {
                        return true;
                    }
                }

                MessageBox.Show("Bạn chưa chọn những đơn hàng cần xóa");
                return false;
            }
            catch
            {

                return false;
            }
        }

        private void printPdfBtn_Click(object sender, EventArgs e)
        {

            try
            {
                    if (this.dgvCustomerChangeBill.CurrentCell == null)
                    {
                        MessageBox.Show("Bảng dữ liệu có thể chưa có dòng dữ liệu nào để xem chi tiết");
                        return;
                    }
                    if (this.dgvCustomerChangeBill.CurrentCell.RowIndex < 0 || this.dgvCustomerChangeBill.CurrentCell == null)
                    {
                        MessageBox.Show("Hãy chọn dòng dữ liệu muốn thao tác");
                        return;
                    }

                    DataGridViewRow row = this.dgvCustomerChangeBill.Rows[this.dgvCustomerChangeBill.CurrentCell.RowIndex];

                    using (CustomerChangeBillPrintForm customerChangeBillPrintForm = new CustomerChangeBillPrintForm(Convert.ToInt32(row.Cells[0].Value)))
                    {

                        customerChangeBillPrintForm.ShowDialog();

                    }
            }
            catch (Exception er)
            {

                Console.WriteLine(er);
            }
        }

        private void customerCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                List<CustomerChangeBillDTO> customerChangeBillList = handleFilter(this.searchInput.Text.ToString());

                this.loadCustomerChangeBillListToDataView(customerChangeBillList);
            }
            catch (Exception er)
            {

                Console.WriteLine(er);
            }
        }

        private List<CustomerChangeBillDTO> handleFilter(string searchText)
        {
            try
            {
                List<CustomerChangeBillDTO> customerChangeBillList = CustomerChangeBillBUS.Instance.search(searchText);

                if (DateTime.Compare(this.dateTimeFrom.Value, this.dateTimeTo.Value) <= 0 && this.filterCkx.Checked)
                {
                    try
                    {
                        customerChangeBillList = customerChangeBillList.FindAll(
                            item => (DateTime.Compare(item.NgayLap, this.dateTimeFrom.Value) >= 0)
                                    && (DateTime.Compare(item.NgayLap, this.dateTimeTo.Value) <= 0)
                        );
                    }
                    catch
                    {
                        MessageBox.Show("Lọc theo khoảng thời gian không hợp lệ");
                    }
                }

                int staffId = Convert.ToInt32(this.staffCbx.SelectedValue);

                List<CustomerChangeBillDTO> newCustomerChangeBillList = customerChangeBillList.FindAll(customerChangeBill =>
                {
                    if (staffId != 0)
                    {
                        return customerChangeBill.MaNhanVien == staffId;
                    }

                    return true;
                });

                return newCustomerChangeBillList;
            }
            catch
            {

                return new List<CustomerChangeBillDTO>();
            }
        }

        private void bookNeedChangeCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                List<CustomerChangeBillDTO> customerChangeBillList = handleFilter(this.searchInput.Text.ToString());

                this.loadCustomerChangeBillListToDataView(customerChangeBillList);
            }
            catch (Exception er)
            {

                Console.WriteLine(er);
            }
        }

        private void bookWantChangeCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                List<CustomerChangeBillDTO> customerChangeBillList = handleFilter(this.searchInput.Text.ToString());

                this.loadCustomerChangeBillListToDataView(customerChangeBillList);
            }
            catch (Exception er)
            {

                Console.WriteLine(er);
            }
        }

        private void staffCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                List<CustomerChangeBillDTO> customerChangeBillList = handleFilter(this.searchInput.Text.ToString());

                this.loadCustomerChangeBillListToDataView(customerChangeBillList);
            }
            catch (Exception er)
            {

                Console.WriteLine(er);
            }
        }

        private void filterCkx_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                this.dateTimeFrom.Enabled = this.filterCkx.Checked;
                this.dateTimeTo.Enabled = this.filterCkx.Checked;
            }
            catch (Exception er)
            {

                Console.WriteLine(er);
            }
        }

        private void dateTimeFrom_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                bool isValid = DateTime.Compare(dateTimeFrom.Value, dateTimeTo.Value) > 0;

                if (isValid)
                {
                    dateTimeFrom.Value = dateTimeTo.Value;
                    MessageBox.Show("Bạn không thể chọn ngày lớn hơn ngày " + dateTimeTo.Value.GetDateTimeFormats()[0]);
                    return;
                }

                List<CustomerChangeBillDTO> customerChangeBillList = handleFilter(this.searchInput.Text.ToString());

                this.loadCustomerChangeBillListToDataView(customerChangeBillList);
            }
            catch (Exception er)
            {

                Console.WriteLine(er);
            }
        }

        private void dateTimeTo_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                bool isValid = DateTime.Compare(dateTimeTo.Value, dateTimeFrom.Value) < 0;

                if (isValid)
                {
                    dateTimeTo.Value = dateTimeFrom.Value;
                    MessageBox.Show("Bạn không thể chọn ngày nhỏ hơn ngày " + dateTimeFrom.Value.GetDateTimeFormats()[0]);
                    return;
                }

                List<CustomerChangeBillDTO> customerChangeBillList = handleFilter(this.searchInput.Text.ToString());

                this.loadCustomerChangeBillListToDataView(customerChangeBillList);
            }
            catch (Exception er)
            {

                Console.WriteLine(er);
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void detailsBtn_Click(object sender, EventArgs e)
        {
            try
            {
                    if (this.dgvCustomerChangeBill.CurrentCell == null)
                    {
                        MessageBox.Show("Bảng dữ liệu có thể chưa có dòng dữ liệu nào để xem chi tiết");
                        return;
                    }
                    if (this.dgvCustomerChangeBill.CurrentCell.RowIndex < 0)
                    {
                        MessageBox.Show("Hãy chọn phiếu trả muốn xem");
                        return;
                    }
                    using (var modal = new CustomerChangeBillModal(ManagerGUI.currentStaff.Ma, "Xem chi tiết phiếu đổi bán hàng"))
                    {
                        DataGridViewRow selectedRow = dgvCustomerChangeBill.Rows[dgvCustomerChangeBill.CurrentCell.RowIndex];
                        CustomerChangeBillDTO customerChangeBill = CustomerChangeBillBUS.Instance.getById(selectedRow.Cells[0].Value.ToString());
                        modal.customerChangeBill = customerChangeBill;
                        modal.ShowDialog();
                    }
            }
            catch (Exception er)
            {

                Console.WriteLine(er);
            }
        }

        private void dgvCustomerChangeBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dgvCustomerChangeBill.CurrentCell.RowIndex < 0)
                {
                    MessageBox.Show("Hãy chọn phiếu trả muốn xem");
                    return;
                }
                using (var modal = new CustomerChangeBillModal(ManagerGUI.currentStaff.Ma, "Xem chi tiết phiếu đổi bán hàng"))
                {
                    DataGridViewRow selectedRow = dgvCustomerChangeBill.Rows[dgvCustomerChangeBill.CurrentCell.RowIndex];
                    CustomerChangeBillDTO customerChangeBill = CustomerChangeBillBUS.Instance.getById(selectedRow.Cells[0].Value.ToString());
                    modal.customerChangeBill = customerChangeBill;
                    modal.ShowDialog();
                }
            }
            catch (Exception er)
            {

                Console.WriteLine(er);
            }
        }
    }
}
