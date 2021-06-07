using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace TTCN2_Nhom22.Forms
{
    public partial class frmBaoCaoHTK : Form
    {
        public frmBaoCaoHTK()
        {
            InitializeComponent();
        }

        private void frmBaoCaoHTK_Load(object sender, EventArgs e)
        {
            Hienthi_Luoi();
            txtMaSP.Enabled = false;
            txtTenSP.Enabled = false;
            txtDonvitinh.Enabled = false;
            txtSoluong.Enabled = false;
            txtDongianhap.Enabled = false;
            txtDongiaban.Enabled = false;
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Hàng trong kho đã hết !");
                return;
            }
            DataTable DT = new DataTable();
            string sql = "Select MaSP,TenSP,Soluong,DVT,Dongianhap,Dongiaban FROM tblSanPham Where MaSP = N'" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
            DT = ThucthiSQL.DocBang(sql);
            txtMaSP.Text = DT.Rows[0][0].ToString();
            txtTenSP.Text = DT.Rows[0][1].ToString();
            txtSoluong.Text = DT.Rows[0][2].ToString();
            txtDonvitinh.Text = DT.Rows[0][3].ToString();
            txtDongianhap.Text = DT.Rows[0][4].ToString();
            txtDongiaban.Text = DT.Rows[0][5].ToString();
        }
        private void Hienthi_Luoi()
        {
            string sql;
            DataTable tblHH;
            sql = "Select MaSP,TenSP,Soluong FROM tblSanPham Where Soluong > 0";
            tblHH = ThucthiSQL.DocBang(sql);
            dataGridView1.DataSource = tblHH;
            dataGridView1.Columns[0].HeaderText = "Mã sản phẩm";
            dataGridView1.Columns[1].HeaderText = "Tên sản phẩm";
            dataGridView1.Columns[2].HeaderText = "Số lượng";
            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 350;
            dataGridView1.Columns[2].Width = 180;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            tblHH.Dispose();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable DT = new DataTable();
            string sql = "Select MaSP,TenSP,Soluong,DVT,Dongianhap,Dongiaban FROM tblSanPham Where MaSP = N'" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
            DT = ThucthiSQL.DocBang(sql);
            txtMaSP.Text = DT.Rows[0][0].ToString();
            txtTenSP.Text = DT.Rows[0][1].ToString();
            txtSoluong.Text = DT.Rows[0][2].ToString();
            txtDonvitinh.Text = DT.Rows[0][3].ToString();
            txtDongianhap.Text = DT.Rows[0][4].ToString();
            txtDongiaban.Text = DT.Rows[0][5].ToString();
        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            Hienthi_Luoi();
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Sản phẩm trong kho đã hết !");
                return;
            }
            DataTable DT = new DataTable();
            string sql = "Select MaSP,TenSP,Soluong,DVT,Dongianhap,Dongiaban FROM tblSanPham Where MaSP = N'" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
            DT = ThucthiSQL.DocBang(sql);
            txtMaSP.Text = DT.Rows[0][0].ToString();
            txtTenSP.Text = DT.Rows[0][1].ToString();
            txtSoluong.Text = DT.Rows[0][2].ToString();
            txtDonvitinh.Text = DT.Rows[0][3].ToString();
            txtDongianhap.Text = DT.Rows[0][4].ToString();
            txtDongiaban.Text = DT.Rows[0][5].ToString();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInbaocao_Click(object sender, EventArgs e)
        {
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook;
            COMExcel.Worksheet exSheet;
            COMExcel.Range exRange;
            string sql;
            DataTable tblThongtinHang;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Name = "Times new roman";
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 18;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "VIVU Group";
            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Hà Đông - Hà nội";
            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "0969385885 - 0865889258";
            exRange.Range["C2:D2"].Font.Size = 15;
            exRange.Range["C2:D2"].Font.Name = "Times new roman";
            exRange.Range["C2:D2"].Font.Bold = true;
            exRange.Range["C2:D2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C2:D2"].MergeCells = true;
            exRange.Range["C2:D2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:D2"].Value = "BÁO CÁO HÀNG TỒN KHO";

            sql = "Select MaSP,TenSP,Soluong FROM tblSanPham";
            tblThongtinHang = ThucthiSQL.DocBang(sql);
            //Tạo dòng tiêu đề
            exRange.Range["A5:F5"].Font.Bold = true;
            exRange.Range["A5:F5"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["D5:F5"].ColumnWidth = 10;
            exRange.Range["C5:C5"].ColumnWidth = 30;
            exRange.Range["A5:A5"].Value = "STT";
            exRange.Range["B5:B5"].Value = "Mã hàng";
            exRange.Range["C5:C5"].Value = "Tên hàng";
            exRange.Range["D5:D5"].Value = "Số lượng";
            int hang, cot;
            for (hang = 0; hang <= tblThongtinHang.Rows.Count - 1; hang++)
            {
                //điền stt vào cột 1 dòng 6
                exSheet.Cells[1][hang + 6] = hang + 1;
                for (cot = 0; cot <= tblThongtinHang.Columns.Count - 1; cot++)
                    //điền thông tin từ cột t2 dòng 6
                    exSheet.Cells[cot + 2][hang + 6] = tblThongtinHang.Rows[hang][cot].ToString();
            }
            DateTime d = DateTime.Now;
            exRange = exSheet.Cells[1][hang + 8];//ô A1
            exRange.Range["C1:F1"].MergeCells = true;
            exRange.Range["C1:F1"].Font.Bold = true;
            exRange.Range["C1:F1"].Value = "Hà nội,  ngày " + d.Day + "   tháng " + d.Month + "   năm " + d.Year;
            exSheet.Name = "Báo cáo hàng tồn kho";
            exApp.Visible = true;
        }
    }
}
