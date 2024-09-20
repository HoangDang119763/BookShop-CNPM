using BookShop_CNPM.BUS;
using BookShop_CNPM.DTO;
using BookShop_CNPM.GUI.Report;
using BookShop_CNPM.GUI.Modal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BookShop_CNPM.GUI.Manager
{
    public partial class ImportChangeBillGUI : Form
    {
        public ImportChangeBillGUI()
        {
            InitializeComponent();
        }

        private void loadImportChangeBillListToDataView(List<ImportChangeBillDTO> ImportChangeBillList)
        {
            try
            {
                this.dgvImportChangeBill.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 210, 192);
                this.dgvImportChangeBill.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                this.dgvImportChangeBill.Rows.Clear();

                foreach (ImportChangeBillDTO ImportChangeBill in ImportChangeBillList)
                {
                    this.dgvImportChangeBill.Rows.Add(new object[] {
                        ImportChangeBill.MaPhieu,
                        ImportChangeBill.MaDonNhapHang,
                        StaffBUS.Instance.getById(ImportChangeBill.MaNhanVien.ToString()).Ten,
                        ImportChangeBill.TinhTrangSanPham,
                        ImportChangeBill.LiDo,
                        ImportChangeBill.NgayLap,
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

        private void ImportChangeBillGUI_Load(object sender, EventArgs e)
        {

            try
            {
                List<ImportChangeBillDTO> ImportChangeBillList = ImportChangeBillBUS.Instance.getAllData();
                this.loadImportChangeBillListToDataView(ImportChangeBillList);
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

                List<ImportChangeBillDTO> ImportChangeBillList = ImportChangeBillBUS.Instance.search(this.searchInput.Text.ToString());

                this.loadImportChangeBillListToDataView(ImportChangeBillList);
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
                List<ImportChangeBillDTO> ImportChangeBillList = ImportChangeBillBUS.Instance.search("");
                this.loadImportChangeBillListToDataView(ImportChangeBillList);
            }
            catch (Exception er)
            {

                Console.WriteLine(er);
            }
        }

        private void exportBtn_Click(object sender, EventArgs e)
        {
            if (dgvImportChangeBill.Rows.Count <= 0)
            {
                MessageBox.Show("Bảng dữ liệu hiện tại chưa có dòng dữ liệu nào để xuất excel!");
                return;
            }

            try
            {
                string[] headerList = new string[] { "Mã phiếu", "Mã đơn nhập hàng", "Mã nhân viên", "Tình trạng đổi hàng", "Lý do", "Ngày lập" };

                DataTable dt = CustomExcel.Instance.ConvertDataGridViewToDataTable(dgvImportChangeBill);

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

                foreach (DataGridViewRow row in this.dgvImportChangeBill.Rows)
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
                    foreach (DataGridViewRow row in this.dgvImportChangeBill.Rows)
                    {
                        if ((bool)row.Cells[0].Value == true)
                        {
                            ImportChangeBillBUS.Instance.delete(row.Cells[0].Value.ToString());
                        }

                    }
                    List<ImportChangeBillDTO> ImportChangeBillList = ImportChangeBillBUS.Instance.search(this.searchInput.Text.ToString());

                    this.loadImportChangeBillListToDataView(ImportChangeBillList);

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
                using (ImportChangeBillModal importChangeBillModal = new ImportChangeBillModal(ManagerGUI.currentStaff.Ma))
                {
                    importChangeBillModal.ShowDialog();


                    if (importChangeBillModal.isSubmitSuccess)
                    {
                        List<ImportChangeBillDTO> importChangeBillList = ImportChangeBillBUS.Instance.search(this.searchInput.Text.ToString());

                        this.loadImportChangeBillListToDataView(importChangeBillList);
                    }
                }
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
                if (this.dgvImportChangeBill.CurrentCell == null)
                {
                    MessageBox.Show("Bảng dữ liệu có thể chưa có dòng dữ liệu nào để xem chi tiết");
                    return;
                }
                if (this.dgvImportChangeBill.CurrentCell.RowIndex < 0 || this.dgvImportChangeBill.CurrentCell == null)
                {
                    MessageBox.Show("Hãy chọn dòng dữ liệu muốn thao tác");
                    return;
                }

                DataGridViewRow row = this.dgvImportChangeBill.Rows[this.dgvImportChangeBill.CurrentCell.RowIndex];

                using (ImportChangeBillPrintForm importChangeBillPrintForm = new ImportChangeBillPrintForm(Convert.ToInt32(row.Cells[0].Value)))
                {

                    importChangeBillPrintForm.ShowDialog();

                }
            }
            catch (Exception er)
            {

                Console.WriteLine(er);
            }
        }


        private List<ImportChangeBillDTO> handleFilter(string searchText)
        {
            try
            {
                List<ImportChangeBillDTO> importChangeBillList = ImportChangeBillBUS.Instance.search(searchText);

                if (DateTime.Compare(this.dateTimeFrom.Value, this.dateTimeTo.Value) <= 0 && this.filterCkx.Checked)
                {
                    try
                    {
                        importChangeBillList = importChangeBillList.FindAll(
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

                List<ImportChangeBillDTO> newImportChangeBillList = importChangeBillList.FindAll(importChangeBill =>
                {

                    if (staffId != 0)
                    {
                        return importChangeBill.MaNhanVien == staffId;
                    }

                    return true;
                });


                return newImportChangeBillList;
            }
            catch (Exception er)
            {

                return new List<ImportChangeBillDTO>();
            }
        }
        private void supplierCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                List<ImportChangeBillDTO> importChangeBillList = handleFilter(this.searchInput.Text.ToString());

                this.loadImportChangeBillListToDataView(importChangeBillList);
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
                List<ImportChangeBillDTO> importChangeBillList = handleFilter(this.searchInput.Text.ToString());

                this.loadImportChangeBillListToDataView(importChangeBillList);
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

                List<ImportChangeBillDTO> importChangeBillList = handleFilter(this.searchInput.Text.ToString());

                this.loadImportChangeBillListToDataView(importChangeBillList);
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

                List<ImportChangeBillDTO> importChangeBillList = handleFilter(this.searchInput.Text.ToString());

                this.loadImportChangeBillListToDataView(importChangeBillList);
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
                if (this.dgvImportChangeBill.CurrentCell == null)
                {
                    MessageBox.Show("Bảng dữ liệu có thể chưa có dòng dữ liệu nào để xem chi tiết");
                    return;
                }
                if (this.dgvImportChangeBill.CurrentCell.RowIndex < 0)
                {
                    MessageBox.Show("Hãy chọn phiếu trả muốn xem");
                    return;
                }
                using (var modal = new ImportChangeBillModal(ManagerGUI.currentStaff.Ma, "Xem chi tiết phiếu đổi nhập hàng"))
                {
                    DataGridViewRow selectedRow = dgvImportChangeBill.Rows[dgvImportChangeBill.CurrentCell.RowIndex];
                    ImportChangeBillDTO importChangeBill = ImportChangeBillBUS.Instance.getById(selectedRow.Cells[0].Value.ToString());
                    modal.importChangeBill = importChangeBill;
                    modal.ShowDialog();
                }
            }
            catch (Exception er)
            {

                Console.WriteLine(er);
            }
        }

        private void dgvImportChangeBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dgvImportChangeBill.CurrentCell.RowIndex < 0)
                {
                    MessageBox.Show("Hãy chọn phiếu trả muốn xem");
                    return;
                }
                using (var modal = new ImportChangeBillModal(ManagerGUI.currentStaff.Ma, "Xem chi tiết phiếu đổi nhập hàng"))
                {
                    DataGridViewRow selectedRow = dgvImportChangeBill.Rows[dgvImportChangeBill.CurrentCell.RowIndex];
                    ImportChangeBillDTO importChangeBill = ImportChangeBillBUS.Instance.getById(selectedRow.Cells[0].Value.ToString());
                    modal.importChangeBill = importChangeBill;
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
