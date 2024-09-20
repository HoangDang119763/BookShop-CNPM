using System;
using System.Linq;
using System.Windows.Forms;
using Guna.UI.WinForms;
using BookShop_CNPM.BUS;
using BookShop_CNPM.DTO;
using BookShop_CNPM.GUI.Manager;
using BookShop_CNPM.GUI.UserControls;

namespace BookShop_CNPM.GUI
{
    public partial class ManagerGUI : Form
    {
        public static StaffDTO currentStaff;
        public static Authorization authorization;
        private string contentActive;
        private StatisticMenuGUI statisticFrm = new StatisticMenuGUI() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle=FormBorderStyle.None, };
        private BookManageGUI bookFrm = new BookManageGUI() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle=FormBorderStyle.None, };
        private AuthorGUI authorFrm = new AuthorGUI() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle=FormBorderStyle.None, };
        private CustomerManagerGUI customerFrm = new CustomerManagerGUI() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle=FormBorderStyle.None, };
        private StaffManageGUI staffFrm = new StaffManageGUI() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle=FormBorderStyle.None, };
        private SupplierManagerGUI supplierFrm = new SupplierManagerGUI() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle=FormBorderStyle.None, };
        private ImportBillGUI importBillFrm = new ImportBillGUI() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle=FormBorderStyle.None, };
        private CustomerBillGUI customerBillFrm = new CustomerBillGUI() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle=FormBorderStyle.None, };
        private SeoManageGUI seoFrm = new SeoManageGUI() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle=FormBorderStyle.None, };
        private AccountManageGUI accountFrm = new AccountManageGUI() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle=FormBorderStyle.None, };
        private PositionManageGUI positionFrm = new PositionManageGUI() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle=FormBorderStyle.None, };
        private PermissionManageGUI permissionFrm = new PermissionManageGUI() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle=FormBorderStyle.None, };
        private BookTypeGUI bookTypeFrm = new BookTypeGUI() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle=FormBorderStyle.None, };
        private PublisherGUI publisherFrm = new PublisherGUI() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle=FormBorderStyle.None, };
        private RefundFormMenuGUI refundFrm = new RefundFormMenuGUI() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None, };
		private static int staffId = 0;
        public ManagerGUI(int staffId)
        {
            InitializeComponent();
            ManagerGUI.staffId = staffId;
            permissionFrm.onPermissionStatusChange += generateLayout;
            AuthorizeCkb.onPermissionAuthorizeChange += generateLayout;
			currentStaff = StaffBUS.Instance.getById(staffId.ToString());

            navBar.Controls.Clear();
            manageContent.Controls.Clear();

            authorization = new Authorization(currentStaff.MaChucVu);

            foreach (PermissionDTO item in authorization.getPermissionObject())
            {
                bool isCheckPermission = authorization.checkAuthorize(Convert.ToInt32(item.maQuyenHan));

                if (!isCheckPermission)
                {
                    switch (item.maQuyenHan.ToString())
                    {
						case "1":
                            this.navBar.Controls.Remove(bookBtn);
							break;
						case "2":
                            this.navBar.Controls.Remove(staffBtn);
							break;
						case "3":
                            this.navBar.Controls.Remove(supplierBtn);
                            break;
						case "4":
                            this.navBar.Controls.Remove(bookTypeBtn);
                            break;
						case "5":
                            this.navBar.Controls.Remove(publisherBtn);
							break;
                        case "8":
                            this.navBar.Controls.Remove(refundBtn);
                            break;
                        case "9":
                            this.navBar.Controls.Remove(customerBtn);
							break;
						case "10":
                            this.navBar.Controls.Remove(authorBtn);
							break;
						case "11":
                            this.navBar.Controls.Remove(seoBtn);
							break;
						case "12":
                            this.navBar.Controls.Remove(permissionBtn);
							break;
						case "13":
                            this.navBar.Controls.Remove(positionBtn);
							break;
						case "14":
                            this.navBar.Controls.Remove(billBtn);
							break;
						case "15":
                            this.navBar.Controls.Remove(importBilBtn);
							break;
						case "16":
                            this.navBar.Controls.Remove(accountBtn);
							break;
						case "17":
                            this.navBar.Controls.Remove(homeBtn);
							break;
					}
                } else
                {
                    switch (item.maQuyenHan.ToString())
                    {
                        case "1":
                            this.navBar.Controls.Add(bookBtn);
                            this.manageContent.Controls.Add(this.bookFrm);
                            break;
                        case "2":
                            this.navBar.Controls.Add(staffBtn);
                            this.manageContent.Controls.Add(this.staffFrm);
                            break;
                        case "3":
                            this.navBar.Controls.Add(supplierBtn);
                            this.manageContent.Controls.Add(this.supplierFrm);
                            break;
                        case "4":
                            this.navBar.Controls.Add(bookTypeBtn);
                            this.manageContent.Controls.Add(this.bookTypeFrm);
                            break;
                        case "5":
                            this.navBar.Controls.Add(publisherBtn);
                            this.manageContent.Controls.Add(this.publisherFrm);
                            break;
                        case "8":
                            this.navBar.Controls.Add(refundBtn);
                            this.manageContent.Controls.Add(this.refundFrm);
                            break;
                        case "9":
                            this.navBar.Controls.Add(customerBtn);
                            this.manageContent.Controls.Add(this.customerFrm);
                            break;
                        case "10":
                            this.navBar.Controls.Add(authorBtn);
                            this.manageContent.Controls.Add(this.authorFrm);
                            break;
                        case "11":
                            this.navBar.Controls.Add(seoBtn);
                            this.manageContent.Controls.Add(this.seoFrm);
                            break;
                        case "12":
                            this.navBar.Controls.Add(permissionBtn);
                            this.manageContent.Controls.Add(this.permissionFrm);
                            break;
                        case "13":
                            this.navBar.Controls.Add(positionBtn);
                            this.manageContent.Controls.Add(this.positionFrm);
                            break;
                        case "14":
                            this.navBar.Controls.Add(billBtn);
                            this.manageContent.Controls.Add(this.customerBillFrm);
                            break;
                        case "15":
                            this.navBar.Controls.Add(importBilBtn);
                            this.manageContent.Controls.Add(this.importBillFrm);
                            break;
                        case "16":
                            this.navBar.Controls.Add(accountBtn);
                            this.manageContent.Controls.Add(this.accountFrm);
                            break;
                        case "17":
                            this.navBar.Controls.Add(homeBtn);
                            this.manageContent.Controls.Add(this.statisticFrm);
                            break;
                    }
                }
            }

            GunaAdvenceButton btn = this.navBar.Controls
                .OfType<GunaAdvenceButton>()
                .FirstOrDefault();

            this.contentActive = btn.Name;

            Form frm = this.manageContent.Controls.OfType<Form>().FirstOrDefault();

            btn.Checked = true;

            frm.Show();

            if (currentStaff.Ten.Length > 16)
            {
                string truncatedString = currentStaff.Ten.Substring(0, 16 - 3) + " ...";
                this.staffName.Text = truncatedString;
            }
            else
            {
                this.staffName.Text = currentStaff.Ten;
            }

            this.staffPosition.Text = PositionBUS.Instance.getById(currentStaff.MaChucVu.ToString()).TenChucVu;

            if (this.staffPosition.Text.Length > 26)
            {
                string truncatedString = this.staffPosition.Text.Substring(0, 26 - 3) + " ...";
                this.staffPosition.Text = truncatedString;
            }

            if (currentStaff.GioiTinh == "Nam")
            {
                this.staffImg.Image = BookShop_CNPM.Properties.Resources.male_circle;
            }
            else
            {
                this.staffImg.Image = BookShop_CNPM.Properties.Resources.female;
            }
        }
        private void generateLayout(int staffId,string screenName = "")
        {
            currentStaff = StaffBUS.Instance.getById(staffId.ToString());

            navBar.Controls.Clear();
            manageContent.Controls.Clear();

            authorization = new Authorization(currentStaff.MaChucVu);
			foreach (PermissionDTO item in authorization.getPermissionObject())
			{
				bool isCheckPermission = authorization.checkAuthorize(item.maQuyenHan);

				if (!isCheckPermission)
				{
                    switch (item.maQuyenHan.ToString())
                    {
                        case "1":
                            this.navBar.Controls.Remove(bookBtn);
                            this.manageContent.Controls.Remove(bookFrm);
                            break;
                        case "2":
                            this.navBar.Controls.Remove(staffBtn);
                            this.manageContent.Controls.Remove(staffFrm);
                            break;
                        case "3":
                            this.navBar.Controls.Remove(supplierBtn);
                            this.manageContent.Controls.Remove(supplierFrm);
                            break;
                        case "4":
                            this.navBar.Controls.Remove(bookTypeBtn);
                            this.manageContent.Controls.Remove(bookTypeFrm);
                            break;
                        case "5":
                            this.navBar.Controls.Remove(publisherBtn);
                            this.manageContent.Controls.Remove(publisherFrm);
                            break;
                        case "8":
                            this.navBar.Controls.Remove(refundBtn);
                            this.manageContent.Controls.Remove(refundFrm);
                            break;
                        case "9":
                            this.navBar.Controls.Remove(customerBtn);
                            this.manageContent.Controls.Remove(customerFrm);
                            break;
                        case "10":
                            this.navBar.Controls.Remove(authorBtn);
                            this.manageContent.Controls.Remove(authorFrm);
                            break;
                        case "11":
                            this.navBar.Controls.Remove(seoBtn);
                            this.manageContent.Controls.Remove(seoFrm);
                            break;
                        case "12":
                            this.navBar.Controls.Remove(permissionBtn);
                            this.manageContent.Controls.Remove(permissionFrm);
                            break;
                        case "13":
                            this.navBar.Controls.Remove(positionBtn);
                            this.manageContent.Controls.Remove(positionFrm);
                            break;
                        case "14":
                            this.navBar.Controls.Remove(billBtn);
                            this.manageContent.Controls.Remove(customerBillFrm);
                            break;
                        case "15":
                            this.navBar.Controls.Remove(importBilBtn);
                            this.manageContent.Controls.Remove(importBilBtn);
                            break;
                        case "16":
                            this.navBar.Controls.Remove(accountBtn);
                            this.manageContent.Controls.Remove(accountFrm);
                            break;
                        case "17":
                            this.navBar.Controls.Remove(homeBtn);
                            this.manageContent.Controls.Remove(statisticFrm);
                            break;
                    }
                }
				else
				{
                    switch (item.maQuyenHan.ToString())
                    {
                        case "1":
                            this.navBar.Controls.Add(bookBtn);
                            this.manageContent.Controls.Add(this.bookFrm);
                            break;
                        case "2":
                            this.navBar.Controls.Add(staffBtn);
                            this.manageContent.Controls.Add(this.staffFrm);
                            break;
                        case "3":
                            this.navBar.Controls.Add(supplierBtn);
                            this.manageContent.Controls.Add(this.supplierFrm);
                            break;
                        case "4":
                            this.navBar.Controls.Add(bookTypeBtn);
                            this.manageContent.Controls.Add(this.bookTypeFrm);
                            break;
                        case "5":
                            this.navBar.Controls.Add(publisherBtn);
                            this.manageContent.Controls.Add(this.publisherFrm);
                            break;
                        case "8":
                            this.navBar.Controls.Add(refundBtn);
                            this.manageContent.Controls.Add(this.refundFrm);
                            break;
                        case "9":
                            this.navBar.Controls.Add(customerBtn);
                            this.manageContent.Controls.Add(this.customerFrm);
                            break;
                        case "10":
                            this.navBar.Controls.Add(authorBtn);
                            this.manageContent.Controls.Add(this.authorFrm);
                            break;
                        case "11":
                            this.navBar.Controls.Add(seoBtn);
                            this.manageContent.Controls.Add(this.seoFrm);
                            break;
                        case "12":
                            this.navBar.Controls.Add(permissionBtn);
                            this.manageContent.Controls.Add(this.permissionFrm);
                            break;
                        case "13":
                            this.navBar.Controls.Add(positionBtn);
                            this.manageContent.Controls.Add(this.positionFrm);
                            break;
                        case "14":
                            this.navBar.Controls.Add(billBtn);
                            this.manageContent.Controls.Add(this.customerBillFrm);
                            break;
                        case "15":
                            this.navBar.Controls.Add(importBilBtn);
                            this.manageContent.Controls.Add(this.importBillFrm);
                            break;
                        case "16":
                            this.navBar.Controls.Add(accountBtn);
                            this.manageContent.Controls.Add(this.accountFrm);
                            break;
                        case "17":
                            this.navBar.Controls.Add(homeBtn);
                            this.manageContent.Controls.Add(this.statisticFrm);
                            break;
                    }
                }  
			}

		}
		private void homeBtn_Click(object sender, EventArgs e)
        {
            if (!contentActive.Equals("homeBtn")) {
                this.contentActive = "homeBtn";

                this.homeBtn.Checked = true;

                this.bookBtn.Checked = false;
                this.authorBtn.Checked = false;
                this.bookTypeBtn.Checked = false;
                this.customerBtn.Checked = false;
                this.staffBtn.Checked = false;
                this.supplierBtn.Checked = false;
                this.importBilBtn.Checked = false;
                this.billBtn.Checked = false;
                this.seoBtn.Checked = false;
                this.publisherBtn.Checked = false;
                this.accountBtn.Checked = false;
                this.positionBtn.Checked = false;
                this.permissionBtn.Checked = false;
                this.refundBtn.Checked = false;

                this.statisticFrm.Show();

                this.bookFrm.Hide();
                this.authorFrm.Hide();
                this.bookTypeFrm.Hide();
                this.customerFrm.Hide();
                this.staffFrm.Hide();
                this.supplierFrm.Hide();
                this.importBillFrm.Hide();
                this.customerBillFrm.Hide();
                this.seoFrm.Hide();
                this.publisherFrm.Hide();
                this.accountFrm.Hide();
                this.positionFrm.Hide();
                this.permissionFrm.Hide();
                this.refundFrm.Hide();
            }
        }

        private void bookBtn_Click(object sender, EventArgs e)
        {
            if (!contentActive.Equals("bookBtn"))
            {
                this.contentActive = "bookBtn";

                this.bookBtn.Checked = true;

                this.homeBtn.Checked = false;
                this.authorBtn.Checked = false;
                this.bookTypeBtn.Checked = false;
                this.customerBtn.Checked = false;
                this.staffBtn.Checked = false;
                this.supplierBtn.Checked = false;
                this.importBilBtn.Checked = false;
                this.billBtn.Checked = false;
                this.seoBtn.Checked = false;
                this.publisherBtn.Checked = false;
                this.accountBtn.Checked = false;
                this.positionBtn.Checked = false;
                this.permissionBtn.Checked = false;
                this.refundBtn.Checked = false;

                this.bookFrm.Show();

                this.statisticFrm.Hide();
                this.authorFrm.Hide();
                this.bookTypeFrm.Hide();
                this.customerFrm.Hide();
                this.staffFrm.Hide();
                this.supplierFrm.Hide();
                this.importBillFrm.Hide();
                this.customerBillFrm.Hide();
                this.seoFrm.Hide();
                this.publisherFrm.Hide();
                this.accountFrm.Hide();
                this.positionFrm.Hide();
                this.permissionFrm.Hide();
                this.refundFrm.Hide();
            }
		}

        private void authorBtn_Click(object sender, EventArgs e)
        {
            if (!contentActive.Equals("authorBtn"))
            {
                this.contentActive = "authorBtn";

                this.authorBtn.Checked = true;

                this.homeBtn.Checked = false;
                this.bookBtn.Checked = false;
                this.bookTypeBtn.Checked = false;
                this.customerBtn.Checked = false;
                this.staffBtn.Checked = false;
                this.supplierBtn.Checked = false;
                this.importBilBtn.Checked = false;
                this.billBtn.Checked = false;
                this.seoBtn.Checked = false;
                this.publisherBtn.Checked = false;
                this.accountBtn.Checked = false;
                this.positionBtn.Checked = false;
                this.permissionBtn.Checked = false;
                this.refundBtn.Checked = false;

                this.authorFrm.Show();

                this.bookFrm.Hide();
                this.statisticFrm.Hide();
                this.bookTypeFrm.Hide();
                this.customerFrm.Hide();
                this.staffFrm.Hide();
                this.supplierFrm.Hide();
                this.importBillFrm.Hide();
                this.customerBillFrm.Hide();
                this.seoFrm.Hide();
                this.publisherFrm.Hide();
                this.accountFrm.Hide();
                this.positionFrm.Hide();
                this.permissionFrm.Hide();
                this.refundFrm.Hide();
            }
        }

        private void bookTypeBtn_Click(object sender, EventArgs e)
        {
            if (!contentActive.Equals("bookTypeBtn"))
            {
                this.contentActive = "bookTypeBtn";

                this.bookTypeBtn.Checked = true;

                this.homeBtn.Checked = false;
                this.bookBtn.Checked = false;
                this.authorBtn.Checked = false;
                this.customerBtn.Checked = false;
                this.staffBtn.Checked = false;
                this.supplierBtn.Checked = false;
                this.importBilBtn.Checked = false;
                this.billBtn.Checked = false;
                this.seoBtn.Checked = false;
                this.publisherBtn.Checked = false;
                this.accountBtn.Checked = false;
                this.positionBtn.Checked = false;
                this.permissionBtn.Checked = false;
                this.refundBtn.Checked = false;

                this.bookTypeFrm.Show();

                this.bookFrm.Hide();
                this.authorFrm.Hide();
                this.statisticFrm.Hide();
                this.customerFrm.Hide();
                this.staffFrm.Hide();
                this.supplierFrm.Hide();
                this.importBillFrm.Hide();
                this.customerBillFrm.Hide();
                this.seoFrm.Hide();
                this.publisherFrm.Hide();
                this.accountFrm.Hide();
                this.positionFrm.Hide();
                this.permissionFrm.Hide();
                this.refundFrm.Hide();
            }
        }

        private void customerBtn_Click(object sender, EventArgs e)
        {
            Console.WriteLine("!@313132");

            if (!contentActive.Equals("customerBtn"))
            {
                this.contentActive = "customerBtn";

                this.customerBtn.Checked = true;

                this.homeBtn.Checked = false;
                this.bookBtn.Checked = false;
                this.authorBtn.Checked = false;
                this.bookTypeBtn.Checked = false;
                this.staffBtn.Checked = false;
                this.supplierBtn.Checked = false;
                this.importBilBtn.Checked = false;
                this.billBtn.Checked = false;
                this.seoBtn.Checked = false;
                this.publisherBtn.Checked = false;
                this.accountBtn.Checked = false;
                this.positionBtn.Checked = false;
                this.permissionBtn.Checked = false;
                this.refundBtn.Checked = false;

                this.customerFrm.Show();

                this.bookFrm.Hide();
                this.authorFrm.Hide();
                this.bookTypeFrm.Hide();
                this.statisticFrm.Hide();
                this.staffFrm.Hide();
                this.supplierFrm.Hide();
                this.importBillFrm.Hide();
                this.customerBillFrm.Hide();
                this.seoFrm.Hide();
                this.publisherFrm.Hide();
                this.accountFrm.Hide();
                this.positionFrm.Hide();
                this.permissionFrm.Hide();
                this.refundFrm.Hide();
            }
        }

        private void staffBtn_Click(object sender, EventArgs e)
        {
            if (!contentActive.Equals("staffBtn"))
            {
                this.contentActive = "staffBtn";

                this.staffBtn.Checked = true;

                this.homeBtn.Checked = false;
                this.bookBtn.Checked = false;
                this.authorBtn.Checked = false;
                this.bookTypeBtn.Checked = false;
                this.customerBtn.Checked = false;
                this.supplierBtn.Checked = false;
                this.importBilBtn.Checked = false;
                this.billBtn.Checked = false;
                this.seoBtn.Checked = false;
                this.publisherBtn.Checked = false;
                this.accountBtn.Checked = false;
                this.positionBtn.Checked = false;
                this.permissionBtn.Checked = false;
                this.refundBtn.Checked = false;

                this.staffFrm.Show();

                this.bookFrm.Hide();
                this.authorFrm.Hide();
                this.bookTypeFrm.Hide();
                this.customerFrm.Hide();
                this.statisticFrm.Hide();
                this.supplierFrm.Hide();
                this.importBillFrm.Hide();
                this.customerBillFrm.Hide();
                this.seoFrm.Hide();
                this.publisherFrm.Hide();
                this.accountFrm.Hide();
                this.positionFrm.Hide();
                this.permissionFrm.Hide();
                this.refundFrm.Hide();
            }
        }

        private void supplierBtn_Click(object sender, EventArgs e)
        {
            if (!contentActive.Equals("supplierBtn"))
            {
                this.contentActive = "supplierBtn";

                this.supplierBtn.Checked = true;

                this.homeBtn.Checked = false;
                this.bookBtn.Checked = false;
                this.authorBtn.Checked = false;
                this.bookTypeBtn.Checked = false;
                this.customerBtn.Checked = false;
                this.staffBtn.Checked = false;
                this.importBilBtn.Checked = false;
                this.billBtn.Checked = false;
                this.seoBtn.Checked = false;
                this.publisherBtn.Checked = false;
                this.accountBtn.Checked = false;
                this.positionBtn.Checked = false;
                this.permissionBtn.Checked = false;
                this.refundBtn.Checked = false;

                this.supplierFrm.Show();

                this.bookFrm.Hide();
                this.authorFrm.Hide();
                this.bookTypeFrm.Hide();
                this.customerFrm.Hide();
                this.staffFrm.Hide();
                this.statisticFrm.Hide();
                this.importBillFrm.Hide();
                this.customerBillFrm.Hide();
                this.seoFrm.Hide();
                this.publisherFrm.Hide();
                this.accountFrm.Hide();
                this.positionFrm.Hide();
                this.permissionFrm.Hide();
                this.refundFrm.Hide();
            }
        }

        private void importBilBtn_Click(object sender, EventArgs e)
        {
            if (!contentActive.Equals("importBilBtn"))
            {
                this.contentActive = "importBilBtn";

                this.importBilBtn.Checked = true;

                this.homeBtn.Checked = false;
                this.bookBtn.Checked = false;
                this.authorBtn.Checked = false;
                this.bookTypeBtn.Checked = false;
                this.customerBtn.Checked = false;
                this.staffBtn.Checked = false;
                this.supplierBtn.Checked = false;
                this.billBtn.Checked = false;
                this.seoBtn.Checked = false;
                this.publisherBtn.Checked = false;
                this.accountBtn.Checked = false;
                this.positionBtn.Checked = false;
                this.permissionBtn.Checked = false;
                this.refundBtn.Checked = false;

                this.importBillFrm.Show();

                this.bookFrm.Hide();
                this.authorFrm.Hide();
                this.bookTypeFrm.Hide();
                this.customerFrm.Hide();
                this.staffFrm.Hide();
                this.supplierFrm.Hide();
                this.statisticFrm.Hide();
                this.customerBillFrm.Hide();
                this.seoFrm.Hide();
                this.publisherFrm.Hide();
                this.accountFrm.Hide();
                this.positionFrm.Hide();
                this.permissionFrm.Hide();
                this.refundFrm.Hide();
            }
        }

        private void billBtn_Click(object sender, EventArgs e)
        {
            if (!contentActive.Equals("billBtn"))
            {
                this.contentActive = "billBtn";

                this.billBtn.Checked = true;

                this.homeBtn.Checked = false;
                this.bookBtn.Checked = false;
                this.authorBtn.Checked = false;
                this.bookTypeBtn.Checked = false;
                this.customerBtn.Checked = false;
                this.staffBtn.Checked = false;
                this.supplierBtn.Checked = false;
                this.importBilBtn.Checked = false;
                this.seoBtn.Checked = false;
                this.publisherBtn.Checked = false;
                this.accountBtn.Checked = false;
                this.positionBtn.Checked = false;
                this.permissionBtn.Checked = false;
                this.refundBtn.Checked = false;

                this.customerBillFrm.Show();

                this.bookFrm.Hide();
                this.authorFrm.Hide();
                this.bookTypeFrm.Hide();
                this.customerFrm.Hide();
                this.staffFrm.Hide();
                this.supplierFrm.Hide();
                this.importBillFrm.Hide();
                this.statisticFrm.Hide();
                this.seoFrm.Hide();
                this.publisherFrm.Hide();
                this.accountFrm.Hide();
                this.positionFrm.Hide();
                this.permissionFrm.Hide();
                this.refundFrm.Hide();
            }
        }

        private void seoBtn_Click(object sender, EventArgs e)
        {
            if (!contentActive.Equals("seoBtn"))
            {
                this.contentActive = "seoBtn";

                this.seoBtn.Checked = true;

                this.homeBtn.Checked = false;
                this.bookBtn.Checked = false;
                this.authorBtn.Checked = false;
                this.bookTypeBtn.Checked = false;
                this.customerBtn.Checked = false;
                this.staffBtn.Checked = false;
                this.supplierBtn.Checked = false;
                this.importBilBtn.Checked = false;
                this.billBtn.Checked = false;
                this.publisherBtn.Checked = false;
                this.accountBtn.Checked = false;
                this.positionBtn.Checked = false;
                this.permissionBtn.Checked = false;
                this.refundBtn.Checked = false;

                this.seoFrm.Show();

                this.bookFrm.Hide();
                this.authorFrm.Hide();
                this.bookTypeFrm.Hide();
                this.customerFrm.Hide();
                this.staffFrm.Hide();
                this.supplierFrm.Hide();
                this.importBillFrm.Hide();
                this.customerBillFrm.Hide();
                this.statisticFrm.Hide();
                this.publisherFrm.Hide();
                this.accountFrm.Hide();
                this.positionFrm.Hide();
                this.permissionFrm.Hide();
                this.refundFrm.Hide();
			}
		}

        private void publisherBtn_Click(object sender, EventArgs e)
        {
            if (!contentActive.Equals("publisherBtn"))
            {
                this.contentActive = "publisherBtn";

                this.publisherBtn.Checked = true;

                this.homeBtn.Checked = false;
                this.bookBtn.Checked = false;
                this.authorBtn.Checked = false;
                this.bookTypeBtn.Checked = false;
                this.customerBtn.Checked = false;
                this.staffBtn.Checked = false;
                this.supplierBtn.Checked = false;
                this.importBilBtn.Checked = false;
                this.billBtn.Checked = false;
                this.seoBtn.Checked = false;
                this.accountBtn.Checked = false;
                this.positionBtn.Checked = false;
                this.permissionBtn.Checked = false;
                this.refundBtn.Checked = false;

                this.publisherFrm.Show();

                this.bookFrm.Hide();
                this.authorFrm.Hide();
                this.bookTypeFrm.Hide();
                this.customerFrm.Hide();
                this.staffFrm.Hide();
                this.supplierFrm.Hide();
                this.importBillFrm.Hide();
                this.customerBillFrm.Hide();
                this.seoFrm.Hide();
                this.statisticFrm.Hide();
                this.accountFrm.Hide();
                this.positionFrm.Hide();
                this.permissionFrm.Hide();
                this.refundFrm.Hide();
			}
        }

        private void accountBtn_Click(object sender, EventArgs e)
        {
            if (!contentActive.Equals("accountBtn"))
            {
                this.contentActive = "accountBtn";

                this.accountBtn.Checked = true;

                this.homeBtn.Checked = false;
                this.bookBtn.Checked = false;
                this.authorBtn.Checked = false;
                this.bookTypeBtn.Checked = false;
                this.customerBtn.Checked = false;
                this.staffBtn.Checked = false;
                this.supplierBtn.Checked = false;
                this.importBilBtn.Checked = false;
                this.billBtn.Checked = false;
                this.seoBtn.Checked = false;
                this.publisherBtn.Checked = false;
                this.positionBtn.Checked = false;
                this.permissionBtn.Checked = false;
                this.refundBtn.Checked = false;

                this.accountFrm.Show();

                this.bookFrm.Hide();
                this.authorFrm.Hide();
                this.bookTypeFrm.Hide();
                this.customerFrm.Hide();
                this.staffFrm.Hide();
                this.supplierFrm.Hide();
                this.importBillFrm.Hide();
                this.customerBillFrm.Hide();
                this.seoFrm.Hide();
                this.publisherFrm.Hide();
                this.statisticFrm.Hide();
                this.positionFrm.Hide();
                this.permissionFrm.Hide();
                this.refundFrm.Hide();
			}
        }

        private void permissionBtn_Click(object sender, EventArgs e)
        {
            if (!contentActive.Equals("permissionBtn"))
            {
                this.contentActive = "permissionBtn";

                this.permissionBtn.Checked = true;

                this.homeBtn.Checked = false;
                this.bookBtn.Checked = false;
                this.authorBtn.Checked = false;
                this.bookTypeBtn.Checked = false;
                this.customerBtn.Checked = false;
                this.staffBtn.Checked = false;
                this.supplierBtn.Checked = false;
                this.importBilBtn.Checked = false;
                this.billBtn.Checked = false;
                this.seoBtn.Checked = false;
                this.publisherBtn.Checked = false;
                this.positionBtn.Checked = false;
                this.accountBtn.Checked = false;
                this.refundBtn.Checked = false;

                this.permissionFrm.Show();

                this.bookFrm.Hide();
                this.authorFrm.Hide();
                this.bookTypeFrm.Hide();
                this.customerFrm.Hide();
                this.staffFrm.Hide();
                this.supplierFrm.Hide();
                this.importBillFrm.Hide();
                this.customerBillFrm.Hide();
                this.seoFrm.Hide();
                this.publisherFrm.Hide();
                this.statisticFrm.Hide();
                this.positionFrm.Hide();
                this.accountFrm.Hide();
                this.refundFrm.Hide();
			}
        }

        private void positionBtn_Click(object sender, EventArgs e)
        {
            if (!contentActive.Equals("positionBtn"))
            {
                this.contentActive = "positionBtn";

                this.positionBtn.Checked = true;

                this.homeBtn.Checked = false;
                this.bookBtn.Checked = false;
                this.authorBtn.Checked = false;
                this.bookTypeBtn.Checked = false;
                this.customerBtn.Checked = false;
                this.staffBtn.Checked = false;
                this.supplierBtn.Checked = false;
                this.importBilBtn.Checked = false;
                this.billBtn.Checked = false;
                this.seoBtn.Checked = false;
                this.publisherBtn.Checked = false;
                this.refundBtn.Checked = false;
                this.accountBtn.Checked = false;
                this.permissionBtn.Checked = false;

                this.positionFrm.Show();

                this.bookFrm.Hide();
                this.authorFrm.Hide();
                this.bookTypeFrm.Hide();
                this.customerFrm.Hide();
                this.staffFrm.Hide();
                this.supplierFrm.Hide();
                this.importBillFrm.Hide();
                this.customerBillFrm.Hide();
                this.seoFrm.Hide();
                this.publisherFrm.Hide();
                this.statisticFrm.Hide();
                
                this.accountFrm.Hide();
                this.permissionFrm.Hide();
                this.refundFrm.Hide();
			}
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LoginGUI.Instance.Close();
        }

        private void ManagerGUI_Load(object sender, EventArgs e)
        {
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            MenuGUI menu = new MenuGUI(currentStaff.Ma);

            menu.Show();
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void staffPosition_Click(object sender, EventArgs e)
        {

        }

        private void refundBtn_Click(object sender, EventArgs e)
        {
            if (!contentActive.Equals("refundBtn"))
            {
                this.contentActive = "refundBtn";

                this.refundBtn.Checked = true;

                this.positionBtn.Checked = false;
                this.homeBtn.Checked = false;
                this.bookBtn.Checked = false;
                this.authorBtn.Checked = false;
                this.bookTypeBtn.Checked = false;
                this.customerBtn.Checked = false;
                this.staffBtn.Checked = false;
                this.supplierBtn.Checked = false;
                this.importBilBtn.Checked = false;
                this.billBtn.Checked = false;
                this.seoBtn.Checked = false;
                this.publisherBtn.Checked = false;
                this.accountBtn.Checked = false;
                this.permissionBtn.Checked = false;

                this.refundFrm.Show();

                this.positionFrm.Hide();
                this.bookFrm.Hide();
                this.authorFrm.Hide();
                this.bookTypeFrm.Hide();
                this.customerFrm.Hide();
                this.staffFrm.Hide();
                this.supplierFrm.Hide();
                this.importBillFrm.Hide();
                this.customerBillFrm.Hide();
                this.seoFrm.Hide();
                this.publisherFrm.Hide();
                this.statisticFrm.Hide();
                this.accountFrm.Hide();
                this.permissionFrm.Hide();
            }
        }
    }
}
