using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVien
    {
        public NhanVien(int id, string hoTen, string diaChi, string ngaySinh, string sdt, int luongCoBan, int phuCap, int soCa, string taiKhoan)
        {
            this.ID = id;
            this.HoTen = hoTen;
            this.DiaChi = diaChi;
            this.NgaySinh = ngaySinh;
            this.SDT = sdt;
            this.LuongCoBan = luongCoBan;
            this.PhuCap = phuCap;
            this.SoCa = soCa;
            this.TaiKhoan = taiKhoan;
        }

        public NhanVien() { }

        private int iD;
        private string hoTen;
        private string diaChi;
        private string ngaySinh;
        private string sDT;
        private int luongCoBan;
        private int phuCap;
        private int soCa;
        private string taiKhoan;

        public int ID { get => iD; set => iD = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string SDT { get => sDT; set => sDT = value; }
        public int LuongCoBan { get => luongCoBan; set => luongCoBan = value; }
        public int PhuCap { get => phuCap; set => phuCap = value; }
        public int SoCa { get => soCa; set => soCa = value; }
        public string NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string TaiKhoan { get => taiKhoan; set => taiKhoan = value; }
    }
}
