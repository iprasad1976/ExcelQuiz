CREATE TABLE [dbo].[ExamCandidateAttemptQuestionAnswers] (
    [ExamCandidateAttemptQuestionAnswersId] INT      IDENTITY (1, 1) NOT NULL,
    [ExamCandidateAttemptQuestionsId]       INT      NOT NULL,
    [SlNo]                                  INT      NOT NULL,
    [QuestionOptionsId]                     INT      NOT NULL,
    [IsSelected]                            CHAR (1) NOT NULL
);

