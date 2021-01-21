CREATE TABLE [dbo].[ExamQuestion] (
    [ExamQuestionId] INT           IDENTITY (1, 1) NOT NULL,
    [ExamId]         INT           NOT NULL,
    [QuestionId]     INT           NOT NULL,
    [MarkValue]     INT           NOT NULL,
    [CreatedBy]      NVARCHAR (20) NOT NULL,
    [CreatedDate]    DATETIME      NOT NULL,
    [ModifiedBy]     NVARCHAR (20) NOT NULL,
    [ModifiedDate]   DATETIME      NOT NULL,
    [IsActive]       CHAR (1)      NOT NULL
);

