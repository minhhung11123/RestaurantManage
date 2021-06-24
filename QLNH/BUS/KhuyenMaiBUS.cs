using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using System.Data.SqlClient;
using System.Data;

namespace BUS
{
    public class KhuyenMaiBUS
    {
        private static KhuyenMaiBUS instance;

        public static KhuyenMaiBUS Instance
        {
            get { if (instance == null) instance = new KhuyenMaiBUS(); return KhuyenMaiBUS.instance; }
            private set { KhuyenMaiBUS.instance = value; }
        }

        private KhuyenMaiBUS() { }

        public double GetPercentByID(int id)
        {
            try
            {
                return KhuyenMaiDAO.Instance.GetPercentByID(id);
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
                return KhuyenMaiDAO.Instance.InsertKM(km);
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
                return KhuyenMaiDAO.Instance.GetTableKM();
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
                return KhuyenMaiDAO.Instance.EditKM(km);
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
                return KhuyenMaiDAO.Instance.DeleteKM(km);
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
