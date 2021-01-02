


-- This SP is used to Get list of assigned exam for Candiate
CREATE   PROC GetListExam(@userId nvarchar(20))
AS
BEGIN
  SELECT d.ExamId, ExamName
		FROM CandidateLoginRequest a
		INNER JOIN CandidateLogin b ON a.CandidateLoginRequestId= b.CandidateLoginRequestId 
		INNER JOIN ExamCandidate c ON b.CandidateLoginId = c.CandidateLoginId
		INNER JOIN Exam d ON c.ExamId = d.ExamId 
			WHERE a.IsActive = 'Y' AND b.IsActive = 'Y' AND c.IsActive = 'Y' AND d.IsActive = 'Y'
			AND b.UserId = @userId 
END

