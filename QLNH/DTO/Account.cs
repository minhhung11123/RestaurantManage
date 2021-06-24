using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Account
    {
        public Account(string taiKhoan, string matKhau, string matKhau2, int loaiTK)
        {
            this.TaiKhoan = taiKhoan;
            this.MatKhau = matKhau;
            this.MatKhau2 = matKhau2;
            this.LoaiTK = loaiTK;
        }

        public Account() { }

        private string taiKhoan;
        private string matKhau;
        private string matKhau2;
        private int loaiTK;

        public string TaiKhoan { get => taiKhoan; set => taiKhoan = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public string MatKhau2 { get => matKhau2; set => matKhau2 = value; }
        public int LoaiTK { get => loaiTK; set => loaiTK = value; }
    }
}
