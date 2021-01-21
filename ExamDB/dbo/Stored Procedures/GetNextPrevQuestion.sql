
-- This SP is used to Get next prev question for Candidate
CREATE   PROC GetNextPrevQuestion(@examId int, @userId nvarchar(20), @token varchar(50), @seqNo int)
AS
BEGIN
	DECLARE @candidateLoginId INT
	SELECT @candidateLoginId = CandidateLoginId FROM CandidateLogin WHERE UserId = @userId AND IsActive = 'Y'

	SELECT a.QuestionId, a.Question, a.QuestionTypeId, d.MarkValue FROM Question a 
					INNER JOIN ExamQuestion d ON a.QuestionId = d.QuestionId AND d.ExamId = @examId AND d.IsActive = 'Y'
					INNER JOIN ExamCandidateAttemptQuestions b ON a.QuestionId = b.QuestionId AND b.SeqNo = @seqNo 
					INNER JOIN ExamCandidateAttempt c ON b.ExamCandidateAttemptId = c.ExamCandidateAttemptId AND c.ExamId = @examId AND c.CandidateLoginId = @candidateLoginId
					WHERE  a.IsActive = 'Y' AND c.Token = @token
			
END

