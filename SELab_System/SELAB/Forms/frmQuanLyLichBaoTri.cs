using System;
using System.Drawing;
using System.Windows.Forms;
using SELAB.DAL;
using SELAB.Models;

namespace SELAB
{
    public partial class frmQuanLyLichBaoTri : Form
    {
        private readonly LichBaoTriDAL dal = new LichBaoTriDAL();
        private NguoiDung currentUser;

        public frmQuanLyLichBaoTri(NguoiDung user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void frmQuanLyLichBaoTri_Load(object sender, EventArgs e)
        {
            if (currentUser.VaiTro == "Sinh viên")
            {
                MessageBox.Show("Sinh viên không có quyền truy cập chức năng Lịch Bảo Trì!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            LoadComboThietBi();
            LoadDataGrid();
            SetupDateFormat();      // ← Định dạng dd/MM/yyyy
            ToMauBang();
            PhanQuyen();
            cboTrangThai.SelectedIndex = 0;

            dgvLichBaoTri.CellClick += dgvLichBaoTri_CellClick;
        }

        // ====================== ĐỊNH DẠNG NGÀY dd/MM/yyyy ======================
        private void SetupDateFormat()
        {
            // DateTimePicker
            dtpNgayBaoTri.Format = DateTimePickerFormat.Custom;
            dtpNgayBaoTri.CustomFormat = "dd/MM/yyyy";

            // DataGridView
            if (dgvLichBaoTri.Columns["NgayBaoTri"] != null)
            {
                dgvLichBaoTri.Columns["NgayBaoTri"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvLichBaoTri.Columns["NgayBaoTri"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void PhanQuyen()
        {
            btnThem.Visible = true;
            btnCapNhat.Visible = true;
            btnXoa.Visible = true;
        }

        private void LoadComboThietBi()
        {
            cboThietBi.DataSource = dal.GetThietBiCombo();
            cboThietBi.DisplayMember = "TenTB";
            cboThietBi.ValueMember = "MaTB";
        }

        private void LoadDataGrid()
        {
            dgvLichBaoTri.DataSource = dal.GetAllLichBaoTri();
        }

        private void ToMauBang()
        {
            dgvLichBaoTri.EnableHeadersVisualStyles = false;
            dgvLichBaoTri.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 128, 185);
            dgvLichBaoTri.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvLichBaoTri.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dgvLichBaoTri.RowsDefaultCellStyle.BackColor = Color.White;
            dgvLichBaoTri.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);
            dgvLichBaoTri.DefaultCellStyle.SelectionBackColor = Color.FromArgb(26, 188, 156);
            dgvLichBaoTri.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvLichBaoTri.RowHeadersVisible = false;

            // Ẩn cột MaTB (chỉ dùng nội bộ)
            if (dgvLichBaoTri.Columns["MaTB"] != null)
                dgvLichBaoTri.Columns["MaTB"].Visible = false;
        }

        // ====================== CLICK DÒNG → LOAD DỮ LIỆU LÊN Ô NHẬP ======================
        private void dgvLichBaoTri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvLichBaoTri.Rows[e.RowIndex];

            cboThietBi.SelectedValue = Convert.ToInt32(row.Cells["MaTB"].Value);
            dtpNgayBaoTri.Value = Convert.ToDateTime(row.Cells["NgayBaoTri"].Value);
            txtMoTa.Text = row.Cells["MoTaBaoTri"].Value?.ToString() ?? "";
            cboTrangThai.Text = row.Cells["TrangThaiBT"].Value?.ToString() ?? "Chưa thực hiện";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cboThietBi.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn thiết bị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LichBaoTri lbt = new LichBaoTri
            {
                MaTB = (int)cboThietBi.SelectedValue,
                NgayBaoTri = dtpNgayBaoTri.Value,
                MoTaBaoTri = txtMoTa.Text.Trim(),
                TrangThaiBT = cboTrangThai.Text
            };

            if (dal.ThemLichBaoTri(lbt))
            {
                MessageBox.Show("Thêm lịch bảo trì thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGrid();
                ClearForm();
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (dgvLichBaoTri.CurrentRow == null) return;

            int maBaoTri = Convert.ToInt32(dgvLichBaoTri.CurrentRow.Cells["MaBaoTri"].Value);

            if (dal.CapNhatTrangThai(maBaoTri, cboTrangThai.Text, txtMoTa.Text.Trim()))
            {
                MessageBox.Show("Cập nhật trạng thái thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGrid();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvLichBaoTri.CurrentRow == null) return;
            if (MessageBox.Show("Xóa lịch bảo trì này vĩnh viễn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                int maBaoTri = Convert.ToInt32(dgvLichBaoTri.CurrentRow.Cells["MaBaoTri"].Value);
                if (dal.XoaLichBaoTri(maBaoTri))
                {
                    MessageBox.Show("Xóa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGrid();
                    ClearForm();
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadDataGrid();
            ClearForm();
        }

        private void ClearForm()
        {
            txtMoTa.Clear();
            if (cboThietBi.Items.Count > 0) cboThietBi.SelectedIndex = 0;
            cboTrangThai.SelectedIndex = 0;
        }
    }
}