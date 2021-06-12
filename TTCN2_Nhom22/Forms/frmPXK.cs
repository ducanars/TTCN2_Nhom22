using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TTCN2_Nhom22.Forms
{
    public partial class frmPXK : Form
    {
        public frmPXK()
        {
            InitializeComponent();
        }

        private void frmPXK_Load(object sender, EventArgs e)
        {

        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            DataTable KQ = new DataTable();
            string sql = "";
            string ngay = (dtpNgayxuat.Value).ToString();
            string[] cat = ngay.Split(' ');
            string tk = cat[0];
            try
            {
                sql = "SELECT tblHDXuat.MaNV, tblHDXuat.MaKH, tblChiTietHDXuat.MaSP, tblChiTietHDXuat.Soluong FROM tblHDXuat join tblChiTietHDXuat on tblHDXuat.MaHDXuat=tblChitietHDXuat.MaHDXuat  WHERE  tblHDXuat.Ngayxuat= N'" + ThucthiSQL.ConvertDateTime(dtpNgayxuat.Text) + "'";
            }
            catch
            {
                sql = "";
            }
            KQ = ThucthiSQL.DocBang(sql);
            if (KQ.Rows.Count <= 0)
            {
                MessageBox.Show("Không tìm thấy dữ liệu theo ngày", "Thông báo");
                return;
            }
            else
            {
                dataGridView1.DataSource = KQ;
                dataGridView1.Columns[0].HeaderText = "Mã nhân viên";
                dataGridView1.Columns[1].HeaderText = "Mã khách hàng";
                dataGridView1.Columns[2].HeaderText = "Mã hàng";
                dataGridView1.Columns[3].HeaderText = "Số lượng";
                dataGridView1.Columns[0].Width = 200;
                dataGridView1.Columns[1].Width = 100;
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[3].Width = 150;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
                KQ.Dispose();
            }
        }
    }
}
