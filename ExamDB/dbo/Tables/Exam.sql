CREATE TABLE [dbo].[Exam] (
    [ExamId]            INT             IDENTITY (1, 1) NOT NULL,
    [ExamName]          NVARCHAR (1000) NOT NULL,
    [TotalMarks]        INT             NOT NULL,
    [PassingPercentage] INT             NOT NULL,
    [Instructions]      NVARCHAR (4000) NOT NULL,
    [Duration]          INT             NOT NULL,
    [CreatedBy]         NVARCHAR (20)   NOT NULL,
    [CreatedDate]       DATETIME        NOT NULL,
    [ModifiedBy]        NVARCHAR (20)   NOT NULL,
    [ModifiedDate]      DATETIME        NOT NULL,
    [IsActive]          CHAR (1)        NOT NULL
);

