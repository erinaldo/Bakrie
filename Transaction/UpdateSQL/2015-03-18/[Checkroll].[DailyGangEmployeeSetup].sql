
GO

EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'Checkroll', @level1type=N'TABLE',@level1name=N'DailyGangEmployeeSetup', @level2type=N'COLUMN',@level2name=N'EmpID'

GO

EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'Checkroll', @level1type=N'TABLE',@level1name=N'DailyGangEmployeeSetup', @level2type=N'COLUMN',@level2name=N'GangEmployeeID'

GO

/****** Object:  Table [Checkroll].[DailyGangEmployeeSetup]    Script Date: 18/03/2015 9:39:49 ******/
DROP TABLE [Checkroll].[DailyGangEmployeeSetup]
GO

/****** Object:  Table [Checkroll].[DailyGangEmployeeSetup]    Script Date: 18/03/2015 9:39:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Checkroll].[DailyGangEmployeeSetup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DDAte] [datetime] NULL,
	[DailyTeamActivityID] [nchar](50) NOT NULL,
	[GangEmployeeID] [nvarchar](50) NOT NULL,
	[EstateID] [nvarchar](50) NULL,
	[GangMasterID] [nvarchar](50) NULL,
	[EmpID] [nvarchar](50) NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
 CONSTRAINT [PK_DailyGangEmployeeSetup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[DailyTeamActivityID] ASC,
	[GangEmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'<EstateCode>+''R''+ <Max(Id)+1>' , @level0type=N'SCHEMA',@level0name=N'Checkroll', @level1type=N'TABLE',@level1name=N'DailyGangEmployeeSetup', @level2type=N'COLUMN',@level2name=N'GangEmployeeID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Employee list working under this gang/team. refers. CREmployee.EmpID.TeamMember cannot be a mandore or krani.' , @level0type=N'SCHEMA',@level0name=N'Checkroll', @level1type=N'TABLE',@level1name=N'DailyGangEmployeeSetup', @level2type=N'COLUMN',@level2name=N'EmpID'
GO


