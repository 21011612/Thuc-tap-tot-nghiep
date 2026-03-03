using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using SELAB.Models;

namespace SELAB.DAL
{
    public class LichSuSuDungDAL
    {
        private string connStr = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        public DataTable GetAllLichSu()
        {
            string sql = @"SELECT LS.MaLichSu, TB.MaTB, TB.TenTB, ND.MaND, ND.HoTen, 
                                  LS.NgayBatDau, LS.NgayKetThuc, LS.GhiChu 
                           FROM LichSuSuDung LS 
                           JOIN ThietBi TB ON LS.MaTB = TB.MaTB 
                           JOIN NguoiDung ND ON LS.MaND = ND.MaND 
                           ORDER BY LS.NgayBatDau ASC, LS.MaLichSu ASC";
            return ExecuteQuery(sql);
        }

        public DataTable GetLichSuByNguoiDung(int maND)
        {
            string sql = @"SELECT LS.MaLichSu, TB.MaTB, TB.TenTB, ND.MaND, ND.HoTen, 
                                  LS.NgayBatDau, LS.NgayKetThuc, LS.GhiChu 
                           FROM LichSuSuDung LS 
                           JOIN ThietBi TB ON LS.MaTB = TB.MaTB 
                           JOIN NguoiDung ND ON LS.MaND = ND.MaND 
                           WHERE LS.MaND = @maND 
                           ORDER BY LS.NgayBatDau DESC";
            SqlParameter[] para = { new SqlParameter("@maND", maND) };
            return ExecuteQuery(sql, para);
        }

        public bool ThemLichSu(LichSuSuDung ls)
        {
            string sql = @"INSERT INTO LichSuSuDung (MaTB, MaND, NgayBatDau, NgayKetThuc, GhiChu) 
                           VALUES (@matb, @mand, @ngaybatdau, @ngayketthuc, @ghichu)";
            SqlParameter[] para = {
                new SqlParameter("@matb", ls.MaTB),
                new SqlParameter("@mand", ls.MaND),
                new SqlParameter("@ngaybatdau", ls.NgayBatDau),
                new SqlParameter("@ngayketthuc", (object)ls.NgayKetThuc ?? DBNull.Value),
                new SqlParameter("@ghichu", ls.GhiChu ?? (object)DBNull.Value)
            };
            return ExecuteNonQuery(sql, para) > 0;
        }

        public bool SuaLichSu(LichSuSuDung ls)
        {
            string sql = @"UPDATE LichSuSuDung 
                           SET MaTB = @matb, MaND = @mand, NgayBatDau = @ngaybatdau, 
                               NgayKetThuc = @ngayketthuc, GhiChu = @ghichu 
                           WHERE MaLichSu = @malichsu";
            SqlParameter[] para = {
                new SqlParameter("@malichsu", ls.MaLichSu),
                new SqlParameter("@matb", ls.MaTB),
                new SqlParameter("@mand", ls.MaND),
                new SqlParameter("@ngaybatdau", ls.NgayBatDau),
                new SqlParameter("@ngayketthuc", (object)ls.NgayKetThuc ?? DBNull.Value),
                new SqlParameter("@ghichu", ls.GhiChu ?? (object)DBNull.Value)
            };
            return ExecuteNonQuery(sql, para) > 0;
        }

        public bool XoaLichSu(int maLichSu)
        {
            string sql = "DELETE FROM LichSuSuDung WHERE MaLichSu = @malichsu";
            SqlParameter[] para = { new SqlParameter("@malichsu", maLichSu) };
            return ExecuteNonQuery(sql, para) > 0;
        }

        public DataTable GetThietBiCombo()
        {
            string sql = "SELECT MaTB, TenTB FROM ThietBi ORDER BY TenTB";
            return ExecuteQuery(sql);
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