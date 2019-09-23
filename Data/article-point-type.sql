USE [ATVAllowance]
GO
SET IDENTITY_INSERT [dbo].[PointType] ON 

INSERT [dbo].[PointType] ([Id], [Name], [Code]) VALUES (1, N'Tin', N'Tin')
INSERT [dbo].[PointType] ([Id], [Name], [Code]) VALUES (2, N'Phóng sự', N'PS')
INSERT [dbo].[PointType] ([Id], [Name], [Code]) VALUES (3, N'Quay tin', N'QTin')
INSERT [dbo].[PointType] ([Id], [Name], [Code]) VALUES (4, N'Quay phóng sự', N'QPs')
INSERT [dbo].[PointType] ([Id], [Name], [Code]) VALUES (5, N'Phỏng vấn, Phát biểu', N'Pv_Pb')
INSERT [dbo].[PointType] ([Id], [Name], [Code]) VALUES (6, N'Trả lời thư', N'Tlt')
INSERT [dbo].[PointType] ([Id], [Name], [Code]) VALUES (7, N'Soạn dựng', N'Sd')
INSERT [dbo].[PointType] ([Id], [Name], [Code]) VALUES (8, N'Chuyên đề, Chuyên mục', N'Cd_Cm')
INSERT [dbo].[PointType] ([Id], [Name], [Code]) VALUES (9, N'Bài', N'Bai')
INSERT [dbo].[PointType] ([Id], [Name], [Code]) VALUES (10, N'Tường thuật, Ghi nhanh', N'TTh_Gnh')
INSERT [dbo].[PointType] ([Id], [Name], [Code]) VALUES (11, N'Chuyên đề', N'CDe')
INSERT [dbo].[PointType] ([Id], [Name], [Code]) VALUES (12, N'Biên soạn, Dẫn chương trình', N'Bs_DCT')
INSERT [dbo].[PointType] ([Id], [Name], [Code]) VALUES (13, N'Biên tập, Đạo diễn', N'Bt_Dd')
SET IDENTITY_INSERT [dbo].[PointType] OFF
SET IDENTITY_INSERT [dbo].[ArticlePointType] ON 

INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (8, 3, 1)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (9, 3, 2)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (10, 3, 3)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (11, 3, 4)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (12, 1, 1)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (13, 1, 5)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (14, 1, 6)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (15, 1, 7)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (16, 1, 8)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (17, 1, 9)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (18, 2, 1)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (19, 2, 10)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (20, 2, 11)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (21, 2, 5)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (22, 2, 12)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (23, 2, 13)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (24, 4, 1)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (25, 4, 2)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (26, 4, 3)
INSERT [dbo].[ArticlePointType] ([Id], [ArticleTypeId], [PointTypeId]) VALUES (27, 4, 4)
SET IDENTITY_INSERT [dbo].[ArticlePointType] OFF
