using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class ReportDAO
    {
        private static ReportDAO instance;

        public static ReportDAO Instance
        {
            get { if (instance == null) instance = new ReportDAO(); return ReportDAO.instance; }
            private set { ReportDAO.instance = value; }
        }

        private ReportDAO() { }

        public DataTable GetDataBill(int id)
        {
            try
            {
                return DataProvider.Instance.ExecuteQuery("ShowBillInRP @idHD", new object[] { id });
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

        public DataTable GetRPDTNgay(DateTime dt)
        {
            try
            {
                return DataProvider.Instance.ExecuteQuery("ReportDTNgay @dt", new object[] { dt });
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

        public DataTable GetRPDTThang(DateTime dt)
        {
            try
            {
                return DataProvider.Instance.ExecuteQuery("ReportDTThang @dt", new object[] { dt });
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

        public DataTable GetRPDTNam(DateTime dt)
        {
            try
            {
                return DataProvider.Instance.ExecuteQuery("ReportDTNam @dt", new object[] { dt });
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
