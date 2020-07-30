--TAO CO SO DU LIEU--
Use Master
GO
If Exists(Select * From Sys.databases Where Name='BanGiayNam')
Drop Database BanGiayNam
GO
create database BanGiayNam
go
USE BanGiayNam

GO

-- 1. Categorys ----------------------------------------
If Exists(Select * From Sys.tables Where Name='Categorys')
Drop Table Categorys
GO
CREATE TABLE Categorys 
(
	Id INT IDENTITY(1,1) NOT NULL primary key,
	Name nvarchar(255) NOT NULL,
	Slug varchar(255) NOT NULL,
	ParentId INT NOT NULL DEFAULT '0',
	Orders INT NULL,
	Metakey NVARCHAR(155) NULL,
	Metadesc NVARCHAR(155) NULL,
	Created_at datetime NULL,
	Created_by INT NULL DEFAULT '1',
	Updated_at datetime NULL,
	Updated_by INT NULL DEFAULT '1',
	StateId INT NULL DEFAULT '1'
)
GO


-- 2. Contacts  --------------------------------------------
If Exists(Select * From Sys.tables Where Name='Contacts')
Drop Table Contacts
GO
CREATE TABLE Contacts 
(
	Id INT IDENTITY(1,1)	NOT NULL primary key,
	FullName nvarchar(64) NOT NULL,
	Email nvarchar(64) NOT NULL,
	Phone varchar(12) NOT NULL,
	Title varchar(64) NOT NULL,
	Detail text NOT NULL,
	Created_at datetime NULL,
	Updated_at datetime NULL,
	Updated_by INT NULL DEFAULT '1',
	StateId INT NULL DEFAULT '1'
)
GO

-- 3. Orders ------------------------------------------
If Exists(Select * From Sys.tables Where Name='Orders')
Drop Table Orders
GO
CREATE TABLE Orders 
(
	Id INT IDENTITY(1,1) NOT NULL primary key,
	CustemerId INT NOT NULL,
	CreateDate date NOT NULL,
	ExportDate date NULL,
	DeliveryAddress nvarchar(255) NULL,
	DeliveryName nvarchar(255) NULL,
	StateId INT NULL DEFAULT '1'
) 
GO
-- 4. Orderdetails --------------------------------------------------------
If Exists(Select * From Sys.tables Where Name='Orderdetails')
Drop Table Orderdetails
GO
CREATE TABLE Orderdetails 
(
	Id INT IDENTITY(1,1)	NOT NULL primary key,
	OrderId INT NOT NULL,
	ProductId INT NOT NULL,
	Price FLOAT NOT NULL,
	Quantity INT NOT NULL,
	Amount FLOAT NOT NULL
) 
GO
-- 5. Products-- --------------------------------------------------------
If Exists(Select * From Sys.tables Where Name='Products')
Drop Table Products
GO
CREATE TABLE Products 
(
	Id INT IDENTITY(1,1) NOT NULL primary key,
	CatId INT NOT NULL,
	Name nvarchar(255) NOT NULL,
	Slug varchar(255) NOT NULL,
	Img varchar(100) NOT NULL,
	Detail NVARCHAR(MAX) NOT NULL,
	Number INT NOT NULL,
	Price FLOAT NOT NULL,
	Price_sale FLOAT NOT NULL,
	Metakey NVARCHAR(155) NULL,
	Metadesc NVARCHAR(155) NULL,	
	Created_at datetime NULL,
	Created_by INT NULL DEFAULT '1',
	Updated_at datetime NULL,
	Updated_by INT NULL DEFAULT '1',
	StateId INT NULL DEFAULT '1'
)
GO

--6. Sliders-------------------------------------------
If Exists(Select * From Sys.tables Where Name='Sliders')
Drop Table Sliders
GO
CREATE TABLE Sliders 
(
	Id INT IDENTITY(1,1) NOT NULL primary key,
	Name nvarchar(255) NOT NULL,
	Link varchar(255) NOT NULL,
	Position varchar(100) NOT NULL,
	Img varchar(100) NOT NULL,
	Orders INT NULL,
	Created_at datetime NULL,
	Created_by INT NULL DEFAULT '1',
	Updated_at datetime NULL,
	Updated_by INT NULL DEFAULT '1',
	StateId INT NULL DEFAULT '1'
)
GO

-- 7. Topics ----------------------------------------
If Exists(Select * From Sys.tables Where Name='Topics')
Drop Table Topics
GO
CREATE TABLE Topics 
(
	Id INT IDENTITY(1,1) NOT NULL primary key,
	Name nvarchar(255) NOT NULL,
	Slug varchar(255) NOT NULL,
	ParentId INT NOT NULL DEFAULT '0',
	Orders INT NULL,
	Metakey NVARCHAR(155) NULL,
	Metadesc NVARCHAR(155) NULL,
	Created_at datetime NULL,
	Created_by INT NULL DEFAULT '1',
	Updated_at datetime NULL,
	Updated_by INT NULL DEFAULT '1',
	StateId INT NULL DEFAULT '1'
)
GO
-- 8. Users-- --------------------------------------------------------
If Exists(Select * From Sys.tables Where Name='Users')
Drop Table Users
GO
CREATE TABLE Users 
(
	Id INT IDENTITY(1,1)	NOT NULL primary key,
	FullName nvarchar(255) NOT NULL,
	UserName varchar(225) NOT NULL,
	Password varchar(40) NOT NULL,
	Email varchar(255) NOT NULL,
	Gender BIT NULL,
	Phone varchar(15) NOT NULL,
	Img varchar(255) NOT NULL,
	Access INT NOT NULL,
	Created_at datetime NULL,
	Created_by INT NULL DEFAULT '1',
	Updated_at datetime NULL,
	Updated_by INT NULL DEFAULT '1',
	StateId INT NULL DEFAULT '1'
)
GO
-- 9. post-- --------------------------------------------------------
If Exists(Select * From Sys.tables Where Name='post')
Drop Table Posts
GO
CREATE TABLE Posts 
	(
	Id INT IDENTITY(1,1)	NOT NULL primary key,
	CatId INT NOT NULL,
	Title nvarchar(255) NOT NULL,
	Slug varchar(255) NOT NULL,
	Detail NVARCHAR(MAX) NOT NULL,
	Img varchar(100) NOT NULL,
	Metakey NVARCHAR(155) NULL,
	Metadesc NVARCHAR(155) NULL,
	Created_at datetime NULL,
	Created_by INT NULL DEFAULT '1',
	Updated_at datetime NULL,
	Updated_by INT NULL DEFAULT '1',
	StateId INT NULL DEFAULT '1'
)
GO
-- 10. page-- --------------------------------------------------------
If Exists(Select * From Sys.tables Where Name='page')
Drop Table Pages
GO
CREATE TABLE Pages 
(
	Id INT IDENTITY(1,1)	NOT NULL primary key,
	Title varchar(225) NOT NULL,
	Content varchar(40) NOT NULL,
	Avartar varchar(100) NOT NULL,
	Slug varchar(255) NOT NULL,
)
GO
insert into Products
values(15,N'Giày thể thao','giaythethao','giaythethao.jpg',N'chi tiết sản phẩm',25,250000,180000,N'Metakey',N'Metades','2018-09-08 16:10:10',1,'2018-09-08 16:10:10',1,1)
insert into Products
values(15,N'Giày thể thao 1','giaythethao1','giaythethao1.jpg',N'chi tiết sản phẩm',25,350000,260000,N'Metakey',N'Metades','2018-09-08 16:10:10',1,'2018-09-08 16:10:10',1,1)
insert into Products
values(15,N'Giày thể thao 2','giaythethao2','giaythethao2.jpg',N'chi tiết sản phẩm',25,2700000,190000,N'Metakey',N'Metades','2018-09-08 16:10:10',1,'2018-09-08 16:10:10',1,1)
insert into Products
values(15,N'Dép ','dep1','dep1.jpg',N'chi tiết sản phẩm',25,100000,80000,N'Metakey',N'Metades','2018-09-08 16:10:10',1,'2018-09-08 16:10:10',1,1)
insert into Products
values(15,N'Dép','dep2','dep2.jpg',N'chi tiết sản phẩm',25,150000,100000,N'Metakey',N'Metades','2018-09-08 16:10:10',1,'2018-09-08 16:10:10',1,1)
insert into Products
values(15,N'Dép','dep3','dep3.jpg',N'chi tiết sản phẩm',25,170000,130000,N'Metakey',N'Metades','2018-09-08 16:10:10',1,'2018-09-08 16:10:10',1,1)
insert into Products
values(15,N'Giày lười','giayluoi','giayluoi.jpg',N'chi tiết sản phẩm',25,250000,180000,N'Metakey',N'Metades','2018-09-08 16:10:10',1,'2018-09-08 16:10:10',1,1)
insert into Products
values(15,N'Giày lười','giayluoi','giayluoi1.jpg',N'chi tiết sản phẩm',25,300000,250000,N'Metakey',N'Metades','2018-09-08 16:10:10',1,'2018-09-08 16:10:10',1,1)
insert into Products
values(15,N'Giày lười','giayluoi','giayluoi2.jpg',N'chi tiết sản phẩm',25,230000,120000,N'Metakey',N'Metades','2018-09-08 16:10:10',1,'2018-09-08 16:10:10',1,1)

insert into Products
values(15,N'Giày thể thao','giaythethao','giaythethao.jpg',N'chi tiết sản phẩm',25,250000,180000,N'Metakey',N'Metades','2018-09-08 16:10:10',1,'2018-09-08 16:10:10',1,1)
insert into Products
values(15,N'Giày thể thao 1','giaythethao1','giaythethao1.jpg',N'chi tiết sản phẩm',25,350000,260000,N'Metakey',N'Metades','2018-09-08 16:10:10',1,'2018-09-08 16:10:10',1,1)
insert into Products
values(15,N'Giày thể thao 2','giaythethao2','giaythethao2.jpg',N'chi tiết sản phẩm',25,2700000,190000,N'Metakey',N'Metades','2018-09-08 16:10:10',1,'2018-09-08 16:10:10',1,1)
insert into Products
values(15,N'Dép ','dep1','dep1.jpg',N'chi tiết sản phẩm',25,100000,80000,N'Metakey',N'Metades','2018-09-08 16:10:10',1,'2018-09-08 16:10:10',1,1)
insert into Products
values(15,N'Dép','dep2','dep2.jpg',N'chi tiết sản phẩm',25,150000,100000,N'Metakey',N'Metades','2018-09-08 16:10:10',1,'2018-09-08 16:10:10',1,1)
insert into Products
values(15,N'Dép','dep3','dep3.jpg',N'chi tiết sản phẩm',25,170000,130000,N'Metakey',N'Metades','2018-09-08 16:10:10',1,'2018-09-08 16:10:10',1,1)
insert into Products
values(15,N'Giày lười','giayluoi','giayluoi.jpg',N'chi tiết sản phẩm',25,250000,180000,N'Metakey',N'Metades','2018-09-08 16:10:10',1,'2018-09-08 16:10:10',1,1)
insert into Products
values(15,N'Giày lười','giayluoi','giayluoi1.jpg',N'chi tiết sản phẩm',25,300000,250000,N'Metakey',N'Metades','2018-09-08 16:10:10',1,'2018-09-08 16:10:10',1,1)
insert into Products
values(15,N'Giày lười','giayluoi','giayluoi2.jpg',N'chi tiết sản phẩm',25,230000,120000,N'Metakey',N'Metades','2018-09-08 16:10:10',1,'2018-09-08 16:10:10',1,1)
Insert into Sliders
Values(N'Hình ảnh 1',' Hinh-anh-1','slideshow','slider1.jpg',1,'2018-07-25 10:10:10',1,'2018-07-25 10:10:10',1,1)
INSERT INTO Sliders
VALUES(N'Hình ảnh 2',' Hinh-anh-2','slideshow','slider2.jpg',2,'2018-07-25 10:10:10',1,'2018-07-25 10:10:10',1,1)
INSERT INTO Sliders
VALUES(N'Hình ảnhc3',' Hinh-anh-3','slideshow','slider3.jpg',3,'2018-07-25 10:10:10',1,'2018-07-25 10:10:10',1,1)