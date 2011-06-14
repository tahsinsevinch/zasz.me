USE [ColdStorage]
GO
/****** Object:  Table [dbo].[Posts]    Script Date: 06/14/2011 16:10:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posts](
	[Id] [uniqueidentifier] NOT NULL,
	[Slug] [nvarchar](max) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Content] [nvarchar](max) NULL,
	[Timestamp] [datetime] NOT NULL,
	[Site_Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Posts] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE CLUSTERED INDEX [PostsByTime] ON [dbo].[Posts] 
(
	[Timestamp] DESC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Passphrases]    Script Date: 06/14/2011 16:10:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Passphrases](
	[Id] [uniqueidentifier] NOT NULL,
	[PhraseDigest] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[OneTime] [bit] NOT NULL,
 CONSTRAINT [PK_Passphrases] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Logs]    Script Date: 06/14/2011 16:10:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[Id] [uniqueidentifier] NOT NULL,
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
 CONSTRAINT [PK_Logs] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE CLUSTERED INDEX [LogsByTime] ON [dbo].[Logs] 
(
	[Error_Time] DESC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tags]    Script Date: 06/14/2011 16:10:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tags](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Tags] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TagPosts]    Script Date: 06/14/2011 16:10:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TagPosts](
	[Post_Id] [uniqueidentifier] NOT NULL,
	[Tag_Id] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Default [PassphrasesIdDefaulter]    Script Date: 06/14/2011 16:10:20 ******/
ALTER TABLE [dbo].[Passphrases] ADD  CONSTRAINT [PassphrasesIdDefaulter]  DEFAULT (newid()) FOR [Id]
GO
/****** Object:  Default [PostsIdDefaulter]    Script Date: 06/14/2011 16:10:20 ******/
ALTER TABLE [dbo].[Posts] ADD  CONSTRAINT [PostsIdDefaulter]  DEFAULT (newid()) FOR [Id]
GO
/****** Object:  Default [TagsIdDefaulter]    Script Date: 06/14/2011 16:10:20 ******/
ALTER TABLE [dbo].[Tags] ADD  CONSTRAINT [TagsIdDefaulter]  DEFAULT (newid()) FOR [Id]
GO
/****** Object:  ForeignKey [FK_TagPosts_Posts]    Script Date: 06/14/2011 16:10:20 ******/
ALTER TABLE [dbo].[TagPosts]  WITH CHECK ADD  CONSTRAINT [FK_TagPosts_Posts] FOREIGN KEY([Post_Id])
REFERENCES [dbo].[Posts] ([Id])
GO
ALTER TABLE [dbo].[TagPosts] CHECK CONSTRAINT [FK_TagPosts_Posts]
GO
/****** Object:  ForeignKey [FK_TagPosts_Tags]    Script Date: 06/14/2011 16:10:20 ******/
ALTER TABLE [dbo].[TagPosts]  WITH CHECK ADD  CONSTRAINT [FK_TagPosts_Tags] FOREIGN KEY([Tag_Id])
REFERENCES [dbo].[Tags] ([Id])
GO
ALTER TABLE [dbo].[TagPosts] CHECK CONSTRAINT [FK_TagPosts_Tags]
GO
