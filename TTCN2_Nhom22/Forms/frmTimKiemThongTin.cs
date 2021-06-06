using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TTCN2_Nhom22.Forms
{
    public partial class frmTimKiemThongTin : Form
    {
        public frmTimKiemThongTin()
        {
            InitializeComponent();
        }

        private void frmTimKiemThongTin_Load(object sender, EventArgs e)
        {
            txtTenTK.Enabled = false;
            btnTK.Enabled = false;
        }

        private void cmbDTTK_TextChanged(object sender, EventArgs e)
        {
            txtTenTK.Enabled = true;
            dataGridView1.DataSource = null;
            txtTenTK.Text = "";
        }

        private void txtTenTK_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            btnTK.Enabled = true;
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            if (txtTenTK.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập giá trị cần tìm kiếm !");
                txtTenTK.Focus();
                dataGridView1.DataSource = null;
                return;
            }
            if (cmbDTTK.Text == "Nhân viên")
            {
                DataTable NV;
                string sql = "SELECT * FROM tblNhanVien WHERE TenNV like N'%" + txtTenTK.Text + "%'";
                NV = ThucthiSQL.DocBang(sql);
                if (NV.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy !");
                    txtTenTK.Text = "";
                    txtTenTK.Focus();
                    dataGridView1.DataSource = null;
                    return;
                }
                dataGridView1.DataSource = NV;
                dataGridView1.Columns[0].HeaderText = "Mã nhân viên";
                dataGridView1.Columns[1].HeaderText = "Tên nhân viên";
                dataGridView1.Columns[2].HeaderText = "Giới tính";
                dataGridView1.Columns[3].HeaderText = "Ngày sinh";
                dataGridView1.Columns[4].HeaderText = "Số điện thoại";
                dataGridView1.Columns[5].HeaderText = "Quê quán";
                dataGridView1.Columns[6].HeaderText = "Email";
                dataGridView1.Columns[7].HeaderText = "Mã chức vụ";
                dataGridView1.Columns[0].Width = 120;
                dataGridView1.Columns[1].Width = 200;
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[3].Width = 180;
                dataGridView1.Columns[4].Width = 180;
                dataGridView1.Columns[5].Width = 200;
                dataGridView1.Columns[6].Width = 180;
                dataGridView1.Columns[7].Width = 120;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
                NV.Dispose();
            }
            else if (cmbDTTK.Text == "Khách hàng")
            {
                DataTable KH;
                string sql = "SELECT * FROM tblKhachHang WHERE TenKH like N'%" + txtTenTK.Text + "%'";
                KH = ThucthiSQL.DocBang(sql);
                if (KH.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy !");
                    txtTenTK.Text = "";
                    txtTenTK.Focus();
                    dataGridView1.DataSource = null;
                    return;
                }
                dataGridView1.DataSource = KH;
                dataGridView1.Columns[0].HeaderText = "Mã khách hàng";
                dataGridView1.Columns[1].HeaderText = "Tên khách hàng";
                dataGridView1.Columns[2].HeaderText = "Số điện thoại";
                dataGridView1.Columns[3].HeaderText = "Địa chỉ";
                dataGridView1.Columns[4].HeaderText = "Email";
                dataGridView1.Columns[0].Width = 100;
                dataGridView1.Columns[1].Width = 200;
                dataGridView1.Columns[2].Width = 200;
                dataGridView1.Columns[3].Width = 200;
                dataGridView1.Columns[4].Width = 200;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
                KH.Dispose();
            }
            else if (cmbDTTK.Text == "Nhà cung cấp")
            {
                DataTable NCC;
                string sql = "SELECT * FROM tblNCC WHERE TenNCC like N'%" + txtTenTK.Text + "%'";
                NCC = ThucthiSQL.DocBang(sql);
                if (NCC.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy !");
                    txtTenTK.Text = "";
                    txtTenTK.Focus();
                    dataGridView1.DataSource = null;
                    return;
                }
                dataGridView1.DataSource = NCC;
                dataGridView1.Columns[0].HeaderText = "Mã nhà cung cấp";
                dataGridView1.Columns[1].HeaderText = "Tên nhà cung cấp";
                dataGridView1.Columns[2].HeaderText = "Số điện thoại";
                dataGridView1.Columns[3].HeaderText = "Địa chỉ";
                dataGridView1.Columns[4].HeaderText = "Email";
                dataGridView1.Columns[0].Width = 100;
                dataGridView1.Columns[1].Width = 200;
                dataGridView1.Columns[2].Width = 200;
                dataGridView1.Columns[3].Width = 200;
                dataGridView1.Columns[4].Width = 200;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
                NCC.Dispose();
            }
            else if (cmbDTTK.Text == "Sản phẩm")
            {
                DataTable SP;
                string sql = "SELECT * FROM tblSanPham WHERE TenSP like N'%" + txtTenTK.Text + "%'";
                SP = ThucthiSQL.DocBang(sql);
                if (SP.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy !");
                    txtTenTK.Text = "";
                    txtTenTK.Focus();
                    dataGridView1.DataSource = null;
                    return;
                }
                dataGridView1.DataSource = SP;
                dataGridView1.Columns[0].HeaderText = "Mã sản phẩm";
                dataGridView1.Columns[1].HeaderText = "Tên sản phẩm";
                dataGridView1.Columns[2].HeaderText = "Số lượng";
                dataGridView1.Columns[3].HeaderText = "Đơn vị tính";
                dataGridView1.Columns[4].HeaderText = "Đơn giá nhập";
                dataGridView1.Columns[5].HeaderText = "Đơn giá bán";
                dataGridView1.Columns[6].HeaderText = "Mô tả";
                dataGridView1.Columns[7].HeaderText = "Mã nhà cung cấp";
                dataGridView1.Columns[0].Width = 100;
                dataGridView1.Columns[1].Width = 200;
                dataGridView1.Columns[2].Width = 150;
                dataGridView1.Columns[3].Width = 150;
                dataGridView1.Columns[4].Width = 150;
                dataGridView1.Columns[5].Width = 150;
                dataGridView1.Columns[6].Width = 200;
                dataGridView1.Columns[7].Width = 150;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
                SP.Dispose();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
