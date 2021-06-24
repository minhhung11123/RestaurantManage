using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
using System.Data.SqlClient;

namespace QLNH
{
    public partial class FormDangKy : Form
    {
        public FormDangKy()
        {
            InitializeComponent();
        }

        private void btnHoanTat_Click(object sender, EventArgs e)
        {
            try
            {
                if (NVBUS.Instance.CheckIDNV(Int32.Parse(txtIDNVDK.Text)))
                {
                    Account a = new Account();
                    a.TaiKhoan = txtUserNameDK.Text;
                    a.MatKhau = txtPass1.Text;
                    a.MatKhau2 = txtPass2.Text;
                    a.LoaiTK = 1;
                    if (AccountBUS.Instance.InsertAccount(a))
                    {
                        MessageBox.Show("Tạo thành công", "Thông báo", MessageBoxButtons.OK);
                        NVBUS.Instance.SetAccount(a.TaiKhoan, Int32.Parse(txtIDNVDK.Text));
                        this.Close();
                    }
                    else
                        MessageBox.Show("Tạo thất bại", "Thông báo", MessageBoxButtons.OK);
                }
                else
                    MessageBox.Show("ID nhân viên không hợp lệ", "Thông báo");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
