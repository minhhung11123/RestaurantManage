using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class DataProvider
    {
        private static DataProvider instance;

        private string cnstring = @"Data Source=.\SQLEXPRESS;Initial Catalog=dbQLNH;Integrated Security=True";

        internal static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }

        private DataProvider() { }

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection cnn = new SqlConnection(cnstring))
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand(query, cnn);
                    if (parameter != null)
                    {
                        int i = 0;
                        string[] list = query.Split(' ');
                        foreach (string item in list)
                        {
                            if (item.Contains('@'))
                            {
                                cmd.Parameters.AddWithValue(item, parameter[i]);
                                i++;
                            }
                        }
                    }
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    cnn.Close();
                }
                return dt;
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

        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            try
            {
                int data = 0;
                using (SqlConnection cnn = new SqlConnection(cnstring))
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand(query, cnn);
                    if (parameter != null)
                    {
                        int i = 0;
                        string[] list = query.Split(' ');
                        foreach (string item in list)
                        {
                            if (item.Contains('@'))
                            {
                                cmd.Parameters.AddWithValue(item, parameter[i]);
                                i++;
                            }
                        }
                    }
                    data = cmd.ExecuteNonQuery();
                    cnn.Close();
                }
                return data;
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

        public object ExecuteScalar(string query, object[] parameter = null)
        {
            try
            {
                object data = 0;
                using (SqlConnection cnn = new SqlConnection(cnstring))
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand(query, cnn);
                    if (parameter != null)
                    {
                        int i = 0;
                        string[] list = query.Split(' ');
                        foreach (string item in list)
                        {
                            if (item.Contains('@'))
                            {
                                cmd.Parameters.AddWithValue(item, parameter[i]);
                                i++;
                            }
                        }
                    }
                    data = cmd.ExecuteScalar();
                    cnn.Close();
                }
                return data;
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
