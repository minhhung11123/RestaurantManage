using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Food
    {
        public Food(int idMA, string tenMon, int idLoai, int giaTien)
        {
            this.IdMA = idMA;
            this.TenMon = tenMon;
            this.IdLoai = idLoai;
            this.GiaTien = giaTien;
        }

        public Food() { }
        private int idMA;
        private string tenMon;
        private int idLoai;
        private int giaTien;

        public int IdMA { get => idMA; set => idMA = value; }
        public string TenMon { get => tenMon; set => tenMon = value; }
        public int IdLoai { get => idLoai; set => idLoai = value; }
        public int GiaTien { get => giaTien; set => giaTien = value; }
    }
}
