using System;
using System.Drawing;
using System.Windows.Forms;
using SELAB.DAL;
using SELAB.Models;

namespace SELAB
{
    public partial class frmQuanLyLichSuSuDung : Form
    {
        private readonly LichSuSuDungDAL dal = new LichSuSuDungDAL();
        private NguoiDung currentUser;

        public frmQuanLyLichSuSuDung(NguoiDung user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void frmQuanLyLichSuSuDung_Load(object sender, EventArgs e)
        {
            if (currentUser.VaiTro == "Sinh viên")
            {
                // ẨN TOÀN BỘ PHẦN NHẬP LIỆU
                groupBoxThongTin.Visible = false;
                flowLayoutPanelNut.Visible = false;

                // Điều chỉnh bảng chiếm toàn bộ không gian
                dgvLichSu.Location = new Point(20, 20);
                dgvLichSu.Size = new Size(940, 700);   // điều chỉnh chiều cao phù hợp
            }

            LoadComboThietBi();
            LoadComboNguoiDung();
            LoadDataGrid();
            SetupDateFormat();
            ToMauBang();
            PhanQuyen();

            dgvLichSu.CellClick += dgvLichSu_CellClick;
        }

        private void PhanQuyen()
        {
            bool isSinhVien = currentUser.VaiTro == "Sinh viên";
            btnThem.Visible = !isSinhVien;
            btnSua.Visible = !isSinhVien;
            btnXoa.Visible = currentUser.VaiTro == "Admin";
        }

        private void LoadComboThietBi()
        {
            cboThietBi.DataSource = dal.GetThietBiCombo();
            cboThietBi.DisplayMember = "TenTB";
            cboThietBi.ValueMember = "MaTB";
        }

        private void LoadComboNguoiDung()
        {
            cboNguoiDung.DataSource = dal.GetNguoiDungCombo();
            cboNguoiDung.DisplayMember = "HoTen";
            cboNguoiDung.ValueMember = "MaND";
        }

        private void LoadDataGrid()
        {
            dgvLichSu.DataSource = (currentUser.VaiTro == "Sinh viên")
                ? dal.GetLichSuByNguoiDung(currentUser.MaND)
                : dal.GetAllLichSu();
        }

        private void SetupDateFormat()
        {
            if (dgvLichSu.Columns["NgayBatDau"] != null)
            {
                dgvLichSu.Columns["NgayBatDau"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dgvLichSu.Columns["NgayBatDau"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvLichSu.Columns["NgayKetThuc"] != null)
            {
                dgvLichSu.Columns["NgayKetThuc"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dgvLichSu.Columns["NgayKetThuc"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void ToMauBang()
        {
            dgvLichSu.EnableHeadersVisualStyles = false;
            dgvLichSu.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 128, 185);
            dgvLichSu.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvLichSu.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dgvLichSu.RowsDefaultCellStyle.BackColor = Color.White;
            dgvLichSu.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);
            dgvLichSu.DefaultCellStyle.SelectionBackColor = Color.FromArgb(26, 188, 156);
            dgvLichSu.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvLichSu.RowHeadersVisible = false;

            if (dgvLichSu.Columns["MaTB"] != null) dgvLichSu.Columns["MaTB"].Visible = false;
            if (dgvLichSu.Columns["MaND"] != null) dgvLichSu.Columns["MaND"].Visible = false;
        }

        private void dgvLichSu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvLichSu.Rows[e.RowIndex];

            cboThietBi.SelectedValue = Convert.ToInt32(row.Cells["MaTB"].Value);
            cboNguoiDung.SelectedValue = Convert.ToInt32(row.Cells["MaND"].Value);
            dtpNgayBatDau.Value = Convert.ToDateTime(row.Cells["NgayBatDau"].Value);

            if (row.Cells["NgayKetThuc"].Value != DBNull.Value)
                dtpNgayKetThuc.Value = Convert.ToDateTime(row.Cells["NgayKetThuc"].Value);
            else
                dtpNgayKetThuc.Value = DateTime.Now;

            txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString() ?? "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cboThietBi.SelectedValue == null || cboNguoiDung.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn thiết bị và người dùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LichSuSuDung ls = new LichSuSuDung
            {
                MaTB = (int)cboThietBi.SelectedValue,
                MaND = (int)cboNguoiDung.SelectedValue,
                NgayBatDau = dtpNgayBatDau.Value,
                NgayKetThuc = dtpNgayKetThuc.Checked ? dtpNgayKetThuc.Value : (DateTime?)null,
                GhiChu = txtGhiChu.Text.Trim()
            };

            if (dal.ThemLichSu(ls))
            {
                MessageBox.Show("Thêm lịch sử sử dụng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGrid();
                ClearForm();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvLichSu.CurrentRow == null) return;

            LichSuSuDung ls = new LichSuSuDung
            {
                MaLichSu = Convert.ToInt32(dgvLichSu.CurrentRow.Cells["MaLichSu"].Value),
                MaTB = (int)cboThietBi.SelectedValue,
                MaND = (int)cboNguoiDung.SelectedValue,
                NgayBatDau = dtpNgayBatDau.Value,
                NgayKetThuc = dtpNgayKetThuc.Checked ? dtpNgayKetThuc.Value : (DateTime?)null,
                GhiChu = txtGhiChu.Text.Trim()
            };

            if (dal.SuaLichSu(ls))
            {
                MessageBox.Show("Cập nhật thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGrid();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvLichSu.CurrentRow == null) return;
            if (MessageBox.Show("Xóa lịch sử này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int maLichSu = Convert.ToInt32(dgvLichSu.CurrentRow.Cells["MaLichSu"].Value);
                if (dal.XoaLichSu(maLichSu))
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
            txtGhiChu.Clear();
            if (cboThietBi.Items.Count > 0) cboThietBi.SelectedIndex = 0;
            if (cboNguoiDung.Items.Count > 0) cboNguoiDung.SelectedIndex = 0;
        }
    }
}