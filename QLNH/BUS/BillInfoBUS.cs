using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using System.Data.SqlClient;

namespace BUS
{
    public class BillInfoBUS
    {
        private static BillInfoBUS instance;

        public static BillInfoBUS Instance
        {
            get { if (instance == null) instance = new BillInfoBUS(); return BillInfoBUS.instance; }
            private set { BillInfoBUS.instance = value; }
        }

        public BillInfoBUS() { }

        public List<BillInfo> GetListBillInfo(int id)
        {
            try
            {
                return BillInfoDAO.Instance.GetListBillInfo(id);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertBillInfo(BillInfo bi)
        {
            try
            {
                BillInfoDAO.Instance.InsertBillInfo(bi);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
