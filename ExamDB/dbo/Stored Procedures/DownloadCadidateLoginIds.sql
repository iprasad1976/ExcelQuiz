


-- This SP is used to get list of Candidate for download or send email
CREATE   PROC DownloadCadidateLoginIds(@candidateLoginRequestId int)
AS
BEGIN
  SELECT RequestId, RequestDate, UserId, [Password], TotalNoofAttempts, ExamName, ValidFrom, ValidTo
		FROM CandidateLoginRequest a
		INNER JOIN CandidateLogin b ON a.CandidateLoginRequestId= b.CandidateLoginRequestId 
		INNER JOIN ExamCandidate c ON b.CandidateLoginId = c.CandidateLoginId
		INNER JOIN Exam d ON c.ExamId = d.ExamId 
			WHERE a.IsActive = 'Y' AND b.IsActive = 'Y' AND c.IsActive = 'Y' AND d.IsActive = 'Y'
			AND a.CandidateLoginRequestId = @candidateLoginRequestId
			ORDER BY b.CandidateLoginId, d.ExamId
END

