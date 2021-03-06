

/****** Object:  Table [dbo].[notes]    Script Date: 4/27/2021 10:47:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[notes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userID] [int] NOT NULL,
	[description] [nvarchar](max) NULL,
	[created] [datetime] NULL,
	[modified] [datetime] NULL,
	[isArchived] [bit] NULL,
 CONSTRAINT [PK_notes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 4/27/2021 10:47:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](250) NULL,
	[userName] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
	[created] [datetime] NULL,
	[modified] [datetime] NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[notes] ON 
GO
INSERT [dbo].[notes] ([id], [userID], [description], [created], [modified], [isArchived]) VALUES (19, 1, N'A daily live broadcast provides current domestic and international news, weather reports and interviews with newsmakers from the worlds of politics, business, media, entertainment and sports. Additionally, specific segments such as Today''s Money', CAST(N'2021-04-27T10:03:52.577' AS DateTime), CAST(N'2021-04-27T10:35:24.833' AS DateTime), 0)
GO
INSERT [dbo].[notes] ([id], [userID], [description], [created], [modified], [isArchived]) VALUES (20, 1, N'Yahoo! is an American web services provider. It is headquartered in Sunnyvale, California and owned by Verizon Media, which acquired it in 2017 for $4.48 billion. It currently provides a web portal, search engine Yahoo! Search, and related services, including Yahoo! Mail, Yahoo! News, Yahoo!', CAST(N'2021-04-27T10:07:08.030' AS DateTime), CAST(N'2021-04-27T10:09:06.020' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[notes] OFF
GO
SET IDENTITY_INSERT [dbo].[user] ON 
GO
INSERT [dbo].[user] ([id], [name], [userName], [password], [created], [modified]) VALUES (1, N'Rohit', N'rohit', N'rohit', CAST(N'2021-04-27T00:00:00.000' AS DateTime), CAST(N'2021-04-27T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[user] OFF
GO
ALTER TABLE [dbo].[notes]  WITH CHECK ADD  CONSTRAINT [FK_notes_user] FOREIGN KEY([userID])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[notes] CHECK CONSTRAINT [FK_notes_user]
GO

