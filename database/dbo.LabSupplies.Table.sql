USE [lab3]
GO
/****** Object:  Table [dbo].[LabSupplies]    Script Date: 10/31/2024 3:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LabSupplies](
	[SupplyID] [int] IDENTITY(1,1) NOT NULL,
	[SupplyName] [varchar](255) NOT NULL,
	[Description] [text] NULL,
	[Unit] [varchar](20) NULL,
	[StockLevel] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[SupplyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
