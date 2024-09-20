using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BookShop_CNPM.BUS;
using BookShop_CNPM.DTO;
using Microsoft.Reporting.WinForms;

namespace BookShop_CNPM.GUI.Report
{
    public partial class ImportChangeBillPrintForm : Form
    {
        private ImportChangeBillDTO importChangeBill;
        public ImportChangeBillPrintForm(int maDonDoiHang)
        {
            InitializeComponent();
            this.importChangeBill = ImportChangeBillBUS.Instance.getById(maDonDoiHang.ToString());
        }

        private void ImportChangeBillPrintForm_Load(object sender, EventArgs e)
        {
            try
            {
                StaffDTO staff = StaffBUS.Instance.getById(importChangeBill.MaNhanVien.ToString());

                List<ImportChangeBillDetailDTO> importChangeBillDetailList = ImportChangeBillBUS.Instance.getImportChangeBillDetailList(importChangeBill.MaPhieu.ToString());

                ImportBillDTO importBill = ImportBillBUS.Instance.getById(importChangeBill.MaDonNhapHang.ToString());

                SupplierDTO supplier = SupplierBUS.Instance.getById(importBill.MaNhaCungCap.ToString());

                System.Data.DataTable dataTable = this.billDetailDataset.Tables[0];
                BookDTO book;
                BookDTO book2;
                int count = 1;
                foreach (ImportChangeBillDetailDTO importChangeBillDetail in importChangeBillDetailList)
                {
                    book = BookBUS.Instance.getById(importChangeBillDetail.SachCanDoi.ToString());
                    book2 = BookBUS.Instance.getById(importChangeBillDetail.SachMuonDoi.ToString());
                    dataTable.Rows.Add(
                        count,
                        book.TenSach.ToString(),
                        book2.TenSach.ToString(),
                        importChangeBillDetail.soLuong
                    );

                    count++;
                }

                this.bindingSource1.DataSource = dataTable;

                Microsoft.Reporting.WinForms.ReportParameter[] p = new Microsoft.Reporting.WinForms.ReportParameter[]
                {
                    new Microsoft.Reporting.WinForms.ReportParameter("pInvoiceCode", importChangeBill.MaPhieu.ToString()),
                    new Microsoft.Reporting.WinForms.ReportParameter("pEmployee", staff.Ten.ToString()),
                    new Microsoft.Reporting.WinForms.ReportParameter("pDate", importChangeBill.NgayLap.GetDateTimeFormats()[0].ToString()),
                    new Microsoft.Reporting.WinForms.ReportParameter("pImportInvoice", importChangeBill.MaDonNhapHang.ToString()),
                    new Microsoft.Reporting.WinForms.ReportParameter("pSupplier", supplier.TenNhaCungCap),
                };

                ReportDataSource reportDataSource = new ReportDataSource("DataSet1", dataTable);
                reportViewer2.LocalReport.DataSources.Clear();
                reportViewer2.LocalReport.DataSources.Add(reportDataSource);
                this.reportViewer2.LocalReport.SetParameters(p);
                this.reportViewer2.RefreshReport();
            }
            catch (Exception er)
            {

                Console.WriteLine(er);
            }
        }
    }
}
