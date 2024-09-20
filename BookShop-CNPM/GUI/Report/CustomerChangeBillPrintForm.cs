using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BookShop_CNPM.BUS;
using BookShop_CNPM.DTO;
using Microsoft.Reporting.WinForms;
using static Guna.UI2.Native.WinApi;

namespace BookShop_CNPM.GUI.Report
{
    public partial class CustomerChangeBillPrintForm : Form
    {
        private CustomerChangeBillDTO customerChangeBill;

        public CustomerChangeBillPrintForm(int maDonDoiHang)
        {
            InitializeComponent();
            this.customerChangeBill = CustomerChangeBillBUS.Instance.getById(maDonDoiHang.ToString());
        }

        private void CustomerChangeBillPrintForm_Load(object sender, EventArgs e)
        {
            try
            {
                StaffDTO staff = StaffBUS.Instance.getById(customerChangeBill.MaNhanVien.ToString());

                List<CustomerChangeBillDetailDTO> customerChangeBillDetailList = CustomerChangeBillBUS.Instance.getCustomerChangeBillDetailList(customerChangeBill.MaPhieu.ToString());

                CustomerBillDTO customerBill = CustomerBillBUS.Instance.getById(customerChangeBill.MaDonKhachHang.ToString());

                CustomerDTO customer = CustomerBUS.Instance.getById(customerBill.MaKhachHang.ToString());

                System.Data.DataTable dataTable = this.billDetailDataset.Tables[0];
                BookDTO book;
                BookDTO book2;
                int count = 1;
                foreach (CustomerChangeBillDetailDTO customerChangeBillDetail in customerChangeBillDetailList)
                {
                    book = BookBUS.Instance.getById(customerChangeBillDetail.SachCanDoi.ToString());
                    book2 = BookBUS.Instance.getById(customerChangeBillDetail.SachMuonDoi.ToString());

                    dataTable.Rows.Add(
                        count,
                        book2.TenSach.ToString(),
                        book2.TenSach.ToString(),
                        customerChangeBillDetail.soLuong
                    );

                    count++;
                }

                this.bindingSource1.DataSource = dataTable;

                Microsoft.Reporting.WinForms.ReportParameter[] p = new Microsoft.Reporting.WinForms.ReportParameter[]
                {
                    new Microsoft.Reporting.WinForms.ReportParameter("pInvoiceCode", customerChangeBill.MaPhieu.ToString()),
                    new Microsoft.Reporting.WinForms.ReportParameter("pEmployee", staff.Ten.ToString()),
                    new Microsoft.Reporting.WinForms.ReportParameter("pDate", customerChangeBill.NgayLap.GetDateTimeFormats()[0].ToString()),
                    new Microsoft.Reporting.WinForms.ReportParameter("pSellInvoice", customerChangeBill.MaDonKhachHang.ToString()),
                    new Microsoft.Reporting.WinForms.ReportParameter("pCustomerName", customer.Ten),
                };

                ReportDataSource reportDataSource = new ReportDataSource("DataSet1", dataTable);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                this.reportViewer1.LocalReport.SetParameters(p);
                this.reportViewer1.RefreshReport();
            }
            catch (Exception er)
            {

                Console.WriteLine(er);
            }
        }
    }
}
