using BookShop_CNPM.DAO;
using BookShop_CNPM.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop_CNPM.BUS
{
    public class SupplierBUS : IBUS<SupplierDTO>
    {
        private static SupplierBUS instance;

        public static SupplierBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SupplierBUS();
                }

                return SupplierBUS.instance;
            }
            private set { SupplierBUS.instance = value; }
        }

        public DataTable getAll()
        {
            return SupplierDAO.Instance.getAll();
        }

        public bool checkDuplicateName(string value)
        {
            return SupplierDAO.Instance.checkDuplicateName(value);
        }

        public bool checkDuplicateName(string value, int id)
        {
            return SupplierDAO.Instance.checkDuplicateName(value, id);
        }
        public bool checkDupicatePhoneNumber(string value)
        {
            return SupplierDAO.Instance.checkDuplicatePhoneNumber(value);
        }
		public bool checkDupicatePhoneNumber(string value,int id)
		{
			return SupplierDAO.Instance.checkDuplicatePhoneNumber(value,id);
		}
		public List<SupplierDTO> search(string value)
        {
            List<SupplierDTO> bookList = new List<SupplierDTO>();
            DataTable dt = SupplierDAO.Instance.searchData(value);

            foreach (DataRow row in dt.Rows)
            {
                SupplierDTO book = new SupplierDTO(row);
                bookList.Add(book);
            }

            return bookList;
        }

        public List<SupplierDTO> getAllData()
        {
            List<SupplierDTO> bookList = new List<SupplierDTO>();
            DataTable dt = SupplierDAO.Instance.getAll();

            foreach (DataRow row in dt.Rows)
            {
                SupplierDTO book = new SupplierDTO(row);
                bookList.Add(book);
            }

            return bookList;
        }

        public SupplierDTO getById(string id)
        {
            return SupplierDAO.Instance.getById(id);
        }

        public bool insert(SupplierDTO book)
        {
            return SupplierDAO.Instance.insert(book);
        }

        public bool update(SupplierDTO book)
        {
            return SupplierDAO.Instance.update(book);
        }

        public bool delete(string id)
        {
            return SupplierDAO.Instance.delete(id);
        }
    }
}
