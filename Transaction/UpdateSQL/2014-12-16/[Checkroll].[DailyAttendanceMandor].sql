


/****** Object:  Table [Checkroll].[DailyAttendanceMandor]    Script Date: 26/11/2014 8:37:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Checkroll].[DailyAttendanceMandor](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EstateID] [nvarchar](50) NULL,
	[ActiveMonthYearID] [nvarchar](50) NOT NULL,
	[RDate] [datetime] NULL,
	[EmpID] [nvarchar](50) NULL,
	[AttendanceSetupID] [nvarchar](50) NULL,
	[ConcurrencyId] [timestamp] NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
 CONSTRAINT [PK_DailyAttendanceMandor] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [Checkroll].[DailyAttendanceMandor]  WITH CHECK ADD  CONSTRAINT [FK_DailyAttendanceMandor_ActiveMonthYear] FOREIGN KEY([ActiveMonthYearID])
REFERENCES [General].[ActiveMonthYear] ([ActiveMonthYearID])
GO

ALTER TABLE [Checkroll].[DailyAttendanceMandor] CHECK CONSTRAINT [FK_DailyAttendanceMandor_ActiveMonthYear]
GO

ALTER TABLE [Checkroll].[DailyAttendanceMandor]  WITH CHECK ADD  CONSTRAINT [FK_DailyAttendanceMandor_CREmployee] FOREIGN KEY([EmpID])
REFERENCES [Checkroll].[CREmployee] ([EmpID])
GO

ALTER TABLE [Checkroll].[DailyAttendanceMandor] CHECK CONSTRAINT [FK_DailyAttendanceMandor_CREmployee]
GO

ALTER TABLE [Checkroll].[DailyAttendanceMandor]  WITH CHECK ADD  CONSTRAINT [FK_DailyAttendanceMandor_Estate] FOREIGN KEY([EstateID])
REFERENCES [General].[Estate] ([EstateID])
GO

ALTER TABLE [Checkroll].[DailyAttendanceMandor] CHECK CONSTRAINT [FK_DailyAttendanceMandor_Estate]
GO


