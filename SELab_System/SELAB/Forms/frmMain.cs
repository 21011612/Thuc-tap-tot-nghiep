using System;
using System.Drawing;
using System.Windows.Forms;
using SELAB.Models;

namespace SELAB
{
    public partial class frmMain : Form
    {
        private NguoiDung currentUser;
        private bool sidebarExpanded = true;
        private readonly int sidebarExpandedWidth = 260;
        private readonly int sidebarCollapsedWidth = 65;

        // Biến lưu form con đang mở
        private Form activeForm = null;

        // Biến lưu nút menu đang active (highlight)
        private Button currentActiveButton = null;

        public frmMain(NguoiDung user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (currentUser != null)
            {
                lblUser.Text = $"👤 Xin chào: {currentUser.HoTen} ({currentUser.VaiTro})";

                // ====================== PHÂN QUYỀN ======================
                if (currentUser.VaiTro == "Sinh viên")
                {
                    btnThietBi.Visible = false;
                    btnBaoTri.Visible = false;
                    btnTaiKhoan.Visible = false;

                    btnLichDat.Location = new Point(0, 130);
                    btnLichSu.Location = new Point(0, 190);
                    btnThongBao.Location = new Point(0, 250);
                }
                else
                {
                    btnThietBi.Visible = true;
                    btnBaoTri.Visible = true;
                    btnTaiKhoan.Visible = true;
                    btnLichSu.Visible = true;
                    btnThongBao.Visible = true;
                }

                btnDashboard.Visible = true;
                btnLichDat.Visible = true;

                // Tự động mở Dashboard và highlight nút Dashboard
                OpenChildForm(new frmThongKe());
                HighlightButton(btnDashboard);
            }
        }

        // ====================== HIGHLIGHT NÚT ĐANG CHỌN ======================
        private void HighlightButton(Button selectedBtn)
        {
            // Reset tất cả nút về màu gốc
            ResetAllButtons();

            if (selectedBtn != null)
            {
                currentActiveButton = selectedBtn;
                selectedBtn.BackColor = Color.FromArgb(52, 152, 219);   // Xanh dương nổi bật
                selectedBtn.ForeColor = Color.White;
                selectedBtn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            }
        }

        private void ResetAllButtons()
        {
            Button[] allButtons = { btnDashboard, btnThietBi, btnLichDat, btnBaoTri,
                                   btnLichSu, btnThongBao, btnTaiKhoan };

            foreach (var btn in allButtons)
            {
                if (btn != null && btn.Visible)
                {
                    btn.BackColor = Color.Transparent;
                    btn.ForeColor = Color.White;
                    btn.Font = new Font("Segoe UI", 11F);
                }
            }
        }

        // ====================== HÀM NHÚNG FORM CON ======================
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            pnlMain.Controls.Add(childForm);
            pnlMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        // ====================== ĐĂNG XUẤT ======================
        private void lblUser_Click(object sender, EventArgs e) => XyLyDangXuat();

        private void XyLyDangXuat()
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                new frmLogin().Show();
            }
        }

        // ====================== THU GỌN / MỞ RỘNG SIDEBAR ======================
        private void btnToggle_Click(object sender, EventArgs e)
        {
            if (sidebarExpanded)
            {
                pnlSidebar.Width = sidebarCollapsedWidth;
                sidebarExpanded = false;

                btnDashboard.Text = " 🏠";
                btnThietBi.Text = btnThietBi.Visible ? " 🖥️" : "";
                btnLichDat.Text = " 📅";
                btnBaoTri.Text = btnBaoTri.Visible ? " 🔧" : "";
                btnLichSu.Text = " 📜";
                btnThongBao.Text = " 🛎️";
                btnTaiKhoan.Text = btnTaiKhoan.Visible ? " 👤" : "";
            }
            else
            {
                pnlSidebar.Width = sidebarExpandedWidth;
                sidebarExpanded = true;

                btnDashboard.Text = " 🏠 Dashboard";
                btnThietBi.Text = btnThietBi.Visible ? " 🖥️ Quản lý Thiết Bị" : "";
                btnLichDat.Text = " 📅 Quản lý Lịch Đặt";
                btnBaoTri.Text = btnBaoTri.Visible ? " 🔧 Lịch Bảo Trì" : "";
                btnLichSu.Text = " 📜 Lịch sử sử dụng";
                btnThongBao.Text = " 🛎️ Thông báo";
                btnTaiKhoan.Text = btnTaiKhoan.Visible ? " 👤 Tài Khoản" : "";
            }

            // Giữ highlight sau khi thu gọn/mở rộng
            if (currentActiveButton != null)
            {
                HighlightButton(currentActiveButton);
            }
        }

        // ====================== SỰ KIỆN CLICK NÚT ======================
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmThongKe());
            HighlightButton(btnDashboard);
        }

        private void btnThietBi_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmQuanLyThietBi(currentUser));
            HighlightButton(btnThietBi);
        }

        private void btnLichDat_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmQuanLyLichDat(currentUser));
            HighlightButton(btnLichDat);
        }

        private void btnBaoTri_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmQuanLyLichBaoTri(currentUser));
            HighlightButton(btnBaoTri);
        }

        private void btnLichSu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmQuanLyLichSuSuDung(currentUser));
            HighlightButton(btnLichSu);
        }

        private void btnThongBao_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmQuanLyThongBao(currentUser));
            HighlightButton(btnThongBao);
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmQuanLyTaiKhoan(currentUser));
            HighlightButton(btnTaiKhoan);
        }
    }
}