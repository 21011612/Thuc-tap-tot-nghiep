using System;

namespace SELAB.Models
{
    public class ThongBao
    {
        public int MaTBao { get; set; }
        public int MaND { get; set; }
        public string HoTen { get; set; }       
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
        public DateTime NgayGui { get; set; }
        public bool DaDoc { get; set; }
    }
}