CREATE TABLE [dbo].[Question] (
    [QuestionId]        INT             IDENTITY (1, 1) NOT NULL,
    [QuestionTypeId]    INT             NOT NULL,
    [Question]          NVARCHAR (1000) NOT NULL,
    [NoOfOption]        INT             NOT NULL,
    [MarkValue]         INT             NOT NULL,
    [ComplexityLevelId] INT             NOT NULL,
    [CreatedBy]         NVARCHAR (20)   NOT NULL,
    [CreatedDate]       DATETIME        NOT NULL,
    [ModifiedBy]        NVARCHAR (20)   NOT NULL,
    [ModifiedDate]      DATETIME        NOT NULL,
    [IsActive]          CHAR (1)        NOT NULL
);

