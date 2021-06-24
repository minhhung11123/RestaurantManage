using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;

namespace DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return AccountDAO.instance; }
            private set { AccountDAO.instance = value; }
        }

        private AccountDAO() { }

        public bool GetAccountLogin(Account a)
        {
            try
            {
                string qr = "select * from dbo.TaiKhoan where taiKhoan = @tk and matKhau = @mk";
                return DataProvider.Instance.ExecuteQuery(qr, new object[] { a.TaiKhoan, a.MatKhau }).Rows.Count > 0;
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
                return (int)DataProvider.Instance.ExecuteScalar("Select loaiTK from TaiKhoan where taiKhoan = @tk", new object[] { a.TaiKhoan });
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
                return (int)DataProvider.Instance.ExecuteScalar("Select idNV from dbo.TaiKhoan tk, dbo.NhanVien nv where tk.taiKhoan = @tk and tk.taiKhoan = nv.taiKhoan", new object[] { a.TaiKhoan });
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
                string qr = "insert into dbo.TaiKhoan values ( @taiKhoan , @matKhau , @matKhau2 , 1)";
                object[] ob = new object[] { a.TaiKhoan, a.MatKhau, a.MatKhau2 };
                return DataProvider.Instance.ExecuteNonQuery(qr, ob) > 0;
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
                string qr = "update dbo.TaiKhoan set matKhau = @mk where taiKhoan = @taiKhoan and matKhau2 = @mk2";
                object[] ob = new object[] { a.MatKhau, a.TaiKhoan, a.MatKhau2 };
                return DataProvider.Instance.ExecuteNonQuery(qr, ob) > 0;
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
                string qr = "delete dbo.TaiKhoan where taiKhoan = @tk";
                object[] ob = new object[] { tk };
                DataProvider.Instance.ExecuteNonQuery(qr, ob);
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
