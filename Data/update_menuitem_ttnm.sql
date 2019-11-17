USE [ATVAllowance]
GO
SET IDENTITY_INSERT [dbo].[MenuItem] ON 

INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (26, N'In Thông tin ngày mới', 1, N'In ấn', 3)
INSERT [dbo].[MenuItem] ([Id], [Name], [Level], [ParentName], [Order]) VALUES (27, N'In Biên soạn thông tin ngày mới', 1, N'In ấn', 4)
SET IDENTITY_INSERT [dbo].[MenuItem] OFF
SET IDENTITY_INSERT [dbo].[RoleHasMenuItem] ON 

INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (23, 2, 26)
INSERT [dbo].[RoleHasMenuItem] ([Id], [RoleId], [MenuItemId]) VALUES (24, 2, 27)

SET IDENTITY_INSERT [dbo].[RoleHasMenuItem] OFF
GO
