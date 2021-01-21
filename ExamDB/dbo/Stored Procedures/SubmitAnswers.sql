
-- This SP is used to SubmitAnswer of question for Candidate
CREATE   PROC SubmitAnswers(@examId int, @userId nvarchar(20), @token varchar(50), @seqNo int, @selectedOptionIds varchar(100))
AS
BEGIN
	DECLARE @candidateLoginId INT, @examCandidateAttemptQuestionsId int, @isAnswerCorrect char(1) = 'N', @score int = 0, @questionId int = 0
	SELECT @candidateLoginId = CandidateLoginId FROM CandidateLogin WHERE UserId = @userId AND IsActive = 'Y'

	SELECT @examCandidateAttemptQuestionsId = ExamCandidateAttemptQuestionsId, @questionId = QuestionId	
		FROM ExamCandidateAttemptQuestions b 
			INNER JOIN ExamCandidateAttempt c ON b.ExamCandidateAttemptId = c.ExamCandidateAttemptId
					WHERE c.CandidateLoginId = @candidateLoginId AND c.ExamId = @examId AND b.SeqNo = @seqNo AND Token = @token

	UPDATE ExamCandidateAttemptQuestionAnswers SET IsSelected = 'N' WHERE ExamCandidateAttemptQuestionsId = @examCandidateAttemptQuestionsId
	UPDATE ExamCandidateAttemptQuestionAnswers SET IsSelected = 'Y' WHERE ExamCandidateAttemptQuestionsId = @examCandidateAttemptQuestionsId 
		AND QuestionOptionsId IN (SELECT CAST(a.value AS INT) FROM STRING_SPLIT(@selectedOptionIds, ',') a)

	IF NOT EXISTS(SELECT 1 FROM QuestionOptions a 
		INNER JOIN ExamCandidateAttemptQuestions b ON b.ExamCandidateAttemptQuestionsId = @examCandidateAttemptQuestionsId AND a.QuestionId = b.QuestionId
		INNER JOIN ExamCandidateAttemptQuestionAnswers c ON b.ExamCandidateAttemptQuestionsId = c.ExamCandidateAttemptQuestionsId AND c.IsSelected = 'Y'
		WHERE a.IsActive = 'Y' AND (a.IsCorrect <> c.IsSelected) 
	  )
	BEGIN
		SET @isAnswerCorrect = 'Y'
		SELECT @score = b.MarkValue FROM Question a
			INNER JOIN ExamQuestion b ON a.QuestionId = b.QuestionId AND b.ExamId = @examId AND b.IsActive = 'Y'
			WHERE a.QuestionId = @questionId AND a.IsActive = 'Y'
	END

		UPDATE ExamCandidateAttemptQuestions SET  IsAnswerCorrect = @isAnswerCorrect, GainScore = @score, AttemptTime = GETDATE()
			WHERE ExamCandidateAttemptQuestionsId = @examCandidateAttemptQuestionsId 
	
	
	SELECT @examCandidateAttemptQuestionsId AS UpdatedId, 'Success' AS 'Status'
END

