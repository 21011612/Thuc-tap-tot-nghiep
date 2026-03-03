using System.Drawing;
using System.Windows.Forms;

namespace SELAB
{
    partial class frmQuanLyTaiKhoan
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            groupBoxThongTin = new GroupBox();
            txtHoTen = new TextBox();
            txtTenDangNhap = new TextBox();
            txtMatKhau = new TextBox();
            cboVaiTro = new ComboBox();
            txtEmail = new TextBox();
            txtSoDienThoai = new TextBox();
            lblHoTen = new Label();
            lblTenDangNhap = new Label();
            lblMatKhau = new Label();
            lblVaiTro = new Label();
            lblEmail = new Label();
            lblSoDienThoai = new Label();
            flowLayoutPanelNut = new FlowLayoutPanel();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnResetMK = new Button();
            btnLamMoi = new Button();
            dgvTaiKhoan = new DataGridView();

            groupBoxThongTin.SuspendLayout();
            flowLayoutPanelNut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTaiKhoan).BeginInit();
            SuspendLayout();

            // groupBoxThongTin
            groupBoxThongTin.Controls.Add(lblHoTen);
            groupBoxThongTin.Controls.Add(txtHoTen);
            groupBoxThongTin.Controls.Add(lblTenDangNhap);
            groupBoxThongTin.Controls.Add(txtTenDangNhap);
            groupBoxThongTin.Controls.Add(lblMatKhau);
            groupBoxThongTin.Controls.Add(txtMatKhau);
            groupBoxThongTin.Controls.Add(lblVaiTro);
            groupBoxThongTin.Controls.Add(cboVaiTro);
            groupBoxThongTin.Controls.Add(lblEmail);
            groupBoxThongTin.Controls.Add(txtEmail);
            groupBoxThongTin.Controls.Add(lblSoDienThoai);
            groupBoxThongTin.Controls.Add(txtSoDienThoai);
            groupBoxThongTin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxThongTin.Location = new Point(20, 20);
            groupBoxThongTin.Name = "groupBoxThongTin";
            groupBoxThongTin.Size = new Size(940, 200);
            groupBoxThongTin.TabIndex = 0;
            groupBoxThongTin.TabStop = false;
            groupBoxThongTin.Text = "Thông tin tài khoản";

            lblHoTen.AutoSize = true; lblHoTen.Font = new Font("Segoe UI", 10F); lblHoTen.Location = new Point(30, 35); lblHoTen.Text = "Họ tên:";
            txtHoTen.Font = new Font("Segoe UI", 10F); txtHoTen.Location = new Point(140, 32); txtHoTen.Size = new Size(280, 30); txtHoTen.TabIndex = 1;

            lblTenDangNhap.AutoSize = true; lblTenDangNhap.Font = new Font("Segoe UI", 10F); lblTenDangNhap.Location = new Point(480, 35); lblTenDangNhap.Text = "Tên đăng nhập:";
            txtTenDangNhap.Font = new Font("Segoe UI", 10F); txtTenDangNhap.Location = new Point(620, 32); txtTenDangNhap.Size = new Size(280, 30); txtTenDangNhap.TabIndex = 2;

            lblMatKhau.AutoSize = true; lblMatKhau.Font = new Font("Segoe UI", 10F); lblMatKhau.Location = new Point(30, 75); lblMatKhau.Text = "Mật khẩu:";
            txtMatKhau.Font = new Font("Segoe UI", 10F); txtMatKhau.Location = new Point(140, 72); txtMatKhau.Size = new Size(280, 30); txtMatKhau.PasswordChar = '•'; txtMatKhau.TabIndex = 3;

            lblVaiTro.AutoSize = true; lblVaiTro.Font = new Font("Segoe UI", 10F); lblVaiTro.Location = new Point(480, 75); lblVaiTro.Text = "Vai trò:";
            cboVaiTro.DropDownStyle = ComboBoxStyle.DropDownList; cboVaiTro.Font = new Font("Segoe UI", 10F); cboVaiTro.Location = new Point(620, 72); cboVaiTro.Size = new Size(280, 31); cboVaiTro.TabIndex = 4;
            cboVaiTro.Items.AddRange(new string[] { "Sinh viên", "Giảng viên", "Admin" });

            lblEmail.AutoSize = true; lblEmail.Font = new Font("Segoe UI", 10F); lblEmail.Location = new Point(30, 115); lblEmail.Text = "Email:";
            txtEmail.Font = new Font("Segoe UI", 10F); txtEmail.Location = new Point(140, 112); txtEmail.Size = new Size(280, 30); txtEmail.TabIndex = 5;

            lblSoDienThoai.AutoSize = true; lblSoDienThoai.Font = new Font("Segoe UI", 10F); lblSoDienThoai.Location = new Point(480, 115); lblSoDienThoai.Text = "Số điện thoại:";
            txtSoDienThoai.Font = new Font("Segoe UI", 10F); txtSoDienThoai.Location = new Point(620, 112); txtSoDienThoai.Size = new Size(280, 30); txtSoDienThoai.TabIndex = 6;

            // flowLayoutPanelNut
            flowLayoutPanelNut.Controls.Add(btnThem);
            flowLayoutPanelNut.Controls.Add(btnSua);
            flowLayoutPanelNut.Controls.Add(btnXoa);
            flowLayoutPanelNut.Controls.Add(btnResetMK);
            flowLayoutPanelNut.Controls.Add(btnLamMoi);
            flowLayoutPanelNut.Location = new Point(20, 235);
            flowLayoutPanelNut.Name = "flowLayoutPanelNut";
            flowLayoutPanelNut.Size = new Size(940, 55);
            flowLayoutPanelNut.TabIndex = 1;

            btnThem.BackColor = Color.FromArgb(52, 152, 219); btnThem.Cursor = Cursors.Hand; btnThem.Font = new Font("Segoe UI", 10F, FontStyle.Bold); btnThem.ForeColor = Color.White; btnThem.Location = new Point(5, 5); btnThem.Margin = new Padding(5); btnThem.Name = "btnThem"; btnThem.Size = new Size(130, 45); btnThem.TabIndex = 0; btnThem.Text = "➕ Thêm"; btnThem.UseVisualStyleBackColor = false; btnThem.Click += btnThem_Click;
            btnSua.BackColor = Color.FromArgb(46, 204, 113); btnSua.Cursor = Cursors.Hand; btnSua.Font = new Font("Segoe UI", 10F, FontStyle.Bold); btnSua.ForeColor = Color.White; btnSua.Location = new Point(145, 5); btnSua.Margin = new Padding(5); btnSua.Name = "btnSua"; btnSua.Size = new Size(130, 45); btnSua.TabIndex = 1; btnSua.Text = "✏️ Sửa"; btnSua.UseVisualStyleBackColor = false; btnSua.Click += btnSua_Click;
            btnXoa.BackColor = Color.FromArgb(231, 76, 60); btnXoa.Cursor = Cursors.Hand; btnXoa.Font = new Font("Segoe UI", 10F, FontStyle.Bold); btnXoa.ForeColor = Color.White; btnXoa.Location = new Point(285, 5); btnXoa.Margin = new Padding(5); btnXoa.Name = "btnXoa"; btnXoa.Size = new Size(110, 45); btnXoa.TabIndex = 2; btnXoa.Text = "🗑️ Xóa"; btnXoa.UseVisualStyleBackColor = false; btnXoa.Click += btnXoa_Click;
            btnResetMK.BackColor = Color.FromArgb(243, 156, 18); btnResetMK.Cursor = Cursors.Hand; btnResetMK.Font = new Font("Segoe UI", 10F, FontStyle.Bold); btnResetMK.ForeColor = Color.White; btnResetMK.Location = new Point(405, 5); btnResetMK.Margin = new Padding(5); btnResetMK.Name = "btnResetMK"; btnResetMK.Size = new Size(160, 45); btnResetMK.TabIndex = 3; btnResetMK.Text = "🔑 Reset MK"; btnResetMK.UseVisualStyleBackColor = false; btnResetMK.Click += btnResetMK_Click;
            btnLamMoi.BackColor = Color.FromArgb(149, 165, 166); btnLamMoi.Cursor = Cursors.Hand; btnLamMoi.Font = new Font("Segoe UI", 10F, FontStyle.Bold); btnLamMoi.ForeColor = Color.White; btnLamMoi.Location = new Point(575, 5); btnLamMoi.Margin = new Padding(5); btnLamMoi.Name = "btnLamMoi"; btnLamMoi.Size = new Size(130, 45); btnLamMoi.TabIndex = 4; btnLamMoi.Text = "🔄 Làm mới"; btnLamMoi.UseVisualStyleBackColor = false; btnLamMoi.Click += btnLamMoi_Click;

            // dgvTaiKhoan
            dgvTaiKhoan.AllowUserToAddRows = false;
            dgvTaiKhoan.AllowUserToDeleteRows = false;
            dgvTaiKhoan.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTaiKhoan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTaiKhoan.BackgroundColor = Color.WhiteSmoke;
            dgvTaiKhoan.ColumnHeadersHeight = 35;
            dgvTaiKhoan.Location = new Point(20, 305);
            dgvTaiKhoan.Name = "dgvTaiKhoan";
            dgvTaiKhoan.ReadOnly = true;
            dgvTaiKhoan.RowHeadersWidth = 51;
            dgvTaiKhoan.RowTemplate.Height = 30;
            dgvTaiKhoan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTaiKhoan.Size = new Size(940, 440);
            dgvTaiKhoan.TabIndex = 2;

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 246, 250);
            ClientSize = new Size(982, 763);
            Controls.Add(groupBoxThongTin);
            Controls.Add(flowLayoutPanelNut);
            Controls.Add(dgvTaiKhoan);
            Name = "frmQuanLyTaiKhoan";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Tài Khoản - SE Lab";
            Load += frmQuanLyTaiKhoan_Load;

            groupBoxThongTin.ResumeLayout(false);
            groupBoxThongTin.PerformLayout();
            flowLayoutPanelNut.ResumeLayout(false);
            flowLayoutPanelNut.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTaiKhoan).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.GroupBox groupBoxThongTin;
        private System.Windows.Forms.TextBox txtHoTen, txtTenDangNhap, txtMatKhau, txtEmail, txtSoDienThoai;
        private System.Windows.Forms.ComboBox cboVaiTro;
        private System.Windows.Forms.Label lblHoTen, lblTenDangNhap, lblMatKhau, lblVaiTro, lblEmail, lblSoDienThoai;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelNut;
        private System.Windows.Forms.Button btnThem, btnSua, btnXoa, btnResetMK, btnLamMoi;
        private System.Windows.Forms.DataGridView dgvTaiKhoan;
    }
}