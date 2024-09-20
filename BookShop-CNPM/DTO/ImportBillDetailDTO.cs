using BookShop_CNPM.BUS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop_CNPM.DTO
{
    public class ImportBillDetailDTO : BillDetailDTO
    {
        public ImportBillDetailDTO() : base()
        {
        }

        public int SoLuongDoiTra {  get; set; }

        public ImportBillDetailDTO(
            int maDonHang, int maSach, int soLuong, decimal donGia
        ) : base(maDonHang, maSach, soLuong, donGia)
        {
        }

        public ImportBillDetailDTO(DataRow row)
        {
            this.MaDon = Convert.ToInt32(row["maDonNhapHang"].ToString());
            this.MaSach = Convert.ToInt32(row["maSach"].ToString());
            this.SoLuong = Convert.ToInt32(row["soLuong"].ToString());
            this.SoLuongDoiTra = Convert.ToInt32(row["soLuongDoiTra"].ToString());
            this.DonGia = Convert.ToDecimal(row["donGia"].ToString());
            this.ThanhTien = this.SoLuong * BookBUS.Instance.getById(row["maSach"].ToString()).GiaNhap;
        }
    }
}
