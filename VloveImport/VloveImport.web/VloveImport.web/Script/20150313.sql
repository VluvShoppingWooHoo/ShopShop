USE [master]
GO
/****** Object:  Database [VLOVE_IMPORT]    Script Date: 3/13/2015 10:43:33 PM ******/
CREATE DATABASE [VLOVE_IMPORT]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'VLOVE_IMPORT', FILENAME = N'D:\Striker\Project\P''Bow\Phase 1\DB\VLOVE_IMPORT.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'VLOVE_IMPORT_log', FILENAME = N'D:\Striker\Project\P''Bow\Phase 1\DB\VLOVE_IMPORT_log.ldf' , SIZE = 2816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [VLOVE_IMPORT] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [VLOVE_IMPORT].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [VLOVE_IMPORT] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [VLOVE_IMPORT] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [VLOVE_IMPORT] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [VLOVE_IMPORT] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [VLOVE_IMPORT] SET ARITHABORT OFF 
GO
ALTER DATABASE [VLOVE_IMPORT] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [VLOVE_IMPORT] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [VLOVE_IMPORT] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [VLOVE_IMPORT] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [VLOVE_IMPORT] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [VLOVE_IMPORT] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [VLOVE_IMPORT] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [VLOVE_IMPORT] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [VLOVE_IMPORT] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [VLOVE_IMPORT] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [VLOVE_IMPORT] SET  DISABLE_BROKER 
GO
ALTER DATABASE [VLOVE_IMPORT] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [VLOVE_IMPORT] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [VLOVE_IMPORT] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [VLOVE_IMPORT] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [VLOVE_IMPORT] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [VLOVE_IMPORT] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [VLOVE_IMPORT] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [VLOVE_IMPORT] SET RECOVERY FULL 
GO
ALTER DATABASE [VLOVE_IMPORT] SET  MULTI_USER 
GO
ALTER DATABASE [VLOVE_IMPORT] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [VLOVE_IMPORT] SET DB_CHAINING OFF 
GO
ALTER DATABASE [VLOVE_IMPORT] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [VLOVE_IMPORT] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'VLOVE_IMPORT', N'ON'
GO
USE [VLOVE_IMPORT]
GO
/****** Object:  StoredProcedure [dbo].[GET_BASKET_LIST]    Script Date: 3/13/2015 10:43:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Batt
-- Create date: 2015-02-19
-- Description:	ค้นหาสินค้าในตะกร้า
-- =============================================
CREATE PROCEDURE [dbo].[GET_BASKET_LIST]
	-- Add the parameters for the stored procedure here
@CUS_ID as int = -1

AS
BEGIN
	
	SELECT
		*
	FROM TB_CUSTOMER_BASKET
	WHERE CUS_ID = @CUS_ID;
	
	      
END



GO
/****** Object:  StoredProcedure [dbo].[GET_CUSTOMER_ACCOUNT_BANK]    Script Date: 3/13/2015 10:43:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Batt
-- Create date: 2015-02-19
-- Description:	ค้นหา ข้อมูลที่อยู่ ลูกค้า
-- =============================================
CREATE PROCEDURE [dbo].[GET_CUSTOMER_ACCOUNT_BANK]
	-- Add the parameters for the stored procedure here
@CUS_ID as int = -1
,@CUS_ACC_NAME_ID as int = -1
,@CUS_ACC_NAME as varchar(100) = ''
,@CUS_ACC_NAME_NO as varchar(100) = ''
,@CUS_ACC_NAME_BRANCH as varchar(100) = ''
,@CUS_ACC_NAME_STAUTS as int = 1
,@BANK_ID as int  = -1
,@Act as varchar(50) = ''

AS
BEGIN

	IF UPPER(@Act) = 'BINDDATA'
	BEGIN
			SELECT
				ROW_NUMBER() OVER(ORDER BY CUS_ACC_NAME,BANK.BANK_NAME ASC) AS ROW_INDEX,
				*
			FROM TB_CUSTOMER_ACC_NAME ACC
			INNER JOIN dbo.TB_MASTER_BANK BANK
			ON ACC.BANK_ID = BANK.BANK_ID
			WHERE CUS_ID = @CUS_ID
			ORDER BY CUS_ACC_NAME,BANK.BANK_NAME ASC;
	END;
	ELSE IF UPPER(@Act) = 'BINDDATA_BYID'
	BEGIN
			SELECT
				ROW_NUMBER() OVER(ORDER BY CUS_ACC_NAME,BANK.BANK_NAME ASC) AS ROW_INDEX,
				*
			FROM TB_CUSTOMER_ACC_NAME ACC
			INNER JOIN dbo.TB_MASTER_BANK BANK
			ON ACC.BANK_ID = BANK.BANK_ID
			AND CUS_ID = @CUS_ID
			AND CUS_ACC_NAME_ID = @CUS_ACC_NAME_ID
			ORDER BY CUS_ACC_NAME,BANK.BANK_NAME ASC;
	END;
	ELSE IF UPPER(@Act) = 'CHECK_DATA'
	BEGIN
			SELECT
				CUS_ACC_NAME_ID AS TB_ID,
				CUS_ACC_NAME,
				CUS_ACC_NAME_NO,
				CUS_ACC_NAME_BRANCH,
				BANK_ID
			FROM dbo.TB_CUSTOMER_ACC_NAME
			WHERE CUS_ID = @CUS_ID 
			AND CUS_ACC_NAME_ID = CASE WHEN @CUS_ACC_NAME_ID = -1 THEN CUS_ACC_NAME_ID ELSE @CUS_ACC_NAME_ID END
			AND CUS_ACC_NAME = CASE WHEN @CUS_ACC_NAME = '' THEN CUS_ACC_NAME ELSE @CUS_ACC_NAME END
			AND CUS_ACC_NAME_NO = CASE WHEN @CUS_ACC_NAME_NO = '' THEN CUS_ACC_NAME_NO ELSE @CUS_ACC_NAME_NO END
			AND CUS_ACC_NAME_BRANCH = CASE WHEN @CUS_ACC_NAME_BRANCH = '' THEN CUS_ACC_NAME_BRANCH ELSE @CUS_ACC_NAME_BRANCH END;
	END;	
	ELSE IF UPPER(@Act) = 'BINDDATA_DROPDOWN'
	BEGIN
			SELECT
				CUS_ACC_NAME_ID,
				(BANK_NAME + ' ' + CUS_ACC_NAME + ' ' + CUS_ACC_NAME_NO) CUS_ACC_DETAIL
			FROM TB_CUSTOMER_ACC_NAME CUS_BANK
			LEFT JOIN TB_MASTER_BANK MS_BANK
			ON CUS_BANK.BANK_ID = MS_BANK.BANK_ID
			WHERE CUS_ID = @CUS_ID;
	END;	
	      
END



GO
/****** Object:  StoredProcedure [dbo].[GET_CUSTOMER_ADDRESS]    Script Date: 3/13/2015 10:43:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Batt
-- Create date: 2015-02-19
-- Description:	ค้นหา ข้อมูลที่อยู่ ลูกค้า
-- =============================================
CREATE PROCEDURE [dbo].[GET_CUSTOMER_ADDRESS]
	-- Add the parameters for the stored procedure here
@CUS_ID as int = -1
,@CUS_ADD_ID as int = -1
,@CUS_ADD_CUS_NAME as varchar(200) = ''
,@CUS_ADDRESS_STATUS as int = 1
,@REGION_ID as int = -1
,@PROVINCE_ID as int = -1
,@CUS_ADD_ZIPCODE as int = -1
,@Act as varchar(50) = ''

AS
BEGIN

	IF UPPER(@Act) = 'BINDDATA'
	BEGIN
			SELECT 
				ROW_NUMBER() OVER(ORDER BY CUS_ADD_ID ASC) AS ROW_INDEX,
				(CUS_ADD_ADDRESS_TEXT + ' ' + ISNULL(DISTRICT_NAME,'') + ' ' + ISNULL(SUB_DISTRICT_NAME,'') + ' ' + CAST(CUS_ADD_ZIPCODE AS VARCHAR(5))) as ADDRESS_FULL,
				* 
			FROM TB_CUSTOMER_ADDRESS CUS_ADD
			LEFT JOIN TB_MASTER_SUB_DISTRICT SUB_DIS
			ON CUS_ADD.SUB_DISTRICT_ID = SUB_DIS.SUB_DISTRICT_ID
			LEFT JOIN TB_MASTER_DISTRICT DIS
			ON CUS_ADD.DISTRICT_ID = DIS.DISTRICT_ID
			LEFT JOIN TB_MASTER_PROVINCE PRO
			ON CUS_ADD.PROVINCE_ID = PRO.PROVINCE_ID
			LEFT JOIN TB_MASTER_REGION REG
			ON CUS_ADD.REGION_ID = REG.REGION_ID
			WHERE CUS_ID = @CUS_ID;
	END;
	ELSE IF UPPER(@Act) = 'BINDDATA_BYID'
	BEGIN
			SELECT 
				ROW_NUMBER() OVER(ORDER BY CUS_ADD_ID ASC) AS ROW_INDEX,
				* 
			FROM TB_CUSTOMER_ADDRESS WHERE CUS_ID = @CUS_ID AND CUS_ADD_ID = @CUS_ADD_ID;
	END;
	ELSE IF UPPER(@Act) = 'CHECK_DATA'
	BEGIN
			SELECT
				CUS_ADD_ID,
				CUS_ADD_CUS_NAME,
				CUS_ADD_ZIPCODE,
				REGION_ID,
				PROVINCE_ID
			FROM TB_CUSTOMER_ADDRESS
			WHERE CUS_ID = @CUS_ID 
			AND CUS_ADD_ID = CASE WHEN @CUS_ADD_ID = -1 THEN CUS_ADD_ID ELSE @CUS_ADD_ID END
			AND CUS_ADD_CUS_NAME = CASE WHEN @CUS_ADD_CUS_NAME = '' THEN CUS_ADD_CUS_NAME ELSE @CUS_ADD_CUS_NAME END
			AND CUS_ADD_ZIPCODE = CASE WHEN @CUS_ADD_ZIPCODE = -1 THEN CUS_ADD_ZIPCODE ELSE @CUS_ADD_ZIPCODE END
			AND REGION_ID = CASE WHEN @REGION_ID = -1 THEN REGION_ID ELSE @REGION_ID END
			AND PROVINCE_ID = CASE WHEN @PROVINCE_ID = -1 THEN PROVINCE_ID ELSE @PROVINCE_ID END;
	END;			
	      
END



GO
/****** Object:  StoredProcedure [dbo].[GET_CUSTOMER_FAVORIT_SHOP]    Script Date: 3/13/2015 10:43:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Batt
-- Create date: 2015-02-19
-- Description:	ค้นหา ข้อมูลร้านค้าที่ลูกค้าชื่นชอบ
-- =============================================
CREATE PROCEDURE [dbo].[GET_CUSTOMER_FAVORIT_SHOP]
	-- Add the parameters for the stored procedure here
@CUS_ID as int = -1
,@CUS_SHOP_ID as int = -1
,@CUS_SHOP_NAME as varchar(100) = ''
,@CUS_SHOP_STATUS as int = 1
,@Act as varchar(50) = ''

AS
BEGIN

	IF UPPER(@Act) = 'BINDDATA'
	BEGIN
			SELECT
				ROW_NUMBER() OVER(ORDER BY CUS_SHOP_NAME ASC) AS ROW_INDEX,
				*
			FROM TB_CUSTOMER_FAVORIT_SHOP ACC
			WHERE CUS_ID = @CUS_ID
			ORDER BY CUS_SHOP_NAME ASC;
	END;
	ELSE IF UPPER(@Act) = 'BINDDATA_BYID'
	BEGIN
			SELECT
				ROW_NUMBER() OVER(ORDER BY CUS_SHOP_NAME ASC) AS ROW_INDEX,
				*
			FROM TB_CUSTOMER_FAVORIT_SHOP ACC
			WHERE CUS_ID = @CUS_ID
			AND CUS_SHOP_ID = @CUS_SHOP_ID
			ORDER BY CUS_SHOP_NAME ASC;
	END;
	ELSE IF UPPER(@Act) = 'CHECK_DATA'
	BEGIN
			SELECT
				CUS_SHOP_ID TB_ID,
				CUS_SHOP_NAME
			FROM TB_CUSTOMER_FAVORIT_SHOP
			WHERE CUS_ID = @CUS_ID 
			AND CUS_SHOP_NAME = CASE WHEN @CUS_SHOP_NAME = '' THEN CUS_SHOP_NAME ELSE @CUS_SHOP_NAME END;
	END;	
	      
END



GO
/****** Object:  StoredProcedure [dbo].[GET_CUSTOMER_PROFILE]    Script Date: 3/13/2015 10:43:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Batt
-- Create date: 2015-02-19
-- Description:	ค้นหา ข้อมูลที่อยู่ ลูกค้า
-- =============================================
CREATE PROCEDURE [dbo].[GET_CUSTOMER_PROFILE]
	-- Add the parameters for the stored procedure here
@CUS_ID as int = -1

AS
BEGIN

	SELECT
		*
	FROM TB_CUSTOMER

	WHERE CUS_ID = @CUS_ID

	      
END



GO
/****** Object:  StoredProcedure [dbo].[GET_DATA_BANK_SHOP]    Script Date: 3/13/2015 10:43:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Batt
-- Create date: 2015-02-19
-- Description:	ค้นหา ข้อมูล ธนาคาร หน้า Admin
-- =============================================
CREATE PROCEDURE [dbo].[GET_DATA_BANK_SHOP]
	-- Add the parameters for the stored procedure here
@BANK_SHOP_ID as int = -1,
@BANK_ID as int,
@BANK_SHOP_ACCOUNT_NO as varchar(100),
@BANK_SHOP_ACCOUNT_NAME as varchar(100),
@Act as varchar(50) = ''

AS
BEGIN

	IF UPPER(@Act) = 'BINDDATA'
	BEGIN
			SELECT 
				ROW_NUMBER() OVER(ORDER BY BANK_NAME ASC) AS ROW_INDEX,
				CASE WHEN BANK_SHOP_STATUS = 1 THEN 'ใช้งาน' ELSE 'ไม่ใช้งาน' END BANK_SHOP_STATUS_TEXT,
				*
			FROM TB_BANK_SHOP SP
			INNER JOIN TB_MASTER_BANK BK
			ON SP.BANK_ID = BK.BANK_ID
			ORDER BY BANK_NAME ASC;
	END;
	ELSE IF UPPER(@Act) = 'BINDDATA_BYID'
	BEGIN
			SELECT 
				*
			FROM TB_BANK_SHOP 
			WHERE BANK_SHOP_ID = @BANK_SHOP_ID;
	END;
	ELSE IF UPPER(@Act) = 'CHECK_DATA'
	BEGIN
			SELECT 
				BANK_SHOP_ID,
				BANK_ID,
				BANK_SHOP_ACCOUNT_NO,
				BANK_SHOP_ACCOUNT_NAME
			FROM TB_BANK_SHOP 
			WHERE BANK_ID = CASE WHEN @BANK_ID = -1 THEN BANK_ID ELSE @BANK_ID END
			AND BANK_SHOP_ACCOUNT_NO = CASE WHEN @BANK_SHOP_ACCOUNT_NO = '' THEN BANK_SHOP_ACCOUNT_NO ELSE @BANK_SHOP_ACCOUNT_NO END
			AND BANK_SHOP_ACCOUNT_NAME = CASE WHEN @BANK_SHOP_ACCOUNT_NAME = '' THEN BANK_SHOP_ACCOUNT_NAME ELSE @BANK_SHOP_ACCOUNT_NAME END;
	END;	
	ELSE IF UPPER(@Act) = 'BINDDATA_RB'
	BEGIN
	--1. หมายเลขบัญชี 236-4-03393-2คุณ ทิพวรรณ คล่องแคล่ว สาขา หนองแขม
		  SELECT
				BANK_SHOP_ID,
				(CAST(ROW_INDEX AS VARCHAR(10)) + '.' + 'หมายเลขบัญชี ' + BANK_SHOP_ACCOUNT_NO + ' ' + BANK_SHOP_ACCOUNT_NAME) BANK_SHOP_ACCOUNT_NO
		  FROM
		  (
			SELECT 
				ROW_NUMBER() OVER(ORDER BY BANK_NAME ASC) AS ROW_INDEX,
				SP.*,
				BANK_NAME
			FROM TB_BANK_SHOP SP
			INNER JOIN TB_MASTER_BANK BK
			ON SP.BANK_ID = BK.BANK_ID		  
		  )BANK_SHOP
		  ORDER BY BANK_NAME ASC;
	END;
	      
END



GO
/****** Object:  StoredProcedure [dbo].[GET_DATA_MASTER_ADDRESS]    Script Date: 3/13/2015 10:43:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Batt
-- Create date: 2015-02-19
-- Description:	ดึงข้อมูล ภาค จังหวัด อำเภอ ตำบล
-- =============================================
CREATE PROCEDURE [dbo].[GET_DATA_MASTER_ADDRESS]
	-- Add the parameters for the stored procedure here
@ADD_ID as int = -1
,@ADD_NAME as varchar(100) = ''
,@ADD_STATUS as int = -1
,@Act as varchar(50) = null

AS
BEGIN

	IF UPPER(@Act) = 'REGION'
	BEGIN
			SELECT 
				ROW_NUMBER() OVER(ORDER BY RE.REGION_Name ASC) AS ROW_INDEX,
				RE.* 
			FROM TB_MASTER_REGION RE
			WHERE RE.REGION_NAME LIKE CASE WHEN @ADD_NAME = '' THEN RE.REGION_NAME ELSE '%' + @ADD_NAME + '%' END
			AND RE.REGION_Status = CASE WHEN @ADD_STATUS = -1 THEN RE.REGION_Status ELSE @ADD_STATUS END
			ORDER BY RE.REGION_Name ASC;
	END;
	
	IF UPPER(@Act) = 'PROVINCE'
	BEGIN
			SELECT 
				ROW_NUMBER() OVER(ORDER BY PRO.Province_Name ASC) AS ROW_INDEX,
				* 
			FROM TB_MASTER_REGION RE
			INNER JOIN TB_MASTER_PROVINCE PRO
			ON RE.REGION_ID = PRO.REGION_ID
			AND PRO.Province_Name LIKE CASE WHEN @ADD_NAME = '' THEN PRO.Province_Name ELSE '%' + @ADD_NAME + '%' END
			AND PRO.Province_Status = CASE WHEN @ADD_STATUS = -1 THEN PRO.Province_Status ELSE @ADD_STATUS END
			AND PRO.REGION_ID = CASE WHEN @ADD_ID = -1 THEN PRO.REGION_ID ELSE @ADD_ID END
			ORDER BY PRO.Province_Name ASC;
	END;	
	
	IF UPPER(@Act) = 'DISTRICT'
	BEGIN
			SELECT 
				ROW_NUMBER() OVER(ORDER BY DIS.DISTRICT_NAME ASC) AS ROW_INDEX,
				* 
			FROM TB_MASTER_PROVINCE PRO
			INNER JOIN TB_MASTER_DISTRICT DIS
			ON PRO.PROVINCE_ID = DIS.PROVINCE_ID
			AND DIS.DISTRICT_NAME LIKE CASE WHEN @ADD_NAME = '' THEN DIS.DISTRICT_NAME ELSE '%' + @ADD_NAME + '%' END
			AND DIS.DISTRICT_STATUS = CASE WHEN @ADD_STATUS = -1 THEN DIS.DISTRICT_STATUS ELSE @ADD_STATUS END
			AND DIS.PROVINCE_ID = CASE WHEN @ADD_ID = -1 THEN DIS.PROVINCE_ID ELSE @ADD_ID END
			ORDER BY DIS.DISTRICT_NAME ASC;
	END;
	
	IF UPPER(@Act) = 'SUB_DISTRICT'
	BEGIN
			SELECT 
				ROW_NUMBER() OVER(ORDER BY SUB.SUB_DISTRICT_NAME ASC) AS ROW_INDEX,
				* 
			FROM TB_MASTER_DISTRICT DIS
			INNER JOIN TB_MASTER_SUB_DISTRICT SUB
			ON DIS.DISTRICT_ID = SUB.DISTRICT_ID
			AND SUB.SUB_DISTRICT_NAME LIKE CASE WHEN @ADD_NAME = '' THEN SUB.SUB_DISTRICT_NAME ELSE '%' + @ADD_NAME + '%' END
			AND SUB.SUB_DISTRICT_STATUS = CASE WHEN @ADD_STATUS = -1 THEN SUB.SUB_DISTRICT_STATUS ELSE @ADD_STATUS END
			AND SUB.DISTRICT_ID = CASE WHEN @ADD_ID = -1 THEN SUB.DISTRICT_ID ELSE @ADD_ID END
			ORDER BY SUB.SUB_DISTRICT_NAME ASC;
	END;	
	      
END



GO
/****** Object:  StoredProcedure [dbo].[GET_DATA_MASTER_BANK]    Script Date: 3/13/2015 10:43:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Batt
-- Create date: 2015-02-19
-- Description:	ค้นหา ข้อมูล ธนาคาร หน้า Admin
-- =============================================
CREATE PROCEDURE [dbo].[GET_DATA_MASTER_BANK]
	-- Add the parameters for the stored procedure here
@BANK_ID as int = -1,
@BANK_NAME as varchar(100),
@BANK_STATUS as int = -1,
@Act as varchar(50) = ''

AS
BEGIN

	IF UPPER(@Act) = 'BINDDATA'
	BEGIN
			SELECT 
				ROW_NUMBER() OVER(ORDER BY BANK_NAME ASC) AS ROW_INDEX,
				BANK_ID,
				BANK_NAME,
				CASE WHEN BANK_STATUS = 1 THEN 'ใช้งาน' ELSE 'ไม่ใช้งาน' END BANK_STATUS_TEXT
			FROM TB_MASTER_BANK
			ORDER BY BANK_NAME ASC;
	END;
	      
END



GO
/****** Object:  StoredProcedure [dbo].[GET_DATA_TRANSACTION]    Script Date: 3/13/2015 10:43:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Batt
-- Create date: 2015-02-19
-- Description:	ค้นหา ข้อมูล การทำรายการ การเงินของลูกค้า
-- =============================================
CREATE PROCEDURE [dbo].[GET_DATA_TRANSACTION]
	-- Add the parameters for the stored procedure here
@TRAN_ID as int = -1
,@TRAN_TYPE as int = -1
,@TRAN_TABLE_TYPE as int = -1
,@TRAN_DATE_FORM as date = NULL
,@TRAN_DATE_TO as date = NULL
,@TRAN_STATUS as int = -1
,@TRAN_STATUS_APPROVE as int = -1
,@CUS_ID as int = null
,@Act as varchar(50) = ''

AS
BEGIN

	IF UPPER(@Act) = 'BINDDATA_BY_CUS'
	BEGIN
			SELECT 
				ROW_NUMBER() OVER(ORDER BY TRAN_DATE ASC) AS ROW_INDEX,
				*
			FROM TB_TRANSACTION TRANSAC
			--LEFT JOIN
			ORDER BY TRAN_DATE ASC;
	END;
	ELSE IF UPPER(@Act) = 'BINDDATA_BYID'
	BEGIN
			SELECT 
				ROW_NUMBER() OVER(ORDER BY BANK_NAME ASC) AS ROW_INDEX,
				*
			FROM TB_BANK 
			ORDER BY BANK_NAME ASC;
	END;
	ELSE IF UPPER(@Act) = 'BINDDATA_BY_EMP'
	BEGIN
			SELECT 
				ROW_NUMBER() OVER(ORDER BY BANK_NAME ASC) AS ROW_INDEX,
				*
			FROM TB_BANK 
			ORDER BY BANK_NAME ASC;
	END;
	      
END



GO
/****** Object:  StoredProcedure [dbo].[GET_TRANS_LIST]    Script Date: 3/13/2015 10:43:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Batt
-- Create date: 2015-02-19
-- Description:	ค้นหาสินค้าในตะกร้า
-- =============================================
CREATE PROCEDURE [dbo].[GET_TRANS_LIST]
	-- Add the parameters for the stored procedure here
@TYPEE as varchar(50)

AS
BEGIN
	
	SELECT
		*
	FROM TB_MASTER_TRANSPOT
	WHERE TRANS_TYPE = @TYPEE;
	
	      
END



GO
/****** Object:  StoredProcedure [dbo].[GetLogOnCustomer]    Script Date: 3/13/2015 10:43:33 PM ******/
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
/****** Object:  StoredProcedure [dbo].[INS_ORDER]    Script Date: 3/13/2015 10:43:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[INS_ORDER]
	-- Add the parameters for the stored procedure here
	@ORDER_STATUS varchar(100),
	@Cus_ID int,
	@ORDER_TRANSPOT_CHINA int,
	@ORDER_TRANSPOT_THAI int,
	@CREATE_USER varchar(100),
	@ORDER_ID int Output
	
AS
BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT TB_ORDER (
		ORDER_DATE,
		ORDER_STATUS,
		CUS_ID,		
		ORDER_TRANSPOT_CHINA,
		ORDER_TRANSPOT_THAI,
		CREATE_USER,
		CREATE_DATE
	)
	values(
		GETDATE(),
		@ORDER_STATUS,
		@Cus_ID,
		@ORDER_TRANSPOT_CHINA,
		@ORDER_TRANSPOT_THAI,
		@CREATE_USER,
		GETDATE()
	)	;

	select @ORDER_ID = SCOPE_IDENTITY();
END


GO
/****** Object:  StoredProcedure [dbo].[INS_ORDER_DETAIL]    Script Date: 3/13/2015 10:43:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[INS_ORDER_DETAIL]
	-- Add the parameters for the stored procedure here	
	@ORDER_ID int,
	@OD_ITEMNAME nvarchar(100),
	@OD_AMOUNT int,
	@OD_PRICE float,
	@OD_SIZE nvarchar(50),
	@OD_COLOR nvarchar(50),
	@OD_REMARK nvarchar(500),
	@OD_REF_BASKET int,
	@CREATE_USER varchar(100)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT TB_ORDER_DETAIL (
		ORDER_ID,
		OD_ITEMNAME,
		OD_AMOUNT,		
		OD_PRICE,
		OD_SIZE,
		OD_COLOR,
		OD_REMARK,
		OD_REF_BASKET,
		UPDATE_USER,
		UPDATE_DATE
	)values(
		@ORDER_ID,
		@OD_ITEMNAME,
		@OD_AMOUNT,
		@OD_PRICE,
		@OD_SIZE,
		@OD_COLOR,
		@OD_REMARK,
		@OD_REF_BASKET,
		@CREATE_USER,
		GETDATE()
	);

	UPDATE TB_CUSTOMER_BASKET
	SET CUS_BK_STATUS = 'ORDER'
	WHERE CUS_BK_ID = @OD_REF_BASKET;
END


GO
/****** Object:  StoredProcedure [dbo].[INS_SHOPPINGCART]    Script Date: 3/13/2015 10:43:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[INS_SHOPPINGCART]
	-- Add the parameters for the stored procedure here
	@CUS_ID int,
	@CUS_BK_ITEMNAME nvarchar(100),
	@CUS_BK_ITEMDESC nvarchar(500),
	@CUS_BK_AMOUNT int,
	@CUS_BK_PRICE decimal,
	@CUS_BK_SIZE nvarchar(50),
	@CUS_BK_COLOR nvarchar(50),
	@CUS_BK_REMARK varchar(500),
	@CUS_BK_URL varchar(500),
	@CUS_BK_PICURL varchar(500),
	@CUS_BK_STATUS varchar(50),
	@CREATE_USER varchar(100)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT TB_CUSTOMER_BASKET(
		CUS_ID,		
		CUS_BK_ITEMNAME,
		CUS_BK_ITEMDESC,
		CUS_BK_AMOUNT,
		CUS_BK_PRICE,
		CUS_BK_SIZE,
		CUS_BK_COLOR,
		CUS_BK_REMARK,
		CUS_BK_URL,
		CUS_BK_PICURL,
		CUS_BK_STATUS,
		CREATE_USER,
		CREATE_DATE
	)values(
		@CUS_ID,
		@CUS_BK_ITEMNAME,
		@CUS_BK_ITEMDESC,
		@CUS_BK_AMOUNT,
		@CUS_BK_PRICE,
		@CUS_BK_SIZE,
		@CUS_BK_COLOR,
		@CUS_BK_REMARK,
		@CUS_BK_URL,
		@CUS_BK_PICURL,
		@CUS_BK_STATUS,
		@CREATE_USER,
		SYSDATETIME()
	)	
END


GO
/****** Object:  StoredProcedure [dbo].[INS_UPD_CUSTOMER_ACCOUNT_BANK]    Script Date: 3/13/2015 10:43:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Batt
-- Create date: 2015-02-19
-- Description:	INSERT UPDATE ข้อมูลธนาคารลูกค้า
-- =============================================
CREATE PROCEDURE [dbo].[INS_UPD_CUSTOMER_ACCOUNT_BANK]
	-- Add the parameters for the stored procedure here
@CUS_ACC_NAME_ID as int  = NULL
,@CUS_ACC_NAME as varchar(100) = ''
,@CUS_ACC_NAME_NO as varchar(100) = ''
,@CUS_ACC_NAME_BRANCH as varchar(100) = ''
,@CUS_ACC_NAME_REMARK as varchar(500) = ''
,@CUS_ACC_NAME_STAUTS as int = null
,@CUS_ID as int  = NULL
,@BANK_ID as int  = NULL
,@CREATE_USER as varchar(100) = ''
,@Act as varchar(50) = ''

AS
BEGIN

	IF UPPER(@Act) = 'INS'
	BEGIN
			INSERT INTO TB_CUSTOMER_ACC_NAME 
				(
				   CUS_ACC_NAME
				   ,CUS_ACC_NAME_NO
				   ,CUS_ACC_NAME_BRANCH
				   ,CUS_ACC_NAME_REMARK
				   ,CUS_ACC_NAME_STAUTS
				   ,CUS_ID
				   ,BANK_ID
				   ,CREATE_USER
				   ,CREATE_DATE
				   ,UPDATE_USER
				   ,UPDATE_DATE
				)
			VALUES
				(
					@CUS_ACC_NAME,
					@CUS_ACC_NAME_NO,
					@CUS_ACC_NAME_BRANCH,
					@CUS_ACC_NAME_REMARK,
					@CUS_ACC_NAME_STAUTS,
					@CUS_ID,
					@BANK_ID,
					@CREATE_USER,
					GETDATE(),
					@CREATE_USER,
					GETDATE()
				);
	END;
	ELSE IF UPPER(@Act) = 'UPD'
	BEGIN
			UPDATE TB_CUSTOMER_ACC_NAME SET
				   CUS_ACC_NAME	= @CUS_ACC_NAME
				   ,CUS_ACC_NAME_NO = @CUS_ACC_NAME_NO
				   ,CUS_ACC_NAME_BRANCH = @CUS_ACC_NAME_BRANCH
				   ,CUS_ACC_NAME_REMARK = @CUS_ACC_NAME_REMARK
				   ,CUS_ACC_NAME_STAUTS = @CUS_ACC_NAME_STAUTS
				   ,BANK_ID = @BANK_ID
				   ,UPDATE_USER = @CREATE_USER
				   ,UPDATE_DATE = GETDATE()
			WHERE CUS_ACC_NAME_ID = @CUS_ACC_NAME_ID;
	END;
	ELSE IF UPPER(@Act) = 'DEL'
	BEGIN
			DELETE FROM TB_CUSTOMER_ACC_NAME 
			WHERE CUS_ACC_NAME_ID = @CUS_ACC_NAME_ID;
	END;	
	ELSE IF UPPER(@Act) = 'STATUS'
	BEGIN
			UPDATE TB_CUSTOMER_ACC_NAME SET
				   CUS_ACC_NAME_STAUTS = @CUS_ACC_NAME_STAUTS
				   ,UPDATE_USER = @CREATE_USER
				   ,UPDATE_DATE = GETDATE()
			WHERE CUS_ACC_NAME_ID = @CUS_ACC_NAME_ID;
	END;
	
	
	      
END



GO
/****** Object:  StoredProcedure [dbo].[INS_UPD_CUSTOMER_ADDRESS]    Script Date: 3/13/2015 10:43:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Batt
-- Create date: 2015-02-19
-- Description:	INSERT UPDATE ข้อมูลที่อยู่ ลูกค้า
-- =============================================
CREATE PROCEDURE [dbo].[INS_UPD_CUSTOMER_ADDRESS]
	-- Add the parameters for the stored procedure here
@CUS_ADD_ID as int = null
,@CUS_ADD_CUS_NAME as varchar(200) = ''
,@CUS_ADD_ADDRESS_TEXT as varchar(500) = ''
,@CUS_ADD_ZIPCODE as varchar(5) = ''
,@CUS_ADD_STATUS as int = NULL
,@CUS_ID as int  = NULL
,@REGION_ID as int = NULL
,@PROVINCE_ID as int = NULL
,@DISTRICT_ID as int = NULL
,@SUB_DISTRICT_ID as int = NULL
,@CREATE_USER as varchar(100) = ''
,@Act as varchar(50) = ''

AS
BEGIN

	IF UPPER(@Act) = 'INS'
	BEGIN
			INSERT INTO TB_CUSTOMER_ADDRESS 
				(
					CUS_ADD_CUS_NAME,
					CUS_ADD_ADDRESS_TEXT,
					CUS_ADD_ZIPCODE,
					CUS_ADD_STATUS,
					CUS_ID,
					REGION_ID,
					PROVINCE_ID,
					DISTRICT_ID,
					SUB_DISTRICT_ID,
					CREATE_USER,
					CREATE_DATE,
					UPDATE_USER,
					UPDATE_DATE
				)
			VALUES
				(
					@CUS_ADD_CUS_NAME,
					@CUS_ADD_ADDRESS_TEXT,
					CAST(@CUS_ADD_ZIPCODE AS INT),
					@CUS_ADD_STATUS,
					@CUS_ID,
					@REGION_ID,
					@PROVINCE_ID,
					@DISTRICT_ID,
					@SUB_DISTRICT_ID,
					@CREATE_USER,
					GETDATE(),
					@CREATE_USER,
					GETDATE()
				);
	END;
	ELSE IF UPPER(@Act) = 'UPD'
	BEGIN
			UPDATE TB_CUSTOMER_ADDRESS SET
				CUS_ADD_CUS_NAME = @CUS_ADD_CUS_NAME,
				CUS_ADD_ADDRESS_TEXT = @CUS_ADD_ADDRESS_TEXT,
				CUS_ADD_ZIPCODE = @CUS_ADD_ZIPCODE,
				CUS_ADD_STATUS = @CUS_ADD_STATUS,
				REGION_ID = @REGION_ID,
				PROVINCE_ID = @PROVINCE_ID,
				DISTRICT_ID = @DISTRICT_ID,
				SUB_DISTRICT_ID = @SUB_DISTRICT_ID,
				UPDATE_USER = @CREATE_USER,
				UPDATE_DATE = GETDATE()
			WHERE CUS_ADD_ID = @CUS_ADD_ID;
	END;
	ELSE IF UPPER(@Act) = 'DEL'
	BEGIN
			DELETE FROM TB_CUSTOMER_ADDRESS 
			WHERE CUS_ADD_ID = @CUS_ADD_ID;
	END;	
	ELSE IF UPPER(@Act) = 'STATUS'
	BEGIN
			UPDATE TB_CUSTOMER_ADDRESS SET 
				CUS_ADD_STATUS = @CUS_ADD_STATUS,
				UPDATE_USER = @CREATE_USER,
				UPDATE_DATE = GETDATE()
			WHERE CUS_ADD_ID = @CUS_ADD_ID;
	END;
	
	
	      
END



GO
/****** Object:  StoredProcedure [dbo].[INS_UPD_CUSTOMER_FAVORIT_SHOP]    Script Date: 3/13/2015 10:43:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Batt
-- Create date: 2015-02-19
-- Description:	INSERT UPDATE ข้อมูลร้านค้าที่ลูกค้าชอบ
-- =============================================
CREATE PROCEDURE [dbo].[INS_UPD_CUSTOMER_FAVORIT_SHOP]
	-- Add the parameters for the stored procedure here
@CUS_SHOP_ID as int  = NULL
,@CUS_SHOP_NAME as varchar(100) = ''
,@CUS_SHOP_LINK as varchar(100) = ''
,@CUS_SHOP_REMARK as varchar(100) = ''
,@CUS_SHOP_STATUS as varchar(500) = ''
,@CUS_ID as int  = NULL
,@CREATE_USER as varchar(100) = ''
,@Act as varchar(50) = ''

AS
BEGIN

	IF UPPER(@Act) = 'INS'
	BEGIN
			INSERT INTO TB_CUSTOMER_FAVORIT_SHOP 
				(
					CUS_SHOP_NAME
					,CUS_SHOP_LINK
					,CUS_SHOP_REMARK
					,CUS_SHOP_STATUS
					,CUS_ID
					,CREATE_USER
					,CREATE_DATE
					,UPDATE_USER
					,UPDATE_DATE
				)
			VALUES
				(
					@CUS_SHOP_NAME,
					@CUS_SHOP_LINK,
					@CUS_SHOP_REMARK,
					@CUS_SHOP_STATUS,
					@CUS_ID,
					@CREATE_USER,
					GETDATE(),
					@CREATE_USER,
					GETDATE()
				);
	END;
	ELSE IF UPPER(@Act) = 'UPD'
	BEGIN
			UPDATE TB_CUSTOMER_FAVORIT_SHOP SET
					CUS_SHOP_NAME = @CUS_SHOP_NAME
					,CUS_SHOP_LINK = @CUS_SHOP_LINK
					,CUS_SHOP_REMARK = @CUS_SHOP_REMARK
					,CUS_SHOP_STATUS = @CUS_SHOP_STATUS
					,UPDATE_USER  = @CREATE_USER
					,UPDATE_DATE = GETDATE()
			WHERE CUS_SHOP_ID = @CUS_SHOP_ID;
	END;
	ELSE IF UPPER(@Act) = 'DEL'
	BEGIN
			DELETE FROM TB_CUSTOMER_FAVORIT_SHOP 
			WHERE CUS_SHOP_ID = @CUS_SHOP_ID;
	END;	
	ELSE IF UPPER(@Act) = 'STATUS'
	BEGIN
			UPDATE TB_CUSTOMER_FAVORIT_SHOP SET
				   CUS_SHOP_STATUS = @CUS_SHOP_STATUS
				   ,UPDATE_USER = @CREATE_USER
				   ,UPDATE_DATE = GETDATE()
			WHERE CUS_SHOP_ID = @CUS_SHOP_ID;
	END;
	
	
	      
END



GO
/****** Object:  StoredProcedure [dbo].[INS_UPD_DATA_BANK_SHOP]    Script Date: 3/13/2015 10:43:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Batt
-- Create date: 2015-02-19
-- Description:	เพิ่ม แก้ไข ลบ ข้อมูล ธนาคาร หน้า Admin
-- =============================================
CREATE PROCEDURE [dbo].[INS_UPD_DATA_BANK_SHOP]
	-- Add the parameters for the stored procedure here
@BANK_SHOP_ID as int = -1,
@BANK_ID as int,
@BANK_SHOP_ACCOUNT_NO as varchar(100) = '',
@BANK_SHOP_ACCOUNT_NAME as varchar(100) = '',
@BANK_SHOP_REMARK as varchar(100) = '',
@BANK_SHOP_STATUS as int = 1,
@CREATE_USER as varchar(100) = '',
@Act as varchar(50) = ''

AS
BEGIN

	IF UPPER(@Act) = 'INS'
	BEGIN
			INSERT INTO TB_BANK_SHOP
			   (
				   BANK_ID
				   ,BANK_SHOP_ACCOUNT_NO
				   ,BANK_SHOP_ACCOUNT_NAME
				   ,BANK_SHOP_REMARK
				   ,BANK_SHOP_STATUS
				   ,CREATE_USER
				   ,CREATE_DATE
				   ,UPDATE_USER
				   ,UPDATE_DATE
			   )
			VALUES
				(
				   @BANK_ID
				   ,@BANK_SHOP_ACCOUNT_NO
				   ,@BANK_SHOP_ACCOUNT_NAME
				   ,@BANK_SHOP_REMARK
				   ,@BANK_SHOP_STATUS
				   ,@CREATE_USER
				   ,GETDATE()
				   ,@CREATE_USER
				   ,GETDATE()
				);
	END;
	ELSE IF UPPER(@Act) = 'UPD'
	BEGIN
			UPDATE TB_BANK_SHOP SET
				   BANK_ID = @BANK_ID
				   ,BANK_SHOP_ACCOUNT_NO = @BANK_SHOP_ACCOUNT_NO
				   ,BANK_SHOP_ACCOUNT_NAME = @BANK_SHOP_ACCOUNT_NAME
				   ,BANK_SHOP_REMARK = @BANK_SHOP_REMARK
				   ,BANK_SHOP_STATUS = @BANK_SHOP_STATUS
				   ,UPDATE_USER = @CREATE_USER
				   ,UPDATE_DATE = GETDATE()
			WHERE BANK_SHOP_ID = @BANK_SHOP_ID;
	END;
	ELSE IF UPPER(@Act) = 'DEL'
	BEGIN
			DELETE FROM TB_BANK_SHOP WHERE BANK_SHOP_ID = @BANK_SHOP_ID;
	END;	
	ELSE IF UPPER(@Act) = 'STATUS'
	BEGIN
			UPDATE TB_BANK_SHOP SET
				   BANK_SHOP_STATUS = @BANK_SHOP_STATUS
				   ,UPDATE_USER = @CREATE_USER
				   ,UPDATE_DATE = GETDATE()
			WHERE BANK_SHOP_ID = @BANK_SHOP_ID;
	END;	
	      
END



GO
/****** Object:  StoredProcedure [dbo].[INS_UPD_DATA_MASTER_BANK]    Script Date: 3/13/2015 10:43:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Batt
-- Create date: 2015-02-19
-- Description:	เพิ่ม แก้ไข ลบ ข้อมูล ธนาคาร หน้า Admin
-- =============================================
CREATE PROCEDURE [dbo].[INS_UPD_DATA_MASTER_BANK]
	-- Add the parameters for the stored procedure here
@BANK_ID as int = -1,
@BANK_NAME as varchar(100) = '',
@BANK_ACCOUNT_NO as varchar(100) = '',
@BANK_REMARK as varchar(100) = '',
@BANK_STATUS as int = 1,
@CREATE_USER as varchar(100) = '',
@Act as varchar(50) = ''

AS
BEGIN

	IF UPPER(@Act) = 'INS'
	BEGIN
			INSERT INTO TB_BANK
			   (
				   BANK_NAME
				   ,BANK_ACCOUNT_NO
				   ,BANK_REMARK
				   ,BANK_STATUS
				   ,CREATE_USER
				   ,CREATE_DATE
				   ,UPDATE_USER
				   ,UPDATE_DATE
			   )
			VALUES
				(
				   @BANK_NAME
				   ,@BANK_ACCOUNT_NO
				   ,@BANK_REMARK
				   ,@BANK_STATUS
				   ,@CREATE_USER
				   ,GETDATE()
				   ,@CREATE_USER
				   ,GETDATE()
				);
	END;
	ELSE IF UPPER(@Act) = 'UPD'
	BEGIN
			UPDATE TB_BANK SET
				   BANK_NAME = @BANK_NAME
				   ,BANK_ACCOUNT_NO = @BANK_NAME
				   ,BANK_REMARK = @BANK_NAME
				   ,BANK_STATUS = @BANK_NAME
				   ,UPDATE_USER = @BANK_NAME
				   ,UPDATE_DATE = GETDATE()
			WHERE BANK_ID = @BANK_ID;
	END;
	ELSE IF UPPER(@Act) = 'DEL'
	BEGIN
			DELETE FROM TB_BANK WHERE BANK_ID = @BANK_ID;
	END;	
	ELSE IF UPPER(@Act) = 'STATUS'
	BEGIN
			UPDATE TB_BANK SET
				   BANK_STATUS = @BANK_NAME
				   ,UPDATE_USER = @BANK_NAME
				   ,UPDATE_DATE = GETDATE()
			WHERE BANK_ID = @BANK_ID;
	END;	
	      
END



GO
/****** Object:  StoredProcedure [dbo].[INS_UPD_TRANSACTION]    Script Date: 3/13/2015 10:43:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Batt
-- Create date: 2015-02-19
-- Description:	INSERT UPDATE ข้อมูลธนาคารลูกค้า
-- =============================================
CREATE PROCEDURE [dbo].[INS_UPD_TRANSACTION]
	-- Add the parameters for the stored procedure here
@TRAN_ID as int  = NULL 
,@TRAN_TYPE as int  = NULL --1=เงินเข้า , 2 เงินออก
,@TRAN_TABLE_TYPE as int  = NULL --1 = Payment, 2 = Withdraw, 3 = Order, 4 = Non Product
,@TRAN_DETAIL as varchar(500) = ''
,@TRAN_REMARK as varchar(500) = ''
,@TRAN_AMOUNT as float = NULL
,@TRAN_STATUS as int  = NULL
,@TRAN_STATUS_APPROVE as int  = NULL
,@EMP_ID_APPROVE as int  = NULL
,@EMP_REMARK as varchar(500) = ''
,@CUS_ID as int  = NULL
,@CUS_ACC_NAME_ID as int  = NULL
,@ORDER_ID as int  = NULL
,@PAYMENT_TYPE as int  = NULL --1 = เติมเงินบัญชีในร้าน ,2 = โอนเงินเพื่อชำระการสั่งซื้อ
,@PAYMENT_DATE as date  = NULL
,@PAYMENT_TIME as varchar(8) = ''
,@BANK_ID as int  = NULL
,@Act as varchar(50) = ''

AS
BEGIN

	IF UPPER(@Act) = 'INS'
	BEGIN
			INSERT INTO TB_TRANSACTION 
				(
				   TRAN_TYPE
				   ,TRAN_TABLE_TYPE
				   ,TRAN_DETAIL
				   ,TRAN_REMARK
				   ,TRAN_DATE
				   ,TRAN_AMOUNT
				   ,TRAN_STATUS
				   ,TRAN_STATUS_APPROVE
				   ,EMP_ID_APPROVE
				   ,EMP_APPROVE_DATE
				   ,EMP_REMARK
				   ,CUS_ID
				   ,CUS_ACC_NAME_ID
				   ,ORDER_ID
				   ,PAYMENT_TYPE
				   ,PAYMENT_DATE
				   ,PAYMENT_TIME
				   ,BANK_ID
				)
			VALUES
				(
				   @TRAN_TYPE
				   ,@TRAN_TABLE_TYPE
				   ,@TRAN_DETAIL
				   ,@TRAN_REMARK
				   ,GETDATE()
				   ,@TRAN_AMOUNT
				   ,@TRAN_STATUS
				   ,@TRAN_STATUS_APPROVE
				   ,@EMP_ID_APPROVE
				   ,NULL
				   ,@EMP_REMARK
				   ,@CUS_ID
				   ,@CUS_ACC_NAME_ID
				   ,@ORDER_ID
				   ,@PAYMENT_TYPE
				   ,@PAYMENT_DATE
				   ,@PAYMENT_TIME
				   ,@BANK_ID
				);
	END;
	ELSE IF UPPER(@Act) = 'UPD_EMP_APPROVE'
	BEGIN
			UPDATE TB_TRANSACTION SET
				   EMP_ID_APPROVE = @EMP_ID_APPROVE
				   ,EMP_APPROVE_DATE = GETDATE()
				   ,EMP_REMARK = @EMP_REMARK
			WHERE TRAN_ID = @TRAN_ID;
	END;
	
	
	      
END



GO
/****** Object:  StoredProcedure [dbo].[InsertRegisCustomer]    Script Date: 3/13/2015 10:43:33 PM ******/
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
		CUS_NAME,
		Cus_Email,
		Cus_Password,
		Cus_Mobile,
		Cus_Ref_ID,
		Cus_Activate
	)values(
		@Cus_Email,
		@Cus_Email,
		@Cus_Password,
		@Cus_Mobile,
		@Cus_Ref_ID,
		0
	)	
END


GO
/****** Object:  StoredProcedure [dbo].[UpdateActivateCustomer]    Script Date: 3/13/2015 10:43:33 PM ******/
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
GO
/****** Object:  Table [dbo].[TB_ADM_GROUP_USER]    Script Date: 3/13/2015 10:43:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TB_ADM_GROUP_USER](
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_ADM_USER]    Script Date: 3/13/2015 10:43:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TB_ADM_USER](
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_BANK]    Script Date: 3/13/2015 10:43:33 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_BANK_SHOP]    Script Date: 3/13/2015 10:43:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TB_BANK_SHOP](
	[BANK_SHOP_ID] [int] IDENTITY(1,1) NOT NULL,
	[BANK_ID] [int] NULL,
	[BANK_SHOP_ACCOUNT_NO] [varchar](100) NULL,
	[BANK_SHOP_ACCOUNT_NAME] [varchar](100) NULL,
	[BANK_SHOP_REMARK] [varchar](500) NULL,
	[BANK_SHOP_STATUS] [int] NULL,
	[CREATE_USER] [varchar](100) NULL,
	[CREATE_DATE] [date] NULL,
	[UPDATE_USER] [varchar](100) NULL,
	[UPDATE_DATE] [date] NULL,
 CONSTRAINT [PK_TB_BANK_SHOP] PRIMARY KEY CLUSTERED 
(
	[BANK_SHOP_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_CONFIG]    Script Date: 3/13/2015 10:43:33 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_CUSTOMER]    Script Date: 3/13/2015 10:43:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TB_CUSTOMER](
	[CUS_ID] [int] IDENTITY(1,1) NOT NULL,
	[CUS_CODE] [varchar](50) NULL,
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_CUSTOMER_ACC_NAME]    Script Date: 3/13/2015 10:43:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TB_CUSTOMER_ACC_NAME](
	[CUS_ACC_NAME_ID] [int] IDENTITY(1,1) NOT NULL,
	[CUS_ACC_NAME] [varchar](100) NULL,
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_CUSTOMER_ADDRESS]    Script Date: 3/13/2015 10:43:33 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_CUSTOMER_BASKET]    Script Date: 3/13/2015 10:43:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TB_CUSTOMER_BASKET](
	[CUS_BK_ID] [int] IDENTITY(1,1) NOT NULL,
	[CUS_ID] [int] NOT NULL,
	[CUS_BK_ITEMNAME] [nvarchar](100) NULL,
	[CUS_BK_ITEMDESC] [nvarchar](500) NULL,
	[CUS_BK_AMOUNT] [int] NULL,
	[CUS_BK_PRICE] [float] NULL,
	[CUS_BK_SIZE] [nvarchar](50) NULL,
	[CUS_BK_COLOR] [nvarchar](50) NULL,
	[CUS_BK_REMARK] [varchar](500) NULL,
	[CUS_BK_URL] [varchar](500) NULL,
	[CUS_BK_PICURL] [varchar](500) NULL,
	[CUS_BK_STATUS] [varchar](50) NULL,
	[CREATE_USER] [varchar](100) NULL,
	[CREATE_DATE] [date] NULL,
 CONSTRAINT [PK_TB_CUSTOMER_BASKET] PRIMARY KEY CLUSTERED 
(
	[CUS_BK_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_CUSTOMER_FAVORIT_SHOP]    Script Date: 3/13/2015 10:43:33 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_MASTER_BANK]    Script Date: 3/13/2015 10:43:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TB_MASTER_BANK](
	[BANK_ID] [int] NOT NULL,
	[BANK_NAME] [varchar](100) NULL,
	[BANK_STATUS] [int] NULL,
 CONSTRAINT [PK_TB_MASTER_BANK] PRIMARY KEY CLUSTERED 
(
	[BANK_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_MASTER_DISTRICT]    Script Date: 3/13/2015 10:43:33 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_MASTER_PROVINCE]    Script Date: 3/13/2015 10:43:33 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_MASTER_REGION]    Script Date: 3/13/2015 10:43:33 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_MASTER_STATUS]    Script Date: 3/13/2015 10:43:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_MASTER_STATUS](
	[STATUS_ID] [int] IDENTITY(1,1) NOT NULL,
	[STATUS_NAME] [nvarchar](50) NULL,
	[STATUS_DESCRIPTION] [nvarchar](500) NULL,
	[STATUS_TYPE] [nvarchar](50) NULL,
	[STATUS_STATUS] [bit] NULL,
 CONSTRAINT [PK_TB_MASTER_STATUS] PRIMARY KEY CLUSTERED 
(
	[STATUS_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TB_MASTER_SUB_DISTRICT]    Script Date: 3/13/2015 10:43:33 PM ******/
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
/****** Object:  Table [dbo].[TB_MASTER_TRANSPOT]    Script Date: 3/13/2015 10:43:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_MASTER_TRANSPOT](
	[TRANS_ID] [int] IDENTITY(1,1) NOT NULL,
	[TRANS_NAME] [nvarchar](50) NULL,
	[TRANS_TYPE] [nvarchar](50) NULL,
	[TRANS_STATUS] [bit] NULL,
 CONSTRAINT [PK_TB_MASTER_TRANSPOT] PRIMARY KEY CLUSTERED 
(
	[TRANS_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TB_ORDER]    Script Date: 3/13/2015 10:43:33 PM ******/
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
	[ORDER_TRANSPOT_CHINA] [int] NULL,
	[ORDER_TRANSPOT_THAI] [int] NULL,
	[CREATE_USER] [varchar](100) NULL,
	[CREATE_DATE] [date] NULL,
	[UPDATE_USER] [varchar](100) NULL,
	[UPDATE_DATE] [date] NULL,
 CONSTRAINT [PK_TB_ORDER] PRIMARY KEY CLUSTERED 
(
	[ORDER_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_ORDER_DETAIL]    Script Date: 3/13/2015 10:43:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TB_ORDER_DETAIL](
	[OD_ID] [int] IDENTITY(1,1) NOT NULL,
	[ORDER_ID] [int] NULL,
	[OD_ITEMNAME] [nvarchar](100) NULL,
	[OD_AMOUNT] [int] NULL,
	[OD_AMOUNT_ACTIVE] [int] NULL,
	[OD_PRICE] [float] NULL,
	[OD_SIZE] [nvarchar](50) NULL,
	[OD_COLOR] [nvarchar](50) NULL,
	[OD_REMARK] [varchar](500) NULL,
	[OD_REF_BASKET] [varchar](500) NULL,
	[OD_STATUS] [varchar](50) NULL,
	[UPDATE_USER] [varchar](100) NULL,
	[UPDATE_DATE] [date] NULL,
 CONSTRAINT [PK_TB_ORDER_DETAIL] PRIMARY KEY CLUSTERED 
(
	[OD_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_PRODUCT]    Script Date: 3/13/2015 10:43:33 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_TRANSACTION]    Script Date: 3/13/2015 10:43:33 PM ******/
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
	[EMP_APPROVE_DATE] [date] NULL,
	[EMP_REMARK] [varchar](500) NULL,
	[CUS_ID] [int] NULL,
	[CUS_ACC_NAME_ID] [int] NULL,
	[ORDER_ID] [int] NULL,
	[PAYMENT_TYPE] [int] NULL,
	[PAYMENT_DATE] [date] NULL,
	[PAYMENT_TIME] [varchar](8) NULL,
	[BANK_ID] [int] NULL,
	[TRAN_EMAIL] [varchar](100) NULL,
 CONSTRAINT [PK_TB_TRANSACTION] PRIMARY KEY CLUSTERED 
(
	[TRAN_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_TRANSPORT]    Script Date: 3/13/2015 10:43:33 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0 = ยกเลิกใช้งาน, 1 = ใช้งาน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_CUSTOMER_ADDRESS', @level2type=N'COLUMN',@level2name=N'CUS_ADD_STATUS'
GO
USE [master]
GO
ALTER DATABASE [VLOVE_IMPORT] SET  READ_WRITE 
GO
