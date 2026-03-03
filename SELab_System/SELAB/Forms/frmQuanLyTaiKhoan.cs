using System;
using System.Drawing;
using System.Windows.Forms;
using SELAB.DAL;
using SELAB.Models;

namespace SELAB
{
    public partial class frmQuanLyTaiKhoan : Form
    {
        private readonly NguoiDungDAL dal = new NguoiDungDAL();
        private NguoiDung currentUser;
        private string currentMSSV_MaGV = "";

        public frmQuanLyTaiKhoan(NguoiDung user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void frmQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            if (currentUser.VaiTro == "Sinh viên")
            {
                MessageBox.Show("Sinh viên không có quyền quản lý tài khoản!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }
            LoadDataGrid();
            ToMauBang();
            PhanQuyen();
            cboVaiTro.SelectedIndex = 0;
            dgvTaiKhoan.CellClick += dgvTaiKhoan_CellClick;
        }

        private void PhanQuyen()
        {
            btnThem.Visible = currentUser.VaiTro == "Admin";
            btnSua.Visible = true;
            btnXoa.Visible = currentUser.VaiTro == "Admin";
            btnResetMK.Visible = currentUser.VaiTro == "Admin";
        }

        private void LoadDataGrid()
        {
            dgvTaiKhoan.DataSource = dal.GetAllNguoiDung();
            FormatDataGrid();
        }

        private void FormatDataGrid()
        {
            if (dgvTaiKhoan.Columns.Count == 0) return;
            dgvTaiKhoan.Columns["MaND"].Visible = false;
            dgvTaiKhoan.Columns["MSSV_MaGV"].Visible = false;
            dgvTaiKhoan.Columns["HoTen"].HeaderText = "Họ và tên";
            dgvTaiKhoan.Columns["TenDangNhap"].HeaderText = "Tên đăng nhập";
            dgvTaiKhoan.Columns["VaiTro"].HeaderText = "Vai trò";
            dgvTaiKhoan.Columns["Email"].HeaderText = "Email";
            dgvTaiKhoan.Columns["SoDienThoai"].HeaderText = "Số điện thoại";
            dgvTaiKhoan.Columns["HoTen"].Width = 180;
            dgvTaiKhoan.Columns["TenDangNhap"].Width = 130;
            dgvTaiKhoan.Columns["VaiTro"].Width = 100;
            dgvTaiKhoan.Columns["Email"].Width = 220;
            dgvTaiKhoan.Columns["SoDienThoai"].Width = 120;
        }

        private void ToMauBang()
        {
            dgvTaiKhoan.EnableHeadersVisualStyles = false;
            dgvTaiKhoan.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 128, 185);
            dgvTaiKhoan.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvTaiKhoan.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvTaiKhoan.RowsDefaultCellStyle.BackColor = Color.White;
            dgvTaiKhoan.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);
            dgvTaiKhoan.DefaultCellStyle.SelectionBackColor = Color.FromArgb(26, 188, 156);
            dgvTaiKhoan.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvTaiKhoan.RowHeadersVisible = false;
        }

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvTaiKhoan.Rows[e.RowIndex];
            txtHoTen.Text = row.Cells["HoTen"].Value?.ToString() ?? "";
            txtTenDangNhap.Text = row.Cells["TenDangNhap"].Value?.ToString() ?? "";
            cboVaiTro.Text = row.Cells["VaiTro"].Value?.ToString() ?? "";
            txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";
            txtSoDienThoai.Text = row.Cells["SoDienThoai"].Value?.ToString() ?? "";
            currentMSSV_MaGV = row.Cells["MSSV_MaGV"]?.Value?.ToString() ?? "";
            txtMatKhau.Clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text) || string.IsNullOrWhiteSpace(txtTenDangNhap.Text) || string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Họ tên, Tên đăng nhập và Mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenDN = txtTenDangNhap.Text.Trim();
            string email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim();
            string mssv = currentMSSV_MaGV;

            if (dal.IsTenDangNhapTonTai(tenDN))
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại!", "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
                txtTenDangNhap.SelectAll();
                return;
            }

            if (!string.IsNullOrEmpty(email) && dal.IsEmailTonTai(email))
            {
                MessageBox.Show("Email đã tồn tại!", "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                txtEmail.SelectAll();
                return;
            }

            if (!string.IsNullOrEmpty(mssv) && dal.IsMSSVTonTai(mssv))
            {
                MessageBox.Show("MSSV / Mã GV đã tồn tại!", "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NguoiDung nd = new NguoiDung
            {
                HoTen = txtHoTen.Text.Trim(),
                TenDangNhap = tenDN,
                MatKhau = txtMatKhau.Text.Trim(),
                VaiTro = cboVaiTro.Text,
                Email = email,
                SoDienThoai = string.IsNullOrEmpty(txtSoDienThoai.Text) ? null : txtSoDienThoai.Text.Trim(),
                MSSV_MaGV = mssv
            };

            if (dal.ThemNguoiDung(nd))
            {
                MessageBox.Show("Thêm tài khoản thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGrid();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.CurrentRow == null) return;

            int maND = Convert.ToInt32(dgvTaiKhoan.CurrentRow.Cells["MaND"].Value);
            string tenDN = txtTenDangNhap.Text.Trim();
            string email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim();
            string mssv = currentMSSV_MaGV;

            if (dal.IsTenDangNhapTonTai(tenDN, maND))
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại!", "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
                txtTenDangNhap.SelectAll();
                return;
            }

            if (!string.IsNullOrEmpty(email) && dal.IsEmailTonTai(email, maND))
            {
                MessageBox.Show("Email đã tồn tại!", "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                txtEmail.SelectAll();
                return;
            }

            if (!string.IsNullOrEmpty(mssv) && dal.IsMSSVTonTai(mssv, maND))
            {
                MessageBox.Show("MSSV / Mã GV đã tồn tại!", "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string matKhauMoi = string.IsNullOrWhiteSpace(txtMatKhau.Text) ? null : txtMatKhau.Text.Trim();

            NguoiDung nd = new NguoiDung
            {
                MaND = maND,
                HoTen = txtHoTen.Text.Trim(),
                TenDangNhap = tenDN,
                VaiTro = cboVaiTro.Text,
                Email = email,
                SoDienThoai = string.IsNullOrEmpty(txtSoDienThoai.Text) ? null : txtSoDienThoai.Text.Trim(),
                MSSV_MaGV = mssv
            };

            bool success = dal.SuaNguoiDung(nd, matKhauMoi);
            if (success)
            {
                string msg = "Cập nhật thông tin thành công!";
                if (!string.IsNullOrEmpty(matKhauMoi))
                    msg += "\n\nMật khẩu đã được cập nhật mới.";
                MessageBox.Show(msg, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGrid();
                txtMatKhau.Clear();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.CurrentRow == null) return;
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                int maND = Convert.ToInt32(dgvTaiKhoan.CurrentRow.Cells["MaND"].Value);
                if (dal.XoaNguoiDung(maND))
                {
                    MessageBox.Show("Xóa tài khoản thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGrid();
                    ClearForm();
                }
            }
        }

        private void btnResetMK_Click(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một tài khoản để reset mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string tenDN = dgvTaiKhoan.CurrentRow.Cells["TenDangNhap"].Value?.ToString() ?? "";
            int maND = Convert.ToInt32(dgvTaiKhoan.CurrentRow.Cells["MaND"].Value);
            if (MessageBox.Show($"Reset mật khẩu của '{tenDN}' về mặc định '123'?\n", "Xác nhận Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (dal.DoiMatKhau(maND, "123"))
                {
                    MessageBox.Show($"RESET THÀNH CÔNG!\n\nTài khoản: {tenDN}\nMật khẩu mới: 123\n\n", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGrid();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Reset thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txtHoTen.Clear();
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            txtEmail.Clear();
            txtSoDienThoai.Clear();
            cboVaiTro.SelectedIndex = 0;
            currentMSSV_MaGV = "";
        }
    }
}