USE [DOAN3970]
GO
/****** Object:  Table [dbo].[CHUYEN_NGANH]    Script Date: 4/8/2018 7:09:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHUYEN_NGANH](
	[ID_CHUYEN_NGANH] [int] IDENTITY(1,1) NOT NULL,
	[TEN_CHUYEN_NGANH] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_CHUYEN_NGANH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CHUYENNGANH_MONHOC]    Script Date: 4/8/2018 7:09:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHUYENNGANH_MONHOC](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_MONHOC] [int] NULL,
	[ID_CHUYENNGANH] [int] NULL,
	[TU_CHON] [bit] NULL,
	[NHOM_TU_CHON] [int] NULL,
 CONSTRAINT [PK_CHUYENNGANH_MONHOC] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CT_PHIEU_DANG_KY]    Script Date: 4/8/2018 7:09:03 PM ******/
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
/****** Object:  Table [dbo].[HOC_KY]    Script Date: 4/8/2018 7:09:03 PM ******/
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
/****** Object:  Table [dbo].[MON_HOC]    Script Date: 4/8/2018 7:09:03 PM ******/
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
	[TRANG_THAI] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_MON_HOC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NAM_HOC]    Script Date: 4/8/2018 7:09:03 PM ******/
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
/****** Object:  Table [dbo].[NHAN_VIEN]    Script Date: 4/8/2018 7:09:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NHAN_VIEN](
	[ID_NHANVIEN] [int] IDENTITY(1,1) NOT NULL,
	[TEN_NHANVIEN] [nvarchar](50) NULL,
	[NGAY_SINH] [date] NULL,
	[DIEN_THOAI] [char](500) NULL,
	[DIA_CHI] [nvarchar](900) NULL,
	[EMAIL] [char](500) NULL,
	[ID_TAI_KHOAN] [int] NULL,
 CONSTRAINT [PK_NHAN_VIEN] PRIMARY KEY CLUSTERED 
(
	[ID_NHANVIEN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PHIEU_DANG_KY]    Script Date: 4/8/2018 7:09:03 PM ******/
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
/****** Object:  Table [dbo].[QUYEN]    Script Date: 4/8/2018 7:09:03 PM ******/
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
/****** Object:  Table [dbo].[SINH_VIEN]    Script Date: 4/8/2018 7:09:03 PM ******/
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
/****** Object:  Table [dbo].[TAIKHOAN]    Script Date: 4/8/2018 7:09:03 PM ******/
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
SET IDENTITY_INSERT [dbo].[CHUYEN_NGANH] ON 

INSERT [dbo].[CHUYEN_NGANH] ([ID_CHUYEN_NGANH], [TEN_CHUYEN_NGANH]) VALUES (1, N'Kỹ Thuật Mạng')
INSERT [dbo].[CHUYEN_NGANH] ([ID_CHUYEN_NGANH], [TEN_CHUYEN_NGANH]) VALUES (2, N'Công Nghệ Phần Mềm')
INSERT [dbo].[CHUYEN_NGANH] ([ID_CHUYEN_NGANH], [TEN_CHUYEN_NGANH]) VALUES (3, N'Thiết kế Đồ họa')
INSERT [dbo].[CHUYEN_NGANH] ([ID_CHUYEN_NGANH], [TEN_CHUYEN_NGANH]) VALUES (4, N'Hệ thống Thông tin Quản lý')
SET IDENTITY_INSERT [dbo].[CHUYEN_NGANH] OFF
SET IDENTITY_INSERT [dbo].[CHUYENNGANH_MONHOC] ON 

INSERT [dbo].[CHUYENNGANH_MONHOC] ([ID], [ID_MONHOC], [ID_CHUYENNGANH], [TU_CHON], [NHOM_TU_CHON]) VALUES (3, 13, 2, 0, NULL)
SET IDENTITY_INSERT [dbo].[CHUYENNGANH_MONHOC] OFF
SET IDENTITY_INSERT [dbo].[HOC_KY] ON 

INSERT [dbo].[HOC_KY] ([ID_HOC_KY], [TEN_HOC_KY]) VALUES (1, N'I')
INSERT [dbo].[HOC_KY] ([ID_HOC_KY], [TEN_HOC_KY]) VALUES (2, N'II')
SET IDENTITY_INSERT [dbo].[HOC_KY] OFF
SET IDENTITY_INSERT [dbo].[MON_HOC] ON 

INSERT [dbo].[MON_HOC] ([ID_MON_HOC], [MA_MON_HOC], [TEN_MON_HOC], [SO_CHI], [LOAI_DVHT], [LOAI_HINH], [MON_TIEN_QUYET], [MON_SONG_HANH], [MO_TA], [TRANG_THAI]) VALUES (13, N'cs 211                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ', N'123', 2, N'123', N'123', N'123', N'123', N'123', 1)
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
INSERT [dbo].[TAIKHOAN] ([ID_TAI_KHOAN], [USERNAME], [PASS], [ID_QUYEN]) VALUES (6, N'trần hoàng bửu', N'4026', 2)
SET IDENTITY_INSERT [dbo].[TAIKHOAN] OFF
/****** Object:  Index [motmot]    Script Date: 4/8/2018 7:09:03 PM ******/
ALTER TABLE [dbo].[NHAN_VIEN] ADD  CONSTRAINT [motmot] UNIQUE NONCLUSTERED 
(
	[ID_TAI_KHOAN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SINH_VIEN]    Script Date: 4/8/2018 7:09:03 PM ******/
ALTER TABLE [dbo].[SINH_VIEN] ADD  CONSTRAINT [IX_SINH_VIEN] UNIQUE NONCLUSTERED 
(
	[ID_TAI_KHOAN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__SINH_VIE__8BF6535A8D0D00AE]    Script Date: 4/8/2018 7:09:03 PM ******/
ALTER TABLE [dbo].[SINH_VIEN] ADD UNIQUE NONCLUSTERED 
(
	[MA_SINH_VIEN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CHUYENNGANH_MONHOC]  WITH CHECK ADD  CONSTRAINT [FK_CHUYENNGANH_MONHOC_CHUYEN_NGANH] FOREIGN KEY([ID_CHUYENNGANH])
REFERENCES [dbo].[CHUYEN_NGANH] ([ID_CHUYEN_NGANH])
GO
ALTER TABLE [dbo].[CHUYENNGANH_MONHOC] CHECK CONSTRAINT [FK_CHUYENNGANH_MONHOC_CHUYEN_NGANH]
GO
ALTER TABLE [dbo].[CHUYENNGANH_MONHOC]  WITH CHECK ADD  CONSTRAINT [FK_CHUYENNGANH_MONHOC_MON_HOC] FOREIGN KEY([ID_MONHOC])
REFERENCES [dbo].[MON_HOC] ([ID_MON_HOC])
GO
ALTER TABLE [dbo].[CHUYENNGANH_MONHOC] CHECK CONSTRAINT [FK_CHUYENNGANH_MONHOC_MON_HOC]
GO
ALTER TABLE [dbo].[CT_PHIEU_DANG_KY]  WITH CHECK ADD FOREIGN KEY([ID_MON_HOC])
REFERENCES [dbo].[MON_HOC] ([ID_MON_HOC])
GO
ALTER TABLE [dbo].[CT_PHIEU_DANG_KY]  WITH CHECK ADD FOREIGN KEY([ID_PHIEU_DANG_KY])
REFERENCES [dbo].[PHIEU_DANG_KY] ([ID_PHIEU_DANG_KY])
GO
ALTER TABLE [dbo].[NHAN_VIEN]  WITH CHECK ADD  CONSTRAINT [FK_NHAN_VIEN_TAIKHOAN] FOREIGN KEY([ID_TAI_KHOAN])
REFERENCES [dbo].[TAIKHOAN] ([ID_TAI_KHOAN])
GO
ALTER TABLE [dbo].[NHAN_VIEN] CHECK CONSTRAINT [FK_NHAN_VIEN_TAIKHOAN]
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
/****** Object:  StoredProcedure [dbo].[TONGTINCHICODUOC]    Script Date: 4/8/2018 7:09:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TONGTINCHICODUOC](@ID_NAM_HOC INT, @ID_HOC_KY INT)
AS
BEGIN
	SELECT C.MA_MON_HOC, C.TEN_MON_HOC, COUNT(A.ID_MON_HOC) AS TONGCHIMON
	FROM dbo.CT_PHIEU_DANG_KY A, dbo.PHIEU_DANG_KY B , dbo.MON_HOC C
	WHERE B.ID_NAM_HOC = @ID_NAM_HOC 
		  AND B.ID_HOC_KY = @ID_HOC_KY 
		  AND A.ID_MON_HOC = C.ID_MON_HOC 
		  AND A.ID_PHIEU_DANG_KY = B.ID_PHIEU_DANG_KY
	GROUP BY C.MA_MON_HOC, C.TEN_MON_HOC
END
GO

CREATE TRIGGER CONGCHIVAOPHIEU
ON CT_PHIEU_DANG_KY
FOR INSERT AS
BEGIN
	DECLARE @ID_PHIEU INT
	DECLARE @ID_MON_HOC INT
	DECLARE @SO_CHI_MON INT
	SELECT @ID_PHIEU = ID_PHIEU_DANG_KY, @ID_MON_HOC = ID_MON_HOC FROM INSERTED
	SELECT @SO_CHI_MON = SO_CHI FROM MON_HOC
	UPDATE PHIEU_DANG_KY SET TONG_SO_TIN_CHI = TONG_SO_TIN_CHI + @SO_CHI_MON WHERE ID_PHIEU_DANG_KY = @ID_PHIEU
END
GO

CREATE TRIGGER TRUCHIKHOIPHIEU
ON CT_PHIEU_DANG_KY
FOR DELETE AS
BEGIN
	DECLARE @ID_PHIEU INT
	DECLARE @ID_MON_HOC INT
	DECLARE @SO_CHI_MON INT
	SELECT @ID_PHIEU = ID_PHIEU_DANG_KY, @ID_MON_HOC = ID_MON_HOC FROM Deleted
	SELECT @SO_CHI_MON = SO_CHI FROM MON_HOC
	UPDATE PHIEU_DANG_KY SET TONG_SO_TIN_CHI = TONG_SO_TIN_CHI - @SO_CHI_MON WHERE ID_PHIEU_DANG_KY = @ID_PHIEU
END