USE [master]
GO
/****** Object:  Database [MyPham]    Script Date: 11/12/2022 4:32:05 CH ******/
CREATE DATABASE [MyPham]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MyPham', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS02\MSSQL\DATA\MyPham.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MyPham_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS02\MSSQL\DATA\MyPham_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MyPham] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MyPham].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MyPham] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MyPham] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MyPham] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MyPham] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MyPham] SET ARITHABORT OFF 
GO
ALTER DATABASE [MyPham] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MyPham] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MyPham] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MyPham] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MyPham] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MyPham] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MyPham] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MyPham] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MyPham] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MyPham] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MyPham] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MyPham] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MyPham] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MyPham] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MyPham] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MyPham] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MyPham] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MyPham] SET RECOVERY FULL 
GO
ALTER DATABASE [MyPham] SET  MULTI_USER 
GO
ALTER DATABASE [MyPham] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MyPham] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MyPham] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MyPham] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MyPham] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MyPham] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [MyPham] SET QUERY_STORE = OFF
GO
USE [MyPham]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 11/12/2022 4:32:05 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[username] [nvarchar](225) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[address] [nvarchar](255) NOT NULL,
	[phone] [nvarchar](50) NOT NULL,
	[phone2] [nvarchar](50) NULL,
	[address2] [nvarchar](255) NULL,
	[type] [nvarchar](max) NULL,
	[name] [nvarchar](250) NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 11/12/2022 4:32:05 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[ProductID] [int] NOT NULL,
	[OrderID] [int] NOT NULL,
	[Quantity] [int] NULL,
	[Price] [decimal](18, 0) NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC,
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderImport]    Script Date: 11/12/2022 4:32:05 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderImport](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CodeOrder] [varchar](250) NULL,
	[MaNV] [varchar](250) NULL,
	[CreateDated] [datetime] NULL,
	[Total] [int] NULL,
	[Note] [nvarchar](250) NULL,
	[ImportLocation] [nvarchar](500) NULL,
 CONSTRAINT [PK_OrderImport] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderImportDetail]    Script Date: 11/12/2022 4:32:05 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderImportDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderImportId] [int] NULL,
	[ProductId] [int] NULL,
	[Quantity] [int] NULL,
	[Price] [decimal](18, 0) NULL,
	[TotalPrice] [decimal](18, 0) NULL,
	[CreatedDate] [datetime] NULL,
	[Note] [nvarchar](500) NULL,
 CONSTRAINT [PK_OrderImportDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 11/12/2022 4:32:05 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[Username] [nvarchar](16) NULL,
	[Status] [int] NULL,
	[Address] [nvarchar](255) NULL,
	[Phone] [nchar](10) NULL,
	[Total] [float] NULL,
	[TypePaymet] [nvarchar](max) NULL,
	[StatusPayment] [nvarchar](max) NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 11/12/2022 4:32:05 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[img] [nvarchar](100) NULL,
	[description] [nvarchar](500) NULL,
	[price] [float] NULL,
	[count] [int] NULL,
	[pricefordistributors] [float] NULL,
	[priceCustom] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 11/12/2022 4:32:05 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[MaNV] [varchar](250) NULL,
 CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Accounts] ([username], [password], [address], [phone], [phone2], [address2], [type], [name]) VALUES (N'hailx', N'123', N'hà nội', N'0345801986', N'0345801986', N'hà nội', N'1', N'Lê xuân hải')
INSERT [dbo].[Accounts] ([username], [password], [address], [phone], [phone2], [address2], [type], [name]) VALUES (N'hungnv', N'123', N'thanh xuân ', N'0345801763', N'0345801763', N'thanh xuân ', N'0', N'Nguyên văn hưng')
INSERT [dbo].[Accounts] ([username], [password], [address], [phone], [phone2], [address2], [type], [name]) VALUES (N'Tri', N'1234', N'số 3 ấp Hàng Gòn xã Lộc An huyện Long Thành Đồng Nai', N'0937456440', N'0937456440', N'số 3 ấp Hàng Gòn xã Lộc An huyện Long Thành Đồng Nai', N'0', NULL)
GO
INSERT [dbo].[OrderDetails] ([ProductID], [OrderID], [Quantity], [Price]) VALUES (1, 3, 3, CAST(6000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetails] ([ProductID], [OrderID], [Quantity], [Price]) VALUES (1, 10, 1, CAST(2000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetails] ([ProductID], [OrderID], [Quantity], [Price]) VALUES (1, 17, 1, CAST(2000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetails] ([ProductID], [OrderID], [Quantity], [Price]) VALUES (1, 21, 4, CAST(80 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetails] ([ProductID], [OrderID], [Quantity], [Price]) VALUES (1, 22, 1, CAST(15 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetails] ([ProductID], [OrderID], [Quantity], [Price]) VALUES (2, 3, 3, CAST(3000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetails] ([ProductID], [OrderID], [Quantity], [Price]) VALUES (2, 16, 3, CAST(3000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetails] ([ProductID], [OrderID], [Quantity], [Price]) VALUES (2, 17, 0, CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetails] ([ProductID], [OrderID], [Quantity], [Price]) VALUES (2, 18, 1, CAST(30 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetails] ([ProductID], [OrderID], [Quantity], [Price]) VALUES (2, 22, 1, CAST(30 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetails] ([ProductID], [OrderID], [Quantity], [Price]) VALUES (4, 9, 1, CAST(3000 AS Decimal(18, 0)))
GO
SET IDENTITY_INSERT [dbo].[OrderImport] ON 

INSERT [dbo].[OrderImport] ([Id], [CodeOrder], [MaNV], [CreateDated], [Total], [Note], [ImportLocation]) VALUES (15, N'phieu001', N'h001', CAST(N'2022-12-11T00:00:00.000' AS DateTime), 0, N'', N'Ha Noi')
SET IDENTITY_INSERT [dbo].[OrderImport] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderImportDetail] ON 

INSERT [dbo].[OrderImportDetail] ([Id], [OrderImportId], [ProductId], [Quantity], [Price], [TotalPrice], [CreatedDate], [Note]) VALUES (17, 15, 3, 100, CAST(10 AS Decimal(18, 0)), CAST(1000 AS Decimal(18, 0)), NULL, N'abc')
SET IDENTITY_INSERT [dbo].[OrderImportDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([ID], [Name], [CreateDate], [Username], [Status], [Address], [Phone], [Total], [TypePaymet], [StatusPayment]) VALUES (21, N'Order-20221211160111', CAST(N'2022-12-11T16:01:11.793' AS DateTime), N'Tri', 0, N'số 3 ấp Hàng Gòn xã Lộc An huyện Long Thành Đồng Nai', N'0937456440', 80, N'tructiep', N'Kiểm tra thanh toán')
INSERT [dbo].[Orders] ([ID], [Name], [CreateDate], [Username], [Status], [Address], [Phone], [Total], [TypePaymet], [StatusPayment]) VALUES (22, N'Order-20221211160140', CAST(N'2022-12-11T16:01:40.407' AS DateTime), N'hailx', 0, N'hà nội', N'0345801986', 45, N'tructiep', N'Kiểm tra thanh toán')
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([id], [name], [img], [description], [price], [count], [pricefordistributors], [priceCustom]) VALUES (1, N'product 1', N'p1.png', N'a', 20, 3000, 15, NULL)
INSERT [dbo].[Products] ([id], [name], [img], [description], [price], [count], [pricefordistributors], [priceCustom]) VALUES (2, N'product 2', N'p2.png', N'b', 50, 4000, 30, NULL)
INSERT [dbo].[Products] ([id], [name], [img], [description], [price], [count], [pricefordistributors], [priceCustom]) VALUES (3, N'product 3', N'p3.png', N'c', 30, 5000, 20, NULL)
INSERT [dbo].[Products] ([id], [name], [img], [description], [price], [count], [pricefordistributors], [priceCustom]) VALUES (4, N'product 4', N'p4.png', N'd', 40, 1000, 20, NULL)
INSERT [dbo].[Products] ([id], [name], [img], [description], [price], [count], [pricefordistributors], [priceCustom]) VALUES (5, N'product 5', N'p5.png', N'e', 60, 6000, 30, NULL)
INSERT [dbo].[Products] ([id], [name], [img], [description], [price], [count], [pricefordistributors], [priceCustom]) VALUES (6, N'product 6', N'p6.png', N'f', 70, 7000, 50, NULL)
INSERT [dbo].[Products] ([id], [name], [img], [description], [price], [count], [pricefordistributors], [priceCustom]) VALUES (7, N'product 7', N'p7.png', N'g', 80, 5000, 50, NULL)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Staff] ON 

INSERT [dbo].[Staff] ([Id], [Name], [MaNV]) VALUES (1, N'Lê Xuân Hải', N'h001')
INSERT [dbo].[Staff] ([Id], [Name], [MaNV]) VALUES (2, N'Nguyễn Văn Hưng', N'h002')
SET IDENTITY_INSERT [dbo].[Staff] OFF
GO
USE [master]
GO
ALTER DATABASE [MyPham] SET  READ_WRITE 
GO
