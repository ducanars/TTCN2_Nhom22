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

        private void btnInbaocao_Click(object sender, EventArgs e)
        {
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook;
            COMExcel.Worksheet exSheet;
            COMExcel.Range exRange;
            int hang = 0, cot = 0;
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
            exRange.Range["C2:E2"].Value = "BÁO CÁO DOANH THU";


            //Tạo dòng tiêu đề
            exRange.Range["A5:F5"].Font.Bold = true;
            exRange.Range["A5:F5"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C5:F5"].ColumnWidth = 15;
            exRange.Range["E5:E5"].ColumnWidth = 18;
            exRange.Range["A5:A5"].Value = "STT";
            exRange.Range["B5:B5"].Value = "Mã hoá đơn";
            exRange.Range["C5:C5"].Value = "Mã nhân viên";
            exRange.Range["D5:D5"].Value = "Mã Khách hàng";
            exRange.Range["E5:E5"].Value = "Ngày bán";
            exRange.Range["F5:F5"].Value = "Tổng tiền";
            for (hang = 0; hang <= dataGridView1.Rows.Count - 1; hang++)
            {
                //điền stt vào cột 1 dòng 12
                exSheet.Cells[1][hang + 6] = hang + 1;
                for (cot = 0; cot <= dataGridView1.Columns.Count - 1; cot++)
                    //điền thông tin từ cột t2 dòng 12
                    exSheet.Cells[cot + 2][hang + 6] = dataGridView1.Rows[hang].Cells[cot].Value.ToString();
            }
            exRange = exSheet.Cells[cot][hang + 8];
            exRange.Font.Bold = true;
            exRange.Value2 = "Doanh thu: ";
            exRange = exSheet.Cells[cot + 1][hang + 8];
            exRange.Font.Bold = true;
            exRange.Value2 = txtDoanhThu.Text;
            exRange = exSheet.Cells[1][hang + 9];//ô A1
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange.Range["A1:F1"].Value = "Bằng chữ: " + ThucthiSQL.ChuyenSoSangChu(txtDoanhThu.Text);

            DateTime d = DateTime.Now;
            exRange = exSheet.Cells[1][hang + 11];
            exRange.Range["D1:E1"].MergeCells = true;
            exRange.Range["D1:E1"].Font.Bold = true;
            exRange.Range["D1:E1"].Value = "Hà nội, Ngày " + d.Day + " Tháng " + d.Month + " Năm " + d.Year;
            exRange.Range["D2:E2"].MergeCells = true;
            exRange.Range["D2:E2"].Value = "Nhân viên lập báo cáo";
            exRange.Range["D2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exSheet.Name = "Báo cáo doanh thu";
            exApp.Visible = true;
        }
    }
}
