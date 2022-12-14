-- NamHoc(NH_Ma, NH_NamHoc)
-- HocKi(HK_Ma, HK_Ten)
-- Khoi(Khoi_Ma, Khoi_Ten)
-- MonHoc(Mon_Ma, Mon_Ten)
-- ChucVu(CV_Ma, CV_Ten)
-- Quyen (Quyen_Ma, Quyen_Ten)
-- ChuyenMon (GV_Ma, MH_Ma)
-- LoaiDiem(LD_Ma, LD_Ten)
-- Lop(Lop_Ma, Lop_Ten, Khoi_Ma)
-- HocSinh(HS_Ma, HS_Ten, HS_DiaChi, HS_GioiTinh, HS_NgaySinh, HS_Gmail, HS_SDT)
-- GiaoVien(GV_Ma, GV_TenDN, HV_MatKhau GV_Ten, GV_DiaChi, GV_GioiTinh, GV_NgaySinh, GV_Gmail, GV_SDT, CV_Ma)
-- ChuNhiem(GV_Ma, Lop_Ma, NH_Ma)
-- HocTap( HS_Ma, Lop_Ma, NH_Ma)
-- GiangDay(GV_Ma, Lop_Ma, Mon_Ma, HK_Ma, NH_Ma)
-- ChiTietDiem(HS_Ma, HK_Ma, Mon_Ma, LD_Ma, CTD_Lan, CTD_Diem) 

-- Tạo database
create database QuanLiDiem
Go

use QuanLiDiem
Go

  -- Bảng Năm học
create table NamHoc(
	NH_Ma nvarchar(50) primary key,
	NH_Ten nvarchar(50)
)
Go

  -- Bảng Học kì
 create table HocKi(
	HK_Ma nvarchar(50) primary key,
	HK_Ten nvarchar(50)
)
Go

-- Bảng Khối
create table Khoi(
	Khoi_Ma nvarchar(50) primary key,
	Khoi_Ten nvarchar(50)
)
Go

-- Bảng Môn hoc
create table MonHoc(
	MH_Ma nvarchar(50) primary key,
	MH_Ten nvarchar(50)
)
Go

-- Bảng Chức vụ
create table ChucVu(
	CV_Ma nvarchar(50) primary key,
	CV_Ten nvarchar(50)
)
Go

-- Bảng quyen
create table Quyen(
	Quyen_Ma nvarchar(50) primary key,
	Quyen_Ten nvarchar(50)
)
Go



-- Bảng Loại điểm
create table LoaiDiem(
	LD_Ma nvarchar(50) primary key,
	LD_Ten nvarchar(50),
	LD_HeSo int
)
Go

-- Bảng Lớp
create table Lop(
	Lop_Ma nvarchar(50) primary key,
	Lop_Ten nvarchar(50),
	Khoi_Ma nvarchar(50),
	NH_Ma nvarchar(50)

	foreign key (Khoi_Ma) references Khoi(Khoi_Ma),
	foreign key (NH_Ma) references NamHoc(NH_Ma)
)
Go

-- Bảng Học sinh
create table HocSinh(
	HS_Ma nvarchar(50) primary key,
	HS_HoTen nvarchar(100) not null,
	HS_DiaChi nvarchar(100) default N'Chưa cập nhật',
	HS_GioiTinh nvarchar(50) default N'Chưa cập nhật',
	HS_Gmail nvarchar(100) default N'Chưa cập nhật',
	HS_NgaySinh nvarchar(50) default N'Chưa cập nhật',
	HS_SDT nvarchar(50) default N'Chưa cập nhật',
	Lop_Ma nvarchar(50)

	foreign key (Lop_Ma) references Lop(Lop_Ma)
)
Go

-- Bảng Giáo viên
create table GiaoVien(
	GV_Ma nvarchar(50) primary key,
	GV_HoTen nvarchar(100) not null,
	GV_TenDN nvarchar(50) not null,
	GV_MatKhau nvarchar(50) not null,
	GV_GioiTinh nvarchar(50) default N'Chưa cập nhật',
	GV_DiaChi nvarchar(100) default N'Chưa cập nhật',
	GV_NgaySinh  nvarchar(50) default N'Chưa cập nhật',
	GV_Gmail nvarchar(100)  default N'Chưa cập nhật',
	GV_SDT nvarchar(50) default N'Chưa cập nhật',
	Quyen_Ma nvarchar(50) default N'Q02',
	CV_Ma nvarchar(50)  default N'CV02'
	
	foreign key (CV_Ma) references ChucVu(CV_Ma),
	foreign key (Quyen_Ma) references Quyen(Quyen_Ma)
)
Go

-- Bang chuyen mon
create table ChuyenMon(
	GV_Ma nvarchar(50),
	MH_Ma nvarchar(50)

	primary key (GV_Ma, MH_Ma)
	foreign key (GV_Ma) references GiaoVien(GV_Ma),
	foreign key (MH_Ma) references MonHoc(MH_Ma)
)
Go

-- Bảng Chủ nhiệm
create table ChuNhiem(
	GV_Ma nvarchar(50),
	Lop_Ma nvarchar(50),
	NH_Ma nvarchar(50),

	primary key (GV_Ma, Lop_Ma, NH_Ma),
	foreign key (GV_ma) references GiaoVien(GV_Ma),
	foreign key (Lop_ma) references Lop(Lop_Ma),
	foreign key (NH_ma) references NamHoc(NH_Ma)

)
Go

-- Bảng Giảng day
create table GiangDay(
	GV_Ma nvarchar(50),
	Lop_Ma nvarchar(50),
	MH_Ma nvarchar(50),
	NH_Ma nvarchar(50),
	HK_Ma nvarchar(50),

	primary key (GV_Ma, Lop_Ma, MH_Ma, NH_Ma, HK_ma),
	foreign key (GV_ma) references GiaoVien(GV_Ma),
	foreign key (Lop_ma) references Lop(Lop_Ma),
	foreign key (MH_ma) references MonHoc(MH_Ma),
	foreign key (NH_ma) references NamHoc(NH_Ma),
	foreign key (HK_Ma) references HocKi(HK_Ma)
)
Go

-- Bang Chi tiết điểm
create table ChiTietDiem(
	HS_Ma nvarchar(50),
	HK_Ma nvarchar(50),
	MH_Ma nvarchar(50),
	LD_Ma nvarchar(50),
	CTD_Lan nvarchar(50),
	CTD_Diem float

	primary key (HS_Ma, HK_Ma, MH_Ma, LD_Ma, CTD_Lan),
	foreign key (HS_Ma) references HocSinh(HS_Ma),
	foreign key (HK_ma) references HocKi(HK_Ma),
	foreign key (MH_ma) references MonHoc(MH_Ma),
	foreign key (LD_ma) references LoaiDiem(LD_Ma)
)
Go

-- Bang nam hoc
insert into NamHoc values (N'NH01', N'2022-2023')
insert into NamHoc values (N'NH02', N'2023-2024')
insert into NamHoc values (N'NH03', N'2022-2025')	
Go

-- Bang hoc ki
insert into HocKi values (N'HK01', N'Hoc kì 1')
insert into HocKi values (N'HK02', N'Hoc kì 2')
Go

-- Bang khoi
insert into Khoi values (N'K01', N'Khối 10')
insert into Khoi values (N'K02', N'Khối 11')
insert into Khoi values (N'K03', N'Khối 12')
Go

-- Bang mon hoc
insert into MonHoc values (N'M01',N'Toán');
insert into MonHoc values (N'M02', N'Văn');
Go

-- Bang chuc vu
insert into ChucVu values (N'CV01', N'Hiệu trưởng')
insert into ChucVu values (N'CV02', N'Giáo viên')

-- Bang quyen
insert into Quyen values (N'Q01', N'Quản lí')
insert into Quyen values (N'Q02', N'Người dùng')


-- Bang loai diem
insert into LoaiDiem values (N'LD01', N'Kiểm tra miệng', 1)
insert into LoaiDiem values (N'LD02', N'Kiểm tra 15p', 1)
insert into LoaiDiem values (N'LD03', N'Kiểm tra 1 tiết', 2)
insert into LoaiDiem values (N'LD04', N'Thi', 2)

-- Bang Lop

insert into Lop values (N'L01', N'10A1', N'K01', N'NH01')
insert into Lop values (N'L02', N'10A2', N'K01', N'NH01')
insert into Lop values (N'L03', N'11A1', N'K02', N'NH01')
insert into Lop values (N'L04', N'12A1', N'K03', N'NH01')


-- Bang hoc sinh
insert into HocSinh values(N'HS01', N'Võ Huỳnh Đức', N'Vĩnh Long', N'Nam', N'duc@gmail.com', '11/02/2001', N'0366348236', N'L01')
insert into HocSinh values(N'HS02', N'Hồ Thị Minh Tuyền', N'Bến Tre', N'Nữ', N'tuyen@gmail.com','20/01/2001', N'0366348237', N'L01')
insert into HocSinh values(N'HS03', N'Nguyễn Vĩ Khang', N'Cần Thơ', N'Nam', N'khang@gmail.com','18/09/2001', N'0366348238', N'L02')
insert into HocSinh values(N'HS04', N'Bùi Chí Hải', N'Vĩnh Long', N'Nam', N'hai@gmail.com','15/08/2001', N'0366348239', N'L02')
insert into HocSinh values(N'HS05', N'Nguyễn Minh Phát', N'Vĩnh Long', N'Nam', N'phat@gmail.com','12/01/2001', N'0366348235', N'L02')


-- Bang giao vien
insert into GiaoVien values(N'GV01', N'Hiệu trưởng', N'admin123',N'0', N'Nam', N'Cần Thơ', '21/09/1996',N'admin@gmail.com',N'0123456789', N'Q01', N'CV01')
insert into GiaoVien (GV_Ma, GV_HoTen, GV_TenDN, GV_MatKhau) values(N'GV02', N'Bùi Hoàng Việt Anh',N'anh123',N'0')
insert into GiaoVien (GV_Ma, GV_HoTen, GV_TenDN, GV_MatKhau) values(N'GV03', N'Nguyễn Hoàng Đức', N'duc123',N'0')
insert into GiaoVien (GV_Ma, GV_HoTen, GV_TenDN, GV_MatKhau) values(N'GV04', N'Nguyễn Tiến Linh', N'linh123',N'0')

-- Bang chuyen mon
insert into ChuyenMon values ( N'GV04', N'M01') 
insert into ChuyenMon values ( N'GV04', N'M02') 
insert into ChuyenMon values ( N'GV02', N'M02') 
insert into ChuyenMon values ( N'GV03', N'M01') 
insert into ChuyenMon values ( N'GV03', N'M02') 


-- Bang chu nhiem
insert into ChuNhiem values ( N'GV02', N'L01', 'NH01') 
insert into ChuNhiem values ( N'GV03', N'L02', 'NH01') 

insert into ChuNhiem values ( N'GV04', N'L03', 'NH01') 
insert into ChuNhiem values ( N'GV05', N'L05', 'NH01') 

insert into ChuNhiem values ( N'Chua cap nhat', N'L06', 'NH01') 


-- Bang giang day
insert into GiangDay values ( N'GV03', N'L01', N'M01', N'NH01', N'HK01') 
insert into GiangDay values ( N'GV03', N'L02', N'M01', N'NH01', N'HK01') 
insert into GiangDay values ( N'GV04', N'L01', N'M02', N'NH01', N'HK01') 


-- Bang chi tiet diem
insert into ChiTietDiem values (N'HS01', N'HK01', 'M01', N'LD01', 1, 9) 
insert into ChiTietDiem values (N'HS01', N'HK01', 'M01', N'LD02', 1, 9) 
insert into ChiTietDiem values (N'HS01', N'HK01', 'M01', N'LD02', 2, 10) 
insert into ChiTietDiem values (N'HS01', N'HK01', 'M02', N'LD01', 1, 9) 
insert into ChiTietDiem values (N'HS02', N'HK01', 'M01', N'LD02', 2, 10) 
insert into ChiTietDiem values (N'HS03', N'HK01', 'M02', N'LD01', 1, 9) 
insert into ChiTietDiem values (N'HS01', N'HK02', 'M02', N'LD02', 1, 9) 
insert into ChiTietDiem values (N'HS01', N'HK02', 'M01', N'LD03', 2, 10) 

-- Tinh diem TBM
create procedure tbm(
 	@maHS nvarchar(50),
	@maNh nvarchar(50),
	@maHK nvarchar(50))
as
begin
	
	select MH_Ten as [Môn học], sum(CTD_Diem*LD_HeSo)/sum(LD_HeSo) as [TBM] into #temp from ChiTietDiem ct, LoaiDiem ld, MonHoc mh, HocSinh hs, lop l where ct.LD_Ma = ld.LD_Ma and ct.MH_Ma = mh.MH_Ma and ct.HS_Ma = hs.HS_Ma and hs.Lop_Ma = l.Lop_Ma and ct.HS_Ma = @maHS and HK_Ma = @maHK and NH_Ma = @maNh group by MH_Ten
	select ROUND(sum(tbm)/count(tbm), 1, 1) from #temp
	
end
