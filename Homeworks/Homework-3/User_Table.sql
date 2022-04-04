USE [LogoDb]
GO

/****** Object:  Table [dbo].[User]    Script Date: 27.03.2022 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirtsName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](30) NOT NULL,
	[Email] [varchar](20) NOT NULL,
	[Address] [varchar](200) NOT NULL,
	[PhoneNumber] [varchar](20) NOT NULL,
	[Password] [varchar](20) NOT NULL,
	[Company_Id] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Company] FOREIGN KEY([Company_Id])
REFERENCES [dbo].[Company] ([Id])
GO

ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Company]
GO


