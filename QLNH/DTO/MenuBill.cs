using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DTO
{
    public class MenuBill
    {
        public MenuBill(string tenMon, int soLuong, int giaTien, int tongCong = 0)
        {
            this.TenMon = tenMon;
            this.SoLuong = soLuong;
            this.GiaTien = giaTien;
            this.TongCong = tongCong;
        }

        public MenuBill(DataRow dr)
        {
            this.TenMon = dr["tenMon"].ToString();
            this.SoLuong = (int)dr["soLuong"];
            this.GiaTien = (int)dr["giaTien"];
            this.TongCong = (int)dr["tongCong"];
        }

        private string tenMon;
        private int soLuong;
        private int giaTien;
        private int tongCong;

        public string TenMon { get => tenMon; set => tenMon = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public int GiaTien { get => giaTien; set => giaTien = value; }
        public int TongCong { get => tongCong; set => tongCong = value; }
    }
}
