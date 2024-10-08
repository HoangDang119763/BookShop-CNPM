﻿using System;
using System.Data;

namespace BookShop_CNPM.DTO
{
    public class CustomerRefundBillDTO : RefundBillDTO
    {
        public int MaDonKhachHang { get; set; }

        public CustomerRefundBillDTO(int maPhieu, decimal tongTien, string liDo, int maDonKhachHang, DateTime ngayLap, int maNhanVien)
            :base(maPhieu, tongTien, liDo, ngayLap, maNhanVien)
        {
            this.MaDonKhachHang = maDonKhachHang;
        }

        public CustomerRefundBillDTO(DataRow row){
            this.MaPhieu = (int)row["maPhieuTraBanHang"];
            this.MaDonKhachHang = (int)row["maDonKhachHang"];
            this.MaNhanVien = (int)row["maNhanVien"];
            this.TongTien = Convert.ToDecimal(row["tongTien"]);
            this.LiDo = row["liDo"].ToString();
            this.NgayLap = (DateTime)row["ngayLap"];
        }
    }
}
