using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
using System.Data.SqlClient;
using System.Data;

namespace BUS
{
    public class NVBUS
    {
        private static NVBUS instance;

        public static NVBUS Instance
        {
            get { if (instance == null) instance = new NVBUS(); return NVBUS.instance; }
            private set { NVBUS.instance = value; }
        }

        public bool InsertNV(NhanVien nv)
        {
            try {
                return NVDAO.Instance.InsertNV(nv);
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

        public DataTable GetTableNV()
        {
            try
            {
                return NVDAO.Instance.GetTableNV();
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

        public bool EditNV(NhanVien nv)
        {
            try
            {
                return NVDAO.Instance.EditNV(nv);
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

        public bool DeleteNV(NhanVien nv)
        {
            try
            {
                return NVDAO.Instance.DeleteNV(nv);
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

        public bool CheckIDNV(int id)
        {
            try
            {
                return NVDAO.Instance.CheckIDNV(id);
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

        public void SetAccount(string acc, int id)
        {
            try
            {
                NVDAO.Instance.SetAccount(acc, id);
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
