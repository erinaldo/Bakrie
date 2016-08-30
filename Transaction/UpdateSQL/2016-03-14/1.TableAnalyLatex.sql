
/****** Object:  Table [Checkroll].[AnalyLatexCost]    Script Date: 9/3/2016 1:49:20 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Checkroll].[AnalyLatexCost](
	[EstateID] [nvarchar](50) NOT NULL,
	[ActiveMonthYearID] [nvarchar](50) NOT NULL,
	[MainDescription] [nvarchar](50) NOT NULL,
	[SubDescription] [nvarchar](50) NOT NULL,
	[YOP] [nvarchar](50) NOT NULL,
	[MainOrderCounter] [int] NULL,
	[SubOrderCounterMain] [int] NOT NULL,
	[SubOrderCounterSub] [int] IDENTITY(1,1) NOT NULL,
	[PayrollBunches] [numeric](18, 3) NULL,
	[FactoryKG] [numeric](18, 3) NULL,
	[KGPerBunches] [numeric](18, 3) NULL,
	[Mandays] [numeric](18, 3) NULL,
	[KGPerMandays] [numeric](18, 3) NULL,
	[Cost] [numeric](18, 3) NULL,
	[CostPerKG] [numeric](18, 3) NULL,
	[CostPerBunches] [numeric](18, 3) NULL,
	[FactoryBunches] [numeric](18, 3) NULL,
	[DifferenceBunches] [numeric](18, 3) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NULL,
 CONSTRAINT [PK_AnalyLatexCost] PRIMARY KEY CLUSTERED 
(
	[EstateID] ASC,
	[ActiveMonthYearID] ASC,
	[MainDescription] ASC,
	[SubDescription] ASC,
	[YOP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [Checkroll].[AnalyLatexCost]  WITH NOCHECK ADD  CONSTRAINT [FK_AnalyLatexCost_ActiveMonthYear] FOREIGN KEY([ActiveMonthYearID])
REFERENCES [General].[ActiveMonthYear] ([ActiveMonthYearID])
GO

ALTER TABLE [Checkroll].[AnalyLatexCost] NOCHECK CONSTRAINT [FK_AnalyLatexCost_ActiveMonthYear]
GO

ALTER TABLE [Checkroll].[AnalyLatexCost]  WITH NOCHECK ADD  CONSTRAINT [FK_AnalyLatexCost_Estate] FOREIGN KEY([EstateID])
REFERENCES [General].[Estate] ([EstateID])
GO

ALTER TABLE [Checkroll].[AnalyLatexCost] NOCHECK CONSTRAINT [FK_AnalyLatexCost_Estate]
GO


