using System;

namespace SELAB.Models
{
    public class LichSuSuDung
    {
        public int MaLichSu { get; set; }
        public int MaTB { get; set; }
        public string TenTB { get; set; }
        public int MaND { get; set; }
        public string HoTen { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public string GhiChu { get; set; }
    }
}