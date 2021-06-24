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
    public class KhoDAO
    {
        private static KhoDAO instance;

        public static KhoDAO Instance
        {
            get { if (instance == null) instance = new KhoDAO(); return KhoDAO.instance; }
            private set { KhoDAO.instance = value; }
        }

        private KhoDAO() { }

        public bool InsertKho(Kho k)
        {
            try
            {
                string qr = "Insert into dbo.Kho values ( @1 , @2 , @3 , @4 , @5 , @6 , @7 , @8 )";
                object[] ob = new object[] { k.Name, k.Type, k.Count, k.NCC, k.NgayNhap, k.DiaChi, k.Sdt, k.TongTien };
                return DataProvider.Instance.ExecuteNonQuery(qr,ob) > 0;
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
                return DataProvider.Instance.ExecuteQuery("select * from dbo.Kho");
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
                string qr = "update dbo.Kho set tenSanPham = @1 , loaiSanPham = @2 , soLuong = @3 , nhaCungCap = @4 , ngayNhapKho = @5 , diaChi = @6 , SDT = @7 , tongTien = @8 where idSanPham = @9";
                object[] ob = new object[] { k.Name, k.Type, k.Count, k.NCC, k.NgayNhap, k.DiaChi, k.Sdt, k.TongTien, k.Id };
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

        public bool DeleteKho(Kho k)
        {
            try
            {
                string qr = "delete dbo.Kho where idSanPham = @9";
                object[] ob = new object[] { k.Id };
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
    }
}
