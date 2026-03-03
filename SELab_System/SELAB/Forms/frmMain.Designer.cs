namespace SELAB
{
    partial class frmMain
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

        private void InitializeComponent()
        {
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.btnTaiKhoan = new System.Windows.Forms.Button();
            this.btnBaoTri = new System.Windows.Forms.Button();
            this.btnLichDat = new System.Windows.Forms.Button();
            this.btnThietBi = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnLichSu = new System.Windows.Forms.Button();
            this.btnThongBao = new System.Windows.Forms.Button();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.btnToggle = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();

            this.pnlSidebar.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();

            // pnlSidebar
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(30, 58, 138);
            this.pnlSidebar.Controls.Add(this.btnThongBao);
            this.pnlSidebar.Controls.Add(this.btnLichSu);
            this.pnlSidebar.Controls.Add(this.btnTaiKhoan);
            this.pnlSidebar.Controls.Add(this.btnBaoTri);
            this.pnlSidebar.Controls.Add(this.btnLichDat);
            this.pnlSidebar.Controls.Add(this.btnThietBi);
            this.pnlSidebar.Controls.Add(this.btnDashboard);
            this.pnlSidebar.Controls.Add(this.pnlLogo);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(260, 850);
            this.pnlSidebar.TabIndex = 0;

            // pnlLogo
            this.pnlLogo.Controls.Add(this.btnToggle);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(260, 70);
            this.pnlLogo.TabIndex = 8;

            // btnToggle
            this.btnToggle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToggle.FlatAppearance.BorderSize = 0;
            this.btnToggle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(29, 78, 216);
            this.btnToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnToggle.ForeColor = System.Drawing.Color.White;
            this.btnToggle.Location = new System.Drawing.Point(10, 10);
            this.btnToggle.Name = "btnToggle";
            this.btnToggle.Size = new System.Drawing.Size(45, 45);
            this.btnToggle.TabIndex = 0;
            this.btnToggle.Text = "☰";
            this.btnToggle.UseVisualStyleBackColor = true;
            this.btnToggle.Click += new System.EventHandler(this.btnToggle_Click);

            // Hàm cấu hình nút Menu
            void ConfigureMenuButton(System.Windows.Forms.Button btn, string text, int yPos)
            {
                btn.BackColor = System.Drawing.Color.Transparent;
                btn.Cursor = System.Windows.Forms.Cursors.Hand;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(23, 37, 84);
                btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(29, 78, 216);
                btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btn.Font = new System.Drawing.Font("Segoe UI", 11F);
                btn.ForeColor = System.Drawing.Color.White;
                btn.Location = new System.Drawing.Point(0, yPos);
                btn.Name = btn.Name;
                btn.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
                btn.Size = new System.Drawing.Size(260, 60);
                btn.Text = text;
                btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                btn.UseVisualStyleBackColor = false;
            }

            ConfigureMenuButton(this.btnDashboard, "   🏠   Dashboard", 70);
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);

            ConfigureMenuButton(this.btnThietBi, "   🖥️   Quản lý Thiết Bị", 130);
            this.btnThietBi.Click += new System.EventHandler(this.btnThietBi_Click);

            ConfigureMenuButton(this.btnLichDat, "   📅   Quản lý Lịch Đặt", 190);
            this.btnLichDat.Click += new System.EventHandler(this.btnLichDat_Click);

            ConfigureMenuButton(this.btnBaoTri, "   🔧   Lịch Bảo Trì", 250);
            this.btnBaoTri.Click += new System.EventHandler(this.btnBaoTri_Click);

            ConfigureMenuButton(this.btnLichSu, "   📜   Lịch sử sử dụng", 310);
            this.btnLichSu.Click += new System.EventHandler(this.btnLichSu_Click);

            ConfigureMenuButton(this.btnThongBao, "   🛎️   Thông báo", 370);
            this.btnThongBao.Click += new System.EventHandler(this.btnThongBao_Click);

            ConfigureMenuButton(this.btnTaiKhoan, "   👤   Tài Khoản", 430);
            this.btnTaiKhoan.Click += new System.EventHandler(this.btnTaiKhoan_Click);

            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(30, 58, 138);
            this.pnlHeader.Controls.Add(this.lblUser);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(260, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1236, 70);
            this.pnlHeader.TabIndex = 1;

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(25, 17);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(387, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "HỆ THỐNG QUẢN LÝ SE LAB";

            this.lblUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblUser.ForeColor = System.Drawing.Color.White;
            this.lblUser.Location = new System.Drawing.Point(820, 23);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(390, 25);
            this.lblUser.TabIndex = 1;
            this.lblUser.Text = "👤 Xin chào: Đang tải...";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUser.Click += new System.EventHandler(this.lblUser_Click);

            // pnlMain
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(243, 244, 246);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(260, 70);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(20);
            this.pnlMain.Size = new System.Drawing.Size(1236, 780);
            this.pnlMain.TabIndex = 2;

            // frmMain
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1496, 850);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSidebar);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SE LAB Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);

            this.pnlSidebar.ResumeLayout(false);
            this.pnlLogo.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
        }

        // Controls
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnThietBi;
        private System.Windows.Forms.Button btnLichDat;
        private System.Windows.Forms.Button btnBaoTri;
        private System.Windows.Forms.Button btnTaiKhoan;
        private System.Windows.Forms.Button btnLichSu;
        private System.Windows.Forms.Button btnThongBao;
        private System.Windows.Forms.Button btnToggle;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Panel pnlMain;
    }
}