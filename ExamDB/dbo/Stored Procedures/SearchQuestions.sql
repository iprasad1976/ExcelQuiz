
-- This SP is used to exam detail
CREATE   PROC SearchQuestions(@examId int, @search nvarchar(250))
AS
BEGIN
	SELECT a.QuestionId, QuestionType, Question, NoOfOption 
		FROM Question a 
	   INNER JOIN QuestionType b ON a.QuestionTypeId = b.QuestionTypeId
	   INNER JOIN ExamQuestion c ON a.QuestionId = c.QuestionId AND c.ExamId = @examId
		WHERE a.IsActive = 'Y' AND c.IsActive = 'Y' AND Question LIKE @search Order By a.QuestionId
END

