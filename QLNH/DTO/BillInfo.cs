using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DTO
{
    public class BillInfo
    {
        public BillInfo(int idHD, int idMA, int soLuong)
        {
            this.IdHD = idHD;
            this.IdMA = idMA;
            this.SoLuong = soLuong;
        }

        public BillInfo(DataRow row)
        {
            this.IdHD = (int)row["idHD"];
            this.IdMA = (int)row["idMA"];
            this.SoLuong = (int)row["soLuong"];
        }

        public BillInfo() { }

        private int idHD;
        private int idMA;
        private int soLuong;

        public int IdHD { get => idHD; set => idHD = value; }
        public int IdMA { get => idMA; set => idMA = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
    }
}
