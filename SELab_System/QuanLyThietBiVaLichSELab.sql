-- =============================================
-- DATABASE: QuanLyThietBiVaLichSELab
-- PHIÊN BẢN HOÀN CHỈNH CHO SE LAB
-- ĐÃ BỔ SUNG BẢNG 6 & BẢNG 7 - MaTB KHÔNG TỰ TĂNG
-- =============================================

CREATE DATABASE QuanLyThietBiVaLichSELab;
GO
USE QuanLyThietBiVaLichSELab;
GO

-- ==================== TẠO CÁC BẢNG ====================
CREATE TABLE LoaiThietBi (
    MaLoai INT IDENTITY(1,1) PRIMARY KEY,
    TenLoai NVARCHAR(100) NOT NULL,
    MoTa NVARCHAR(255)
);

CREATE TABLE ThietBi (
    MaTB INT PRIMARY KEY,                    -- KHÔNG CÓ IDENTITY(1,1)
    TenTB NVARCHAR(150) NOT NULL,
    MaLoai INT FOREIGN KEY REFERENCES LoaiThietBi(MaLoai),
    SerialNumber NVARCHAR(50) UNIQUE,
    TrangThai NVARCHAR(30) CHECK (TrangThai IN (N'Sẵn sàng', N'Đang sử dụng', N'Bảo trì', N'Hỏng')),
    ViTri NVARCHAR(100),
    NgayNhap DATE,
    BaoHanhDen DATE,
    MoTa NVARCHAR(500)
);

CREATE TABLE NguoiDung (
    MaND INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    MSSV_MaGV NVARCHAR(20),
    Email NVARCHAR(100) UNIQUE,
    SoDienThoai NVARCHAR(15),
    VaiTro NVARCHAR(30) CHECK (VaiTro IN (N'Admin', N'Giảng viên', N'Sinh viên')),
    TenDangNhap NVARCHAR(50) UNIQUE,
    MatKhau NVARCHAR(255)
);

CREATE TABLE LichDat (
    MaLich INT IDENTITY(1,1) PRIMARY KEY,
    MaTB INT FOREIGN KEY REFERENCES ThietBi(MaTB),
    MaND INT FOREIGN KEY REFERENCES NguoiDung(MaND),
    NgayDat DATE NOT NULL,
    ThoiGianBatDau TIME NOT NULL,
    ThoiGianKetThuc TIME NOT NULL,
    LyDo NVARCHAR(200),
    TrangThaiLich NVARCHAR(30) CHECK (TrangThaiLich IN (N'Chờ duyệt', N'Đã duyệt', N'Hủy'))
);

CREATE TABLE LichBaoTri (
    MaBaoTri INT IDENTITY(1,1) PRIMARY KEY,
    MaTB INT FOREIGN KEY REFERENCES ThietBi(MaTB),
    NgayBaoTri DATE NOT NULL,
    MoTaBaoTri NVARCHAR(300),
    TrangThaiBT NVARCHAR(30) DEFAULT N'Chưa thực hiện'
);

CREATE TABLE LichSuSuDung (
    MaLichSu INT IDENTITY(1,1) PRIMARY KEY,
    MaTB INT FOREIGN KEY REFERENCES ThietBi(MaTB),
    MaND INT FOREIGN KEY REFERENCES NguoiDung(MaND),
    NgayBatDau DATETIME NOT NULL,
    NgayKetThuc DATETIME,
    GhiChu NVARCHAR(300)
);

CREATE TABLE ThongBao (
    MaTBao INT IDENTITY(1,1) PRIMARY KEY,
    MaND INT FOREIGN KEY REFERENCES NguoiDung(MaND),
    TieuDe NVARCHAR(150) NOT NULL,
    NoiDung NVARCHAR(500) NOT NULL,
    NgayGui DATETIME DEFAULT GETDATE(),
    DaDoc BIT DEFAULT 0
);

-- ==================== INSERT DỮ LIỆU ====================

-- 1. Loại thiết bị (10 loại)
INSERT INTO LoaiThietBi (TenLoai, MoTa) VALUES
(N'Máy tính để bàn', N'PC Dell, HP, Lenovo, ASUS'),
(N'Laptop', N'Dell, HP, ASUS, MacBook, Lenovo'),
(N'Máy chiếu', N'Epson, BenQ, Optoma, ViewSonic'),
(N'Màn hình', N'Dell, LG, Samsung, ViewSonic'),
(N'Bộ Arduino & Kit', N'Arduino Uno, Mega, Raspberry Pi'),
(N'Máy hiện sóng', N'Rigol, Hantek, Tektronix'),
(N'Switch mạng', N'Cisco, TP-Link, Netgear, D-Link'),
(N'Router WiFi', N'TP-Link, ASUS, Linksys'),
(N'Bàn phím + Chuột', N'Logitech, Razer, Royal Kludge'),
(N'Loa hội thảo', N'JBL, Sony, Bose, Anker');

-- 2. Thiết bị (40 thiết bị) - THÊM MaTB thủ công
INSERT INTO ThietBi (MaTB, TenTB, MaLoai, SerialNumber, TrangThai, ViTri, NgayNhap, BaoHanhDen, MoTa) VALUES
(1, N'Dell OptiPlex 7090', 1, 'SN-PC001', N'Sẵn sàng', N'Phòng SE Lab 101', '2023-05-15', '2026-05-15', N'i7-11700, 16GB RAM, SSD 512GB'),
(2, N'HP EliteDesk 800 G6', 1, 'SN-PC002', N'Sẵn sàng', N'Phòng SE Lab 101', '2023-06-01', '2026-06-01', N'i5-10500, 16GB RAM'),
(3, N'Dell Latitude 5420', 2, 'SN-LAP001', N'Đang sử dụng', N'Phòng SE Lab 102', '2024-01-10', '2027-01-10', N'i7-1165G7, 16GB'),
(4, N'HP Pavilion 15', 2, 'SN-LAP002', N'Sẵn sàng', N'Phòng SE Lab 102', '2024-02-20', '2027-02-20', N'Ryzen 5 5500U'),
(5, N'Epson EB-X41', 3, 'SN-PROJ001', N'Sẵn sàng', N'Phòng SE Lab 103', '2023-03-05', '2025-03-05', N'4000 lumens'),
(6, N'BenQ MS550', 3, 'SN-PROJ002', N'Bảo trì', N'Phòng SE Lab 103', '2023-08-12', '2025-08-12', N''),
(7, N'Dell P2422H 24"', 4, 'SN-MON001', N'Sẵn sàng', N'Phòng SE Lab 101', '2023-04-01', '2026-04-01', N'Full HD IPS'),
(8, N'LG 27UL500 27"', 4, 'SN-MON002', N'Sẵn sàng', N'Phòng SE Lab 102', '2024-03-15', '2027-03-15', N'4K UHD'),
(9, N'Arduino Uno R3', 5, 'SN-ARD001', N'Sẵn sàng', N'Phòng SE Lab 104', '2023-07-10', '2025-07-10', N'Kit chính hãng'),
(10, N'Arduino Mega 2560', 5, 'SN-ARD002', N'Sẵn sàng', N'Phòng SE Lab 104', '2023-07-10', '2025-07-10', N''),
(11, N'Rigol DS1054Z', 6, 'SN-OSC001', N'Sẵn sàng', N'Phòng SE Lab 105', '2023-09-01', '2026-09-01', N'50MHz 4 kênh'),
(12, N'Cisco Catalyst 2960', 7, 'SN-SW001', N'Sẵn sàng', N'Phòng SE Lab 101', '2023-10-05', '2028-10-05', N'24 ports Gigabit'),
(13, N'TP-Link TL-SG108', 7, 'SN-SW002', N'Sẵn sàng', N'Phòng SE Lab 102', '2024-04-20', '2027-04-20', N'8 ports'),
(14, N'ASUS RT-AX55', 8, 'SN-RT001', N'Sẵn sàng', N'Phòng SE Lab 103', '2024-05-01', '2027-05-01', N'WiFi 6'),
(15, N'Logitech MK270 Combo', 9, 'SN-KM001', N'Sẵn sàng', N'Phòng SE Lab 101', '2023-11-15', '2025-11-15', N'Wireless'),
(16, N'JBL PartyBox 100', 10, 'SN-LOA001', N'Sẵn sàng', N'Phòng SE Lab 103', '2024-01-25', '2026-01-25', N'Loa hội thảo'),
(17, N'Dell Inspiron 3511', 2, 'SN-LAP003', N'Sẵn sàng', N'Phòng SE Lab 102', '2024-03-20', '2027-03-20', N'i5-1135G7'),
(18, N'Lenovo IdeaPad Slim 3', 2, 'SN-LAP004', N'Sẵn sàng', N'Phòng SE Lab 102', '2024-04-05', '2027-04-05', N'Ryzen 5'),
(19, N'ViewSonic PA503S', 3, 'SN-PROJ003', N'Sẵn sàng', N'Phòng SE Lab 103', '2023-05-10', '2025-05-10', N'3800 lumens'),
(20, N'Optoma UHD38', 3, 'SN-PROJ004', N'Sẵn sàng', N'Phòng SE Lab 103', '2024-06-15', '2026-06-15', N'4K'),
(21, N'Samsung LS32A700', 4, 'SN-MON003', N'Sẵn sàng', N'Phòng SE Lab 101', '2024-01-30', '2027-01-30', N'32" 75Hz'),
(22, N'LG UltraGear 27GN650', 4, 'SN-MON004', N'Sẵn sàng', N'Phòng SE Lab 101', '2024-02-28', '2027-02-28', N'144Hz'),
(23, N'Raspberry Pi 5 8GB', 5, 'SN-ARD003', N'Sẵn sàng', N'Phòng SE Lab 104', '2024-01-15', '2026-01-15', N'Kit IoT'),
(24, N'Hantek 6022BE', 6, 'SN-OSC002', N'Sẵn sàng', N'Phòng SE Lab 105', '2023-11-20', '2026-11-20', N'USB Oscilloscope'),
(25, N'Netgear GS305', 7, 'SN-SW003', N'Sẵn sàng', N'Phòng SE Lab 102', '2024-05-10', '2027-05-10', N'5 ports'),
(26, N'TP-Link Archer C80', 8, 'SN-RT002', N'Sẵn sàng', N'Phòng SE Lab 103', '2024-07-20', '2027-07-20', N'WiFi 6'),
(27, N'RK Royal Kludge RK61', 9, 'SN-KM002', N'Sẵn sàng', N'Phòng SE Lab 101', '2023-12-10', '2025-12-10', N'RGB Mechanical'),
(28, N'JBL Charge 5', 10, 'SN-LOA002', N'Sẵn sàng', N'Phòng SE Lab 103', '2024-03-05', '2026-03-05', N'Portable'),
(29, N'HP EliteDesk 805 G8', 1, 'SN-PC003', N'Sẵn sàng', N'Phòng SE Lab 101', '2023-08-01', '2026-08-01', N'Ryzen 7'),
(30, N'ASUS VivoBook 15', 2, 'SN-LAP005', N'Đang sử dụng', N'Phòng SE Lab 102', '2024-04-15', '2027-04-15', N'i7-1255U'),
(31, N'Canon LV-WX300', 3, 'SN-PROJ005', N'Bảo trì', N'Phòng SE Lab 103', '2023-11-01', '2025-11-01', N''),
(32, N'Dell S2721QS', 4, 'SN-MON005', N'Sẵn sàng', N'Phòng SE Lab 101', '2024-05-20', '2027-05-20', N'27" 4K'),
(33, N'Elegoo Mega2560', 5, 'SN-ARD004', N'Sẵn sàng', N'Phòng SE Lab 104', '2024-02-10', '2026-02-10', N''),
(34, N'Tektronix TBS1102B', 6, 'SN-OSC003', N'Sẵn sàng', N'Phòng SE Lab 105', '2023-10-15', '2026-10-15', N'100MHz'),
(35, N'D-Link DGS-108', 7, 'SN-SW004', N'Sẵn sàng', N'Phòng SE Lab 102', '2024-06-01', '2027-06-01', N'8 ports'),
(36, N'Linksys MR7350', 8, 'SN-RT003', N'Sẵn sàng', N'Phòng SE Lab 103', '2024-08-01', '2027-08-01', N'WiFi 6'),
(37, N'Logitech G Pro X', 9, 'SN-KM003', N'Sẵn sàng', N'Phòng SE Lab 101', '2024-01-05', '2026-01-05', N''),
(38, N'Sony SRS-XB43', 10, 'SN-LOA003', N'Sẵn sàng', N'Phòng SE Lab 103', '2024-04-10', '2026-04-10', N''),
(39, N'MacBook Pro M3 14"', 2, 'SN-LAP006', N'Sẵn sàng', N'Phòng SE Lab 102', '2024-09-01', '2027-09-01', N'16GB RAM'),
(40, N'BenQ TK700', 3, 'SN-PROJ006', N'Sẵn sàng', N'Phòng SE Lab 103', '2024-07-15', '2026-07-15', N'4K Gaming');

-- 3. Người dùng (25 người)
INSERT INTO NguoiDung (HoTen, MSSV_MaGV, Email, SoDienThoai, VaiTro, TenDangNhap, MatKhau) VALUES
(N'Nguyễn Văn An', 'AD001', 'admin@selab.edu.vn', '0901234567', N'Admin', 'admin', '123456'),
(N'Trần Thị Bình', 'GV001', 'gv1@selab.edu.vn', '0987654321', N'Giảng viên', 'gv1', '123'),
(N'Lê Hoàng Cường', 'SE195001', 'se195001@selab.edu.vn', '0912345678', N'Sinh viên', 'se195001', '123'),
(N'Phạm Minh Đức', 'GV002', 'gv2@selab.edu.vn', '0978123456', N'Giảng viên', 'gv2', '123'),
(N'Võ Thị Em', 'SE195002', 'se195002@selab.edu.vn', '0923456789', N'Sinh viên', 'se195002', '123'),
(N'Hồ Văn Phúc', 'GV003', 'gv3@selab.edu.vn', '0945678901', N'Giảng viên', 'gv3', '123'),
(N'Đặng Thị Giang', 'SE195003', 'se195003@selab.edu.vn', '0934567890', N'Sinh viên', 'se195003', '123'),
(N'Trần Văn Hải', 'SE195004', 'se195004@selab.edu.vn', '0911122334', N'Sinh viên', 'se195004', '123'),
(N'Lý Thị Hương', 'GV004', 'gv4@selab.edu.vn', '0988776655', N'Giảng viên', 'gv4', '123'),
(N'Nguyễn Hoàng Long', 'SE195005', 'se195005@selab.edu.vn', '0909887766', N'Sinh viên', 'se195005', '123'),
(N'Phan Minh Quân', 'AD002', 'admin2@selab.edu.vn', '0911223344', N'Admin', 'admin2', '123456'),
(N'Bùi Thị Lan', 'GV005', 'gv5@selab.edu.vn', '0977665544', N'Giảng viên', 'gv5', '123'),
(N'Hoàng Văn Minh', 'SE195006', 'se195006@selab.edu.vn', '0933221100', N'Sinh viên', 'se195006', '123'),
(N'Đỗ Thị Ngọc', 'SE195007', 'se195007@selab.edu.vn', '0944556677', N'Sinh viên', 'se195007', '123'),
(N'Lê Minh Quân', 'GV006', 'gv6@selab.edu.vn', '0988112233', N'Giảng viên', 'gv6', '123'),
(N'Vũ Thị Oanh', 'SE195008', 'se195008@selab.edu.vn', '0912340987', N'Sinh viên', 'se195008', '123'),
(N'Nguyễn Thị Phương', 'GV007', 'gv7@selab.edu.vn', '0966554433', N'Giảng viên', 'gv7', '123'),
(N'Trần Hoàng Quang', 'SE195009', 'se195009@selab.edu.vn', '0908776655', N'Sinh viên', 'se195009', '123'),
(N'Phạm Văn Sơn', 'GV008', 'gv8@selab.edu.vn', '0981234567', N'Giảng viên', 'gv8', '123'),
(N'Lê Thị Thanh', 'SE195010', 'se195010@selab.edu.vn', '0919876543', N'Sinh viên', 'se195010', '123'),
(N'Đặng Minh Tuấn', 'SE195011', 'se195011@selab.edu.vn', '0934561234', N'Sinh viên', 'se195011', '123'),
(N'Hồ Thị Uyên', 'GV009', 'gv9@selab.edu.vn', '0976543210', N'Giảng viên', 'gv9', '123'),
(N'Võ Văn Việt', 'SE195012', 'se195012@selab.edu.vn', '0901122334', N'Sinh viên', 'se195012', '123'),
(N'Bùi Hoàng Xuân', 'GV010', 'gv10@selab.edu.vn', '0987651098', N'Giảng viên', 'gv10', '123'),
(N'Nguyễn Văn Yên', 'SE195013', 'se195013@selab.edu.vn', '0912345670', N'Sinh viên', 'se195013', '123');

-- 4. Lịch đặt (50 lịch)
INSERT INTO LichDat (MaTB, MaND, NgayDat, ThoiGianBatDau, ThoiGianKetThuc, LyDo, TrangThaiLich) VALUES
(1, 3, '2025-03-01', '08:00', '10:00', N'Thực hành môn SE', N'Đã duyệt'),
(2, 4, '2025-03-02', '14:00', '16:00', N'Báo cáo đồ án nhóm 1', N'Đã duyệt'),
(5, 3, '2025-03-05', '09:00', '11:30', N'Presentation môn PM', N'Chờ duyệt'),
(3, 5, '2025-03-06', '13:30', '15:30', N'Thực hành OOP', N'Đã duyệt'),
(8, 6, '2025-03-07', '10:00', '12:00', N'Họp nhóm đồ án', N'Đã duyệt'),
(12, 7, '2025-03-08', '08:30', '10:30', N'Thử nghiệm mạng', N'Đã duyệt'),
(15, 8, '2025-03-10', '14:00', '16:00', N'Làm bài tập lớn', N'Chờ duyệt'),
(20, 9, '2025-03-11', '09:00', '11:00', N'Presentation', N'Đã duyệt'),
(25, 10, '2025-03-12', '15:00', '17:00', N'Thực hành IoT', N'Đã duyệt'),
(30, 11, '2025-03-13', '08:00', '10:00', N'Bảo vệ đề tài', N'Hủy'),
(4, 12, '2025-03-15', '13:00', '15:00', N'Thực hành C#', N'Đã duyệt'),
(7, 13, '2025-03-16', '10:30', '12:30', N'Họp nhóm', N'Đã duyệt'),
(9, 14, '2025-03-17', '14:30', '16:30', N'Thử nghiệm Arduino', N'Chờ duyệt'),
(11, 15, '2025-03-18', '09:30', '11:30', N'Báo cáo tiến độ', N'Đã duyệt'),
(18, 16, '2025-03-19', '15:30', '17:30', N'Thực hành PM', N'Đã duyệt'),
(22, 17, '2025-03-20', '08:00', '10:00', N'Thử nghiệm màn hình', N'Đã duyệt'),
(28, 18, '2025-03-21', '14:00', '16:00', N'Họp lab', N'Đã duyệt'),
(35, 19, '2025-03-22', '10:00', '12:00', N'Thực hành Network', N'Chờ duyệt'),
(40, 20, '2025-03-23', '13:00', '15:00', N'Báo cáo đồ án', N'Đã duyệt'),
(6, 21, '2025-04-01', '09:00', '11:00', N'Thử nghiệm máy chiếu', N'Đã duyệt'),
(13, 22, '2025-04-02', '15:00', '17:00', N'Thực hành Switch', N'Đã duyệt'),
(17, 23, '2025-04-03', '08:30', '10:30', N'Làm bài tập Router', N'Đã duyệt'),
(21, 24, '2025-04-04', '14:00', '16:00', N'Thử nghiệm loa', N'Chờ duyệt'),
(26, 25, '2025-04-05', '10:00', '12:00', N'Presentation nhóm', N'Đã duyệt'),
(31, 3, '2025-04-06', '13:30', '15:30', N'Thực hành SE', N'Đã duyệt'),
(36, 4, '2025-04-07', '09:00', '11:00', N'Báo cáo', N'Đã duyệt'),
(2, 5, '2025-04-08', '15:00', '17:00', N'Thử nghiệm Laptop', N'Đã duyệt'),
(10, 6, '2025-04-09', '08:00', '10:00', N'Thực hành Arduino', N'Chờ duyệt'),
(14, 7, '2025-04-10', '14:00', '16:00', N'Họp nhóm', N'Đã duyệt'),
(19, 8, '2025-04-11', '10:30', '12:30', N'Thử nghiệm Oscilloscope', N'Đã duyệt'),
(23, 9, '2025-04-12', '13:00', '15:00', N'Báo cáo tiến độ', N'Đã duyệt'),
(27, 10, '2025-04-13', '09:30', '11:30', N'Thực hành Loa', N'Đã duyệt'),
(32, 11, '2025-04-14', '15:30', '17:30', N'Thử nghiệm Router', N'Đã duyệt'),
(37, 12, '2025-04-15', '08:00', '10:00', N'Họp lab', N'Chờ duyệt'),
(1, 13, '2025-04-16', '14:00', '16:00', N'Thực hành PC', N'Đã duyệt'),
(5, 14, '2025-04-17', '10:00', '12:00', N'Thử nghiệm Máy chiếu', N'Đã duyệt'),
(8, 15, '2025-04-18', '13:30', '15:30', N'Báo cáo đồ án', N'Đã duyệt'),
(12, 16, '2025-04-19', '09:00', '11:00', N'Thực hành Switch', N'Đã duyệt'),
(16, 17, '2025-04-20', '15:00', '17:00', N'Họp nhóm', N'Đã duyệt'),
(24, 18, '2025-04-21', '08:30', '10:30', N'Thử nghiệm Màn hình', N'Chờ duyệt'),
(29, 19, '2025-04-22', '14:00', '16:00', N'Thực hành Keyboard', N'Đã duyệt'),
(33, 20, '2025-04-23', '10:30', '12:30', N'Báo cáo', N'Đã duyệt'),
(38, 21, '2025-04-24', '13:00', '15:00', N'Thử nghiệm Loa', N'Đã duyệt'),
(39, 22, '2025-04-25', '09:30', '11:30', N'Thực hành MacBook', N'Đã duyệt'),
(40, 23, '2025-04-26', '15:30', '17:30', N'Họp lab cuối kỳ', N'Đã duyệt'),
(3, 24, '2025-05-01', '08:00', '10:00', N'Thử nghiệm Laptop', N'Chờ duyệt'),
(9, 25, '2025-05-02', '14:00', '16:00', N'Báo cáo đồ án', N'Đã duyệt');

-- 5. Lịch bảo trì (20 lịch)
INSERT INTO LichBaoTri (MaTB, NgayBaoTri, MoTaBaoTri, TrangThaiBT) VALUES
(6, '2025-04-10', N'Vệ sinh bụi, thay đèn projector', N'Đã thực hiện'),
(12, '2025-05-15', N'Cập nhật firmware Switch Cisco', N'Chưa thực hiện'),
(30, '2025-06-01', N'Kiểm tra màn hình LG 27UL500', N'Chưa thực hiện'),
(5, '2025-06-10', N'Thay bóng đèn Epson EB-X41', N'Đã thực hiện'),
(18, '2025-07-05', N'Kiểm tra Arduino Mega', N'Chưa thực hiện'),
(25, '2025-07-20', N'Cập nhật driver Router ASUS', N'Đã thực hiện'),
(35, '2025-08-01', N'Vệ sinh máy tính để bàn HP', N'Chưa thực hiện'),
(40, '2025-08-15', N'Kiểm tra MacBook Pro M3', N'Chưa thực hiện'),
(7, '2025-09-10', N'Thay pin laptop Dell', N'Đã thực hiện'),
(15, '2025-09-20', N'Kiểm tra Oscilloscope Rigol', N'Chưa thực hiện'),
(22, '2025-10-05', N'Vệ sinh loa JBL', N'Đã thực hiện'),
(28, '2025-10-15', N'Cập nhật Windows Laptop HP', N'Chưa thực hiện'),
(33, '2025-11-01', N'Kiểm tra Switch Netgear', N'Đã thực hiện'),
(38, '2025-11-10', N'Vệ sinh bàn phím Logitech', N'Chưa thực hiện'),
(2, '2025-12-01', N'Kiểm tra PC Dell OptiPlex', N'Chưa thực hiện'),
(11, '2025-12-15', N'Thay quạt tản nhiệt', N'Đã thực hiện'),
(17, '2026-01-05', N'Kiểm tra Router TP-Link', N'Chưa thực hiện'),
(23, '2026-01-20', N'Vệ sinh màn hình Samsung', N'Đã thực hiện'),
(29, '2026-02-10', N'Cập nhật firmware Arduino', N'Chưa thực hiện'),
(34, '2026-02-25', N'Kiểm tra toàn bộ Lab 105', N'Chưa thực hiện');

-- ==================== BẢNG 6 & 7 ====================
INSERT INTO LichSuSuDung (MaTB, MaND, NgayBatDau, NgayKetThuc, GhiChu) VALUES
(1, 3, '2025-03-01 08:00:00', '2025-03-01 10:00:00', N'Thực hành môn SE'),
(3, 5, '2025-03-06 13:30:00', '2025-03-06 15:30:00', N'Thực hành OOP'),
(5, 3, '2025-03-05 09:00:00', '2025-03-05 11:30:00', N'Presentation'),
(8, 6, '2025-03-07 10:00:00', '2025-03-07 12:00:00', N'Họp nhóm đồ án'),
(12, 7, '2025-03-08 08:30:00', '2025-03-08 10:30:00', N'Thử nghiệm mạng'),
(15, 8, '2025-03-10 14:00:00', '2025-03-10 16:00:00', N'Làm bài tập lớn'),
(20, 9, '2025-03-11 09:00:00', '2025-03-11 11:00:00', N'Presentation'),
(25, 10, '2025-03-12 15:00:00', '2025-03-12 17:00:00', N'Thực hành IoT'),
(4, 12, '2025-03-15 13:00:00', '2025-03-15 15:00:00', N'Thực hành C#'),
(10, 6, '2025-04-09 08:00:00', '2025-04-09 10:00:00', N'Thực hành Arduino'),
(19, 8, '2025-04-11 10:30:00', '2025-04-11 12:30:00', N'Thử nghiệm Oscilloscope'),
(27, 10, '2025-04-13 09:30:00', '2025-04-13 11:30:00', N'Thực hành Loa'),
(32, 11, '2025-04-14 15:30:00', '2025-04-14 17:30:00', N'Thử nghiệm Router'),
(38, 21, '2025-04-24 13:00:00', '2025-04-24 15:00:00', N'Thử nghiệm Loa'),
(40, 23, '2025-04-26 15:30:00', '2025-04-26 17:30:00', N'Họp lab cuối kỳ');

INSERT INTO ThongBao (MaND, TieuDe, NoiDung, NgayGui, DaDoc) VALUES
(3, N'Lịch đặt đã được duyệt', N'Lịch đặt thiết bị Dell OptiPlex 7090 ngày 01/03/2025 đã được duyệt.', '2025-03-01 10:05:00', 1),
(5, N'Lịch đặt của bạn bị từ chối', N'Lịch đặt máy chiếu BenQ MS550 ngày 05/03/2025 đã bị hủy.', '2025-03-05 12:00:00', 0),
(6, N'Nhắc nhở bảo trì', N'Thiết bị Arduino Mega 2560 cần bảo trì vào ngày 05/07/2025.', '2025-06-01 09:00:00', 0),
(8, N'Lịch đặt thành công', N'Lịch đặt Switch mạng ngày 08/03/2025 đã được duyệt.', '2025-03-08 11:00:00', 1),
(10, N'Thông báo hệ thống', N'Bạn có 2 lịch đặt đang chờ duyệt.', '2025-04-01 08:30:00', 0),
(12, N'Nhắc lịch sử dụng', N'Thiết bị Laptop HP Pavilion 15 đang được bạn sử dụng.', '2025-04-08 15:30:00', 1),
(15, N'Lịch bảo trì', N'Màn hình LG 27UL500 sẽ được kiểm tra ngày 01/06/2025.', '2025-05-20 14:00:00', 0),
(3, N'Hoàn thành bảo trì', N'Bảo trì máy chiếu Epson EB-X41 đã hoàn tất.', '2025-06-10 16:00:00', 1),
(7, N'Nhắc trả thiết bị', N'Vui lòng trả thiết bị Cisco Catalyst 2960 trước 10:00 ngày mai.', '2025-03-09 09:00:00', 0),
(9, N'Lịch đặt mới', N'Bạn có lịch đặt mới cần xác nhận.', '2025-04-05 10:00:00', 1),
(11, N'Cập nhật hệ thống', N'Hệ thống đã cập nhật thêm chức năng thông báo.', '2025-04-15 08:00:00', 0),
(13, N'Thông báo từ Admin', N'Phòng SE Lab 101 sẽ bảo trì toàn bộ thiết bị ngày 01/08/2025.', '2025-07-20 14:00:00', 0),
(16, N'Lịch sử sử dụng', N'Bạn đã sử dụng 5 thiết bị trong tháng này.', '2025-04-30 17:00:00', 1),
(20, N'Nhắc lịch bảo trì', N'Thiết bị MacBook Pro M3 cần kiểm tra bảo hành.', '2025-08-15 09:00:00', 0),
(25, N'Chúc mừng', N'Bạn đã hoàn thành 10 lịch đặt thành công.', '2025-05-02 16:00:00', 1);

