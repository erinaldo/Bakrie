
GO

/****** Object:  Table [dbo].[Budget.FieldRubberProduction]    Script Date: 26/8/2015 9:41:28 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Budget].[FieldRubberProduction](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[BlockID] [nvarchar](50) NULL,
	[EstateId] [nvarchar](50) NULL,
	[ZMonth] [int] NULL,
	[ZYear] [int] NULL,
	[BudgetProduksi] [numeric](18, 2) NULL,
	[JumlahHariKerja] [int] NULL,
	[JumlahTask] [numeric](18, 2) NULL,
 CONSTRAINT [PK_Budget.FieldRubberProduction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


