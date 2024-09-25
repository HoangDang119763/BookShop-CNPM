﻿using System.Collections.Generic;
using System.Data;
using BookShop_CNPM.DAO;
using BookShop_CNPM.DTO;

namespace BookShop_CNPM.BUS
{
    public class CustomerRefundBillBUS : IBUS<CustomerRefundBillDTO>
    {
        private static CustomerRefundBillBUS instance;

        public static CustomerRefundBillBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CustomerRefundBillBUS();
                }

                return CustomerRefundBillBUS.instance;
            }
            private set { CustomerRefundBillBUS.instance = value; }
        }

        public DataTable getAll()
        {
            return CustomerRefundBillDAO.Instance.getAll();
        }

        public List<CustomerRefundBillDTO> getAllData()
        {
            List<CustomerRefundBillDTO> customerRefundBillList = new List<CustomerRefundBillDTO>();
            DataTable dt = CustomerRefundBillDAO.Instance.getAll();

            foreach (DataRow row in dt.Rows)
            {
                CustomerRefundBillDTO customerRefundBill = new CustomerRefundBillDTO(row);
                customerRefundBillList.Add(customerRefundBill);
            }

            return customerRefundBillList;
        }

		public int getRefundQuantityByBookId(string bookId)
		{
			return CustomerRefundBillDAO.Instance.getRefundQuantityByBookId(bookId);
		}

		public decimal getRefundRevenueByBookId(string bookId)
        {
			return CustomerRefundBillDAO.Instance.getRefundRevenueByBookId(bookId);
		}

		public List<CustomerRefundBillDetailDTO> getCustomerRefundBillDetailList(string id)
        {
            return CustomerRefundBillDAO.Instance.getCustomerRefundBillDetailList(id);
        }

        public List<CustomerRefundBillDTO> getCustomerRefundBillList(string id)
        {
            return CustomerRefundBillDAO.Instance.getCustomerRefundBillList(id);
        }

        public bool createCustomerRefundBillDetail(CustomerRefundBillDetailDTO customerRefundBillDetail, string madon)
        {
            return CustomerRefundBillDAO.Instance.createCustomerRefundBillDetail(customerRefundBillDetail,madon);
        }

        public List<CustomerRefundBillDTO> search(string value)
        {
            DataTable dataTable = CustomerRefundBillDAO.Instance.searchData(value);

            List<CustomerRefundBillDTO> customerRefundBillList = new List<CustomerRefundBillDTO>();

            foreach (DataRow row in dataTable.Rows)
            {
                CustomerRefundBillDTO customerRefundBill = new CustomerRefundBillDTO(row);
                customerRefundBillList.Add(customerRefundBill);
            }

            return customerRefundBillList;
        }

        public bool exist(string value)
        {
           return CustomerRefundBillDAO.Instance.existData(value);
        }

        public bool insert(CustomerRefundBillDTO customerRefundBill)
        {
            return CustomerRefundBillDAO.Instance.insert(customerRefundBill);
        }

        public CustomerRefundBillDTO insertReturnBill(CustomerRefundBillDTO customerRefundBill)
        {
            return CustomerRefundBillDAO.Instance.insertReturnBill(customerRefundBill);
        }

        public bool delete(string id)
        {
            return CustomerRefundBillDAO.Instance.delete(id);
        }

        public bool update(CustomerRefundBillDTO customerRefundBill)
        {
            return CustomerRefundBillDAO.Instance.update(customerRefundBill);
        }

        public CustomerRefundBillDTO getById(string id)
        {
            return CustomerRefundBillDAO.Instance.getById(id);
        }
    }
}
