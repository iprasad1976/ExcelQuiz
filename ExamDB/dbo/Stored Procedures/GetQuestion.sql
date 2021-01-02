﻿
-- This SP is used to question detail
CREATE   PROC GetQuestion(@questionId int)
AS
BEGIN
	SELECT QuestionId, QuestionTypeId, Question, NoOfOption, MarkValue, ComplexityLevelId
		FROM Question WHERE IsActive = 'Y' AND QuestionId = @questionId
END
