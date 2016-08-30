
/****** Object:  Table [dbo].[MandorBesarPremi]    Script Date: 4/9/2015 6:28:57 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Checkroll].[MandorBesarPremi](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EmpId] [nvarchar](50) NULL,
	[Estateid] [nvarchar](50) NULL,
	[MandorPanenDiawasi] [int] NULL,
	[MandorDeresDiawasi] [int] NULL,
	[HaPanenDiawasi] [numeric](18,4) NULL,
	[HaDeresDiawasi] [numeric](18,4) NULL,
	[PremiPanen] [numeric](18,4) NULL,
	[PremiDeres] [numeric](18,4) NULL,
	[PremiDibayar] [numeric](18,4) NULL,
	[DDate] [date] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_MandorBesarPremi] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


