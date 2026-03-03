using System.Drawing;
using System.Windows.Forms;

namespace SELAB
{
    partial class frmQuanLyLichSuSuDung
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
            lblThietBi = new Label();
            cboThietBi = new ComboBox();
            lblNguoiDung = new Label();
            cboNguoiDung = new ComboBox();
            lblNgayBatDau = new Label();
            dtpNgayBatDau = new DateTimePicker();
            lblNgayKetThuc = new Label();
            dtpNgayKetThuc = new DateTimePicker();
            lblGhiChu = new Label();
            txtGhiChu = new TextBox();
            flowLayoutPanelNut = new FlowLayoutPanel();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            dgvLichSu = new DataGridView();
            groupBoxThongTin.SuspendLayout();
            flowLayoutPanelNut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLichSu).BeginInit();
            SuspendLayout();
            // 
            // groupBoxThongTin
            // 
            groupBoxThongTin.Controls.Add(lblThietBi);
            groupBoxThongTin.Controls.Add(cboThietBi);
            groupBoxThongTin.Controls.Add(lblNguoiDung);
            groupBoxThongTin.Controls.Add(cboNguoiDung);
            groupBoxThongTin.Controls.Add(lblNgayBatDau);
            groupBoxThongTin.Controls.Add(dtpNgayBatDau);
            groupBoxThongTin.Controls.Add(lblNgayKetThuc);
            groupBoxThongTin.Controls.Add(dtpNgayKetThuc);
            groupBoxThongTin.Controls.Add(lblGhiChu);
            groupBoxThongTin.Controls.Add(txtGhiChu);
            groupBoxThongTin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxThongTin.Location = new Point(20, 20);
            groupBoxThongTin.Name = "groupBoxThongTin";
            groupBoxThongTin.Size = new Size(940, 200);
            groupBoxThongTin.TabIndex = 0;
            groupBoxThongTin.TabStop = false;
            groupBoxThongTin.Text = "Thông tin lịch sử sử dụng";
            // 
            // lblThietBi
            // 
            lblThietBi.AutoSize = true;
            lblThietBi.Font = new Font("Segoe UI", 10F);
            lblThietBi.Location = new Point(30, 35);
            lblThietBi.Name = "lblThietBi";
            lblThietBi.Size = new Size(71, 23);
            lblThietBi.TabIndex = 0;
            lblThietBi.Text = "Thiết bị:";
            // 
            // cboThietBi
            // 
            cboThietBi.DropDownStyle = ComboBoxStyle.DropDownList;
            cboThietBi.Font = new Font("Segoe UI", 10F);
            cboThietBi.Location = new Point(140, 32);
            cboThietBi.Name = "cboThietBi";
            cboThietBi.Size = new Size(380, 31);
            cboThietBi.TabIndex = 1;
            // 
            // lblNguoiDung
            // 
            lblNguoiDung.AutoSize = true;
            lblNguoiDung.Font = new Font("Segoe UI", 10F);
            lblNguoiDung.Location = new Point(540, 35);
            lblNguoiDung.Name = "lblNguoiDung";
            lblNguoiDung.Size = new Size(106, 23);
            lblNguoiDung.TabIndex = 2;
            lblNguoiDung.Text = "Người dùng:";
            // 
            // cboNguoiDung
            // 
            cboNguoiDung.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNguoiDung.Font = new Font("Segoe UI", 10F);
            cboNguoiDung.Location = new Point(650, 32);
            cboNguoiDung.Name = "cboNguoiDung";
            cboNguoiDung.Size = new Size(260, 31);
            cboNguoiDung.TabIndex = 3;
            // 
            // lblNgayBatDau
            // 
            lblNgayBatDau.AutoSize = true;
            lblNgayBatDau.Font = new Font("Segoe UI", 10F);
            lblNgayBatDau.Location = new Point(17, 72);
            lblNgayBatDau.Name = "lblNgayBatDau";
            lblNgayBatDau.Size = new Size(118, 23);
            lblNgayBatDau.TabIndex = 4;
            lblNgayBatDau.Text = "Ngày bắt đầu:";
            // 
            // dtpNgayBatDau
            // 
            dtpNgayBatDau.CustomFormat = "dd/MM/yyyy";
            dtpNgayBatDau.Font = new Font("Segoe UI", 10F);
            dtpNgayBatDau.Format = DateTimePickerFormat.Custom;
            dtpNgayBatDau.Location = new Point(140, 72);
            dtpNgayBatDau.Name = "dtpNgayBatDau";
            dtpNgayBatDau.Size = new Size(200, 30);
            dtpNgayBatDau.TabIndex = 5;
            // 
            // lblNgayKetThuc
            // 
            lblNgayKetThuc.AutoSize = true;
            lblNgayKetThuc.Font = new Font("Segoe UI", 10F);
            lblNgayKetThuc.Location = new Point(380, 75);
            lblNgayKetThuc.Name = "lblNgayKetThuc";
            lblNgayKetThuc.Size = new Size(121, 23);
            lblNgayKetThuc.TabIndex = 6;
            lblNgayKetThuc.Text = "Ngày kết thúc:";
            // 
            // dtpNgayKetThuc
            // 
            dtpNgayKetThuc.CustomFormat = "dd/MM/yyyy";
            dtpNgayKetThuc.Font = new Font("Segoe UI", 10F);
            dtpNgayKetThuc.Format = DateTimePickerFormat.Custom;
            dtpNgayKetThuc.Location = new Point(500, 72);
            dtpNgayKetThuc.Name = "dtpNgayKetThuc";
            dtpNgayKetThuc.Size = new Size(200, 30);
            dtpNgayKetThuc.TabIndex = 7;
            // 
            // lblGhiChu
            // 
            lblGhiChu.AutoSize = true;
            lblGhiChu.Font = new Font("Segoe UI", 10F);
            lblGhiChu.Location = new Point(30, 115);
            lblGhiChu.Name = "lblGhiChu";
            lblGhiChu.Size = new Size(73, 23);
            lblGhiChu.TabIndex = 8;
            lblGhiChu.Text = "Ghi chú:";
            // 
            // txtGhiChu
            // 
            txtGhiChu.Font = new Font("Segoe UI", 10F);
            txtGhiChu.Location = new Point(140, 112);
            txtGhiChu.Multiline = true;
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(760, 60);
            txtGhiChu.TabIndex = 9;
            // 
            // flowLayoutPanelNut
            // 
            flowLayoutPanelNut.Controls.Add(btnThem);
            flowLayoutPanelNut.Controls.Add(btnSua);
            flowLayoutPanelNut.Controls.Add(btnXoa);
            flowLayoutPanelNut.Controls.Add(btnLamMoi);
            flowLayoutPanelNut.Location = new Point(20, 235);
            flowLayoutPanelNut.Name = "flowLayoutPanelNut";
            flowLayoutPanelNut.Size = new Size(940, 55);
            flowLayoutPanelNut.TabIndex = 1;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.FromArgb(52, 152, 219);
            btnThem.Cursor = Cursors.Hand;
            btnThem.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(5, 5);
            btnThem.Margin = new Padding(5);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(130, 45);
            btnThem.TabIndex = 0;
            btnThem.Text = "➕ Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.FromArgb(46, 204, 113);
            btnSua.Cursor = Cursors.Hand;
            btnSua.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(145, 5);
            btnSua.Margin = new Padding(5);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(130, 45);
            btnSua.TabIndex = 1;
            btnSua.Text = "✏️ Cập nhật";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.FromArgb(231, 76, 60);
            btnXoa.Cursor = Cursors.Hand;
            btnXoa.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(285, 5);
            btnXoa.Margin = new Padding(5);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(110, 45);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "🗑️ Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.FromArgb(149, 165, 166);
            btnLamMoi.Cursor = Cursors.Hand;
            btnLamMoi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.Location = new Point(405, 5);
            btnLamMoi.Margin = new Padding(5);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(130, 45);
            btnLamMoi.TabIndex = 3;
            btnLamMoi.Text = "🔄 Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // dgvLichSu
            // 
            dgvLichSu.AllowUserToAddRows = false;
            dgvLichSu.AllowUserToDeleteRows = false;
            dgvLichSu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvLichSu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLichSu.BackgroundColor = Color.WhiteSmoke;
            dgvLichSu.ColumnHeadersHeight = 35;
            dgvLichSu.Location = new Point(20, 305);
            dgvLichSu.Name = "dgvLichSu";
            dgvLichSu.ReadOnly = true;
            dgvLichSu.RowHeadersWidth = 51;
            dgvLichSu.RowTemplate.Height = 30;
            dgvLichSu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLichSu.Size = new Size(940, 440);
            dgvLichSu.TabIndex = 2;
            // 
            // frmQuanLyLichSuSuDung
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 246, 250);
            ClientSize = new Size(982, 763);
            Controls.Add(groupBoxThongTin);
            Controls.Add(flowLayoutPanelNut);
            Controls.Add(dgvLichSu);
            Name = "frmQuanLyLichSuSuDung";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Lịch Sử Sử Dụng - SE Lab";
            Load += frmQuanLyLichSuSuDung_Load;
            groupBoxThongTin.ResumeLayout(false);
            groupBoxThongTin.PerformLayout();
            flowLayoutPanelNut.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLichSu).EndInit();
            ResumeLayout(false);
        }

        private GroupBox groupBoxThongTin;
        private ComboBox cboThietBi, cboNguoiDung;
        private DateTimePicker dtpNgayBatDau, dtpNgayKetThuc;
        private TextBox txtGhiChu;
        private Label lblThietBi, lblNguoiDung, lblNgayBatDau, lblNgayKetThuc, lblGhiChu;
        private FlowLayoutPanel flowLayoutPanelNut;
        private Button btnThem, btnSua, btnXoa, btnLamMoi;
        private DataGridView dgvLichSu;
    }
}