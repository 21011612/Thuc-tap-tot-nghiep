using System.Configuration;
using System.Data.SqlClient;
using SELAB.Models;

namespace SELAB.DAL
{
    public class DataAccess
    {
        private string connStr = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        public NguoiDung CheckLogin(string tenDangNhap, string matKhau)
        {
            string sql = "SELECT MaND, HoTen, TenDangNhap, VaiTro FROM NguoiDung WHERE TenDangNhap = @user AND MatKhau = @pass";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@user", tenDangNhap);
                    cmd.Parameters.AddWithValue("@pass", matKhau);

                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            return new NguoiDung
                            {
                                MaND = (int)rd["MaND"],
                                HoTen = rd["HoTen"].ToString(),
                                TenDangNhap = rd["TenDangNhap"].ToString(),
                                VaiTro = rd["VaiTro"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}