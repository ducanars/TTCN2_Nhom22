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
    public partial class frmHDXuat : Form
    {
        public frmHDXuat()
        {
            InitializeComponent();
        }

        private void frmHDXuat_Load(object sender, EventArgs e)
        {
            btnLuuhoadon.Enabled = false;
            btnHuy.Enabled = false;
            btnInhoadon.Enabled = false;
            grbTTHD.Enabled = false;
            grbCTHD.Enabled = false;
            txtDiachi.ReadOnly = true;
            txtSDT.ReadOnly = true;
            txtThanhtien.ReadOnly = true;
            txtTongtien.ReadOnly = true;
            txtThanhtien.Text = "0";
            txtTongtien.Text = "0";
            dtpNgayxuat.Format = DateTimePickerFormat.Short;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbMaNV_DropDown(object sender, EventArgs e)
        {
            cmbMaNV.DataSource = ThucthiSQL.DocBang("SELECT MaNV FROM tblNhanVien WHERE MaCV=N'CV03'");
            cmbMaNV.ValueMember = "MaNV";
            cmbMaNV.SelectedIndex = -1;
        }

        private void cmbMaKH_DropDown(object sender, EventArgs e)
        {
            cmbMaKH.DataSource = ThucthiSQL.DocBang("SELECT MaKH FROM tblKhachHang");
            cmbMaKH.ValueMember = "MaKH";
            cmbMaKH.SelectedIndex = -1;
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
            txtMaHDXuat.Text = ThucthiSQL.CreateKey("HDX");
        }
        private void ResetValues()
        {
            txtMaHDXuat.Text = "";
            dtpNgayxuat.Text = DateTime.Now.ToShortDateString();
            cmbMaNV.Text = "";
            cmbMaKH.Text = "";
            txtSDT.Text = "";
            txtDiachi.Text = "";
            cmbMaSP.Text = "";
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
                cmbTenNV.Text = "";
                return;
            }
            string sql = "SELECT TenNV FROM tblNhanVien WHERE MaNV = N'" + cmbMaNV.Text + "'";
            DataTable tbl = ThucthiSQL.DocBang(sql);
            if (tbl.Rows.Count > 0)
                cmbTenNV.Text = tbl.Rows[0][0].ToString();
        }

        private void cmbMaKH_TextChanged(object sender, EventArgs e)
        {
            if (cmbMaKH.Text == "")
            {
                cmbTenKH.Text = "";
                txtDiachi.Text = "";
                txtSDT.Text = "";
                txtEmail.Text = "";
                return;
            }
            string sql = "SELECT TenKH, Diachi, SDT,Email FROM tblKhachHang WHERE MaKH = N'" + cmbMaKH.Text + "'";
            DataTable tbl = ThucthiSQL.DocBang(sql);
            if (tbl.Rows.Count > 0)
            {
                cmbTenKH.Text = tbl.Rows[0][0].ToString();
                txtDiachi.Text = tbl.Rows[0][1].ToString();
                txtSDT.Text = tbl.Rows[0][2].ToString();
                txtEmail.Text = tbl.Rows[0][3].ToString();
            }
        }

        private void cmbMaSP_TextChanged(object sender, EventArgs e)
        {
            if (cmbMaSP.Text == "")
            {
                cmbTenSP.Text = "";
                txtSoluong.Text = "0";
                return;
            }
            string sql = "SELECT TenSP, Dongiaban FROM tblSanPham WHERE MaSP = N'" + cmbMaSP.Text + "'";
            DataTable tbl = ThucthiSQL.DocBang(sql);
            if (tbl.Rows.Count > 0)
            {
                cmbTenSP.Text = tbl.Rows[0][0].ToString();
                txtDongiaban.Text = (Convert.ToInt32(tbl.Rows[0][1]) ).ToString();
            }
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            double gt1, gt2, ss;
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

            if (txtDongiaban.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đơn giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDongiaban.Focus();
                return;
            }
            if (txtGiamgia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiamgia.Focus();
                return;
            }
            string sql = "select MaSP from tblChiTietHDXuat where MaSP=N'" + cmbMaSP.Text +
                "'and MaHDXuat=N'" + txtMaHDXuat.Text.Trim() + "'";
            if (ThucthiSQL.DocBang(sql).Rows.Count > 0)
            {
                MessageBox.Show("Sản phẩm này đã có, mời bạn phải chọn sản phẩm khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValuesSP();
                cmbMaSP.Focus();
                return;
            }
            string str = "select Soluong from tblSanPham where MaSP = N'" + cmbMaSP.SelectedValue.ToString()  + "'";
            DataTable table = ThucthiSQL.DocBang(str);
            if (table.Rows.Count > 0)
            {
                txtSoluongcon.Text = table.Rows[0][0].ToString();
            }
            gt1 = Convert.ToDouble(txtSoluongcon.Text);
            gt2 = Convert.ToDouble(txtSoluong.Text);
            ss = gt2 - gt1;

            if (ss > 0)
            {
                MessageBox.Show("Số lượng sản phẩm này không đủ đáp ứng yêu cầu, mời nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoluong.Focus();
                return;
            }
            sql = "insert into tblChiTietHDXuat(MaHDXuat,MaSP,Soluong,Dongiaban,Giamgia,Thanhtien) values(N'" +
                txtMaHDXuat.Text.Trim() + "',N'" +
                cmbMaSP.Text.ToString() + "'," +
                txtSoluong.Text + "," +
                txtDongiaban.Text + "," +
                txtGiamgia.Text + "," + txtThanhtien.Text + ")";
            ThucthiSQL.CapNhatDuLieu(sql);
            Hienthi_Luoi();

            //Cập nhật tổng tiền mới vào bảng hóa đơn bán theo công thức
            //Tổng tiền mới=tổng tiền trong bảng HDB+ Thành tiền
            double tong = Convert.ToDouble(ThucthiSQL.DocBang("select Tongtien from tblHDXuat where MaHDXuat=N'" +
                txtMaHDXuat.Text + "'").Rows[0][0].ToString());
            double tongmoi = tong + Convert.ToDouble(txtThanhtien.Text);
            sql = "update tblHDXuat set Tongtien=" + tongmoi + "where MaHDXuat=N'" + txtMaHDXuat.Text + "'";
            ThucthiSQL.CapNhatDuLieu(sql);
            txtTongtien.Text = tongmoi.ToString();
            lblBangchu.Text = "Bằng chữ:" + ThucthiSQL.ChuyenSoSangChu(tong.ToString());

            double sl = Convert.ToDouble(ThucthiSQL.DocBang("select Soluong from tblSanPham where MaSP=N'" +
                cmbMaSP.Text + "'").Rows[0][0].ToString());

            // Cập nhật số lượng mới vào bảng hàng theo công thức
            //Số lượng mới =sl trong bảng hàng - số lượng đang nhập trên form hóa đơn bán
            double slmoi = sl - Convert.ToDouble(txtSoluong.Text);
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
            txtDongiaban.Text = "";
            txtGiamgia.Text = "0";

        }
        private void Hienthi_Luoi()
        {
            string sql;
            sql = "Select MaSP,Soluong,Dongiaban,Giamgia,Thanhtien from tblChiTietHDXuat where MaHDXuat=N'" +
                txtMaHDXuat.Text + "'";
            dataGridView1.DataSource = ThucthiSQL.DocBang(sql);
            dataGridView1.Columns[0].HeaderText = "Mã hàng";
            dataGridView1.Columns[1].HeaderText = "Số lượng";
            dataGridView1.Columns[2].HeaderText = "Giá bán";
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
            if (dtpNgayxuat.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập ngày ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgayxuat.Focus();
                return;
            }
            if (cmbMaNV.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập Mã nhân viên ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMaNV.Focus();
                return;
            }
            if (cmbMaKH.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập Mã khách hàng ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMaKH.Focus();
                return;
            }

            sql = "INSERT INTO tblHDXuat(MaHDXuat,MaNV,MaKH,Ngayxuat,Tongtien) VALUES(N'" + txtMaHDXuat.Text.Trim() +
                "',N'" + cmbMaNV.Text + "',N'" + cmbMaKH.Text + "',N'" + ThucthiSQL.ConvertDateTime(dtpNgayxuat.Text) +
                "'," + txtTongtien.Text + ")";
            ThucthiSQL.CapNhatDuLieu(sql);
            btnLuuhoadon.Enabled = false;
            txtThanhtien.Enabled = false;
            txtTongtien.Enabled = false;
            txtDongiaban.Enabled = false;
            grbCTHD.Enabled = true;
        }

        private void txtSoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < '0') || (e.KeyChar > '9')) && (Convert.ToInt32(e.KeyChar) != 8))
                e.Handled = true;
        }

        private void txtGiamgia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < '0') || (e.KeyChar > '9')) && (Convert.ToInt32(e.KeyChar) != 8))
                e.Handled = true;
        }

        private void txtDongiaban_KeyPress(object sender, KeyPressEventArgs e)
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
            if (txtDongiaban.Text == "")
                dg = 0;
            else dg = Convert.ToDouble(txtDongiaban.Text);
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
            if (txtDongiaban.Text == "")
                dg = 0;
            else dg = Convert.ToDouble(txtDongiaban.Text);
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
                string sql = "Select MaSP, Soluong,Dongiaban from tblChiTietHDXuat where MaHDXuat=N'" + txtMaHDXuat.Text + "'";
                DataTable tbl = ThucthiSQL.DocBang(sql);

                //xóa hóa đơn
                sql = "delete tblHDXuat where MaHDXuat=N'" + txtMaHDXuat.Text + "'";
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
            string sql = "select * from tblChiTietHDXuat where MaHDXuat=N'" + txtMaHDXuat.Text + "'";
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
                sql = "Delete tblChiTietHDXuat where MaHDXuat=N'" + txtMaHDXuat.Text +
                    "'and MaSP=N'" + mahangxoa + "'";
                ThucthiSQL.CapNhatDuLieu(sql);
                Hienthi_Luoi();

                //cập nhật lại số lượng hàng
                DelUpdateSP(mahangxoa, slxoa, giamgiaxoa);

                //cập nhật lại tổng tiền cho hóa đơn xuất
                DelUpdateTongtien(txtMaHDXuat.Text, thanhtienxoa);
            }
        }
        private void DelUpdateSP(string mahangxoa, double slxoa, double gianhapxoa)
        {
            //cập nhật số lượng hàng vào bảng hàng theo công thức
            //số lượng mới=số lượng trong bảng hàng+số lượng đã bị xóa
            double sl = Convert.ToDouble(ThucthiSQL.DocBang("select Soluong from tblSanPham where MaSP=N'" +
                mahangxoa + "'").Rows[0][0].ToString());
            double slmoisauxoa = sl + slxoa;
            string sql = "update tblSanPham set Soluong=" + slmoisauxoa + "where MaSP=N'" + mahangxoa + "'";
            ThucthiSQL.CapNhatDuLieu(sql);

        }

        private void DelUpdateTongtien(string mahoadonxoa, double thanhtienxoa)
        {
            double tong = Convert.ToDouble(ThucthiSQL.DocBang("select Tongtien from tblHDXuat where MaHDXuat=N'" +
                mahoadonxoa + "'").Rows[0][0].ToString());
            double tongmoi = tong - thanhtienxoa;
            string sql = "update tblHDXuat set Tongtien=" + tongmoi + "where MaHDXuat=N'" + mahoadonxoa + "'";
            ThucthiSQL.CapNhatDuLieu(sql);
            txtTongtien.Text = tongmoi.ToString();
            lblBangchu.Text = "Bằng chữ: " + ThucthiSQL.ChuyenSoSangChu(tongmoi.ToString());
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
            exRange.Range["A1:B1"].Value = "VIVU Group";
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
            exRange.Range["C2:E2"].Value = "HÓA ĐƠN BÁN ";

            //Biểu diễn thông tin chung củ hóa đơn bán
            sql = "select a.MaHDXuat,a.Ngayxuat,a.Tongtien,b.TenKH,b.Diachi,b.SDT,b.Email,c.TenNV " +
                  "FROM tblHDXuat as a,tblKhachHang AS b, tblNhanVien AS c where a.MaHDXuat=N'" + txtMaHDXuat.Text +
                  "'AND a.MaKH=b.MaKH and a.MaNV=c.MaNV";
            tblThongtinHD = ThucthiSQL.DocBang(sql);
            exRange.Range["B6:C10"].Font.Size = 12;
            exRange.Range["B6:C10"].Font.Name = "Times new roman";
            exRange.Range["B6:B6"].Value = "Mã hóa đơn";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinHD.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Khách hàng";
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
            sql = "select b.TenSP,a.Soluong,a.Dongiaban,a.Giamgia,a.Thanhtien " +
               "from tblChiTietHDXuat AS a, tblSanPham AS b where a.MaHDXuat=N'" + txtMaHDXuat.Text +
               "'and a.MaSP=b.MaSP ";
            tblThongtinHang = ThucthiSQL.DocBang(sql);
            //Tạo dòng tiêu đề
            exRange.Range["A12:F12"].Font.Bold = true;
            exRange.Range["A12:F12"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C12:F12"].ColumnWidth = 12;
            exRange.Range["A12:A12"].Value = "STT";
            exRange.Range["B12:B12"].Value = "Tên hàng";
            exRange.Range["C12:C12"].Value = "Số lượng";
            exRange.Range["D12:D12"].Value = "Đơn giá";
            exRange.Range["E12:E12"].Value = "Giảm giá";
            exRange.Range["F12:F12"].Value = "Thành tiền";
            for (hang = 0; hang <= tblThongtinHang.Rows.Count - 1; hang++)
            {
                //điền stt vào cột 1 dòng 13
                exSheet.Cells[1][hang + 13] = hang + 1;
                for (cot = 0; cot <= tblThongtinHang.Columns.Count - 1; cot++)
                //điền thông tin từ cột t2 dòng 13               
                    exSheet.Cells[cot + 2][hang + 13] = tblThongtinHang.Rows[hang][cot].ToString();                       
            }
            exRange = exSheet.Cells[cot][hang + 15];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền";
            exRange = exSheet.Cells[cot + 1][hang + 15];
            exRange.Font.Bold = true;
            exRange.Value2 = tblThongtinHD.Rows[0][2].ToString();
            exRange = exSheet.Cells[1][hang + 16];//ô A1
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:F1"].Value = "Bằng chữ:" + ThucthiSQL.ChuyenSoSangChu(tblThongtinHD.Rows[0][2].ToString());
            exRange = exSheet.Cells[4][hang + 18];//ô a1
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);
            exRange.Range["A1:C1"].Value = "Hà nội, Ngày " + d.Day + " Tháng " + d.Month + " Năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].Value = "Nhân viên bán hàng";
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].Value = tblThongtinHD.Rows[0][7];
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exSheet.Name = "Hóa đơn bán";
            exApp.Visible = true;
        }
        private void cmbTenKH_DropDown(object sender, EventArgs e)
        {
            cmbTenKH.DataSource = ThucthiSQL.DocBang("SELECT TenKH FROM tblKhachHang");
            cmbTenKH.ValueMember = "TenKH";
            cmbTenKH.SelectedIndex = -1;
        }
        private void cmbTenNV_DropDown(object sender, EventArgs e)
        {
            cmbTenNV.DataSource = ThucthiSQL.DocBang("SELECT TenNV FROM tblNhanVien WHERE MaCV=N'CV03'");
            cmbTenNV.ValueMember = "TenNV";
            cmbTenNV.SelectedIndex = -1;
        }

        private void cmbTenNV_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT MaNV FROM tblNhanVien WHERE TenNV = N'" + cmbTenNV.Text + "'";
            DataTable tbl = ThucthiSQL.DocBang(sql);
            if (tbl.Rows.Count > 0)
            {
                cmbMaNV.Text = tbl.Rows[0][0].ToString();
            }
        }
        private void cmbTenKH_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT MaKH, Diachi, SDT, Email FROM tblKhachHang WHERE TenKH = N'" + cmbTenKH.Text + "'";
            DataTable tbl = ThucthiSQL.DocBang(sql);
            if (tbl.Rows.Count > 0)
            {
                cmbMaKH.Text = tbl.Rows[0][0].ToString();
                txtDiachi.Text = tbl.Rows[0][1].ToString();
                txtSDT.Text = tbl.Rows[0][2].ToString();
                txtEmail.Text = tbl.Rows[0][3].ToString();
            }
        }

        private void cmbTenSP_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT MaSP, Dongiaban FROM tblSanPham WHERE TenSP = N'" + cmbTenSP.Text + "'";
            DataTable tbl = ThucthiSQL.DocBang(sql);
            if (tbl.Rows.Count > 0)
            {
                cmbMaSP.Text = tbl.Rows[0][0].ToString();
                txtDongiaban.Text = tbl.Rows[0][1].ToString();
            }
        }

        private void cmbTenSP_DropDown(object sender, EventArgs e)
        {
            cmbTenSP.DataSource = ThucthiSQL.DocBang("SELECT TenSP FROM tblSanPham");
            cmbTenSP.ValueMember = "TenSP";
            cmbTenSP.SelectedIndex = -1;
        }
    }
}
