using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class KhuyenMaiDAO
    {
        private static KhuyenMaiDAO instance;

        public static KhuyenMaiDAO Instance
        {
            get { if (instance == null) instance = new KhuyenMaiDAO(); return KhuyenMaiDAO.instance; }
            private set { KhuyenMaiDAO.instance = value; }
        }

        private KhuyenMaiDAO() { }

        public double GetPercentByID(int id)
        {
            try
            {
                DataTable dt = DataProvider.Instance.ExecuteQuery("select * from dbo.KhuyenMai");
                foreach (DataRow dr in dt.Rows)
                {
                    if ((int)dr["IdMaKM"] == id)
                    {
                        return (double)dr["tyLeGiamGia"];
                    }
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

        public bool InsertKM(KhuyenMai km)
        {
            try
            {
                string query = @"insert into dbo.KhuyenMai values ( @ten , @phanTram )";
                object[] ob = new object[] { km.Name, km.Percent };
                int result = DataProvider.Instance.ExecuteNonQuery(query, ob);
                return result > 0;
            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataTable GetTableKM()
        {
            try
            {
                string query = @"select * from dbo.KhuyenMai";
                return DataProvider.Instance.ExecuteQuery(query);
            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool EditKM(KhuyenMai km)
        {
            try
            {
                string query = @"update dbo.KhuyenMai set loaiKM = @loaiKM , tyLeGiamGia = @tyLeGiamGia where idMaKM = @id";
                object[] ob = new object[] { km.Name, km.Percent, km.Id };
                int result = DataProvider.Instance.ExecuteNonQuery(query, ob);
                return result > 0;
            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool DeleteKM(KhuyenMai km)
        {
            try
            {
                string query = @"delete dbo.KhuyenMai where idMaKM = @id";
                object[] ob = new object[] { km.Id };
                int result = DataProvider.Instance.ExecuteNonQuery(query, ob);
                return result > 0;
            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
