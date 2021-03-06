USE [master]
GO
/****** Object:  Database [HightechSchool]    Script Date: 8/21/2018 10:18:35 PM ******/
CREATE DATABASE [HightechSchool]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HightechSchool', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\HightechSchool.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'HightechSchool_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\HightechSchool_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [HightechSchool] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HightechSchool].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HightechSchool] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HightechSchool] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HightechSchool] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HightechSchool] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HightechSchool] SET ARITHABORT OFF 
GO
ALTER DATABASE [HightechSchool] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [HightechSchool] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HightechSchool] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HightechSchool] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HightechSchool] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HightechSchool] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HightechSchool] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HightechSchool] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HightechSchool] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HightechSchool] SET  ENABLE_BROKER 
GO
ALTER DATABASE [HightechSchool] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HightechSchool] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HightechSchool] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HightechSchool] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HightechSchool] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HightechSchool] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HightechSchool] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HightechSchool] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HightechSchool] SET  MULTI_USER 
GO
ALTER DATABASE [HightechSchool] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HightechSchool] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HightechSchool] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HightechSchool] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [HightechSchool] SET DELAYED_DURABILITY = DISABLED 
GO
USE [HightechSchool]
GO
/****** Object:  Table [dbo].[Achivements]    Script Date: 8/21/2018 10:18:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Achivements](
	[AchvNo] [int] IDENTITY(1,1) NOT NULL,
	[EmpNo] [int] NULL,
	[Date] [date] NULL,
	[Product] [varchar](50) NULL,
	[Details] [varchar](200) NULL,
	[Amount] [money] NULL,
	[Status] [varchar](100) NULL,
 CONSTRAINT [PK_Achivements] PRIMARY KEY CLUSTERED 
(
	[AchvNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Emp]    Script Date: 8/21/2018 10:18:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Emp](
	[EmpId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Addr] [nvarchar](100) NULL,
	[State] [nvarchar](20) NULL,
	[City] [nvarchar](20) NULL,
	[ContactNumber] [nvarchar](20) NULL,
	[Email] [nvarchar](50) NULL,
	[ParentContact] [nvarchar](20) NULL,
	[AddressProf] [nvarchar](20) NULL,
	[UserName] [nvarchar](20) NULL,
	[Password] [nvarchar](20) NULL,
	[Status] [int] NULL,
	[Position] [nvarchar](50) NULL,
 CONSTRAINT [PK_Emp] PRIMARY KEY CLUSTERED 
(
	[EmpId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 8/21/2018 10:18:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[PrdID] [int] NOT NULL,
	[Product] [nvarchar](50) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[PrdID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Project]    Script Date: 8/21/2018 10:18:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[PrjNo] [int] IDENTITY(1,1) NOT NULL,
	[Project] [nvarchar](50) NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[PrjNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Table_1]    Script Date: 8/21/2018 10:18:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Table_1](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[address] [varchar](50) NULL,
	[gender] [varchar](50) NULL,
	[course] [varchar](50) NULL,
	[email] [varchar](50) NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_assignroute]    Script Date: 8/21/2018 10:18:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_assignroute](
	[assignnum] [int] IDENTITY(1,1) NOT NULL,
	[adno] [int] NULL,
	[ptnum] [int] NULL,
 CONSTRAINT [PK_tbl_assignroute] PRIMARY KEY CLUSTERED 
(
	[assignnum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_assignteach]    Script Date: 8/21/2018 10:18:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_assignteach](
	[classteacherno] [int] NULL,
	[subjectnum] [int] NULL,
	[classno] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_attend]    Script Date: 8/21/2018 10:18:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_attend](
	[adno] [int] NULL,
	[classno] [int] NULL,
	[sname] [varchar](50) NULL,
	[cstandard] [varchar](50) NULL,
	[classteacherno] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_attendance]    Script Date: 8/21/2018 10:18:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_attendance](
	[date] [datetime] NULL,
	[adno] [int] NULL,
	[rollno] [int] NULL,
	[classno] [int] NULL,
	[status] [bit] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_buspayment]    Script Date: 8/21/2018 10:18:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_buspayment](
	[busrcptno] [int] NOT NULL,
	[ptnum] [int] NULL,
	[adno] [int] NULL,
	[Frmdate] [datetime] NULL,
	[Todate] [datetime] NULL,
	[Amount] [money] NULL,
	[Fine] [money] NULL,
	[Tdate] [datetime] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_class]    Script Date: 8/21/2018 10:18:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_class](
	[classno] [int] IDENTITY(1,1) NOT NULL,
	[cstandard] [nvarchar](50) NULL,
	[division] [nvarchar](50) NULL,
	[classteacherno] [int] NULL,
	[syllabusnum] [int] NULL,
 CONSTRAINT [PK_tbl_class] PRIMARY KEY CLUSTERED 
(
	[classno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Count]    Script Date: 8/21/2018 10:18:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Count](
	[CT] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_DailyTransaction]    Script Date: 8/21/2018 10:18:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_DailyTransaction](
	[TrNo] [int] NULL,
	[TType] [varchar](50) NULL,
	[TDesc] [varchar](200) NULL,
	[Amount] [money] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_exam]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_exam](
	[examnum] [int] IDENTITY(1,1) NOT NULL,
	[exam] [nvarchar](50) NULL,
	[cstandard] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_exam] PRIMARY KEY CLUSTERED 
(
	[examnum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Exammark]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Exammark](
	[adno] [int] NULL,
	[examnum] [int] NULL,
	[subjectno] [int] NULL,
	[mark] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_fee]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_fee](
	[feeid] [int] IDENTITY(1,1) NOT NULL,
	[feetype] [nvarchar](50) NULL,
	[cstandard] [nvarchar](50) NULL,
	[Newsyll] [nvarchar](50) NULL,
	[amount] [money] NULL,
	[collection] [datetime] NULL,
	[fine] [money] NULL,
 CONSTRAINT [PK_tbl_fee] PRIMARY KEY CLUSTERED 
(
	[feeid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_feeTemp]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_feeTemp](
	[FeeType] [nvarchar](50) NULL,
	[Amount] [money] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_fillblanks]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_fillblanks](
	[qno] [int] IDENTITY(1,1) NOT NULL,
	[empno] [int] NULL,
	[question] [nvarchar](max) NULL,
	[mark] [float] NULL,
	[cstandard] [nvarchar](50) NULL,
	[syllabus] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_fillblanks] PRIMARY KEY CLUSTERED 
(
	[qno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_gquestions]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_gquestions](
	[qno] [int] IDENTITY(1,1) NOT NULL,
	[empno] [int] NULL,
	[question] [nvarchar](max) NULL,
	[mark] [float] NULL,
	[cstandard] [nvarchar](50) NULL,
	[syllabus] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_gquestions] PRIMARY KEY CLUSTERED 
(
	[qno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_gradesetting]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_gradesetting](
	[slno] [int] IDENTITY(1,1) NOT NULL,
	[MinMark] [int] NULL,
	[MaxMark] [int] NULL,
	[Grade] [nvarchar](50) NULL,
	[Type] [nvarchar](50) NULL,
	[Standard] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_gradesetting] PRIMARY KEY CLUSTERED 
(
	[slno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_HightechSchool]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_HightechSchool](
	[HightechSchoolName] [varchar](100) NULL,
	[HightechSchoolAddress] [varchar](200) NULL,
	[Phone] [varchar](20) NULL,
	[Mobile] [varchar](20) NULL,
	[Manager] [varchar](50) NULL,
	[Principal] [varchar](50) NULL,
	[Website] [varchar](50) NULL,
	[Email] [varchar](100) NULL,
	[HightechSchoolRoute] [varchar](100) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_Item]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Item](
	[ITEM_ID] [int] IDENTITY(1,1) NOT NULL,
	[ITEM_NAME] [varchar](100) NOT NULL,
	[ITEM_MANUFACTURER] [varchar](100) NULL,
	[ITEM_CATEGORY] [varchar](10) NULL,
	[ITEM_QTY] [decimal](18, 2) NULL,
	[ITEM_UNIT] [varchar](10) NULL,
	[ITEM_PURCHASE_AMOUNT] [money] NULL,
	[ITEM_RETAIL_PRICE] [money] NULL,
 CONSTRAINT [PK_tbl_Item_1] PRIMARY KEY CLUSTERED 
(
	[ITEM_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_matchcase]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_matchcase](
	[qno] [int] IDENTITY(1,1) NOT NULL,
	[empno] [int] NULL,
	[field1] [nvarchar](max) NULL,
	[field2] [nvarchar](max) NULL,
	[mark] [float] NULL,
	[cstandard] [nvarchar](50) NULL,
	[syllabus] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_matchcase] PRIMARY KEY CLUSTERED 
(
	[qno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_optques]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_optques](
	[qno] [int] IDENTITY(1,1) NOT NULL,
	[empno] [int] NULL,
	[question] [nvarchar](max) NULL,
	[ans1] [nvarchar](max) NULL,
	[ans2] [nvarchar](max) NULL,
	[ans3] [nvarchar](max) NULL,
	[ans4] [nvarchar](max) NULL,
	[mark] [float] NULL,
	[cstandard] [nvarchar](50) NULL,
	[syllabus] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_optques] PRIMARY KEY CLUSTERED 
(
	[qno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_otherfee]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_otherfee](
	[otherid] [int] IDENTITY(1,1) NOT NULL,
	[otherfee] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_otherfee] PRIMARY KEY CLUSTERED 
(
	[otherid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_othrfeecollect]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_othrfeecollect](
	[ReceiptNo] [int] NULL,
	[feeid] [int] NULL,
	[adno] [int] NULL,
	[datefpay] [datetime] NULL,
	[amount] [money] NULL,
	[fine] [money] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_privilege]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_privilege](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userid] [int] NULL,
	[privilege] [int] NULL,
 CONSTRAINT [PK_tbl_privilege] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Purchase]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Purchase](
	[PURCHASE_ID] [int] IDENTITY(1,1) NOT NULL,
	[PURCHASE_NO] [int] NOT NULL,
	[ITEM_NO] [int] NOT NULL,
	[CATEGORY] [varchar](10) NOT NULL,
	[ITEM_QUANTITY] [decimal](18, 2) NULL,
 CONSTRAINT [PK_tbl_Purchase] PRIMARY KEY CLUSTERED 
(
	[PURCHASE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_PurchaseMaster]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_PurchaseMaster](
	[PURCHASE_NO] [int] IDENTITY(1,1) NOT NULL,
	[SUPPLIER_NO] [int] NULL,
	[INVOICE_NO] [varchar](20) NULL,
	[PURCHASE_AMOUNT] [money] NULL,
	[PURCHASE_DATE] [datetime] NULL,
	[PURCHASE_VEHICLE_NO] [varchar](15) NULL,
 CONSTRAINT [PK_tbl_PurchaseMaster] PRIMARY KEY CLUSTERED 
(
	[PURCHASE_NO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_route]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_route](
	[routenum] [int] IDENTITY(1,1) NOT NULL,
	[route] [nvarchar](50) NULL,
	[BusNo] [nvarchar](10) NULL,
 CONSTRAINT [PK_tbl_route] PRIMARY KEY CLUSTERED 
(
	[routenum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_routepoint]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_routepoint](
	[ptnum] [int] IDENTITY(1,1) NOT NULL,
	[routenum] [int] NULL,
	[rfrom] [nvarchar](50) NULL,
	[rto] [nvarchar](50) NULL,
	[fare] [money] NULL,
 CONSTRAINT [PK_tbl_routepoint] PRIMARY KEY CLUSTERED 
(
	[ptnum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Sales]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Sales](
	[SlNo] [int] IDENTITY(1,1) NOT NULL,
	[BillNo] [int] NULL,
	[Itemno] [int] NULL,
	[Quantity] [int] NULL,
	[TotalAmt] [money] NULL,
 CONSTRAINT [PK_tbl_Sales] PRIMARY KEY CLUSTERED 
(
	[SlNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_SalesMaster]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_SalesMaster](
	[BillNo] [int] IDENTITY(1,1) NOT NULL,
	[CurrDate] [datetime] NULL,
	[admno] [nvarchar](50) NULL,
	[Discount] [money] NULL,
	[Amount] [money] NULL,
 CONSTRAINT [PK_tbl_SalesMaster] PRIMARY KEY CLUSTERED 
(
	[BillNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_School]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_School](
	[SchoolName] [varchar](100) NULL,
	[SchoolAddress] [varchar](200) NULL,
	[Phone] [varchar](20) NULL,
	[Mobile] [varchar](20) NULL,
	[Manager] [varchar](50) NULL,
	[Principal] [varchar](50) NULL,
	[Website] [varchar](50) NULL,
	[Email] [varchar](100) NULL,
	[SchoolRoute] [varchar](100) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_stddivision]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_stddivision](
	[adno] [nvarchar](50) NULL,
	[rollno] [int] NULL,
	[cstandard] [nvarchar](50) NULL,
	[classno] [int] NULL,
	[division] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_student]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_student](
	[SlNo] [int] IDENTITY(1,1) NOT NULL,
	[adno] [nvarchar](50) NULL,
	[sname] [nvarchar](50) NULL,
	[sfname] [nvarchar](50) NULL,
	[pnum] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[religion] [nvarchar](50) NULL,
	[caste] [nvarchar](50) NULL,
	[occupation] [nvarchar](50) NULL,
	[nation] [nvarchar](50) NULL,
	[sex] [nvarchar](50) NULL,
	[dob] [datetime] NULL,
	[smname] [nvarchar](50) NULL,
	[mnum] [nvarchar](50) NULL,
	[address] [nvarchar](50) NULL,
	[photo] [nvarchar](50) NULL,
	[preHightechSchool] [nvarchar](50) NULL,
	[standard] [nvarchar](50) NULL,
	[dofleave] [datetime] NULL,
	[tcnodate] [nvarchar](50) NULL,
	[remarks] [nvarchar](50) NULL,
	[cstandard] [nvarchar](50) NULL,
	[dofadmin] [datetime] NULL,
	[Newsyll] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_student_1] PRIMARY KEY CLUSTERED 
(
	[SlNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_subforclass]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_subforclass](
	[slno] [int] IDENTITY(1,1) NOT NULL,
	[Standard] [nvarchar](50) NULL,
	[Syllabus] [nvarchar](50) NULL,
	[Subject] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_subforclass] PRIMARY KEY CLUSTERED 
(
	[slno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_subinexam]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_subinexam](
	[examnum] [int] NULL,
	[subjectnum] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_subject]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_subject](
	[subjectnum] [int] IDENTITY(1,1) NOT NULL,
	[subject] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_subject] PRIMARY KEY CLUSTERED 
(
	[subjectnum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Supplier]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Supplier](
	[SUPPLIER_NO] [int] IDENTITY(1,1) NOT NULL,
	[SUPPLIER_NAME] [varchar](100) NOT NULL,
	[SUPPLIER_ADDRESS] [varchar](200) NOT NULL,
	[SUPPLIER_TIN_NO] [varchar](50) NOT NULL,
	[SUPPLIER_ACCOUNTNO] [varchar](50) NOT NULL,
	[SUPPLIER_BANK] [varchar](50) NOT NULL,
	[SUPPLIER_BRANCH] [varchar](50) NOT NULL,
	[SUPPLIER_IFSC_CODE] [varchar](50) NOT NULL,
	[SUPPLIER_CONTACTNO_1] [varchar](50) NOT NULL,
	[SUPPLIER_CONTACTNO_2] [varchar](50) NOT NULL,
	[SUPPLIER_FAX] [varchar](50) NOT NULL,
	[SUPPLIER_EMAIL] [varchar](50) NOT NULL,
	[SUPPLIER_WEBSITE] [varchar](50) NOT NULL,
	[SUPPLIER_FLAG] [bit] NOT NULL,
 CONSTRAINT [PK_tbl_Supplier] PRIMARY KEY CLUSTERED 
(
	[SUPPLIER_NO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_sview]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_sview](
	[Rollnum] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Contactnum] [nvarchar](50) NULL,
	[Comments] [nvarchar](50) NULL,
	[Class] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_sview] PRIMARY KEY CLUSTERED 
(
	[Rollnum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_syllabus]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_syllabus](
	[syllabusnum] [int] IDENTITY(1,1) NOT NULL,
	[Newsyll] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_syllabus] PRIMARY KEY CLUSTERED 
(
	[syllabusnum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_syllabusinstandard]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_syllabusinstandard](
	[syllno] [int] IDENTITY(1,1) NOT NULL,
	[syllabusnum] [int] NULL,
	[cstandard] [nvarchar](50) NULL,
	[typenum] [int] NULL,
	[subjectnum] [int] NULL,
 CONSTRAINT [PK_tbl_syllabusinstandard] PRIMARY KEY CLUSTERED 
(
	[syllno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_thirdstudent]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_thirdstudent](
	[Slno] [int] IDENTITY(1,1) NOT NULL,
	[admsnno] [int] NULL,
 CONSTRAINT [PK_tbl_thirdstudent] PRIMARY KEY CLUSTERED 
(
	[Slno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_TotalFee]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_TotalFee](
	[ReceiptNo] [int] NULL,
	[TutionFee] [money] NULL,
	[TutionFine] [money] NULL,
	[OtherFee] [money] NULL,
	[OtherFine] [money] NULL,
	[BusFee] [money] NULL,
	[BusFine] [money] NULL,
	[Total] [money] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Transaction]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Transaction](
	[TrNo] [int] IDENTITY(1,1) NOT NULL,
	[Tdate] [datetime] NULL,
 CONSTRAINT [PK_tbl_Transaction] PRIMARY KEY CLUSTERED 
(
	[TrNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_tuitionfee]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_tuitionfee](
	[feeno] [int] IDENTITY(1,1) NOT NULL,
	[cstandard] [nvarchar](50) NULL,
	[Newsyll] [nvarchar](50) NULL,
	[amount] [money] NULL,
	[collectiondate] [int] NULL,
	[fine] [money] NULL,
 CONSTRAINT [PK_tbl_tuitionfee] PRIMARY KEY CLUSTERED 
(
	[feeno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_tutionfeepayment]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_tutionfeepayment](
	[receiptno] [int] NULL,
	[adno] [int] NULL,
	[dateftrans] [datetime] NULL,
	[month] [nvarchar](50) NULL,
	[year] [datetime] NULL,
	[amount] [money] NULL,
	[fine] [money] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_UserLogin]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_UserLogin](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[empno] [int] NULL,
	[Privilage] [nvarchar](50) NULL,
	[Status] [bit] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[teacherdet]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[teacherdet](
	[Empno] [int] IDENTITY(1,1) NOT NULL,
	[EmpName] [nvarchar](50) NULL,
	[Qualification] [nvarchar](50) NULL,
	[Phonenum] [nvarchar](50) NULL,
	[Emailid] [nvarchar](50) NULL,
	[Address] [nvarchar](max) NULL,
	[DOB] [datetime] NULL,
	[Mobnum] [nvarchar](50) NULL,
	[DOJ] [datetime] NULL,
	[Sex] [nvarchar](50) NULL,
	[Salary] [money] NULL,
	[EmpType] [nvarchar](50) NULL,
	[Photo] [nvarchar](50) NULL,
	[username] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_teacherdet] PRIMARY KEY CLUSTERED 
(
	[Empno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WorkStatus]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkStatus](
	[SlNo] [int] IDENTITY(1,1) NOT NULL,
	[EmpID] [int] NULL,
	[ProjectType] [nvarchar](50) NULL,
	[Workdetails] [nvarchar](max) NULL,
	[HoursSpent] [decimal](18, 2) NULL,
	[TDate] [date] NULL,
	[Status] [nvarchar](50) NULL,
	[Project] [nvarchar](50) NULL,
 CONSTRAINT [PK_WorkStatus] PRIMARY KEY CLUSTERED 
(
	[SlNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  StoredProcedure [dbo].[del_assignteacher]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[del_assignteacher](@classteacherno int,@subjectnum int,@classno int)
AS
	delete from tbl_assignteach where classteacherno=@classteacherno and subjectnum=@subjectnum and classno=@classno 
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[del_clas]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[del_clas](@classno int,@cstandard nvarchar(50),@division nvarchar(50),@classteacherno int)

AS
	
	delete from tbl_class where classno=@classno
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[del_otherfees]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[del_otherfees](@otherid int,@otherfee nvarchar(50))
AS
	
	delete from tbl_otherfee  where otherid=@otherid
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[del_route]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[del_route](@routenum int,@route nvarchar(50))
AS
	delete from tbl_route where route=@route 
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[edit_clas]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[edit_clas](@classno int,@cstandard nvarchar(50),@division nvarchar(50),@classteacherno int,@syllabusnum int)

AS
	
	update tbl_class set cstandard=@cstandard,division=@division,classteacherno=@classteacherno,@syllabusnum=@syllabusnum where classno=@classno
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[edit_teacher]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[edit_teacher](@Empno int,@EmpName nvarchar(50),@Qualification nvarchar(50),@Phonenum nvarchar(50),@Emailid nvarchar(50),@Address nvarchar(50),@DOB datetime,@Mobnum nvarchar(50),@DOJ datetime,@Sex nvarchar(50),@Salary money,@Photo nvarchar(50),@EmpType nvarchar(50))
AS
	update teacherdet set Empname=@EmpName,Qualification=@Qualification,Phonenum=@Phonenum,Emailid=@Emailid,Address=@Address,DOB=@DOB,Mobnum=@Mobnum,DOJ=@DOJ,Sex=@Sex,Salary=@Salary,EmpType=@EmpType,Photo=@Photo,Status=1 where Empno=@Empno
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[FeesCollection]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>e
-- =============================================
CREATE PROCEDURE [dbo].[FeesCollection](@admno int)

AS
BEGIN

create table #temp
(FeeType varchar(50),PaidDate varchar(50),Amount money,Fine money,Total money)

-- For Tution Fee

Insert into #temp
select 'TutionFee',Convert(varchar(20),dateftrans,101),amount,fine,amount+fine from tbl_tutionfeepayment
where adno=@admno


-- For Other Fee

Insert into #temp
select 'OtherFee',Convert(varchar(20),datefpay,101),amount,fine,amount+fine from tbl_othrfeecollect
where adno=@admno

--For BusPayment

Insert into #temp
Select 'BusFee',Convert(varchar(20),TDate,101),amount,fine,amount+fine from tbl_buspayment
where adno=@admno



-- Select frm temp table


Select FeeType,PaidDate,Amount,Fine,Total from #temp


END


GO
/****** Object:  StoredProcedure [dbo].[ins_addothrfeecollect]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ins_addothrfeecollect](@rcptno int,@feeid int,@adno int,@datefpay datetime,@amount money,@fine money)
AS
	insert into tbl_othrfeecollect values(@rcptno,@feeid,@adno,@datefpay,@amount,@fine)
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[ins_assignroute]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ins_assignroute](@adno int,@ptnum int)

AS
	insert into tbl_assignroute values(@adno,@ptnum)
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[ins_assignteacher]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ins_assignteacher](@classteacherno int,@subjectnum int,@classno int)
AS
	insert into  tbl_assignteach values(@classteacherno,@subjectnum,@classno)
	
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[ins_attend]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ins_attend](@empno int,@classno int)
AS
select * from tbl_attendance where convert(varchar(8),date,3)=convert(varchar(8),getdate(),3) and classno=@classno

if @@rowcount<1
	 begin
	INSERT INTO tbl_attendance
SELECT     GETDATE() AS Expr3, s.adno, st.rollno AS Expr1,c.classno,1 AS Expr2
FROM         tbl_student AS s INNER JOIN
                      tbl_stddivision AS st ON s.adno = st.adno INNER JOIN
                      tbl_class AS c ON st.classno = c.classno INNER JOIN
                      teacherdet AS t ON c.classteacherno = t.Empno
WHERE     (c.classteacherno =@empno)
	end 
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[ins_busfare]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ins_busfare](@rcptno int,@ptnum int,@adno int,@frmdate datetime,@todate datetime,@amt money,
@fine money,@tdate datetime)
	
AS
	insert into tbl_buspayment values(@rcptno,@ptnum,@adno,@frmdate,@todate,@amt,
@fine,@tdate) 
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[ins_clas]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE  [dbo].[ins_clas](@cstandard nvarchar(50),@division nvarchar(50),@classteacherno int,@syllabusnum int)

AS
	insert into tbl_class values (@cstandard,@division,@classteacherno,@syllabusnum)
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[ins_dailytrans]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create  PROCEDURE [dbo].[ins_dailytrans](@trano int,@type varchar(50),@desc varchar(200),@amt money)

AS
	insert into tbl_DailyTransaction values(@trano,@type,@desc,@amt)
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[ins_exam]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ins_exam](@exam nvarchar(50),@cstandard nvarchar(50))

AS
	
	insert into tbl_exam values(@exam,@cstandard)
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[ins_exammark]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[ins_exammark]
(
@adno int,
@examnum int,
@subjectno int,
@mark int
)

AS
	
	insert into tbl_Exammark values
	(
	@adno,
	@examnum,
	@subjectno,
	@mark
	)
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[ins_fee]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ins_fee](@feetype nvarchar(50),@cstandard nvarchar(50),@Newsyll nvarchar(50),@amount money,@collection datetime,@fine money)

AS
insert into tbl_fee values(@feetype,@cstandard,@Newsyll,@amount,@collection,@fine)
	
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[ins_feepay]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ins_feepay](@receiptno int,@adno int,@dateftrans datetime,@month nvarchar(50),@year datetime ,@amount money,@fine money)
AS
	insert into tbl_tutionfeepayment values(@receiptno,@adno,@dateftrans,@month,@year,@amount,@fine)
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[ins_feeTemp]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[ins_feeTemp](@feetype nvarchar(50),@amount money)

AS
insert into tbl_feeTemp values(@feetype,@amount)
	
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[ins_fillblanks]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ins_fillblanks](@empno int,@question nvarchar(MAX),@mark float,@cstandard nvarchar(50),@syllabus nvarchar(50))
AS
	insert into tbl_fillblanks values(@empno,@question,@mark,@cstandard,@syllabus)

	RETURN


GO
/****** Object:  StoredProcedure [dbo].[ins_gquestions]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ins_gquestions](@empno int,@question nvarchar(MAX),@mark float,@cstandard nvarchar(50),@syllabus nvarchar(50))
AS
	insert into tbl_gquestions values(@empno,@question,@mark,@cstandard,@syllabus)
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[ins_gradesetting]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ins_gradesetting](@type nvarchar(50),@min int,@max int,@grade nvarchar(50),@std nvarchar(50))
AS
	INSERT INTO tbl_gradesetting VALUES(@type,@min,@max,@grade,@std)
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[ins_matchcase]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ins_matchcase](@empno int,@field1 nvarchar(MAX),@field2 nvarchar(MAX),@mark float,@cstandard nvarchar(50),@syllabus nvarchar(50))
AS
	insert into tbl_matchcase values(@empno,@field1,@field2,@mark,@cstandard,@syllabus)
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[ins_optques]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ins_optques](@empno int,@question nvarchar(MAX),@ans1 nvarchar(MAX),@ans2 nvarchar(MAX),@ans3 nvarchar(MAX),@ans4 nvarchar(MAX),@mark float,@cstandard nvarchar(50),@syllabus nvarchar(50))
AS
	insert into tbl_optques values(@empno,@question,@ans1,@ans2,@ans3,@ans4,@mark,@cstandard,@syllabus)
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[ins_otherfee]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ins_otherfee](@otherfee nvarchar(50))
AS
	insert into tbl_otherfee values(@otherfee)
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[ins_Privilege]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ins_Privilege](@UsrNo int,@FrmNo int)
AS
insert into tbl_Privilege values(@UsrNo,@FrmNo)
RETURN


GO
/****** Object:  StoredProcedure [dbo].[ins_route]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ins_route](@route nvarchar(50),@busno nvarchar(10))
AS
	insert into tbl_route values(@route,@busno)
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[ins_routepoint]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ins_routepoint](@routenum int,@rfrom nvarchar(50),@rto nvarchar(50),@fare money)
AS
	insert into tbl_routepoint values(@routenum,@rfrom,@rto,@fare)
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[ins_Sales]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ins_Sales](@billno int,@itemno int,@Quantity int,@totamt money)
AS
	INSERT INTO tbl_Sales VALUES(@billno,@itemno,@Quantity,@totamt)
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[ins_SalesMaster]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ins_SalesMaster](@CurrDate datetime,@admno nvarchar(50),@Discount money,@Amt money)
AS
	INSERT INTO tbl_SalesMaster VALUES(@CurrDate,@admno,@Discount,@Amt)
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[ins_stddivision]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ins_stddivision](@adno nvarchar(50),@rollno int,@cstandard nvarchar(50),@classno int,@division nvarchar(50))
AS
	insert into tbl_stddivision values(@adno ,@rollno,@cstandard,@classno,@division)
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[ins_stud]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ins_stud](@adno nvarchar(50),@sname nvarchar(50),@sfname nvarchar(50),@pnum nvarchar(50),@email nvarchar(50),@religion nvarchar(50),@caste nvarchar(50),@occupation nvarchar(50),@nation nvarchar(50),@sex nvarchar(50),@dob datetime,@smname nvarchar(50),@mnum nvarchar(50),@address nvarchar(50),@photo nvarchar(50) ,@preschool nvarchar(50),@standard nvarchar(50),@dofleave datetime,@tcnodate nvarchar(50),@remarks nvarchar(50),@cstandard nvarchar(50),@dofadmin datetime,@Newsyll nvarchar(50))
	
AS
	insert into tbl_student values(@adno,@sname ,@sfname ,@pnum ,@email ,@religion ,@caste ,@occupation ,@nation ,@sex ,@dob ,@smname ,@mnum ,@address ,@photo,@preschool ,@standard,@dofleave ,@tcnodate ,@remarks,@cstandard,@dofadmin,@Newsyll)
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[ins_subforclass]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ins_subforclass](@standard nvarchar(50),@sylabus nvarchar(50),@subject nvarchar(50))
AS
	INSERT INTO tbl_subforclass VALUES(@standard,@sylabus,@subject)
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[ins_subinexam]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ins_subinexam](@examnum int,@subjectnum int)
AS

	insert into tbl_subinexam values(@examnum,@subjectnum)
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[ins_subject]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE  [dbo].[ins_subject](@subject nvarchar(50))
AS
	insert into tbl_subject values(@subject)
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[ins_teach]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ins_teach](@EmpName nvarchar(50),@Qualification nvarchar(50),@Phonenum nvarchar(50),@Emailid nvarchar(50),@Address nvarchar(MAX),@DOB datetime,@Mobnum nvarchar(50),@DOJ datetime,@Sex nvarchar(50),@Salary money,@Photo nvarchar(50),@EmpType nvarchar(50),@username nvarchar(50),@password nvarchar(50))
AS
	insert into teacherdet values(@Empname,@Qualification,@Phonenum,@Emailid,@Address,@DOB,@Mobnum,@DOJ,@Sex,@Salary,@EmpType,@Photo,@username,@password,1)
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[ins_thirdstudent]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ins_thirdstudent](@admsnno int)
	
AS
	INSERT INTO tbl_thirdstudent VALUES(@admsnno)
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[ins_TotalFee]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ins_TotalFee](@rcptno int,@tfee money,@tfine money,@ofee money,@0fine money,@bfee money,@bfine money,@total money)
AS
	insert into tbl_TotalFee values(@rcptno,@tfee,@tfine,@ofee,@0fine,@bfee,@bfine,@total)
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[ins_trans]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ins_trans](@trno int out,
@tdate datetime)
AS
	insert into tbl_Transaction values(@tdate)
	select @trno=max(Trno) from tbl_Transaction
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[ins_tuition]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ins_tuition](@cstandard nvarchar(50),@Newsyll nvarchar(50),@amount money,@collectiondate int,@fine money)

AS
	insert into tbl_tuitionfee values(@cstandard,@Newsyll,@amount,@collectiondate,@fine)
	
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[ins_user]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ins_user](@empno int,@privilage varchar(50),@sts bit)

AS
insert into tbl_UserLogin values(@empno,@privilage,@sts)
RETURN


GO
/****** Object:  StoredProcedure [dbo].[InsItem]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[InsItem]
(
@ITEM_NAME [varchar](100),
@ITEM_MANUFACTURER [varchar](100),
@ITEM_CATEGORY [varchar](10),
@ITEM_QTY [decimal](18, 2),
@ITEM_UNIT [varchar](10),
@ITEM_PURCHASE_AMOUNT [money],
@ITEM_RETAIL_PRICE [money]
) 
As
 Begin
   Insert into tbl_Item(ITEM_NAME, ITEM_MANUFACTURER, ITEM_CATEGORY,ITEM_QTY,ITEM_UNIT,ITEM_PURCHASE_AMOUNT,ITEM_RETAIL_PRICE)
   Values(@ITEM_NAME, @ITEM_MANUFACTURER, @ITEM_CATEGORY,@ITEM_QTY,@ITEM_UNIT,@ITEM_PURCHASE_AMOUNT,@ITEM_RETAIL_PRICE)
 End


GO
/****** Object:  StoredProcedure [dbo].[InsPurchase]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[InsPurchase]
(
            @INVOICE_NO [varchar](20)
           ,@PURCHASE_AMOUNT money
           ,@PURCHASE_DATE datetime
           ,@PURCHASE_VEHICLE_NO [varchar](15)
           ,@SUPPLIER_NO int
           ,@PURCHASE_NO int OUTPUT
           )
           As
 Begin
 SET NOCOUNT ON;
 
   Insert into tbl_PurchaseMaster([SUPPLIER_NO],[INVOICE_NO],[PURCHASE_AMOUNT],[PURCHASE_DATE],[PURCHASE_VEHICLE_NO])
   Values( @SUPPLIER_NO,@INVOICE_NO,@PURCHASE_AMOUNT,@PURCHASE_DATE,@PURCHASE_VEHICLE_NO)
		
		Set @PURCHASE_NO = SCOPE_IDENTITY()

 End


GO
/****** Object:  StoredProcedure [dbo].[InsPurchaseItems]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[InsPurchaseItems]
(
		   @PURCHASE_NO int,
           @ITEM_NO int,
           @CATEGORY varchar(10),
           @ITEM_QUANTITY decimal(18,2)
           )
           As
 Begin
   Insert into [tbl_Purchase]([PURCHASE_NO],[ITEM_NO],[CATEGORY],[ITEM_QUANTITY])
   Values(@PURCHASE_NO,@ITEM_NO,@CATEGORY,@ITEM_QUANTITY)
  
   UPDATE [tbl_Item] 
   SET ITEM_QTY  = ITEM_QTY + @ITEM_QUANTITY
   WHERE ITEM_ID  = @ITEM_NO
   
 End


GO
/****** Object:  StoredProcedure [dbo].[InsSupplier]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[InsSupplier]
(@SUPPLIER_NAME varchar(100),
           @SUPPLIER_ADDRESS varchar(200),
           @SUPPLIER_TIN_NO varchar(20),
           @SUPPLIER_ACCOUNTNO varchar(30),
           @SUPPLIER_BANK varchar(30),
           @SUPPLIER_BRANCH varchar(20),
           @SUPPLIER_IFSC_CODE varchar(15),
           @SUPPLIER_CONTACTNO_1 varchar(15),
           @SUPPLIER_CONTACTNO_2 varchar(15),
           @SUPPLIER_FAX varchar(15),
           @SUPPLIER_EMAIL varchar(50),
           @SUPPLIER_WEBSITE varchar(40),
           @SUPPLIER_FLAG bit)	
As
 Begin
   Insert into tbl_SUPPLIER(
[SUPPLIER_NAME]
           ,[SUPPLIER_ADDRESS]
           ,[SUPPLIER_TIN_NO]
           ,[SUPPLIER_ACCOUNTNO]
           ,[SUPPLIER_BANK]
           ,[SUPPLIER_BRANCH]
           ,[SUPPLIER_IFSC_CODE]
           ,[SUPPLIER_CONTACTNO_1]
           ,[SUPPLIER_CONTACTNO_2]
           ,[SUPPLIER_FAX]
           ,[SUPPLIER_EMAIL]
           ,[SUPPLIER_WEBSITE]
           ,[SUPPLIER_FLAG])
   Values(@SUPPLIER_NAME
           ,@SUPPLIER_ADDRESS
           ,@SUPPLIER_TIN_NO
           ,@SUPPLIER_ACCOUNTNO
           ,@SUPPLIER_BANK
           ,@SUPPLIER_BRANCH
           ,@SUPPLIER_IFSC_CODE
           ,@SUPPLIER_CONTACTNO_1
           ,@SUPPLIER_CONTACTNO_2
           ,@SUPPLIER_FAX
           ,@SUPPLIER_EMAIL
           ,@SUPPLIER_WEBSITE
           ,@SUPPLIER_FLAG
)
 End


GO
/****** Object:  StoredProcedure [dbo].[se_teach]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE  [dbo].[se_teach]
                            
                            
AS  select Empname from teacherdet 

                   
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[sel_amount]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sel_amount](@feeid int,@amount money,@fine money)
AS
	select amount,fine from tbl_fee where feeid=@feeid
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[sel_cstandard]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sel_cstandard]
	
AS
	Select DISTINCT cstandard from tbl_class ORDER BY cstandard ASC
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[sel_div]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sel_div](@cstandard nvarchar(50),@division nvarchar(50))
AS
    select division from tbl_class where cstandard=@cstandard
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[sel_empname]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sel_empname]
AS
	select EmpName from teacherdet
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[sel_exam]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sel_exam]
AS
	select exam from tbl_exam
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[sel_fee]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sel_fee]
AS
	select  otherfee from tbl_otherfee
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[sel_feetype]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sel_feetype]
AS
	select  distinct feetype from tbl_fee 
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[sel_route]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sel_route](@route nvarchar(50))
	
AS
	select route from tbl_route
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[sel_stdview]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sel_stdview] (@Rollnum int,@Name nvarchar(50),@Class nvarchar(50))
	
AS
	select Rollnum,Name,Contactnum,Comments,Class  from tbl_sview where Rollnum=@Rollnum 
	
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[sel_stud]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sel_stud]
	
AS
	select  distinct cstandard from tbl_student
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[sel_sub]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sel_sub]
AS
	select distinct subject from tbl_subject 
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[sel_syllabus]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sel_syllabus]
AS
	select Newsyll from tbl_syllabus
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[sel_trans_report]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sel_trans_report]
(@dt1 varchar(20),@dt2 varchar(20))
AS
	select s.adno as [AdNo:],s.sname as [Name],st.cstandard as [Standard],st.division as [Division],
'TutionFee' as [FeeType],tp.Amount from tbl_student s join
tbl_stddivision st on s.adno=st.adno join
tbl_tutionfeepayment tp on tp.adno=s.adno where tp.year>=@dt1 and tp.year<@dt2
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[Select_PendingFee]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[Select_PendingFee](@mnt int)
as
declare
@mnct int,
@AccYearStart int,
@I int

Create table #temp
(AdmissionNo int,Name varchar(50),CStandard varchar(5),Division varchar(5),PMonth varchar(10),FeeType varchar(20),Amount money,Fine money,Total money)

--Fee Section
set @mnct=@mnt
--Read Acc year start here
set @AccYearStart=5
set @I=@AccYearStart
while @I<=@mnct
Begin
Insert into #temp
Select st.adno as [AdmissionNo],st.sname as [Name],std.cstandard as [Standard],
std.division as [Division],@mnct,'Fee',f.Amount,f.fine,f.Amount+f.fine
from tbl_student st Join
tbl_stddivision std on st.adno=std.adno Join
tbl_tuitionfee f on std.cstandard=f.cstandard Join
tbl_tutionfeepayment fp on fp.adno=st.adno Where fp.month not in(@mnct)

set @mnct=@mnct-1



End

Select * from #temp


GO
/****** Object:  StoredProcedure [dbo].[upd_assignstatus]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[upd_assignstatus](@adno int,@status int ,@date datetime)
AS
   update tbl_attendance set status=@status where adno=@adno and convert(varchar(8),date,3)=convert(varchar(8),getdate(),3)
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[upd_assignteacher]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[upd_assignteacher](@classteacherno int,@subjectnum int,@classno int,@Empnum int,@subjctnum int,@clsno int)
AS
	update tbl_assignteach set classteacherno=@classteacherno,subjectnum=@subjectnum,classno=@classno where classteacherno=@Empnum and subjectnum=@subjctnum and classno=@clsno  
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[upd_fee]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[upd_fee](@feeid int,@feetype nvarchar(50),@cstandard nvarchar(50),@Newsyll nvarchar(50),@amount money,@collection datetime,@fine money)
AS
	update tbl_fee set feetype=@feetype,cstandard=@cstandard,Newsyll=@Newsyll,amount=@amount,collection=@collection,fine=@fine where feeid=@feeid 
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[upd_fillblanks]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[upd_fillblanks](@qno int,@question nvarchar(MAX),@mark float,@cstandard nvarchar(50),@syllabus nvarchar(50))
AS
	update tbl_fillblanks set question=@question,mark=@mark,cstandard=@cstandard,syllabus=@syllabus where qno=@qno
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[upd_gquestions]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[upd_gquestions](@qno int,@question nvarchar(MAX),@mark float,@cstandard nvarchar(50),@syllabus nvarchar(50))
AS
	update tbl_gquestions set question=@question,mark=@mark,cstandard=@cstandard,syllabus=@syllabus where qno=@qno
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[upd_matchcase]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[upd_matchcase](@qno int,@field1 nvarchar(MAX),@field2 nvarchar(MAX),@mark float,@cstandard nvarchar(50),@syllabus nvarchar(50))
AS
	update tbl_matchcase set field1=@field1,field2=@field2,mark=@mark,cstandard=@cstandard,syllabus=@syllabus where qno=@qno
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[upd_optques]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[upd_optques](@qno int,@question nvarchar(MAX),@ans1 nvarchar(MAX),@ans2 nvarchar(MAX),@ans3 nvarchar(MAX),@ans4 nvarchar(MAX),@mark float,@cstandard nvarchar(50),@syllabus nvarchar(50))


AS
	update tbl_optques set question=@question,ans1=@ans1,ans2=@ans2,ans3=@ans3,ans4=@ans4,mark=@mark,cstandard=@cstandard,syllabus=@syllabus where qno=@qno
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[upd_route]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[upd_route](@routenum int,@route nvarchar(50))
AS
	update tbl_route set route=@route where routenum=@routenum
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[upd_routepoint]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[upd_routepoint](@ptnum int,@rfrom nvarchar(50),@rto nvarchar(50),@fare money)

AS
	update tbl_routepoint set rfrom=@rfrom,rto=@rto,fare=@fare where ptnum=@ptnum
	
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[upd_stud1]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[upd_stud1](@SlNo int ,@adno nvarchar(50),@sname nvarchar(50),@sfname nvarchar(50),@pnum nvarchar(50),@email nvarchar(50),@religion nvarchar(50),@caste nvarchar(50),@occupation nvarchar(50),@nation nvarchar(50),@sex nvarchar(50),@dob nvarchar(50),@smname nvarchar(50),@mnum nvarchar(50),@address nvarchar(50),@preHightechSchool nvarchar(50),@standard nvarchar(50),@dofleave nvarchar(50),@tcnodate nvarchar(50),@remarks nvarchar(50),@dofadmin nvarchar(50),@Newsyll nvarchar(50),@cstandard nvarchar(50))	

As

update tbl_student set adno=@adno,sname=@sname,sfname=@sfname,pnum=@pnum,email=@email,religion=@religion,caste=@caste,occupation=@occupation,nation=@nation,sex=@sex,dob=@dob,smname=@smname,mnum=@mnum,address=@address,preHightechSchool=@preHightechSchool,standard=@standard,dofleave=@dofleave,tcnodate=@tcnodate,remarks=@remarks ,dofadmin=@dofadmin,Newsyll=@Newsyll,cstandard=@cstandard where adno=@adno
	
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[upd_subforclass]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[upd_subforclass] (@slno int,@standard nvarchar(50),@sylabus nvarchar(50),@subject nvarchar(50))
AS
	Update tbl_subforclass set Standard=@standard, Syllabus=@sylabus, @Subject=@subject where slno=@slno
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[upd_subject]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[upd_subject](@subjectnum int,@subject nvarchar(50))
AS
	Update tbl_subject set subject=@subject where subjectnum=@subjectnum
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[upd_tuitionfee]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[upd_tuitionfee](@feeno int,@cstandard nvarchar(50),@Newsyll nvarchar(50),@amount money,@collectiondate int,@fine money)
AS
	update tbl_tuitionfee set cstandard=@cstandard,Newsyll=@Newsyll,amount=@amount,collectiondate=@collectiondate,fine=@fine where feeno=@feeno
	RETURN


GO
/****** Object:  StoredProcedure [dbo].[UpdatePurchase]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[UpdatePurchase]
(
            @INVOICE_NO [varchar](20)
           ,@PURCHASE_AMOUNT money
           ,@PURCHASE_DATE datetime
           ,@PURCHASE_VEHICLE_NO [varchar](15)
           ,@SUPPLIER_NO int
           ,@PURCHASE_NO int
           )
      As
 Begin
 UPDATE [tbl_PurchaseMaster]
   SET INVOICE_NO = @INVOICE_NO
      ,PURCHASE_AMOUNT = @PURCHASE_AMOUNT
      ,PURCHASE_DATE = @PURCHASE_DATE
      ,PURCHASE_VEHICLE_NO = @PURCHASE_VEHICLE_NO
      ,SUPPLIER_NO = @SUPPLIER_NO
 WHERE PURCHASE_NO = @PURCHASE_NO
 END


GO
/****** Object:  StoredProcedure [dbo].[UpdateSupplier]    Script Date: 8/21/2018 10:18:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateSupplier]
(@SUPPLIER_NAME varchar(100),
           @SUPPLIER_ADDRESS varchar(200),
           @SUPPLIER_TIN_NO varchar(20),
           @SUPPLIER_ACCOUNTNO varchar(30),
           @SUPPLIER_BANK varchar(30),
           @SUPPLIER_BRANCH varchar(20),
           @SUPPLIER_IFSC_CODE varchar(15),
           @SUPPLIER_CONTACTNO_1 varchar(15),
           @SUPPLIER_CONTACTNO_2 varchar(15),
           @SUPPLIER_FAX varchar(15),
           @SUPPLIER_EMAIL varchar(50),
           @SUPPLIER_WEBSITE varchar(40),
           @SUPPLIER_FLAG bit,
           @SUPPLIER_NO int)	
As
 Begin
 UPDATE [tbl_Supplier]
   SET [SUPPLIER_NAME] = @SUPPLIER_NAME
      ,[SUPPLIER_ADDRESS] = @SUPPLIER_ADDRESS
      ,[SUPPLIER_TIN_NO] = @SUPPLIER_TIN_NO
      ,[SUPPLIER_ACCOUNTNO] = @SUPPLIER_ACCOUNTNO
      ,[SUPPLIER_BANK] = @SUPPLIER_BANK
      ,[SUPPLIER_BRANCH] = @SUPPLIER_BRANCH
      ,[SUPPLIER_IFSC_CODE] = @SUPPLIER_IFSC_CODE
      ,[SUPPLIER_CONTACTNO_1] = @SUPPLIER_CONTACTNO_1
      ,[SUPPLIER_CONTACTNO_2] = @SUPPLIER_CONTACTNO_2
      ,[SUPPLIER_FAX] = @SUPPLIER_FAX
      ,[SUPPLIER_EMAIL] = @SUPPLIER_EMAIL
      ,[SUPPLIER_WEBSITE] = @SUPPLIER_WEBSITE
      ,[SUPPLIER_FLAG] = @SUPPLIER_FLAG
 WHERE SUPPLIER_NO = @SUPPLIER_NO
 END


GO
USE [master]
GO
ALTER DATABASE [HightechSchool] SET  READ_WRITE 
GO
