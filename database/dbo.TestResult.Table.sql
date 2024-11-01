USE [lab3]
GO
/****** Object:  Table [dbo].[TestResult]    Script Date: 10/31/2024 3:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestResult](
	[ResultID] [int] IDENTITY(1,1) NOT NULL,
	[PID] [int] NULL,
	[RequestID] [int] NULL,
	[TestID] [int] NULL,
	[ResultValue] [float] NULL,
	[ResultDate] [date] NOT NULL,
	[PerformedBy] [int] NULL,
	[Flag] [varchar](10) NULL,
	[Notes] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[ResultID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[TestResult]  WITH CHECK ADD FOREIGN KEY([PerformedBy])
REFERENCES [dbo].[STAFF] ([Staff_ID])
GO
ALTER TABLE [dbo].[TestResult]  WITH CHECK ADD FOREIGN KEY([RequestID])
REFERENCES [dbo].[TEST_REQ] ([RequestID])
GO
ALTER TABLE [dbo].[TestResult]  WITH CHECK ADD FOREIGN KEY([TestID])
REFERENCES [dbo].[Test] ([TestID])
GO
ALTER TABLE [dbo].[TestResult]  WITH CHECK ADD FOREIGN KEY([PID])
REFERENCES [dbo].[Patient] ([PatientID])
GO
