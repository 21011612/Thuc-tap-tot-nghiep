using System;
using System.Drawing;
using System.Windows.Forms;
using SELAB.DAL;
using SELAB.Models;

namespace SELAB
{
    public partial class frmQuanLyThietBi : Form
    {
        private readonly ThietBiDAL dal = new ThietBiDAL();
        private NguoiDung currentUser;

        public frmQuanLyThietBi(NguoiDung user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void frmQuanLyThietBi_Load(object sender, EventArgs e)
        {
            LoadComboLoai();
            LoadDataGrid();
            SetupDateFormat();
            ToMauBang();
            PhânQuyền();
        }

        // ====================== FORMAT NGÀY dd/MM/yyyy ======================
        private void SetupDateFormat()
        {
            dtpNgayNhap.Format = DateTimePickerFormat.Custom;
            dtpNgayNhap.CustomFormat = "dd/MM/yyyy";

            dtpBaoHanh.Format = DateTimePickerFormat.Custom;
            dtpBaoHanh.CustomFormat = "dd/MM/yyyy";

            if (dgvThietBi.Columns["NgayNhap"] != null)
            {
                dgvThietBi.Columns["NgayNhap"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvThietBi.Columns["NgayNhap"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvThietBi.Columns["BaoHanhDen"] != null)
            {
                dgvThietBi.Columns["BaoHanhDen"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvThietBi.Columns["BaoHanhDen"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void LoadComboLoai()
        {
            cboLoai.DataSource = dal.GetLoaiThietBi();
            cboLoai.DisplayMember = "TenLoai";
            cboLoai.ValueMember = "MaLoai";

            cboTrangThai.Items.AddRange(new string[] { "Sẵn sàng", "Đang sử dụng", "Bảo trì", "Hỏng" });
            cboTrangThai.SelectedIndex = 0;
        }

        private void LoadDataGrid()
        {
            dgvThietBi.DataSource = dal.GetAllThietBi();
        }

        private void ToMauBang()
        {
            dgvThietBi.EnableHeadersVisualStyles = false;
            dgvThietBi.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 128, 185);
            dgvThietBi.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvThietBi.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dgvThietBi.RowsDefaultCellStyle.BackColor = Color.White;
            dgvThietBi.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);

            dgvThietBi.DefaultCellStyle.SelectionBackColor = Color.FromArgb(26, 188, 156);
            dgvThietBi.DefaultCellStyle.SelectionForeColor = Color.White;

            // ====================== BỎ Ô DƯ BÊN TRÁI (ROW HEADER) ======================
            dgvThietBi.RowHeadersVisible = false;
        }

        private void PhânQuyền()
        {
            if (currentUser.VaiTro == "Sinh viên")
            {
                btnThem.Visible = false;
                btnSua.Visible = false;
                btnXoa.Visible = false;
            }
            else if (currentUser.VaiTro == "Giảng viên")
            {
                btnXoa.Visible = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaTB.Text) || string.IsNullOrEmpty(txtTenTB.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ mã và tên thiết bị!");
                return;
            }

            try
            {
                ThietBi tb = new ThietBi
                {
                    MaTB = Convert.ToInt32(txtMaTB.Text),
                    TenTB = txtTenTB.Text,
                    MaLoai = (int)cboLoai.SelectedValue,
                    SerialNumber = txtSerialNumber.Text,
                    TrangThai = cboTrangThai.Text,
                    ViTri = txtViTri.Text,
                    NgayNhap = dtpNgayNhap.Value,
                    BaoHanhDen = dtpBaoHanh.Value,
                    MoTa = txtMoTa.Text
                };

                if (dal.ThemThietBi(tb))
                {
                    MessageBox.Show("Thêm thành công!");
                    LoadDataGrid();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvThietBi.CurrentRow == null) return;

            ThietBi tb = new ThietBi
            {
                MaTB = Convert.ToInt32(txtMaTB.Text),
                TenTB = txtTenTB.Text,
                MaLoai = (int)cboLoai.SelectedValue,
                SerialNumber = txtSerialNumber.Text,
                TrangThai = cboTrangThai.Text,
                ViTri = txtViTri.Text,
                NgayNhap = dtpNgayNhap.Value,
                BaoHanhDen = dtpBaoHanh.Value,
                MoTa = txtMoTa.Text
            };

            if (dal.SuaThietBi(tb))
            {
                MessageBox.Show("Sửa thành công!");
                LoadDataGrid();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvThietBi.CurrentRow == null) return;
            if (MessageBox.Show("Xóa thiết bị này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int maTB = Convert.ToInt32(dgvThietBi.CurrentRow.Cells["MaTB"].Value);
                if (dal.XoaThietBi(maTB))
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadDataGrid();
                    ClearForm();
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadDataGrid();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dgvThietBi.DataSource = dal.TimKiemThietBi(txtTimKiem.Text.Trim());
        }

        private void dgvThietBi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvThietBi.Rows[e.RowIndex];

            txtMaTB.Text = row.Cells["MaTB"].Value.ToString();
            txtTenTB.Text = row.Cells["TenTB"].Value.ToString();
            txtSerialNumber.Text = row.Cells["SerialNumber"].Value.ToString();
            cboLoai.Text = row.Cells["TenLoai"].Value.ToString();
            cboTrangThai.Text = row.Cells["TrangThai"].Value.ToString();
            txtViTri.Text = row.Cells["ViTri"].Value.ToString();
            dtpNgayNhap.Value = Convert.ToDateTime(row.Cells["NgayNhap"].Value);
            dtpBaoHanh.Value = Convert.ToDateTime(row.Cells["BaoHanhDen"].Value);
            txtMoTa.Text = row.Cells["MoTa"].Value.ToString();
        }

        private void dgvThietBi_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvThietBi.Columns[e.ColumnIndex].Name == "TrangThai" && e.Value != null)
            {
                string trangThai = e.Value.ToString();

                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                e.CellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);

                switch (trangThai)
                {
                    case "Sẵn sàng":
                        e.CellStyle.ForeColor = Color.FromArgb(39, 174, 96);
                        break;
                    case "Đang sử dụng":
                        e.CellStyle.ForeColor = Color.FromArgb(41, 128, 185);
                        break;
                    case "Bảo trì":
                        e.CellStyle.ForeColor = Color.FromArgb(211, 84, 0);
                        break;
                    case "Hỏng":
                        e.CellStyle.ForeColor = Color.FromArgb(192, 57, 43);
                        break;
                }
            }
        }

        private void ClearForm()
        {
            txtMaTB.Clear();
            txtTenTB.Clear();
            txtSerialNumber.Clear();
            txtViTri.Clear();
            txtMoTa.Clear();
            txtTimKiem.Clear();
            cboTrangThai.SelectedIndex = 0;
        }
    }
}