using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DAO;
using System.Data;

namespace BUS
{
    public class BillBUS
    {
        private static BillBUS instance;

        public static BillBUS Instance
        {
            get { if (instance == null) instance = new BillBUS(); return BillBUS.instance; }
            private set { BillBUS.instance = value; }
        }

        private BillBUS() { }

        public int GetUncheckBillByTableID(int id)
        {
            try
            {
                return BillDAO.Instance.GetUncheckBillByTableID(id);
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

        public void InsertBill(int idNV, int idBan)
        {
            try
            {
                BillDAO.Instance.InsertBill(idNV, idBan);
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

        public int GetMaxIDBill()
        {
            try
            {
                return BillDAO.Instance.GetMaxIDBill();
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

        public void ThanhToan(int id, int maKM, int tongTien)
        {
            try
            {
                BillDAO.Instance.ThanhToan(id, maKM, tongTien);
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

        public DataTable GetDataTableHistory(DateTime dt1, DateTime dt2)
        {
            try
            {
                return BillDAO.Instance.GetDataTableHistory(dt1, dt2);
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
