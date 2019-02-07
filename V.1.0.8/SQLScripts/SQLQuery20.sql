

-- USE [POSSYS]
GO
/****** Object:  Table [dbo].[CSCCD]    Script Date: 04/13/2011 23:12:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CSCCD](
	[CURID] [char](3) NOT NULL,
	[AUDTDATE] [decimal](9, 0) NOT NULL,
	[AUDTTIME] [decimal](9, 0) NOT NULL,
	[AUDTUSER] [char](8) NOT NULL,
	[AUDTORG] [char](6) NOT NULL,
	[CURNAME] [char](60) NOT NULL,
	[SYMBOL] [char](4) NOT NULL,
	[DECIMALS] [smallint] NOT NULL,
	[SYMBOLPOS] [smallint] NOT NULL,
	[THOUSSEP] [char](1) NOT NULL,
	[DECSEP] [char](1) NOT NULL,
	[NEGDISP] [smallint] NOT NULL,
 CONSTRAINT [CSCCD_KEY_0] PRIMARY KEY CLUSTERED 
(
	[CURID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF




USE [POSSYS]
GO
/****** Object:  Table [dbo].[CSCRD]    Script Date: 04/13/2011 23:17:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CSCRD](
	[HOMECUR] [char](3) NOT NULL,
	[RATETYPE] [char](2) NOT NULL,
	[SOURCECUR] [char](3) NOT NULL,
	[RATEDATE] [decimal](9, 0) NOT NULL,
	[AUDTDATE] [decimal](9, 0) NOT NULL,
	[AUDTTIME] [decimal](9, 0) NOT NULL,
	[AUDTUSER] [char](8) NOT NULL,
	[AUDTORG] [char](6) NOT NULL,
	[RATE] [decimal](15, 7) NOT NULL,
	[SPREAD] [decimal](15, 7) NOT NULL,
	[DATEMATCH] [smallint] NOT NULL,
	[RATEOPER] [smallint] NOT NULL,
 CONSTRAINT [CSCRD_KEY_0] PRIMARY KEY CLUSTERED 
(
	[HOMECUR] ASC,
	[RATETYPE] ASC,
	[SOURCECUR] ASC,
	[RATEDATE] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF


USE [Toydat]
GO
/****** Object:  Table [dbo].[CSCOM]    Script Date: 04/13/2011 23:24:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CSCOM](
	[ORGID] [char](6) NOT NULL,
	[AUDTDATE] [decimal](9, 0) NOT NULL,
	[AUDTTIME] [decimal](9, 0) NOT NULL,
	[AUDTUSER] [char](8) NOT NULL,
	[AUDTORG] [char](6) NOT NULL,
	[CONAME] [char](60) NOT NULL,
	[ADDR01] [char](60) NOT NULL,
	[ADDR02] [char](60) NOT NULL,
	[ADDR03] [char](60) NOT NULL,
	[ADDR04] [char](60) NOT NULL,
	[CITY] [char](30) NOT NULL,
	[STATE] [char](30) NOT NULL,
	[POSTAL] [char](20) NOT NULL,
	[COUNTRY] [char](30) NOT NULL,
	[LOCTYPE] [char](6) NOT NULL,
	[LOCCODE] [char](30) NOT NULL,
	[PHONEFMT] [smallint] NOT NULL,
	[PHONE] [char](30) NOT NULL,
	[FAX] [char](30) NOT NULL,
	[CONTACT] [char](60) NOT NULL,
	[CNTRYCODE] [char](6) NOT NULL,
	[BRANCH] [char](6) NOT NULL,
	[PERDFSC] [smallint] NOT NULL,
	[QTR4PERD] [smallint] NOT NULL,
	[HOMECUR] [char](3) NOT NULL,
	[MULTICURSW] [smallint] NOT NULL,
	[RATETYPE] [char](2) NOT NULL,
	[WARNDAYS] [smallint] NOT NULL,
	[EUROCURSW] [smallint] NOT NULL,
	[REPORTCUR] [char](3) NOT NULL,
	[HNDLCKFSC] [smallint] NOT NULL,
	[HNDINAACCT] [smallint] NOT NULL,
	[HNDNEXACCT] [smallint] NOT NULL,
	[GNLSSMTHD] [smallint] NOT NULL,
	[TAXNBR] [char](20) NOT NULL,
	[LEGALNAME] [char](60) NOT NULL,
 CONSTRAINT [CSCOM_KEY_0] PRIMARY KEY CLUSTERED 
(
	[ORGID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF





USE [possite]
GO
/****** Object:  Table [dbo].[organization]    Script Date: 04/14/2011 11:21:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[organization](
	[organization_no] [int] NOT NULL,
	[organization_name] [varchar](50) NOT NULL,
	[federal_tax_id] [varchar](40) NOT NULL,
	[legal_status_code] [varchar](10) NOT NULL,
	[state_tax_id] [varchar](40) NOT NULL,
	[tax_id] [varchar](40) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[organization_no] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF



create table currency_code
(
currency_code varchar(3) not null,
currency_name varchar(60) not null,
symbol		  varchar (4) not null,
thousand_seperator varchar (1) not null,
decimal_seperator varchar (1) not null,
negative_display smallint not null,
constraint currency_code_key primary key (currency_code) 
)

go


/* ------------------ currency ------------------------ */


create table currency
(
home_currency varchar(3) not null,
source_currency varchar(3) not null,
rate_date datetime not null,
conversion_rate decimal(15,7) not null,
spread decimal(15,7),
date_match datetime,
rate_operator smallint,
constraint pk_currency primary key (home_currency, source_currency, rate_date)
)


go