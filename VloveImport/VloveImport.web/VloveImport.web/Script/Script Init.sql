USE [VLOVE_IMPORT]
GO
/****** Object:  Table [dbo].[TB_TRANSPORT]    Script Date: 02/16/2015 17:33:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TB_TRANSPORT](
	[TS_ID] [int] IDENTITY(1,1) NOT NULL,
	[TS_DATE] [date] NULL,
	[TS_CODE] [varchar](100) NULL,
	[TS_DETAIL] [varchar](500) NULL,
	[TS_REMARK] [varchar](500) NULL,
	[TS_STAUTS] [int] NULL,
	[ORDER_ID] [int] NULL,
	[CREATE_USER] [varchar](100) NULL,
	[CREATE_DATE] [date] NULL,
	[UPDATE_USER] [varchar](100) NULL,
	[UPDATE_DATE] [date] NULL,
 CONSTRAINT [PK_TB_TRANSPORT] PRIMARY KEY CLUSTERED 
(
	[TS_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_TRANSACTION]    Script Date: 02/16/2015 17:33:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TB_TRANSACTION](
	[TRAN_ID] [int] IDENTITY(1,1) NOT NULL,
	[TRAN_TYPE] [int] NULL,
	[TRAN_TABLE_TYPE] [int] NULL,
	[TRAN_DETAIL] [varchar](500) NULL,
	[TRAN_REMARK] [varchar](500) NULL,
	[TRAN_DATE] [date] NULL,
	[TRAN_AMOUNT] [float] NULL,
	[TRAN_STATUS] [int] NULL,
	[TRAN_STATUS_APPROVE] [int] NULL,
	[EMP_ID_APPROVE] [int] NULL,
	[EMP_APPROVE_DATE] [int] NULL,
	[EMP_REMARK] [varchar](500) NULL,
	[CUS_ID] [int] NULL,
	[CUS_ACC_NAME_ID] [int] NULL,
	[ORDER_ID] [int] NULL,
	[PAYMENT_TYPE] [int] NULL,
	[PAYMENT_DATE] [date] NULL,
	[PAYMENT_TIME] [varchar](5) NULL,
	[BANK_ID] [int] NULL,
 CONSTRAINT [PK_TB_TRANSACTION] PRIMARY KEY CLUSTERED 
(
	[TRAN_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_PRODUCT]    Script Date: 02/16/2015 17:33:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TB_PRODUCT](
	[PROD_ID] [int] IDENTITY(1,1) NOT NULL,
	[PROD_NAME] [varchar](500) NULL,
	[PROD_LINK] [varchar](500) NULL,
	[PROD_SIZE] [varchar](500) NULL,
	[PROD_COLOR] [varchar](500) NULL,
	[CREATE_USER] [varchar](100) NULL,
	[CREATE_DATE] [date] NULL,
	[UPDATE_USER] [varchar](100) NULL,
	[UPDATE_DATE] [date] NULL,
 CONSTRAINT [PK_TB_PRODUCT] PRIMARY KEY CLUSTERED 
(
	[PROD_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_ORDER_DETAIL]    Script Date: 02/16/2015 17:33:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TB_ORDER_DETAIL](
	[OD_ID] [int] IDENTITY(1,1) NOT NULL,
	[ORDER_ID] [int] NULL,
	[PROD_ID] [int] NULL,
	[PROD_PRICE] [float] NULL,
	[PROD_NUMBER_ORDER] [int] NULL,
	[PROD_NUMBER_ACTIVE] [int] NULL,
	[PROD_REMARK] [varchar](500) NULL,
	[UPDATE_USER] [varchar](100) NULL,
	[UPDATE_DATE] [date] NULL,
 CONSTRAINT [PK_TB_ORDER_DETAIL] PRIMARY KEY CLUSTERED 
(
	[OD_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_ORDER]    Script Date: 02/16/2015 17:33:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TB_ORDER](
	[ORDER_ID] [int] IDENTITY(1,1) NOT NULL,
	[ORDER_DATE] [date] NULL,
	[ORDER_STATUS] [int] NULL,
	[CUS_ID] [int] NULL,
	[CREATE_USER] [varchar](100) NULL,
	[CREATE_DATE] [date] NULL,
	[UPDATE_USER] [varchar](100) NULL,
	[UPDATE_DATE] [date] NULL,
 CONSTRAINT [PK_TB_ORDER] PRIMARY KEY CLUSTERED 
(
	[ORDER_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_MASTER_SUB_DISTRICT]    Script Date: 02/16/2015 17:33:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TB_MASTER_SUB_DISTRICT](
	[SUB_DISTRICT_ID] [int] NOT NULL,
	[DISTRICT_ID] [int] NULL,
	[SUB_DISTRICT_NAME] [varchar](100) NULL,
	[POST_CODE] [varchar](10) NULL,
	[SUB_DISTRICT_STATUS] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_MASTER_REGION]    Script Date: 02/16/2015 17:33:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TB_MASTER_REGION](
	[REGION_ID] [int] NOT NULL,
	[REGION_Name] [varchar](100) NULL,
	[REGION_Status] [int] NOT NULL,
 CONSTRAINT [PK_TB_MASTER_REGION] PRIMARY KEY CLUSTERED 
(
	[REGION_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_MASTER_PROVINCE]    Script Date: 02/16/2015 17:33:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TB_MASTER_PROVINCE](
	[PROVINCE_ID] [int] NOT NULL,
	[Province_Name] [varchar](100) NULL,
	[Province_Status] [int] NULL,
	[REGION_ID] [int] NOT NULL,
 CONSTRAINT [PK_TB_MASTER_PROVINCE] PRIMARY KEY CLUSTERED 
(
	[PROVINCE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_MASTER_DISTRICT]    Script Date: 02/16/2015 17:33:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TB_MASTER_DISTRICT](
	[DISTRICT_ID] [int] NOT NULL,
	[DISTRICT_NAME] [varchar](50) NOT NULL,
	[DISTRICT_STATUS] [int] NULL,
	[PROVINCE_ID] [int] NOT NULL,
 CONSTRAINT [PK_TB_MASTER_DISTRICT] PRIMARY KEY CLUSTERED 
(
	[DISTRICT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_GROUP_USER]    Script Date: 02/16/2015 17:33:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TB_GROUP_USER](
	[GROUP_ID] [int] IDENTITY(1,1) NOT NULL,
	[GROUP_NAME] [varchar](100) NULL,
	[GROUP_ROLE] [varchar](4000) NULL,
	[GROUP_REMARK] [varchar](500) NULL,
	[GROUP_STATUS] [int] NULL,
	[CREATE_USER] [varchar](100) NULL,
	[CREATE_DATE] [date] NULL,
	[UPDATE_USER] [varchar](100) NULL,
	[UPDATE_DATE] [date] NULL,
 CONSTRAINT [PK_TB_GROUP_USER] PRIMARY KEY CLUSTERED 
(
	[GROUP_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_EMPLOYEE]    Script Date: 02/16/2015 17:33:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TB_EMPLOYEE](
	[EMP_ID] [int] IDENTITY(1,1) NOT NULL,
	[EMP_NAME] [varchar](100) NULL,
	[EMP_LNAME] [varchar](100) NULL,
	[EMP_DETAIL] [varchar](500) NULL,
	[EMP_STATUS] [int] NULL,
	[GROUP_ID] [int] NULL,
	[CREATE_USER] [varchar](100) NULL,
	[CREATE_DATE] [date] NULL,
	[UPDATE_USER] [varchar](100) NULL,
	[UPDATE_DATE] [date] NULL,
 CONSTRAINT [PK_TB_EMPLOYEE] PRIMARY KEY CLUSTERED 
(
	[EMP_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_CUSTOMER_FAVORIT_SHOP]    Script Date: 02/16/2015 17:33:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TB_CUSTOMER_FAVORIT_SHOP](
	[CUS_SHOP_ID] [int] IDENTITY(1,1) NOT NULL,
	[CUS_SHOP_NAME] [varchar](100) NULL,
	[CUS_SHOP_LINK] [varchar](500) NULL,
	[CUS_SHOP_REMARK] [varchar](500) NULL,
	[CUS_SHOP_STATUS] [int] NULL,
	[CUS_ID] [int] NULL,
	[CREATE_USER] [varchar](100) NULL,
	[CREATE_DATE] [date] NULL,
	[UPDATE_USER] [varchar](100) NULL,
	[UPDATE_DATE] [date] NULL,
 CONSTRAINT [PK_TB_CUSTOMER_FAVORIT_SHOP] PRIMARY KEY CLUSTERED 
(
	[CUS_SHOP_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_CUSTOMER_BASKET]    Script Date: 02/16/2015 17:33:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TB_CUSTOMER_BASKET](
	[CUS_ID] [int] NOT NULL,
	[PROD_ID] [int] NULL,
	[CUS_BK_NUMBER] [int] NULL,
	[CUS_BK_PRICE] [float] NULL,
	[CUS_BK_REMARK] [varchar](500) NULL,
	[CREATE_USER] [varchar](100) NULL,
	[CREATE_DATE] [date] NULL,
	[UPDATE_USER] [varchar](100) NULL,
	[UPDATE_DATE] [date] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_CUSTOMER_ADDRESS]    Script Date: 02/16/2015 17:33:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TB_CUSTOMER_ADDRESS](
	[CUS_ADD_ID] [int] IDENTITY(1,1) NOT NULL,
	[CUS_ADD_CUS_NAME] [varchar](200) NULL,
	[CUS_ADD_ADDRESS_TEXT] [varchar](500) NULL,
	[CUS_ADD_ZIPCODE] [int] NULL,
	[CUS_ADD_STATUS] [int] NULL,
	[CUS_ID] [int] NULL,
	[REGION_ID] [int] NULL,
	[PROVINCE_ID] [int] NULL,
	[DISTRICT_ID] [int] NULL,
	[SUB_DISTRICT_ID] [int] NULL,
	[CREATE_USER] [varchar](100) NULL,
	[CREATE_DATE] [date] NULL,
	[UPDATE_USER] [varchar](100) NULL,
	[UPDATE_DATE] [date] NULL,
 CONSTRAINT [PK_TB_CUSTOMER_ADDRESS] PRIMARY KEY CLUSTERED 
(
	[CUS_ADD_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0 = ยกเลิกใช้งาน, 1 = ใช้งาน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_CUSTOMER_ADDRESS', @level2type=N'COLUMN',@level2name=N'CUS_ADD_STATUS'
GO
/****** Object:  Table [dbo].[TB_CUSTOMER_ACC_NAME]    Script Date: 02/16/2015 17:33:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TB_CUSTOMER_ACC_NAME](
	[CUS_ACC_NAME_ID] [int] IDENTITY(1,1) NOT NULL,
	[CUS_ACC_NAME_NO] [varchar](100) NULL,
	[CUS_ACC_NAME_BRANCH] [varchar](100) NULL,
	[CUS_ACC_NAME_REMARK] [varchar](500) NULL,
	[CUS_ACC_NAME_STAUTS] [int] NULL,
	[CUS_ID] [int] NULL,
	[BANK_ID] [int] NULL,
	[CREATE_USER] [varchar](100) NULL,
	[CREATE_DATE] [date] NULL,
	[UPDATE_USER] [varchar](100) NULL,
	[UPDATE_DATE] [date] NULL,
 CONSTRAINT [PK_TB_CUSTOMER_ACC_NAME] PRIMARY KEY CLUSTERED 
(
	[CUS_ACC_NAME_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_CUSTOMER]    Script Date: 02/16/2015 17:33:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TB_CUSTOMER](
	[CUS_ID] [int] IDENTITY(1,1) NOT NULL,
	[CUS_NAME] [varchar](100) NULL,
	[CUS_LNAME] [varchar](100) NULL,
	[CUS_GENDER] [varchar](1) NULL,
	[CUS_BIRTHDAY] [date] NULL,
	[CUS_TELEPHONE] [varchar](100) NULL,
	[CUS_MOBILE] [varchar](100) NULL,
	[CUS_FAX] [varchar](100) NULL,
	[CUS_EMAIL] [varchar](100) NULL,
	[CUS_PASSWORD] [varchar](50) NULL,
	[CUS_WITHDRAW_CODE] [varchar](50) NULL,
	[CUS_LINK_SHOP] [varchar](500) NULL,
	[CUS_POINT] [int] NULL,
	[CUS_REF_ID] [int] NULL,
	[CUS_ACTIVATE] [int] NULL,
	[CUS_STATUS] [int] NULL,
	[ACTIVATE_DATE] [date] NULL,
	[CREATE_USER] [varchar](100) NULL,
	[CREATE_DATE] [date] NULL,
	[UPDATE_USER] [varchar](100) NULL,
	[UPDATE_DATE] [date] NULL,
 CONSTRAINT [PK_TB_CUSTOMER] PRIMARY KEY CLUSTERED 
(
	[CUS_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_CONFIG]    Script Date: 02/16/2015 17:33:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TB_CONFIG](
	[CONFIG_ID] [varchar](500) NOT NULL,
	[CONFIG_VALUE] [varchar](500) NULL,
	[CONFIG_GROUP] [varchar](500) NULL,
	[CONFIG_REMARK] [varchar](500) NULL,
	[CREATE_USER] [varchar](100) NULL,
	[CREATE_DATE] [date] NULL,
	[UPDATE_USER] [varchar](100) NULL,
	[UPDATE_DATE] [date] NULL,
 CONSTRAINT [PK_TB_CONFIG] PRIMARY KEY CLUSTERED 
(
	[CONFIG_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_BANK]    Script Date: 02/16/2015 17:33:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TB_BANK](
	[BANK_ID] [int] IDENTITY(1,1) NOT NULL,
	[BANK_NAME] [varchar](100) NULL,
	[BANK_ACCOUNT_NO] [varchar](100) NULL,
	[BANK_REMARK] [varchar](500) NULL,
	[BANK_STATUS] [int] NULL,
	[CREATE_USER] [varchar](100) NULL,
	[CREATE_DATE] [date] NULL,
	[UPDATE_USER] [varchar](100) NULL,
	[UPDATE_DATE] [date] NULL,
 CONSTRAINT [PK_TB_BANK] PRIMARY KEY CLUSTERED 
(
	[BANK_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

GO
/****** Object:  StoredProcedure [dbo].[GetLogOnCustomer]    Script Date: 2/16/2015 5:45:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetLogOnCustomer]
	-- Add the parameters for the stored procedure here
	@UserName varchar(200)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM TB_Customer 
	WHERE Cus_Email = @UserName
END

GO
/****** Object:  StoredProcedure [dbo].[InsertRegisCustomer]    Script Date: 2/16/2015 5:45:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertRegisCustomer]
	-- Add the parameters for the stored procedure here
	@Cus_Email varchar(100),
	@Cus_Password varchar(50),
	@Cus_Mobile varchar(100),
	@Cus_Ref_ID int
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT TB_Customer (
		Cus_Email,
		Cus_Password,
		Cus_Mobile,
		Cus_Ref_ID,
		Cus_Activate
	)values(
		@Cus_Email,
		@Cus_Password,
		@Cus_Mobile,
		@Cus_Ref_ID,
		0
	)	
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateActivateCustomer]    Script Date: 2/16/2015 5:45:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[UpdateActivateCustomer]
	-- Add the parameters for the stored procedure here
	@Cus_Email varchar(100),
	@Cus_Password varchar(50)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE TB_Customer 
	SET Cus_Activate = 1,
		Activate_Date = SYSDATETIME()
	WHERE Cus_Email = @Cus_Email
	AND Cus_Password = @Cus_Password
	
END
