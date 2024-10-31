USE [lab3]
GO
/****** Object:  Table [dbo].[Lab_Report]    Script Date: 10/31/2024 3:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lab_Report](
	[Report_id] [int] IDENTITY(1,1) NOT NULL,
	[Patient_name] [varchar](255) NULL,
	[ReportDate] [date] NULL,
	[ReportText] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
