using BookShop_CNPM.BUS;
using BookShop_CNPM.DTO;
using System;
using System.Collections.Generic;

namespace BookShop_CNPM
{
    public class Authorization
    {
        public int MaChucVu { get; private set; }
        private List<PermissionDTO> permissionObj = new List<PermissionDTO>();

        public Authorization(int maChucVu) {
            this.MaChucVu = maChucVu;

            permissionObj = PermissionBUS.Instance.getAllData();
        }

        public List<PermissionDTO> getPermissionObject()
        {
            return permissionObj;
        }

        public bool checkAuthorize(int maQuyenHan)
        {
            PermissionDTO permission = permissionObj.Find(e => e.maQuyenHan == maQuyenHan);

            if (!permission.TrangThai) return false;

            AuthDetailDTO authDetail = AuthDetailBUS.Instance.getById(this.MaChucVu.ToString(), maQuyenHan.ToString());
            

            if (authDetail == null || !authDetail.TrangThai) return false;
            
            return true;
        }
    }
}
