
-- This SP is used to Get next prev question for Candidate
CREATE  PROC GetNextPrevQuestionOptions(@examId int, @userId nvarchar(20), @token varchar(50), @seqNo int)
AS
BEGIN
	DECLARE @candidateLoginId INT
	SELECT @candidateLoginId = CandidateLoginId FROM CandidateLogin WHERE UserId = @userId AND IsActive = 'Y'

	SELECT a.QuestionOptionsId, a.[Option], d.SlNo, d.IsSelected FROM QuestionOptions a 
					INNER JOIN ExamCandidateAttemptQuestionAnswers d ON a.QuestionOptionsId = d.QuestionOptionsId 
					INNER JOIN ExamCandidateAttemptQuestions b ON a.QuestionId = b.QuestionId
					    AND b.SeqNo = @seqNo AND b.ExamCandidateAttemptQuestionsId = d.ExamCandidateAttemptQuestionsId 
					INNER JOIN ExamCandidateAttempt c 
					   ON b.ExamCandidateAttemptId = c.ExamCandidateAttemptId AND c.ExamId = @examId AND c.CandidateLoginId = @candidateLoginId
					WHERE  a.IsActive = 'Y' AND c.Token = @token
					ORDER BY d.SlNo
			
			
END
