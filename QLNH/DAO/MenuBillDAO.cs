using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAO
{
    public class MenuBillDAO
    {
        private static MenuBillDAO instance;

        public static MenuBillDAO Instance
        {
            get { if (instance == null) instance = new MenuBillDAO(); return MenuBillDAO.instance; }
            private set { MenuBillDAO.instance = value; }
        }

        private MenuBillDAO() { }

        public List<MenuBill> GetListMenuBillByTable(int id)
        {
            List<MenuBill> listMenuBill = new List<MenuBill>();
            DataTable tb = DataProvider.Instance.ExecuteQuery("GetMenuBill "+ id);
            foreach (DataRow item in tb.Rows)
            {
                MenuBill info = new MenuBill(item);
                listMenuBill.Add(info);
            }
            return listMenuBill;
        }
    }
}
