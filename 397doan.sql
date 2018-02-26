USE [DOAN3970]
GO
/****** Object:  Table [dbo].[CHUONG_TRINH_HOC]    Script Date: 2/26/2018 4:28:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHUONG_TRINH_HOC](
	[ID_CHUONG_TRINH_HOC] [int] IDENTITY(1,1) NOT NULL,
	[ID_SINHVIEN] [int] NULL,
	[ID_MON_HOC] [int] NULL,
	[TINH_TRANG] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_CHUONG_TRINH_HOC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CHUYEN_NGANH]    Script Date: 2/26/2018 4:28:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHUYEN_NGANH](
	[ID_CHUYEN_NGANH] [int] IDENTITY(1,1) NOT NULL,
	[TEN_CHUYEN_NGANH] [nvarchar](500) NULL,
	[ID_KHOA] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_CHUYEN_NGANH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CT_PHIEU_DANG_KY]    Script Date: 2/26/2018 4:28:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CT_PHIEU_DANG_KY](
	[ID_CT_PHIEU_DANG_KY] [int] IDENTITY(1,1) NOT NULL,
	[ID_PHIEU_DANG_KY] [int] NULL,
	[ID_MON_HOC] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_CT_PHIEU_DANG_KY] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HOC_KY]    Script Date: 2/26/2018 4:28:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOC_KY](
	[ID_HOC_KY] [int] IDENTITY(1,1) NOT NULL,
	[TEN_HOC_KY] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_HOC_KY] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KHOA]    Script Date: 2/26/2018 4:28:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHOA](
	[ID_KHOA] [int] IDENTITY(1,1) NOT NULL,
	[TEN_KHOA] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_KHOA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LOAI_MON]    Script Date: 2/26/2018 4:28:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAI_MON](
	[ID_LOAI_MON] [int] IDENTITY(1,1) NOT NULL,
	[TEN_LOAI_MON] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_LOAI_MON] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MON_HOC]    Script Date: 2/26/2018 4:28:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MON_HOC](
	[ID_MON_HOC] [int] IDENTITY(1,1) NOT NULL,
	[MA_MON_HOC] [char](500) NOT NULL,
	[TEN_MON_HOC] [nvarchar](500) NULL,
	[SO_CHI] [int] NULL,
	[LOAI_DVHT] [nvarchar](500) NULL,
	[LOAI_HINH] [nvarchar](500) NULL,
	[MON_TIEN_QUYET] [nvarchar](500) NULL,
	[MON_SONG_HANH] [nvarchar](500) NULL,
	[MO_TA] [ntext] NULL,
	[ID_LOAI_MON] [int] NULL,
	[ID_CHUYEN_NGANH] [int] NULL,
	[TRANG_THAI] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_MON_HOC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NAM_HOC]    Script Date: 2/26/2018 4:28:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NAM_HOC](
	[ID_NAM_HOC] [int] IDENTITY(1,1) NOT NULL,
	[TEN_NAM_HOC] [char](500) NULL,
	[TRANGTHAI] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_NAM_HOC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PHIEU_DANG_KY]    Script Date: 2/26/2018 4:28:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIEU_DANG_KY](
	[ID_PHIEU_DANG_KY] [int] IDENTITY(1,1) NOT NULL,
	[ID_SINHVIEN] [int] NULL,
	[ID_HOC_KY] [int] NULL,
	[ID_NAM_HOC] [int] NULL,
	[TONG_SO_TIN_CHI] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_PHIEU_DANG_KY] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[QUYEN]    Script Date: 2/26/2018 4:28:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QUYEN](
	[ID_QUYEN] [int] IDENTITY(1,1) NOT NULL,
	[TEN_QUYEN] [nvarchar](500) NULL,
	[MO_TA] [ntext] NULL,
	[TRANG_THAI] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_QUYEN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SINH_VIEN]    Script Date: 2/26/2018 4:28:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SINH_VIEN](
	[ID_SINHVIEN] [int] IDENTITY(1,1) NOT NULL,
	[MA_SINH_VIEN] [char](500) NOT NULL,
	[TEN_SINH_VIEN] [nvarchar](500) NULL,
	[NGAY_SINH] [datetime] NULL,
	[CMND] [char](500) NULL,
	[DIEN_THOAI] [char](500) NULL,
	[DIA_CHI] [nvarchar](900) NULL,
	[EMAIL] [char](500) NULL,
	[ID_TAI_KHOAN] [int] NULL,
	[ID_CHUYEN_NGANH] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_SINHVIEN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TAIKHOAN]    Script Date: 2/26/2018 4:28:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TAIKHOAN](
	[ID_TAI_KHOAN] [int] IDENTITY(1,1) NOT NULL,
	[USERNAME] [nvarchar](500) NULL,
	[PASS] [nvarchar](500) NULL,
	[ID_QUYEN] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_TAI_KHOAN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[CHUONG_TRINH_HOC] ON 

INSERT [dbo].[CHUONG_TRINH_HOC] ([ID_CHUONG_TRINH_HOC], [ID_SINHVIEN], [ID_MON_HOC], [TINH_TRANG]) VALUES (1, 5, 1, 0)
INSERT [dbo].[CHUONG_TRINH_HOC] ([ID_CHUONG_TRINH_HOC], [ID_SINHVIEN], [ID_MON_HOC], [TINH_TRANG]) VALUES (2, 5, 2, 0)
INSERT [dbo].[CHUONG_TRINH_HOC] ([ID_CHUONG_TRINH_HOC], [ID_SINHVIEN], [ID_MON_HOC], [TINH_TRANG]) VALUES (3, 5, 3, 0)
INSERT [dbo].[CHUONG_TRINH_HOC] ([ID_CHUONG_TRINH_HOC], [ID_SINHVIEN], [ID_MON_HOC], [TINH_TRANG]) VALUES (4, 5, 4, 0)
INSERT [dbo].[CHUONG_TRINH_HOC] ([ID_CHUONG_TRINH_HOC], [ID_SINHVIEN], [ID_MON_HOC], [TINH_TRANG]) VALUES (5, 5, 5, 0)
INSERT [dbo].[CHUONG_TRINH_HOC] ([ID_CHUONG_TRINH_HOC], [ID_SINHVIEN], [ID_MON_HOC], [TINH_TRANG]) VALUES (6, 5, 6, 0)
INSERT [dbo].[CHUONG_TRINH_HOC] ([ID_CHUONG_TRINH_HOC], [ID_SINHVIEN], [ID_MON_HOC], [TINH_TRANG]) VALUES (7, 5, 7, 0)
INSERT [dbo].[CHUONG_TRINH_HOC] ([ID_CHUONG_TRINH_HOC], [ID_SINHVIEN], [ID_MON_HOC], [TINH_TRANG]) VALUES (8, 4, 1, 0)
INSERT [dbo].[CHUONG_TRINH_HOC] ([ID_CHUONG_TRINH_HOC], [ID_SINHVIEN], [ID_MON_HOC], [TINH_TRANG]) VALUES (9, 4, 2, 0)
INSERT [dbo].[CHUONG_TRINH_HOC] ([ID_CHUONG_TRINH_HOC], [ID_SINHVIEN], [ID_MON_HOC], [TINH_TRANG]) VALUES (10, 4, 3, 0)
INSERT [dbo].[CHUONG_TRINH_HOC] ([ID_CHUONG_TRINH_HOC], [ID_SINHVIEN], [ID_MON_HOC], [TINH_TRANG]) VALUES (11, 4, 4, 0)
INSERT [dbo].[CHUONG_TRINH_HOC] ([ID_CHUONG_TRINH_HOC], [ID_SINHVIEN], [ID_MON_HOC], [TINH_TRANG]) VALUES (12, 4, 5, 0)
INSERT [dbo].[CHUONG_TRINH_HOC] ([ID_CHUONG_TRINH_HOC], [ID_SINHVIEN], [ID_MON_HOC], [TINH_TRANG]) VALUES (13, 4, 6, 0)
INSERT [dbo].[CHUONG_TRINH_HOC] ([ID_CHUONG_TRINH_HOC], [ID_SINHVIEN], [ID_MON_HOC], [TINH_TRANG]) VALUES (14, 4, 7, 0)
SET IDENTITY_INSERT [dbo].[CHUONG_TRINH_HOC] OFF
SET IDENTITY_INSERT [dbo].[CHUYEN_NGANH] ON 

INSERT [dbo].[CHUYEN_NGANH] ([ID_CHUYEN_NGANH], [TEN_CHUYEN_NGANH], [ID_KHOA]) VALUES (1, N'Kỹ Thuật Mạng', 1)
INSERT [dbo].[CHUYEN_NGANH] ([ID_CHUYEN_NGANH], [TEN_CHUYEN_NGANH], [ID_KHOA]) VALUES (2, N'Công Nghệ Phần Mềm', 1)
INSERT [dbo].[CHUYEN_NGANH] ([ID_CHUYEN_NGANH], [TEN_CHUYEN_NGANH], [ID_KHOA]) VALUES (3, N'Thiết kế Đồ họa', 1)
INSERT [dbo].[CHUYEN_NGANH] ([ID_CHUYEN_NGANH], [TEN_CHUYEN_NGANH], [ID_KHOA]) VALUES (4, N'Hệ thống Thông tin Quản lý', 1)
INSERT [dbo].[CHUYEN_NGANH] ([ID_CHUYEN_NGANH], [TEN_CHUYEN_NGANH], [ID_KHOA]) VALUES (5, N'Xây Dựng Dân Dụng & Công Nghiệp', 2)
INSERT [dbo].[CHUYEN_NGANH] ([ID_CHUYEN_NGANH], [TEN_CHUYEN_NGANH], [ID_KHOA]) VALUES (6, N' Xây Dựng Cầu Đường ', 2)
INSERT [dbo].[CHUYEN_NGANH] ([ID_CHUYEN_NGANH], [TEN_CHUYEN_NGANH], [ID_KHOA]) VALUES (7, N'Công nghệ Quản lý Xây dựng', 2)
INSERT [dbo].[CHUYEN_NGANH] ([ID_CHUYEN_NGANH], [TEN_CHUYEN_NGANH], [ID_KHOA]) VALUES (8, N'Kiến Trúc Công Trình', 3)
INSERT [dbo].[CHUYEN_NGANH] ([ID_CHUYEN_NGANH], [TEN_CHUYEN_NGANH], [ID_KHOA]) VALUES (9, N'Thiết kế Nội thất', 3)
INSERT [dbo].[CHUYEN_NGANH] ([ID_CHUYEN_NGANH], [TEN_CHUYEN_NGANH], [ID_KHOA]) VALUES (10, N'Điện Tự động', 4)
INSERT [dbo].[CHUYEN_NGANH] ([ID_CHUYEN_NGANH], [TEN_CHUYEN_NGANH], [ID_KHOA]) VALUES (11, N'Thiết kế Số', 4)
INSERT [dbo].[CHUYEN_NGANH] ([ID_CHUYEN_NGANH], [TEN_CHUYEN_NGANH], [ID_KHOA]) VALUES (12, N'Điện Tử - Viễn Thông', 4)
INSERT [dbo].[CHUYEN_NGANH] ([ID_CHUYEN_NGANH], [TEN_CHUYEN_NGANH], [ID_KHOA]) VALUES (13, N'Ngành Công nghệ & Kỹ thuật Môi trường', 5)
INSERT [dbo].[CHUYEN_NGANH] ([ID_CHUYEN_NGANH], [TEN_CHUYEN_NGANH], [ID_KHOA]) VALUES (14, N'Công nghệ Thực phẩm', 6)
INSERT [dbo].[CHUYEN_NGANH] ([ID_CHUYEN_NGANH], [TEN_CHUYEN_NGANH], [ID_KHOA]) VALUES (15, N'Quản Trị Marketing', 7)
INSERT [dbo].[CHUYEN_NGANH] ([ID_CHUYEN_NGANH], [TEN_CHUYEN_NGANH], [ID_KHOA]) VALUES (16, N'Quản Trị Kinh Doanh Tổng Hợp', 7)
INSERT [dbo].[CHUYEN_NGANH] ([ID_CHUYEN_NGANH], [TEN_CHUYEN_NGANH], [ID_KHOA]) VALUES (17, N'Ngoại Thương (Quản trị Kinh doanh Quốc tế)', 8)
INSERT [dbo].[CHUYEN_NGANH] ([ID_CHUYEN_NGANH], [TEN_CHUYEN_NGANH], [ID_KHOA]) VALUES (18, N'Quản Trị Du Lịch Khách Sạn', 9)
INSERT [dbo].[CHUYEN_NGANH] ([ID_CHUYEN_NGANH], [TEN_CHUYEN_NGANH], [ID_KHOA]) VALUES (19, N'Quản Trị Du Lịch Lữ Hành', 9)
INSERT [dbo].[CHUYEN_NGANH] ([ID_CHUYEN_NGANH], [TEN_CHUYEN_NGANH], [ID_KHOA]) VALUES (20, N'Kinh doanh Thương mại', 10)
INSERT [dbo].[CHUYEN_NGANH] ([ID_CHUYEN_NGANH], [TEN_CHUYEN_NGANH], [ID_KHOA]) VALUES (21, N'Tài chính Doanh nghiệp', 11)
INSERT [dbo].[CHUYEN_NGANH] ([ID_CHUYEN_NGANH], [TEN_CHUYEN_NGANH], [ID_KHOA]) VALUES (22, N'Ngân Hàng', 11)
INSERT [dbo].[CHUYEN_NGANH] ([ID_CHUYEN_NGANH], [TEN_CHUYEN_NGANH], [ID_KHOA]) VALUES (23, N'Kế Toán Kiểm Toán', 12)
INSERT [dbo].[CHUYEN_NGANH] ([ID_CHUYEN_NGANH], [TEN_CHUYEN_NGANH], [ID_KHOA]) VALUES (24, N'Kế Toán Doanh Nghiệp', 12)
INSERT [dbo].[CHUYEN_NGANH] ([ID_CHUYEN_NGANH], [TEN_CHUYEN_NGANH], [ID_KHOA]) VALUES (25, N'Tiếng Anh Biên - Phiên dịch', 13)
INSERT [dbo].[CHUYEN_NGANH] ([ID_CHUYEN_NGANH], [TEN_CHUYEN_NGANH], [ID_KHOA]) VALUES (26, N'Tiếng Anh Du lịch', 13)
INSERT [dbo].[CHUYEN_NGANH] ([ID_CHUYEN_NGANH], [TEN_CHUYEN_NGANH], [ID_KHOA]) VALUES (27, N'Văn - Báo chí', 14)
INSERT [dbo].[CHUYEN_NGANH] ([ID_CHUYEN_NGANH], [TEN_CHUYEN_NGANH], [ID_KHOA]) VALUES (28, N'Việt Nam học - Văn hóa Du lịch', 14)
INSERT [dbo].[CHUYEN_NGANH] ([ID_CHUYEN_NGANH], [TEN_CHUYEN_NGANH], [ID_KHOA]) VALUES (29, N'Quan hệ Quốc tế', 14)
INSERT [dbo].[CHUYEN_NGANH] ([ID_CHUYEN_NGANH], [TEN_CHUYEN_NGANH], [ID_KHOA]) VALUES (30, N'Điều dưỡng Đa khoa', 15)
INSERT [dbo].[CHUYEN_NGANH] ([ID_CHUYEN_NGANH], [TEN_CHUYEN_NGANH], [ID_KHOA]) VALUES (31, N'Dược ', 15)
INSERT [dbo].[CHUYEN_NGANH] ([ID_CHUYEN_NGANH], [TEN_CHUYEN_NGANH], [ID_KHOA]) VALUES (32, N'Bác sĩ Đa khoa', 15)
INSERT [dbo].[CHUYEN_NGANH] ([ID_CHUYEN_NGANH], [TEN_CHUYEN_NGANH], [ID_KHOA]) VALUES (33, N'Luật Kinh tế', 16)
SET IDENTITY_INSERT [dbo].[CHUYEN_NGANH] OFF
SET IDENTITY_INSERT [dbo].[CT_PHIEU_DANG_KY] ON 

INSERT [dbo].[CT_PHIEU_DANG_KY] ([ID_CT_PHIEU_DANG_KY], [ID_PHIEU_DANG_KY], [ID_MON_HOC]) VALUES (21, 10, 1)
INSERT [dbo].[CT_PHIEU_DANG_KY] ([ID_CT_PHIEU_DANG_KY], [ID_PHIEU_DANG_KY], [ID_MON_HOC]) VALUES (22, 10, 2)
INSERT [dbo].[CT_PHIEU_DANG_KY] ([ID_CT_PHIEU_DANG_KY], [ID_PHIEU_DANG_KY], [ID_MON_HOC]) VALUES (23, 10, 3)
INSERT [dbo].[CT_PHIEU_DANG_KY] ([ID_CT_PHIEU_DANG_KY], [ID_PHIEU_DANG_KY], [ID_MON_HOC]) VALUES (24, 10, 4)
INSERT [dbo].[CT_PHIEU_DANG_KY] ([ID_CT_PHIEU_DANG_KY], [ID_PHIEU_DANG_KY], [ID_MON_HOC]) VALUES (25, 10, 6)
INSERT [dbo].[CT_PHIEU_DANG_KY] ([ID_CT_PHIEU_DANG_KY], [ID_PHIEU_DANG_KY], [ID_MON_HOC]) VALUES (26, 10, 7)
INSERT [dbo].[CT_PHIEU_DANG_KY] ([ID_CT_PHIEU_DANG_KY], [ID_PHIEU_DANG_KY], [ID_MON_HOC]) VALUES (27, 11, 5)
INSERT [dbo].[CT_PHIEU_DANG_KY] ([ID_CT_PHIEU_DANG_KY], [ID_PHIEU_DANG_KY], [ID_MON_HOC]) VALUES (28, 11, 1)
INSERT [dbo].[CT_PHIEU_DANG_KY] ([ID_CT_PHIEU_DANG_KY], [ID_PHIEU_DANG_KY], [ID_MON_HOC]) VALUES (29, 11, 2)
INSERT [dbo].[CT_PHIEU_DANG_KY] ([ID_CT_PHIEU_DANG_KY], [ID_PHIEU_DANG_KY], [ID_MON_HOC]) VALUES (30, 11, 3)
INSERT [dbo].[CT_PHIEU_DANG_KY] ([ID_CT_PHIEU_DANG_KY], [ID_PHIEU_DANG_KY], [ID_MON_HOC]) VALUES (31, 11, 6)
INSERT [dbo].[CT_PHIEU_DANG_KY] ([ID_CT_PHIEU_DANG_KY], [ID_PHIEU_DANG_KY], [ID_MON_HOC]) VALUES (32, 11, 4)
INSERT [dbo].[CT_PHIEU_DANG_KY] ([ID_CT_PHIEU_DANG_KY], [ID_PHIEU_DANG_KY], [ID_MON_HOC]) VALUES (33, 12, 5)
INSERT [dbo].[CT_PHIEU_DANG_KY] ([ID_CT_PHIEU_DANG_KY], [ID_PHIEU_DANG_KY], [ID_MON_HOC]) VALUES (34, 12, 1)
INSERT [dbo].[CT_PHIEU_DANG_KY] ([ID_CT_PHIEU_DANG_KY], [ID_PHIEU_DANG_KY], [ID_MON_HOC]) VALUES (35, 12, 4)
INSERT [dbo].[CT_PHIEU_DANG_KY] ([ID_CT_PHIEU_DANG_KY], [ID_PHIEU_DANG_KY], [ID_MON_HOC]) VALUES (36, 12, 3)
INSERT [dbo].[CT_PHIEU_DANG_KY] ([ID_CT_PHIEU_DANG_KY], [ID_PHIEU_DANG_KY], [ID_MON_HOC]) VALUES (37, 12, 7)
SET IDENTITY_INSERT [dbo].[CT_PHIEU_DANG_KY] OFF
SET IDENTITY_INSERT [dbo].[HOC_KY] ON 

INSERT [dbo].[HOC_KY] ([ID_HOC_KY], [TEN_HOC_KY]) VALUES (1, N'I')
INSERT [dbo].[HOC_KY] ([ID_HOC_KY], [TEN_HOC_KY]) VALUES (2, N'II')
SET IDENTITY_INSERT [dbo].[HOC_KY] OFF
SET IDENTITY_INSERT [dbo].[KHOA] ON 

INSERT [dbo].[KHOA] ([ID_KHOA], [TEN_KHOA]) VALUES (1, N'Công nghệ Thông tin')
INSERT [dbo].[KHOA] ([ID_KHOA], [TEN_KHOA]) VALUES (2, N'Xây dựng')
INSERT [dbo].[KHOA] ([ID_KHOA], [TEN_KHOA]) VALUES (3, N'Kiến trúc')
INSERT [dbo].[KHOA] ([ID_KHOA], [TEN_KHOA]) VALUES (4, N'Điện - Điện tử')
INSERT [dbo].[KHOA] ([ID_KHOA], [TEN_KHOA]) VALUES (5, N'Công nghệ Môi trường')
INSERT [dbo].[KHOA] ([ID_KHOA], [TEN_KHOA]) VALUES (6, N'Công nghệ Thực phẩm')
INSERT [dbo].[KHOA] ([ID_KHOA], [TEN_KHOA]) VALUES (7, N'Quản trị Kinh doanh')
INSERT [dbo].[KHOA] ([ID_KHOA], [TEN_KHOA]) VALUES (8, N'Ngoại Thương (Quản trị Kinh doanh Quốc tế)')
INSERT [dbo].[KHOA] ([ID_KHOA], [TEN_KHOA]) VALUES (9, N'Du lịch')
INSERT [dbo].[KHOA] ([ID_KHOA], [TEN_KHOA]) VALUES (10, N'Kinh doanh Thương mại')
INSERT [dbo].[KHOA] ([ID_KHOA], [TEN_KHOA]) VALUES (11, N'Tài chính - Ngân hàng')
INSERT [dbo].[KHOA] ([ID_KHOA], [TEN_KHOA]) VALUES (12, N'Kế toán')
INSERT [dbo].[KHOA] ([ID_KHOA], [TEN_KHOA]) VALUES (13, N'Ngoại ngữ')
INSERT [dbo].[KHOA] ([ID_KHOA], [TEN_KHOA]) VALUES (14, N'Khoa học Xã hội & Nhân văn')
INSERT [dbo].[KHOA] ([ID_KHOA], [TEN_KHOA]) VALUES (15, N'Y - Dược')
INSERT [dbo].[KHOA] ([ID_KHOA], [TEN_KHOA]) VALUES (16, N'Luật Kinh tế')
SET IDENTITY_INSERT [dbo].[KHOA] OFF
SET IDENTITY_INSERT [dbo].[LOAI_MON] ON 

INSERT [dbo].[LOAI_MON] ([ID_LOAI_MON], [TEN_LOAI_MON]) VALUES (1, N'ĐẠI CƯƠNG')
INSERT [dbo].[LOAI_MON] ([ID_LOAI_MON], [TEN_LOAI_MON]) VALUES (2, N'GIÁO DỤC THỂ CHẤT & QUỐC PHÒNG')
INSERT [dbo].[LOAI_MON] ([ID_LOAI_MON], [TEN_LOAI_MON]) VALUES (3, N'ĐẠI CƯƠNG NGÀNH')
INSERT [dbo].[LOAI_MON] ([ID_LOAI_MON], [TEN_LOAI_MON]) VALUES (4, N'CHUYÊN NGÀNH')
SET IDENTITY_INSERT [dbo].[LOAI_MON] OFF
SET IDENTITY_INSERT [dbo].[MON_HOC] ON 

INSERT [dbo].[MON_HOC] ([ID_MON_HOC], [MA_MON_HOC], [TEN_MON_HOC], [SO_CHI], [LOAI_DVHT], [LOAI_HINH], [MON_TIEN_QUYET], [MON_SONG_HANH], [MO_TA], [ID_LOAI_MON], [ID_CHUYEN_NGANH], [TRANG_THAI]) VALUES (1, N'CS 100                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ', N'Giới Thiệu về Khoa Học Máy Tính', 1, N'Tín Chỉ', N'LEC', N'(Không có Môn học Tiên quyết)', N'(Không có Môn học Tiên quyết)', N'...', 3, 4, 1)
INSERT [dbo].[MON_HOC] ([ID_MON_HOC], [MA_MON_HOC], [TEN_MON_HOC], [SO_CHI], [LOAI_DVHT], [LOAI_HINH], [MON_TIEN_QUYET], [MON_SONG_HANH], [MO_TA], [ID_LOAI_MON], [ID_CHUYEN_NGANH], [TRANG_THAI]) VALUES (2, N'STA 151                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             ', N'Lý Thuyết Xác Suất & Thống Kê Toán', 3, N'Tín Chỉ', N'LEC', N'(Không có Môn học Tiên quyết)', N'(Không có Môn học Tiên quyết)', N'...', 1, 2, 1)
INSERT [dbo].[MON_HOC] ([ID_MON_HOC], [MA_MON_HOC], [TEN_MON_HOC], [SO_CHI], [LOAI_DVHT], [LOAI_HINH], [MON_TIEN_QUYET], [MON_SONG_HANH], [MO_TA], [ID_LOAI_MON], [ID_CHUYEN_NGANH], [TRANG_THAI]) VALUES (3, N'MTH 254                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             ', N'Toán Rời Rạc & Ứng Dụng', 3, N'Tín Chỉ', N'LEC/LAB', N'MTH 103 - Toán Cao Cấp A1', N'(Không có Môn học Tiên quyết)', N'...', 1, 2, 1)
INSERT [dbo].[MON_HOC] ([ID_MON_HOC], [MA_MON_HOC], [TEN_MON_HOC], [SO_CHI], [LOAI_DVHT], [LOAI_HINH], [MON_TIEN_QUYET], [MON_SONG_HANH], [MO_TA], [ID_LOAI_MON], [ID_CHUYEN_NGANH], [TRANG_THAI]) VALUES (4, N'CS 316                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ', N'Giới Thiệu Cấu Trúc Dữ Liệu & Giải Thuật', 3, N'Tín Chỉ', N'LEC/LAB', N'(Không có Môn học Tiên quyết)', N'(Không có Môn học Tiên quyết)', N'...', 1, 2, 1)
INSERT [dbo].[MON_HOC] ([ID_MON_HOC], [MA_MON_HOC], [TEN_MON_HOC], [SO_CHI], [LOAI_DVHT], [LOAI_HINH], [MON_TIEN_QUYET], [MON_SONG_HANH], [MO_TA], [ID_LOAI_MON], [ID_CHUYEN_NGANH], [TRANG_THAI]) VALUES (5, N'CS 211                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ', N'Lập Trình Cơ Sở', 4, N'Tín Chỉ', N'LEC/LAB', N'(Không có Môn học Tiên quyết)', N'(Không có Môn học Tiên quyết)', N'...', 1, 2, 1)
INSERT [dbo].[MON_HOC] ([ID_MON_HOC], [MA_MON_HOC], [TEN_MON_HOC], [SO_CHI], [LOAI_DVHT], [LOAI_HINH], [MON_TIEN_QUYET], [MON_SONG_HANH], [MO_TA], [ID_LOAI_MON], [ID_CHUYEN_NGANH], [TRANG_THAI]) VALUES (6, N'CS 311                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ', N'Lập Trình Hướng Đối Tượng', 4, N'Tín Chỉ', N'LEC/LAB', N'CS 211 - Lập Trình Cơ Sở', N'(Không có Môn học Tiên quyết)', N'...', 1, 2, 1)
INSERT [dbo].[MON_HOC] ([ID_MON_HOC], [MA_MON_HOC], [TEN_MON_HOC], [SO_CHI], [LOAI_DVHT], [LOAI_HINH], [MON_TIEN_QUYET], [MON_SONG_HANH], [MO_TA], [ID_LOAI_MON], [ID_CHUYEN_NGANH], [TRANG_THAI]) VALUES (7, N'IS 301                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ', N'Cơ Sở Dữ Liệu', 3, N'Tín Chỉ', N'LEC', N'CS 101 - Tin Học Đại Cương', N'(Không có Môn học Tiên quyết)', N'...', 1, 4, 1)
SET IDENTITY_INSERT [dbo].[MON_HOC] OFF
SET IDENTITY_INSERT [dbo].[NAM_HOC] ON 

INSERT [dbo].[NAM_HOC] ([ID_NAM_HOC], [TEN_NAM_HOC], [TRANGTHAI]) VALUES (1, N'2017-2018                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           ', 1)
INSERT [dbo].[NAM_HOC] ([ID_NAM_HOC], [TEN_NAM_HOC], [TRANGTHAI]) VALUES (2, N'2018-2019                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           ', 1)
INSERT [dbo].[NAM_HOC] ([ID_NAM_HOC], [TEN_NAM_HOC], [TRANGTHAI]) VALUES (3, N'2019-2020                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           ', 0)
INSERT [dbo].[NAM_HOC] ([ID_NAM_HOC], [TEN_NAM_HOC], [TRANGTHAI]) VALUES (4, N'2020-2021                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           ', 0)
INSERT [dbo].[NAM_HOC] ([ID_NAM_HOC], [TEN_NAM_HOC], [TRANGTHAI]) VALUES (5, N'2021-2022                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           ', 0)
INSERT [dbo].[NAM_HOC] ([ID_NAM_HOC], [TEN_NAM_HOC], [TRANGTHAI]) VALUES (6, N'2022-2023                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           ', 0)
INSERT [dbo].[NAM_HOC] ([ID_NAM_HOC], [TEN_NAM_HOC], [TRANGTHAI]) VALUES (7, N'2023-2024                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           ', 0)
INSERT [dbo].[NAM_HOC] ([ID_NAM_HOC], [TEN_NAM_HOC], [TRANGTHAI]) VALUES (8, N'2024-2025                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           ', 0)
INSERT [dbo].[NAM_HOC] ([ID_NAM_HOC], [TEN_NAM_HOC], [TRANGTHAI]) VALUES (9, N'2025-2026                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           ', 0)
INSERT [dbo].[NAM_HOC] ([ID_NAM_HOC], [TEN_NAM_HOC], [TRANGTHAI]) VALUES (10, N'2026-2027                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           ', 0)
INSERT [dbo].[NAM_HOC] ([ID_NAM_HOC], [TEN_NAM_HOC], [TRANGTHAI]) VALUES (11, N'2027-2028                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           ', 0)
INSERT [dbo].[NAM_HOC] ([ID_NAM_HOC], [TEN_NAM_HOC], [TRANGTHAI]) VALUES (12, N'2028-2030                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           ', 0)
INSERT [dbo].[NAM_HOC] ([ID_NAM_HOC], [TEN_NAM_HOC], [TRANGTHAI]) VALUES (13, N'2030-2031                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           ', 0)
SET IDENTITY_INSERT [dbo].[NAM_HOC] OFF
SET IDENTITY_INSERT [dbo].[PHIEU_DANG_KY] ON 

INSERT [dbo].[PHIEU_DANG_KY] ([ID_PHIEU_DANG_KY], [ID_SINHVIEN], [ID_HOC_KY], [ID_NAM_HOC], [TONG_SO_TIN_CHI]) VALUES (10, 4, 1, 2, 17)
INSERT [dbo].[PHIEU_DANG_KY] ([ID_PHIEU_DANG_KY], [ID_SINHVIEN], [ID_HOC_KY], [ID_NAM_HOC], [TONG_SO_TIN_CHI]) VALUES (11, 5, 1, 2, 18)
INSERT [dbo].[PHIEU_DANG_KY] ([ID_PHIEU_DANG_KY], [ID_SINHVIEN], [ID_HOC_KY], [ID_NAM_HOC], [TONG_SO_TIN_CHI]) VALUES (12, 4, 2, 2, 14)
SET IDENTITY_INSERT [dbo].[PHIEU_DANG_KY] OFF
SET IDENTITY_INSERT [dbo].[QUYEN] ON 

INSERT [dbo].[QUYEN] ([ID_QUYEN], [TEN_QUYEN], [MO_TA], [TRANG_THAI]) VALUES (1, N'admin', N'tài khoản của admin quản trị', 1)
INSERT [dbo].[QUYEN] ([ID_QUYEN], [TEN_QUYEN], [MO_TA], [TRANG_THAI]) VALUES (2, N'sinh viên', N'tài khoản của sinh viên dtu', 1)
INSERT [dbo].[QUYEN] ([ID_QUYEN], [TEN_QUYEN], [MO_TA], [TRANG_THAI]) VALUES (3, N'Giáo vụ CNTT', N'Giáo vụ khoa công nghệ thông tin', 1)
INSERT [dbo].[QUYEN] ([ID_QUYEN], [TEN_QUYEN], [MO_TA], [TRANG_THAI]) VALUES (4, N'Giáo Vụ Du Lịch', N'Giáo Vụ Khoa Du Lịch', 0)
INSERT [dbo].[QUYEN] ([ID_QUYEN], [TEN_QUYEN], [MO_TA], [TRANG_THAI]) VALUES (5, N'Giáo Vụ Kiến trúc', N'Giáo Vụ khoa Kiến trúc', 0)
SET IDENTITY_INSERT [dbo].[QUYEN] OFF
SET IDENTITY_INSERT [dbo].[SINH_VIEN] ON 

INSERT [dbo].[SINH_VIEN] ([ID_SINHVIEN], [MA_SINH_VIEN], [TEN_SINH_VIEN], [NGAY_SINH], [CMND], [DIEN_THOAI], [DIA_CHI], [EMAIL], [ID_TAI_KHOAN], [ID_CHUYEN_NGANH]) VALUES (4, N'2121114026                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          ', N'Trần Hoàng Bửu', CAST(N'1997-06-06 00:00:00.000' AS DateTime), N'191961511                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           ', N'01266625412                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         ', N'Huế', N'tranhoangbuu66@gmail.com                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            ', 2, 2)
INSERT [dbo].[SINH_VIEN] ([ID_SINHVIEN], [MA_SINH_VIEN], [TEN_SINH_VIEN], [NGAY_SINH], [CMND], [DIEN_THOAI], [DIA_CHI], [EMAIL], [ID_TAI_KHOAN], [ID_CHUYEN_NGANH]) VALUES (5, N'2121114027                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          ', N'Ngô Thị Thanh', CAST(N'1997-02-13 00:00:00.000' AS DateTime), N'20                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  ', N'0979672073                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          ', N'Quảng Nam', N'ngothithanh@gmail.com                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               ', 5, 2)
SET IDENTITY_INSERT [dbo].[SINH_VIEN] OFF
SET IDENTITY_INSERT [dbo].[TAIKHOAN] ON 

INSERT [dbo].[TAIKHOAN] ([ID_TAI_KHOAN], [USERNAME], [PASS], [ID_QUYEN]) VALUES (1, N'admin', N'123', 1)
INSERT [dbo].[TAIKHOAN] ([ID_TAI_KHOAN], [USERNAME], [PASS], [ID_QUYEN]) VALUES (2, N'tranhoangbuu', N'123', 2)
INSERT [dbo].[TAIKHOAN] ([ID_TAI_KHOAN], [USERNAME], [PASS], [ID_QUYEN]) VALUES (3, N'cntt', N'123', 3)
INSERT [dbo].[TAIKHOAN] ([ID_TAI_KHOAN], [USERNAME], [PASS], [ID_QUYEN]) VALUES (5, N'ngothithanh', N'123', 2)
SET IDENTITY_INSERT [dbo].[TAIKHOAN] OFF
/****** Object:  Index [IX_SINH_VIEN]    Script Date: 2/26/2018 4:28:09 PM ******/
ALTER TABLE [dbo].[SINH_VIEN] ADD  CONSTRAINT [IX_SINH_VIEN] UNIQUE NONCLUSTERED 
(
	[ID_TAI_KHOAN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__SINH_VIE__8BF6535A8D0D00AE]    Script Date: 2/26/2018 4:28:09 PM ******/
ALTER TABLE [dbo].[SINH_VIEN] ADD UNIQUE NONCLUSTERED 
(
	[MA_SINH_VIEN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CHUONG_TRINH_HOC]  WITH CHECK ADD FOREIGN KEY([ID_MON_HOC])
REFERENCES [dbo].[MON_HOC] ([ID_MON_HOC])
GO
ALTER TABLE [dbo].[CHUONG_TRINH_HOC]  WITH CHECK ADD FOREIGN KEY([ID_SINHVIEN])
REFERENCES [dbo].[SINH_VIEN] ([ID_SINHVIEN])
GO
ALTER TABLE [dbo].[CHUYEN_NGANH]  WITH CHECK ADD FOREIGN KEY([ID_KHOA])
REFERENCES [dbo].[KHOA] ([ID_KHOA])
GO
ALTER TABLE [dbo].[CT_PHIEU_DANG_KY]  WITH CHECK ADD FOREIGN KEY([ID_MON_HOC])
REFERENCES [dbo].[MON_HOC] ([ID_MON_HOC])
GO
ALTER TABLE [dbo].[CT_PHIEU_DANG_KY]  WITH CHECK ADD FOREIGN KEY([ID_PHIEU_DANG_KY])
REFERENCES [dbo].[PHIEU_DANG_KY] ([ID_PHIEU_DANG_KY])
GO
ALTER TABLE [dbo].[MON_HOC]  WITH CHECK ADD FOREIGN KEY([ID_CHUYEN_NGANH])
REFERENCES [dbo].[CHUYEN_NGANH] ([ID_CHUYEN_NGANH])
GO
ALTER TABLE [dbo].[MON_HOC]  WITH CHECK ADD FOREIGN KEY([ID_LOAI_MON])
REFERENCES [dbo].[LOAI_MON] ([ID_LOAI_MON])
GO
ALTER TABLE [dbo].[PHIEU_DANG_KY]  WITH CHECK ADD FOREIGN KEY([ID_HOC_KY])
REFERENCES [dbo].[HOC_KY] ([ID_HOC_KY])
GO
ALTER TABLE [dbo].[PHIEU_DANG_KY]  WITH CHECK ADD FOREIGN KEY([ID_NAM_HOC])
REFERENCES [dbo].[NAM_HOC] ([ID_NAM_HOC])
GO
ALTER TABLE [dbo].[PHIEU_DANG_KY]  WITH CHECK ADD FOREIGN KEY([ID_SINHVIEN])
REFERENCES [dbo].[SINH_VIEN] ([ID_SINHVIEN])
GO
ALTER TABLE [dbo].[SINH_VIEN]  WITH CHECK ADD FOREIGN KEY([ID_CHUYEN_NGANH])
REFERENCES [dbo].[CHUYEN_NGANH] ([ID_CHUYEN_NGANH])
GO
ALTER TABLE [dbo].[SINH_VIEN]  WITH CHECK ADD  CONSTRAINT [FK_SINH_VIEN_TAIKHOAN] FOREIGN KEY([ID_TAI_KHOAN])
REFERENCES [dbo].[TAIKHOAN] ([ID_TAI_KHOAN])
GO
ALTER TABLE [dbo].[SINH_VIEN] CHECK CONSTRAINT [FK_SINH_VIEN_TAIKHOAN]
GO
ALTER TABLE [dbo].[TAIKHOAN]  WITH CHECK ADD FOREIGN KEY([ID_QUYEN])
REFERENCES [dbo].[QUYEN] ([ID_QUYEN])
GO
/****** Object:  StoredProcedure [dbo].[TONGTINCHICODUOC]    Script Date: 2/26/2018 4:28:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TONGTINCHICODUOC](@ID_NAM_HOC INT, @ID_HOC_KY INT)
AS
BEGIN
	SELECT C.TEN_MON_HOC, SUM(C.SO_CHI) AS TONGCHIMON
	FROM dbo.CT_PHIEU_DANG_KY A, dbo.PHIEU_DANG_KY B , dbo.MON_HOC C
	WHERE B.ID_NAM_HOC = @ID_NAM_HOC 
		  AND B.ID_HOC_KY = @ID_HOC_KY 
		  AND A.ID_MON_HOC = C.ID_MON_HOC 
		  AND A.ID_PHIEU_DANG_KY = B.ID_PHIEU_DANG_KY
	GROUP BY C.TEN_MON_HOC
END

GO
