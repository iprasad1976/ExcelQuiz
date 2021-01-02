CREATE TABLE [dbo].[CandidateLoginToken] (
    [CandidateLoginTokenId] INT          IDENTITY (1, 1) NOT NULL,
    [CandidateLoginId]      INT          NOT NULL,
    [Token]                 VARCHAR (50) NOT NULL,
    [LoginStartTime]        DATETIME     NOT NULL,
    [LoginEndTime]          DATETIME     NOT NULL
);

