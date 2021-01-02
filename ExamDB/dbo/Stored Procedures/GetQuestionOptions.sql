
-- This SP is used to question detail
CREATE   PROC GetQuestionOptions(@questionId int)
AS
BEGIN
	SELECT QuestionOptionsId, SlNo, [Option], IsCorrect
		FROM QuestionOptions WHERE IsActive = 'Y' AND QuestionId = @questionId
END

