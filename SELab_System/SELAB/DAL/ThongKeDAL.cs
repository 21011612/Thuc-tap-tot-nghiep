using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using SELAB.Models;

namespace SELAB.DAL
{
    public class ThongKeDAL
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        // ====================== THỐNG KÊ TỔNG QUAN (4 Cards) ======================
        public ThongKeTongQuan GetThongKeTongQuan()
        {
            ThongKeTongQuan kq = new ThongKeTongQuan();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Tổng thiết bị
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM ThietBi", conn))
                        kq.TongThietBi = Convert.ToInt32(cmd.ExecuteScalar());

                    // Thiết bị sẵn sàng
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM ThietBi WHERE TrangThai = N'Sẵn sàng'", conn))
                        kq.ThietBiSanSang = Convert.ToInt32(cmd.ExecuteScalar());

                    // Lịch đặt chờ duyệt
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM LichDat WHERE TrangThaiLich = N'Chờ duyệt'", conn))
                        kq.LichDatMoi = Convert.ToInt32(cmd.ExecuteScalar());

                    // Đang bảo trì
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM LichBaoTri WHERE TrangThaiBT = N'Chưa thực hiện'", conn))
                        kq.DangBaoTri = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ThongKeDAL] Lỗi GetThongKeTongQuan: {ex.Message}");
            }

            return kq;
        }

        // ====================== THỐNG KÊ TRẠNG THÁI THIẾT BỊ (Biểu đồ tròn) ======================
        public List<ThongKeTrangThaiThietBi> GetThongKeTrangThai()
        {
            List<ThongKeTrangThaiThietBi> list = new List<ThongKeTrangThaiThietBi>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT TrangThai, COUNT(*) as SoLuong 
                                     FROM ThietBi 
                                     GROUP BY TrangThai";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new ThongKeTrangThaiThietBi
                            {
                                TrangThai = reader["TrangThai"].ToString(),
                                SoLuong = Convert.ToInt32(reader["SoLuong"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ThongKeDAL] Lỗi GetThongKeTrangThai: {ex.Message}");
            }

            return list;
        }

        public List<ThongKeLichDatTheoLoai> GetThongKeLichDat()
        {
            List<ThongKeLichDatTheoLoai> list = new List<ThongKeLichDatTheoLoai>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT LT.TenLoai, COUNT(LD.MaLich) as SoLuot
                        FROM LichDat LD
                        JOIN ThietBi TB ON LD.MaTB = TB.MaTB
                        JOIN LoaiThietBi LT ON TB.MaLoai = LT.MaLoai
                        GROUP BY LT.TenLoai";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new ThongKeLichDatTheoLoai
                            {
                                TenLoai = reader["TenLoai"].ToString(),
                                SoLuotDat = Convert.ToInt32(reader["SoLuot"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ThongKeDAL] Lỗi GetThongKeLichDat: {ex.Message}");
            }

            return list;
        }
    }
}