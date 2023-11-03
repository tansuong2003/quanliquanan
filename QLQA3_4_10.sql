-- Tạo CSDL QLQuanAn
USE QuanLyQuanAn
GO
--3.QuanLyKHACHHANG
--Hàm tìm kiếm khách hàng
CREATE FUNCTION [dbo].[SearchTenKHBySDT](@SDT nchar(11))
RETURNS nvarchar(50)
AS
BEGIN
 DECLARE @TenKH nvarchar(50);
 SELECT @TenKH = TenKH FROM KHACHHANG WHERE SDT = @SDT;
 RETURN @TenKH;
END
GO

--Tạo mới khách hàng
CREATE PROCEDURE [dbo].[InsertNewKHACHHANG]
 @MaKH nchar(10),
 @TenKH nvarchar(50),
 @SDT nchar(11)
AS
BEGIN
 IF EXISTS (SELECT 1 FROM KHACHHANG WHERE SDT = @SDT)
 BEGIN
 RETURN;
 END
 INSERT INTO KHACHHANG (MaKH, TenKH, SDT, DiemTL)
 VALUES (@MaKH, @TenKH, @SDT, 0)
END
GO

--Trigger bắt lỗi khi thêm khách hàng mới
CREATE TRIGGER trg_InsertNewKHACHHANG
ON KHACHHANG
FOR INSERT, UPDATE
AS
BEGIN
 -- check MaKH
IF EXISTS (SELECT * FROM inserted WHERE TRIM(MaKH) = ' ')
BEGIN
 RAISERROR('Mã KH không được để trống', 16, 1)
 ROLLBACK TRANSACTION
 RETURN
 END
IF NOT EXISTS (SELECT * FROM KHACHHANG WHERE MaKH IN (SELECT MaKH FROM
inserted))
BEGIN
 RAISERROR('Mã KH đã tồn tại', 16, 1)
 ROLLBACK TRANSACTION
 RETURN
 END
-- check ten KH
IF EXISTS (SELECT * FROM inserted WHERE TRIM(TenKH) = ' ')
BEGIN
 RAISERROR('Tên KH không được để trống', 16, 1)
 ROLLBACK TRANSACTION
 RETURN
 END
-- check SDT
IF EXISTS (SELECT * FROM inserted WHERE TRIM(SDT) = ' ')
BEGIN
 RAISERROR('Mã KH không được để trống', 16, 1)
 ROLLBACK TRANSACTION
 RETURN
 END
IF NOT EXISTS (SELECT * FROM KHACHHANG WHERE SDT IN (SELECT SDT FROM
inserted))
BEGIN
 RAISERROR('SDT đã tồn tại', 16, 1)
 ROLLBACK TRANSACTION
 RETURN
 END
END;
GO

--4.Quản lý hóa đơn
--Xuất hóa đơn
CREATE PROCEDURE [dbo].[proc_AddHoaDon]
 @MaHD nchar(10),
 @NgayDatHang date,
 @MaKH nchar(10),
 @MaNV nchar(10),
 @TriGiaHD int
AS
BEGIN
 INSERT INTO HoaDon (MaHD, NgayDatHang, MaKH, MaNV, TriGiaHD)
 VALUES (@MaHD, @NgayDatHang, @MaKH, @MaNV, @TriGiaHD);
END;
GO

--Tìm kiếm hóa đơn
CREATE PROCEDURE [dbo].[proc_TimKiemHoaDon]
@NgayBatDau DATE,
@NgayKetThuc DATE
AS
BEGIN
SELECT *
FROM HoaDon
WHERE NgayDatHang BETWEEN
@NgayBatDau AND @NgayKetThuc
END
GO

--10. Quản lý phân ca
--Thêm ca cho nhân viên
CREATE PROC [dbo].[proc_PhanCa]
@maca nchar(10),
@manv nchar(10),
@dayOfWeek nchar(10)
AS
BEGIN
BEGIN TRY
INSERT INTO BangPhanCa
VALUES(@maca, @manv, @dayOfWeek)
END TRY
BEGIN CATCH
DECLARE @err NVARCHAR(MAX)
SELECT @err = N'Lỗi ' + ERROR_MESSAGE()
RAISERROR(@err, 16, 1)
END CATCH
END
GO

--Xóa ca làm việc của nhân viên
CREATE PROC [dbo].[proc_XoaPhanCa]
@manv nchar(10),
@maca nchar(10),
@ngay nchar(10)
AS
BEGIN
BEGIN TRY
DELETE FROM BangPhanCa
WHERE MaNV = @manv and
 MaCa = @maca and
 NgayLam = @ngay
END TRY
BEGIN CATCH
DECLARE @err NVARCHAR(MAX)
SELECT @err = N'Lỗi ' + ERROR_MESSAGE()
RAISERROR(@err, 16, 1)
END CATCH
END
GO