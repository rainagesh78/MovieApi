
/********************
Rating Table
********************/

CREATE TABLE [Movie](
	[MovieId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](100) NULL,
	[YearOfRelease] [int] NULL,
	[RunningTime] [int] NULL,
	[Genres] [varchar](250) NULL,
 CONSTRAINT [PK_Movies] PRIMARY KEY CLUSTERED 
(
	[MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/********************
Rating Table
********************/


CREATE TABLE [User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](250) NULL,
	[LastName] [varchar](250) NULL,
	[UserName] [char](10) NULL,
	[Password] [varchar](50) NULL,
	[Email] [varchar](100) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/********************
Rating Table
********************/

CREATE TABLE [Rating](
	[MovieId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[GivenRating] [numeric](5,2 ) NULL,
  CONSTRAINT [IX_Rating] UNIQUE NONCLUSTERED 
(
	[MovieId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF

ALTER TABLE [Rating]  WITH CHECK ADD  CONSTRAINT [FK_RATING_C_REFERENCE_MOVIES] FOREIGN KEY([MovieId])
REFERENCES [Movie] ([MovieId])
GO

ALTER TABLE [Rating] CHECK CONSTRAINT [FK_RATING_C_REFERENCE_MOVIES]
GO

ALTER TABLE [Rating]  WITH CHECK ADD  CONSTRAINT [FK_RATING_C_REFERENCE_USERS] FOREIGN KEY([UserId])
REFERENCES [User] ([UserId])
GO

ALTER TABLE [Rating] CHECK CONSTRAINT [FK_RATING_C_REFERENCE_USERS]
GO