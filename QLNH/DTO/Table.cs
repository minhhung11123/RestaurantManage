using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DTO
{
    public class Table
    {
        public Table(int id, string name, int status)
        {
            this.ID = id;
            this.Name = name;
            this.Status = status;
        }
        public Table() { }
        public Table(DataRow row)
        {
            this.ID = (int)row["idBan"];
            this.Name = row["tenBan"].ToString();
            this.Status = (int)row["trangThai"];
        }

        private int iD;

        private string name;

        private int status;

        public int ID { get => iD; set => iD = value; }

        public string Name { get => name; set => name = value; }

        public int Status { get => status; set => status = value; }
    }
}
