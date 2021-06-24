using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Bill
    {
        private int idHD;
        private int idNV;
        private int idBan;
        private DateTime? thoiGianVao;
        private DateTime? thoiGianRa;
        private int status;
        private int idKM;
        private int tongTien;

        public Bill(int id, DateTime? thoiGianVao, DateTime? thoiGianRa, int status)
        {
            this.IdHD = id;
            this.ThoiGianVao = thoiGianVao;
            this.ThoiGianRa = thoiGianRa;
            this.Status = status;
        }

        public Bill(DataRow row)
        {
            this.IdHD = (int)row["idHD"];
            this.ThoiGianVao = (DateTime?)row["thoiGianVao"];
            //this.ThoiGianRa = (DateTime?)row["thoiGianRa"];
            this.Status = (int)row["trangThai"];
        }

        public int IdHD { get => idHD; set => idHD = value; }
        public int IdNV { get => idNV; set => idNV = value; }
        public int IdBan { get => idBan; set => idBan = value; }
        public DateTime? ThoiGianVao { get => thoiGianVao; set => thoiGianVao = value; }
        public DateTime? ThoiGianRa { get => thoiGianRa; set => thoiGianRa = value; }
        public int Status { get => status; set => status = value; }
        public int IdKM { get => idKM; set => idKM = value; }
        public int TongTien { get => tongTien; set => tongTien = value; }
    }
}
