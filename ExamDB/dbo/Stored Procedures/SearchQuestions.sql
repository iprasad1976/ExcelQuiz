
-- This SP is used to exam detail
CREATE   PROC SearchQuestions(@examId int, @search nvarchar(250))
AS
BEGIN
	SELECT a.QuestionId, QuestionType, Question, NoOfOption, d.MarkValue, ComplexityLevel
		FROM Question a 
			INNER JOIN QuestionType b ON a.QuestionTypeId = b.QuestionTypeId
			INNER JOIN ComplexityLevel c ON a.ComplexityLevelId = c.ComplexityLevelId
			INNER JOIN ExamQuestion d ON a.QuestionId = d.QuestionId
		WHERE a.IsActive = 'Y' AND d.IsActive ='Y' AND Question LIKE @search AND d.ExamId = @examId Order By a.QuestionId
END

