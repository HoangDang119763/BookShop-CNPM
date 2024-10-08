﻿using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using BookShop_CNPM.BUS;
using BookShop_CNPM.DTO;

namespace BookShop_CNPM.DAO
{
    public class PositionDAO : IDAO<PositionDTO>
    {
        private static PositionDAO instance;

        public static PositionDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PositionDAO();
                }

                return PositionDAO.instance;
            }
            private set { PositionDAO.instance = value; }
        }


        public DataTable getAll()
        {
            return DataProvider.Instance.ExecuteQuery("select * from chucvu where hienThi=1 ");
        } 

        public bool checkDuplicateName(string value)
        {
            DataTable dataTable = DataProvider.Instance.ExecuteQuery("select * from chucvu WHERE LOWER(tenChucVu)= LOWER(@tenChucVu) and hienThi=1;",
                new MySqlParameter[] {
                    new MySqlParameter("@tenChucVu", value.Trim().ToLower())
                }
            );

            if (dataTable.Rows.Count <= 0) return false;

            return true;
        }

        public bool checkDuplicateName(string value, int id)
        {
            DataTable dataTable = DataProvider.Instance.ExecuteQuery("select * from chucvu WHERE LOWER(tenChucVu)= LOWER(@tenChucVu) and maChucVu!=@id and hienThi=1;",
                new MySqlParameter[] {
                    new MySqlParameter("@tenChucVu", value.Trim().ToLower()),
                    new MySqlParameter("@id", id)
                }
            );

            if (dataTable.Rows.Count <= 0) return false;

            return true;
        }

        public PositionDTO getById(string id)
        {
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(
                "SELECT * FROM chucvu WHERE maChucVu=@maChucVu;",
                new MySqlParameter[] {
                    new MySqlParameter("@maChucVu", id)
                }
            );

            if (dataTable.Rows.Count <= 0) return null;

            PositionDTO account = new PositionDTO(dataTable.Rows[0]);

            return account;
        }
        public DataTable searchData(string value)
        {
            string sql = $@"SELECT * FROM chucvu WHERE (maChucVu LIKE @maChucVu OR tenChucVu LIKE @tenChucVu) and hienThi=1;";

            return DataProvider.Instance.ExecuteQuery(sql,
                new MySqlParameter[] {
                    new MySqlParameter("@maChucVu", "%" + value + "%"),
                    new MySqlParameter("@tenChucVu", "%" + value + "%")
                }
            );
        }

        public bool insert(PositionDTO data)
        {

            string sql = $@"INSERT INTO chucvu (tenChucVu, heSoLuong, moTa, trangThai)
                            VALUES (@tenChucVu, @heSoLuong, @moTa, @trangThai);";

            int rowChanged = DataProvider.Instance.ExecuteNonQuery(sql,
                new MySqlParameter[] {
                    new MySqlParameter("@tenChucVu", data.TenChucVu),
                    new MySqlParameter("@moTa", data.MoTa),
                    new MySqlParameter("@trangThai", data.TrangThai),
                    new MySqlParameter("@heSoLuong", data.HeSoLuong),
                });

            if (rowChanged > 0)
            {
                sql = "SELECT * FROM chucvu ORDER BY maChucVu DESC LIMIT 1;";

                DataTable dataTable = DataProvider.Instance.ExecuteQuery(sql);

                if (dataTable.Rows.Count <= 0) return false;

                PositionDTO position = new PositionDTO(dataTable.Rows[0]);

                List<PermissionDTO> permissionList = PermissionBUS.Instance.getAllData();

                sql = $@"INSERT INTO chitietphanquyen (maChucVu, maQuyenHan)
                            VALUES (@maChucVu, @maQuyenHan);";

                foreach (PermissionDTO permission in permissionList)
                {
                    DataProvider.Instance.ExecuteNonQuery(sql,
                        new MySqlParameter[] {
                            new MySqlParameter("@maChucVu", position.MaChucVu),
                            new MySqlParameter("@maQuyenHan", permission.maQuyenHan),
                        });
                }
            }

            return rowChanged > 0;
        }

        public bool update(PositionDTO data)
        {
            string sql = $@"UPDATE chucvu
                            SET tenChucVu=@tenChucVu, heSoLuong=@heSoLuong, moTa=@moTa, trangThai=@trangThai
                            WHERE maChucVu=@maChucVu;";

            int rowChanged = DataProvider.Instance.ExecuteNonQuery(sql,
                new MySqlParameter[] {
                    new MySqlParameter("@maChucVu", data.MaChucVu),
                    new MySqlParameter("@tenChucVu", data.TenChucVu),
                    new MySqlParameter("@heSoLuong", data.HeSoLuong),
                    new MySqlParameter("@moTa", data.MoTa),
                    new MySqlParameter("@trangThai", data.TrangThai),
                });

            return rowChanged > 0;
        }

        public bool delete(string id)
        {
            string sql = $@"UPDATE chucvu SET hienThi = 0 WHERE maChucVu=@maChucVu;";

            int rowChanged = DataProvider.Instance.ExecuteNonQuery(sql,
                new MySqlParameter[] {
                    new MySqlParameter("@maChucVu", id),
                });

            if (rowChanged > 0 )
            {
                AuthDetailBUS.Instance.deleteAllByPositionId(id);
            }

            return rowChanged > 0;
        }
    }
}
