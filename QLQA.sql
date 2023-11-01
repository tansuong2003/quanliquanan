
-- Tạo CSDL QLQuanAn
USE QuanLyQuanAn
GO
-- Tạo Bảng 

CREATE TABLE CONGVIEC(
MaCV nchar(10) CONSTRAINT PK_CONGVIEC PRIMARY KEY,
TenCV nvarchar(50) NOT NULL,
Luong float check (Luong > 0)
)
GO

CREATE TABLE NHANVIEN(
MaNV nchar(10) CONSTRAINT PK_NHANVIEN PRIMARY KEY,
HoNV nvarchar(10) NOT NULL,
TenNV nvarchar(10) NOT NULL,
NgaySinh date check (DATEDIFF(year, NgaySinh, GETDATE())>=18),
GioiTinh nvarchar(3),
DiaChi nvarchar(100),
SDT nchar(11) check (len(SDT)=10),
MaCV nchar(10) CONSTRAINT FK_NHANVIEN_CV FOREIGN KEY REFERENCES
CONGVIEC(MaCV),
 SoCa int,
Thuong int,
NgayTD date check (DATEDIFF(day, NgayTD, GETDATE())>=0)
)
GO
CREATE TABLE KHACHHANG(
MaKH nchar(10) CONSTRAINT PK_KHACHHANG PRIMARY KEY,
TenKH nvarchar(50) NOT NULL,
SDT nchar(11) NOT NULL check (len(SDT)=10),
DiemTL int
)
GO
CREATE TABLE NHACUNGCAP(
MaNCC nchar(10) CONSTRAINT PK_NHACUNGCAP PRIMARY KEY,
TenNCC nvarchar(50) NOT NULL,
DiaChi nchar(100),
SDT nchar(10) NOT NULL check (len(SDT)=10)
)
GO

CREATE TABLE DONNHAPHANG(
MaDonNH nchar(10) CONSTRAINT PK_DONNHAPHANG PRIMARY KEY,
NgayNH date check (DATEDIFF(day, NgayNH, GETDATE())>=0),
TriGiaDonNH float NOT NULL,
MaNCC nchar(10) CONSTRAINT FK_DONNHAPHANG_NCC FOREIGN KEY REFERENCES
NHACUNGCAP(MaNCC),
 TinhTrang nvarchar(50)
)
GO

CREATE TABLE NGUYENLIEU(
MaNL nchar(10) CONSTRAINT PK_NGUYENLIEU PRIMARY KEY,
TenNL nvarchar(50) NOT NULL,
MaNCC nchar(10) CONSTRAINT FK_NGUYENLIEU_NCC FOREIGN KEY REFERENCES
NHACUNGCAP(MaNCC),
SL int check (SL>0),
DonVi nchar(10),
TinhTrang nchar(10)
)
GO
CREATE TABLE ChiTietDonNhap(
MaDonNH nchar(10) CONSTRAINT FK_ChiTietNH_DonNH FOREIGN KEY REFERENCES
DONNHAPHANG(MaDonNH),
MaNL nchar(10) CONSTRAINT FK_ChiTietNH_NL FOREIGN KEY REFERENCES
NGUYENLIEU(MaNL),
DonGia float,
SL int check (SL>0),
 DonVi nchar(10),
TongTien float
CONSTRAINT PK_ChiTietDonNhap PRIMARY KEY (MaDonNH, MaNL)
)
GO

CREATE TABLE LOAISP(
MaLoaiSP nchar(10) CONSTRAINT PK_LOAISP PRIMARY KEY,
TenLoaiSP nvarchar(50) NOT NULL
)
GO


CREATE TABLE SANPHAM(
MaSP nchar(10) CONSTRAINT PK_MaSP PRIMARY KEY,
TenSP nvarchar(50) NOT NULL,
DonGia float NOT NULL,
TinhTrang nchar(10) DEFAULT N'Hết hàng',
MaLoaiSP nchar(10) CONSTRAINT FK_SANPHAM_LoaiSP FOREIGN KEY REFERENCES
LOAISP
)
GO


CREATE TABLE UD(
MaUD nchar(10) CONSTRAINT PK_UD PRIMARY KEY,
TenUD nvarchar(50) NOT NULL,
ChietKhau int NOT NULL
)
GO


CREATE TABLE HOADON(
MaHD nchar(10) CONSTRAINT PK_HOADON PRIMARY KEY,
NgayDatHang date check (DATEDIFF(year, NgayDatHang, GETDATE())>=0),
MaKH nchar(10) CONSTRAINT FK_HOADON_KH FOREIGN KEY REFERENCES
KHACHHANG(MaKH),
MaNV nchar(10) CONSTRAINT FK_HOADON_NV FOREIGN KEY REFERENCES NHANVIEN(MaNV),
TriGiaHD int NOT NULL
)
GO
ALTER TABLE HOADON
ADD TrangThai NVARCHAR(40);
GO


CREATE TABLE ChiTietHD(
MaHD nchar(10) CONSTRAINT FK_ChiTietHD_HD FOREIGN KEY REFERENCES
HOADON(MaHD),
MaSP nchar(10) CONSTRAINT FK_ChiTietHD_SP FOREIGN KEY REFERENCES
SANPHAM(MaSP),
SL int check (SL > 0),
DonGia float,
TongTien float
CONSTRAINT PK_ChiTietHD PRIMARY KEY (MaHD, MaSP)
)
GO


CREATE TABLE HOADON_UD(
MaHD_UD nchar(10) CONSTRAINT PK_HOADON_UD PRIMARY KEY,
NgayDatHang date check (DATEDIFF(day, NgayDatHang, GETDATE())>=0),
MaUD nchar(10) CONSTRAINT FK_HOADON_UD_UD FOREIGN KEY REFERENCES
UD(MaUD),
MaNV nchar(10) CONSTRAINT FK_HOADON_UD_NV FOREIGN KEY REFERENCES
NHANVIEN(MaNV),
TriGiaDH int NOT NULL
)
GO

ALTER TABLE HOADON_UD
ADD TrangThai NVARCHAR(40);
GO

CREATE TABLE ChiTiet_HDUD(
MaHD_UD nchar(10) CONSTRAINT FK_ChiTietHDUD_HDUD FOREIGN KEY REFERENCES
HOADON_UD(MaHD_UD),
MaSP nchar(10) CONSTRAINT FK_ChiTietHDUD_SP FOREIGN KEY REFERENCES
SANPHAM(MaSP),
SL int check (SL>0),
DonGia float,
TongTien float
CONSTRAINT PK_ChiTietHDUD PRIMARY KEY (MaHD_UD, MaSP)
)
GO

CREATE TABLE CALAMVIEC(
MaCa nchar(10),
NgayLam date check (DATEDIFF(day, NgayLam, GETDATE())>=0),
GioBatDau nchar(10),
GioKetThuc nchar(10),
CONSTRAINT PK_CALAMVIEC PRIMARY KEY (MaCa, NgayLam)
)
GO


CREATE TABLE BangPhanCa(
MaCa nchar(10),
MaNV nchar(10) CONSTRAINT FK_PhanCa_NV FOREIGN KEY REFERENCES NHANVIEN(MaNV),
NgayLam date check (DATEDIFF(day, NgayLam, GETDATE())>=0),
CONSTRAINT PK_BangPhanCa PRIMARY KEY (MaCa,MaNV, NgayLam),
CONSTRAINT FK_PhanCa_Ca FOREIGN KEY (MaCa,NgayLam) REFERENCES CALAMVIEC(MaCa,
NgayLam)
)
GO

CREATE TABLE PhieuChi(
MaPC nchar(10) CONSTRAINT PK_PHIEUCHI PRIMARY KEY,
MaDonNH nchar(10) CONSTRAINT FK_PhieuChi_DonNH FOREIGN KEY REFERENCES
DONNHAPHANG(MaDonNH),
NgayXuatPhieu date check (DATEDIFF(day, NgayXuatPhieu, GETDATE())>=0),
SoTienChi float
)
GO


CREATE TABLE CheBien(
MaSP nchar(10) CONSTRAINT FK_CheBien_SP FOREIGN KEY REFERENCES SANPHAM(MaSP),
MaNL nchar(10) CONSTRAINT FK_CheBien_NL FOREIGN KEY REFERENCES
NGUYENLIEU(MaNL),
LieuLuong int,
DonVi nchar(10)
CONSTRAINT PK_CheBien PRIMARY KEY (MaSP,MaNL)
)
GO


--View
--Xem ca lam viec cua nhan vien trong ngay
CREATE VIEW V_CaLamTrongNgay AS
SELECT clv.*, nv.TenNV, nv.MaCV, cv.TenCV
FROM dbo.BangPhanCa pc
	JOIN dbo.NhanVien nv ON pc.MaNV = nv.MaNV
	JOIN dbo.CALAMVIEC clv ON pc.MaCa = clv.MaCa
	JOIN dbo.CONGVIEC cv ON nv.MaCV = cv.MaCV
WHERE clv.NgayLam = CONVERT(DATE, GETDATE())
GO

--Xem danh sach san pham
CREATE VIEW V_DanhSachSanPham AS
SELECT MaSP, TenSP, DonGia, TinhTrang
FROM dbo.SANPHAM
GO


--Xem so luong san pham da ban trong ngay
CREATE VIEW V_SoLuongSanPhamDaBanTrongNgay AS
SELECT sp.MaSP, SUM(cthd.SL) AS SoLuongDaBanTaiQuay, SUM(cthdUD.SL)
AS SoLuongDaBanQuaUD
FROM dbo.SanPham sp
JOIN dbo.ChiTietHD cthd ON sp.MaSP = cthd.MaSP
JOIN dbo.HOADON hd ON cthd.MaHD = hd.MaHD
JOIN dbo.ChiTiet_HDUD cthdUD ON sp.MaSP = cthdUD.MaSP
JOIN dbo.HOADON_UD hdUD ON cthdUD.MaHD_UD = hdud.MaHD_UD
WHERE hd.NgayDatHang = CONVERT(DATE, GETDATE()) AND hdud.NgayDatHang = CONVERT(DATE,
GETDATE())
GROUP BY sp.MaSP
GO

-- Xem thong tin nhan vien
CREATE VIEW V_ThongTinNhanVien AS
SELECT nv.TenNV, nv.NgaySinh, nv.SDT, nv.SoCa, nv.NgayTD, nv.Thuong,
cv.TenCV, cv.Luong
FROM dbo.NHANVIEN nv JOIN dbo.CONGVIEC cv ON nv.MaCV = cv.MaCV
GO

--Xem phieu chi trong ngay
CREATE VIEW V_PhieuChiTrongNgay AS
SELECT *
FROM dbo.PhieuChi pc
WHERE pc.NgayXuatPhieu = CONVERT(DATE,GETDATE())
GO

--Xem don nhap hang chua giao
CREATE VIEW V_DonNhapHangChuaGiao AS
SELECT *
FROM dbo.DONNHAPHANG dnh
WHERE TinhTrang = N'Chưa giao'
GO

--Trigger
--Trigger dat trang thai hoa don
CREATE TRIGGER set_HoaDon_TrangThai
ON HOADON
FOR INSERT
AS
BEGIN
	UPDATE HOADON
	SET TrangThai = 'Chưa thanh toán'
	WHERE MaHD IN (SELECT MaHD FROM INSERTED)
END;
GO

--Trigger thay doi so luong cua nguyen lieu moi khi ban duoc san pham

CREATE TRIGGER TG_CheBienSanPham
ON ChiTietHD
AFTER Insert
AS
Begin
		Declare @newMaSP nchar(10), @newSL int
		Select @newMaSP=ne.MaSP, @newSL=ne.SL
		From inserted ne
		IF (@newMaSP = 'SP01' OR @newMaSP = 'SP03')
			Begin
				UPDATE NGUYENLIEU
				SET SL = (SL*1000 - @newSL*(select TOP 1 LieuLuong
											from CheBien
											where MaSP=@newMaSP))/1000
				WHERE MaNL = 'BN'
			End
		IF (@newMaSP = 'SP03' OR @newMaSP = 'SP05')
			Begin
				UPDATE NGUYENLIEU
				SET SL = (SL*1000 - @newSL*(select TOP 1 LieuLuong
											from CheBien
											where MaSP=@newMaSP))/1000
				WHERE MaNL = 'CH'
			End
		IF (@newMaSP = 'SP03' OR @newMaSP = 'SP07'OR @newMaSP = 'SP08'OR @newMaSP = 'SP09')
			Begin
				UPDATE NGUYENLIEU
				SET SL = (SL*1000 - @newSL*(select TOP 1 LieuLuong
											from CheBien
											where MaSP=@newMaSP))/1000
				WHERE MaNL = 'D'
			End
		IF (@newMaSP = 'SP01' OR @newMaSP = 'SP02'OR @newMaSP = 'SP03'OR @newMaSP = 'SP05'
		OR @newMaSP = 'SP06'OR @newMaSP = 'SP07'OR @newMaSP = 'SP08')
			Begin
				UPDATE NGUYENLIEU
				SET SL = (SL*1000 - @newSL*(select TOP 1 LieuLuong
											from CheBien
											where MaSP=@newMaSP))/1000
				WHERE MaNL = 'DD'
			End

		IF (@newMaSP = 'SP01' OR @newMaSP = 'SP02'OR @newMaSP = 'SP03' OR @newMaSP = 'SP04' OR @newMaSP = 'SP05'
		OR @newMaSP = 'SP06'OR @newMaSP = 'SP08'OR @newMaSP = 'SP09')
			Begin
				UPDATE NGUYENLIEU
				SET SL = (SL*1000 - @newSL*(select TOP 1 LieuLuong
											from CheBien
											where MaSP=@newMaSP))/1000
				WHERE MaNL = 'DD'
			End

		IF (@newMaSP = 'SP02' OR @newMaSP = 'SP08')
			Begin
				UPDATE NGUYENLIEU
				SET SL = (SL*1000 - @newSL*(select TOP 1 LieuLuong
											from CheBien
											where MaSP=@newMaSP))/1000
				WHERE MaNL = 'HN'
			End

		IF (@newMaSP = 'SP01' OR @newMaSP = 'SP02' OR @newMaSP = 'SP04' OR @newMaSP = 'SP05'
		OR @newMaSP = 'SP06'OR @newMaSP = 'SP07'OR @newMaSP = 'SP08')
			Begin
				UPDATE NGUYENLIEU
				SET SL = (SL*1000 - @newSL*(select TOP 1 LieuLuong
											from CheBien
											where MaSP=@newMaSP))/1000
				WHERE MaNL = 'MA'
			End
		IF (@newMaSP = 'SP03' OR @newMaSP = 'SP04' OR @newMaSP = 'SP06')
			Begin
				UPDATE NGUYENLIEU
				SET SL = (SL*1000 - @newSL*(select TOP 1 LieuLuong
											from CheBien
											where MaSP=@newMaSP))/1000
				WHERE MaNL = 'MU'
			End
		IF (@newMaSP = 'SP02')
			Begin
				UPDATE NGUYENLIEU
				SET SL = (SL*1000 - @newSL*(select TOP 1 LieuLuong
											from CheBien
											where MaSP=@newMaSP))/1000
				WHERE MaNL = 'ND'
			End
		IF (@newMaSP = 'SP03' OR @newMaSP = 'SP05'OR @newMaSP = 'SP07' OR @newMaSP = 'SP08')
			Begin
				UPDATE NGUYENLIEU
				SET SL = (SL*1000 - @newSL*(select TOP 1 LieuLuong
											from CheBien
											where MaSP=@newMaSP))/1000
				WHERE MaNL = 'OT'
			End
		IF (@newMaSP = 'SP08')
			Begin
				UPDATE NGUYENLIEU
				SET SL = (SL*1000 - @newSL*(select TOP 1 LieuLuong
											from CheBien
											where MaSP=@newMaSP))/1000
				WHERE MaNL = 'SA'
			End
		IF (@newMaSP = 'SP05' OR @newMaSP = 'SP06')
			Begin
				UPDATE NGUYENLIEU
				SET SL = (SL*1000 - @newSL*(select TOP 1 LieuLuong
											from CheBien
											where MaSP=@newMaSP))/1000
				WHERE MaNL = 'SN'
			End
		IF (@newMaSP = 'SP01' OR @newMaSP = 'SP02'OR @newMaSP = 'SP03' OR @newMaSP = 'SP04' )
			Begin
				UPDATE NGUYENLIEU
				SET SL = (SL*1000 - @newSL*(select TOP 1 LieuLuong
											from CheBien
											where MaSP=@newMaSP))/1000
				WHERE MaNL = 'TH'
			End
		IF (@newMaSP = 'SP07' OR @newMaSP = 'SP08')
			Begin
				UPDATE NGUYENLIEU
				SET SL = (SL*1000 - @newSL*(select TOP 1 LieuLuong
											from CheBien
											where MaSP=@newMaSP))/1000
				WHERE MaNL = 'TG'
			End
		IF (@newMaSP = 'SP03')
			Begin
				UPDATE NGUYENLIEU
				SET SL = (SL*1000 - @newSL*(select TOP 1 LieuLuong
											from CheBien
											where MaSP=@newMaSP))/1000
				WHERE MaNL = 'THOM'
			End
		IF (@newMaSP = 'SP01' OR @newMaSP = 'SP02'OR @newMaSP = 'SP04' OR @newMaSP = 'SP08' OR @newMaSP = 'SP09')
			Begin
				UPDATE NGUYENLIEU
				SET SL = (SL*1000 - @newSL*(select TOP 1 LieuLuong
											from CheBien
											where MaSP=@newMaSP))/1000
				WHERE MaNL = 'TIU'
			End
		IF (@newMaSP = 'SP01' OR @newMaSP = 'SP05'
		OR @newMaSP = 'SP06'OR @newMaSP = 'SP07'OR @newMaSP = 'SP08')
			Begin
				UPDATE NGUYENLIEU
				SET SL = (SL*1000 - @newSL*(select TOP 1 LieuLuong
											from CheBien
											where MaSP=@newMaSP))/1000
				WHERE MaNL = 'TOI'
			End
		IF (@newMaSP = 'SP02' OR @newMaSP = 'SP04'OR @newMaSP = 'SP09')
			Begin
				UPDATE NGUYENLIEU
				SET SL = (SL*1000 - @newSL*(select TOP 1 LieuLuong
											from CheBien
											where MaSP=@newMaSP))/1000
				WHERE MaNL = 'TRG'
			End
			
End
GO

-- Trigger kiem tra xem nguyen lieu trong kho con du de dap ung so luong khach hang yeu cau hay khong
CREATE TRIGGER TG_SPHetHang
ON ChiTietHD
AFTER INSERT
AS
		BEGIN
			Declare @newMaSP nchar(10), @newSL int, @MaNLMin nchar(10), @SLMin int, @LieuLuongCan float
			Select @newMaSP = ne.MaSP, @newSL = ne.SL
			From inserted ne
			--
			Select @SLMin=min(NGUYENLIEU.SL)
			From NGUYENLIEU, CheBien
			Where NGUYENLIEU.MaNL = CheBien.MaNL
			and CheBien.MaSP = @newMaSP
			--
			Select TOP 1 @MaNLMin = NGUYENLIEU.MaNL, @LieuLuongCan = CheBien.LieuLuong
			From NGUYENLIEU, CheBien
			Where NGUYENLIEU.MaNL = CheBien.MaNL
			and CheBien.MaSP = @newMaSP
			and NGUYENLIEU.SL = @SLMin
			--
			IF (@newSL*@LieuLuongCan - @SLMin*1000 > 0)
					BEGIN
						UPDATE SanPham
						SET TinhTrang = 'Hết hàng'
						WHERE MaSP=@newMaSP
						ROLLBACK
					END
		END
GO


--Kiem tra trung lap so dien thoai cua khach hang
CREATE TRIGGER TG_TrungSDT
ON dbo.KHACHHANG
AFTER INSERT, UPDATE
AS
BEGIN
	-- Kiểm tra số điện thoại vừa thêm có bị trùng lặp
	IF EXISTS (
		SELECT *
		FROM inserted i
		WHERE EXISTS (
			SELECT *
			FROM dbo.KHACHHANG k
			WHERE k.SDT = i.SDT AND k.MaKH <> i.MaKH
		
		)
	)
	BEGIN
	-- Nếu trùng thì rollback
	--PRINT N'Số điện thoại đã tồn tại'
		ROLLBACK;
	END
END
GO



--Kiem tra ten san pham co bi trung khong
CREATE TRIGGER TG_TrungTenSP
ON dbo.SANPHAM
AFTER INSERT, UPDATE
AS
BEGIN
		-- Kiểm tra tên sản phẩm vừa thêm có bị trùng lặp
		IF EXISTS (
			SELECT *
			FROM inserted i
			WHERE EXISTS (
				SELECT *
				FROM dbo.SANPHAM sp
				WHERE sp.TenSP = i.TenSP AND sp.MaSP <> i.MaSP
			)
		)
		BEGIN
		-- Nếu trùng thì rollback
			RAISERROR ('Tên sản phẩm bị trùng', 16, 1)
			ROLLBACK;
		END
END
GO