using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using BookShop_CNPM.DTO;
using BookShop_CNPM.GUI.UserControls;
using Google.Protobuf.WellKnownTypes;
using System.Text.RegularExpressions;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;

namespace BookShop_CNPM.DAO
{
    public class BookDAO : IDAO<BookDTO>
    {
        private static BookDAO instance;

        public static BookDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BookDAO();
                }

                return BookDAO.instance;
            }
            private set { BookDAO.instance = value; }
        }

        private DataTable getBookRemain(DataTable dataTable)
        {
            dataTable.Columns.Add("soLuongConLai");

            foreach (DataRow row in dataTable.Rows)
            {
                DataTable dataTable1 = DataProvider.Instance.ExecuteQuery(
                    "SELECT COUNT(*) as soLuongConLai FROM chitietsach WHERE maSach=@MaSach;",
                    new MySqlParameter[] {
                        new MySqlParameter("@MaSach", row["maSach"])
                    }
                );

                row["soLuongConLai"] = dataTable1.Rows[0]["soLuongConLai"];
            }

            return dataTable;
        }

        public DataTable getAllKeCaXoa() {
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(
                "SELECT * FROM sach"
            );

            return getBookRemain(dataTable);
        }
        public DataTable getAll()
        {
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(
                "SELECT * FROM sach WHERE hienThi = 1;"
            );

            return getBookRemain(dataTable);
        }

        public bool checkDuplicateName(string value)
        {
            DataTable dataTable = DataProvider.Instance.ExecuteQuery("select * from sach WHERE LOWER(tenSach)=LOWER(@tenSach) and hienThi=1;",
                new MySqlParameter[] {
                    new MySqlParameter("@tenSach", value.Trim().ToLower())
                }
            );

            if (dataTable.Rows.Count <= 0) return false;

            return true;
        }

        public bool checkDuplicateName(string value, int id)
        {
            DataTable dataTable = DataProvider.Instance.ExecuteQuery("select * from sach WHERE LOWER(tenSach)=LOWER(@tenSach) and hienThi=1 and maSach!=@id;",
                new MySqlParameter[] {
                    new MySqlParameter("@tenSach", value.Trim().ToLower()),
                    new MySqlParameter("@id", id)
                }
            );

            if (dataTable.Rows.Count <= 0) return false;

            return true;
        }

        public DataTable getAllDataFiltered(int SortMode, string Type, string Author, string Publisher, bool Import)
        {
            string sql = @"SELECT sach.* FROM sach WHERE sach.hienThi = 1";

            // Add filters based on user input
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            if (!Type.Equals("-1") && !Type.Equals("0"))
            {
                sql += " AND sach.maTheLoai = @maTheLoai";
                parameters.Add(new MySqlParameter("@maTheLoai", Type));
            }
            if (!Author.Equals("-1") && !Author.Equals("0"))
            {
                sql += " AND sach.maTacGia = @maTacGia";
                parameters.Add(new MySqlParameter("@maTacGia", Author));
            }

            if (!Publisher.Equals("-1") && !Publisher.Equals("0"))
            {
                sql += " AND sach.maNhaXuatBan = @maNhaXuatBan";
                parameters.Add(new MySqlParameter("@maNhaXuatBan", Publisher));
            }
            switch (SortMode)
            {
                case -1:
                    sql += ";";
                    break;
                case 0:
                    if (Import) // If filtering in Import page
                    {
                        sql += " ORDER BY giaNhap ASC;";
                    }
                    else
                    {
                        sql += " ORDER BY giaBan ASC;";
                    }
                    break;
                case 1:
                    if (Import) // If filtering in Import page
                    {
                        sql += " ORDER BY giaNhap DESC;";
                    }
                    else
                    {
                        sql += " ORDER BY giaBan DESC;";
                    }
                    break;
                case 2:
                    sql += " ORDER BY tenSach ASC;";
                    break;
                case 3:
                    sql += " ORDER BY tenSach DESC;";
                    break;
                default:
                    sql += ";";
                    break;
            }

            // Execute the query with parameters
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(sql, parameters.ToArray());

            // Process the results
            return getBookRemain(dataTable);
        }

        public BookDTO getById(string id)
        {
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(
                "SELECT * FROM sach WHERE maSach=@MaSach;",
                new MySqlParameter[] {
                    new MySqlParameter("@MaSach", id)
                }
            );

            if (dataTable.Rows.Count <= 0) return null;

            DataTable dataTable1 = DataProvider.Instance.ExecuteQuery(
                "SELECT COUNT(*) as soLuongConLai FROM chitietsach WHERE maSach=@MaSach;",
                new MySqlParameter[] {
                    new MySqlParameter("@MaSach", id)
                }
            );

            dataTable.Columns.Add("soLuongConLai");
            dataTable.Rows[0]["soLuongConLai"] = dataTable1.Rows[0]["soLuongConLai"];

            BookDTO book = new BookDTO(dataTable.Rows[0]);

            return book;
        }

/*======*/
        public int getIdByName(string name)
        {
            int id = -1;
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(
                "SELECT * FROM sach WHERE tenSach=@tenSach;",
                new MySqlParameter[] {
                    new MySqlParameter("tenSach", name)
                }
            );

            if (dataTable.Rows.Count > 0)
            {
                id = Convert.ToInt32(dataTable.Rows[0]["maSach"]); // Giả sử cột ID trong bảng là "id"
           
            }
            return id;
        }

        public BookDTO getLatestBook()
		{
			DataTable dataTable = DataProvider.Instance.ExecuteQuery("SELECT * FROM sach order by maSach DESC;");

			if (dataTable.Rows.Count <= 0) return null;

			DataTable dataTable1 = DataProvider.Instance.ExecuteQuery(
				"SELECT COUNT(*) as soLuongConLai FROM chitietsach WHERE maSach=@MaSach;",
				new MySqlParameter[] {
					new MySqlParameter("@MaSach", dataTable.Rows[0]["maSach"].ToString())
				}
			);

			dataTable.Columns.Add("soLuongConLai");
			dataTable.Rows[0]["soLuongConLai"] = dataTable1.Rows[0]["soLuongConLai"];

			BookDTO book = new BookDTO(dataTable.Rows[0]);

			return book;
		}

		public DataTable searchData(string value)
        {
            string sql = $@"SELECT * FROM sach WHERE (maSach LIKE @maSach OR tenSach LIKE @tenSach) AND hienThi = 1;";

            DataTable dataTable = DataProvider.Instance.ExecuteQuery(sql,
                new MySqlParameter[] {
                    new MySqlParameter("@maSach", "%" + value + "%"),
                    new MySqlParameter("@tenSach", "%" + value + "%")
                }
            );
            
            return getBookRemain(dataTable);
        }

        public DataTable searchByAuthor(string value)
        {
            string sql = @"
                SELECT sach.*
                FROM sach
                JOIN tacgia ON sach.maTacGia = tacgia.maTacGia
                WHERE tacgia.tenTacGia LIKE @tenTacGia AND sach.hienThi = 1;
            ";

            DataTable dataTable = DataProvider.Instance.ExecuteQuery(sql,
                new MySqlParameter[] {
                    new MySqlParameter("@tenTacGia", "%" + value + "%"),
                }
            );

            return getBookRemain(dataTable);
        }

        public bool insert(BookDTO data)
        {

            string sql = $@"INSERT INTO sach (tenSach, hinhAnh, maTheLoai, maTacGia, maNhaXuatBan, giaBan, giaNhap)
                            VALUES (@tenSach, @hinhAnh, @maTheLoai, @maTacGia, @maNhaXuatBan, @giaBan, @giaNhap);";

            int rowChanged = DataProvider.Instance.ExecuteNonQuery(sql,
                new MySqlParameter[] {
                    new MySqlParameter("@tenSach", data.TenSach),
                    new MySqlParameter("@hinhAnh", data.HinhAnh),
                    new MySqlParameter("@maTheLoai", data.MaTheLoai),
                    new MySqlParameter("@maTacGia", data.MaTacGia),
                    new MySqlParameter("@maNhaXuatBan", data.MaNhaXuatBan),
                    new MySqlParameter("@giaBan", data.GiaBan),
                    new MySqlParameter("@giaNhap", data.GiaNhap),
                });

            return rowChanged > 0;
        }

        public bool update(BookDTO data)
        {
            string sql = $@"UPDATE sach
                            SET tenSach=@tenSach, hinhAnh=@hinhAnh, maTheLoai=@maTheLoai, maTacGia=@maTacGia, maNhaXuatBan=@maNhaXuatBan, giaBan=@giaBan, giaNhap=@giaNhap
                            WHERE maSach=@maSach;";

            int rowChanged = DataProvider.Instance.ExecuteNonQuery(sql,
                new MySqlParameter[] {
                    new MySqlParameter("@maSach", data.MaSach),
                    new MySqlParameter("@tenSach", data.TenSach),
                    new MySqlParameter("@hinhAnh", data.HinhAnh),
                    new MySqlParameter("@maTheLoai", data.MaTheLoai),
                    new MySqlParameter("@maTacGia", data.MaTacGia),
                    new MySqlParameter("@maNhaXuatBan", data.MaNhaXuatBan),
                    new MySqlParameter("@soLuongConLai", data.SoLuongConLai),
                    new MySqlParameter("@giaBan", data.GiaBan),
                    new MySqlParameter("@giaNhap", data.GiaNhap),
                });

            return rowChanged > 0;
        }

        public bool delete(string id)
        {
            string sql = $@"UPDATE sach SET hienThi = 0 WHERE maSach=@maSach;";

            int rowChanged = DataProvider.Instance.ExecuteNonQuery(sql,
                new MySqlParameter[] {
                    new MySqlParameter("@maSach", id),
                });

            if (rowChanged > 0)
            {
                sql = $@"DELETE FROM chitietsach WHERE maSach=@maSach;";

                rowChanged = DataProvider.Instance.ExecuteNonQuery(sql,
                    new MySqlParameter[] {
                        new MySqlParameter("@maSach", id),
                });

                return rowChanged > 0;
            }

            return false;
        }

        public bool deleteBookAmount(string id, int amount)
        {
            string sql;
            DataTable dataTable;
            int rowChanged = 0;

            for (int i = 1; i <= amount; i++)
            {
                sql = $@"SELECT * FROM chitietsach WHERE maSach=@maSach LIMIT 1;";

                dataTable = DataProvider.Instance.ExecuteQuery(sql,
                    new MySqlParameter[] {
                    new MySqlParameter("@maSach", id),
                });

                if (dataTable.Rows.Count <= 0) return false;

                DataRow row = dataTable.Rows[0];

                sql = $@"DELETE FROM chitietsach WHERE maChiTietSach=@maChiTietSach;";

                rowChanged = DataProvider.Instance.ExecuteNonQuery(sql,
                    new MySqlParameter[] {
                    new MySqlParameter("@maChiTietSach", row["maChiTietSach"]),
                });
            }

            return rowChanged > 0;
        }

        public bool createBookAmount(string id, int amount)
        {
            string sql = $@"INSERT INTO chitietsach(maSach) VALUES (@maSach);";
            int rowChanged = 0;

            for (int i = 1; i <= amount; i++)
            {
                rowChanged = DataProvider.Instance.ExecuteNonQuery(sql,
                    new MySqlParameter[] {
                    new MySqlParameter("@maSach", id),
                });
            }

            return rowChanged > 0;
        }
        public List<BookDTO> getBookList(string id)
        {
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(
                "SELECT * FROM sach WHERE (maSach LIKE @maSach OR giaBan LIKE @giaBan) AND hienThi = 1;",
                new MySqlParameter[] {
                     new MySqlParameter("@maSach", id),
                     new MySqlParameter("@giaBan", id)
                }
            );

            if (dataTable.Rows.Count <= 0) return null;
            dataTable.Columns.Add("soLuongConLai");
            foreach (DataRow row in dataTable.Rows)
            {
                DataTable dataTable1 = DataProvider.Instance.ExecuteQuery(
                    "SELECT COUNT(*) as soLuongConLai FROM chitietsach WHERE maSach=@MaSach;",
                    new MySqlParameter[] {
                    new MySqlParameter("@MaSach", row["maSach"])
                    }
                );

                row["soLuongConLai"] = dataTable1.Rows[0]["soLuongConLai"];
            }
            List<BookDTO> booklList = new List<BookDTO>();

            foreach (DataRow row in dataTable.Rows)
            {
                BookDTO book = new BookDTO(row);
                booklList.Add(book);
            }
            return booklList;
        }
        public List<BookDTO> getBookListImport(string id)
        {
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(
                "SELECT * FROM sach WHERE (maSach LIKE @maSach OR giaNhap LIKE @giaNhap) AND hienThi = 1;",
                new MySqlParameter[] {
                     new MySqlParameter("@maSach", id),
                     new MySqlParameter("@giaNhap", id)
                }
            );

            if (dataTable.Rows.Count <= 0) return null;
            dataTable.Columns.Add("soLuongConLai");
            foreach (DataRow row in dataTable.Rows)
            {
                DataTable dataTable1 = DataProvider.Instance.ExecuteQuery(
                    "SELECT COUNT(*) as soLuongConLai FROM chitietsach WHERE maSach=@MaSach;",
                    new MySqlParameter[] {
                    new MySqlParameter("@MaSach", row["maSach"])
                    }
                );

                row["soLuongConLai"] = dataTable1.Rows[0]["soLuongConLai"];
            }
            List<BookDTO> booklList = new List<BookDTO>();

            foreach (DataRow row in dataTable.Rows)
            {
                BookDTO book = new BookDTO(row);
                booklList.Add(book);
            }
            return booklList;
        }
    }
}
