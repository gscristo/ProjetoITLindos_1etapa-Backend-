CREATE DATABASE LeanLearning
GO

USE LeanLearning

USE [LeanLearning]
GO

/****** Object:  Table [dbo].[Person]    Script Date: 02/05/2021 00:31:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Person](
	[PersonId] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[SocialNumber] [varchar](15) NOT NULL,
	[Fone] [varchar](15) NULL,
	[ZipCode] [varchar](10) NOT NULL,
	[Street] [varchar](100) NOT NULL,
	[Number] [varchar](10) NOT NULL,
	[Neighborhood] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[State] [varchar](50) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



