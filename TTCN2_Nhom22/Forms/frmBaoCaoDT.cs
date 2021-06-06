using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TTCN2_Nhom22.Forms
{
    public partial class frmBaoCaoDT : Form
    {
        public frmBaoCaoDT()
        {
            InitializeComponent();
        }

        private void frmBaoCaoDT_Load(object sender, EventArgs e)
        {
            ResetDT();
        }
        private void ResetDT()
        {
            cmbThang.Enabled = false;
            cmbQuy.Enabled = false;
            txtNam.Enabled = false;
            txtDoanhThu.Enabled = false;
            dataGridView1.DataSource = null;
            lblDoanhthu.Text = "Bằng chữ: ";
            txtDoanhThu.Text = "";
            cmbThang.Text = "";
            cmbQuy.Text = "";
            cmbDK.Text = "";
            txtNam.Text = "";
        }

        private void btnLamlai_Click(object sender, EventArgs e)
        {
            ResetDT();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbDK_TextChanged(object sender, EventArgs e)
        {
            if (cmbDK.Text == "Tháng")
            {
                cmbThang.Enabled = true;
                cmbQuy.Enabled = false;
                txtNam.Enabled = true;
            }
            if (cmbDK.Text == "Quý")
            {
                cmbThang.Enabled = false;
                cmbQuy.Enabled = true;
                txtNam.Enabled = true;
            }
            if (cmbDK.Text == "Năm")
            {
                cmbThang.Enabled = false;
                cmbQuy.Enabled = false;
                txtNam.Enabled = true;
            }
        }

        private void txtNam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < '0') || (e.KeyChar > '9')) && (Convert.ToInt32(e.KeyChar) != 8))
                e.Handled = true;
        }

        private void btnBaocao_Click(object sender, EventArgs e)
        {
            if (cmbDK.Text == "")
            {
                MessageBox.Show("Bạn hãy chọn điều kiện lọc doanh thu !");
                cmbDK.Focus();
                return;
            }
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
            if (txtNam.Text == "")
            {
                MessageBox.Show("Bạn hãy nhập Năm !");
                txtNam.Focus();
                return;
            }

            if (txtNam.Text.Length != 4)
            {
                MessageBox.Show("Bạn hãy nhập đúng Năm !");
                txtNam.Focus();
                return;
            }

            string sql;
            DataTable KQ = new DataTable();
            if (cmbDK.Text == "Tháng")
            {
                sql = "SELECT * FROM tblHDXuat WHERE Month(Ngayxuat) =  " + Convert.ToInt32(cmbThang.Text.Trim()) + " And Year(Ngayxuat) = " + Convert.ToInt32(txtNam.Text.Trim()) + "";
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
                    sql = "SELECT * FROM tblHDXuat WHERE Month(Ngayxuat) Between 7 AND 9 and Year(Ngayxuat) = " + Convert.ToInt32(txtNam.Text) + "";
                    KQ = ThucthiSQL.DocBang(sql);
                }
                else if (cmbQuy.Text == "4")
                {
                    sql = "SELECT * FROM tblHDXuat WHERE Month(Ngayxuat) Between 10 AND 12 and Year(Ngayxuat) = " + Convert.ToInt32(txtNam.Text) + "";
                    KQ = ThucthiSQL.DocBang(sql);
                }
            }
            if (KQ.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu theo yêu cầu !");
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
            int sum = new int();
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
            }
            txtDoanhThu.Text = Convert.ToString(sum);
            lblDoanhthu.Text = "Bằng chữ: " + ThucthiSQL.ChuyenSoSangChu(txtDoanhThu.Text.ToString());
        }
    }
}
