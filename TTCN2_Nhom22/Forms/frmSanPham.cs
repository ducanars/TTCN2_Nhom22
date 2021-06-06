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
    public partial class frmSanPham : Form
    {
        public frmSanPham()
        {
            InitializeComponent();
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            ThucthiSQL.OpenConnection();
            loadDataGridView();
            fillDataToComboNCC();
            ThucthiSQL.CloseConnection();
            cmbMaNCC.Text = "";
        }
        private void loadDataGridView()
        {
            string sql = "select * from tblSanPham";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, ThucthiSQL.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
        public void fillDataToComboNCC()
        {
            string sql = "Select * from tblNCC";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, ThucthiSQL.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmbMaNCC.DataSource = table;
            cmbMaNCC.ValueMember = "MaNCC";
            cmbMaNCC.DisplayMember = "TenNCC";
        }

        private void ResetValue()
        {
            txtMaSP.Enabled = false;
            txtMaSP.Text = "";
            txtTenSP.Enabled = false;
            txtTenSP.Text = "";
            txtSoluong.Enabled = false;
            txtSoluong.Text = "";
            txtDVT.Enabled = false;
            txtDVT.Text = "";
            txtDongianhap.Enabled = false;
            txtDongianhap.Text = "";
            txtDongiaban.Enabled = false;
            txtDongiaban.Text = "";
            txtMota.Enabled = false;
            txtMota.Text = "";
            cmbMaNCC.Enabled = false;
            cmbMaNCC.Text = "";
            dataGridView1.Enabled = true;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = false;
            txtMaSP.Enabled = true;
            txtTenSP.Enabled = true;
            txtSoluong.Enabled = true;
            txtDVT.Enabled = true;
            txtDongianhap.Enabled = true;
            txtDongiaban.Enabled = true;
            txtMota.Enabled = true;
            cmbMaNCC.Enabled = true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetValue();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaSP.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSP.Focus();
            }
            if (txtTenSP.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenSP.Focus();
            }
            if (txtSoluong.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số lượng sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoluong.Focus();
            }
            if (txtDVT.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đơn vị tính sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDVT.Focus();
            }
            if (txtDongianhap.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đơn giá nhập sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDongianhap.Focus();
            }
            if (txtDongiaban.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đơn giá bán sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDongiaban.Focus();
            }
            if (txtMota.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mô tả sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMota.Focus();
                return;
            }
            if (cmbMaNCC.Text == "")
            {
                MessageBox.Show("Bạn phải chọn nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMaNCC.Focus();
                return;
            }
            if (txtMaSP.Text.Substring(0, 2) != "SP")
            {
                MessageBox.Show("Mã sản phẩm phải có dạng 'SPxx'");
                txtMaSP.Focus();
                return;
            }
            string sql = "select * from tblSanPham where MaSP = '" + txtMaSP.Text.Trim() + "'";
            ThucthiSQL.OpenConnection();
            if (ThucthiSQL.CheckKeyExit(sql))
            {
                MessageBox.Show("Mã sản phẩm này đã tồn tại, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSP.Focus();
                ThucthiSQL.CloseConnection();
                return;
            }            
            else
            {
                sql = "insert into  tblSanPham (MaSP, TenSP, Soluong, DVT, Dongianhap,Dongiaban, Mota, MaNCC)" +
                    " values ('" + txtMaSP.Text.Trim() + "',N'" + txtTenSP.Text.Trim() + "', '" + txtSoluong.Text.Trim() + "',N'" +
                    txtDVT.Text.Trim() + "','" + txtDongianhap.Text.Trim() + "','" + txtDongiaban.Text.Trim() 
                    + "',N'" + txtMota.Text.Trim() + "','" + cmbMaNCC.SelectedValue.ToString() + "')";
                SqlCommand cmd = new SqlCommand(sql, ThucthiSQL.con);
                cmd.ExecuteNonQuery();
                loadDataGridView();
                fillDataToComboNCC();
                ThucthiSQL.CloseConnection();

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaSP.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSP.Focus();
            }
            if (txtTenSP.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenSP.Focus();
            }
            if (txtSoluong.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số lượng sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoluong.Focus();
            }
            if (txtDVT.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đơn vị tính sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDVT.Focus();
            }
            if (txtDongianhap.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đơn giá nhập sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDongianhap.Focus();
            }
            if (txtDongiaban.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đơn giá bán sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDongiaban.Focus();
            }
            if (txtMota.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mô tả sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMota.Focus();
                return;
            }
            if (cmbMaNCC.Text == "")
            {
                MessageBox.Show("Bạn phải chọn nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMaNCC.Focus();
                return;
            }
            sql = "UPDATE tblSanPham SET  TenSP=N'" + txtTenSP.Text.Trim().ToString() + "',Soluong ='" + txtSoluong.Text.Trim() 
                + "',DVT=N'" + txtDVT.Text.Trim() + "',Dongianhap='" + txtDongianhap.Text.Trim() + "',Dongiaban='" 
                + txtDongiaban.Text.Trim() + "',Mota=N'" + txtMota.Text.Trim() + "' WHERE MaSP=N'" + txtMaSP.Text.Trim() + "'";
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
                string sql = "delete from tblSanPham where MaSP = '" + txtMaSP.Text + "'";
                ThucthiSQL.OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = ThucthiSQL.con;
                cmd.ExecuteNonQuery();
                ThucthiSQL.CloseConnection();
                loadDataGridView();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSP.Text = dataGridView1.CurrentRow.Cells["MaSP"].Value.ToString();
            txtTenSP.Text = dataGridView1.CurrentRow.Cells["TenSP"].Value.ToString();
            txtSoluong.Text = dataGridView1.CurrentRow.Cells["Soluong"].Value.ToString();
            txtDVT.Text = dataGridView1.CurrentRow.Cells["DVT"].Value.ToString();
            txtDongianhap.Text = dataGridView1.CurrentRow.Cells["Dongianhap"].Value.ToString();
            txtDongiaban.Text = dataGridView1.CurrentRow.Cells["Dongiaban"].Value.ToString();
            txtMota.Text = dataGridView1.CurrentRow.Cells["Mota"].Value.ToString();
            string sql;
            sql = "Select TenNCC From tblNCC Where MaNCC = N'" + dataGridView1.CurrentRow.Cells["MaNCC"].Value.ToString() + "'";
            cmbMaNCC.Text = ThucthiSQL.GetFieldValues(sql);
        }

        private void txtDongiaban_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < '0') || (e.KeyChar > '9')) && (Convert.ToInt32(e.KeyChar) != 8))
                e.Handled = true;
        }

        private void txtSoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < '0') || (e.KeyChar > '9')) && (Convert.ToInt32(e.KeyChar) != 8))
                e.Handled = true;
        }

        private void txtDongianhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < '0') || (e.KeyChar > '9')) && (Convert.ToInt32(e.KeyChar) != 8))
                e.Handled = true;
        }
    }
}
