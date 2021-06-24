using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAO;

namespace BUS
{
    public class ReportBUS
    {
        private static ReportBUS instance;

        public static ReportBUS Instance
        {
            get { if (instance == null) instance = new ReportBUS(); return ReportBUS.instance; }
            private set { ReportBUS.instance = value; }
        }

        private ReportBUS() { }

        public DataTable GetDataBill(int id)
        {
            try
            {
                return ReportDAO.Instance.GetDataBill(id);
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
                return ReportDAO.Instance.GetRPDTNgay(dt);
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
                return ReportDAO.Instance.GetRPDTThang(dt);
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
                return ReportDAO.Instance.GetRPDTNam(dt);
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
