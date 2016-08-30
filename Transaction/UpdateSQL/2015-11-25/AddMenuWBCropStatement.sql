GO
SET IDENTITY_INSERT [dbo].[Menu] ON 
INSERT [dbo].[Menu] ([RNo], [MenuID], [MenuName], [MenuNameB], [ModID], [MenuGroupID], [MenuGroupSeqNo], [MenuSeqNo], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [PageName]) VALUES (1613, N'M588', N'Weighbridge Crop Statement Report', N'Weighbridge Crop Statement Report', 4, N'M3', 3, 4, N'system', CAST(N'2015-07-06 00:00:00.000' AS DateTime), N'system', CAST(N'2015-07-06 00:00:00.000' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Menu] OFF

select * from Menu order by MenuID desc