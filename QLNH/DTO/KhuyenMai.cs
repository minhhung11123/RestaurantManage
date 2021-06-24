using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhuyenMai
    {
        public KhuyenMai() { }
        
        public KhuyenMai(int id, string name, double percent)
        {
            this.Id = id;
            this.Name = name;
            this.Percent = percent;
        }

        int id;
        string name;
        double percent;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public double Percent { get => percent; set => percent = value; }
    }
}
