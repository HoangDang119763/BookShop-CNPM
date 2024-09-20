using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BookShop_CNPM.BUS;
using BookShop_CNPM.DTO;
using BookShop_CNPM.GUI.Modal;

namespace BookShop_CNPM.GUI.Manager
{
    public partial class PermissionManageGUI : Form
    {
        public delegate void OnPermissionStatusChange(int staffId, string screenName);
		public event OnPermissionStatusChange onPermissionStatusChange;
		public PermissionManageGUI()
        {
            InitializeComponent();
        }

        private CheckBox headerCheckbox;
        private void renderCheckBoxDgv()
        {
            int size = 25;

            Rectangle rect = this.dgvPermission.GetCellDisplayRectangle(0, -1, false);

            headerCheckbox = new CheckBox();

            headerCheckbox.BackColor = Color.FromArgb(45, 210, 192);
            headerCheckbox.Name = "chkHeader";
            headerCheckbox.Size = new Size(size, size);
            headerCheckbox.TabStop = false;

            rect.X = (rect.Width / 2) - (size / 4);
            rect.Y = (rect.Height / 2) - (size / 2);

            headerCheckbox.Location = rect.Location;


            this.dgvPermission.Controls.Add(headerCheckbox);
        }
        private void headerCheckbox_Clicked(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in this.dgvPermission.Rows)
                {
                    row.Cells[0].Value = headerCheckbox.Checked;
                }

                this.dgvPermission.RefreshEdit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void loadPermissionListToDataView(List<PermissionDTO> positionList)
        {
            try
            {
                this.dgvPermission.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 210, 192);
                this.dgvPermission.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
			    this.dgvPermission.ColumnHeadersDefaultCellStyle.Font = new Font("#9Slide03 Cabin", 10, FontStyle.Regular);
				this.dgvPermission.Rows.Clear();

                foreach (PermissionDTO position in positionList)
                {
                    this.dgvPermission.Rows.Add(new object[] {
                        false,
                        position.maQuyenHan,
                        position.tenQuyenHan,
                        position.TrangThai ? "Đang hoạt động" : "Ngưng hoạt động",
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }


        private void PermissionManageGUI_Load(object sender, EventArgs e)
        {
            try
            {

                List<PermissionDTO> positionList = PermissionBUS.Instance.getAllData();
                this.renderCheckBoxDgv();
                headerCheckbox.MouseClick += new MouseEventHandler(headerCheckbox_Clicked);
                this.loadPermissionListToDataView(positionList);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void searchInput_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.searchInput.ForeColor = Color.Black;

                List<PermissionDTO> positionList = PermissionBUS.Instance.search(this.searchInput.Text.Trim());

                this.loadPermissionListToDataView(positionList);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void exportBtn_Click(object sender, EventArgs e)
        {
            if (dgvPermission.Rows.Count <= 0)
            {
                MessageBox.Show("Bảng dữ liệu hiện tại chưa có dòng dữ liệu nào để xuất excel!");
                return;
            }

            try
            {

                string[] headerList = new string[] { "Mã quyền hạn", "Tên quyền hạn", "Trạng thái" };

                DataTable dt = CustomExcel.Instance.ConvertDataGridViewToDataTable(dgvPermission);

                CustomExcel.Instance.ExportFileDatagridView(dt, "Book Manage", 1, "Cửa hàng bán sách", headerList);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.dgvPermission.CurrentCell != null)
                {
					if (this.dgvPermission.CurrentCell.RowIndex < 0)
					{
						MessageBox.Show("Hãy chọn dòng dữ liệu muốn thao tác");
						return;
					}

					using (PermissionModal positionModal = new PermissionModal("Sửa quyền hạn"))
					{
						DataGridViewRow row = this.dgvPermission.Rows[this.dgvPermission.CurrentCell.RowIndex];

						PermissionDTO position = PermissionBUS.Instance.getById(row.Cells[1].Value.ToString());

						positionModal.updatePermission = position;

						if (positionModal.updatePermission == null)
						{
							MessageBox.Show("Đã xảy ra lỗi vui lòng thử lại sau!!");
							return;
						}

						positionModal.ShowDialog();
						if (positionModal.isSubmitSuccess)
						{
							List<PermissionDTO> positionList = PermissionBUS.Instance.search(this.searchInput.Text.Trim());

							this.loadPermissionListToDataView(positionList);
							if (positionModal.isPermissionStatusChange)
							{
								onPermissionStatusChange(ManagerGUI.currentStaff.Ma, "");
							}
						}
					}
                }
                else
                {
					MessageBox.Show("Bảng dữ liệu có thể chưa có dòng dữ liệu nào để chỉnh sửa");
				}

			}
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                bool isHaveSelect = false;

                foreach (DataGridViewRow row in this.dgvPermission.Rows)
                {
                    if ((bool)row.Cells[0].Value)
                    {
                        isHaveSelect = true;
                        break;
                    }
                }

                if (!isHaveSelect)
                {
                    MessageBox.Show("Bạn chưa chọn những quyền hạn cần xóa");
                    return;
                }

                DialogResult dlgResult = MessageBox.Show(
                    "Bạn chắc chắn muốn xóa các quyền hạn đã chọn chứ?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1
                );

                if (dlgResult == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in this.dgvPermission.Rows)
                    {
                        if ((bool)row.Cells[0].Value == true)
                        {
                            PermissionBUS.Instance.delete(row.Cells[1].Value.ToString());
                        }

                    }
                    List<PermissionDTO> positionList = PermissionBUS.Instance.search(this.searchInput.Text.Trim());
                    this.loadPermissionListToDataView(positionList);

                    MessageBox.Show("Delete successful");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void dgvPermission_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex <= 0)
                {
                    return;
                }

                using (PermissionModal positionModal = new PermissionModal("Sửa quyền hạn"))
                {
                    DataGridViewRow row = this.dgvPermission.Rows[e.RowIndex];

                    PermissionDTO position = PermissionBUS.Instance.getById(row.Cells[1].Value.ToString());

                    positionModal.updatePermission = position;

                    if (positionModal.updatePermission == null)
                    {
                        MessageBox.Show("Đã xảy ra lỗi vui lòng thử lại sau!!");
                        return;
                    }

                    positionModal.ShowDialog();

                    if (positionModal.isSubmitSuccess)
                    {
                        List<PermissionDTO> positionList = PermissionBUS.Instance.search(this.searchInput.Text.Trim());

                        this.loadPermissionListToDataView(positionList);
						if (positionModal.isPermissionStatusChange)
						{
							onPermissionStatusChange(ManagerGUI.currentStaff.Ma, "");
						}
					}
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            using (PermissionModal positionModal = new PermissionModal())
            {
                positionModal.ShowDialog();


                if (positionModal.isSubmitSuccess)
                {
                    List<PermissionDTO> positionList = PermissionBUS.Instance.search(this.searchInput.Text.Trim());

                    this.loadPermissionListToDataView(positionList);
                }
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.searchInput.Clear();
                this.headerCheckbox.Checked = false;
                List<PermissionDTO> positionList = PermissionBUS.Instance.search("");
                this.loadPermissionListToDataView(positionList);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
