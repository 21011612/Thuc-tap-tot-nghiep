using System;

namespace SELAB.Models
{
    public class ThietBi
    {
        public int MaTB { get; set; }
        public string TenTB { get; set; }
        public int MaLoai { get; set; }
        public string TenLoai { get; set; }    
        public string SerialNumber { get; set; }
        public string TrangThai { get; set; }
        public string ViTri { get; set; }
        public DateTime NgayNhap { get; set; }
        public DateTime BaoHanhDen { get; set; }
        public string MoTa { get; set; }
    }
}