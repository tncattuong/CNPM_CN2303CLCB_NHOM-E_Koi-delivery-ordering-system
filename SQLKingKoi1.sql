USE master
GO

CREATE DATABASE KingKoi
GO

USE KingKoi
GO

-- Bảng Khách Hàng
DROP TABLE IF EXISTS Khach_Hang;--neu can sua bang 
CREATE TABLE Khach_Hang
(
    Ma_Khach NVARCHAR(10) PRIMARY KEY,
    Ten_Khach NVARCHAR(255),
    Gioi_Tinh_Khach BIT,
    Dia_Chi_Khach NVARCHAR(255),
    So_Dien_Thoai VARCHAR(15),
    Email VARCHAR(100) UNIQUE,
    Ngay_Tao DATETIME DEFAULT CURRENT_TIMESTAMP,
    Ngay_Chinh_Sua DATETIME DEFAULT CURRENT_TIMESTAMP
)
GO

-- Bảng Nhân Viên
DROP TABLE IF EXISTS Nhan_Vien;
CREATE TABLE Nhan_Vien
(
    Ma_Nhan_Vien NVARCHAR(10) PRIMARY KEY,
    Ho_Ten NVARCHAR(255),
    Tuoi INT,
    Gioi_Tinh BIT,
    Dia_Chi NVARCHAR(255),
    So_Dien_Thoai VARCHAR(15),
    Email VARCHAR(100) UNIQUE,
    Mat_Khau NVARCHAR(255),
    Them_Vao_Ngay DATETIME DEFAULT CURRENT_TIMESTAMP,
    Cap_Nhat_Vao_Ngay DATETIME DEFAULT CURRENT_TIMESTAMP
)
GO

-- Bảng Dịch Vụ Vận Chuyển
DROP TABLE IF EXISTS Dich_Vu_Van_Chuyen;
CREATE TABLE Dich_Vu_Van_Chuyen
(
    Ma_Van_Chuyen NVARCHAR(10) PRIMARY KEY,
    Ma_Don_Vi_Van_Chuyen NVARCHAR(10),
    Ma_Phuong_Thuc NVARCHAR(10),
    Ten_Don_Vi NVARCHAR(255),
    Ten_Van_Chuyen NVARCHAR(255),
    Gia_Cuoc INT,
    Ngay_Tao DATETIME DEFAULT CURRENT_TIMESTAMP,
    Ngay_Chinh_Sua DATETIME DEFAULT CURRENT_TIMESTAMP
)
GO

-- Bảng Đơn Hàng
DROP TABLE IF EXISTS Don_Hang;
CREATE TABLE Don_Hang
(
    Ma_Don_Hang INT PRIMARY KEY IDENTITY(1,1),
    Ma_Khach NVARCHAR(10),
    Ma_Nhan_Vien NVARCHAR(10),
    Ma_Van_Chuyen NVARCHAR(10),
    Ngay_Dat_Hang DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (Ma_Khach) REFERENCES Khach_Hang(Ma_Khach) ON DELETE CASCADE,
    FOREIGN KEY (Ma_Nhan_Vien) REFERENCES Nhan_Vien(Ma_Nhan_Vien) ON DELETE SET NULL,
    FOREIGN KEY (Ma_Van_Chuyen) REFERENCES Dich_Vu_Van_Chuyen(Ma_Van_Chuyen) ON DELETE SET NULL
)
GO
