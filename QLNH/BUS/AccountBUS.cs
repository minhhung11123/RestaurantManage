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
    public class AccountBUS
    {
        private static AccountBUS instance;

        public static AccountBUS Instance
        {
            get { if (instance == null) instance = new AccountBUS(); return AccountBUS.instance; }
            private set { AccountBUS.instance = value; }
        }

        private AccountBUS() { }

        public bool GetAccountLogin(Account a)
        {
            try
            {
                return AccountDAO.Instance.GetAccountLogin(a);
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

        public int GetRole(Account a)
        {
            try
            {
                return AccountDAO.Instance.GetRole(a);
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

        public int GetIDNV(Account a)
        {
            try
            {
                return AccountDAO.Instance.GetIDNV(a);
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

        public bool InsertAccount(Account a)
        {
            try
            {
                return AccountDAO.Instance.InsertAccount(a);
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

        public bool FogotAccount(Account a)
        {
            try
            {
                return AccountDAO.Instance.FogotAccount(a);
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

        public void DeleteAccount(string tk)
        {
            try
            {
                AccountDAO.Instance.DeleteAccount(tk);
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
