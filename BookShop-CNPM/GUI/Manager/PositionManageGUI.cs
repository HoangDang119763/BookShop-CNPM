﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BookShop_CNPM.BUS;
using BookShop_CNPM.DTO;
using BookShop_CNPM.GUI.Modal;

namespace BookShop_CNPM.GUI.Manager
{
    public partial class PositionManageGUI : Form
    {
        public PositionManageGUI()
        {
            InitializeComponent();
        }
        private CheckBox headerCheckbox;
        private void renderCheckBoxDgv()
        {
            int size = 25;

            Rectangle rect = this.dgvPosition.GetCellDisplayRectangle(0, -1, false);

            headerCheckbox = new CheckBox();

            headerCheckbox.BackColor = Color.FromArgb(45, 210, 192);
            headerCheckbox.Name = "chkHeader";
            headerCheckbox.Size = new Size(size, size);
            headerCheckbox.TabStop = false;

            rect.X = (rect.Width / 2) - (size / 4);
            rect.Y = (rect.Height / 2) - (size / 2);

            headerCheckbox.Location = rect.Location;


            this.dgvPosition.Controls.Add(headerCheckbox);
        }

        private void headerCheckbox_Clicked(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in this.dgvPosition.Rows)
                {
                    row.Cells[0].Value = headerCheckbox.Checked;
                }

                this.dgvPosition.RefreshEdit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        private void loadPositionListToDataView(List<PositionDTO> positionList)
        {
            try
            {
                this.dgvPosition.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 210, 192);
                this.dgvPosition.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                this.dgvPosition.ColumnHeadersDefaultCellStyle.Font = new Font("#9Slide03 Cabin", 10, FontStyle.Regular);
				this.dgvPosition.Rows.Clear();

                List<PositionDTO> filter = positionList.Where(p=>p.MaChucVu != 1).ToList();

                foreach (PositionDTO position in filter)
                {
                    this.dgvPosition.Rows.Add(new object[] {
                        false,
                        position.MaChucVu,
                        position.TenChucVu,
                        position.HeSoLuong,
                        position.MoTa,
                        position.TrangThai ? "Đang hoạt động" : "Ngưng hoạt động",
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }


        private void PositionManageGUI_Load(object sender, EventArgs e)
        {

            try
            {
                List<PositionDTO> positionList = PositionBUS.Instance.getAllData();
                this.renderCheckBoxDgv();
                headerCheckbox.MouseClick += new MouseEventHandler(headerCheckbox_Clicked);
                this.loadPositionListToDataView(positionList);

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

                List<PositionDTO> positionList = PositionBUS.Instance.search(this.searchInput.Text.Trim());

                this.loadPositionListToDataView(positionList);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void exportBtn_Click(object sender, EventArgs e)
        {
            if (dgvPosition.Rows.Count <= 0)
            {
                MessageBox.Show("Bảng dữ liệu hiện tại chưa có dòng dữ liệu nào để xuất excel!");
                return;

            }
            try
            {
                string[] headerList = new string[] { "Mã chức vụ", "Tên chức vụ", "Hệ số lương", "Mô tả", "Trạng thái" };

                DataTable dt = CustomExcel.Instance.ConvertDataGridViewToDataTable(dgvPosition);

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
                if(this.dgvPosition.CurrentCell != null)
                {
					if (this.dgvPosition.CurrentCell.RowIndex < 0)
					{
						MessageBox.Show("Hãy chọn dòng dữ liệu muốn thao tác");
						return;
					}

					DataGridViewRow row = this.dgvPosition.Rows[this.dgvPosition.CurrentCell.RowIndex];

					if (row.Cells[0].Value.ToString() == "1")
					{
						MessageBox.Show("Chức vụ này không thể thay đổi!!");
						return;
					}

					using (PositionModal positionModal = new PositionModal("Sửa chức vụ"))
					{
						PositionDTO position = PositionBUS.Instance.getById(row.Cells[1].Value.ToString());

						positionModal.updatePosition = position;

						if (positionModal.updatePosition == null)
						{
							MessageBox.Show("Đã xảy ra lỗi vui lòng thử lại sau!!");
							return;
						}

						positionModal.ShowDialog();

						if (positionModal.isSubmitSuccess)
						{
							List<PositionDTO> positionList = PositionBUS.Instance.search(this.searchInput.Text.Trim());

							this.loadPositionListToDataView(positionList);
						}
					}
                }
                else
                {
                    MessageBox.Show("Bảng có thể chưa có dòng dữ liệu nào để chỉnh sửa");
				}
			}
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void dgvPosition_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex <= 0)
                {
                    return;
                }

                DataGridViewRow row = this.dgvPosition.Rows[e.RowIndex];

                using (PositionModal positionModal = new PositionModal("Sửa chức vụ"))
                {
                    PositionDTO position = PositionBUS.Instance.getById(row.Cells[1].Value.ToString());

                    positionModal.updatePosition = position;

                    if (positionModal.updatePosition == null)
                    {
                        MessageBox.Show("Đã xảy ra lỗi vui lòng thử lại sau!!");
                        return;
                    }

                    positionModal.ShowDialog();

                    if (positionModal.isSubmitSuccess)
                    {
                        List<PositionDTO> positionList = PositionBUS.Instance.search(this.searchInput.Text.Trim());

                        this.loadPositionListToDataView(positionList);
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
            using (PositionModal positionModal = new PositionModal())
            {
                positionModal.ShowDialog();


                if (positionModal.isSubmitSuccess)
                {
                    List<PositionDTO> positionList = PositionBUS.Instance.search(this.searchInput.Text.Trim());

                    this.loadPositionListToDataView(positionList);
                }
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.searchInput.Clear();
                this.headerCheckbox.Checked = false;

                List<PositionDTO> positionList = PositionBUS.Instance.search("");
                this.loadPositionListToDataView(positionList);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void authorizeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.dgvPosition.CurrentCell != null)
                {
					if (this.dgvPosition.CurrentCell.RowIndex < 0)
					{
						MessageBox.Show("Hãy chọn dòng dữ liệu muốn thao tác");
						return;
					}

					DataGridViewRow row = this.dgvPosition.Rows[this.dgvPosition.CurrentCell.RowIndex];

					if (row.Cells[1].Value.ToString() == "1")
					{
						MessageBox.Show("Chức vụ này đã có quyền tuyệt đối không thể thay đổi quyền!!");
						return;
					}

					using (AuthorizeModal authorizeModal = new AuthorizeModal(Convert.ToInt32(row.Cells[1].Value)))
					{
						authorizeModal.ShowDialog();
					}
                }
                else
                {
                    MessageBox.Show("Bảng có thể chưa có dòng dữ liệu nào để chỉnh sửa");
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

                foreach (DataGridViewRow row in this.dgvPosition.Rows)
                {
                    if ((bool)row.Cells[0].Value)
                    {
                        isHaveSelect = true;
                        break;
                    }
                }

                if (!isHaveSelect)
                {
                    MessageBox.Show("Bạn chưa chọn những chức vụ cần xóa");
                    return;
                }

                DialogResult dlgResult = MessageBox.Show(
                    "Bạn chắc chắn muốn xóa các chức vụ đã chọn chứ?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1
                );

                if (dlgResult == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in this.dgvPosition.Rows)
                    {
                        if ((bool)row.Cells[0].Value == true)
                        {
                            PositionBUS.Instance.delete(row.Cells[1].Value.ToString());
                        }

                    }
                    List<PositionDTO> positionList = PositionBUS.Instance.search(this.searchInput.Text.Trim());

                    this.loadPositionListToDataView(positionList);

                    MessageBox.Show("Xóa thành công");
                }
            }
            catch (Exception er)
            {

                Console.WriteLine(er);
            }
        }

        private void dgvPosition_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
