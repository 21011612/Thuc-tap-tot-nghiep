using System.Drawing;
using System.Windows.Forms;

namespace SELAB
{
    partial class frmQuanLyThietBi
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
            txtMaTB = new TextBox();
            txtTenTB = new TextBox();
            txtSerialNumber = new TextBox();
            cboLoai = new ComboBox();
            cboTrangThai = new ComboBox();
            txtViTri = new TextBox();
            dtpNgayNhap = new DateTimePicker();
            dtpBaoHanh = new DateTimePicker();
            txtMoTa = new TextBox();
            lblMaTB = new Label();
            lblTenTB = new Label();
            lblSerial = new Label();
            lblLoai = new Label();
            lblTrangThai = new Label();
            lblViTri = new Label();
            lblNgayNhap = new Label();
            lblBaoHanh = new Label();
            lblMoTa = new Label();
            flowLayoutPanelNut = new FlowLayoutPanel();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            txtTimKiem = new TextBox();
            btnTimKiem = new Button();
            dgvThietBi = new DataGridView();
            groupBoxThongTin.SuspendLayout();
            flowLayoutPanelNut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvThietBi).BeginInit();
            SuspendLayout();

            groupBoxThongTin.Controls.Add(lblMaTB);
            groupBoxThongTin.Controls.Add(txtMaTB);
            groupBoxThongTin.Controls.Add(lblSerial);
            groupBoxThongTin.Controls.Add(txtSerialNumber);
            groupBoxThongTin.Controls.Add(lblTenTB);
            groupBoxThongTin.Controls.Add(txtTenTB);
            groupBoxThongTin.Controls.Add(lblTrangThai);
            groupBoxThongTin.Controls.Add(cboTrangThai);
            groupBoxThongTin.Controls.Add(lblLoai);
            groupBoxThongTin.Controls.Add(cboLoai);
            groupBoxThongTin.Controls.Add(lblNgayNhap);
            groupBoxThongTin.Controls.Add(dtpNgayNhap);
            groupBoxThongTin.Controls.Add(lblViTri);
            groupBoxThongTin.Controls.Add(txtViTri);
            groupBoxThongTin.Controls.Add(lblBaoHanh);
            groupBoxThongTin.Controls.Add(dtpBaoHanh);
            groupBoxThongTin.Controls.Add(lblMoTa);
            groupBoxThongTin.Controls.Add(txtMoTa);
            groupBoxThongTin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxThongTin.Location = new Point(20, 20);
            groupBoxThongTin.Name = "groupBoxThongTin";
            groupBoxThongTin.Size = new Size(940, 240);
            groupBoxThongTin.TabIndex = 0;
            groupBoxThongTin.TabStop = false;
            groupBoxThongTin.Text = "Thông tin thiết bị";

            lblMaTB.AutoSize = true;
            lblMaTB.Font = new Font("Segoe UI", 10F);
            lblMaTB.Location = new Point(30, 40);
            lblMaTB.Name = "lblMaTB";
            lblMaTB.Text = "Mã TB:";

            txtMaTB.Font = new Font("Segoe UI", 10F);
            txtMaTB.Location = new Point(140, 37);
            txtMaTB.Name = "txtMaTB";
            txtMaTB.Size = new Size(280, 30);
            txtMaTB.TabIndex = 1;

            lblSerial.AutoSize = true;
            lblSerial.Font = new Font("Segoe UI", 10F);
            lblSerial.Location = new Point(480, 40);
            lblSerial.Name = "lblSerial";
            lblSerial.Text = "Serial Number:";

            txtSerialNumber.Font = new Font("Segoe UI", 10F);
            txtSerialNumber.Location = new Point(600, 37);
            txtSerialNumber.Name = "txtSerialNumber";
            txtSerialNumber.Size = new Size(300, 30);
            txtSerialNumber.TabIndex = 2;

            lblTenTB.AutoSize = true;
            lblTenTB.Font = new Font("Segoe UI", 10F);
            lblTenTB.Location = new Point(30, 80);
            lblTenTB.Name = "lblTenTB";
            lblTenTB.Text = "Tên thiết bị:";

            txtTenTB.Font = new Font("Segoe UI", 10F);
            txtTenTB.Location = new Point(140, 77);
            txtTenTB.Name = "txtTenTB";
            txtTenTB.Size = new Size(280, 30);
            txtTenTB.TabIndex = 3;

            lblTrangThai.AutoSize = true;
            lblTrangThai.Font = new Font("Segoe UI", 10F);
            lblTrangThai.Location = new Point(480, 80);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Text = "Trạng thái:";

            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.Font = new Font("Segoe UI", 10F);
            cboTrangThai.Location = new Point(600, 77);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(300, 31);
            cboTrangThai.TabIndex = 4;

            lblLoai.AutoSize = true;
            lblLoai.Font = new Font("Segoe UI", 10F);
            lblLoai.Location = new Point(30, 120);
            lblLoai.Name = "lblLoai";
            lblLoai.Text = "Loại thiết bị:";

            cboLoai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoai.Font = new Font("Segoe UI", 10F);
            cboLoai.Location = new Point(140, 117);
            cboLoai.Name = "cboLoai";
            cboLoai.Size = new Size(280, 31);
            cboLoai.TabIndex = 5;

            lblNgayNhap.AutoSize = true;
            lblNgayNhap.Font = new Font("Segoe UI", 10F);
            lblNgayNhap.Location = new Point(480, 120);
            lblNgayNhap.Name = "lblNgayNhap";
            lblNgayNhap.Text = "Ngày nhập:";

            dtpNgayNhap.Font = new Font("Segoe UI", 10F);
            dtpNgayNhap.Format = DateTimePickerFormat.Short;
            dtpNgayNhap.Location = new Point(600, 117);
            dtpNgayNhap.Name = "dtpNgayNhap";
            dtpNgayNhap.Size = new Size(300, 30);
            dtpNgayNhap.TabIndex = 6;

            lblViTri.AutoSize = true;
            lblViTri.Font = new Font("Segoe UI", 10F);
            lblViTri.Location = new Point(30, 160);
            lblViTri.Name = "lblViTri";
            lblViTri.Text = "Vị trí:";

            txtViTri.Font = new Font("Segoe UI", 10F);
            txtViTri.Location = new Point(140, 157);
            txtViTri.Name = "txtViTri";
            txtViTri.Size = new Size(280, 30);
            txtViTri.TabIndex = 7;

            lblBaoHanh.AutoSize = true;
            lblBaoHanh.Font = new Font("Segoe UI", 10F);
            lblBaoHanh.Location = new Point(480, 160);
            lblBaoHanh.Name = "lblBaoHanh";
            lblBaoHanh.Text = "Bảo hành đến:";

            dtpBaoHanh.Font = new Font("Segoe UI", 10F);
            dtpBaoHanh.Format = DateTimePickerFormat.Short;
            dtpBaoHanh.Location = new Point(600, 157);
            dtpBaoHanh.Name = "dtpBaoHanh";
            dtpBaoHanh.Size = new Size(300, 30);
            dtpBaoHanh.TabIndex = 8;

            lblMoTa.AutoSize = true;
            lblMoTa.Font = new Font("Segoe UI", 10F);
            lblMoTa.Location = new Point(30, 200);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Text = "Mô tả:";

            txtMoTa.Font = new Font("Segoe UI", 10F);
            txtMoTa.Location = new Point(140, 197);
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(760, 30);
            txtMoTa.TabIndex = 9;

            flowLayoutPanelNut.Controls.Add(btnThem);
            flowLayoutPanelNut.Controls.Add(btnSua);
            flowLayoutPanelNut.Controls.Add(btnXoa);
            flowLayoutPanelNut.Controls.Add(btnLamMoi);
            flowLayoutPanelNut.Controls.Add(txtTimKiem);
            flowLayoutPanelNut.Controls.Add(btnTimKiem);
            flowLayoutPanelNut.Location = new Point(20, 275);
            flowLayoutPanelNut.Name = "flowLayoutPanelNut";
            flowLayoutPanelNut.Size = new Size(940, 55);
            flowLayoutPanelNut.TabIndex = 1;

            btnThem.BackColor = Color.FromArgb(52, 152, 219);
            btnThem.Cursor = Cursors.Hand;
            btnThem.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(5, 5);
            btnThem.Margin = new Padding(5);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(110, 45);
            btnThem.TabIndex = 0;
            btnThem.Text = "➕ Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;

            btnSua.BackColor = Color.FromArgb(46, 204, 113);
            btnSua.Cursor = Cursors.Hand;
            btnSua.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(125, 5);
            btnSua.Margin = new Padding(5);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(110, 45);
            btnSua.TabIndex = 1;
            btnSua.Text = "✏️ Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;

            btnXoa.BackColor = Color.FromArgb(231, 76, 60);
            btnXoa.Cursor = Cursors.Hand;
            btnXoa.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(245, 5);
            btnXoa.Margin = new Padding(5);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(110, 45);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "🗑️ Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;

            btnLamMoi.BackColor = Color.FromArgb(149, 165, 166);
            btnLamMoi.Cursor = Cursors.Hand;
            btnLamMoi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.Location = new Point(365, 5);
            btnLamMoi.Margin = new Padding(5);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(125, 45);
            btnLamMoi.TabIndex = 3;
            btnLamMoi.Text = "🔄 Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;

            txtTimKiem.Font = new Font("Segoe UI", 10F);
            txtTimKiem.Location = new Point(515, 12);
            txtTimKiem.Margin = new Padding(20, 12, 5, 5);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Nhập tên thiết bị hoặc serial...";
            txtTimKiem.Size = new Size(260, 30);
            txtTimKiem.TabIndex = 4;

            btnTimKiem.BackColor = Color.FromArgb(241, 196, 15);
            btnTimKiem.Cursor = Cursors.Hand;
            btnTimKiem.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(785, 5);
            btnTimKiem.Margin = new Padding(5);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(130, 45);
            btnTimKiem.TabIndex = 5;
            btnTimKiem.Text = "🔍 Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;

            dgvThietBi.AllowUserToAddRows = false;
            dgvThietBi.AllowUserToDeleteRows = false;
            dgvThietBi.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvThietBi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvThietBi.BackgroundColor = Color.WhiteSmoke;
            dgvThietBi.ColumnHeadersHeight = 35;
            dgvThietBi.Location = new Point(20, 345);
            dgvThietBi.Name = "dgvThietBi";
            dgvThietBi.ReadOnly = true;
            dgvThietBi.RowHeadersWidth = 51;
            dgvThietBi.RowTemplate.Height = 30;
            dgvThietBi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvThietBi.Size = new Size(940, 400);
            dgvThietBi.TabIndex = 2;
            dgvThietBi.CellClick += dgvThietBi_CellClick;
            dgvThietBi.CellFormatting += dgvThietBi_CellFormatting;

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 246, 250);
            ClientSize = new Size(982, 763);
            Controls.Add(groupBoxThongTin);
            Controls.Add(flowLayoutPanelNut);
            Controls.Add(dgvThietBi);
            Name = "frmQuanLyThietBi";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Thiết Bị - SE LAB";
            Load += frmQuanLyThietBi_Load;
            groupBoxThongTin.ResumeLayout(false);
            groupBoxThongTin.PerformLayout();
            flowLayoutPanelNut.ResumeLayout(false);
            flowLayoutPanelNut.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvThietBi).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.GroupBox groupBoxThongTin;
        private System.Windows.Forms.TextBox txtMaTB, txtTenTB, txtSerialNumber, txtViTri, txtMoTa, txtTimKiem;
        private System.Windows.Forms.ComboBox cboLoai, cboTrangThai;
        private System.Windows.Forms.DateTimePicker dtpNgayNhap, dtpBaoHanh;
        private System.Windows.Forms.Label lblMaTB, lblTenTB, lblSerial, lblLoai, lblTrangThai, lblViTri, lblNgayNhap, lblBaoHanh, lblMoTa;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelNut;
        private System.Windows.Forms.Button btnThem, btnSua, btnXoa, btnLamMoi, btnTimKiem;
        private System.Windows.Forms.DataGridView dgvThietBi;
    }
}