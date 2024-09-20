using BookShop_CNPM.BUS;
using BookShop_CNPM.DTO;
using BookShop_CNPM.GUI.Modal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BookShop_CNPM.GUI.Manager
{
    public partial class SupplierManagerGUI : Form
    {
        public SupplierManagerGUI()
        {
            InitializeComponent();
        }
        private CheckBox headerCheckbox;
        private void renderCheckBoxDgv()
        {
            int size = 25;

            Rectangle rect = this.dgvSupplier.GetCellDisplayRectangle(0, -1, false);

            headerCheckbox = new CheckBox();

            headerCheckbox.BackColor = Color.FromArgb(45, 210, 192);
            headerCheckbox.Name = "chkHeader";
            headerCheckbox.Size = new Size(size, size);
            headerCheckbox.TabStop = false;

            rect.X = (rect.Width / 2) - (size / 4);
            rect.Y = (rect.Height / 2) - (size / 2);

            headerCheckbox.Location = rect.Location;


            this.dgvSupplier.Controls.Add(headerCheckbox);
        }

        private void headerCheckbox_Clicked(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in this.dgvSupplier.Rows)
                {
                    row.Cells[0].Value = headerCheckbox.Checked;
                }

                this.dgvSupplier.RefreshEdit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void loadSupplierListToDataView(List<SupplierDTO> SupplierList)
        {
            try
            {
                this.dgvSupplier.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 210, 192);
                this.dgvSupplier.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                this.dgvSupplier.ColumnHeadersDefaultCellStyle.Font = new Font("#9Slide03 Cabin", 10, FontStyle.Regular);
				this.dgvSupplier.Rows.Clear();

                foreach (SupplierDTO Supplier in SupplierList)
                {
					    this.dgvSupplier.Rows.Add(new object[] {
                            false,
						    Supplier.MaNhaCungCap,
						    Supplier.TenNhaCungCap,
						    Supplier.DiaChi,
						    Supplier.SoDienThoai,
					    });
                }
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
                List<SupplierDTO> SupplierList = SupplierBUS.Instance.search(this.searchInput.Text.Trim());
                this.loadSupplierListToDataView(SupplierList);
            }
            catch (Exception er)
            {

                Console.WriteLine(er);
            }
        }

        private void exportBtn_Click(object sender, EventArgs e)
        {
            if (dgvSupplier.Rows.Count <= 0)
            {
                MessageBox.Show("Bảng dữ liệu hiện tại chưa có dòng dữ liệu nào để xuất excel!");
                return;

            }

            try
            {
                string[] headerList = new string[] { "Mã nhà cung cấp", "Tên nhà cung cấp", "Địa chỉ", "Số điện thoại" };
                DataTable dt = CustomExcel.Instance.ConvertDataGridViewToDataTable(dgvSupplier);
                CustomExcel.Instance.ExportFileDatagridView(dt, "Book Manage", 1, "Cửa hàng bán sách", headerList);
            }
            catch (Exception er)
            {

                Console.WriteLine(er);
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            try
            {   
                if(this.dgvSupplier.CurrentCell != null )
                {
					if (this.dgvSupplier.CurrentCell.RowIndex < 0)
					{
						MessageBox.Show("Hãy chọn dòng dữ liệu muốn thao tác");
						return;
					}

					using (SupplierModal SupplierModal = new SupplierModal("Sửa nhà cung cấp"))
					{
						DataGridViewRow row = this.dgvSupplier.Rows[this.dgvSupplier.CurrentCell.RowIndex];

						SupplierDTO Supplier = SupplierBUS.Instance.getById(row.Cells[1].Value.ToString());

						SupplierModal.updateSupplier = Supplier;

						if (SupplierModal.updateSupplier == null)
						{
							MessageBox.Show("Đã xảy ra lỗi vui lòng thử lại sau!!");
							return;
						}

						SupplierModal.ShowDialog();

						if (SupplierModal.isSubmitSuccess)
						{
							List<SupplierDTO> SupplierList = SupplierBUS.Instance.search(this.searchInput.Text.Trim());

							this.loadSupplierListToDataView(SupplierList);
						}
					}
				}
                else
                {
					MessageBox.Show("Bảng dữ liệu có thể chưa có dòng dữ liệu nào để chỉnh sửa");
				}
				
            }
            catch (Exception er)
            {

                Console.WriteLine(er);
            }
        }

        private void dgvSupplier_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex <= 0)
                {
                    return;
                }

                using (SupplierModal SupplierModal = new SupplierModal("Sửa nhà cung cấp"))
                {
                    DataGridViewRow row = this.dgvSupplier.Rows[e.RowIndex];

                    SupplierDTO Supplier = SupplierBUS.Instance.getById(row.Cells[1].Value.ToString());

                    SupplierModal.updateSupplier = Supplier;
                    if (SupplierModal.updateSupplier == null)
                    {
                        MessageBox.Show("Đã xảy ra lỗi vui lòng thử lại sau!!");
                        return;
                    }

                    SupplierModal.ShowDialog();

                    if (SupplierModal.isSubmitSuccess)
                    {
                        List<SupplierDTO> SupplierList = SupplierBUS.Instance.search(this.searchInput.Text.Trim());

                        this.loadSupplierListToDataView(SupplierList);
                    }
                }
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
                this.headerCheckbox.Checked = false;

                List<SupplierDTO> SupplierList = SupplierBUS.Instance.search("");
                this.loadSupplierListToDataView(SupplierList);
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
                using (SupplierModal SupplierModal = new SupplierModal())
                {
                    SupplierModal.ShowDialog();


                    if (SupplierModal.isSubmitSuccess)
                    {
                        List<SupplierDTO> SupplierList = SupplierBUS.Instance.search(this.searchInput.Text.Trim());

                        this.loadSupplierListToDataView(SupplierList);
                    }
                }
            }
            catch (Exception er)
            {

                Console.WriteLine(er);
            }
        }

        private void SupplierManagerGUI_Load(object sender, EventArgs e)
        {
            try
            {
                List<SupplierDTO> SupplierList = SupplierBUS.Instance.getAllData();
                this.renderCheckBoxDgv();
                headerCheckbox.MouseClick += new MouseEventHandler(headerCheckbox_Clicked);
                this.loadSupplierListToDataView(SupplierList);
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

                foreach (DataGridViewRow row in this.dgvSupplier.Rows)
                {
                    if ((bool)row.Cells[0].Value)
                    {
                        isHaveSelect = true;
                    }
                }

                if (!isHaveSelect)
                {
                    MessageBox.Show("Bạn chưa chọn nhà cung cấp nào để xóa");
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Bạn có chắc muốn xóa các nhà cung cấp đã chọn?",
                    "Xác nhận",
                      MessageBoxButtons.YesNo,
                      MessageBoxIcon.None
                    );
                if (result == DialogResult.Yes)
                {
                    bool isDeleted = false;
                    foreach (DataGridViewRow row in this.dgvSupplier.Rows)
                    {
                        if ((bool)row.Cells[0].Value)
                        {
                            SupplierBUS.Instance.delete(row.Cells[1].Value.ToString());
                            isDeleted = true;
                        }
                    }
                    if (isDeleted)
                    {
                        List<SupplierDTO> SupplierList = SupplierBUS.Instance.search(this.searchInput.Text.Trim());
                        this.loadSupplierListToDataView(SupplierList);
                        MessageBox.Show("Xóa thành công");
                    }
                }
            }
            catch
            {

            }
        }
    }
}
