using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using SELAB.Models;

namespace SELAB.DAL
{
    public class ThongBaoDAL
    {
        private string connStr = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        public DataTable GetAllThongBao()
        {
            string sql = @"SELECT TB.MaTBao, ND.MaND, ND.HoTen, TB.TieuDe, TB.NoiDung, 
                                  TB.NgayGui, TB.DaDoc 
                           FROM ThongBao TB 
                           JOIN NguoiDung ND ON TB.MaND = ND.MaND 
                           ORDER BY TB.NgayGui DESC";
            return ExecuteQuery(sql);
        }

        public DataTable GetThongBaoByNguoiDung(int maND)
        {
            string sql = @"SELECT TB.MaTBao, ND.MaND, ND.HoTen, TB.TieuDe, TB.NoiDung, 
                                  TB.NgayGui, TB.DaDoc 
                           FROM ThongBao TB 
                           JOIN NguoiDung ND ON TB.MaND = ND.MaND 
                           WHERE TB.MaND = @maND 
                           ORDER BY TB.NgayGui DESC";
            SqlParameter[] para = { new SqlParameter("@maND", maND) };
            return ExecuteQuery(sql, para);
        }

        public bool ThemThongBao(ThongBao tb)
        {
            string sql = @"INSERT INTO ThongBao (MaND, TieuDe, NoiDung, NgayGui, DaDoc) 
                           VALUES (@mand, @tieude, @noidung, GETDATE(), 0)";
            SqlParameter[] para = {
                new SqlParameter("@mand", tb.MaND),
                new SqlParameter("@tieude", tb.TieuDe),
                new SqlParameter("@noidung", tb.NoiDung)
            };
            return ExecuteNonQuery(sql, para) > 0;
        }

        public bool DanhDauDaDoc(int maTBao)
        {
            string sql = "UPDATE ThongBao SET DaDoc = 1 WHERE MaTBao = @matbao";
            SqlParameter[] para = { new SqlParameter("@matbao", maTBao) };
            return ExecuteNonQuery(sql, para) > 0;
        }

        public bool XoaThongBao(int maTBao)
        {
            string sql = "DELETE FROM ThongBao WHERE MaTBao = @matbao";
            SqlParameter[] para = { new SqlParameter("@matbao", maTBao) };
            return ExecuteNonQuery(sql, para) > 0;
        }

        public DataTable GetNguoiDungCombo()
        {
            string sql = "SELECT MaND, HoTen FROM NguoiDung ORDER BY HoTen";
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