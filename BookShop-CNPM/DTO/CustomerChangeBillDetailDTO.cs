using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop_CNPM.DTO
{
    public class CustomerChangeBillDetailDTO : ChangeBillDetailDTO
    {
        public CustomerChangeBillDetailDTO() : base()
        { }
        public CustomerChangeBillDetailDTO(
            int MaDon, int SachCanDoi, decimal donGiaSachCanDoi, int SachMuonDoi, decimal donGiaSachMuonDoi, int soLuong
        ) : base(MaDon, SachCanDoi, donGiaSachCanDoi, SachMuonDoi, donGiaSachMuonDoi, soLuong)
        {
        }

        public CustomerChangeBillDetailDTO(DataRow row)
        {
            this.MaDon = (int)row["maPhieuDoiBanHang"];
            this.SachCanDoi = (int)row["maSachCanDoi"]; 
            this.donGiaSachCanDoi = (decimal)row["donGiaSachCanDoi"];
            this.SachMuonDoi = (int)row["maSachMuonDoi"]; 
            this.donGiaSachMuonDoi = (decimal)row["donGiaSachMuonDoi"];
            this.soLuong = (int)row["soLuong"];
        }
    }
}
