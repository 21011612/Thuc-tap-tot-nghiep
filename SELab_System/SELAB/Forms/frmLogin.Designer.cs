namespace SELAB
{
    partial class frmLogin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelLeftBrand = new Panel();
            lblTitle = new Label();
            pictureBoxLogo = new PictureBox();
            panelRightLogin = new Panel();
            btnThoat = new Button();
            btnDangNhap = new Button();
            panelPassword = new Panel();
            txtMatKhau = new TextBox();
            lblMatKhau = new Label();
            panelUsername = new Panel();
            txtTenDangNhap = new TextBox();
            lblTenDangNhap = new Label();
            lblLoginHeader = new Label();
            panelLeftBrand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            panelRightLogin.SuspendLayout();
            panelPassword.SuspendLayout();
            panelUsername.SuspendLayout();
            SuspendLayout();
            // 
            // panelLeftBrand
            // 
            panelLeftBrand.BackColor = Color.FromArgb(0, 83, 166);
            panelLeftBrand.Controls.Add(lblTitle);
            panelLeftBrand.Controls.Add(pictureBoxLogo);
            panelLeftBrand.Dock = DockStyle.Left;
            panelLeftBrand.Location = new Point(0, 0);
            panelLeftBrand.Margin = new Padding(3, 4, 3, 4);
            panelLeftBrand.Name = "panelLeftBrand";
            panelLeftBrand.Size = new Size(400, 688);
            panelLeftBrand.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(25, 325);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(350, 188);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "HỆ THỐNG QUẢN LÝ\r\nTHIẾT BỊ VÀ LỊCH\r\nSE LAB";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.BackColor = Color.Transparent;
            pictureBoxLogo.Location = new Point(100, 50);
            pictureBoxLogo.Margin = new Padding(3, 4, 3, 4);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(200, 250);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;
            // 
            // panelRightLogin
            // 
            panelRightLogin.BackColor = Color.White;
            panelRightLogin.Controls.Add(btnThoat);
            panelRightLogin.Controls.Add(btnDangNhap);
            panelRightLogin.Controls.Add(panelPassword);
            panelRightLogin.Controls.Add(lblMatKhau);
            panelRightLogin.Controls.Add(panelUsername);
            panelRightLogin.Controls.Add(lblTenDangNhap);
            panelRightLogin.Controls.Add(lblLoginHeader);
            panelRightLogin.Dock = DockStyle.Fill;
            panelRightLogin.Location = new Point(400, 0);
            panelRightLogin.Margin = new Padding(3, 4, 3, 4);
            panelRightLogin.Name = "panelRightLogin";
            panelRightLogin.Size = new Size(500, 688);
            panelRightLogin.TabIndex = 1;
            // 
            // btnThoat
            // 
            btnThoat.BackColor = Color.White;
            btnThoat.Cursor = Cursors.Hand;
            btnThoat.FlatAppearance.BorderSize = 0;
            btnThoat.FlatStyle = FlatStyle.Flat;
            btnThoat.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            btnThoat.ForeColor = Color.FromArgb(220, 53, 69);
            btnThoat.Location = new Point(280, 525);
            btnThoat.Margin = new Padding(3, 4, 3, 4);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(140, 56);
            btnThoat.TabIndex = 7;
            btnThoat.Text = "THOÁT";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnDangNhap
            // 
            btnDangNhap.BackColor = Color.FromArgb(0, 168, 232);
            btnDangNhap.Cursor = Cursors.Hand;
            btnDangNhap.FlatAppearance.BorderSize = 0;
            btnDangNhap.FlatStyle = FlatStyle.Flat;
            btnDangNhap.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnDangNhap.ForeColor = Color.White;
            btnDangNhap.Location = new Point(80, 525);
            btnDangNhap.Margin = new Padding(3, 4, 3, 4);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(180, 56);
            btnDangNhap.TabIndex = 6;
            btnDangNhap.Text = "ĐĂNG NHẬP";
            btnDangNhap.UseVisualStyleBackColor = false;
            btnDangNhap.Click += btnDangNhap_Click;
            // 
            // panelPassword
            // 
            panelPassword.BackColor = Color.WhiteSmoke;
            panelPassword.Controls.Add(txtMatKhau);
            panelPassword.Location = new Point(80, 362);
            panelPassword.Margin = new Padding(3, 4, 3, 4);
            panelPassword.Name = "panelPassword";
            panelPassword.Padding = new Padding(10, 15, 10, 12);
            panelPassword.Size = new Size(340, 62);
            panelPassword.TabIndex = 5;
            // 
            // txtMatKhau
            // 
            txtMatKhau.BackColor = Color.WhiteSmoke;
            txtMatKhau.BorderStyle = BorderStyle.None;
            txtMatKhau.Dock = DockStyle.Fill;
            txtMatKhau.Font = new Font("Segoe UI", 13F);
            txtMatKhau.ForeColor = Color.FromArgb(64, 64, 64);
            txtMatKhau.Location = new Point(10, 15);
            txtMatKhau.Margin = new Padding(3, 4, 3, 4);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PasswordChar = '●';
            txtMatKhau.Size = new Size(320, 29);
            txtMatKhau.TabIndex = 0;
            // 
            // lblMatKhau
            // 
            lblMatKhau.AutoSize = true;
            lblMatKhau.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblMatKhau.ForeColor = Color.Gray;
            lblMatKhau.Location = new Point(80, 325);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Size = new Size(84, 23);
            lblMatKhau.TabIndex = 4;
            lblMatKhau.Text = "Mật khẩu";
            // 
            // panelUsername
            // 
            panelUsername.BackColor = Color.WhiteSmoke;
            panelUsername.Controls.Add(txtTenDangNhap);
            panelUsername.Location = new Point(80, 225);
            panelUsername.Margin = new Padding(3, 4, 3, 4);
            panelUsername.Name = "panelUsername";
            panelUsername.Padding = new Padding(10, 15, 10, 12);
            panelUsername.Size = new Size(340, 62);
            panelUsername.TabIndex = 3;
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.BackColor = Color.WhiteSmoke;
            txtTenDangNhap.BorderStyle = BorderStyle.None;
            txtTenDangNhap.Dock = DockStyle.Fill;
            txtTenDangNhap.Font = new Font("Segoe UI", 13F);
            txtTenDangNhap.ForeColor = Color.FromArgb(64, 64, 64);
            txtTenDangNhap.Location = new Point(10, 15);
            txtTenDangNhap.Margin = new Padding(3, 4, 3, 4);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(320, 29);
            txtTenDangNhap.TabIndex = 0;
            // 
            // lblTenDangNhap
            // 
            lblTenDangNhap.AutoSize = true;
            lblTenDangNhap.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblTenDangNhap.ForeColor = Color.Gray;
            lblTenDangNhap.Location = new Point(80, 188);
            lblTenDangNhap.Name = "lblTenDangNhap";
            lblTenDangNhap.Size = new Size(124, 23);
            lblTenDangNhap.TabIndex = 2;
            lblTenDangNhap.Text = "Tên đăng nhập";
            // 
            // lblLoginHeader
            // 
            lblLoginHeader.AutoSize = true;
            lblLoginHeader.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblLoginHeader.ForeColor = Color.FromArgb(0, 83, 166);
            lblLoginHeader.Location = new Point(75, 75);
            lblLoginHeader.Name = "lblLoginHeader";
            lblLoginHeader.Size = new Size(350, 46);
            lblLoginHeader.TabIndex = 0;
            lblLoginHeader.Text = "Chào mừng quay lại!";
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(900, 688);
            Controls.Add(panelRightLogin);
            Controls.Add(panelLeftBrand);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SE LAB Login";
            Load += frmLogin_Load;
            panelLeftBrand.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            panelRightLogin.ResumeLayout(false);
            panelRightLogin.PerformLayout();
            panelPassword.ResumeLayout(false);
            panelPassword.PerformLayout();
            panelUsername.ResumeLayout(false);
            panelUsername.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLeftBrand;
        private System.Windows.Forms.Panel panelRightLogin;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblLoginHeader;
        private System.Windows.Forms.Panel panelUsername;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.Label lblTenDangNhap;
        private System.Windows.Forms.Panel panelPassword;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnDangNhap;
    }
}