using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TTCN2_Nhom22.Forms
{
    public partial class frmTimKiemHD : Form
    {
        public frmTimKiemHD()
        {
            InitializeComponent();
        }

        private void frmTimKiemHD_Load(object sender, EventArgs e)
        {
            cmbThang.Enabled = false;
            cmbQuy.Enabled = false;
            txtNam.Enabled = false;
            cmbMaNV.Enabled = false;
            txtTenNV.Enabled = false;
        }

        private void cmbDK_TextChanged(object sender, EventArgs e)
        {
            if (cmbDK.Text == "Tháng")
            {
                cmbThang.Enabled = true;
                cmbQuy.Enabled = false;
                txtNam.Enabled = true;
                cmbMaNV.Enabled = false;
                txtTenNV.Enabled = false;
            }
            if (cmbDK.Text == "Quý")
            {
                cmbThang.Enabled = false;
                cmbQuy.Enabled = true;
                txtNam.Enabled = true;
                cmbMaNV.Enabled = false;
                txtTenNV.Enabled = false;
            }
            if (cmbDK.Text == "Năm")
            {
                cmbThang.Enabled = false;
                cmbQuy.Enabled = false;
                txtNam.Enabled = true;
                cmbMaNV.Enabled = false;
                txtTenNV.Enabled = false;
            }
            if (cmbDK.Text == "Mã nhân viên")
            {
                cmbThang.Enabled = false;
                cmbQuy.Enabled = false;
                txtNam.Enabled = false;
                cmbMaNV.Enabled = true;
                txtTenNV.Enabled = false;
            }
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            if (cmbThang.Text == "" && cmbThang.Enabled == true)
            {
                MessageBox.Show("Bạn hãy nhập Tháng !");
                cmbThang.Focus();
                return;
            }
            if (cmbQuy.Text == "" && cmbQuy.Enabled == true)
            {
                MessageBox.Show("Bạn hãy nhập Quý !");
                cmbQuy.Focus();
                return;
            }
            if (txtNam.Text == "" && txtNam.Enabled == true)
            {
                MessageBox.Show("Bạn hãy nhập Năm !");
                txtNam.Focus();
                return;
            }

            if (txtNam.Text.Length != 4 && txtNam.Enabled == true)
            {
                MessageBox.Show("Bạn hãy nhập đúng Năm !");
                txtNam.Focus();
                return;
            }
            string sql;
            DataTable KQ = new DataTable();
            if (rdoHDN.Checked == true)
            {
                if (cmbDK.Text == "Tháng")
                {
                    sql = "SELECT * FROM tblHDNhap WHERE Month(Ngaynhap) =  " + Convert.ToInt32(cmbThang.Text) + " And Year(Ngaynhap) = " + Convert.ToInt32(txtNam.Text) + "";
                    KQ = ThucthiSQL.DocBang(sql);
                }
                else if (cmbDK.Text == "Năm")
                {
                    sql = "SELECT * FROM tblHDNhap WHERE Year(Ngaynhap) = " + Convert.ToInt32(txtNam.Text) + "";
                    KQ = ThucthiSQL.DocBang(sql);
                }
                else if (cmbDK.Text == "Quý")
                {
                    if (cmbQuy.Text == "1")
                    {
                        sql = "SELECT * FROM tblHDNhap WHERE Month(Ngaynhap) Between 1 AND 3 and Year(Ngaynhap) = " + Convert.ToInt32(txtNam.Text) + "  ";
                        KQ = ThucthiSQL.DocBang(sql);
                    }
                    else if (cmbQuy.Text == "2")
                    {
                        sql = "SELECT * FROM tblHDNhap WHERE Month(Ngaynhap) Between 4 AND 6 and Year(Ngaynhap) = " + Convert.ToInt32(txtNam.Text) + "";
                        KQ = ThucthiSQL.DocBang(sql);
                    }
                    else if (cmbQuy.Text == "3")
                    {
                        sql = "SELECT * FROM tblHDNhap WHERE Month(Ngaynhap) Between 7 AND 9 and Year(Ngaynhap) = " + Convert.ToInt32(txtNam.Text) + "";
                        KQ = ThucthiSQL.DocBang(sql);
                    }
                    else if (cmbQuy.Text == "4")
                    {
                        sql = "SELECT * FROM tblHDNhap WHERE Month(Ngaynhap) Between 10 AND 12 and Year(Ngaynhap) = " + Convert.ToInt32(txtNam.Text) + "";
                        KQ = ThucthiSQL.DocBang(sql);
                    }
                    else if (cmbDK.Text == "Mã nhân viên")
                    {
                        sql = "Select * FROM tblHDNhap WHERE MaNV = N'" + cmbMaNV.Text + "'";
                        KQ = ThucthiSQL.DocBang(sql);
                    }
                }
                if (KQ.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy !");
                    cmbThang.Text = "";
                    cmbQuy.Text = "";
                    txtNam.Text = "";
                    dataGridView1.DataSource = null;
                    return;
                }
                dataGridView1.DataSource = KQ;
                dataGridView1.Columns[0].HeaderText = "Mã hoá đơn";
                dataGridView1.Columns[1].HeaderText = "Mã nhân viên";
                dataGridView1.Columns[2].HeaderText = "Mã nhà cung cấp";
                dataGridView1.Columns[3].HeaderText = "Ngày nhập";
                dataGridView1.Columns[4].HeaderText = "Tổng tiền";
                dataGridView1.Columns[0].Width = 200;
                dataGridView1.Columns[1].Width = 100;
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[3].Width = 150;
                dataGridView1.Columns[4].Width = 150;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
                KQ.Dispose();
            }

            else if (rdoHDX.Checked == true)
            {
                if (cmbThang.Text == "Tháng")
                {
                    sql = "SELECT * FROM tblHDXuat WHERE Month(Ngayxuat) =  " + Convert.ToInt32(cmbThang.Text) + " And Year(Ngayxuat) = " + Convert.ToInt32(txtNam.Text) + "";
                    KQ = ThucthiSQL.DocBang(sql);
                }
                else if (cmbDK.Text == "Năm")
                {
                    sql = "SELECT * FROM tblHDXuat WHERE Year(Ngayxuat) = " + Convert.ToInt32(txtNam.Text) + "";
                    KQ = ThucthiSQL.DocBang(sql);
                }
                else if (cmbDK.Text == "Quý")
                {
                    if (cmbQuy.Text == "1")
                    {
                        sql = "SELECT * FROM tblHDXuat WHERE Month(Ngayxuat) Between 1 AND 3 and Year(Ngayxuat) = " + Convert.ToInt32(txtNam.Text) + "  ";
                        KQ = ThucthiSQL.DocBang(sql);
                    }
                    else if (cmbQuy.Text == "2")
                    {
                        sql = "SELECT * FROM tblHDXuat WHERE Month(Ngayxuat) Between 4 AND 6 and Year(Ngayxuat) = " + Convert.ToInt32(txtNam.Text) + "";
                        KQ = ThucthiSQL.DocBang(sql);
                    }
                    else if (cmbQuy.Text == "3")
                    {
                        sql = "SELECT * FROM tblHDXuat WHERE Month(Ngayxuat) Between 7 AND 9 and Year(NgayXuat) = " + Convert.ToInt32(txtNam.Text) + "";
                        KQ = ThucthiSQL.DocBang(sql);
                    }
                    else if (cmbQuy.Text == "4")
                    {
                        sql = "SELECT * FROM tblHDXuat WHERE Month(Ngayxuat) Between 10 AND 12 and Year(Ngayxuat) = " + Convert.ToInt32(txtNam.Text) + "";
                        KQ = ThucthiSQL.DocBang(sql);
                    }
                }
                else if (cmbDK.Text == "Mã nhân viên")
                {
                    sql = "Select * FROM tblHDXuat WHERE MaNV = N'" + cmbMaNV.Text + "'";
                    KQ = ThucthiSQL.DocBang(sql);
                }
                if (KQ.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy !");
                    cmbThang.Text = "";
                    cmbQuy.Text = "";
                    txtNam.Text = "";
                    dataGridView1.DataSource = null;
                    return;
                }
                dataGridView1.DataSource = KQ;
                dataGridView1.Columns[0].HeaderText = "Mã hoá đơn";
                dataGridView1.Columns[1].HeaderText = "Mã nhân viên";
                dataGridView1.Columns[2].HeaderText = "Mã khách hàng";
                dataGridView1.Columns[3].HeaderText = "Ngày bán";
                dataGridView1.Columns[4].HeaderText = "Tổng tiền";
                dataGridView1.Columns[0].Width = 200;
                dataGridView1.Columns[1].Width = 100;
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[3].Width = 150;
                dataGridView1.Columns[4].Width = 150;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
                KQ.Dispose();
            }
        }

        private void txtNam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < '0') || (e.KeyChar > '9')) && (Convert.ToInt32(e.KeyChar) != 8))
                e.Handled = true;
        }

        private void cmbMaNV_DropDown(object sender, EventArgs e)
        {
            cmbMaNV.DataSource = ThucthiSQL.DocBang("SELECT MaNV FROM tblNhanVien");
            cmbMaNV.ValueMember = "MaNV";
            cmbMaNV.SelectedIndex = -1;
        }

        private void cmbMaNV_TextChanged(object sender, EventArgs e)
        {
            if (cmbMaNV.Text == "")
            {
                txtTenNV.Text = "";
                return;
            }
            string sql = "SELECT TenNV FROM tblNhanVien WHERE MaNV = N'" + cmbMaNV.Text + "'";
            DataTable tbl = ThucthiSQL.DocBang(sql);
            if (tbl.Rows.Count > 0)
                txtTenNV.Text = tbl.Rows[0][0].ToString();
        }
    }
}
