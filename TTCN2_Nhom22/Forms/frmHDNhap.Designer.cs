
namespace TTCN2_Nhom22.Forms
{
    partial class frmHDNhap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHDNhap));
            this.grbTTHD = new System.Windows.Forms.GroupBox();
            this.cmbTenNCC = new System.Windows.Forms.ComboBox();
            this.cmbMaNCC = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMaNV = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpNgaynhap = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenNV = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtDiachi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaHDNhap = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.grbCTHD = new System.Windows.Forms.GroupBox();
            this.txtTongtien = new System.Windows.Forms.TextBox();
            this.lblBangchu = new System.Windows.Forms.Label();
            this.txtThanhtien = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.txtGiamgia = new System.Windows.Forms.TextBox();
            this.txtDongianhap = new System.Windows.Forms.TextBox();
            this.txtSoluong = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.cmbMaSP = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.btnThemSP = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnThemhoadon = new System.Windows.Forms.Button();
            this.btnLuuhoadon = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnInhoadon = new System.Windows.Forms.Button();
            this.grbTTHD.SuspendLayout();
            this.grbCTHD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // grbTTHD
            // 
            this.grbTTHD.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.grbTTHD.Controls.Add(this.cmbTenNCC);
            this.grbTTHD.Controls.Add(this.cmbMaNCC);
            this.grbTTHD.Controls.Add(this.label1);
            this.grbTTHD.Controls.Add(this.cmbMaNV);
            this.grbTTHD.Controls.Add(this.label4);
            this.grbTTHD.Controls.Add(this.dtpNgaynhap);
            this.grbTTHD.Controls.Add(this.label6);
            this.grbTTHD.Controls.Add(this.txtEmail);
            this.grbTTHD.Controls.Add(this.label13);
            this.grbTTHD.Controls.Add(this.txtSDT);
            this.grbTTHD.Controls.Add(this.label3);
            this.grbTTHD.Controls.Add(this.txtTenNV);
            this.grbTTHD.Controls.Add(this.label5);
            this.grbTTHD.Controls.Add(this.label14);
            this.grbTTHD.Controls.Add(this.txtDiachi);
            this.grbTTHD.Controls.Add(this.label2);
            this.grbTTHD.Controls.Add(this.txtMaHDNhap);
            this.grbTTHD.Controls.Add(this.label7);
            this.grbTTHD.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.grbTTHD.ForeColor = System.Drawing.Color.Navy;
            this.grbTTHD.Location = new System.Drawing.Point(133, 107);
            this.grbTTHD.Name = "grbTTHD";
            this.grbTTHD.Size = new System.Drawing.Size(1176, 274);
            this.grbTTHD.TabIndex = 0;
            this.grbTTHD.TabStop = false;
            this.grbTTHD.Text = "Thông tin hóa đơn";
            // 
            // cmbTenNCC
            // 
            this.cmbTenNCC.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbTenNCC.FormattingEnabled = true;
            this.cmbTenNCC.Location = new System.Drawing.Point(815, 81);
            this.cmbTenNCC.Name = "cmbTenNCC";
            this.cmbTenNCC.Size = new System.Drawing.Size(278, 31);
            this.cmbTenNCC.TabIndex = 130;
            this.cmbTenNCC.DropDown += new System.EventHandler(this.cmbTenNCC_DropDown);
            this.cmbTenNCC.TextChanged += new System.EventHandler(this.cmbTenNCC_TextChanged);
            // 
            // cmbMaNCC
            // 
            this.cmbMaNCC.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cmbMaNCC.FormattingEnabled = true;
            this.cmbMaNCC.Location = new System.Drawing.Point(815, 32);
            this.cmbMaNCC.Name = "cmbMaNCC";
            this.cmbMaNCC.Size = new System.Drawing.Size(278, 31);
            this.cmbMaNCC.TabIndex = 129;
            this.cmbMaNCC.DropDown += new System.EventHandler(this.cmbMaNCC_DropDown);
            this.cmbMaNCC.TextChanged += new System.EventHandler(this.cmbMaNCC_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(648, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 22);
            this.label1.TabIndex = 128;
            this.label1.Text = "Mã nhà cung cấp";
            // 
            // cmbMaNV
            // 
            this.cmbMaNV.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cmbMaNV.FormattingEnabled = true;
            this.cmbMaNV.Location = new System.Drawing.Point(219, 130);
            this.cmbMaNV.Name = "cmbMaNV";
            this.cmbMaNV.Size = new System.Drawing.Size(278, 31);
            this.cmbMaNV.TabIndex = 126;
            this.cmbMaNV.DropDown += new System.EventHandler(this.cmbMaNV_DropDown);
            this.cmbMaNV.TextChanged += new System.EventHandler(this.cmbMaNV_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(63, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 22);
            this.label4.TabIndex = 125;
            this.label4.Text = "Mã nhân viên";
            // 
            // dtpNgaynhap
            // 
            this.dtpNgaynhap.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpNgaynhap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgaynhap.Location = new System.Drawing.Point(219, 82);
            this.dtpNgaynhap.Name = "dtpNgaynhap";
            this.dtpNgaynhap.Size = new System.Drawing.Size(278, 30);
            this.dtpNgaynhap.TabIndex = 127;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Location = new System.Drawing.Point(63, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 22);
            this.label6.TabIndex = 126;
            this.label6.Text = "Ngày nhập";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtEmail.Location = new System.Drawing.Point(815, 226);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtEmail.Size = new System.Drawing.Size(278, 30);
            this.txtEmail.TabIndex = 115;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.ForeColor = System.Drawing.Color.Navy;
            this.label13.Location = new System.Drawing.Point(648, 231);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(57, 22);
            this.label13.TabIndex = 114;
            this.label13.Text = "Email";
            // 
            // txtSDT
            // 
            this.txtSDT.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSDT.Location = new System.Drawing.Point(815, 178);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSDT.Size = new System.Drawing.Size(278, 30);
            this.txtSDT.TabIndex = 115;
            this.txtSDT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSDT_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(648, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 22);
            this.label3.TabIndex = 114;
            this.label3.Text = "Điện thoại";
            // 
            // txtTenNV
            // 
            this.txtTenNV.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTenNV.Location = new System.Drawing.Point(219, 178);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTenNV.Size = new System.Drawing.Size(278, 30);
            this.txtTenNV.TabIndex = 115;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(63, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 22);
            this.label5.TabIndex = 114;
            this.label5.Text = "Tên nhân viên";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label14.ForeColor = System.Drawing.Color.Navy;
            this.label14.Location = new System.Drawing.Point(648, 85);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(146, 22);
            this.label14.TabIndex = 114;
            this.label14.Text = "Tên nhà cung cấp";
            // 
            // txtDiachi
            // 
            this.txtDiachi.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDiachi.Location = new System.Drawing.Point(815, 129);
            this.txtDiachi.Name = "txtDiachi";
            this.txtDiachi.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDiachi.Size = new System.Drawing.Size(278, 30);
            this.txtDiachi.TabIndex = 115;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(648, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 22);
            this.label2.TabIndex = 114;
            this.label2.Text = "Địa chỉ";
            // 
            // txtMaHDNhap
            // 
            this.txtMaHDNhap.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtMaHDNhap.Location = new System.Drawing.Point(219, 33);
            this.txtMaHDNhap.Name = "txtMaHDNhap";
            this.txtMaHDNhap.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMaHDNhap.Size = new System.Drawing.Size(278, 30);
            this.txtMaHDNhap.TabIndex = 115;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.Navy;
            this.label7.Location = new System.Drawing.Point(63, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 22);
            this.label7.TabIndex = 114;
            this.label7.Text = "Mã hóa đơn";
            // 
            // grbCTHD
            // 
            this.grbCTHD.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.grbCTHD.Controls.Add(this.txtTongtien);
            this.grbCTHD.Controls.Add(this.lblBangchu);
            this.grbCTHD.Controls.Add(this.txtThanhtien);
            this.grbCTHD.Controls.Add(this.label8);
            this.grbCTHD.Controls.Add(this.txtTenSP);
            this.grbCTHD.Controls.Add(this.txtGiamgia);
            this.grbCTHD.Controls.Add(this.txtDongianhap);
            this.grbCTHD.Controls.Add(this.txtSoluong);
            this.grbCTHD.Controls.Add(this.label15);
            this.grbCTHD.Controls.Add(this.label16);
            this.grbCTHD.Controls.Add(this.label17);
            this.grbCTHD.Controls.Add(this.label18);
            this.grbCTHD.Controls.Add(this.label19);
            this.grbCTHD.Controls.Add(this.cmbMaSP);
            this.grbCTHD.Controls.Add(this.label20);
            this.grbCTHD.Controls.Add(this.btnThemSP);
            this.grbCTHD.Controls.Add(this.dataGridView1);
            this.grbCTHD.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.grbCTHD.ForeColor = System.Drawing.Color.Navy;
            this.grbCTHD.Location = new System.Drawing.Point(73, 400);
            this.grbCTHD.Name = "grbCTHD";
            this.grbCTHD.Size = new System.Drawing.Size(1292, 526);
            this.grbCTHD.TabIndex = 1;
            this.grbCTHD.TabStop = false;
            this.grbCTHD.Text = "Chi tiết hóa đơn";
            // 
            // txtTongtien
            // 
            this.txtTongtien.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTongtien.Location = new System.Drawing.Point(172, 477);
            this.txtTongtien.Name = "txtTongtien";
            this.txtTongtien.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTongtien.Size = new System.Drawing.Size(233, 30);
            this.txtTongtien.TabIndex = 141;
            // 
            // lblBangchu
            // 
            this.lblBangchu.AutoSize = true;
            this.lblBangchu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblBangchu.ForeColor = System.Drawing.Color.Navy;
            this.lblBangchu.Location = new System.Drawing.Point(492, 481);
            this.lblBangchu.Name = "lblBangchu";
            this.lblBangchu.Size = new System.Drawing.Size(100, 22);
            this.lblBangchu.TabIndex = 139;
            this.lblBangchu.Text = "Bằng chữ : ";
            // 
            // txtThanhtien
            // 
            this.txtThanhtien.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtThanhtien.Location = new System.Drawing.Point(959, 108);
            this.txtThanhtien.Name = "txtThanhtien";
            this.txtThanhtien.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtThanhtien.Size = new System.Drawing.Size(233, 30);
            this.txtThanhtien.TabIndex = 142;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.Navy;
            this.label8.Location = new System.Drawing.Point(60, 481);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 22);
            this.label8.TabIndex = 140;
            this.label8.Text = "Tổng tiền";
            // 
            // txtTenSP
            // 
            this.txtTenSP.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTenSP.Location = new System.Drawing.Point(567, 38);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTenSP.Size = new System.Drawing.Size(233, 30);
            this.txtTenSP.TabIndex = 143;
            // 
            // txtGiamgia
            // 
            this.txtGiamgia.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtGiamgia.Location = new System.Drawing.Point(567, 108);
            this.txtGiamgia.Name = "txtGiamgia";
            this.txtGiamgia.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtGiamgia.Size = new System.Drawing.Size(233, 30);
            this.txtGiamgia.TabIndex = 144;
            this.txtGiamgia.TextChanged += new System.EventHandler(this.txtGiamgia_TextChanged);
            this.txtGiamgia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGiamgia_KeyPress);
            // 
            // txtDongianhap
            // 
            this.txtDongianhap.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDongianhap.Location = new System.Drawing.Point(172, 104);
            this.txtDongianhap.Name = "txtDongianhap";
            this.txtDongianhap.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDongianhap.Size = new System.Drawing.Size(233, 30);
            this.txtDongianhap.TabIndex = 145;
            this.txtDongianhap.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDongianhap_KeyPress);
            // 
            // txtSoluong
            // 
            this.txtSoluong.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSoluong.Location = new System.Drawing.Point(959, 38);
            this.txtSoluong.Name = "txtSoluong";
            this.txtSoluong.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSoluong.Size = new System.Drawing.Size(233, 30);
            this.txtSoluong.TabIndex = 146;
            this.txtSoluong.TextChanged += new System.EventHandler(this.txtSoluong_TextChanged);
            this.txtSoluong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoluong_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label15.ForeColor = System.Drawing.Color.Navy;
            this.label15.Location = new System.Drawing.Point(854, 112);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(92, 22);
            this.label15.TabIndex = 136;
            this.label15.Text = "Thành tiền";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label16.ForeColor = System.Drawing.Color.Navy;
            this.label16.Location = new System.Drawing.Point(439, 116);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(118, 22);
            this.label16.TabIndex = 137;
            this.label16.Text = "Giảm giá (%)";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label17.ForeColor = System.Drawing.Color.Navy;
            this.label17.Location = new System.Drawing.Point(60, 112);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(78, 22);
            this.label17.TabIndex = 138;
            this.label17.Text = "Đơn giá ";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label18.ForeColor = System.Drawing.Color.Navy;
            this.label18.Location = new System.Drawing.Point(854, 42);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(82, 22);
            this.label18.TabIndex = 139;
            this.label18.Text = "Số lượng";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label19.ForeColor = System.Drawing.Color.Navy;
            this.label19.Location = new System.Drawing.Point(439, 42);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(118, 22);
            this.label19.TabIndex = 140;
            this.label19.Text = "Tên sản phẩm";
            // 
            // cmbMaSP
            // 
            this.cmbMaSP.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cmbMaSP.FormattingEnabled = true;
            this.cmbMaSP.Location = new System.Drawing.Point(172, 37);
            this.cmbMaSP.Name = "cmbMaSP";
            this.cmbMaSP.Size = new System.Drawing.Size(233, 31);
            this.cmbMaSP.TabIndex = 147;
            this.cmbMaSP.DropDown += new System.EventHandler(this.cmbMaSP_DropDown);
            this.cmbMaSP.TextChanged += new System.EventHandler(this.cmbMaSP_TextChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label20.ForeColor = System.Drawing.Color.Navy;
            this.label20.Location = new System.Drawing.Point(60, 42);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(114, 22);
            this.label20.TabIndex = 141;
            this.label20.Text = "Mã sản phẩm";
            // 
            // btnThemSP
            // 
            this.btnThemSP.Image = global::TTCN2_Nhom22.Properties.Resources.Button_Add_icon;
            this.btnThemSP.Location = new System.Drawing.Point(1219, 67);
            this.btnThemSP.Name = "btnThemSP";
            this.btnThemSP.Size = new System.Drawing.Size(43, 40);
            this.btnThemSP.TabIndex = 135;
            this.btnThemSP.UseVisualStyleBackColor = true;
            this.btnThemSP.Click += new System.EventHandler(this.btnThemSP_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(60, 183);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(1176, 263);
            this.dataGridView1.TabIndex = 134;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // btnThemhoadon
            // 
            this.btnThemhoadon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnThemhoadon.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnThemhoadon.Image = ((System.Drawing.Image)(resources.GetObject("btnThemhoadon.Image")));
            this.btnThemhoadon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemhoadon.Location = new System.Drawing.Point(73, 32);
            this.btnThemhoadon.Name = "btnThemhoadon";
            this.btnThemhoadon.Size = new System.Drawing.Size(180, 45);
            this.btnThemhoadon.TabIndex = 135;
            this.btnThemhoadon.Text = "   Thêm hóa đơn";
            this.btnThemhoadon.UseVisualStyleBackColor = true;
            this.btnThemhoadon.Click += new System.EventHandler(this.btnThemhoadon_Click);
            // 
            // btnLuuhoadon
            // 
            this.btnLuuhoadon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLuuhoadon.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnLuuhoadon.Image = ((System.Drawing.Image)(resources.GetObject("btnLuuhoadon.Image")));
            this.btnLuuhoadon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuuhoadon.Location = new System.Drawing.Point(298, 32);
            this.btnLuuhoadon.Name = "btnLuuhoadon";
            this.btnLuuhoadon.Size = new System.Drawing.Size(180, 45);
            this.btnLuuhoadon.TabIndex = 136;
            this.btnLuuhoadon.Text = "    Lưu hóa đơn";
            this.btnLuuhoadon.UseVisualStyleBackColor = true;
            this.btnLuuhoadon.Click += new System.EventHandler(this.btnLuuhoadon_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnHuy.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnHuy.Image = global::TTCN2_Nhom22.Properties.Resources.Actions_dialog_cancel_icon;
            this.btnHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHuy.Location = new System.Drawing.Point(527, 32);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(113, 45);
            this.btnHuy.TabIndex = 137;
            this.btnHuy.Text = "   Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnDong
            // 
            this.btnDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDong.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnDong.Image = global::TTCN2_Nhom22.Properties.Resources.Button_Close_icon;
            this.btnDong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDong.Location = new System.Drawing.Point(905, 32);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(113, 45);
            this.btnDong.TabIndex = 138;
            this.btnDong.Text = "   Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnInhoadon
            // 
            this.btnInhoadon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnInhoadon.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnInhoadon.Image = global::TTCN2_Nhom22.Properties.Resources.print_icon;
            this.btnInhoadon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInhoadon.Location = new System.Drawing.Point(683, 32);
            this.btnInhoadon.Name = "btnInhoadon";
            this.btnInhoadon.Size = new System.Drawing.Size(180, 45);
            this.btnInhoadon.TabIndex = 136;
            this.btnInhoadon.Text = "    In hóa đơn";
            this.btnInhoadon.UseVisualStyleBackColor = true;
            this.btnInhoadon.Click += new System.EventHandler(this.btnInhoadon_Click);
            // 
            // frmHDNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1442, 942);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnInhoadon);
            this.Controls.Add(this.btnLuuhoadon);
            this.Controls.Add(this.btnThemhoadon);
            this.Controls.Add(this.grbCTHD);
            this.Controls.Add(this.grbTTHD);
            this.Name = "frmHDNhap";
            this.Text = "Chương trình quản lý Công ty Cổ phần VIVU Group Việt Nam";
            this.Load += new System.EventHandler(this.frmHDNhap_Load);
            this.grbTTHD.ResumeLayout(false);
            this.grbTTHD.PerformLayout();
            this.grbCTHD.ResumeLayout(false);
            this.grbCTHD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbTTHD;
        private System.Windows.Forms.TextBox txtMaHDNhap;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpNgaynhap;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbMaNCC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMaNV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDiachi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grbCTHD;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnThemhoadon;
        private System.Windows.Forms.Button btnLuuhoadon;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnInhoadon;
        private System.Windows.Forms.Button btnThemSP;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtTenNV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtThanhtien;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.TextBox txtGiamgia;
        private System.Windows.Forms.TextBox txtDongianhap;
        private System.Windows.Forms.TextBox txtSoluong;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cmbMaSP;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtTongtien;
        private System.Windows.Forms.Label lblBangchu;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbTenNCC;
    }
}