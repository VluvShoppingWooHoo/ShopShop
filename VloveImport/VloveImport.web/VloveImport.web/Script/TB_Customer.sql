USE [VLoveImport]
GO

/****** Object:  Table [dbo].[TB_Customer]    Script Date: 2/15/2015 12:57:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TB_Customer](
	[Cus_ID] [int] IDENTITY(1,1) NOT NULL,
	[Cus_Name] [nvarchar](100) NULL,
	[Cus_LName] [nvarchar](100) NOT NULL,
	[Cus__Gender] [nvarchar](1) NOT NULL,
	[Cus_Birthday] [date] NULL,
	[Cus_Telephone] [nvarchar](100) NULL,
	[Cus_Mobile] [nvarchar](100) NULL,
	[Cus_Fax] [nvarchar](100) NULL,
	[Cus_Email] [nvarchar](100) NULL,
	[Cus_Password] [nvarchar](50) NULL,
	[Cus_Withdraw_Code] [nvarchar](50) NULL,
	[Cus_Link_Shop] [nvarchar](500) NULL,
	[Cus_Point] [int] NULL,
	[Cus_Ref_ID] [int] NULL,
	[Cus_Active] [int] NULL,
	[Cus_Status] [int] NULL,
	[Activate_Date] [datetime] NULL,
	[Create_User] [nvarchar](100) NULL,
	[Create_Date] [datetime] NULL,
	[Update_User] [nvarchar](100) NULL,
	[Update_Date] [datetime] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Cus_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


