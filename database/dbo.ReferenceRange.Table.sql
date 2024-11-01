USE [lab3]
GO
/****** Object:  Table [dbo].[ReferenceRange]    Script Date: 10/31/2024 3:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReferenceRange](
	[ReferenceRangeID] [int] IDENTITY(1,1) NOT NULL,
	[AgeGroup] [varchar](20) NULL,
	[Gender] [varchar](10) NULL,
	[LowerLimit] [float] NULL,
	[UpperLimit] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[ReferenceRangeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
