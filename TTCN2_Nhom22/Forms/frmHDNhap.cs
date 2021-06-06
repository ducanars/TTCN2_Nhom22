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
using COMExcel = Microsoft.Office.Interop.Excel;

namespace TTCN2_Nhom22.Forms
{
    public partial class frmHDNhap : Form
    {
        public frmHDNhap()
        {
            InitializeComponent();
        }

        private void frmHDNhap_Load(object sender, EventArgs e)
        {
            btnLuuhoadon.Enabled = false;
            btnHuy.Enabled = false;
            btnInhoadon.Enabled = false;
            grbTTHD.Enabled = false;
            grbCTHD.Enabled = false;
            txtTenNV.ReadOnly = true;
            txtDiachi.ReadOnly = true;
            txtSDT.ReadOnly = true;
            txtThanhtien.ReadOnly = true;
            txtTongtien.ReadOnly = true;
            txtThanhtien.Text = "0";
            txtTongtien.Text = "0";
            dtpNgaynhap.Format = DateTimePickerFormat.Short;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbMaNV_DropDown(object sender, EventArgs e)
        {
            cmbMaNV.DataSource = ThucthiSQL.DocBang("SELECT MaNV FROM tblNhanVien");
            cmbMaNV.ValueMember = "MaNV";
            cmbMaNV.SelectedIndex = -1;
        }

        private void cmbMaNCC_DropDown(object sender, EventArgs e)
        {
            cmbMaNCC.DataSource = ThucthiSQL.DocBang("SELECT MaNCC FROM tblNCC");
            cmbMaNCC.ValueMember = "MaNCC";
            cmbMaNCC.SelectedIndex = -1;
        }

        private void cmbMaSP_DropDown(object sender, EventArgs e)
        {
            cmbMaSP.DataSource = ThucthiSQL.DocBang("SELECT MaSP FROM tblSanPham");
            cmbMaSP.ValueMember = "MaSP";
            cmbMaSP.SelectedIndex = -1;
        }

        private void btnThemhoadon_Click(object sender, EventArgs e)
        {
            btnLuuhoadon.Enabled = true;
            grbTTHD.Enabled = true;
            dataGridView1.DataSource = null;
            grbCTHD.Enabled = false;
            btnInhoadon.Enabled = false;
            ResetValues();
            txtMaHDNhap.Text = ThucthiSQL.CreateKey("HDN");
        }
        private void ResetValues()
        {
            txtMaHDNhap.Text = "";
            dtpNgaynhap.Text = DateTime.Now.ToShortDateString();
            cmbMaNV.Text = "";
            txtTenNV.Text = "";
            cmbMaNCC.Text = "";
            txtSDT.Text = "";
            txtDiachi.Text = "";
            cmbMaSP.Text = "";
            txtTenSP.Text = "";
            txtSoluong.Text = "0";
            txtGiamgia.Text = "0";
            txtThanhtien.Text = "0";
            txtTongtien.Text = "0";
            lblBangchu.Text = "Bằng chữ: ";
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

        private void cmbMaNCC_TextChanged(object sender, EventArgs e)
        {
            if (cmbMaNCC.Text == "")
            {
                cmbTenNCC.Text = "";
                txtDiachi.Text = "";
                txtSDT.Text = "";
                txtEmail.Text = "";
                return;
            }
            string sql = "SELECT TenNCC, Diachi, SDT,Email FROM tblNCC WHERE MaNCC = N'" + cmbMaNCC.Text + "'";
            DataTable tbl = ThucthiSQL.DocBang(sql);
            if (tbl.Rows.Count > 0)
            {
                cmbTenNCC.Text = tbl.Rows[0][0].ToString();
                txtDiachi.Text = tbl.Rows[0][1].ToString();
                txtSDT.Text = tbl.Rows[0][2].ToString();
                txtEmail.Text = tbl.Rows[0][3].ToString();
            }
        }

        private void cmbMaSP_TextChanged(object sender, EventArgs e)
        {
            if (cmbMaSP.Text == "")
            {
                txtTenSP.Text = "";
                txtSoluong.Text = "0";
                return;
            }
            string sql = "SELECT TenSP, Dongianhap FROM tblSanPham WHERE MaSP = N'" + cmbMaSP.Text + "'";
            DataTable tbl = ThucthiSQL.DocBang(sql);
            if (tbl.Rows.Count > 0)
            {
                txtTenSP.Text = tbl.Rows[0][0].ToString();
                txtDongianhap.Text = (Convert.ToInt32(tbl.Rows[0][1])).ToString();
            }
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            if (cmbMaSP.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMaSP.Focus();
                return;
            }
            if ((txtSoluong.Text.Trim().Length == 0) || (txtSoluong.Text == "0"))
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtSoluong.Text = "";
                txtSoluong.Focus();
                return;
            }

            if (txtDongianhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đơn giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDongianhap.Focus();
                return;
            }
            if (txtGiamgia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiamgia.Focus();
                return;
            }
            string sql = "select MaSP from tblChiTietHDNhap where MaSP=N'" + cmbMaSP.Text +
                "'and MaHDNhap=N'" + txtMaHDNhap.Text.Trim() + "'";
            if (ThucthiSQL.DocBang(sql).Rows.Count > 0)
            {
                MessageBox.Show("Mã này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValuesSP();
                cmbMaSP.Focus();
                return;
            }
            sql = "insert into tblChiTietHDNhap(MaHDNhap,MaSP,Soluong,Dongianhap,Giamgia,Thanhtien) values(N'" +
                txtMaHDNhap.Text.Trim() + "',N'" +
                cmbMaSP.Text.ToString() + "'," +
                txtSoluong.Text + "," +
                txtDongianhap.Text + "," +
                txtGiamgia.Text + "," + txtThanhtien.Text + ")";
            ThucthiSQL.CapNhatDuLieu(sql);
            Hienthi_Luoi();

            //Cập nhật tổng tiền mới vào bảng hóa đơn bán theo công thức
            //Tổng tiền mới=tổng tiền trong bảng HDB+ Thành tiền
            double tong = Convert.ToDouble(ThucthiSQL.DocBang("select Tongtien from tblHDNhap where MaHDNhap=N'" +
                txtMaHDNhap.Text + "'").Rows[0][0].ToString());
            double tongmoi = tong + Convert.ToDouble(txtThanhtien.Text);
            sql = "update tblHDNhap set Tongtien=" + tongmoi + "where MaHDNhap=N'" + txtMaHDNhap.Text + "'";
            ThucthiSQL.CapNhatDuLieu(sql);
            txtTongtien.Text = tongmoi.ToString();
            lblBangchu.Text = "Bằng chữ:" + ThucthiSQL.ChuyenSoSangChu(tong.ToString());

            double sl = Convert.ToDouble(ThucthiSQL.DocBang("select Soluong from tblSanPham where MaSP=N'" +
                cmbMaSP.Text + "'").Rows[0][0].ToString());

            // Cập nhật số lượng mới vào bảng hàng theo công thức
            //Số lượng mới =sl trong bảng hàng + số lượng đang nhập trên form hóa đơn nhập
            double slmoi = sl + Convert.ToDouble(txtSoluong.Text);
            sql = "update tblSanPham set Soluong=" + slmoi + "where MaSP=N'" + cmbMaSP.Text + "'";
            ThucthiSQL.CapNhatDuLieu(sql);

            ResetValuesSP();
            btnHuy.Enabled = true;
            btnInhoadon.Enabled = true;
            lblBangchu.Text = "Bằng chữ: " + ThucthiSQL.ChuyenSoSangChu(txtTongtien.Text.ToString());
        }
        private void ResetValuesSP()
        {
            cmbMaSP.Text = "";
            txtSoluong.Text = "";
            txtDongianhap.Text = "";
            txtGiamgia.Text = "0";

        }
        private void Hienthi_Luoi()
        {
            string sql;
            sql = "Select MaSP,Soluong,Dongianhap,Giamgia,Thanhtien from tblChiTietHDNhap where MaHDNhap=N'" +
                txtMaHDNhap.Text + "'";
            dataGridView1.DataSource = ThucthiSQL.DocBang(sql);
            dataGridView1.Columns[0].HeaderText = "Mã hàng";
            dataGridView1.Columns[1].HeaderText = "Số lượng";
            dataGridView1.Columns[2].HeaderText = "Giá nhập";
            dataGridView1.Columns[3].HeaderText = "Giảm giá";
            dataGridView1.Columns[4].HeaderText = "Thành tiền";
            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].Width = 200;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnLuuhoadon_Click(object sender, EventArgs e)
        {
            string sql;
            if (dtpNgaynhap.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập ngày ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgaynhap.Focus();
                return;
            }
            if (cmbMaNV.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập Mã nhân viên ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMaNV.Focus();
                return;
            }
            if (cmbMaNCC.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập Mã nhà cung cấp ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMaNCC.Focus();
                return;
            }

            sql = "INSERT INTO tblHDNhap(MaHDNhap,MaNV,MaNCC,Ngaynhap,Tongtien) VALUES(N'" + txtMaHDNhap.Text.Trim() +
                "',N'" + cmbMaNV.Text + "',N'" + cmbMaNCC.Text + "',N'" + ThucthiSQL.ConvertDateTime(dtpNgaynhap.Text) +
                "'," + txtTongtien.Text + ")";
            ThucthiSQL.CapNhatDuLieu(sql);
            btnLuuhoadon.Enabled = false;
            txtThanhtien.Enabled = false;
            txtTongtien.Enabled = false;
            txtDongianhap.Enabled = false;
            grbCTHD.Enabled = true;
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

        private void txtGiamgia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < '0') || (e.KeyChar > '9')) && (Convert.ToInt32(e.KeyChar) != 8))
                e.Handled = true;
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < '0') || (e.KeyChar > '9')) && (Convert.ToInt32(e.KeyChar) != 8))
                e.Handled = true;
        }

        private void txtSoluong_TextChanged(object sender, EventArgs e)
        {
            double tt, sl, dg, gg;
            if (txtSoluong.Text == "")
                sl = 0;
            else sl = Convert.ToDouble(txtSoluong.Text);
            if (txtDongianhap.Text == "")
                dg = 0;
            else dg = Convert.ToDouble(txtDongianhap.Text);
            if (txtGiamgia.Text == "")
                gg = 0;
            else gg = Convert.ToDouble(txtGiamgia.Text);
            tt = (sl * dg) - (sl * dg * gg / 100);
            tt = Math.Round((double)(tt));
            txtThanhtien.Text = tt.ToString();
        }

        private void txtGiamgia_TextChanged(object sender, EventArgs e)
        {
            double tt, sl, dg, gg;
            if (txtSoluong.Text == "")
                sl = 0;
            else sl = Convert.ToDouble(txtSoluong.Text);
            if (txtDongianhap.Text == "")
                dg = 0;
            else dg = Convert.ToDouble(txtDongianhap.Text);
            if (txtGiamgia.Text == "")
                gg = 0;
            else gg = Convert.ToDouble(txtGiamgia.Text);
            tt = (sl * dg) - (sl * dg * gg / 100);
            tt = Math.Round((double)(tt));
            txtThanhtien.Text = tt.ToString();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
               == DialogResult.Yes)
            {
                //lấy thông tin các mặt hàng sẽ bị xóa
                string sql = "Select MaSP, Soluong,Dongianhap from tblChiTietHDNhap where MaHDNhap=N'" + txtMaHDNhap.Text + "'";
                DataTable tbl = ThucthiSQL.DocBang(sql);

                //xóa hóa đơn
                sql = "delete tblHDNhap where MaHDNhap=N'" + txtMaHDNhap.Text + "'";
                ThucthiSQL.CapNhatDuLieu(sql);
                ResetValues();
                Hienthi_Luoi();
                //Cập nhật lại số lượng hàng, đơn giá bán cho từng mặt hàng sẽ bị xóa
                for (int i = 0; i < tbl.Rows.Count; i++)
                    DelUpdateSP(tbl.Rows[i][0].ToString(), Convert.ToDouble(tbl.Rows[i][1]), Convert.ToDouble(tbl.Rows[i][2]));
                btnHuy.Enabled = false;
                btnInhoadon.Enabled = false;
                grbTTHD.Enabled = false;
                grbCTHD.Enabled = false;
                return;
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            string sql = "select * from tblChiTietHDNhap where MaHDNhap=N'" + txtMaHDNhap.Text + "'";
            if (ThucthiSQL.DocBang(sql).Rows.Count == 0)
            {
                MessageBox.Show("không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes))
            {
                //Lấy thông tin mã hóa đơn, mã hàng, số luowgj, giá nhập, thành tiền của dòng dữ liệu muốn xóa
                string mahangxoa = dataGridView1.CurrentRow.Cells["MaSP"].Value.ToString();
                double slxoa = Convert.ToDouble(dataGridView1.CurrentRow.Cells["Soluong"].Value.ToString());
                double giamgiaxoa = Convert.ToDouble(dataGridView1.CurrentRow.Cells["Giamgia"].Value.ToString());
                double thanhtienxoa = Convert.ToDouble(dataGridView1.CurrentRow.Cells["Thanhtien"].Value.ToString());

                //Xóa hàng trong bảng ChitietHDN
                sql = "Delete tblChiTietHDNhap where MaHDNhap=N'" + txtMaHDNhap.Text +
                    "'and MaSP=N'" + mahangxoa + "'";
                ThucthiSQL.CapNhatDuLieu(sql);
                Hienthi_Luoi();

                //cập nhật lại số lượng hàng
                DelUpdateSP(mahangxoa, slxoa, giamgiaxoa);

                //cập nhật lại tổng tiền cho hóa đơn xuất
                DelUpdateTongtien(txtMaHDNhap.Text, thanhtienxoa);
            }

        }
        private void DelUpdateSP(string mahangxoa, double slxoa, double gianhapxoa)
        {
            //cập nhật số lượng hàng vào bảng hàng theo công thức
            //số lượng mới=số lượng trong bảng hàng+số lượng đã bị xóa
            double sl = Convert.ToDouble(ThucthiSQL.DocBang("select Soluong from tblSanPham where MaSP=N'" +
                mahangxoa + "'").Rows[0][0].ToString());
            double slmoisauxoa = sl - slxoa;
            string sql = "update tblSanPham set Soluong=" + slmoisauxoa + "where MaSP=N'" + mahangxoa + "'";
            ThucthiSQL.CapNhatDuLieu(sql);

        }

        private void DelUpdateTongtien(string mahoadonxoa, double thanhtienxoa)
        {
            double tong = Convert.ToDouble(ThucthiSQL.DocBang("select Tongtien from tblHDNhap where MaHDNhap=N'" +
                mahoadonxoa + "'").Rows[0][0].ToString());
            double tongmoi = tong - thanhtienxoa;
            string sql = "update tblHDNhap set Tongtien=" + tongmoi + "where MaHDNhap=N'" + mahoadonxoa + "'";
            ThucthiSQL.CapNhatDuLieu(sql);
            txtTongtien.Text = tongmoi.ToString();
            lblBangchu.Text = "Bằng chữ: " + ThucthiSQL.ChuyenSoSangChu(tongmoi.ToString());
        }

        private void cmbTenNCC_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT MaNCC, Diachi, SDT, Email FROM tblNCC WHERE TenNCC = N'" + cmbTenNCC.Text + "'";
            DataTable tbl = ThucthiSQL.DocBang(sql);
            if (tbl.Rows.Count > 0)
            {
                cmbMaNCC.Text = tbl.Rows[0][0].ToString();
                txtDiachi.Text = tbl.Rows[0][1].ToString();
                txtSDT.Text = tbl.Rows[0][2].ToString();
                txtEmail.Text = tbl.Rows[0][3].ToString();
            }
        }

        private void cmbTenNCC_DropDown(object sender, EventArgs e)
        {
            cmbTenNCC.DataSource = ThucthiSQL.DocBang("SELECT TenNCC FROM tblNCC");
            cmbTenNCC.ValueMember = "TenNCC";
            cmbTenNCC.SelectedIndex = -1;
        }

        private void btnInhoadon_Click(object sender, EventArgs e)
        {
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook;
            COMExcel.Worksheet exSheet;
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblThongtinHD, tblThongtinHang;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Name = "Times new roman";
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 25;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Thủy Anh Fruits";
            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Hà Đông - Hà nội";
            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "0969385885 - 0865889258";
            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Name = "Times new roman";
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "HÓA ĐƠN NHẬP ";

            //Biểu diễn thông tin chung củ hóa đơn nhập
            sql = "select a.MaHDN,a.Ngaynhap,a.Tongtien,b.TenNCC,b.Diachi,b.SDT,b.Email,c.TenNV " +
                  "FROM tblHDNhap as a,tblNCC AS b, tblNhanVien AS c where a.MaHDNhap=N'" + txtMaHDNhap.Text +
                  "'AND a.MaNCC=b.MaNCC and a.MaNV=c.MaNV";
            tblThongtinHD = ThucthiSQL.DocBang(sql);
            exRange.Range["B6:C10"].Font.Size = 12;
            exRange.Range["B6:C10"].Font.Name = "Times new roman";
            exRange.Range["B6:B6"].Value = "Mã hóa đơn";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["B6:B6"].Value = tblThongtinHD.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Nhà cung cấp";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblThongtinHD.Rows[0][3].ToString();
            exRange.Range["B8:B8"].Value = "Địa chỉ";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = tblThongtinHD.Rows[0][4].ToString();
            exRange.Range["B9:B9"].Value = "Điện thoại";
            exRange.Range["C9:E9"].MergeCells = true;
            exRange.Range["C9:E9"].Value = "'" + tblThongtinHD.Rows[0][5].ToString();
            exRange.Range["B10:B10"].Value = "Email";
            exRange.Range["C10:E10"].MergeCells = true;
            exRange.Range["C10:E10"].Value = "'" + tblThongtinHD.Rows[0][6].ToString();

            //Lấy thông tin các mặt hàng
            sql = "select b.Tenhang,a.Soluong,a.Dongianhap,a.Giamgia,a.Thanhtien " +
               "from tblChiTietHDNhap AS a, tblSanPham AS b where a.MaHDNhap=N'" + txtMaHDNhap.Text +
               "'and a.MaSP=b.MaSP ";
            tblThongtinHang = ThucthiSQL.DocBang(sql);
            //Tạo dòng tiêu đề
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Tên hàng";
            exRange.Range["C11:C11"].Value = "Số lượng";
            exRange.Range["D11:D11"].Value = "Đơn giá";
            exRange.Range["E11:E11"].Value = "Giảm giá";
            exRange.Range["F11:F11"].Value = "Thành tiền";
            for (hang = 0; hang <= tblThongtinHang.Rows.Count - 1; hang++)
            {
                //điền stt vào cột 1 dòng 12
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot <= tblThongtinHang.Columns.Count - 1; cot++)
                    //điền thông tin từ cột t2 dòng 12
                    exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString();
            }
            exRange = exSheet.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền";
            exRange = exSheet.Cells[cot + 1][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = tblThongtinHD.Rows[0][2].ToString();
            exRange = exSheet.Cells[1][hang + 15];//ô A1
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:F1"].Value = "Bằng chữ:" + ThucthiSQL.ChuyenSoSangChu(tblThongtinHD.Rows[0][2].ToString());
            exRange = exSheet.Cells[4][hang + 17];//ô a1
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);
            exRange.Range["A1:C1"].Value = "Hà nội, Ngày " + d.Day + " Tháng " + d.Month + " Năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].Value = "Nhân viên nhập hàng";
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].Value = tblThongtinHD.Rows[0][6];
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exSheet.Name = "Hóa đơn nhập";
            exApp.Visible = true;
        }
    }
}
