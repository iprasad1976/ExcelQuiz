
-- This SP is used to exam detail
CREATE   PROC SearchQuestions(@search nvarchar(250))
AS
BEGIN
	SELECT QuestionId, QuestionType, Question, NoOfOption, MarkValue, ComplexityLevel
		FROM Question a 
			INNER JOIN QuestionType b ON a.QuestionTypeId = b.QuestionTypeId
			INNER JOIN ComplexityLevel c ON a.ComplexityLevelId = c.ComplexityLevelId
		WHERE IsActive = 'Y' AND Question LIKE '%' + @search + '%'
END

