-- This SP is used to question detail
CREATE   PROC GetQuestionExams(@questionId int)
AS
BEGIN
	SELECT ExamId, MarkValue
		FROM ExamQuestion WHERE IsActive = 'Y' AND QuestionId = @questionId
END
