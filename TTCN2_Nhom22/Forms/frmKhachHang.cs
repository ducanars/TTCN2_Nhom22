using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTCN2_Nhom22.Forms
{
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {           
            dataGridView1.Enabled = false;
            txtMaKH.Enabled = true;
            txtTenKH.Enabled = true;
            txtDiachi.Enabled = true;
            txtSDT.Enabled = true;
            txtEmail.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaKH.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKH.Focus();
            }
            if (txtTenKH.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenKH.Focus();
            }
            if (txtSDT.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
            }
            if (txtDiachi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiachi.Focus();
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập email khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
            }
            sql = "update tblKhachHang set TenKH=N'" + txtTenKH.Text.Trim() + "',SDT=N'" + txtSDT.Text.Trim() + "',Diachi=N'"
                + txtDiachi.Text.Trim() + "',Email=N'" + txtEmail.Text.Trim() + "' where MaKH ='" + txtMaKH.Text.Trim() + "'";
            ThucthiSQL.OpenConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = ThucthiSQL.con;
            cmd.ExecuteNonQuery();
            ThucthiSQL.CloseConnection();
            loadDataGridView();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string sql = "delete from tblKhachHang where MaKH = '" + txtMaKH.Text + "'";
                ThucthiSQL.OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = ThucthiSQL.con;
                cmd.ExecuteNonQuery();
                ThucthiSQL.CloseConnection();
                loadDataGridView();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql1, sql2;
            if (txtMaKH.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKH.Focus();
            }
            if (txtTenKH.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenKH.Focus();
            }
            if (txtSDT.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
            }
            if (txtDiachi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiachi.Focus();
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập email khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
            }
            if (txtMaKH.Text.Substring(0, 2) != "KH")
            {
                MessageBox.Show("Mã khách hàng phải có dạng 'KHxx'");
                txtMaKH.Focus();
                return;
            }
            sql1 = "Select * from tblKhachHang where MaKH ='" + txtMaKH.Text.Trim() + "'";
            sql2 = "Select * from tblKhachHang where SDT ='" + txtSDT.Text.Trim() + "'";
            ThucthiSQL.OpenConnection();
            if (ThucthiSQL.CheckKeyExit(sql1))
            {
                MessageBox.Show("Mã khách hàng đã tồn tại, vui lòng xem lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ThucthiSQL.CloseConnection();
                txtMaKH.Focus();
                return;
            }
            if (ThucthiSQL.CheckKeyExit(sql2))
            {
                MessageBox.Show("Số điện thoại này đã tồn tại, vui lòng xem lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ThucthiSQL.CloseConnection();
                txtSDT.Focus();
                return;
            }
            else
            {
                sql1 = "insert into tblKhachHang (MaKH,TenKH,SDT,Diachi,Email) " +
                    " values ('" + txtMaKH.Text.Trim() + "',N'" + txtTenKH.Text.Trim() + "',N'" + txtSDT.Text.Trim() + "',N'"
                    + txtDiachi.Text.Trim() + "',N'" + txtEmail.Text.Trim() + "')";
                SqlCommand cmd = new SqlCommand(sql1, ThucthiSQL.con);
                cmd.ExecuteNonQuery();
                ThucthiSQL.CloseConnection();
                loadDataGridView();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetValue();
        }

        private void ResetValue()
        {
            txtMaKH.Enabled = false;
            txtMaKH.Text = "";
            txtTenKH.Enabled = false;
            txtTenKH.Text = "";
            txtDiachi.Enabled = false;
            txtDiachi.Text = "";
            txtSDT.Enabled = false;
            txtSDT.Text = "";
            txtEmail.Enabled = false;
            txtEmail.Text = "";
            dataGridView1.Enabled = true;
        }

        private void loadDataGridView()
        {
            string sql = "select * from tblKhachHang";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, ThucthiSQL.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            ThucthiSQL.OpenConnection();
            loadDataGridView();
            ThucthiSQL.CloseConnection();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaKH.Text = dataGridView1.CurrentRow.Cells["MaKH"].Value.ToString();
            txtTenKH.Text = dataGridView1.CurrentRow.Cells["TenKH"].Value.ToString();
            txtSDT.Text = dataGridView1.CurrentRow.Cells["SDT"].Value.ToString();
            txtDiachi.Text = dataGridView1.CurrentRow.Cells["Diachi"].Value.ToString();
            txtEmail.Text = dataGridView1.CurrentRow.Cells["Email"].Value.ToString();
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < '0') || (e.KeyChar > '9')) && (Convert.ToInt32(e.KeyChar) != 8))
                e.Handled = true;
        }
    }
}
