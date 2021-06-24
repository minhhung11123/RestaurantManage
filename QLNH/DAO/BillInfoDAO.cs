using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;

        public static BillInfoDAO Instance
        {
            get { if (instance == null) instance = new BillInfoDAO(); return BillInfoDAO.instance; }
            private set { BillInfoDAO.instance = value; }
        }

        private BillInfoDAO() { }

        public List<BillInfo> GetListBillInfo(int id)
        {
            try
            {
                List<BillInfo> listBillInfo = new List<BillInfo>();
                DataTable tb = DataProvider.Instance.ExecuteQuery("select * from dbo.CTHoaDon where idHD = " + id);
                foreach (DataRow item in tb.Rows)
                {
                    BillInfo info = new BillInfo(item);
                    listBillInfo.Add(info);
                }
                return listBillInfo;
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
                DataProvider.Instance.ExecuteNonQuery("Exec InsertBillInfo @idHD , @idMA , @soLuong", new object[] { bi.IdHD, bi.IdMA, bi.SoLuong });
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
