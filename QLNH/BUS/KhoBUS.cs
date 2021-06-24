using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
using System.Data;
using System.Data.SqlClient;

namespace BUS
{
    public class KhoBUS
    {
        private static KhoBUS instance;

        public static KhoBUS Instance
        {
            get { if (instance == null) instance = new KhoBUS(); return KhoBUS.instance; }
            private set { KhoBUS.instance = value; }
        }

        private KhoBUS() { }

        public bool InsertKho(Kho k)
        {
            try
            {
                return KhoDAO.Instance.InsertKho(k);
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

        public DataTable GetTableKho()
        {
            try
            {
                return KhoDAO.Instance.GetTableKho();
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

        public bool EditKho(Kho k)
        {
            try
            {
                return KhoDAO.Instance.EditKho(k);
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

        public bool DeleteKho(Kho k)
        {
            try
            {
                return KhoDAO.Instance.DeleteKho(k);
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
