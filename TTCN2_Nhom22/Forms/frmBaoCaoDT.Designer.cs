
namespace TTCN2_Nhom22.Forms
{
    partial class frmBaoCaoDT
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbQuy = new System.Windows.Forms.ComboBox();
            this.cmbThang = new System.Windows.Forms.ComboBox();
            this.cmbDK = new System.Windows.Forms.ComboBox();
            this.txtNam = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDoanhthu = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnInbaocao = new System.Windows.Forms.Button();
            this.btnLamlai = new System.Windows.Forms.Button();
            this.btnBaocao = new System.Windows.Forms.Button();
            this.txtDoanhThu = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.Controls.Add(this.cmbQuy);
            this.groupBox1.Controls.Add(this.cmbThang);
            this.groupBox1.Controls.Add(this.cmbDK);
            this.groupBox1.Controls.Add(this.txtNam);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(128, 136);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(765, 166);
            this.groupBox1.TabIndex = 144;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Điều kiện";
            // 
            // cmbQuy
            // 
            this.cmbQuy.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cmbQuy.FormattingEnabled = true;
            this.cmbQuy.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cmbQuy.Location = new System.Drawing.Point(521, 73);
            this.cmbQuy.Name = "cmbQuy";
            this.cmbQuy.Size = new System.Drawing.Size(216, 31);
            this.cmbQuy.TabIndex = 145;
            // 
            // cmbThang
            // 
            this.cmbThang.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cmbThang.FormattingEnabled = true;
            this.cmbThang.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cmbThang.Location = new System.Drawing.Point(521, 26);
            this.cmbThang.Name = "cmbThang";
            this.cmbThang.Size = new System.Drawing.Size(216, 31);
            this.cmbThang.TabIndex = 145;
            // 
            // cmbDK
            // 
            this.cmbDK.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cmbDK.FormattingEnabled = true;
            this.cmbDK.Items.AddRange(new object[] {
            "Tháng",
            "Quý",
            "Năm"});
            this.cmbDK.Location = new System.Drawing.Point(157, 73);
            this.cmbDK.Name = "cmbDK";
            this.cmbDK.Size = new System.Drawing.Size(140, 31);
            this.cmbDK.TabIndex = 145;
            this.cmbDK.TextChanged += new System.EventHandler(this.cmbDK_TextChanged);
            // 
            // txtNam
            // 
            this.txtNam.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNam.Location = new System.Drawing.Point(521, 121);
            this.txtNam.Name = "txtNam";
            this.txtNam.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtNam.Size = new System.Drawing.Size(216, 30);
            this.txtNam.TabIndex = 115;
            this.txtNam.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNam_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.ForeColor = System.Drawing.Color.Navy;
            this.label13.Location = new System.Drawing.Point(420, 125);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 22);
            this.label13.TabIndex = 114;
            this.label13.Text = "Năm";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(420, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 22);
            this.label5.TabIndex = 114;
            this.label5.Text = "Tháng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(420, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 22);
            this.label2.TabIndex = 114;
            this.label2.Text = "Quý";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.Navy;
            this.label7.Location = new System.Drawing.Point(38, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 22);
            this.label7.TabIndex = 114;
            this.label7.Text = "Báo cáo theo";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.ForeColor = System.Drawing.Color.Navy;
            this.groupBox2.Location = new System.Drawing.Point(42, 350);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(956, 248);
            this.groupBox2.TabIndex = 144;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 26);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(944, 216);
            this.dataGridView1.TabIndex = 143;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(166, 616);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 22);
            this.label1.TabIndex = 114;
            this.label1.Text = "Doanh thu ";
            // 
            // lblDoanhthu
            // 
            this.lblDoanhthu.AutoSize = true;
            this.lblDoanhthu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDoanhthu.ForeColor = System.Drawing.Color.Navy;
            this.lblDoanhthu.Location = new System.Drawing.Point(166, 656);
            this.lblDoanhthu.Name = "lblDoanhthu";
            this.lblDoanhthu.Size = new System.Drawing.Size(95, 22);
            this.lblDoanhthu.TabIndex = 114;
            this.lblDoanhthu.Text = "Bằng chữ :";
            // 
            // btnDong
            // 
            this.btnDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDong.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnDong.Image = global::TTCN2_Nhom22.Properties.Resources.Button_Close_icon;
            this.btnDong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDong.Location = new System.Drawing.Point(740, 43);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(113, 45);
            this.btnDong.TabIndex = 147;
            this.btnDong.Text = "   Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnInbaocao
            // 
            this.btnInbaocao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnInbaocao.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnInbaocao.Image = global::TTCN2_Nhom22.Properties.Resources.print_icon;
            this.btnInbaocao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInbaocao.Location = new System.Drawing.Point(548, 43);
            this.btnInbaocao.Name = "btnInbaocao";
            this.btnInbaocao.Size = new System.Drawing.Size(152, 45);
            this.btnInbaocao.TabIndex = 146;
            this.btnInbaocao.Text = "   In báo cáo";
            this.btnInbaocao.UseVisualStyleBackColor = true;
            this.btnInbaocao.Click += new System.EventHandler(this.btnInbaocao_Click);
            // 
            // btnLamlai
            // 
            this.btnLamlai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLamlai.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnLamlai.Image = global::TTCN2_Nhom22.Properties.Resources.Button_Refresh_icon__1_;
            this.btnLamlai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLamlai.Location = new System.Drawing.Point(373, 43);
            this.btnLamlai.Name = "btnLamlai";
            this.btnLamlai.Size = new System.Drawing.Size(133, 45);
            this.btnLamlai.TabIndex = 145;
            this.btnLamlai.Text = "   Làm lại";
            this.btnLamlai.UseVisualStyleBackColor = true;
            this.btnLamlai.Click += new System.EventHandler(this.btnLamlai_Click);
            // 
            // btnBaocao
            // 
            this.btnBaocao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBaocao.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnBaocao.Image = global::TTCN2_Nhom22.Properties.Resources.Pencil_icon1;
            this.btnBaocao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBaocao.Location = new System.Drawing.Point(179, 43);
            this.btnBaocao.Name = "btnBaocao";
            this.btnBaocao.Size = new System.Drawing.Size(152, 45);
            this.btnBaocao.TabIndex = 146;
            this.btnBaocao.Text = "    Báo cáo";
            this.btnBaocao.UseVisualStyleBackColor = true;
            this.btnBaocao.Click += new System.EventHandler(this.btnBaocao_Click);
            // 
            // txtDoanhThu
            // 
            this.txtDoanhThu.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDoanhThu.Location = new System.Drawing.Point(285, 612);
            this.txtDoanhThu.Name = "txtDoanhThu";
            this.txtDoanhThu.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDoanhThu.Size = new System.Drawing.Size(177, 30);
            this.txtDoanhThu.TabIndex = 115;
            // 
            // frmBaoCaoDT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1048, 687);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnBaocao);
            this.Controls.Add(this.btnInbaocao);
            this.Controls.Add(this.txtDoanhThu);
            this.Controls.Add(this.btnLamlai);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblDoanhthu);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmBaoCaoDT";
            this.Text = "Chương trình quản lý Công ty Cổ phần VIVU Group Việt Nam";
            this.Load += new System.EventHandler(this.frmBaoCaoDT_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNam;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbQuy;
        private System.Windows.Forms.ComboBox cmbThang;
        private System.Windows.Forms.ComboBox cmbDK;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDoanhthu;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnInbaocao;
        private System.Windows.Forms.Button btnLamlai;
        private System.Windows.Forms.Button btnBaocao;
        private System.Windows.Forms.TextBox txtDoanhThu;
    }
}