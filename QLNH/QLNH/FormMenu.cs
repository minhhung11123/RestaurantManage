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
using System.Globalization;
using System.Threading;

namespace QLNH
{
    public partial class FormMenu : Form
    {
        private int idNV;
        private int idFoodMenu;
        private int role;

        public FormMenu()
        {
            InitializeComponent();
            try
            {
                LoadTable();
                LoadTableNV();
                dgvFoodTC.DataSource = FoodBUS.Instance.GetTableFoodName(0);
                dgvFoodTC.Columns[0].Width = 30;
                dgvFoodTC.Columns[1].Width = 255;
                idFoodMenu = Int32.Parse(dgvFoodTC.Rows[0].Cells[0].Value.ToString());
                LoadCBTable(cbSwitchTB);
                LoadCBTable(cbGopBan);
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        #region SetNV
        public void SetNV(int idNV1, int role1)
        {
            idNV = idNV1;
            role = role1;
            if (role == 1)
            {
                name.TabPages.Remove(tabPage9);
                name.TabPages.Remove(tabPage8);
                name.TabPages.Remove(tabPage4);
                name.TabPages.Remove(tabPage7);
            }
        }
        #endregion

        #region LoadFoodTC
        private void LoadFoodTC(object sender, EventArgs e)
        {
            try
            {
                int id = 0;
                Button btn = (Button)sender;
                if (btn.Text == "Tất cả")
                    id = 0;
                if (btn.Text == "Thức uống")
                    id = 1;
                if (btn.Text == "Rượu")
                    id = 2;
                if (btn.Text == "Khai vị")
                    id = 3;
                if (btn.Text == "Hải sản")
                    id = 4;
                if (btn.Text == "Bò")
                    id = 5;
                if (btn.Text == "Combo")
                    id = 6;
                if (btn.Text == "Tráng miệng")
                    id = 7;
                if (btn.Text == "Khác")
                    id = 8;
                dgvFoodTC.DataSource = FoodBUS.Instance.GetTableFoodName(id);
                idFoodMenu = Int32.Parse(dgvFoodTC.Rows[0].Cells[0].Value.ToString());
                dgvFoodTC.Columns[0].Width = 30;
                dgvFoodTC.Columns[1].Width = 255;
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region LoadTableTC
        void LoadTable()
        {
            try
            {
                List<Table> tableList = TableBUS.Instance.LoadTableList();
                foreach (Table tb in tableList)
                {
                    Button btn = new Button() { Width = 50, Height = 50 };
                    btn.Text = tb.Name;
                    btn.Click += btnTable_click;
                    btn.Tag = tb;
                    btn.BackColor = tb.Status == 0 ? Color.Gray : Color.Blue;
                    flpTable.Controls.Add(btn);
                }
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region ShowBill
        void ShowBill(int id)
        {
            try
            {
                flpTable.Controls.Clear();
                lvBill.Items.Clear();
                lbTable.Text = (lvBill.Tag as Table).Name;
                List<MenuBill> listMenuBill = MenuBillBUS.Instance.GetListMenuBillByTable(id);
                double thanhTien = 0;
                foreach (MenuBill item in listMenuBill)
                {
                    ListViewItem lsvItem = new ListViewItem(item.TenMon.ToString());
                    lsvItem.SubItems.Add(item.SoLuong.ToString());
                    lsvItem.SubItems.Add(item.GiaTien.ToString());
                    lsvItem.SubItems.Add(item.TongCong.ToString());
                    thanhTien += item.TongCong;
                    lvBill.Items.Add(lsvItem);
                }
                thanhTien = thanhTien - thanhTien * KhuyenMaiBUS.Instance.GetPercentByID(Int32.Parse(txtKM.Text));
                CultureInfo culture = new CultureInfo("vi-VN");
                txtThanhTien.Text = thanhTien.ToString("c", culture);
                LoadTable();
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region EventClickTable
        void btnTable_click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).ID;
            lvBill.Tag = (sender as Button).Tag;
            txtKM.Text = "1";
            ShowBill(tableID);
        }
        #endregion

        #region ThemMA
        private void btnThemMA_Click(object sender, EventArgs e)
        {
            try
            {
                Food fd = new Food();
                fd.TenMon = txtTenMon.Text;
                if (cbLoaiMon.Text == "Thức uống")
                    fd.IdLoai = 1;
                if (cbLoaiMon.Text == "Rượu")
                    fd.IdLoai = 2;
                if (cbLoaiMon.Text == "Khai vị")
                    fd.IdLoai = 3;
                if (cbLoaiMon.Text == "Hải sản")
                    fd.IdLoai = 4;
                if (cbLoaiMon.Text == "Bò")
                    fd.IdLoai = 5;
                if (cbLoaiMon.Text == "Combo")
                    fd.IdLoai = 6;
                if (cbLoaiMon.Text == "Tráng miệng")
                    fd.IdLoai = 7;
                if (cbLoaiMon.Text == "Khác")
                    fd.IdLoai = 8;
                fd.GiaTien = Int32.Parse(txtGiaTien.Text);
                if (FoodBUS.Instance.InsertFood(fd))
                {
                    MessageBox.Show("Thêm thành công");
                    LoadTableFood();
                }
                else
                    MessageBox.Show("Thêm thất bại");
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region NhapNV
        private void btnNhapNV_Click(object sender, EventArgs e)
        {
            try
            {
                NhanVien nv = new NhanVien();
                nv.HoTen = txtHoTen.Text;
                nv.DiaChi = txtDiaChi.Text;
                nv.NgaySinh = txtNgaySinh.Text;
                nv.SDT = txtSDT.Text;
                nv.LuongCoBan = Int32.Parse(txtLuongCoBan.Text);
                nv.PhuCap = Int32.Parse(txtPhuCap.Text);
                nv.SoCa = Int32.Parse(txtSoCa.Text);
                if (NVBUS.Instance.InsertNV(nv))
                {
                    MessageBox.Show("Thêm thành công!");
                    LoadTableNV();
                }
                else
                    MessageBox.Show("Thêm thất bại!");
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region SuaNV
        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            try
            {
                NhanVien nv = new NhanVien();
                nv.ID = Int32.Parse(txtMaNV.Text);
                nv.HoTen = txtHoTen.Text;
                nv.DiaChi = txtDiaChi.Text;
                nv.NgaySinh = txtNgaySinh.Text;
                nv.SDT = txtSDT.Text;
                nv.LuongCoBan = Int32.Parse(txtLuongCoBan.Text);
                nv.PhuCap = Int32.Parse(txtPhuCap.Text);
                nv.SoCa = Int32.Parse(txtSoCa.Text);
                if (NVBUS.Instance.EditNV(nv))
                {
                    MessageBox.Show("Sửa thành công!");
                    LoadTableNV();
                }
                else
                    MessageBox.Show("Sửa thất bại!");
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region XoaNV
        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            try
            {
                NhanVien nv = new NhanVien();
                nv.ID = Int32.Parse(txtMaNV.Text);
                if (MessageBox.Show("Xác nhận", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    if (NVBUS.Instance.DeleteNV(nv))
                    {
                        AccountBUS.Instance.DeleteAccount(dgvNV.Tag.ToString());
                        MessageBox.Show("Xóa thành công!");
                        LoadTableNV();
                    }
                    else
                        MessageBox.Show("Xóa thất bại!");
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region LoadTableNV
        void LoadTableNV()
        {
            try
            {
                dgvNV.DataSource = NVBUS.Instance.GetTableNV();
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region LoadTableFood
        void LoadTableFood()
        {
            try
            {
                dgvFood.DataSource = FoodBUS.Instance.GetTableFood(0);
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region SuaMonAn
        private void btnSuaMA_Click(object sender, EventArgs e)
        {
            try
            {
                Food fd = new Food();
                fd.IdMA = Int32.Parse(txtIdMonAn.Text);
                fd.TenMon = txtTenMon.Text;
                if (cbLoaiMon.Text == "Thức uống")
                    fd.IdLoai = 1;
                if (cbLoaiMon.Text == "Rượu")
                    fd.IdLoai = 2;
                if (cbLoaiMon.Text == "Khai vị")
                    fd.IdLoai = 3;
                if (cbLoaiMon.Text == "Hải sản")
                    fd.IdLoai = 4;
                if (cbLoaiMon.Text == "Bò")
                    fd.IdLoai = 5;
                if (cbLoaiMon.Text == "Combo")
                    fd.IdLoai = 6;
                if (cbLoaiMon.Text == "Tráng miệng")
                    fd.IdLoai = 7;
                if (cbLoaiMon.Text == "Khác")
                    fd.IdLoai = 8;
                fd.GiaTien = Int32.Parse(txtGiaTien.Text);
                if (FoodBUS.Instance.UpdateFood(fd))
                {
                    MessageBox.Show("Sửa thành công");
                    LoadTableFood();
                }
                else
                    MessageBox.Show("Sửa thất bại");
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region dgvFood click
        private void dgvFood_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            if (numrow > -1)
            {
                txtIdMonAn.Text = dgvFood.Rows[numrow].Cells[0].Value.ToString();
                txtTenMon.Text = dgvFood.Rows[numrow].Cells[1].Value.ToString();
                cbLoaiMon.Text = dgvFood.Rows[numrow].Cells[2].Value.ToString();
                txtGiaTien.Text = dgvFood.Rows[numrow].Cells[3].Value.ToString();
            }
        }
        #endregion

        #region XoaMonAn
        private void btnXoaMA_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Int32.Parse(txtIdMonAn.Text);
                if (FoodBUS.Instance.DeleteFood(id.ToString()))
                {
                    MessageBox.Show("Xóa thành công");
                    LoadTableFood();
                }
                else
                    MessageBox.Show("Xóa thất bại");

            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region LoadTableTB
        void LoadTableTB()
        {
            try
            {
                dgvBan.DataSource = TableBUS.Instance.GetTableTB();
                dgvBan.Columns[0].HeaderText = "ID Bàn";
                dgvBan.Columns[1].HeaderText = "Tên Bàn";
                dgvBan.Columns[2].HeaderText = "Trạng thái bàn";
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region ThemBan
        private void btnThemBan_Click(object sender, EventArgs e)
        {
            try
            {
                Table tb = new Table();
                tb.Name = txtTenBan.Text;
                tb.Status = 0;
                if (TableBUS.Instance.InsertTable(tb))
                {
                    MessageBox.Show("Thêm thành công");
                    LoadTableTB();
                }
                else
                    MessageBox.Show("Thêm thất bại");
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region dgvBan_Click
        private void dgvBan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                int numrow;
                numrow = e.RowIndex;
                if (numrow > -1)
                {
                    txtIDBan.Text = dgvBan.Rows[numrow].Cells[0].Value.ToString();
                    txtTenBan.Text = dgvBan.Rows[numrow].Cells[1].Value.ToString();
                }
            }
        }
        #endregion

        #region SuaBam
        private void btnSuaBan_Click(object sender, EventArgs e)
        {
            try
            {
                Table tb = new Table();
                tb.ID = Int32.Parse(txtIDBan.Text);
                tb.Name = txtTenBan.Text;
                if (TableBUS.Instance.UpdateTable(tb))
                {
                    MessageBox.Show("Sửa thành công");
                    LoadTableTB();
                }
                else
                    MessageBox.Show("Sửa thất bại");
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region ChuyenTrang
        private void name_Click(object sender, EventArgs e)
        {
            try
            {
                if (role == 1)
                {
                    LoadTableFood();
                    LoadCBTable(cbSwitchTB);
                    LoadCBTable(cbGopBan);
                    SetTimeHistory();
                    LoadKho();
                    btnXem_Click(new Button(), new EventArgs());
                }
                else
                {
                    LoadTableTB();
                    LoadTableFood();
                    LoadCBTable(cbSwitchTB);
                    LoadCBTable(cbGopBan);
                    SetTimeHistory();
                    LoadKM();
                    LoadKho();
                    btnXem_Click(new Button(), new EventArgs());
                    txtNgaySinh.Text = "mm/dd/yyyy";
                }
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region XoaBan
        private void btnXoaBan_Click(object sender, EventArgs e)
        {
            try
            {
                Table tb = new Table();
                tb.ID = Int32.Parse(txtIDBan.Text);
                if (TableBUS.Instance.DeleteTable(tb))
                {
                    MessageBox.Show("Xóa thành công");
                    LoadTableTB();
                }
                else
                    MessageBox.Show("Xóa thất bại");

            }
            catch(SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region food_click_QLFood
        private void food_Click(object sender, EventArgs e)
        {
            try
            {
                RadioButton btn = (RadioButton)sender;
                int id = Int32.Parse(btn.Tag.ToString());
                dgvFood.DataSource = FoodBUS.Instance.GetTableFood(id);
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        #endregion

        #region btnThemMonVaoBill
        private void btnThemMonVaoBill_Click(object sender, EventArgs e)
        {
            try
            {
                Table table = lvBill.Tag as Table;
                BillInfo bi = new BillInfo();
                bi.IdMA = idFoodMenu;
                bi.SoLuong = (int)nmSoLuong.Value;
                int idBill = BillBUS.Instance.GetUncheckBillByTableID(table.ID);
                if (idBill == -1)
                {
                    BillBUS.Instance.InsertBill(idNV, table.ID);
                    bi.IdHD = BillBUS.Instance.GetMaxIDBill();
                    BillInfoBUS.Instance.InsertBillInfo(bi);
                }
                else
                {
                    bi.IdHD = idBill;
                    BillInfoBUS.Instance.InsertBillInfo(bi);
                }
                ShowBill(table.ID);
                nmSoLuong.Value = 0;
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region dgvFoodTCClick
        private void dgvFoodTC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                idFoodMenu = Int32.Parse(dgvFoodTC.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }
        #endregion

        #region ThanhToan
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                Table table = lvBill.Tag as Table;
                int idBill = BillBUS.Instance.GetUncheckBillByTableID(table.ID);
                if (idBill != -1)
                {
                    if (MessageBox.Show("Bạn muốn thanh toán cho bàn " + table.Name, "Xác nhận", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        int maKM = Int32.Parse(txtKM.Text);
                        int tongTien = Int32.Parse(txtThanhTien.Text.Split(',')[0].Replace(".",""));
                        BillBUS.Instance.ThanhToan(idBill, maKM, tongTien);
                        DataTable dt = ReportBUS.Instance.GetDataBill(idBill);
                        RPBill rp = new RPBill();
                        rp.SetDataSource(dt);
                        FormReport f = new FormReport();
                        f.crystalReportViewer1.ReportSource = rp;
                        f.ShowDialog();
                        ShowBill(table.ID);
                    }
                }
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Leave_TextBoxKM
        private void txtKM_Leave(object sender, EventArgs e)
        {
            if (Int32.Parse(txtKM.Text) > 0)
            {
                Table table = lvBill.Tag as Table;
                if (KhuyenMaiBUS.Instance.GetPercentByID(Int32.Parse(txtKM.Text)) == -1)
                {
                    MessageBox.Show("Mã giảm giá không hợp lệ!", "Thông báo", MessageBoxButtons.OK);
                    txtKM.Text = "1";
                }
                ShowBill(table.ID);
            }
        }
        #endregion

        #region ChuyenBan
        private void btnChuyenBan_Click(object sender, EventArgs e)
        {
            try
            {
                int id1 = (lvBill.Tag as Table).ID;
                int id2 = (cbSwitchTB.SelectedItem as Table).ID;
                if (MessageBox.Show(string.Format("Chuyển {0} qua {1}", (lvBill.Tag as Table).Name, (cbSwitchTB.SelectedItem as Table).Name), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    TableBUS.Instance.SwitchTable(id1, id2, idNV);
                    ShowBill(id1);
                }
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region LoadCBTable
        void LoadCBTable(ComboBox cb)
        {
            cb.DataSource = TableBUS.Instance.LoadTableList();
            cb.DisplayMember = "Name";
        }
        #endregion

        #region GopBan
        private void btnGopBan_Click(object sender, EventArgs e)
        {
            try
            {
                int id1 = (lvBill.Tag as Table).ID;
                int id2 = (cbGopBan.SelectedItem as Table).ID;
                if (MessageBox.Show(string.Format("Gộp {0} qua {1}", (lvBill.Tag as Table).Name, (cbGopBan.SelectedItem as Table).Name), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    TableBUS.Instance.MergeTable(id1, id2, idNV);
                    ShowBill(id1);
                }
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region XemLichSuThanhToan
        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                dgvLSThanhToan.DataSource = BillBUS.Instance.GetDataTableHistory(dtFirstDay.Value, dtSecondDay.Value);
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region SetTimeHistory
        void SetTimeHistory()
        {
            DateTime today = DateTime.Now;
            dtFirstDay.Value = new DateTime(today.Year, today.Month, 1);
            dtSecondDay.Value = dtFirstDay.Value.AddMonths(1).AddDays(-1);
        }
        #endregion

        #region dgvNVClick
        private void dgvNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            if (numrow > -1)
            {
                txtMaNV.Text = dgvNV.Rows[numrow].Cells[0].Value.ToString();
                txtHoTen.Text = dgvNV.Rows[numrow].Cells[1].Value.ToString();
                txtDiaChi.Text = dgvNV.Rows[numrow].Cells[2].Value.ToString();
                txtNgaySinh.Text = dgvNV.Rows[numrow].Cells[3].Value.ToString().Split(' ')[0];
                txtSDT.Text = dgvNV.Rows[numrow].Cells[4].Value.ToString();
                txtLuongCoBan.Text = dgvNV.Rows[numrow].Cells[5].Value.ToString();
                txtPhuCap.Text = dgvNV.Rows[numrow].Cells[6].Value.ToString();
                txtSoCa.Text = dgvNV.Rows[numrow].Cells[7].Value.ToString();
                dgvNV.Tag = dgvNV.Rows[numrow].Cells[8].Value.ToString();
            }
        }
        #endregion

        #region ThemKM
        private void btnThemKM_Click(object sender, EventArgs e)
        {
            try
            {
                KhuyenMai km = new KhuyenMai();
                km.Name = txtTenKM.Text;
                km.Percent = Double.Parse(txtPhamTramKM.Text);
                if (KhuyenMaiBUS.Instance.InsertKM(km))
                {
                    MessageBox.Show("Thêm thành công");
                    LoadKM();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
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
        #endregion

        #region LoadKM
        void LoadKM()
        {
            try
            {
                dgvKM.DataSource = KhuyenMaiBUS.Instance.GetTableKM();
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
        #endregion

        #region dgvKMClick
        private void dgvKM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            if (numrow > -1)
            {
                txtMaKM.Text = dgvKM.Rows[numrow].Cells[0].Value.ToString();
                txtTenKM.Text = dgvKM.Rows[numrow].Cells[1].Value.ToString();
                txtPhamTramKM.Text = dgvKM.Rows[numrow].Cells[2].Value.ToString();
            }
        }
        #endregion

        #region EditKM
        private void btnSuaKM_Click(object sender, EventArgs e)
        {
            try
            {
                KhuyenMai km = new KhuyenMai();
                km.Name = txtTenKM.Text;
                km.Percent = Double.Parse(txtPhamTramKM.Text);
                km.Id = Int32.Parse(txtMaKM.Text);
                if (KhuyenMaiBUS.Instance.EditKM(km))
                {
                    MessageBox.Show("Sửa thành công");
                    LoadKM();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại");
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
        #endregion

        #region DeleteKM
        private void btnXoaKM_Click(object sender, EventArgs e)
        {
            try
            {
                KhuyenMai km = new KhuyenMai();
                km.Id = Int32.Parse(txtMaKM.Text);
                if (KhuyenMaiBUS.Instance.DeleteKM(km))
                {
                    MessageBox.Show("Xóa thành công");
                    LoadKM();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại");
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
        #endregion

        #region LoadKho
        void LoadKho()
        {
            try
            {
                dgvKho.DataSource = KhoBUS.Instance.GetTableKho();
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
        #endregion

        #region NhapKho
        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            try
            {
                Kho k = new Kho();
                k.Name = txtTenNL.Text;
                k.Type = txtLoaiNL.Text;
                k.Count = Int32.Parse(txtSLNL.Text);
                k.NCC = txtNCC.Text;
                k.NgayNhap = txtNgayNhap.Text;
                k.Sdt = txtSDTKho.Text;
                k.TongTien = Int32.Parse(txtThanhToanKho.Text);
                k.DiaChi = txtDiaChiKho.Text;
                if (KhoBUS.Instance.InsertKho(k))
                {
                    MessageBox.Show("Thêm thành công");
                    LoadKho();
                }
                else
                    MessageBox.Show("Thêm thất bại");

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
        #endregion

        #region dgvKhoClick
        private void dgvKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            if (numrow > -1)
            {
                txtMaNL.Text = dgvKho.Rows[numrow].Cells[0].Value.ToString();
                txtTenNL.Text = dgvKho.Rows[numrow].Cells[1].Value.ToString();
                txtLoaiNL.Text = dgvKho.Rows[numrow].Cells[2].Value.ToString();
                txtSLNL.Text = dgvKho.Rows[numrow].Cells[3].Value.ToString();
                txtNCC.Text = dgvKho.Rows[numrow].Cells[4].Value.ToString();
                txtNgayNhap.Text = dgvKho.Rows[numrow].Cells[5].Value.ToString().Split(' ')[0];
                txtDiaChiKho.Text = dgvKho.Rows[numrow].Cells[6].Value.ToString();
                txtSDTKho.Text = dgvKho.Rows[numrow].Cells[7].Value.ToString();
                txtThanhToanKho.Text = dgvKho.Rows[numrow].Cells[8].Value.ToString();
            }
        }

        #endregion

        #region SuaKho
        private void btnSuaKho_Click(object sender, EventArgs e)
        {
            try
            {
                Kho k = new Kho();
                k.Id = Int32.Parse(txtMaNL.Text);
                k.Name = txtTenNL.Text;
                k.Type = txtLoaiNL.Text;
                k.Count = Int32.Parse(txtSLNL.Text);
                k.NCC = txtNCC.Text;
                k.NgayNhap = txtNgayNhap.Text;
                k.Sdt = txtSDTKho.Text;
                k.TongTien = Int32.Parse(txtThanhToanKho.Text);
                k.DiaChi = txtDiaChiKho.Text;
                if (KhoBUS.Instance.EditKho(k))
                {
                    MessageBox.Show("Sửa thành công");
                    LoadKho();
                }
                else
                    MessageBox.Show("Sửa thất bại");

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
        #endregion

        #region XoaKho
        private void btnXoaKho_Click(object sender, EventArgs e)
        {
            try
            {
                Kho k = new Kho();
                k.Id = Int32.Parse(txtMaNL.Text);
                if (KhoBUS.Instance.DeleteKho(k))
                {
                    MessageBox.Show("Xóa thành công");
                    LoadKho();
                }
                else
                    MessageBox.Show("Xóa thất bại");

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


        #endregion

        #region ShowRPNgay
        private void btnDTNgay_Click(object sender, EventArgs e)
        {
            try
            {
                ReportBCDTNgay rp = new ReportBCDTNgay();
                DataTable dt = ReportBUS.Instance.GetRPDTNgay(dtRP.Value);
                rp.SetDataSource(dt);
                crDT.ReportSource = rp;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region ShowRPThang
        private void btnDTThang_Click(object sender, EventArgs e)
        {
            try
            {
                ReportBCDTThang rp = new ReportBCDTThang();
                DataTable dt = ReportBUS.Instance.GetRPDTThang(dtRP.Value);
                rp.SetDataSource(dt);
                crDT.ReportSource = rp;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region ShowRPNam
        private void btnDTNam_Click(object sender, EventArgs e)
        {
            try
            {
                ReportBCDTNam rp = new ReportBCDTNam();
                DataTable dt = ReportBUS.Instance.GetRPDTNam(dtRP.Value);
                rp.SetDataSource(dt);
                crDT.ReportSource = rp;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
