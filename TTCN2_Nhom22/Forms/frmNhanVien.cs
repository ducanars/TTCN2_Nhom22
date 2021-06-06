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
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loadDataGridView()
        {
            string sql = "select * from tblNhanVien";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, ThucthiSQL.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
        public void fillDataToComboChucVu()
        {
            string sql = "Select * from tblChucVu";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, ThucthiSQL.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmbMaCV.DataSource = table;
            cmbMaCV.ValueMember = "MaCV";
            cmbMaCV.DisplayMember = "TenCV";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {            
            dataGridView1.Enabled = false;
            txtMaNV.Enabled = true;
            txtTenNV.Enabled = true;
            chkGioitinh.Enabled = true;
            txtSDT.Enabled = true;
            txtEmail.Enabled = true;
            dtpNgaysinh.Enabled = true;
            txtQuequan.Enabled = true;
            cmbMaCV.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql, gt;
            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNV.Focus();
            }
            if (txtTenNV.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNV.Focus();
            }
            if (txtSDT.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
            }
            if (txtQuequan.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập quê quán nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuequan.Focus();
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập email nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
            }
            if (dtpNgaysinh.Text == "")
            {
                MessageBox.Show("Bạn phải nhập ngày sinh nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgaysinh.Focus();
                return;
            }
            if (cmbMaCV.Text == "")
            {
                MessageBox.Show("Bạn phải chọn chức vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMaCV.Focus();
                return;
            }
            if (chkGioitinh.Checked == true)
                gt = "Nam";
            else
                gt = "Nữ";
            sql = "UPDATE tblNhanVien SET  TenNV=N'" + txtTenNV.Text.Trim().ToString() +
                    "',Ngaysinh =N'" + ThucthiSQL.ConvertDateTime(dtpNgaysinh.Value.ToString("MM/dd/yyyy")) + "',Gioitinh=N'" + gt +
                    "',SDT='" + txtSDT.Text.Trim() + "',Quequan=N'" + txtQuequan.Text.Trim() +  "',MaCV='" + cmbMaCV.SelectedValue.ToString() +
                    "' WHERE MaNV=N'" + txtMaNV.Text.Trim() + "'";
            ThucthiSQL.OpenConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = ThucthiSQL.con;
            cmd.ExecuteNonQuery();
            loadDataGridView();
            ThucthiSQL.CloseConnection();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string sql = "delete from tblNhanVien where MaNV = '" + txtMaNV.Text + "'";
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
            string gt;
            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNV.Focus();
            }
            if (txtTenNV.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNV.Focus();
            }
            if (txtSDT.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
            }
            if (txtQuequan.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập quê quán nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuequan.Focus();
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập email nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
            }
            if (dtpNgaysinh.Text == "")
            {
                MessageBox.Show("Bạn phải nhập ngày sinh nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgaysinh.Focus();
                return;
            }
            if (cmbMaCV.Text == "")
            {
                MessageBox.Show("Bạn phải chọn chức vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMaCV.Focus();
                return;
            }
            if (chkGioitinh.Checked == true)
                gt = "Nam";
            else
                gt = "Nữ";
            if (txtMaNV.Text.Substring(0, 2) != "NV")
            {
                MessageBox.Show("Mã nhân viên phải có dạng 'NVxx'");
                txtMaNV.Focus();
                return;
            }
            string sql = "select * from tblNhanVien where MaNV = '" + txtMaNV.Text.Trim() + "'";
            ThucthiSQL.OpenConnection();
            if (ThucthiSQL.CheckKeyExit(sql))
            {
                MessageBox.Show("Mã nhân viên này đã tồn tại, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNV.Focus();
                ThucthiSQL.CloseConnection();
                return;
            }
            else
            {
                sql = "insert into  tblNhanVien (MaNV, TenNV, Ngaysinh, Gioitinh, " +
                    "SDT, Quequan, Email, MaCV)" +
                    " values ('" + txtMaNV.Text.Trim() + "',N'"
                    + txtTenNV.Text.Trim() + "', N'" + ThucthiSQL.ConvertDateTime(dtpNgaysinh.Text.ToString()) + "',N'" +
                    gt + "',N'" + txtSDT.Text.Trim() + "',N'" + txtQuequan.Text.Trim() +
                    "',N'" + txtEmail.Text.Trim() + "','" + cmbMaCV.SelectedValue.ToString() + "')";
                SqlCommand cmd = new SqlCommand(sql, ThucthiSQL.con);
                cmd.ExecuteNonQuery();
                loadDataGridView();
                fillDataToComboChucVu();
                ThucthiSQL.CloseConnection();

            }
        }

        private void frmNhanvien_Load(object sender, EventArgs e)
        {
            ThucthiSQL.OpenConnection();
            loadDataGridView();
            fillDataToComboChucVu();
            ThucthiSQL.CloseConnection();
            cmbMaCV.Text = "";
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetValue();
        }
        private void ResetValue()
        {
            txtMaNV.Enabled = false;
            txtMaNV.Text = "";
            txtTenNV.Enabled = false;
            txtTenNV.Text = "";
            chkGioitinh.Enabled = false;
            chkGioitinh.Text = "";
            txtSDT.Enabled = false;
            txtSDT.Text = "";
            txtEmail.Enabled = false;
            txtEmail.Text = "";
            dtpNgaysinh.Enabled = false;
            dtpNgaysinh.Text = "";
            txtQuequan.Enabled = false;
            txtQuequan.Text = "";
            cmbMaCV.Enabled = false;
            cmbMaCV.Text = "";
            dataGridView1.Enabled = true;
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNV.Text = dataGridView1.CurrentRow.Cells["MaNV"].Value.ToString();
            txtTenNV.Text = dataGridView1.CurrentRow.Cells["TenNV"].Value.ToString();
            dtpNgaysinh.Text = dataGridView1.CurrentRow.Cells["Ngaysinh"].Value.ToString();
            if (dataGridView1.CurrentRow.Cells["Gioitinh"].Value.ToString() == "Nam") chkGioitinh.Checked = true;
            else chkGioitinh.Checked = false;
            txtSDT.Text = dataGridView1.CurrentRow.Cells["SDT"].Value.ToString();
            txtQuequan.Text = dataGridView1.CurrentRow.Cells["Quequan"].Value.ToString();
            txtEmail.Text = dataGridView1.CurrentRow.Cells["Email"].Value.ToString();
            string sql;
            sql = "Select TenCV From tblChucVu Where MaCV = N'" + dataGridView1.CurrentRow.Cells["MaCV"].Value.ToString() + "'";
            cmbMaCV.Text = ThucthiSQL.GetFieldValues(sql);
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < '0') || (e.KeyChar > '9')) && (Convert.ToInt32(e.KeyChar) != 8))
                e.Handled = true;
        }
    }
}
