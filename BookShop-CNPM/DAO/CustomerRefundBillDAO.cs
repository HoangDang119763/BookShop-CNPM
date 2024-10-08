﻿using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using BookShop_CNPM.BUS;
using BookShop_CNPM.DTO;
using System;

namespace BookShop_CNPM.DAO
{
    public class CustomerRefundBillDAO : IDAO<CustomerRefundBillDTO>
    {
        private static CustomerRefundBillDAO instance;

        public static CustomerRefundBillDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CustomerRefundBillDAO();
                }

                return CustomerRefundBillDAO.instance;
            }
            private set { CustomerRefundBillDAO.instance = value; }
        }
        public DataTable getAll() {
            return DataProvider.Instance.ExecuteQuery("select * from phieutrabanhang;");
        }

        public CustomerRefundBillDetailDTO getCustomerRefundBillDetail(string billId, string bookId)
        {
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(
                "SELECT * FROM chitietphieutrabanhang WHERE maPhieuTraBanHang=@maPhieuTraBanHang AND maSach=@maSach;",
                new MySqlParameter[] {
                    new MySqlParameter("@maPhieuTraBanHang", billId),
                    new MySqlParameter("@maSach", bookId)
                }
            );

            if (dataTable.Rows.Count <= 0) return null;

            CustomerRefundBillDetailDTO customerBillDetail = new CustomerRefundBillDetailDTO(dataTable.Rows[0]);

            return customerBillDetail;
        }

        public int getRefundQuantityByBookId(string bookId)
        {
			DataTable dataTable = DataProvider.Instance.ExecuteQuery(
				"SELECT sum(soLuong) as daTra FROM chitietphieutrabanhang WHERE maSach=@maSach;",
				new MySqlParameter[] {
				new MySqlParameter("@maSach", bookId)
				}
			);

			if (dataTable.Rows.Count <= 0 || dataTable.Rows[0]["daTra"] == DBNull.Value) return 0;

			return Convert.ToInt32(dataTable.Rows[0]["daTra"]);
		}

		public decimal getRefundRevenueByBookId(string bookId)
		{
			DataTable dataTable = DataProvider.Instance.ExecuteQuery(
				"SELECT sum(soLuong * donGia) as tienDaTra FROM chitietphieutrabanhang WHERE maSach=@maSach;",
				new MySqlParameter[] {
				new MySqlParameter("@maSach", bookId)
				}
			);

			if (dataTable.Rows.Count <= 0 || dataTable.Rows[0]["tienDaTra"] == DBNull.Value) return 0;

			return Convert.ToDecimal(dataTable.Rows[0]["tienDaTra"]);
		}

		public List<CustomerRefundBillDetailDTO> getCustomerRefundBillDetailList(string billId)
        {
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(
                "SELECT * FROM chitietphieutrabanhang WHERE maPhieuTraBanHang=@maPhieuTraBanHang;",
                new MySqlParameter[] {
                    new MySqlParameter("@maPhieuTraBanHang", billId),
                }
            );

            if (dataTable.Rows.Count <= 0) return null;

            List<CustomerRefundBillDetailDTO> customerBillDetailList = new List<CustomerRefundBillDetailDTO>();

            foreach (DataRow row in dataTable.Rows)
            {
                CustomerRefundBillDetailDTO customerBillDetail = new CustomerRefundBillDetailDTO(row);
                customerBillDetailList.Add(customerBillDetail);
            }

            return customerBillDetailList;
        }

        /**/
        public List<CustomerRefundBillDTO> getCustomerRefundBillList(string billId)
        {
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(
                "SELECT * FROM phieutrabanhang WHERE maDonKhachHang=@maDonKhachHang;",
                new MySqlParameter[] {
                    new MySqlParameter("@maDonKhachHang", billId),
                }
            );

            if (dataTable.Rows.Count <= 0) return null;

            List<CustomerRefundBillDTO> customerBillList = new List<CustomerRefundBillDTO>();

            foreach (DataRow row in dataTable.Rows)
            {
                CustomerRefundBillDTO customerBillRefund = new CustomerRefundBillDTO(row);
                customerBillList.Add(customerBillRefund);
            }

            return customerBillList;
        }

        public DataTable searchData(string value)
        {
            string sql = $@"SELECT * FROM phieutrabanhang WHERE maPhieuTraBanHang LIKE @maPhieuTraBanHang;";

            return DataProvider.Instance.ExecuteQuery(sql,
                new MySqlParameter[] {
                    new MySqlParameter("@maPhieuTraBanHang", "%" + value + "%"),
                }
            );
        }

        /*public DataTable existData(string value)
        {
            string sql = $@"SELECT * FROM phieutrabanhang WHERE maDonKhachHang LIKE @maDonKhachHang;";

            return DataProvider.Instance.ExecuteQuery(sql,
                new MySqlParameter[] {
                    new MySqlParameter("@maDonKhachHang", "%" + value + "%"),
                }
            );
        }*/

        public bool existData(string value)
        {
            string sql = @"SELECT COUNT(*) FROM phieutrabanhang WHERE maDonKhachHang LIKE @maDonKhachHang;";

            DataTable dataTable = DataProvider.Instance.ExecuteQuery(sql,
                new MySqlParameter[] {
            new MySqlParameter("@maDonKhachHang", "%" + value + "%"),
                }
            );

            // Kiểm tra số lượng hàng. Nếu có ít nhất 1 hàng, trả về true.
            return dataTable.Rows.Count > 0 && Convert.ToInt32(dataTable.Rows[0][0]) > 0;
        }

        public bool insert(CustomerRefundBillDTO data)
        {

            string sql = $@"INSERT INTO phieutrabanhang (maDonKhachHang, maNhanVien, ngayLap, liDo, tongTien)
                            VALUES (@maDonKhachHang, @maNhanVien, @ngayLap, @liDo, @tongTien);";

            int rowChanged = DataProvider.Instance.ExecuteNonQuery(sql,
                new MySqlParameter[] {
                    new MySqlParameter("@maDonKhachHang", data.MaDonKhachHang),
                    new MySqlParameter("@maNhanVien", data.MaNhanVien),
                    new MySqlParameter("@ngayLap", data.NgayLap),
                    new MySqlParameter("@liDo", data.LiDo),
                    new MySqlParameter("@tongTien", data.TongTien),
                });

            return rowChanged > 0;
        }

        public CustomerRefundBillDTO insertReturnBill(CustomerRefundBillDTO data)
        {
            string sql = "SELECT * FROM phieutrabanhang ORDER BY maPhieuTraBanHang DESC LIMIT 1;";
            if (this.insert(data))
            {

                DataTable dataTable = DataProvider.Instance.ExecuteQuery(sql);

                if (dataTable.Rows.Count <= 0) return null;

                CustomerRefundBillDTO customerBill = new CustomerRefundBillDTO(dataTable.Rows[0]);

                return customerBill;
            };

            return null;
        }

        public bool createCustomerRefundBillDetail(CustomerRefundBillDetailDTO data,string madon)
        {
            string sql = $@"INSERT INTO chitietphieutrabanhang (maPhieuTraBanHang, maSach, soLuong, donGia) 
                            VALUES (@maPhieuTraBanHang, @maSach, @soLuong, @donGia);";

            int rowChanged = DataProvider.Instance.ExecuteNonQuery(sql,
                new MySqlParameter[] {
                    new MySqlParameter("@maPhieuTraBanHang", data.MaDon),
                    new MySqlParameter("@maSach", data.MaSach),
                    new MySqlParameter("@soLuong", data.SoLuong),
                    new MySqlParameter("@donGia", data.DonGia),
                });

            // xóa số lượng còn lại của sách
            if (rowChanged > 0)
            {
                BookBUS.Instance.createBookAmount(data.MaSach.ToString(), data.SoLuong);
                CustomerBillBUS.Instance.createBookAmount(madon, data.MaSach.ToString(), data.SoLuong);
            }

            return rowChanged > 0;
        }

        public bool update(CustomerRefundBillDTO data)
        {
            string sql = $@"UPDATE phieutrabanhang SET 
                            maDonKhachHang=@maDonKhachHang, maNhanVien=@maNhanVien, liDo=@liDo, ngayLap=@ngayLap, 
                            tongTien=@tongTien WHERE maPhieuTraBanHang=@maPhieuTraBanHang;";

            int rowChanged = DataProvider.Instance.ExecuteNonQuery(sql,
                new MySqlParameter[] {
                    new MySqlParameter("@maDonKhachHang", data.MaDonKhachHang),
                    new MySqlParameter("@maNhanVien", data.MaNhanVien),
                    new MySqlParameter("@liDo", data.LiDo),
                    new MySqlParameter("@ngayLap", data.NgayLap),
                    new MySqlParameter("@tongTien", data.TongTien),
                    new MySqlParameter("@maPhieuTraBanHang", data.MaPhieu),
                });

            return rowChanged > 0;
        }

        public bool delete(string id)
        {
            string sql = $@"UPDATE phieutrabanhang SET hienThi=0 WHERE maPhieuTraBanHang=@maPhieuTraBanHang;";

            int rowChanged = DataProvider.Instance.ExecuteNonQuery(sql,
                new MySqlParameter[] {
                    new MySqlParameter("@maPhieuTraBanHang", id),
                });

            return rowChanged > 0;
        }

        public CustomerRefundBillDTO getById(string id)
        {
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(
                "SELECT * FROM phieutrabanhang WHERE maPhieuTraBanHang=@maPhieuTraBanHang;",
                new MySqlParameter[] {
                    new MySqlParameter("@maPhieuTraBanHang", id),
                }
            );

            if (dataTable.Rows.Count <= 0) return null;

            CustomerRefundBillDTO customerBill = new CustomerRefundBillDTO(dataTable.Rows[0]);

            return customerBill;
        }
    }
}
