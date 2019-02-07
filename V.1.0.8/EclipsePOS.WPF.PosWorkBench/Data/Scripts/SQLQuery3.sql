USE [possite]
GO
/****** Object:  Table [dbo].[department]    Script Date: 06/24/2008 09:53:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[department]') AND type in (N'U'))
DROP TABLE [dbo].[department]
go

USE [possite]
GO
/****** Object:  Table [dbo].[dialog]    Script Date: 06/24/2008 09:53:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dialog]') AND type in (N'U'))
DROP TABLE [dbo].[dialog]

USE [possite]
GO
/****** Object:  Table [dbo].[dialog_event]    Script Date: 06/24/2008 09:54:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dialog_event]') AND type in (N'U'))
DROP TABLE [dbo].[dialog_event]
go


USE [possite]
GO
/****** Object:  Table [dbo].[employee]    Script Date: 06/24/2008 10:04:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[employee]') AND type in (N'U'))
DROP TABLE [dbo].[employee]
go

USE [possite]
GO
/****** Object:  Table [dbo].[help]    Script Date: 06/24/2008 10:04:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[help]') AND type in (N'U'))
DROP TABLE [dbo].[help]
go

USE [possite]
GO
/****** Object:  Table [dbo].[input_filter]    Script Date: 06/24/2008 10:06:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[input_filter]') AND type in (N'U'))
DROP TABLE [dbo].[input_filter]
go

USE [possite]
GO
/****** Object:  Table [dbo].[input_filter_field]    Script Date: 06/24/2008 10:07:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[input_filter_field]') AND type in (N'U'))
DROP TABLE [dbo].[input_filter_field]

go

USE [possite]
GO
/****** Object:  Table [dbo].[item]    Script Date: 06/24/2008 10:07:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[item]') AND type in (N'U'))
DROP TABLE [dbo].[item]

go

USE [possite]
GO
/****** Object:  Table [dbo].[item_link]    Script Date: 06/24/2008 10:08:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[item_link]') AND type in (N'U'))
DROP TABLE [dbo].[item_link]

USE [possite]
GO
/****** Object:  Table [dbo].[ItemGroup]    Script Date: 06/24/2008 10:08:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ItemGroup]') AND type in (N'U'))
DROP TABLE [dbo].[ItemGroup]

go

USE [possite]
GO
/****** Object:  Table [dbo].[media]    Script Date: 06/24/2008 10:13:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[media]') AND type in (N'U'))
DROP TABLE [dbo].[media]

go

USE [possite]
GO
/****** Object:  Table [dbo].[menu_config]    Script Date: 06/24/2008 10:14:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[menu_config]') AND type in (N'U'))
DROP TABLE [dbo].[menu_config]
go

USE [possite]
GO
/****** Object:  Table [dbo].[menu_panels]    Script Date: 06/24/2008 10:14:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[menu_panels]') AND type in (N'U'))
DROP TABLE [dbo].[menu_panels]

go

USE [possite]
GO
/****** Object:  Table [dbo].[menu_root]    Script Date: 06/24/2008 10:15:04 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[menu_root]') AND type in (N'U'))
DROP TABLE [dbo].[menu_root]

go

USE [possite]
GO
/****** Object:  Table [dbo].[Organization]    Script Date: 06/24/2008 10:18:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Organization]') AND type in (N'U'))
DROP TABLE [dbo].[Organization]

go

USE [possite]
GO
/****** Object:  Table [dbo].[plu]    Script Date: 06/24/2008 10:19:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[plu]') AND type in (N'U'))
DROP TABLE [dbo].[plu]

go

USE [possite]
GO
/****** Object:  Table [dbo].[pos]    Script Date: 06/24/2008 10:19:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pos]') AND type in (N'U'))
DROP TABLE [dbo].[pos]

go


/****** Object:  Table [dbo].[pos]    Script Date: 06/24/2008 10:19:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pos_balance_detail]') AND type in (N'U'))
DROP TABLE [dbo].[pos_balance_detail]

go

/****** Object:  Table [dbo].[pos]    Script Date: 06/24/2008 10:19:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pos_config]') AND type in (N'U'))
DROP TABLE [dbo].[pos_config]

go

/****** Object:  Table [dbo].[pos]    Script Date: 06/24/2008 10:19:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pos]') AND type in (N'U'))
DROP TABLE [dbo].[pos]

go


















