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
    public class FoodDAO
    {
        private static FoodDAO instance;

        public static FoodDAO Instance
        {
            get { if (instance == null) instance = new FoodDAO(); return FoodDAO.instance; }
            private set { FoodDAO.instance = value; }
        }

        private FoodDAO() { }
    
        public bool InsertFood(Food fd)
        {
            try
            {
                string query = @"insert into dbo.MonAn values ( @tenMon , @idLoai , @giaTien )";
                object[] ob = new object[] {fd.TenMon, fd.IdLoai, fd.GiaTien };
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

        public DataTable GetTableFood()
        {
            try
            {
                string query = "GetFoodList";
                return DataProvider.Instance.ExecuteQuery(query);
            }
            catch(SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataTable GetTableFood(int id)
        {
            try
            {
                string query = "GetFoodListBy @id";
                return DataProvider.Instance.ExecuteQuery(query, new object[] { id });
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

        public bool UpdateFood(Food fd)
        {
            try
            {
                string query = @" update dbo.MonAn set tenMon = @tenMon , idLoai = @idLoai , giaTien = @giaTien where idMA = @idMA ";
                object[] ob = new object[] { fd.TenMon, fd.IdLoai, fd.GiaTien ,fd.IdMA };
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
        public bool DeleteFood(string idMA)
        {
            try
            {
                string qr = string.Format(" Delete dbo.MonAn where idMA = @idMA ");
                object[] ob = new object[] { idMA };
                int result = DataProvider.Instance.ExecuteNonQuery(qr, ob);
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
        public DataTable GetFoodTableBy(int loai)
        {
            try
            {
                string qr = string.Format(" Select * from dbo.MonAn where idLoai = @id ");
                object[] ob = new object[] { loai };
                return DataProvider.Instance.ExecuteQuery(qr, ob);
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
        public DataTable GetTableFoodName()
        {
            try
            {
                string query = "Select idMA as N'ID', tenMon as N'Tên món ăn' from dbo.MonAn";
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
        public DataTable GetTableFoodName(int id)
        {
            try
            {
                string query = "Select idMA as N'ID', tenMon as N'Tên món ăn' from dbo.MonAn where idLoai = " + id;
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
    }
}
