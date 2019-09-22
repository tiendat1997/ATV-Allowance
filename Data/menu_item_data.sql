USE [ATVAllowance]
GO
SET IDENTITY_INSERT [dbo].[MenuItem] ON 

INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (5, N'In ấn', 0, NULL, 2)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (6, N'In Thời sự', 1, N'In ấn', 0)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (7, N'In Phát thanh ', 1, N'In ấn', 1)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (8, N'In Phát thanh trực tiếp', 1, N'In ấn', 2)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (9, N'Quản lý chung', 0, NULL, 1)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (10, N'Quản lý nhân viên', 1, N'Quản lý chung', 1)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (11, N'Quản lý chỉ tiêu', 1, N'Quản lý chung', 2)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (12, N'Quản lý đơn vị', 1, N'Quản lý chung', 3)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (13, N'Quản lý loại tin', 1, N'Quản lý chung', 4)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (14, N'Quản lý giảm trừ', 1, N'Quản lý chung', 5)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (15, N'Nhập liệu', 0, NULL, 0)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (18, N'Nhập Tin thời sự hàng ngày', 1, N'Nhập liệu', 0)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (19, N'Nhập Tin, PS ttnm', 1, N'Nhập liệu', 1)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (20, N'Nhập Tin phát thanh', 1, N'Nhập liệu', 2)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (21, N'Nhập Tin phát thanh tt', 1, N'Nhập liệu', 3)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (22, N'Nhập Thù lao biên soạn tnnm', 1, N'Nhập liệu', 4)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (23, N'Xem nhanh tin', 1, N'Quản lý chung', 0)
SET IDENTITY_INSERT [dbo].[MenuItem] OFF
SET IDENTITY_INSERT [dbo].[RoleHasMenuItem] ON 

INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (5, 2, 5)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (6, 2, 6)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (7, 2, 7)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (8, 2, 8)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (9, 2, 9)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (10, 2, 10)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (11, 2, 11)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (12, 2, 12)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (13, 2, 13)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (14, 2, 14)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (15, 2, 15)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (16, 2, 18)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (17, 2, 19)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (18, 2, 20)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (19, 2, 21)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (20, 2, 22)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (21, 2, 23)
SET IDENTITY_INSERT [dbo].[RoleHasMenuItem] OFF
