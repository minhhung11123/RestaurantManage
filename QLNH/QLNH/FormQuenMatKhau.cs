using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;
using System.Data.SqlClient;

namespace QLNH
{
    public partial class FormQuenMatKhau : Form
    {
        public FormQuenMatKhau()
        {
            InitializeComponent();
        }

        private void btnHT_Click(object sender, EventArgs e)
        {
            try
            {
                Account a = new Account();
                a.TaiKhoan = txtUserNameFP.Text;
                a.MatKhau = txtNewPass.Text;
                a.MatKhau2 = txtPass2FP.Text;
                if (AccountBUS.Instance.FogotAccount(a))
                {
                    MessageBox.Show("Đổi mật khẩu thành công");
                    this.Close();
                }
                else
                    MessageBox.Show("Đổi mật khẩu thất bại");
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
