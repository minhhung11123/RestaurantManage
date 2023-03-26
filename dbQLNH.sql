create database dbQLNH
go
use dbQLNH
go

create table TaiKhoan
(
	taiKhoan varchar(20) primary key,
	matKhau varchar(32),
	matKhau2 varchar(32),
	loaiTK int
)
go
create table NhanVien
(
	idNV int identity primary key,
	hoTenNV nvarchar(30),
	diaChi nvarchar(100),
	ngaySinh date,
	sdt char(10),
	luongCoBan int,
	phuCap int,
	soCa int,
	taiKhoan varchar(20) references TaiKhoan(taiKhoan)
)
go
create table Ban
(
	idBan int identity primary key,
	tenBan nvarchar(30),
	trangThai int
)
go
create table LoaiMonAn
(
	idLoai int identity primary key,
	tenLoai nvarchar(50)
)
go
create table MonAn
(
	idMA int identity primary key,
	tenMon nvarchar(50),
	idLoai int references LoaiMonAn(idLoai),
	giaTien int
)
go
create table KhuyenMai
(
	idMaKM int identity primary key,
	loaiKM nvarchar(50),
	tyLeGiamGia float
)
go
create table HoaDon
(
	idHD int identity primary key,
	idNV int references NhanVien(idNV),
	idBan int references Ban(idBan),
	thoiGianVao datetime,
	thoiGianRa datetime,
	idMaKM int,
	trangThai int,
	tongTien int
)
go
create table CTHoaDon
(
	id int identity primary key,
	idHD int references HoaDon(idHD),
	idMA int references MonAn(idMA),
	soLuong int,
)
go
create table Kho
(
	idSanPham int identity primary key,
	tenSanPham nvarchar(50),
	loaiSanPham nvarchar(50),
	soLuong int,
	nhaCungCap nvarchar(50),
	ngayNhapKho datetime,
	diaChi nvarchar(100),
	SDT varchar(10),
	tongTien int
)
go

insert into TaiKhoan values ('admin', '21232f297a57a5a743894a0e4a801fc3', '21232f297a57a5a743894a0e4a801fc3', 0)
insert into TaiKhoan values ('123', '202cb962ac59075b964b07152d234b70', '202cb962ac59075b964b07152d234b70', 1)
go

insert into NhanVien (hoTenNV,taiKhoan) values ('admin', 'admin')
insert into NhanVien values (N'Nguyễn Phương Nam', N'123 Thọ Nam', '5/12/1995', 0123456789, 30000, 100000, 20, '123')
go

insert into LoaiMonAn
values (N'Thức uống'),(N'Rượu'),(N'Khai vị'),(N'Hải sản'),(N'Bò'),(N'Combo'),(N'Tráng miệng'),(N'Khác')
go

--ten mon an, loai, gia tien
insert into MonAn
values  (N'Tôm Hùm Alaska nướng phô mai',4,1000000),
		(N'Bia Budweiser',1,400000),
		(N'Rượu Ripassco',2,1000000),
		(N'Súp tổ Yến',3,500000),
		(N'Bò Cube nướng',5,4000000),
		(N'Combo 1',6,10000000),
		(N'Bánh Crepe Sầu Riêng',7,200000)
go

declare @i int = 1
while @i <= 20
begin
	Insert dbo.Ban values (N'Bàn ' + cast(@i as nvarchar(30)), 0)
	set @i = @i + 1
end
go

insert into KhuyenMai values (N'Không có', 0)
insert into KhuyenMai values (N'5%', 0.05)
go

create proc GetTableList
as
	select * from Ban
go

create proc GetNVList
as
select * from NhanVien
go
 
 
create proc GetFoodList
as
select ma.idMA as N'ID Món ăn', ma.tenMon as N'Tên món', lma.tenLoai as N'Tên loại', ma.giaTien as N'Giá tiền' from LoaiMonAn lma, MonAn ma where ma.idLoai=lma.idLoai
go

create proc GetFoodListBy(@id int)
as
select ma.idMA as N'ID Món ăn', ma.tenMon as N'Tên món', lma.tenLoai as N'Tên loại', ma.giaTien as N'Giá tiền' from LoaiMonAn lma, MonAn ma where ma.idLoai=lma.idLoai and ma.idLoai = @id
go

create proc GetMenuBill(@id int)
as
	select ma.tenMon, ct.soLuong, ma.giaTien, ma.giaTien*ct.soLuong as tongCong from MonAn ma, HoaDon hd, CTHoaDon ct
	where ma.idMA = ct.idMA and hd.idHD = ct.idHD and hd.idBan = @id and hd.trangThai = 0
go

create proc InsertBill (@idNV int, @idTable int)
as
begin
	insert into dbo.HoaDon values (@idNV, @idTable, GETDATE(), null, null, 0, null)
end
go

create proc InsertBillInfo (@idBill int, @idFood int, @count int)
as
begin
	Declare @isExitsBillInfo int
	Declare @foodCount int = 1
	select @isExitsBillInfo = idHD, @foodCount = soLuong from dbo.CTHoaDon where idHD = @idBill and idMA = @idFood
	if (@isExitsBillInfo > 0)
	begin
		Declare @newCount int = @count + @foodCount
		if (@newCount > 0)
			Update dbo.CTHoaDon set soLuong = @count + @foodCount where idHD = @idBill and idMA = @idFood 
		else
			Delete dbo.CTHoaDon where idHD = @idBill and idMA = @idFood
	end
	else
	begin
		if (@count > 0)
			insert into dbo.CTHoaDon values (@idBill, @idFood, @count)
	end
end
go

create trigger UpdateBillInfo
on dbo.CTHoaDon for insert, update
as
begin
	declare @idBill int
	select @idBill = idHD from inserted
	declare @idTable int
	select @idTable = idBan from dbo.HoaDon where idHD = @idBill and trangThai = 0
	declare @count int 
	select @count = COUNT(*) from dbo.CTHoaDon where idHD = @idBill
	if (@count > 0)
		update	dbo.Ban set trangThai = 1 where idBan = @idTable
	else
	begin
		update dbo.Ban set trangThai = 0 where idBan = @idTable
		--delete dbo.HoaDon where idBan = @idTable
	end
end
go

create trigger UpdateBill
on dbo.HoaDon for update
as
begin
	declare @idBill int
	select @idBill = idHD from inserted
	declare @idTable int
	select @idTable = idBan from dbo.HoaDon where idHD = @idBill
	declare @count int = 0
	select @count = COUNT(*) from dbo.HoaDon where idBan = @idTable and trangThai = 0
	if (@count = 0)
		update dbo.Ban set trangThai = 0 where idBan = @idTable
end
go

create proc ChuyenBan
@idTable1 int, @idTable2 int, @idNV int
as begin
	declare @idFirstBill int
	declare @idSecondBill int
	declare @check1 int = 1
	declare @check2 int = 1
	declare @date1 datetime
	declare @date2 datetime
	select @idSecondBill = idHD from dbo.HoaDon where idBan = @idTable2 and trangThai = 0
	select @idFirstBill = idHD from dbo.HoaDon where idBan = @idTable1 and trangThai = 0
	if (@idFirstBill is null)
	begin
		insert into dbo.HoaDon values (@idNV, @idTable1, GETDATE(), null, null, 0, null)
		select @idFirstBill = max(idHD) from dbo.HoaDon where idBan = @idTable1 and trangThai = 0

	end 
	select @check1 = COUNT(*) from dbo.CTHoaDon where idHD = @idFirstBill
	if (@idSecondBill is null)
	begin
		insert into dbo.HoaDon values (@idNV, @idTable2, GETDATE(), null, null, 0, null)
		select @idSecondBill = max(idHD) from dbo.HoaDon where idBan = @idTable2 and trangThai = 0

	end
	select @check2 = COUNT(*) from dbo.CTHoaDon where idHD = @idSecondBill
	select id into IDBillInfoTable from dbo.CTHoaDon where idHD = @idSecondBill
	update dbo.CTHoaDon set idHD = @idSecondBill where idHD = @idFirstBill
	update dbo.CTHoaDon set idHD = @idFirstBill where id in (select * from IDBillInfoTable)
	drop table IDBillInfoTable
	select @date1 = thoiGianVao from dbo.HoaDon where idHD = @idFirstBill
	select @date2 = thoiGianVao from dbo.HoaDon where idHD = @idSecondBill
	update dbo.HoaDon set thoiGianVao = @date1 where idHD = @idSecondBill
	update dbo.HoaDon set thoiGianVao = @date2 where idHD = @idFirstBill
	if (@check1 = 0)
	begin
		update dbo.Ban set trangThai = 0 where idBan = @idTable2
		delete dbo.HoaDon where idBan = @idTable2
	end
	if (@check2 = 0)
	begin
		update dbo.Ban set trangThai = 0 where idBan = @idTable1
		delete dbo.HoaDon where idBan = @idTable1
	end
end
go

create proc GopBan
@idTable1 int, @idTable2 int, @idNV int
as begin
	declare @idFirstBill int
	declare @idSecondBill int
	declare @check int = 1
	select @idSecondBill = idHD from dbo.HoaDon where idBan = @idTable2 and trangThai = 0
	select @idFirstBill = idHD from dbo.HoaDon where idBan = @idTable1 and trangThai = 0
	if (@idFirstBill is null)
	begin
		insert into dbo.HoaDon values (@idNV, @idTable1, GETDATE(), null, null, 0, null)
		select @idFirstBill = max(idHD) from dbo.HoaDon where idBan = @idTable1 and trangThai = 0

	end 
	if (@idSecondBill is null)
	begin
		insert into dbo.HoaDon values (@idNV, @idTable2, GETDATE(), null, null, 0, null)
		select @idSecondBill = max(idHD) from dbo.HoaDon where idBan = @idTable2 and trangThai = 0

	end
	update dbo.CTHoaDon set idHD = @idSecondBill where idHD = @idFirstBill
	select @check = COUNT(*) from dbo.CTHoaDon where idHD = @idSecondBill
	if (@check = 0)
	begin
		update dbo.Ban set trangThai = 0 where idBan = @idTable2
		delete dbo.HoaDon where idBan = @idTable2
	end
	update dbo.Ban set trangThai = 0 where idBan = @idTable1
	delete dbo.HoaDon where idBan = @idTable1
end
go

create proc ShowHistoryBill
@date1 datetime, @date2 datetime
as
begin
	select hd.idHD as [ID Hóa Đơn], b.tenBan as [Tên Bàn], nv.hoTenNV as [Tên Nhân Viên], thoiGianVao as [Thời Gian Vào], thoiGianRa as [Thời Gian Ra],
		   km.loaiKM as [Loại Khuyến Mãi], tongTien as [Tổng Tiền]
	from dbo.HoaDon hd, dbo.Ban b, dbo.KhuyenMai km, dbo.NhanVien nv
	where hd.idBan = b.idBan and hd.idNV = nv.idNV and hd.idMaKM = km.idMaKM and thoiGianRa between @date1 and @date2
end
go

create proc ShowBillInRP
@idHD int
as
	select * from HoaDon hd, CTHoaDon ct, MonAn ma, Ban b, NhanVien nv, KhuyenMai km where hd.trangThai = 1 and km.idMaKM = hd.idMaKM and nv.idNV = hd.idNV and b.idBan = hd.idBan and hd.idHD = ct.idHD and ma.idMA = ct.idMA and ct.idHD = @idHD
go

create proc ReportDTNgay
@date date
as
	select ma.tenMon, SUM(ct.soLuong) as tong, ma.giaTien * sum(ct.soLuong) as tongTien, convert(date, @date) as ngay
	from HoaDon hd, CTHoaDon ct, MonAn ma where hd.idHD = ct.idHD and ma.idMA = ct.idMA and convert(date, hd.thoiGianRa) = @date
	group by ma.tenMon, ma.giaTien
go

create proc ReportDTThang
@date date
as
begin
	select day(hd.thoiGianRa) as N'Ngày', sum(ct.soLuong * ma.giaTien) as N'Tổng tiền', MONTH(@date) as m, YEAR(@date) as y
	from CTHoaDon ct, HoaDon hd, MonAn ma where hd.idHD = ct.idHD and ma.idMA = ct.idMA and MONTH(hd.thoiGianRa) = MONTH(@date) and YEAR(hd.thoiGianRa) = year(@date)
	group by day(hd.thoiGianRa)
end
go

create proc ReportDTNam
@date date
as
begin
	select month(hd.thoiGianRa) as N'Tháng', sum(ct.soLuong * ma.giaTien) as N'Tổng tiền', YEAR(@date) as y
	from CTHoaDon ct, HoaDon hd, MonAn ma where hd.idHD = ct.idHD and ma.idMA = ct.idMA and YEAR(hd.thoiGianRa) = year(@date)
	group by month(hd.thoiGianRa)
end
go

