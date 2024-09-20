using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using BookShop_CNPM.BUS;
using BookShop_CNPM.DTO;
using System;

namespace BookShop_CNPM.DAO
{
    public class CustomerChangeBillDAO : IDAO<CustomerChangeBillDTO>
    {
        private static CustomerChangeBillDAO instance;

        public static CustomerChangeBillDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CustomerChangeBillDAO();
                }

                return CustomerChangeBillDAO.instance;
            }
            private set { CustomerChangeBillDAO.instance = value; }
        }
        public DataTable getAll() {
            return DataProvider.Instance.ExecuteQuery("select * from phieudoibanhang;");
        }

        public DataTable searchData(string value)
        {
            string sql = $@"SELECT * FROM phieudoibanhang WHERE maPhieuDoiBanHang LIKE @maPhieuDoiBanHang;";

            return DataProvider.Instance.ExecuteQuery(sql,
                new MySqlParameter[] {
                    new MySqlParameter("@maPhieuDoiBanHang", "%" + value + "%"),
                }
            );
        }

		public int getChangeQuantityByBookId(string bookId)
		{
			DataTable dataTable = DataProvider.Instance.ExecuteQuery(
				"SELECT sum(soLuong) as daDoi FROM chitietphieudoibanhang WHERE maSachCanDoi=@maSachCanDoi;",
				new MySqlParameter[] {
				new MySqlParameter("@maSachCanDoi", bookId)
				}
			);

            int daDoi;
			if (dataTable.Rows.Count <= 0 || dataTable.Rows[0]["daDoi"] == DBNull.Value) daDoi = 0;
			else daDoi = Convert.ToInt32(dataTable.Rows[0]["daDoi"]);

			DataTable dataTable1 = DataProvider.Instance.ExecuteQuery(
				"SELECT sum(soLuong) as daDoi FROM chitietphieudoibanhang WHERE maSachMuonDoi=@maSachMuonDoi;",
				new MySqlParameter[] {
				new MySqlParameter("@maSachMuonDoi", bookId)
				}
			);

            if (dataTable1.Rows.Count <= 0 || dataTable1.Rows[0]["daDoi"] == DBNull.Value) return daDoi;
            else return daDoi - Convert.ToInt32(dataTable1.Rows[0]["daDoi"]);
		}

		public decimal getChangeRevenueByBookId(string bookId)
		{
			DataTable dataTable = DataProvider.Instance.ExecuteQuery(
				"SELECT sum(soLuong * donGiaSachCanDoi) as tienDaDoi FROM chitietphieudoibanhang WHERE maSachCanDoi=@maSachCanDoi;",
				new MySqlParameter[] {
				new MySqlParameter("@maSachCanDoi", bookId)
				}
			);

			decimal tienDaDoi;
			if (dataTable.Rows.Count <= 0 || dataTable.Rows[0]["tienDaDoi"] == DBNull.Value) tienDaDoi = 0;
			else tienDaDoi = Convert.ToDecimal(dataTable.Rows[0]["tienDaDoi"]);

			DataTable dataTable1 = DataProvider.Instance.ExecuteQuery(
				"SELECT sum(soLuong * donGiaSachMuonDoi) as tienDaDoi FROM chitietphieudoibanhang WHERE maSachMuonDoi=@maSachMuonDoi;",
				new MySqlParameter[] {
				new MySqlParameter("@maSachMuonDoi", bookId)
				}
			);

			if (dataTable1.Rows.Count <= 0 || dataTable1.Rows[0]["tienDaDoi"] == DBNull.Value) return tienDaDoi;
			else return tienDaDoi - Convert.ToDecimal(dataTable1.Rows[0]["tienDaDoi"]);
		}

		public bool insert(CustomerChangeBillDTO data)
        {

            string sql = $@"INSERT INTO phieudoibanhang (maDonKhachHang, ngayLap, liDo, tinhTrangSanPham, maNhanVien)
                            VALUES (@maDonKhachHang,@ngayLap, @liDo, @tinhTrangSanPham, @maNhanVien);";

            int rowChanged = DataProvider.Instance.ExecuteNonQuery(sql,
                new MySqlParameter[] {
                    new MySqlParameter("@maDonKhachHang", data.MaDonKhachHang),
                    new MySqlParameter("@ngayLap", data.NgayLap),
                    new MySqlParameter("@liDo", data.LiDo),
                    new MySqlParameter("@tinhTrangSanPham", data.TinhTrangSanPham),
                    new MySqlParameter("@maNhanVien", data.MaNhanVien),
                });

            return rowChanged > 0;
        }

        public CustomerChangeBillDTO insertReturnBill(CustomerChangeBillDTO data)
        {
            string sql = "SELECT * FROM phieudoibanhang ORDER BY maPhieuDoiBanHang DESC LIMIT 1;";
            if (this.insert(data))
            {
                DataTable dataTable = DataProvider.Instance.ExecuteQuery(sql);

                if (dataTable.Rows.Count <= 0) return null;

                CustomerChangeBillDTO customerBill = new CustomerChangeBillDTO(dataTable.Rows[0]);

                return customerBill;
            };

            return null;
        }

        public bool update(CustomerChangeBillDTO data)
        {
            string sql = $@"UPDATE phieudoibanhang SET maDonKhachHang=@maDonKhachHang, ngayLap=@ngayLap, liDo=@liDo, tinhTrangSanPham=@tinhTrangSanPham,
                            maNhanVien=@maNhanVien WHERE maPhieuDoiBanHang=@maPhieuDoiBanHang;";

            int rowChanged = DataProvider.Instance.ExecuteNonQuery(sql,
                new MySqlParameter[] {
                    new MySqlParameter("@ngayLap", data.MaDonKhachHang),
                    new MySqlParameter("@ngayLap", data.NgayLap),
                    new MySqlParameter("@liDo", data.LiDo),
                    new MySqlParameter("@tinhTrangSanPham", data.TinhTrangSanPham),
                    new MySqlParameter("@maPhieuDoiBanHang", data.MaPhieu),
                });

            return rowChanged > 0;
        }

        public bool delete(string id)
        {
            string sql = $@"DELETE FROM `phieudoibanhang` WHERE maPhieuDoiBanHang=@maPhieuDoiBanHang;";

            int rowChanged = DataProvider.Instance.ExecuteNonQuery(sql,
                new MySqlParameter[] {
                    new MySqlParameter("@maPhieuDoiBanHang", id),
                });
            string sql2 = $@"DELETE FROM chitietphieudoibanhang WHERE maPhieuDoiBanHang=@maPhieuDoiBanHang;";
            int rowChangeddetail = DataProvider.Instance.ExecuteNonQuery(sql2,
                new MySqlParameter[] {
                    new MySqlParameter("@maPhieuDoiBanHang", id),
                });

            return rowChanged > 0;
        }

        public CustomerChangeBillDTO getById(string id)
        {
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(
                "SELECT * FROM phieudoibanhang WHERE maPhieuDoiBanHang=@maPhieuDoiBanHang;",
                new MySqlParameter[] {
                    new MySqlParameter("@maPhieuDoiBanHang", id),
                }
            );

            if (dataTable.Rows.Count <= 0) return null;

            CustomerChangeBillDTO customerBill = new CustomerChangeBillDTO(dataTable.Rows[0]);

            return customerBill;
        }
        public List<CustomerChangeBillDetailDTO> getCustomerChangeBillDetailList(string billId)
        {
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(
                "SELECT * FROM chitietphieudoibanhang WHERE maPhieuDoiBanHang=@maPhieuDoiBanHang;",
                new MySqlParameter[] {
                    new MySqlParameter("@maPhieuDoiBanHang", billId),
                }
            );

            if (dataTable.Rows.Count <= 0) return null;

            List<CustomerChangeBillDetailDTO> customerChangeBillDetailList = new List<CustomerChangeBillDetailDTO>();

            foreach (DataRow row in dataTable.Rows)
            {
                CustomerChangeBillDetailDTO customerChangeBillDetail = new CustomerChangeBillDetailDTO(row);
                customerChangeBillDetailList.Add(customerChangeBillDetail);
            }

            return customerChangeBillDetailList;
        }
        public bool createCustomerChangeBillDetail(CustomerChangeBillDetailDTO data,string madon)
        {
            string sql = $@"INSERT INTO chitietphieudoibanhang (maPhieuDoiBanHang, maSachCanDoi, donGiaSachCanDoi, maSachMuonDoi, donGiaSachMuonDoi, soLuong) 
                            VALUES (@maPhieuDoiBanHang, @maSachCanDoi, @donGiaSachCanDoi, @maSachMuonDoi, @donGiaSachMuonDoi, @soLuong);";
            int rowChanged = DataProvider.Instance.ExecuteNonQuery(sql,
                new MySqlParameter[] {
                    new MySqlParameter("@maPhieuDoiBanHang", data.MaDon),
                    new MySqlParameter("@maSachCanDoi", data.SachCanDoi),
                    new MySqlParameter("@donGiaSachCanDoi", data.donGiaSachCanDoi),
                    new MySqlParameter("@maSachMuonDoi", data.SachMuonDoi),
                    new MySqlParameter("@donGiaSachMuonDoi", data.donGiaSachMuonDoi),
                    new MySqlParameter("@soLuong", data.soLuong),
                });
            if (rowChanged > 0)
            {
                BookBUS.Instance.createBookAmount(data.SachCanDoi.ToString(), data.soLuong);
                BookBUS.Instance.deleteBookAmount(data.SachMuonDoi.ToString(), data.soLuong);
                CustomerBillBUS.Instance.createBookAmount(madon,data.SachCanDoi.ToString(), data.soLuong);
            }

            return rowChanged > 0;
        }
    }
}
