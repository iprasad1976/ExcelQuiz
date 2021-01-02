CREATE TABLE [dbo].[CandidateLogin] (
    [CandidateLoginId]        INT           IDENTITY (1, 1) NOT NULL,
    [CandidateLoginRequestId] INT           NOT NULL,
    [UserId]                  NVARCHAR (20) NOT NULL,
    [Password]                NVARCHAR (20) NOT NULL,
    [ValidFrom]               DATE          NOT NULL,
    [ValidTo]                 DATE          NOT NULL,
    [CreatedBy]               NVARCHAR (20) NOT NULL,
    [CreatedDate]             DATETIME      NOT NULL,
    [ModifiedBy]              NVARCHAR (20) NOT NULL,
    [ModifiedDate]            DATETIME      NOT NULL,
    [IsActive]                CHAR (1)      NOT NULL
);

