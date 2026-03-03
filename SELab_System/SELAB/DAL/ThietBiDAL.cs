using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using SELAB.Models;

namespace SELAB.DAL
{
    public class ThietBiDAL
    {
        private string connStr = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        public DataTable GetAllThietBi()
        {
            string sql = @"SELECT TB.MaTB, TB.TenTB, LT.TenLoai, TB.SerialNumber, 
                                  TB.TrangThai, TB.ViTri, TB.NgayNhap, TB.BaoHanhDen, TB.MoTa 
                           FROM ThietBi TB 
                           JOIN LoaiThietBi LT ON TB.MaLoai = LT.MaLoai 
                           ORDER BY TB.MaTB ASC";
            return ExecuteQuery(sql);
        }

        public bool ThemThietBi(ThietBi tb)
        {
            string sql = @"INSERT INTO ThietBi (MaTB, TenTB, MaLoai, SerialNumber, TrangThai, ViTri, NgayNhap, BaoHanhDen, MoTa)
                           VALUES (@matb, @ten, @maloai, @serial, @tt, @vitri, @ngay, @baohanh, @mota)";
            SqlParameter[] para = {
                new SqlParameter("@matb", tb.MaTB),
                new SqlParameter("@ten", tb.TenTB),
                new SqlParameter("@maloai", tb.MaLoai),
                new SqlParameter("@serial", tb.SerialNumber),
                new SqlParameter("@tt", tb.TrangThai),
                new SqlParameter("@vitri", tb.ViTri ?? (object)DBNull.Value),
                new SqlParameter("@ngay", tb.NgayNhap),
                new SqlParameter("@baohanh", tb.BaoHanhDen),
                new SqlParameter("@mota", tb.MoTa ?? (object)DBNull.Value)
            };
            return ExecuteNonQuery(sql, para) > 0;
        }

        public bool SuaThietBi(ThietBi tb)
        {
            string sql = @"UPDATE ThietBi SET TenTB=@ten, MaLoai=@maloai, SerialNumber=@serial,
                           TrangThai=@tt, ViTri=@vitri, NgayNhap=@ngay, BaoHanhDen=@baohanh, MoTa=@mota
                           WHERE MaTB=@matb";
            SqlParameter[] para = {
                new SqlParameter("@matb", tb.MaTB),
                new SqlParameter("@ten", tb.TenTB),
                new SqlParameter("@maloai", tb.MaLoai),
                new SqlParameter("@serial", tb.SerialNumber),
                new SqlParameter("@tt", tb.TrangThai),
                new SqlParameter("@vitri", tb.ViTri ?? (object)DBNull.Value),
                new SqlParameter("@ngay", tb.NgayNhap),
                new SqlParameter("@baohanh", tb.BaoHanhDen),
                new SqlParameter("@mota", tb.MoTa ?? (object)DBNull.Value)
            };
            return ExecuteNonQuery(sql, para) > 0;
        }

        public bool XoaThietBi(int maTB)
        {
            string sql = "DELETE FROM ThietBi WHERE MaTB = @matb";
            SqlParameter[] para = { new SqlParameter("@matb", maTB) };
            return ExecuteNonQuery(sql, para) > 0;
        }

        public DataTable TimKiemThietBi(string tuKhoa)
        {
            string sql = @"SELECT TB.MaTB, TB.TenTB, LT.TenLoai, TB.SerialNumber, 
                                  TB.TrangThai, TB.ViTri, TB.NgayNhap, TB.BaoHanhDen, TB.MoTa 
                           FROM ThietBi TB 
                           JOIN LoaiThietBi LT ON TB.MaLoai = LT.MaLoai 
                           WHERE TB.TenTB LIKE @tk OR TB.SerialNumber LIKE @tk OR LT.TenLoai LIKE @tk";
            SqlParameter[] para = { new SqlParameter("@tk", "%" + tuKhoa + "%") };
            return ExecuteQuery(sql, para);
        }

        public DataTable GetLoaiThietBi()
        {
            string sql = "SELECT MaLoai, TenLoai FROM LoaiThietBi ORDER BY TenLoai";
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