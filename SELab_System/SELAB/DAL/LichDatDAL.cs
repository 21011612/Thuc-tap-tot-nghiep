using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using SELAB.Models;

namespace SELAB.DAL
{
    public class LichDatDAL
    {
        private string connStr = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        public DataTable GetAllLichDat()
        {
            string sql = @"SELECT LD.MaLich, TB.TenTB, ND.HoTen AS NguoiDat, LD.NgayDat, 
                                  LD.ThoiGianBatDau, LD.ThoiGianKetThuc, LD.LyDo, LD.TrangThaiLich 
                           FROM LichDat LD 
                           JOIN ThietBi TB ON LD.MaTB = TB.MaTB 
                           JOIN NguoiDung ND ON LD.MaND = ND.MaND 
                           ORDER BY LD.NgayDat ASC, LD.ThoiGianBatDau ASC";
            return ExecuteQuery(sql);
        }

        public DataTable GetLichDatByNguoiDung(int maND)
        {
            string sql = @"SELECT LD.MaLich, TB.TenTB, ND.HoTen AS NguoiDat, LD.NgayDat, 
                                  LD.ThoiGianBatDau, LD.ThoiGianKetThuc, LD.LyDo, LD.TrangThaiLich 
                           FROM LichDat LD 
                           JOIN ThietBi TB ON LD.MaTB = TB.MaTB 
                           JOIN NguoiDung ND ON LD.MaND = ND.MaND 
                           WHERE LD.MaND = @maND 
                           ORDER BY LD.NgayDat DESC";
            SqlParameter[] para = { new SqlParameter("@maND", maND) };
            return ExecuteQuery(sql, para);
        }

        public bool ThemLichDat(LichDat ld)
        {
            string sql = @"INSERT INTO LichDat (MaTB, MaND, NgayDat, ThoiGianBatDau, ThoiGianKetThuc, LyDo, TrangThaiLich) 
                           VALUES (@matb, @mand, @ngay, @batdau, @ketthuc, @lydo, N'Chờ duyệt')";
            SqlParameter[] para = {
                new SqlParameter("@matb", ld.MaTB),
                new SqlParameter("@mand", ld.MaND),
                new SqlParameter("@ngay", ld.NgayDat),
                new SqlParameter("@batdau", ld.ThoiGianBatDau),
                new SqlParameter("@ketthuc", ld.ThoiGianKetThuc),
                new SqlParameter("@lydo", ld.LyDo ?? (object)DBNull.Value)
            };
            return ExecuteNonQuery(sql, para) > 0;
        }

        public bool DuyetLichDat(int maLich)
        {
            string sql = "UPDATE LichDat SET TrangThaiLich = N'Đã duyệt' WHERE MaLich = @malich";
            SqlParameter[] para = { new SqlParameter("@malich", maLich) };
            return ExecuteNonQuery(sql, para) > 0;
        }

        public bool HuyLichDat(int maLich)
        {
            string sql = "UPDATE LichDat SET TrangThaiLich = N'Hủy' WHERE MaLich = @malich";
            SqlParameter[] para = { new SqlParameter("@malich", maLich) };
            return ExecuteNonQuery(sql, para) > 0;
        }

        public bool XoaLichDat(int maLich)
        {
            string sql = "DELETE FROM LichDat WHERE MaLich = @malich";
            SqlParameter[] para = { new SqlParameter("@malich", maLich) };
            return ExecuteNonQuery(sql, para) > 0;
        }

        public DataTable GetThietBiSanSang()
        {
            string sql = "SELECT MaTB, TenTB FROM ThietBi WHERE TrangThai = N'Sẵn sàng' ORDER BY TenTB";
            return ExecuteQuery(sql);
        }

        private DataTable ExecuteQuery(string sql, SqlParameter[] para = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (para != null) cmd.Parameters.AddRange(para);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        da.Fill(dt);
                }
            }
            return dt;
        }

        private int ExecuteNonQuery(string sql, SqlParameter[] para = null)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (para != null) cmd.Parameters.AddRange(para);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}