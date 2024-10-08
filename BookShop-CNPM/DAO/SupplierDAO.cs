using BookShop_CNPM.DTO;
using MySql.Data.MySqlClient;
using System.Data;
using System;

namespace BookShop_CNPM.DAO
{
    public class SupplierDAO : IDAO<SupplierDTO>
    {
        private static SupplierDAO instance;

        public static SupplierDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SupplierDAO();
                }

                return SupplierDAO.instance;
            }
            private set { SupplierDAO.instance = value; }
        }

        public DataTable getAll()
        {
            return DataProvider.Instance.ExecuteQuery("select * from nhacungcap where hienThi=1;");
        }

        public bool checkDuplicateName(string value)
        {
            DataTable dataTable = DataProvider.Instance.ExecuteQuery("select * from nhacungcap WHERE LOWER(tenNhaCungCap)=LOWER(@tenNhaCungCap) and hienThi=1;",
                new MySqlParameter[] {
                    new MySqlParameter("@tenNhaCungCap", value.Trim().ToLower())
                }
            );

            if (dataTable.Rows.Count <= 0) return false;

            return true;
        }

        public bool checkDuplicateName(string value, int id)
        {
            DataTable dataTable = DataProvider.Instance.ExecuteQuery("select * from nhacungcap WHERE  LOWER(tenNhaCungCap)=LOWER(@tenNhaCungCap) and maNhaCungCap!=@id and hienThi=1;",
                new MySqlParameter[] {
                    new MySqlParameter("@tenNhaCungCap", value.Trim().ToLower()),
                    new MySqlParameter("@id", id)
                }
            );

            if (dataTable.Rows.Count <= 0) return false;

            return true;
        }

        public SupplierDTO getById(string id)
        {
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(
                "SELECT * FROM nhacungcap WHERE maNhaCungCap=@maNhaCungCap",
                new MySqlParameter[] {
                    new MySqlParameter("@maNhaCungCap", id)
                }
            );

            if (dataTable.Rows.Count <= 0) return null;

            SupplierDTO account = new SupplierDTO(dataTable.Rows[0]);

            return account;
        }

        public DataTable searchData(string value)
        {
            string sql = $@"SELECT * FROM nhacungcap WHERE (maNhaCungCap LIKE @maNhaCungCap OR tenNhaCungCap LIKE @tenNhaCungCap) and hienThi=1;";

            return DataProvider.Instance.ExecuteQuery(sql,
                new MySqlParameter[] {
                    new MySqlParameter("@maNhaCungCap", "%" + value + "%"),
                    new MySqlParameter("@tenNhaCungCap", "%" + value + "%")
                }
            );
        }

        public bool insert(SupplierDTO data)
        {

            string sql = $@"INSERT INTO nhacungcap (tenNhaCungCap, diaChi, soDienThoai)
                            VALUES (@tenNhaCungCap, @diaChi, @soDienThoai);";

            int rowChanged = DataProvider.Instance.ExecuteNonQuery(sql,
                new MySqlParameter[] {
                    new MySqlParameter("@tenNhaCungCap", data.TenNhaCungCap),
                    new MySqlParameter("@diaChi", data.DiaChi),
                    new MySqlParameter("@soDienThoai", data.SoDienThoai),
                });

            return rowChanged > 0;
        }

        public bool update(SupplierDTO data)
        {
            string sql = $@"UPDATE nhacungcap
                            SET tenNhaCungCap=@tenNhaCungCap, diaChi=@diaChi, soDienThoai=@soDienThoai
                            WHERE maNhaCungCap=@maNhaCungCap;";

            int rowChanged = DataProvider.Instance.ExecuteNonQuery(sql,
                new MySqlParameter[] {
                    new MySqlParameter("@maNhaCungCap", data.MaNhaCungCap),
                    new MySqlParameter("@tenNhaCungCap", data.TenNhaCungCap),
                    new MySqlParameter("@diaChi", data.DiaChi),
                    new MySqlParameter("@soDienThoai", data.SoDienThoai),
                });

            return rowChanged > 0;
        }

        public bool delete(string id)
        {
            string sql = $@"UPDATE nhacungcap SET hienThi=0 WHERE maNhaCungCap=@maNhaCungCap;";

            int rowChanged = DataProvider.Instance.ExecuteNonQuery(sql,
                new MySqlParameter[] {
                    new MySqlParameter("@maNhaCungCap", id),
                });

            return rowChanged > 0;
        }

		public bool checkDuplicatePhoneNumber(string value)
		{
			DataTable dataTable = DataProvider.Instance.ExecuteQuery("select * from nhacungcap WHERE  soDienThoai = @SoDienThoai and hienThi=1;",
				new MySqlParameter[] {
					new MySqlParameter("@SoDienThoai", value)
				}
			);

			if (dataTable.Rows.Count <= 0) return false;

			return true;
		}

		public bool checkDuplicatePhoneNumber(string value,int id)
		{
			DataTable dataTable = DataProvider.Instance.ExecuteQuery("select * from nhacungcap WHERE  soDienThoai = @SoDienThoai and maNhaCungCap != @MaNhaCungCap and hienThi=1;",
				new MySqlParameter[] {
					new MySqlParameter("@SoDienThoai", value),
                    new MySqlParameter("@MaNhaCungCap",id)
				}
			);

			if (dataTable.Rows.Count <= 0) return false;

			return true;
		}
	}

}
