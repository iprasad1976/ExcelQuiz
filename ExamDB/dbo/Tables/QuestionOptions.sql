CREATE TABLE [dbo].[QuestionOptions] (
    [QuestionOptionsId] INT             IDENTITY (1, 1) NOT NULL,
    [QuestionId]        INT             NOT NULL,
    [SlNo]              INT             NOT NULL,
    [Option]            NVARCHAR (1000) NOT NULL,
    [IsCorrect]         BIT             NOT NULL,
    [CreatedBy]         NVARCHAR (20)   NOT NULL,
    [CreatedDate]       DATETIME        NOT NULL,
    [ModifiedBy]        NVARCHAR (20)   NOT NULL,
    [ModifiedDate]      DATETIME        NOT NULL,
    [IsActive]          CHAR (1)        NOT NULL
);

