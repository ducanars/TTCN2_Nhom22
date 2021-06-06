using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TTCN2_Nhom22
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình không?", "Hỏi Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmNhaCC f = new Forms.frmNhaCC();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmKhachHang f = new Forms.frmKhachHang();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmNhanVien f = new Forms.frmNhanVien();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmSanPham f = new Forms.frmSanPham();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void chứcVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmChucvu f = new Forms.frmChucvu();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void hóaĐơnXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmHDXuat f = new Forms.frmHDXuat();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void hóaĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmHDNhap f = new Forms.frmHDNhap();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void báoCáoHàngTồnKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmBaoCaoHTK f = new Forms.frmBaoCaoHTK();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void tìmKiếmThôngTinChungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmTimKiemThongTin f = new Forms.frmTimKiemThongTin();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void tìmKiếmHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmTimKiemHD f = new Forms.frmTimKiemHD();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void báoCáoDoanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmBaoCaoDT f = new Forms.frmBaoCaoDT();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }
    }
}
