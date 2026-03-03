using System;

namespace SELAB.Models
{
    public class LichDat
    {
        public int MaLich { get; set; }
        public int MaTB { get; set; }
        public int MaND { get; set; }
        public DateTime NgayDat { get; set; }
        public TimeSpan ThoiGianBatDau { get; set; }
        public TimeSpan ThoiGianKetThuc { get; set; }
        public string LyDo { get; set; }
        public string TrangThaiLich { get; set; }
    }
}