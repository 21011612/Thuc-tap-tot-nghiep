using System;
using System.Drawing;
using System.Windows.Forms;
using SELAB.DAL;
using SELAB.Models;

namespace SELAB
{
    public partial class frmQuanLyLichDat : Form
    {
        private readonly LichDatDAL dal = new LichDatDAL();
        private NguoiDung currentUser;

        public frmQuanLyLichDat(NguoiDung user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void frmQuanLyLichDat_Load(object sender, EventArgs e)
        {
            LoadComboThietBi();
            LoadDataGrid();
            SetupDateFormat();
            ToMauBang();
            PhanQuyen();

            dgvLichDat.CellClick += dgvLichDat_CellClick;
            dgvLichDat.CellFormatting += dgvLichDat_CellFormatting;   // ← Thêm dòng này
        }

        private void PhanQuyen()
        {
            bool isSinhVien = currentUser.VaiTro == "Sinh viên";
            btnDuyet.Visible = !isSinhVien;
            btnHuy.Visible = !isSinhVien;
            btnXoa.Visible = currentUser.VaiTro == "Admin";
        }

        private void LoadComboThietBi()
        {
            cboThietBi.DataSource = dal.GetThietBiSanSang();
            cboThietBi.DisplayMember = "TenTB";
            cboThietBi.ValueMember = "MaTB";
        }

        private void LoadDataGrid()
        {
            dgvLichDat.DataSource = (currentUser.VaiTro == "Sinh viên")
                ? dal.GetLichDatByNguoiDung(currentUser.MaND)
                : dal.GetAllLichDat();
        }

        private void SetupDateFormat()
        {
            // Chỉ format cột Ngày
            if (dgvLichDat.Columns["NgayDat"] != null)
            {
                dgvLichDat.Columns["NgayDat"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvLichDat.Columns["NgayDat"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void ToMauBang()
        {
            dgvLichDat.EnableHeadersVisualStyles = false;
            dgvLichDat.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 128, 185);
            dgvLichDat.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvLichDat.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dgvLichDat.RowsDefaultCellStyle.BackColor = Color.White;
            dgvLichDat.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);
            dgvLichDat.DefaultCellStyle.SelectionBackColor = Color.FromArgb(26, 188, 156);
            dgvLichDat.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvLichDat.RowHeadersVisible = false;

            if (dgvLichDat.Columns["MaLich"] != null)
                dgvLichDat.Columns["MaLich"].Visible = false;
        }

        // ====================== CELL FORMATTING - HIỂN THỊ GIỜ ĐẸP HH:mm ======================
        private void dgvLichDat_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Format cột Thời gian
            if (e.Value != null && e.Value != DBNull.Value)
            {
                string colName = dgvLichDat.Columns[e.ColumnIndex].Name;

                if (colName == "ThoiGianBatDau" || colName == "ThoiGianKetThuc")
                {
                    if (e.Value is TimeSpan ts)
                    {
                        e.Value = ts.ToString(@"hh\:mm");
                        e.FormattingApplied = true;
                    }
                }
            }

            // Format màu Trạng thái
            if (dgvLichDat.Columns[e.ColumnIndex].Name == "TrangThaiLich" && e.Value != null)
            {
                string tt = e.Value.ToString();
                e.CellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                switch (tt)
                {
                    case "Chờ duyệt": e.CellStyle.ForeColor = Color.FromArgb(243, 156, 18); break;
                    case "Đã duyệt": e.CellStyle.ForeColor = Color.FromArgb(39, 174, 96); break;
                    case "Hủy": e.CellStyle.ForeColor = Color.FromArgb(192, 57, 43); break;
                }
            }
        }

        // ====================== CLICK DÒNG → LOAD DỮ LIỆU LÊN Ô NHẬP ======================
        private void dgvLichDat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvLichDat.Rows[e.RowIndex];

            cboThietBi.Text = row.Cells["TenTB"].Value.ToString();
            dtpNgayDat.Value = Convert.ToDateTime(row.Cells["NgayDat"].Value);

            if (row.Cells["ThoiGianBatDau"].Value != DBNull.Value)
                dtpBatDau.Value = DateTime.Today.Add((TimeSpan)row.Cells["ThoiGianBatDau"].Value);

            if (row.Cells["ThoiGianKetThuc"].Value != DBNull.Value)
                dtpKetThuc.Value = DateTime.Today.Add((TimeSpan)row.Cells["ThoiGianKetThuc"].Value);

            txtLyDo.Text = row.Cells["LyDo"].Value?.ToString() ?? "";
        }

        private void btnDatLich_Click(object sender, EventArgs e)
        {
            if (cboThietBi.SelectedValue == null || string.IsNullOrEmpty(txtLyDo.Text.Trim()))
            {
                MessageBox.Show("Vui lòng chọn thiết bị và nhập lý do!");
                return;
            }

            LichDat ld = new LichDat
            {
                MaTB = (int)cboThietBi.SelectedValue,
                MaND = currentUser.MaND,
                NgayDat = dtpNgayDat.Value,
                ThoiGianBatDau = dtpBatDau.Value.TimeOfDay,
                ThoiGianKetThuc = dtpKetThuc.Value.TimeOfDay,
                LyDo = txtLyDo.Text.Trim()
            };

            if (dal.ThemLichDat(ld))
            {
                MessageBox.Show("Đặt lịch thành công!\nTrạng thái: Chờ duyệt", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGrid();
                ClearForm();
            }
        }

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            if (dgvLichDat.CurrentRow == null) return;
            int maLich = Convert.ToInt32(dgvLichDat.CurrentRow.Cells["MaLich"].Value);
            if (dal.DuyetLichDat(maLich))
            {
                MessageBox.Show("Duyệt lịch thành công!");
                LoadDataGrid();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (dgvLichDat.CurrentRow == null) return;
            int maLich = Convert.ToInt32(dgvLichDat.CurrentRow.Cells["MaLich"].Value);
            if (dal.HuyLichDat(maLich))
            {
                MessageBox.Show("Đã hủy lịch!");
                LoadDataGrid();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvLichDat.CurrentRow == null) return;
            if (MessageBox.Show("Xóa lịch này vĩnh viễn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                int maLich = Convert.ToInt32(dgvLichDat.CurrentRow.Cells["MaLich"].Value);
                if (dal.XoaLichDat(maLich))
                {
                    MessageBox.Show("Xóa thành công!");
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
            txtLyDo.Clear();
            if (cboThietBi.Items.Count > 0) cboThietBi.SelectedIndex = 0;
        }
    }
}