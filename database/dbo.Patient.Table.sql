USE [lab3]
GO
/****** Object:  Table [dbo].[Patient]    Script Date: 10/31/2024 3:04:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patient](
	[PatientID] [int] IDENTITY(11,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[DateOfBirth] [date] NULL,
	[Gender] [varchar](10) NULL,
	[Address] [varchar](255) NULL,
	[PhoneNumber] [varchar](20) NULL,
	[MedicalHistory] [text] NULL,
	[EmergencyContactName] [varchar](255) NULL,
	[EmergencyContactPhone] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[PatientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
