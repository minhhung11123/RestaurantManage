using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BUS;
using DTO;

namespace QLNH
{
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Account acc = new Account();
                acc.TaiKhoan = txtUsername.Text;
                acc.MatKhau = txtPassword.Text;
                if (AccountBUS.Instance.GetAccountLogin(acc))
                {
                    FormMenu f = new FormMenu();
                    f.SetNV(AccountBUS.Instance.GetIDNV(acc), AccountBUS.Instance.GetRole(acc));
                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Thông tin đăng nhập không chính xác!", "Thông báo", MessageBoxButtons.OK);
                }
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

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            FormDangKy f = new FormDangKy();
            f.ShowDialog();
        }

        private void llForgotPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormQuenMatKhau f = new FormQuenMatKhau();
            f.ShowDialog();
        }
    }
}
