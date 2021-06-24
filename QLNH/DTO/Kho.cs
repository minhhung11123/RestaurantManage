using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Kho
    {
        public Kho() { }

        private int id;
        private string name;
        private string type;
        private int count;
        private string nCC;
        private string ngayNhap;
        private string diaChi;
        private string sdt;
        private int tongTien;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Type { get => type; set => type = value; }
        public int Count { get => count; set => count = value; }
        public string NCC { get => nCC; set => nCC = value; }
        public string NgayNhap { get => ngayNhap; set => ngayNhap = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public int TongTien { get => tongTien; set => tongTien = value; }
    }
}
