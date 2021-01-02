CREATE TABLE [dbo].[ExamCandidateAttempt] (
    [ExamCandidateAttemptId] INT            IDENTITY (1, 1) NOT NULL,
    [Token]                  VARCHAR (50)   NOT NULL,
    [ExamId]                 INT            NOT NULL,
    [CandidateLoginId]       INT            NOT NULL,
    [CandidateName]          NVARCHAR (100) NULL,
    [CandidateEmailId]       NVARCHAR (250) NULL,
    [CandidatePhone]         NVARCHAR (12)  NULL,
    [AttemptDate]            DATE           NULL,
    [CompleteAttempt]        BIT            NULL,
    [StartTime]              DATETIME       NULL,
    [EndTime]                DATETIME       NULL,
    [TotalScore]             INT            NULL,
    [GainScore]              INT            NULL,
    [PercentageScore]        INT            NULL
);

