using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class MenuBillBUS
    {
        private static MenuBillBUS instance;

        public static MenuBillBUS Instance
        {
            get { if (instance == null) instance = new MenuBillBUS(); return MenuBillBUS.instance; }
            private set { MenuBillBUS.instance = value; }
        }

        public MenuBillBUS() { }

        public List<MenuBill> GetListMenuBillByTable(int id)
        {
            return MenuBillDAO.Instance.GetListMenuBillByTable(id);
        }
    }
}
