using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop_CNPM.DTO
{
    public class ChangeBillDetailDTO
    {
        
        public int MaDon { get; set; }
        public int SachCanDoi { get; set; }
        public decimal donGiaSachCanDoi { get; set; }
        public int SachMuonDoi { get; set; }
        public decimal donGiaSachMuonDoi { get; set; }
        public int soLuong { get; set; }

        public ChangeBillDetailDTO()
        {
        }

        public ChangeBillDetailDTO(int MaDon, int SachCanDoi, decimal donGiaSachCanDoi, int SachMuonDoi, decimal donGiaSachMuonDoi, int soLuong)
        {
            this.MaDon = MaDon;
            this.SachCanDoi = SachCanDoi;
            this.donGiaSachCanDoi= donGiaSachCanDoi;
            this.SachMuonDoi = SachMuonDoi;
            this.donGiaSachMuonDoi= donGiaSachMuonDoi;
            this.soLuong = soLuong;
        }
    }
}
