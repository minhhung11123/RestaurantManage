using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return BillDAO.instance; }
            private set { BillDAO.instance = value; }
        }

        private BillDAO() { }

        public int GetUncheckBillByTableID(int id)
        {
            try
            {
                DataTable tb = DataProvider.Instance.ExecuteQuery("Select * from dbo.HoaDon where idBan = @id and trangThai = 0", new object[] { id });
                if (tb.Rows.Count > 0)
                {
                    Bill bill = new Bill(tb.Rows[0]);
                    return bill.IdHD;
                }
                return -1;
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
                DataProvider.Instance.ExecuteNonQuery("Exec InsertBill @idNV , @idBan", new object[] { idNV, idBan });
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
                return (int)DataProvider.Instance.ExecuteScalar("Select MAX(idHD) from dbo.HoaDon");
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
                string query = "Update dbo.HoaDon set trangThai = 1, thoiGianRa = GETDATE(), idMaKM = @maKM , tongTien = @tongTien where idHD = @id";
                object[] ob = new object[] { maKM, tongTien, id };
                DataProvider.Instance.ExecuteNonQuery(query, ob);
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
                string query = "ShowHistoryBill @dt1 , @dt2";
                object[] ob = new object[] { dt1, dt2 };
                return DataProvider.Instance.ExecuteQuery(query, ob);
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
