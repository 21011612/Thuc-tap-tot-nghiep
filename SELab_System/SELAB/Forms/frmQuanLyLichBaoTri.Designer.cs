using System.Drawing;
using System.Windows.Forms;

namespace SELAB
{
    partial class frmQuanLyLichBaoTri
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
            dtpNgayBaoTri = new DateTimePicker();
            txtMoTa = new TextBox();
            cboTrangThai = new ComboBox();
            lblThietBi = new Label();
            lblNgay = new Label();
            lblMoTa = new Label();
            lblTrangThai = new Label();
            flowLayoutPanelNut = new FlowLayoutPanel();
            btnThem = new Button();
            btnCapNhat = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            dgvLichBaoTri = new DataGridView();

            groupBoxThongTin.SuspendLayout();
            flowLayoutPanelNut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLichBaoTri).BeginInit();
            SuspendLayout();

            // groupBoxThongTin
            groupBoxThongTin.Controls.Add(lblThietBi);
            groupBoxThongTin.Controls.Add(cboThietBi);
            groupBoxThongTin.Controls.Add(lblNgay);
            groupBoxThongTin.Controls.Add(dtpNgayBaoTri);
            groupBoxThongTin.Controls.Add(lblMoTa);
            groupBoxThongTin.Controls.Add(txtMoTa);
            groupBoxThongTin.Controls.Add(lblTrangThai);
            groupBoxThongTin.Controls.Add(cboTrangThai);
            groupBoxThongTin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxThongTin.Location = new Point(20, 20);
            groupBoxThongTin.Name = "groupBoxThongTin";
            groupBoxThongTin.Size = new Size(940, 180);
            groupBoxThongTin.TabIndex = 0;
            groupBoxThongTin.TabStop = false;
            groupBoxThongTin.Text = "Thông tin lịch bảo trì";

            lblThietBi.AutoSize = true; lblThietBi.Location = new Point(30, 35); lblThietBi.Text = "Thiết bị:";
            cboThietBi.DropDownStyle = ComboBoxStyle.DropDownList; cboThietBi.Location = new Point(140, 32); cboThietBi.Size = new Size(760, 31);

            lblNgay.AutoSize = true; lblNgay.Location = new Point(30, 75); lblNgay.Text = "Ngày bảo trì:";
            dtpNgayBaoTri.Format = DateTimePickerFormat.Custom; dtpNgayBaoTri.CustomFormat = "dd/MM/yyyy";
            dtpNgayBaoTri.Location = new Point(140, 72); dtpNgayBaoTri.Size = new Size(200, 30);

            lblMoTa.AutoSize = true; lblMoTa.Location = new Point(30, 115); lblMoTa.Text = "Mô tả:";
            txtMoTa.Location = new Point(140, 112); txtMoTa.Size = new Size(760, 50); txtMoTa.Multiline = true;

            lblTrangThai.AutoSize = true; lblTrangThai.Location = new Point(380, 75); lblTrangThai.Text = "Trạng thái:";
            cboTrangThai.Items.AddRange(new string[] { "Chưa thực hiện", "Đã thực hiện" });
            cboTrangThai.Location = new Point(480, 72); cboTrangThai.Size = new Size(200, 31);

            // flowLayoutPanelNut
            flowLayoutPanelNut.Controls.Add(btnThem);
            flowLayoutPanelNut.Controls.Add(btnCapNhat);
            flowLayoutPanelNut.Controls.Add(btnXoa);
            flowLayoutPanelNut.Controls.Add(btnLamMoi);
            flowLayoutPanelNut.Location = new Point(20, 215);
            flowLayoutPanelNut.Size = new Size(940, 55);

            btnThem.BackColor = Color.FromArgb(52, 152, 219); btnThem.Text = "➕ Thêm"; btnThem.Size = new Size(130, 45); btnThem.Click += btnThem_Click;
            btnCapNhat.BackColor = Color.FromArgb(46, 204, 113); btnCapNhat.Text = "✏️ Cập nhật"; btnCapNhat.Size = new Size(130, 45); btnCapNhat.Click += btnCapNhat_Click;
            btnXoa.BackColor = Color.FromArgb(231, 76, 60); btnXoa.Text = "🗑️ Xóa"; btnXoa.Size = new Size(110, 45); btnXoa.Click += btnXoa_Click;
            btnLamMoi.BackColor = Color.FromArgb(149, 165, 166); btnLamMoi.Text = "🔄 Làm mới"; btnLamMoi.Size = new Size(130, 45); btnLamMoi.Click += btnLamMoi_Click;

            // dgvLichBaoTri
            dgvLichBaoTri.AllowUserToAddRows = false;
            dgvLichBaoTri.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvLichBaoTri.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLichBaoTri.Location = new Point(20, 285);
            dgvLichBaoTri.Size = new Size(940, 460);
            dgvLichBaoTri.ReadOnly = true;
            dgvLichBaoTri.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 246, 250);
            ClientSize = new Size(982, 763);
            Controls.Add(groupBoxThongTin);
            Controls.Add(flowLayoutPanelNut);
            Controls.Add(dgvLichBaoTri);
            Name = "frmQuanLyLichBaoTri";
            Text = "Quản Lý Lịch Bảo Trì - SE Lab";
            Load += frmQuanLyLichBaoTri_Load;
            groupBoxThongTin.ResumeLayout(false);
            flowLayoutPanelNut.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLichBaoTri).EndInit();
            ResumeLayout(false);
        }

        private GroupBox groupBoxThongTin;
        private ComboBox cboThietBi, cboTrangThai;
        private DateTimePicker dtpNgayBaoTri;
        private TextBox txtMoTa;
        private Label lblThietBi, lblNgay, lblMoTa, lblTrangThai;
        private FlowLayoutPanel flowLayoutPanelNut;
        private Button btnThem, btnCapNhat, btnXoa, btnLamMoi;
        private DataGridView dgvLichBaoTri;
    }
}