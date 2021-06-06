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
    public partial class frmChucvu : Form
    {
        public frmChucvu()
        {
            InitializeComponent();
        }

        private void frmChucvu_Load(object sender, EventArgs e)
        {
            ThucthiSQL.OpenConnection();
            loadDataGridView();
            ThucthiSQL.CloseConnection();
        }
        private void loadDataGridView()
        {
            string sql = "select * from tblChucVu";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, ThucthiSQL.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
        private void ResetValue()
        {
            txtMaCV.Text = "";
            txtTenCV.Text = "";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {            
            ResetValue();
            txtMaCV.Enabled = true;
            txtMaCV.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaCV.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã chức vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaCV.Focus();
            }
            if (txtTenCV.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên chức vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenCV.Focus();
            }
            sql = "update tblChucVu set TenCV=N'" + txtTenCV.Text.Trim() + "' where MaCV ='" + txtMaCV.Text.Trim() + "'";
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
                string sql = "delete from tblChucVu where MaCV = '" + txtMaCV.Text + "'";
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
            if (txtMaCV.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập mã chức vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaCV.Focus();
                return;
            }
            if (txtTenCV.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập tên chức vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenCV.Focus();
                return;
            }
            if (txtMaCV.Text.Substring(0, 2) != "CV")
            {
                MessageBox.Show("Mã chức vụ phải có dạng 'CVxx'");
                txtMaCV.Focus();
                return;
            }
            sql = "Select MaCV from tblChucVu where MaCV ='" + txtMaCV.Text.Trim() + "'";
            ThucthiSQL.OpenConnection();
            if (ThucthiSQL.CheckKeyExit(sql))
            {
                MessageBox.Show("Mã chức vụ đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ThucthiSQL.CloseConnection();
                txtMaCV.Focus();
                return;
            }
            else
            {
                sql = "insert into tblChucVu (MaCV,TenCV) " +
                    " values ('" + txtMaCV.Text.Trim() + "',N'" + txtTenCV.Text.Trim() + "')";
                SqlCommand cmd = new SqlCommand(sql, ThucthiSQL.con);
                cmd.ExecuteNonQuery();
                ThucthiSQL.CloseConnection();
                loadDataGridView();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetValue();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaCV.Text = dataGridView1.CurrentRow.Cells["MaCV"].Value.ToString();
            txtTenCV.Text = dataGridView1.CurrentRow.Cells["TenCV"].Value.ToString();
            txtMaCV.Enabled = false;
        }
    }
}
