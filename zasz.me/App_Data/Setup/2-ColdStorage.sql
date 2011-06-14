USE [ColdStorage]
GO
/****** Object:  Table [dbo].[Posts]    Script Date: 06/10/2011 23:08:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posts](
	[Slug] [nvarchar](128) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Content] [nvarchar](max) NULL,
	[Timestamp] [datetime] NOT NULL,
	[Site_Name] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Slug] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Passphrases]    Script Date: 06/10/2011 23:08:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Passphrases](
	[PhraseDigest] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[OneTime] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PhraseDigest] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Logs]    Script Date: 06/10/2011 23:08:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[ID] [nvarchar](128) NOT NULL,
	[Error_ApplicationName] [nvarchar](max) NULL,
	[Error_HostName] [nvarchar](max) NULL,
	[Error_Type] [nvarchar](max) NULL,
	[Error_Source] [nvarchar](max) NULL,
	[Error_Message] [nvarchar](max) NULL,
	[Error_Detail] [nvarchar](max) NULL,
	[Error_User] [nvarchar](max) NULL,
	[Error_Time] [datetime] NOT NULL,
	[Error_StatusCode] [int] NOT NULL,
	[Error_WebHostHtmlMessage] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EdmMetadata]    Script Date: 06/10/2011 23:08:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EdmMetadata](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ModelHash] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[EdmMetadata] ON
INSERT [dbo].[EdmMetadata] ([Id], [ModelHash]) VALUES (1, N'B32F992C63F816F6A41ADECD813CA563E55D4A440BFDC14DC4A1B6E60ED34381')
SET IDENTITY_INSERT [dbo].[EdmMetadata] OFF
/****** Object:  Table [dbo].[Tags]    Script Date: 06/10/2011 23:08:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tags](
	[Name] [nvarchar](128) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[TagPosts]    Script Date: 06/10/2011 23:08:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TagPosts](
	[Tag_Name] [nvarchar](128) NOT NULL,
	[Post_Slug] [nvarchar](128) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Tag_Name] ASC,
	[Post_Slug] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  ForeignKey [Tag_Posts_Source]    Script Date: 06/10/2011 23:08:48 ******/
ALTER TABLE [dbo].[TagPosts]  WITH CHECK ADD  CONSTRAINT [Tag_Posts_Source] FOREIGN KEY([Tag_Name])
REFERENCES [dbo].[Tags] ([Name])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TagPosts] CHECK CONSTRAINT [Tag_Posts_Source]
GO
/****** Object:  ForeignKey [Tag_Posts_Target]    Script Date: 06/10/2011 23:08:48 ******/
ALTER TABLE [dbo].[TagPosts]  WITH CHECK ADD  CONSTRAINT [Tag_Posts_Target] FOREIGN KEY([Post_Slug])
REFERENCES [dbo].[Posts] ([Slug])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TagPosts] CHECK CONSTRAINT [Tag_Posts_Target]
GO
