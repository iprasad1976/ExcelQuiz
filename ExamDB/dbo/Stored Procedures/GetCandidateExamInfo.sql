
-- This SP is used to Get list of assigned exam for Candiate
CREATE   PROC GetCandidateExamInfo(@examId int, @userId nvarchar(20))
AS
BEGIN
  SELECT d.ExamId, ExamName, Instructions, TotalNoofAttempts, NoofAttempted
		FROM CandidateLoginRequest a
		INNER JOIN CandidateLogin b ON a.CandidateLoginRequestId= b.CandidateLoginRequestId 
		INNER JOIN ExamCandidate c ON b.CandidateLoginId = c.CandidateLoginId
		INNER JOIN Exam d ON c.ExamId = d.ExamId 
			WHERE a.IsActive = 'Y' AND b.IsActive = 'Y' AND c.IsActive = 'Y' AND d.IsActive = 'Y'
			AND b.UserId = @userId AND d.ExamId = @examId
END

