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
    public partial class frmNhaCC : Form
    {
        public frmNhaCC()
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
            txtMaNCC.Enabled = true;
            txtTenNCC.Enabled = true;
            txtDiachi.Enabled = true;
            txtSDT.Enabled = true;
            txtEmail.Enabled = true;
        }

        private void ResetValue()
        {
            txtMaNCC.Enabled = false;
            txtMaNCC.Text = "";
            txtTenNCC.Enabled = false;
            txtTenNCC.Text = "";
            txtDiachi.Enabled = false;
            txtDiachi.Text = "";
            txtSDT.Enabled = false;
            txtSDT.Text = "";
            txtEmail.Enabled = false;
            txtEmail.Text = "";
            dataGridView1.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaNCC.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNCC.Focus();
            }
            if (txtTenNCC.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNCC.Focus();
            }
            if (txtSDT.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
            }
            if (txtDiachi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiachi.Focus();
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập email nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
            }
            sql = "update tblNCC set TenNCC=N'" + txtTenNCC.Text.Trim() + "',SDT=N'" + txtSDT.Text.Trim() + "',Diachi=N'" 
                + txtDiachi.Text.Trim() + "',Email=N'" + txtEmail.Text.Trim() + "' where MaNCC ='" + txtMaNCC.Text.Trim() + "'";
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
                string sql = "delete from tblNCC where MaNCC = '" + txtMaNCC.Text + "'";
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
            string sql;
            if (txtMaNCC.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập mã nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNCC.Focus();
                return;
            }
            if (txtTenNCC.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập tên nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNCC.Focus();
                return;
            }
            if (txtSDT.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
            }
            if (txtDiachi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiachi.Focus();
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập email nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
            }
            if (txtMaNCC.Text.Substring(0, 3) != "NCC")
            {
                MessageBox.Show("Mã nhà cung cấp phải có dạng 'NCCxx'");
                txtMaNCC.Focus();
                return;
            }
            sql = "Select MaNCC from tblNCC where MaNCC ='" + txtMaNCC.Text.Trim() + "'";
            ThucthiSQL.OpenConnection();
            if (ThucthiSQL.CheckKeyExit(sql))
            {
                MessageBox.Show("Mã nhà cung cấp đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ThucthiSQL.CloseConnection();
                txtMaNCC.Focus();
                return;
            }
            else
            {
                sql = "insert into tblNCC (MaNCC,TenNCC,SDT,Diachi,Email) " +
                    " values ('" + txtMaNCC.Text.Trim() + "',N'" + txtTenNCC.Text.Trim() + "',N'" + txtSDT.Text.Trim() + "',N'" 
                    + txtDiachi.Text.Trim() + "',N'" + txtEmail.Text.Trim() + "')";
                SqlCommand cmd = new SqlCommand(sql, ThucthiSQL.con);
                cmd.ExecuteNonQuery();
                ThucthiSQL.CloseConnection();
                loadDataGridView();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNCC.Text = dataGridView1.CurrentRow.Cells["MaNCC"].Value.ToString();
            txtTenNCC.Text = dataGridView1.CurrentRow.Cells["TenNCC"].Value.ToString();
            txtSDT.Text = dataGridView1.CurrentRow.Cells["SDT"].Value.ToString();
            txtDiachi.Text = dataGridView1.CurrentRow.Cells["Diachi"].Value.ToString();
            txtEmail.Text = dataGridView1.CurrentRow.Cells["Email"].Value.ToString();
        }

        private void frmNhaCC_Load(object sender, EventArgs e)
        {
            ThucthiSQL.OpenConnection();
            loadDataGridView();
            ThucthiSQL.CloseConnection();
        }

        private void loadDataGridView()
        {
            string sql = "select * from tblNCC";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, ThucthiSQL.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetValue();
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < '0') || (e.KeyChar > '9')) && (Convert.ToInt32(e.KeyChar) != 8))
                e.Handled = true;
        }
    }
}
