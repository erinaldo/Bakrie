

/****** Object:  Table [dbo].[Integration]    Script Date: 17/2/2015 1:41:56 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Integration](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IntegrationModule] [nvarchar](50) NULL,
	[LastRunDateTime] [datetime] NULL,
	[LastRunId] [bigint] NULL,
 CONSTRAINT [PK_Integration] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



