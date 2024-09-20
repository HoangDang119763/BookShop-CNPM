using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop_CNPM.DTO
{
    public class ImportChangeBillDetailDTO : ChangeBillDetailDTO
    {
        public ImportChangeBillDetailDTO() : base()
        {
        }

        public ImportChangeBillDetailDTO(
            int MaDon, int SachCanDoi, decimal donGiaSachCanDoi, int SachMuonDoi, decimal donGiaSachMuonDoi, int soLuong
        ) : base(MaDon, SachCanDoi, donGiaSachCanDoi, SachMuonDoi, donGiaSachMuonDoi, soLuong)
        {
        }

        public ImportChangeBillDetailDTO(DataRow row)
        {
            this.MaDon = Convert.ToInt32(row["maPhieuDoiNhapHang"].ToString());
            this.SachCanDoi = (int)row["maSachCanDoi"];
            this.donGiaSachCanDoi = Convert.ToDecimal(row["donGiaSachCanDoi"]);
            this.SachMuonDoi = (int)row["maSachMuonDoi"];
            this.donGiaSachMuonDoi = Convert.ToDecimal(row["donGiaSachMuonDoi"]);
            this.soLuong = (int)row["soLuong"];
        }
    }
}
