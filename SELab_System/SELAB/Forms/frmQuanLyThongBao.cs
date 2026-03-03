using SELAB.DAL;
using SELAB.Models;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SELAB
{
    public partial class frmQuanLyThongBao : Form
    {
        private readonly ThongBaoDAL dal = new ThongBaoDAL();
        private NguoiDung currentUser;

        public frmQuanLyThongBao(NguoiDung user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void frmQuanLyThongBao_Load(object sender, EventArgs e)
        {
            LoadComboNguoiNhan();
            LoadDataGrid();
            SetupDateFormat();      // ← Định dạng dd/MM/yyyy
            ToMauBang();
            PhanQuyen();

            dgvThongBao.CellClick += dgvThongBao_CellClick;
        }

        // ====================== ĐỊNH DẠNG NGÀY dd/MM/yyyy ======================
        private void SetupDateFormat()
        {
            if (dgvThongBao.Columns["NgayGui"] != null)
            {
                dgvThongBao.Columns["NgayGui"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dgvThongBao.Columns["NgayGui"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void PhanQuyen()
        {
            bool isSinhVien = currentUser.VaiTro == "Sinh viên";
            btnGui.Visible = !isSinhVien;
            btnXoa.Visible = !isSinhVien;
            btnDaDoc.Visible = isSinhVien;
        }

        private void LoadComboNguoiNhan()
        {
            DataTable dt = dal.GetNguoiDungCombo();

            DataRow row = dt.NewRow();
            row["MaND"] = 0;
            row["HoTen"] = "Gửi cho tất cả";
            dt.Rows.InsertAt(row, 0);

            cboNguoiNhan.DataSource = dt;
            cboNguoiNhan.DisplayMember = "HoTen";
            cboNguoiNhan.ValueMember = "MaND";
            cboNguoiNhan.SelectedIndex = 0;
        }

        private void LoadDataGrid()
        {
            dgvThongBao.DataSource = (currentUser.VaiTro == "Sinh viên")
                ? dal.GetThongBaoByNguoiDung(currentUser.MaND)
                : dal.GetAllThongBao();
        }

        private void ToMauBang()
        {
            dgvThongBao.EnableHeadersVisualStyles = false;
            dgvThongBao.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 128, 185);
            dgvThongBao.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvThongBao.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dgvThongBao.RowsDefaultCellStyle.BackColor = Color.White;
            dgvThongBao.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);
            dgvThongBao.DefaultCellStyle.SelectionBackColor = Color.FromArgb(26, 188, 156);
            dgvThongBao.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvThongBao.RowHeadersVisible = false;

            if (dgvThongBao.Columns["MaTBao"] != null) dgvThongBao.Columns["MaTBao"].Visible = false;
            if (dgvThongBao.Columns["MaND"] != null) dgvThongBao.Columns["MaND"].Visible = false;
        }

        private void dgvThongBao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvThongBao.Rows[e.RowIndex];

            txtTieuDe.Text = row.Cells["TieuDe"].Value.ToString();
            txtNoiDung.Text = row.Cells["NoiDung"].Value.ToString();
        }

        private void btnGui_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTieuDe.Text) || string.IsNullOrEmpty(txtNoiDung.Text))
            {
                MessageBox.Show("Vui lòng nhập tiêu đề và nội dung!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ThongBao tb = new ThongBao
            {
                MaND = currentUser.MaND,
                TieuDe = txtTieuDe.Text.Trim(),
                NoiDung = txtNoiDung.Text.Trim()
            };

            if (dal.ThemThongBao(tb))
            {
                MessageBox.Show("Gửi thông báo thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGrid();
                ClearForm();
            }
        }

        private void btnDaDoc_Click(object sender, EventArgs e)
        {
            if (dgvThongBao.CurrentRow == null) return;
            int maTBao = Convert.ToInt32(dgvThongBao.CurrentRow.Cells["MaTBao"].Value);

            if (dal.DanhDauDaDoc(maTBao))
            {
                LoadDataGrid();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvThongBao.CurrentRow == null) return;
            if (MessageBox.Show("Xóa thông báo này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int maTBao = Convert.ToInt32(dgvThongBao.CurrentRow.Cells["MaTBao"].Value);
                if (dal.XoaThongBao(maTBao))
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadDataGrid();
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
            txtTieuDe.Clear();
            txtNoiDung.Clear();
            cboNguoiNhan.SelectedIndex = 0;
        }
    }
}