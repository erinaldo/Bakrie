
/****** Object:  Table [Checkroll].[THR]    Script Date: 19/1/2016 8:59:49 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Checkroll].[Bonus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BonusId] [nvarchar](50) NOT NULL,
	[EstateID] [nvarchar](50) NOT NULL,
	[ActiveMonthYearID] [nvarchar](50) NOT NULL,
	[EmpID] [nvarchar](50) NOT NULL,
	[ProcessingDate] [datetime] NOT NULL,
	[YearPeriod] [int] NOT NULL,
	[Bruto] [numeric](18, 2) NULL,
	[DedIncomeTax] [numeric](18, 2) NULL,
	[DedCooper] [numeric](18, 2) NULL,
	[DedOthers] [numeric](18, 2) NULL,
	[Netto] [numeric](18, 2) NULL,
	[RoundUP] [numeric](18, 2) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
	[BerasNatura] [numeric](18, 3) NULL,
	[DagingNatura] [numeric](18, 3) NULL,
 CONSTRAINT [PK_BONUS] PRIMARY KEY CLUSTERED 
(
	[BonusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) 


