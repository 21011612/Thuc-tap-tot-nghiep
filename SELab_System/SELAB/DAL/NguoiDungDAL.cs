using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using SELAB.Models;

namespace SELAB.DAL
{
    public class NguoiDungDAL
    {
        private string connStr = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        public DataTable GetAllNguoiDung()
        {
            string sql = @"SELECT MaND, HoTen, MSSV_MaGV, Email, SoDienThoai, VaiTro, TenDangNhap
                           FROM NguoiDung ORDER BY VaiTro, HoTen";
            return ExecuteQuery(sql);
        }

        public bool ThemNguoiDung(NguoiDung nd)
        {
            string sql = @"INSERT INTO NguoiDung (HoTen, MSSV_MaGV, Email, SoDienThoai, VaiTro, TenDangNhap, MatKhau)
                           VALUES (@hoten, @mssv, @email, @sdt, @vaitro, @tendn, @matkhau)";
            SqlParameter[] para = {
                new SqlParameter("@hoten", nd.HoTen?.Trim()),
                new SqlParameter("@mssv", nd.MSSV_MaGV ?? (object)DBNull.Value),
                new SqlParameter("@email", nd.Email ?? (object)DBNull.Value),
                new SqlParameter("@sdt", nd.SoDienThoai ?? (object)DBNull.Value),
                new SqlParameter("@vaitro", nd.VaiTro),
                new SqlParameter("@tendn", nd.TenDangNhap?.Trim()),
                new SqlParameter("@matkhau", nd.MatKhau?.Trim())
            };
            return ExecuteNonQuery(sql, para) > 0;
        }

        public bool SuaNguoiDung(NguoiDung nd, string matKhauMoi = null)
        {
            string sql = @"UPDATE NguoiDung
                           SET HoTen = @hoten, MSSV_MaGV = @mssv, Email = @email,
                               SoDienThoai = @sdt, VaiTro = @vaitro, TenDangNhap = @tendn";
            if (!string.IsNullOrWhiteSpace(matKhauMoi))
                sql += ", MatKhau = @matkhau";
            sql += " WHERE MaND = @mand";
            var paraList = new System.Collections.Generic.List<SqlParameter>
            {
                new SqlParameter("@mand", nd.MaND),
                new SqlParameter("@hoten", nd.HoTen?.Trim()),
                new SqlParameter("@mssv", nd.MSSV_MaGV ?? (object)DBNull.Value),
                new SqlParameter("@email", nd.Email ?? (object)DBNull.Value),
                new SqlParameter("@sdt", nd.SoDienThoai ?? (object)DBNull.Value),
                new SqlParameter("@vaitro", nd.VaiTro),
                new SqlParameter("@tendn", nd.TenDangNhap?.Trim())
            };
            if (!string.IsNullOrWhiteSpace(matKhauMoi))
                paraList.Add(new SqlParameter("@matkhau", matKhauMoi.Trim()));
            return ExecuteNonQuery(sql, paraList.ToArray()) > 0;
        }

        public bool XoaNguoiDung(int maND)
        {
            string sql = "DELETE FROM NguoiDung WHERE MaND = @mand";
            SqlParameter[] para = { new SqlParameter("@mand", maND) };
            return ExecuteNonQuery(sql, para) > 0;
        }

        public bool DoiMatKhau(int maND, string matKhauMoi)
        {
            if (string.IsNullOrWhiteSpace(matKhauMoi)) return false;
            string sql = "UPDATE NguoiDung SET MatKhau = @matkhau WHERE MaND = @mand";
            SqlParameter[] para = {
                new SqlParameter("@mand", maND),
                new SqlParameter("@matkhau", matKhauMoi.Trim())
            };
            return ExecuteNonQuery(sql, para) > 0;
        }

        private object ExecuteScalar(string sql, SqlParameter[] para = null)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (para != null) cmd.Parameters.AddRange(para);
                    return cmd.ExecuteScalar();
                }
            }
        }

        public bool IsTenDangNhapTonTai(string tenDangNhap, int? maNDExclude = null)
        {
            if (string.IsNullOrWhiteSpace(tenDangNhap)) return false;
            string sql = "SELECT COUNT(*) FROM NguoiDung WHERE TenDangNhap = @tendn";
            if (maNDExclude.HasValue) sql += " AND MaND != @mand";
            SqlParameter[] para = maNDExclude.HasValue
                ? new[] { new SqlParameter("@tendn", tenDangNhap.Trim()), new SqlParameter("@mand", maNDExclude.Value) }
                : new[] { new SqlParameter("@tendn", tenDangNhap.Trim()) };
            return Convert.ToInt32(ExecuteScalar(sql, para)) > 0;
        }

        public bool IsEmailTonTai(string email, int? maNDExclude = null)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            string sql = "SELECT COUNT(*) FROM NguoiDung WHERE Email = @email";
            if (maNDExclude.HasValue) sql += " AND MaND != @mand";
            SqlParameter[] para = maNDExclude.HasValue
                ? new[] { new SqlParameter("@email", email.Trim()), new SqlParameter("@mand", maNDExclude.Value) }
                : new[] { new SqlParameter("@email", email.Trim()) };
            return Convert.ToInt32(ExecuteScalar(sql, para)) > 0;
        }

        public bool IsMSSVTonTai(string mssv, int? maNDExclude = null)
        {
            if (string.IsNullOrWhiteSpace(mssv)) return false;
            string sql = "SELECT COUNT(*) FROM NguoiDung WHERE MSSV_MaGV = @mssv";
            if (maNDExclude.HasValue) sql += " AND MaND != @mand";
            SqlParameter[] para = maNDExclude.HasValue
                ? new[] { new SqlParameter("@mssv", mssv.Trim()), new SqlParameter("@mand", maNDExclude.Value) }
                : new[] { new SqlParameter("@mssv", mssv.Trim()) };
            return Convert.ToInt32(ExecuteScalar(sql, para)) > 0;
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