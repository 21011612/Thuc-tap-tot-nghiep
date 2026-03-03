using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SELAB.DAL;
using SELAB.Models;

namespace SELAB
{
    public partial class frmThongKe : Form
    {
        private ThongKeDAL thongKeDAL;

        public frmThongKe()
        {
            InitializeComponent();
            thongKeDAL = new ThongKeDAL();
        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            LoadTongQuan();
            LoadBieuDoTrangThai();
            LoadBieuDoLichDat();
        }

        private void LoadTongQuan()
        {
            ThongKeTongQuan data = thongKeDAL.GetThongKeTongQuan();

            lblValTongTB.Text = data.TongThietBi.ToString();
            lblValSanSang.Text = data.ThietBiSanSang.ToString();
            lblValLichDat.Text = data.LichDatMoi.ToString();
            lblValBaoTri.Text = data.DangBaoTri.ToString();
        }

        private void LoadBieuDoTrangThai()
        {
            List<ThongKeTrangThaiThietBi> data = thongKeDAL.GetThongKeTrangThai();
            chartTrangThai.Series["Trạng Thái"].Points.Clear();

            foreach (var item in data)
            {
                chartTrangThai.Series["Trạng Thái"].Points.AddXY(item.TrangThai, item.SoLuong);
            }
        }

        private void LoadBieuDoLichDat()
        {
            List<ThongKeLichDatTheoLoai> data = thongKeDAL.GetThongKeLichDat();
            chartLichDat.Series["Lượt Đặt"].Points.Clear();

            foreach (var item in data)
            {
                chartLichDat.Series["Lượt Đặt"].Points.AddXY(item.TenLoai, item.SoLuotDat);
            }
        }
    }
}