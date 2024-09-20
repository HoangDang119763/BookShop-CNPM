using System;
using System.Data;

namespace BookShop_CNPM.DTO
{
    public class ImportRefundBillDTO : RefundBillDTO
    {
        public int MaDonNhapHang { get; set; }

        public ImportRefundBillDTO(int maPhieu, decimal tongTien, string liDo, int maDonNhapHang, DateTime ngayLap, int maNhanVien)
            : base(maPhieu, tongTien, liDo, ngayLap, maNhanVien)
        {
            this.MaDonNhapHang = maDonNhapHang;
        }

        public ImportRefundBillDTO(DataRow row)
        {
            this.MaPhieu = (int)row["maPhieuTraNhapHang"];
            this.MaDonNhapHang = (int)row["maDonNhapHang"];
            this.MaNhanVien = (int)row["maNhanVien"];
            this.TongTien = Convert.ToDecimal(row["tongTien"]);
            this.LiDo = row["liDo"].ToString();
            this.NgayLap = (DateTime)row["ngayLap"];
        }
    }
}
