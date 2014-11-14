USE [XPlatInsurance]
GO

/****** Object:  Table [dbo].[ClaimDetail]    Script Date: 11/13/2014 21:16:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ClaimDetail](
	[ClaimDetailID] [int] NOT NULL,
	[ClaimID] [int] NOT NULL,
	[VehicleID] [varchar](50) NOT NULL,
	[Damage] [varchar](2000) NOT NULL,
 CONSTRAINT [PK_ClaimDetail] PRIMARY KEY CLUSTERED 
(
	[ClaimDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ClaimDetail]  WITH CHECK ADD  CONSTRAINT [FK_ClaimDetail_Claim] FOREIGN KEY([ClaimID])
REFERENCES [dbo].[Claim] ([ClaimID])
GO

ALTER TABLE [dbo].[ClaimDetail] CHECK CONSTRAINT [FK_ClaimDetail_Claim]
GO

