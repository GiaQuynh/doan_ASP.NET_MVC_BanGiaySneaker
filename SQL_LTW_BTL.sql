CREATE DATABASE QL_GIAY_LTW
USE QL_GIAY_LTW


CREATE TABLE Brand (
	MaBrand INT,
	TenBrand NVARCHAR(50),
	CONSTRAINT PK_Brand PRIMARY KEY(MaBrand),
);

CREATE TABLE SanPham (
	MaSP INT,
	TenSP NVARCHAR(MAX),
	AnhSP VARCHAR(MAX),
	GiaBan DECIMAL(18,0),
	MauSac NVARCHAR(50),
	MoTa NVARCHAR(MAX),
	--ThoiGianBaoHanh INT,
	--NgayCapNhat DATE,
	--SoLuongTon INT,
	MaBrand INT,

  	CONSTRAINT PK_SanPham PRIMARY KEY(MaSP),
	CONSTRAINT FK_Brand FOREIGN KEY(MaBrand) REFERENCES Brand(MaBrand)
);

CREATE TABLE KhachHang (
	MaKH INT,
	HoTen NVARCHAR(50),
	NgaySinh DATETIME,
	GioiTinh NVARCHAR(3),
	DienThoai VARCHAR(50),
	TaiKhoan VARCHAR(50),
	MatKhau VARCHAR(50),
	Email NVARCHAR(100),
	DiaChi NChar(10)
	CONSTRAINT PK_KhachHang PRIMARY KEY(MaKH)
);

CREATE TABLE DonDatHang
(
	MaDonHang INT,
	NgayDat DATETIME,
	NgayGiao DATETIME,
	DaThanhToan BIT,
	TinhTrangGiaoHang BIT,	
	MaKH INT,
	CONSTRAINT PK_DonDatHang PRIMARY KEY(MaDonHang),
	CONSTRAINT FK_KhachHang FOREIGN KEY(MaKH) REFERENCES KhachHang(MaKH)
);

CREATE TABLE ChiTietDonHang
(
	MaDonHang INT,
	MaSP INT,
	SoLuong INT,
	DonGia DECIMAL(18,0),	
	CONSTRAINT PK_CTDonHang PRIMARY KEY(MaDonHang,MaSP),
	CONSTRAINT FK_DonHang FOREIGN KEY (MaDonHang) REFERENCES DonDatHang(MaDonHang),
	CONSTRAINT FK_SP FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
);

insert into Brand values (1, N'Nike'), (2, N'Adidas'), (3, N'Puma'), (4, N'NB'), (5, N'Converse'), (6, N'MLB'), (7, N'Vans');
select * from Brand

insert into SanPham values (1, N'Nike Air Force 107 LV8 ‘Split – Black Phantom’ FD2592-002', 'NK01.png', '4110000', N'Trắng', N'Giày Nike Air Force 1 ’07 LV8 ‘Split – Black Phantom’ FD2592-002 là một phiên bản mới của dòng giày Air Force 1 kinh điển của Nike. Giày có thiết kế phần upper được chia làm hai nửa với màu sắc khác nhau, tạo nên một vẻ ngoài độc đáo và bắt mắt.', 1)
insert into SanPham values (2, N'Nike Air Max 90 Triple White', 'NK02.jpg', '3100000', N'Trắng', N'Nike Air Max 90 là một trong những sản phẩm kinh điển của hãng thể thao Nike, trải qua gần 30 năm lịch sử Nike Air Max 90 đã làm say đắm hàng triệu người yêu giày trên thế giới. Với thiết kế đẹp mắt, form dáng chắc chắn, cảm giác di chuyển vô cùng thoải mái cùng với công nghệ ngày càng hoàn hảo của Nike, Air Max 90 là một sự lựa chọn tuyệt vời cho tất cả mọi người đặc biệt là bạn trẻ năng động.', 1)
insert into SanPham values (3, N'Nike Air Max 90 Triple White', 'NK02.jpg', '3100000', N'Trắng', N'Nike Air Max 90 là một trong những sản phẩm kinh điển của hãng thể thao Nike, trải qua gần 30 năm lịch sử Nike Air Max 90 đã làm say đắm hàng triệu người yêu giày trên thế giới. Với thiết kế đẹp mắt, form dáng chắc chắn, cảm giác di chuyển vô cùng thoải mái cùng với công nghệ ngày càng hoàn hảo của Nike, Air Max 90 là một sự lựa chọn tuyệt vời cho tất cả mọi người đặc biệt là bạn trẻ năng động.', 1)
insert into SanPham values (4, N'MLB Chunky Liner Mid Denim ‘Navy’ 3ASXCDN3N-50NYD', 'MLB01.png', '5500000', N'Xanh', N'Mua Giày MLB Chunky Liner Mid Denim ‘Navy’ 3ASXCDN3N-50NYD chính hãng 100% có sẵn tại Authentic Shoes. Giao hàng miễn phí trong 1 ngày.Cam kết đền tiền X5 nếu phát hiện Fake. Đổi trả miễn phí size. FREE vệ sinh giày trọn đời.', 6)
insert into SanPham values (5, N'All Star All Terrain', 'CON01.jpg', '3154444', N'Đen', N'Feel cozy exploring your environment in style with the Chuck Taylor All Star All Terrain. Find a burst of on-the-go cozy with a quilted tongue that gives you visible comfort and warmth. Weather-resistant materials and hiker-inspired details, like round laces, a heel pull, and a traction outsole are ready for wherever your adventures take you this fall.', 5)
insert into SanPham values (6, N'Nike Air Force 1 Mid By You', 'NK03.jpg', '4110000', N'Đỏ', N'Let your design shine in satin, keep it classic in canvas or get luxe with leather. No matter what you choose, these AF-1s are all about you. 12 colour choices and an additional Gum option for the sole mean your design is destined to be one of a kind, just like you.', 1)
insert into SanPham values (7, N'Chuck Taylor All Star City Trek Waterproof Boot', 'CON02.jpg', '2911794', N'Đen', N'When it comes to fall weather, expect the unexpected. Converse knows this, and thats why we designed the Chuck Taylor All Star City Trek WP. Its a timeless look, now in a boot, with four innovations to get you through fall: waterproofing, comfort, traction, and warmth. Non-wicking canvas helps to keep you dry, while gussets lock the tongue—and warmth—in place. A Converse Traction Utility tread pattern helps keep you steady on rainy commutes. Plus, it comes in easy-to-wear colors to help you ground your fall style.', 5)
insert into SanPham values (8, N'Vans Knu-Skool ‘Black White’ VN0009QC6BT', 'VA01.png', '2205000', N'Đen', N'Trong vũ trụ thời trang đa dạng và phong phú, Vans Knu Skool không chỉ đơn thuần là một sản phẩm, mà còn là một tác phẩm nghệ thuật đầy bất ngờ. Đôi giày này đã nhanh chóng ghi dấu ấn mạnh mẽ với sự sáng tạo tuyệt vời và sự kết hợp hoàn hảo giữa phong cách và tiện nghi. Với sắc đen huyền bí tạo nên sự lôi cuốn và viền trắng tinh tế, đôi giày này chắc chắn sẽ là điểm nhấn hoàn hảo cho bất kỳ bộ trang phục nào, đem đến sự tinh tế và sự phá cách cho mọi phong cách thời trang.', 7)
insert into SanPham values (9, N'Converse x DRKSHDW TURBODRK Chuck 70', 'CON03.jpg', '7900000 ', N'Đen', N'Rick Owens và Converse không phải lúc nào cũng có mối quan hệ công việc, nhưng cả hai tổ chức đã hợp tác trong vài năm qua để mang DRKSHDW TURBODRK Chuck 70 đến với công chúng. Gần đây, hình bóng tiên phong nổi lên với họa tiết ngựa vằn.Chất liệu lông bao phủ phần trên, ngoại trừ ngón chân. Các chi tiết màu đen tương phản xuất hiện dọc theo các mặt cắt và cột sống, với đồng nhãn hiệu trên lưỡi thuôn dài, miếng dán Một Ngôi sao ở giữa và biển số xe cũng chọn tông màu tối. Dưới chân, bộ phận duy nhất được trang bị lại giữ mọi thứ theo chủ đề, mặc dù đế giữa và đế ngoài không có bất kỳ điểm nào giống với con vật có sọc nói trên.', 5)
insert into SanPham values (10, N'MLB Chunky Wide Los Angeles ‘Pink’ 3ASXCCW3N-07PKS', 'MLB02.png', '4100000', N'Multi', N'Mua Giày MLB Chunky Wide Los Angeles ‘Pink’ 3ASXCCW3N-07PKS chính hãng 100% có sẵn tại Authentic Shoes. Giao hàng miễn phí trong 1 ngày. Cam kết đền tiền X5 nếu phát hiện Fake. Đổi trả miễn phí size. Dịch vụ vệ sinh trọn đời. MUA NGAY!', 6)
insert into SanPham values (11, N'Adidas NMD R1 "Glow Pink"', 'AD02.png', '3150000', N'Multi', N'Thân giày co giãn có các chi tiết phủ ngoài bằng TPU trong mờ giúp bảo vệ đôi chân khỏi thời tiết ẩm ướt. Lớp đệm đàn hồi mang đến cảm giác siêu thoải mái cho từng bước chân', 2)
insert into SanPham values (12, N'Adidas Monsters Inc. x Stan Smith ‘Mike & Sulley’ GZ5990"', 'AD03.png', '3150000', N'Multi', N'Mua Giày Adidas Monsters Inc. x Stan Smith ‘Mike & Sulley’ GZ5990 chính hãng 100% có sẵn tại Authentic Shoes. Giao hàng miễn phí trong 1 ngày. Cam kết đền tiền X5 nếu phát hiện Fake. Đổi trả miễn phí size. FREE vệ sinh giày trọn đời. MUA NGAY!', 2)
insert into SanPham values (13, N'Adidas Monsters Inc. x Stan Smith ‘Mike & Sulley’ GZ5990"', 'AD03.png', '3150000', N'Multi', N'Mua Giày Adidas Monsters Inc. x Stan Smith ‘Mike & Sulley’ GZ5990 chính hãng 100% có sẵn tại Authentic Shoes. Giao hàng miễn phí trong 1 ngày. Cam kết đền tiền X5 nếu phát hiện Fake. Đổi trả miễn phí size. FREE vệ sinh giày trọn đời. MUA NGAY!', 2)
insert into SanPham values (14, N'Adidas Monsters Inc. x Stan Smith ‘Mike & Sulley’ GZ5990"', 'AD03.png', '3150000', N'Multi', N'Mua Giày Adidas Monsters Inc. x Stan Smith ‘Mike & Sulley’ GZ5990 chính hãng 100% có sẵn tại Authentic Shoes. Giao hàng miễn phí trong 1 ngày. Cam kết đền tiền X5 nếu phát hiện Fake. Đổi trả miễn phí size. FREE vệ sinh giày trọn đời. MUA NGAY!', 2)
insert into SanPham values (15, N'Adidas Monsters Inc. x Stan Smith ‘Mike & Sulley’ GZ5990"', 'AD03.png', '3150000', N'Multi', N'Mua Giày Adidas Monsters Inc. x Stan Smith ‘Mike & Sulley’ GZ5990 chính hãng 100% có sẵn tại Authentic Shoes. Giao hàng miễn phí trong 1 ngày. Cam kết đền tiền X5 nếu phát hiện Fake. Đổi trả miễn phí size. FREE vệ sinh giày trọn đời. MUA NGAY!', 2)
insert into SanPham values (16, N'Adidas Monsters Inc. x Stan Smith ‘Mike & Sulley’ GZ5990"', 'AD03.png', '3150000', N'Multi', N'Mua Giày Adidas Monsters Inc. x Stan Smith ‘Mike & Sulley’ GZ5990 chính hãng 100% có sẵn tại Authentic Shoes. Giao hàng miễn phí trong 1 ngày. Cam kết đền tiền X5 nếu phát hiện Fake. Đổi trả miễn phí size. FREE vệ sinh giày trọn đời. MUA NGAY!', 2)

--delete SanPham

select * from SanPham

insert into KhachHang values 
(1, N'Trần Văn A', '2000-10-10 00:00:00.000', 'Nam', '0981174688','trva', 'tranva@gmail.com', '123456', 'TP.HCM'),
(2, N'Lê Thị C', '1993-02-12 00:00:00.000', N'Nữ', '0131174238','lec', 'lethc@gmail.com', '123abc', N'Hà Nội'),
(3, N'Nguyễn Văn B', '1985-12-31 00:00:00.000', 'Nam', '0321124688','ngb', 'ngb@gmail.com', 'zxcvb', 'TP.HCM');

CREATE TABLE NhanVien (
	MaNV INT,
	HoTenNV NVARCHAR(50),
	NgaySinhNV DATETIME,
	GioiTinhNV NVARCHAR(3),
	DienThoaiNV VARCHAR(50),
	TaiKhoanNV VARCHAR(50),
	MatKhauNV VARCHAR(50),
	EmailNV NVARCHAR(100),
	DiaChiNV NChar(10),
	ChucVuNC NChar(10),
	CONSTRAINT PK_NhanVien PRIMARY KEY(MaNV)
);

--CREATE TABLE ChucNang
--(
--	MaCN INT,
--	MaChucNang NVARCHAR(50),
--	TenChucNang NVARCHAR(50),
--	CONSTRAINT PK_ChucNang PRIMARY KEY(MaCN)
--);

--CREATE TABLE PhanQuyen
--(
--	MaNV INT,
--	MaCN INT,
--	GhiChu NVARCHAR(50),
--	CONSTRAINT PK_PhanQuyen PRIMARY KEY(MaNV, MACN),
--	CONSTRAINT FK_PhanQuyen_NhanVien FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
--	CONSTRAINT FK_PhanQuyen_ChucNang FOREIGN KEY (MaCN) REFERENCES ChucNang(MaCN)
--);

insert into NhanVien values 
(1, N'Admin 1', '2000-10-10 00:00:00.000', 'Nam', '0981174688','admin1', 'admin1@gmail.com', '123456', 'TP.HCM', 'Admin'),
(2, N'Admin 2', '1993-02-12 00:00:00.000', N'Nữ', '0131174238','admin2', 'admin2@gmail.com', '123abc', N'Hà Nội', 'Admin'),
(3, N'Admin 3', '1985-12-31 00:00:00.000', 'Nam', '0321124688','admin3', 'admin3@gmail.com', 'zxcvb', 'TP.HCM','NV');