using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using SELAB.Models;

namespace SELAB.DAL
{
    public class LichBaoTriDAL
    {
        private string connStr = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        public DataTable GetAllLichBaoTri()
        {
            string sql = @"SELECT LBT.MaBaoTri, TB.MaTB, TB.TenTB, LBT.NgayBaoTri, 
                          LBT.MoTaBaoTri, LBT.TrangThaiBT 
                   FROM LichBaoTri LBT 
                   JOIN ThietBi TB ON LBT.MaTB = TB.MaTB 
                   ORDER BY LBT.NgayBaoTri ASC, LBT.MaBaoTri ASC";
            return ExecuteQuery(sql);
        }

        public bool ThemLichBaoTri(LichBaoTri lbt)
        {
            string sql = @"INSERT INTO LichBaoTri (MaTB, NgayBaoTri, MoTaBaoTri, TrangThaiBT) 
                           VALUES (@matb, @ngay, @mota, @tt)";
            SqlParameter[] para = {
                new SqlParameter("@matb", lbt.MaTB),
                new SqlParameter("@ngay", lbt.NgayBaoTri),
                new SqlParameter("@mota", lbt.MoTaBaoTri ?? (object)DBNull.Value),
                new SqlParameter("@tt", lbt.TrangThaiBT)
            };
            return ExecuteNonQuery(sql, para) > 0;
        }

        public bool CapNhatTrangThai(int maBaoTri, string trangThaiMoi, string moTaMoi)
        {
            string sql = "UPDATE LichBaoTri SET TrangThaiBT = @tt, MoTaBaoTri = @mota WHERE MaBaoTri = @ma";
            SqlParameter[] para = {
                new SqlParameter("@tt", trangThaiMoi),
                new SqlParameter("@mota", moTaMoi ?? (object)DBNull.Value),
                new SqlParameter("@ma", maBaoTri)
            };
            return ExecuteNonQuery(sql, para) > 0;
        }

        public bool XoaLichBaoTri(int maBaoTri)
        {
            string sql = "DELETE FROM LichBaoTri WHERE MaBaoTri = @ma";
            SqlParameter[] para = { new SqlParameter("@ma", maBaoTri) };
            return ExecuteNonQuery(sql, para) > 0;
        }

        public DataTable GetThietBiCombo()
        {
            string sql = "SELECT MaTB, TenTB FROM ThietBi ORDER BY TenTB";
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