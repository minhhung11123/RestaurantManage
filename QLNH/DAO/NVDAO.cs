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
    public class NVDAO
    {
        private static NVDAO instance;

        public static NVDAO Instance
        {
            get { if (instance == null) instance = new NVDAO(); return NVDAO.instance; }
            private set { NVDAO.instance = value; }
        }
      
        private NVDAO() { }

        public bool InsertNV(NhanVien nv)
        {
            try
            {
                string query = @"insert into dbo.NhanVien values ( @hoTen , @diaChi , @ngaySinh , @sdt , @luongCoBan , @phuCap , @soCa , null )";
                object[] ob = new object[] { nv.HoTen, nv.DiaChi, nv.NgaySinh, nv.SDT, nv.LuongCoBan, nv.PhuCap, nv.SoCa};
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

        public DataTable GetTableNV()
        {
            try
            {
                string query = "GetNVList";
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

        public bool EditNV(NhanVien nv)
        {
            try
            {
                string query = @"update dbo.NhanVien set hoTenNV = @hoTen , diaChi = @diaChi , ngaySinh = @ngaySinh , sdt = @sdt , luongCoBan = @luongCoBan , phuCap = @phuCap , soCa = @soCa where idNV = @id";
                object[] ob = new object[] { nv.HoTen, nv.DiaChi, nv.NgaySinh, nv.SDT, nv.LuongCoBan, nv.PhuCap, nv.SoCa, nv.ID };
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

        public bool DeleteNV(NhanVien nv)
        {
            try
            {
                string query = @"delete dbo.NhanVien where idNV = @id";
                object[] ob = new object[] { nv.ID };
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

        public bool CheckIDNV(int id)
        {
            try
            {
                return DataProvider.Instance.ExecuteQuery("select * from dbo.NhanVien where idNV = @id", new object[] { id }).Rows.Count > 0;
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
                DataProvider.Instance.ExecuteNonQuery("update dbo.NhanVien set taiKhoan = @taiKhoan where idNV = @id", new object[] { acc, id });
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
