using System.Drawing;
using System.Windows.Forms;

namespace SELAB
{
    partial class frmQuanLyThongBao
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
            cboNguoiNhan = new ComboBox();
            txtTieuDe = new TextBox();
            txtNoiDung = new TextBox();
            lblNguoiNhan = new Label();
            lblTieuDe = new Label();
            lblNoiDung = new Label();
            flowLayoutPanelNut = new FlowLayoutPanel();
            btnGui = new Button();
            btnDaDoc = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            dgvThongBao = new DataGridView();

            groupBoxThongTin.SuspendLayout();
            flowLayoutPanelNut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvThongBao).BeginInit();
            SuspendLayout();

            // groupBoxThongTin
            groupBoxThongTin.Controls.Add(lblNguoiNhan);
            groupBoxThongTin.Controls.Add(cboNguoiNhan);
            groupBoxThongTin.Controls.Add(lblTieuDe);
            groupBoxThongTin.Controls.Add(txtTieuDe);
            groupBoxThongTin.Controls.Add(lblNoiDung);
            groupBoxThongTin.Controls.Add(txtNoiDung);
            groupBoxThongTin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxThongTin.Location = new Point(20, 20);
            groupBoxThongTin.Name = "groupBoxThongTin";
            groupBoxThongTin.Size = new Size(940, 200);
            groupBoxThongTin.TabIndex = 0;
            groupBoxThongTin.TabStop = false;
            groupBoxThongTin.Text = "Soạn thông báo mới";

            lblNguoiNhan.AutoSize = true; lblNguoiNhan.Font = new Font("Segoe UI", 10F); lblNguoiNhan.Location = new Point(30, 35); lblNguoiNhan.Text = "Người nhận:";
            cboNguoiNhan.DropDownStyle = ComboBoxStyle.DropDownList; cboNguoiNhan.Font = new Font("Segoe UI", 10F); cboNguoiNhan.Location = new Point(140, 32); cboNguoiNhan.Size = new Size(380, 31);

            lblTieuDe.AutoSize = true; lblTieuDe.Font = new Font("Segoe UI", 10F); lblTieuDe.Location = new Point(540, 35); lblTieuDe.Text = "Tiêu đề:";
            txtTieuDe.Font = new Font("Segoe UI", 10F); txtTieuDe.Location = new Point(650, 32); txtTieuDe.Size = new Size(260, 30);

            lblNoiDung.AutoSize = true; lblNoiDung.Font = new Font("Segoe UI", 10F); lblNoiDung.Location = new Point(30, 75); lblNoiDung.Text = "Nội dung:";
            txtNoiDung.Font = new Font("Segoe UI", 10F); txtNoiDung.Location = new Point(140, 72); txtNoiDung.Multiline = true; txtNoiDung.Size = new Size(760, 90);

            // flowLayoutPanelNut
            flowLayoutPanelNut.Controls.Add(btnGui);
            flowLayoutPanelNut.Controls.Add(btnDaDoc);
            flowLayoutPanelNut.Controls.Add(btnXoa);
            flowLayoutPanelNut.Controls.Add(btnLamMoi);
            flowLayoutPanelNut.Location = new Point(20, 235);
            flowLayoutPanelNut.Size = new Size(940, 55);

            btnGui.BackColor = Color.FromArgb(52, 152, 219); btnGui.Text = "📤 Gửi"; btnGui.Size = new Size(130, 45); btnGui.Click += btnGui_Click;
            btnDaDoc.BackColor = Color.FromArgb(46, 204, 113); btnDaDoc.Text = "✅ Đánh dấu đã đọc"; btnDaDoc.Size = new Size(180, 45); btnDaDoc.Click += btnDaDoc_Click;
            btnXoa.BackColor = Color.FromArgb(231, 76, 60); btnXoa.Text = "🗑️ Xóa"; btnXoa.Size = new Size(110, 45); btnXoa.Click += btnXoa_Click;
            btnLamMoi.BackColor = Color.FromArgb(149, 165, 166); btnLamMoi.Text = "🔄 Làm mới"; btnLamMoi.Size = new Size(130, 45); btnLamMoi.Click += btnLamMoi_Click;

            // dgvThongBao
            dgvThongBao.AllowUserToAddRows = false;
            dgvThongBao.AllowUserToDeleteRows = false;
            dgvThongBao.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvThongBao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvThongBao.BackgroundColor = Color.WhiteSmoke;
            dgvThongBao.ColumnHeadersHeight = 35;
            dgvThongBao.Location = new Point(20, 305);
            dgvThongBao.Name = "dgvThongBao";
            dgvThongBao.ReadOnly = true;
            dgvThongBao.RowHeadersWidth = 51;
            dgvThongBao.RowTemplate.Height = 30;
            dgvThongBao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvThongBao.Size = new Size(940, 440);
            dgvThongBao.TabIndex = 2;

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 246, 250);
            ClientSize = new Size(982, 763);
            Controls.Add(groupBoxThongTin);
            Controls.Add(flowLayoutPanelNut);
            Controls.Add(dgvThongBao);
            Name = "frmQuanLyThongBao";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Thông Báo - SE Lab";
            Load += frmQuanLyThongBao_Load;

            groupBoxThongTin.ResumeLayout(false);
            groupBoxThongTin.PerformLayout();
            flowLayoutPanelNut.ResumeLayout(false);
            flowLayoutPanelNut.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvThongBao).EndInit();
            ResumeLayout(false);
        }

        private GroupBox groupBoxThongTin;
        private ComboBox cboNguoiNhan;
        private TextBox txtTieuDe, txtNoiDung;
        private Label lblNguoiNhan, lblTieuDe, lblNoiDung;
        private FlowLayoutPanel flowLayoutPanelNut;
        private Button btnGui, btnDaDoc, btnXoa, btnLamMoi;
        private DataGridView dgvThongBao;
    }
}