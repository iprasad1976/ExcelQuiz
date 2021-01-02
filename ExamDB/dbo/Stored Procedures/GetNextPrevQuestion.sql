
-- This SP is used to Get next prev question for Candidate
CREATE   PROC GetNextPrevQuestion(@examId int, @userId nvarchar(20), @token varchar(50), @seqNo int)
AS
BEGIN
	DECLARE @candidateLoginId INT
	SELECT @candidateLoginId = CandidateLoginId FROM CandidateLogin WHERE UserId = @userId AND IsActive = 'Y'

	SELECT a.QuestionId, a.Question, a.QuestionTypeId, a.MarkValue FROM Question a 
					INNER JOIN ExamCandidateAttemptQuestions b ON a.QuestionId = b.QuestionId
					INNER JOIN ExamCandidateAttempt c ON b.ExamCandidateAttemptId = c.ExamCandidateAttemptId
					WHERE a.IsActive = 'Y' AND c.CandidateLoginId = @candidateLoginId AND c.ExamId = @examId AND b.SeqNo = @seqNo AND Token = @token
			
END

