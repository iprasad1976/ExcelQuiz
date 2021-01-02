CREATE TABLE [dbo].[CandidateLoginRequest] (
    [CandidateLoginRequestId] INT            IDENTITY (1, 1) NOT NULL,
    [RequestId]               NVARCHAR (20)  NOT NULL,
    [RequestDate]             DATETIME       NOT NULL,
    [RequestedPersonEmail]    NVARCHAR (250) NOT NULL,
    [CreatedBy]               NVARCHAR (20)  NOT NULL,
    [CreatedDate]             DATETIME       NOT NULL,
    [ModifiedBy]              NVARCHAR (20)  NOT NULL,
    [ModifiedDate]            DATETIME       NOT NULL,
    [IsActive]                CHAR (1)       NOT NULL
);

