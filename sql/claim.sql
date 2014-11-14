USE [XPlatInsurance]
GO

/****** Object:  Table [dbo].[Claim]    Script Date: 11/13/2014 21:16:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Claim](
	[ClaimID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [varchar](50) NOT NULL,
	[IncidentDate] [datetime] NOT NULL,
	[ReportDateTimeUtc] [datetime] NOT NULL,
	[Location] [varchar](2000) NOT NULL,
	[StatusID] [int] NOT NULL,
 CONSTRAINT [PK_Claim] PRIMARY KEY CLUSTERED 
(
	[ClaimID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Claim] ADD  CONSTRAINT [DF_Table_1_ReportDate]  DEFAULT (getutcdate()) FOR [ReportDateTimeUtc]
GO

ALTER TABLE [dbo].[Claim] ADD  CONSTRAINT [DF_Claim_StatusID]  DEFAULT ((1)) FOR [StatusID]
GO

