CREATE TABLE [dbo].[CandidateLoginRequest](
	[CandidateLoginRequestId] [int] IDENTITY(1,1) NOT NULL,
	[RequestId] [nvarchar](20) NOT NULL,
	[RequestDate] [datetime] NOT NULL,
	[RequestedPersonEmail] [nvarchar](250) NOT NULL,
	[NoofLoginRequest] int  NOT NULL,
	[NoofAttempt] int  NOT NULL,
	[ValidFrom] datetime  NOT NULL,
	[ValidTo] datetime  NOT NULL,
	[CreatedBy] [nvarchar](20) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](20) NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[IsActive] [char](1) NOT NULL
);

