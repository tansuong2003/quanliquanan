-- Tạo CSDL QLQuanAn
USE QuanLyQuanAn
GO
-- 5. Quản lý kho nguyên liệu
--5.1 Tìm kiếm nguyên liệu
CREATE FUNCTION [dbo].[func_getIngreListByString] (@string NVARCHAR(50))
RETURNS @IngreList TABLE (MaNL VARCHAR(10), TenNL NVARCHAR(50), MaNCC
VARCHAR(10), SoLuong INT, DonVi NVARCHAR(10), TinhTrang NVARCHAR(10))
AS
BEGIN
 INSERT INTO @IngreList
 SELECT *
 FROM dbo.NguyenLieu
 WHERE CONCAT(MaNL, TenNL, MaNCC, DonVi, TinhTrang) LIKE N'%' + @string + '%'

 RETURN
END
GO

--5.2 Thêm nguyên liệu
CREATE PROCEDURE [dbo].[proc_themNguyenLieu]
	@MaNL nchar(10),
	@TenNL nvarchar(50),
	@MaNCC nchar(10),
	@SoLuong int,
	@DonVi nchar(10),
	@TinhTrang nchar(10)
AS
BEGIN
	BEGIN TRY
	--Thêm mới sản phẩm
		INSERT INTO dbo.NguyenLieu (MaNL, TenNL, MaNCC, SL, DonVi, TinhTrang)
		VALUES (@MaNL, @TenNL, @MaNCC, @SoLuong, @DonVi, @TinhTrang)
	END TRY
	BEGIN CATCH
		DECLARE @err NVARCHAR(MAX)
		SELECT @err = N'Lỗi ' + ERROR_MESSAGE()
		RAISERROR(@err, 16, 1)
	END CATCH
END

GO

--8. Quản lý nhân viên
--8.1 Thêm nhân viên
CREATE PROC [dbo].[proc_AddEmployee]
@manv nchar(10), @ho nvarchar(10), @ten nvarchar(10), @ns date, @gt nvarchar(3),
@dc nvarchar(100),
@sdt nchar(11), @macv nchar(10), @soca int, @thuong int, @ntd date, @ha image
AS
	INSERT INTO NhanVien (MaNV, HoNV, TenNV, NgaySinh, GioiTinh, DiaChi, SDT,
	MaCV, SoCa, Thuong, NgayTD)
	VALUES(@manv, @ho, @ten, @ns, @gt, @dc, @sdt, @macv, @soca, @thuong, @ntd)

GO

--@ha: thêm @ha vào Values
--8.2 Xóa nhân viên
CREATE PROCEDURE [dbo].[proc_DeleteEmployee]
 @MaNV nchar(10)
AS
BEGIN
	SET NOCOUNT ON;

	BEGIN TRANSACTION;
		BEGIN TRY
 -- Xóa dòng trong bảng OrderDetails có OrderID tương ứng
			DELETE FROM BangPhanCa WHERE MaNV = @MaNV;

 -- Xóa dòng trong bảng Orders có OrderID tương ứng
			DELETE FROM NhanVien WHERE MaNV = @MaNV;
		END TRY
		BEGIN CATCH
			DECLARE @err NVARCHAR(MAX)
			SELECT @err = N'Lỗi ' + ERROR_MESSAGE()
			RAISERROR(@err, 16, 1)
			ROLLBACK TRANSACTION;
			THROW;
		END CATCH
 COMMIT TRANSACTION;
END
GO
--8.3 Tìm kiếm nhân viên
CREATE PROC [dbo].[pro_SearchByMaNV]
 @MaNV nchar(10)
AS
BEGIN
 SELECT *
 FROM v_LoadEmployee
 WHERE MaNV = @MaNV
END

CREATE PROC [dbo].[pro_SearchBySDT]
 @SDT nchar(11)
AS
BEGIN
 SELECT *
 FROM v_LoadEmployee
 WHERE SDT = @SDT
END


CREATE PROC [dbo].[pro_SearchByTenCV]
 @TenCV nvarchar(50)
AS
BEGIN
 SELECT *
 FROM v_LoadEmployee
 WHERE TenCV = @TenCV
END
CREATE PROC [dbo].[pro_SearchByTenNV]
 @TenNV nvarchar(10)
AS
BEGIN
 SELECT *
 FROM v_LoadEmployee
 WHERE TenNV = @TenNV
END
GO
--8.4 Tính lương nhân viên	
CREATE FUNCTION func_tinhLuongNV(@thang INT, @nam INT) RETURNS TABLE
AS RETURN (
SELECT nv.MaNV,nv.HoNV,nv.TenNV ,nv.SoCa,
(nv.SoCa*cv.Luong*4 + nv.Thuong*(cv.Luong*2)) +
CASE WHEN dbo.func_tinhDoanhThuThang(@thang, @nam) > 100000000
THEN dbo.func_tinhDoanhThuThang(@thang, @nam)*0.01
ELSE 0
END AS Luong
FROM NhanVien nv
INNER JOIN CongViec cv ON nv.MaCV = cv.MaCV
)
GO
--8.5. Sửa thông tin nhân viên
CREATE PROC [dbo].[proc_EditEmployee]
 @manv nchar(10), @ho nvarchar(10), @ten nvarchar(10), @ngaysinh date,
 @gioitinh nvarchar(3), @diachi nvarchar(100), @sdt nchar(11), @macv
nchar(10),
 @soca int, @thuong int, @ngaytuyendung date, @hinhanh image
AS
BEGIN
	BEGIN TRY
		UPDATE NhanVien
			SET
			HoNV = @ho, TenNV = @ten, NgaySinh = @ngaysinh,
			GioiTinh = @gioitinh, DiaChi = @diachi, SDT = @sdt, MaCV = @macv,
			SoCa = @soca, Thuong = @thuong, NgayTD = @ngaytuyendung
			--HinhAnh = @hinhanh
			WHERE MaNV = @manv
	END TRY
	BEGIN CATCH
	DECLARE @err NVARCHAR(MAX)
		SELECT @err = N'Lỗi ' + ERROR_MESSAGE()
	RAISERROR(@err, 16, 1)
	END CATCH
END

--8.6 Trigger bắt lỗi khi thêm hoặc sửa thông tin nhân viên
CREATE TRIGGER trg_CheckNhanVien
ON NhanVien
FOR INSERT, UPDATE
AS
BEGIN
-- check MaNV
IF EXISTS (SELECT * FROM inserted WHERE TRIM(MaNV) = ' ')
BEGIN
 RAISERROR('Mã nhân viên không được để trống', 16, 1)
 ROLLBACK TRANSACTION
 RETURN
 END
IF NOT EXISTS (SELECT * FROM NhanVien WHERE MaNV IN (SELECT MaNV FROM
inserted))
BEGIN
 RAISERROR('Mã nhân viên đã tồn tại', 16, 1)
 ROLLBACK TRANSACTION
 RETURN
 END
-- check ho ten nhan vien
IF EXISTS (SELECT * FROM inserted WHERE TRIM(TenNV) = '' )
BEGIN
 RAISERROR('Tên nhân viên không được để trống', 16, 1)
 ROLLBACK TRANSACTION
 RETURN
 END
IF EXISTS (SELECT * FROM inserted WHERE TRIM(HoNV) = '')
BEGIN
 RAISERROR('Họ nhân viên không được để trống', 16, 1)
 ROLLBACK TRANSACTION
 RETURN
 END
IF EXISTS (SELECT 1 FROM inserted i INNER JOIN NhanVien n ON i.MaNV != n.MaNV
AND TRIM(i.HoNV) = TRIM(n.HoNV) AND TRIM(i.TenNV) = TRIM(n.TenNV))
BEGIN
 RAISERROR('Họ tên nhân viên đã tồn tại', 16, 1)
 ROLLBACK TRANSACTION
 RETURN
 END
-- check ngay sinh
IF EXISTS (
 SELECT * FROM inserted WHERE
datediff(year,inserted.NgaySinh,getdate())<(18)
 )
 BEGIN
 RAISERROR ('Nhân viên phải trên 18 tuổi', 16, 1)
 ROLLBACK TRANSACTION
 RETURN
 END
-- check dia chi
IF EXISTS (SELECT * FROM inserted WHERE TRIM(DiaChi) = '' )
BEGIN
 RAISERROR('Địa chỉ không được để trống', 16, 1)
 ROLLBACK TRANSACTION
 RETURN
 END
-- check so dien thoai
IF EXISTS (SELECT * FROM inserted WHERE TRIM(SDT) = '' )
BEGIN
 RAISERROR('Số điện thoại không được để trống', 16, 1)
 ROLLBACK TRANSACTION
 RETURN
 END
IF NOT EXISTS (SELECT * FROM inserted WHERE len(TRIM(SDT)) = (10))
BEGIN
 RAISERROR('Số điện thoại gồm 10 chữ số', 16, 1)
 ROLLBACK TRANSACTION
 RETURN
 END
IF EXISTS (SELECT 1 FROM inserted i INNER JOIN NhanVien n ON i.MaNV != n.MaNV
AND TRIM(i.SDT) = TRIM(n.SDT))
BEGIN
 RAISERROR('Số điện thoại đã tồn tại', 16, 1)
 ROLLBACK TRANSACTION
 RETURN
 END
-- check ngay tuyen dung
IF NOT EXISTS (
 SELECT * FROM inserted WHERE
(datediff(day,[NgayTD],getdate())>=(0))
 )
 BEGIN
 RAISERROR ('Ngày tuyển dụng không thể là trong tương lai', 16, 1)
 ROLLBACK TRANSACTION
 RETURN
 END
END