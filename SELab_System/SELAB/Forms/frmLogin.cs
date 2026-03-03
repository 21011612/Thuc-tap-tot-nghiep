using System;
using System.Drawing;
using System.Windows.Forms;
using SELAB.DAL;
using SELAB.Models;

namespace SELAB
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                pictureBoxLogo.ImageLocation = @"D:\SELab_System\SELAB\images\logo.png";
                pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch
            {
                MessageBox.Show("Không tìm thấy file logo!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string user = txtTenDangNhap.Text.Trim();
            string pass = txtMatKhau.Text.Trim();

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataAccess dal = new DataAccess();
            NguoiDung nd = dal.CheckLogin(user, pass);

            if (nd != null)
            {
                MessageBox.Show($"Đăng nhập thành công!\nChào {nd.HoTen} ({nd.VaiTro})",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmMain mainForm = new frmMain(nd);   // Truyền thông tin người dùng từ CSDL
                mainForm.Show();

                this.Hide();   // Ẩn form Login (không đóng hẳn để tránh lỗi khi đăng xuất)
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhau.Clear();
                txtMatKhau.Focus();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}