
-- This SP is used to question detail
CREATE   PROC GetQuestion(@questionId int)
AS
BEGIN
	SELECT QuestionId, QuestionType, a.QuestionTypeId, Question, NoOfOption
		FROM Question a INNER JOIN QuestionType b ON a.QuestionTypeId = b.QuestionTypeId
		 WHERE IsActive = 'Y' AND QuestionId = @questionId
END

