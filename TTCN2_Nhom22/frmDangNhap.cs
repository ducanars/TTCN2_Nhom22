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

namespace TTCN2_Nhom22
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        private void chkShow_CheckedChanged(object sender, EventArgs e)
        {
            if(chkShow.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }    
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "Select count(*) from QuanLyTaiKhoan where Taikhoan='"+ txtUsername.Text + "'and Matkhau='" + txtPassword.Text + "'";
                ThucthiSQL.OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = ThucthiSQL.con;
                cmd.ExecuteNonQuery();
                int x = (int)cmd.ExecuteScalar();
                if (x == 1)
                {
                    this.Hide();
                    frmMain main = new frmMain();
                    main.Show();
                }
                else
                {
                    lblIncorrect.Text = "Tài khoản hoặc mật khẩu không chính xác";
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    txtUsername.Focus();
                }
                ThucthiSQL.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
