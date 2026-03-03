using System.Drawing;
using System.Windows.Forms;

namespace SELAB
{
    partial class frmQuanLyLichDat
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
            cboThietBi = new ComboBox();
            dtpNgayDat = new DateTimePicker();
            dtpBatDau = new DateTimePicker();
            dtpKetThuc = new DateTimePicker();
            txtLyDo = new TextBox();
            lblThietBi = new Label();
            lblNgayDat = new Label();
            lblBatDau = new Label();
            lblKetThuc = new Label();
            lblLyDo = new Label();
            flowLayoutPanelNut = new FlowLayoutPanel();
            btnDatLich = new Button();
            btnDuyet = new Button();
            btnHuy = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            dgvLichDat = new DataGridView();

            groupBoxThongTin.SuspendLayout();
            flowLayoutPanelNut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLichDat).BeginInit();
            SuspendLayout();

            // groupBoxThongTin
            groupBoxThongTin.Controls.Add(lblThietBi);
            groupBoxThongTin.Controls.Add(cboThietBi);
            groupBoxThongTin.Controls.Add(lblNgayDat);
            groupBoxThongTin.Controls.Add(dtpNgayDat);
            groupBoxThongTin.Controls.Add(lblBatDau);
            groupBoxThongTin.Controls.Add(dtpBatDau);
            groupBoxThongTin.Controls.Add(lblKetThuc);
            groupBoxThongTin.Controls.Add(dtpKetThuc);
            groupBoxThongTin.Controls.Add(lblLyDo);
            groupBoxThongTin.Controls.Add(txtLyDo);
            groupBoxThongTin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxThongTin.Location = new Point(20, 20);
            groupBoxThongTin.Name = "groupBoxThongTin";
            groupBoxThongTin.Size = new Size(940, 200);
            groupBoxThongTin.TabIndex = 0;
            groupBoxThongTin.TabStop = false;
            groupBoxThongTin.Text = "Đặt lịch thiết bị";

            lblThietBi.AutoSize = true;
            lblThietBi.Font = new Font("Segoe UI", 10F);
            lblThietBi.Location = new Point(30, 35);
            lblThietBi.Name = "lblThietBi";
            lblThietBi.Text = "Thiết bị:";

            cboThietBi.DropDownStyle = ComboBoxStyle.DropDownList;
            cboThietBi.Font = new Font("Segoe UI", 10F);
            cboThietBi.Location = new Point(140, 32);
            cboThietBi.Name = "cboThietBi";
            cboThietBi.Size = new Size(760, 31);
            cboThietBi.TabIndex = 1;

            lblNgayDat.AutoSize = true;
            lblNgayDat.Font = new Font("Segoe UI", 10F);
            lblNgayDat.Location = new Point(30, 75);
            lblNgayDat.Name = "lblNgayDat";
            lblNgayDat.Text = "Ngày đặt:";

            dtpNgayDat.Font = new Font("Segoe UI", 10F);
            dtpNgayDat.Format = DateTimePickerFormat.Custom;
            dtpNgayDat.CustomFormat = "dd/MM/yyyy";
            dtpNgayDat.Location = new Point(140, 72);
            dtpNgayDat.Name = "dtpNgayDat";
            dtpNgayDat.Size = new Size(200, 30);
            dtpNgayDat.TabIndex = 2;

            lblBatDau.AutoSize = true;
            lblBatDau.Font = new Font("Segoe UI", 10F);
            lblBatDau.Location = new Point(380, 75);
            lblBatDau.Name = "lblBatDau";
            lblBatDau.Text = "Từ:";

            dtpBatDau.Font = new Font("Segoe UI", 10F);
            dtpBatDau.Format = DateTimePickerFormat.Custom;
            dtpBatDau.CustomFormat = "HH:mm";
            dtpBatDau.ShowUpDown = true;
            dtpBatDau.Location = new Point(430, 72);
            dtpBatDau.Name = "dtpBatDau";
            dtpBatDau.Size = new Size(120, 30);
            dtpBatDau.TabIndex = 3;

            lblKetThuc.AutoSize = true;
            lblKetThuc.Font = new Font("Segoe UI", 10F);
            lblKetThuc.Location = new Point(580, 75);
            lblKetThuc.Name = "lblKetThuc";
            lblKetThuc.Text = "Đến:";

            dtpKetThuc.Font = new Font("Segoe UI", 10F);
            dtpKetThuc.Format = DateTimePickerFormat.Custom;
            dtpKetThuc.CustomFormat = "HH:mm";
            dtpKetThuc.ShowUpDown = true;
            dtpKetThuc.Location = new Point(630, 72);
            dtpKetThuc.Name = "dtpKetThuc";
            dtpKetThuc.Size = new Size(120, 30);
            dtpKetThuc.TabIndex = 4;

            lblLyDo.AutoSize = true;
            lblLyDo.Font = new Font("Segoe UI", 10F);
            lblLyDo.Location = new Point(30, 115);
            lblLyDo.Name = "lblLyDo";
            lblLyDo.Text = "Lý do:";

            txtLyDo.Font = new Font("Segoe UI", 10F);
            txtLyDo.Location = new Point(140, 112);
            txtLyDo.Multiline = true;
            txtLyDo.Name = "txtLyDo";
            txtLyDo.Size = new Size(760, 60);
            txtLyDo.TabIndex = 5;

            // flowLayoutPanelNut
            flowLayoutPanelNut.Controls.Add(btnDatLich);
            flowLayoutPanelNut.Controls.Add(btnDuyet);
            flowLayoutPanelNut.Controls.Add(btnHuy);
            flowLayoutPanelNut.Controls.Add(btnXoa);
            flowLayoutPanelNut.Controls.Add(btnLamMoi);
            flowLayoutPanelNut.Location = new Point(20, 235);
            flowLayoutPanelNut.Name = "flowLayoutPanelNut";
            flowLayoutPanelNut.Size = new Size(940, 55);
            flowLayoutPanelNut.TabIndex = 1;

            btnDatLich.BackColor = Color.FromArgb(52, 152, 219);
            btnDatLich.Cursor = Cursors.Hand;
            btnDatLich.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDatLich.ForeColor = Color.White;
            btnDatLich.Location = new Point(5, 5);
            btnDatLich.Margin = new Padding(5);
            btnDatLich.Name = "btnDatLich";
            btnDatLich.Size = new Size(130, 45);
            btnDatLich.TabIndex = 0;
            btnDatLich.Text = "📅 Đặt lịch";
            btnDatLich.UseVisualStyleBackColor = false;
            btnDatLich.Click += btnDatLich_Click;

            btnDuyet.BackColor = Color.FromArgb(46, 204, 113);
            btnDuyet.Cursor = Cursors.Hand;
            btnDuyet.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDuyet.ForeColor = Color.White;
            btnDuyet.Location = new Point(145, 5);
            btnDuyet.Margin = new Padding(5);
            btnDuyet.Name = "btnDuyet";
            btnDuyet.Size = new Size(110, 45);
            btnDuyet.TabIndex = 1;
            btnDuyet.Text = "✅ Duyệt";
            btnDuyet.UseVisualStyleBackColor = false;
            btnDuyet.Click += btnDuyet_Click;

            btnHuy.BackColor = Color.FromArgb(243, 156, 18);
            btnHuy.Cursor = Cursors.Hand;
            btnHuy.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnHuy.ForeColor = Color.White;
            btnHuy.Location = new Point(265, 5);
            btnHuy.Margin = new Padding(5);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(110, 45);
            btnHuy.TabIndex = 2;
            btnHuy.Text = "❌ Hủy";
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Click += btnHuy_Click;

            btnXoa.BackColor = Color.FromArgb(231, 76, 60);
            btnXoa.Cursor = Cursors.Hand;
            btnXoa.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(385, 5);
            btnXoa.Margin = new Padding(5);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(110, 45);
            btnXoa.TabIndex = 3;
            btnXoa.Text = "🗑️ Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;

            btnLamMoi.BackColor = Color.FromArgb(149, 165, 166);
            btnLamMoi.Cursor = Cursors.Hand;
            btnLamMoi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.Location = new Point(505, 5);
            btnLamMoi.Margin = new Padding(5);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(125, 45);
            btnLamMoi.TabIndex = 4;
            btnLamMoi.Text = "🔄 Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;

            // dgvLichDat
            dgvLichDat.AllowUserToAddRows = false;
            dgvLichDat.AllowUserToDeleteRows = false;
            dgvLichDat.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvLichDat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLichDat.BackgroundColor = Color.WhiteSmoke;
            dgvLichDat.ColumnHeadersHeight = 35;
            dgvLichDat.Location = new Point(20, 305);
            dgvLichDat.Name = "dgvLichDat";
            dgvLichDat.ReadOnly = true;
            dgvLichDat.RowHeadersWidth = 51;
            dgvLichDat.RowTemplate.Height = 30;
            dgvLichDat.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLichDat.Size = new Size(940, 440);
            dgvLichDat.TabIndex = 2;
            dgvLichDat.CellFormatting += dgvLichDat_CellFormatting;

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 246, 250);
            ClientSize = new Size(982, 763);
            Controls.Add(groupBoxThongTin);
            Controls.Add(flowLayoutPanelNut);
            Controls.Add(dgvLichDat);
            Name = "frmQuanLyLichDat";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Lịch Đặt - SE Lab";
            Load += frmQuanLyLichDat_Load;

            groupBoxThongTin.ResumeLayout(false);
            groupBoxThongTin.PerformLayout();
            flowLayoutPanelNut.ResumeLayout(false);
            flowLayoutPanelNut.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLichDat).EndInit();
            ResumeLayout(false);
        }

        private GroupBox groupBoxThongTin;
        private ComboBox cboThietBi;
        private DateTimePicker dtpNgayDat, dtpBatDau, dtpKetThuc;
        private TextBox txtLyDo;
        private Label lblThietBi, lblNgayDat, lblBatDau, lblKetThuc, lblLyDo;
        private FlowLayoutPanel flowLayoutPanelNut;
        private Button btnDatLich, btnDuyet, btnHuy, btnXoa, btnLamMoi;
        private DataGridView dgvLichDat;
    }
}