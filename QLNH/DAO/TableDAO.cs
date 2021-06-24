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
    public class TableDAO
    {
        private static TableDAO instance;

        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set { TableDAO.instance = value; }
        }

        private TableDAO() { }

        public List<Table> LoadTableList()
        {
            try
            {
                List<Table> tableList = new List<Table>();
                DataTable data = DataProvider.Instance.ExecuteQuery("GetTableList");
                foreach (DataRow dr in data.Rows)
                {
                    Table table = new Table(dr);
                    tableList.Add(table);
                }
                return tableList;
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
        public DataTable GetTableTB()
        {
            try
            {
                string query = " select * from dbo.Ban ";
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
        public bool InsertTable(Table tb)
        {
            try
            {
                string query = @"insert into dbo.Ban values ( @tenBan , @trangThai )";
                object[] ob = new object[] { tb.Name, tb.Status };
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
        public bool UpdateTable(Table tb)
        {
            try
            {
                string query = @" update dbo.Ban set tenBan = @tenBan where idBan = @idBan ";
                object[] ob = new object[] { tb.Name, tb.ID };
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

        public bool DeleteTable(Table tb)
        {
            try
            {
                string query = @" delete dbo.Ban where idBan = @idBan ";
                object[] ob = new object[] { tb.ID };
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

        public int GetTableStatus(int id)
        {
            try
            {
                string query = @"select trangThai from dbo.Ban where idBan = @id";
                object[] ob = new object[] { id };
                return (int)DataProvider.Instance.ExecuteScalar(query, ob);
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
                DataProvider.Instance.ExecuteQuery("ChuyenBan @id1 , @id2 , @idnv", new object[] { id1, id2, idNV });
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
                DataProvider.Instance.ExecuteQuery("GopBan @id1 , @id2 , @idnv", new object[] { id1, id2, idNV });
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
