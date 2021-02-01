
-- This SP is used to question detail
CREATE   PROC GetQuestionTypes
AS
BEGIN
	SELECT QuestionTypeId, QuestionType AS QuestionTypeDesc FROM QuestionType 
END

