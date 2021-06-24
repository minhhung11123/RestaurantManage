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
    public class FoodBUS
    {
        private static FoodBUS instance;

        public static FoodBUS Instance
        {
            get { if (instance == null) instance = new FoodBUS(); return FoodBUS.instance; }
            private set { FoodBUS.instance = value; }
        }

        public FoodBUS() { }

        public bool InsertFood(Food fd)
        {
            try
            {
                return FoodDAO.Instance.InsertFood(fd);
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

        public DataTable GetTableFood(int id)
        {
            try
            {
                if (id == 0)
                    return FoodDAO.Instance.GetTableFood();
                return FoodDAO.Instance.GetTableFood(id);
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

        public bool UpdateFood(Food fd)
        {
            try
            {
                return FoodDAO.Instance.UpdateFood(fd);
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
        public bool DeleteFood(string fd)
        {
            try
            {
                return FoodDAO.Instance.DeleteFood(fd);
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
        public DataTable GetTableFoodBy(int loai)
        {
            try
            {
                return FoodDAO.Instance.GetFoodTableBy(loai);
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
        public DataTable GetTableFoodName(int id)
        {
            try
            {
                if (id == 0)
                    return FoodDAO.Instance.GetTableFoodName();
                return FoodDAO.Instance.GetTableFoodName(id);
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
