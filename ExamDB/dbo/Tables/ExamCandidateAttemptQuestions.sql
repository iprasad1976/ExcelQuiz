CREATE TABLE [dbo].[ExamCandidateAttemptQuestions] (
    [ExamCandidateAttemptQuestionsId] INT      IDENTITY (1, 1) NOT NULL,
    [ExamCandidateAttemptId]          INT      NOT NULL,
    [SeqNo]                           INT      NOT NULL,
    [QuestionId]                      INT      NOT NULL,
    [IsAnswerCorrect]                 CHAR (1) NULL,
    [GainScore]                       INT      NULL,
    [AttemptTime]                     DATETIME NULL
);

