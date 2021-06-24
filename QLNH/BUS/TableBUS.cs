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
    public class TableBUS
    {
        private static TableBUS instance;

        public static TableBUS Instance
        {
            get { if (instance == null) instance = new TableBUS(); return TableBUS.instance; }
            private set { TableBUS.instance = value; }
        }

        public List<Table> LoadTableList()
        {
            return TableDAO.Instance.LoadTableList();
        }
        public bool InsertTable(Table tb)
        {
            try
            {
                return TableDAO.Instance.InsertTable(tb);
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

        public DataTable GetTableTB()
        {
            try
            {
                return TableDAO.Instance.GetTableTB();
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
        public bool UpdateTable(Table tb)
        {
            try
            {
                return TableDAO.Instance.UpdateTable(tb);
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

        public bool DeleteTable(Table tb)
        {
            try
            {
                return TableDAO.Instance.DeleteTable(tb);
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

        public int GetTableStatus(int id)
        {
            try
            {
                return TableDAO.Instance.GetTableStatus(id);
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

        public void SwitchTable(int id1, int id2, int idNV)
        {
            try
            {
                TableDAO.Instance.SwitchTable(id1, id2, idNV);
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

        public void MergeTable(int id1, int id2, int idNV)
        {
            try
            {
                TableDAO.Instance.MergeTable(id1, id2, idNV);
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
