
-- This SP is used to Calculate total obtained marks for Candidate
CREATE  PROC [dbo].[CalculateMarks](@examId int, @userId nvarchar(20), @token varchar(50))
AS
BEGIN
	DECLARE @candidateLoginId INT, @totalGainScore int
	SELECT @candidateLoginId = CandidateLoginId FROM CandidateLogin WHERE UserId = @userId AND IsActive = 'Y'

	SELECT 	@totalGainScore = SUM(b.GainScore)
		FROM ExamCandidateAttemptQuestions b 
			INNER JOIN ExamCandidateAttempt c ON b.ExamCandidateAttemptId = c.ExamCandidateAttemptId
					WHERE c.CandidateLoginId = @candidateLoginId AND c.ExamId = @examId AND Token = @token

	UPDATE ExamCandidateAttempt SET GainScore = @totalGainScore, PercentageScore = (@totalGainScore * 100) / TotalScore, EndTime = GETDATE(),
		CompleteAttempt = 1
		WHERE Token = @token and CandidateLoginId = @candidateLoginId AND ExamId = @examId
	UPDATE ExamCandidate SET NoofAttempted = NoofAttempted + 1, ModifiedBy = 'System', ModifiedDate = GETDATE() 
		WHERE IsActive = 'Y' AND ExamId = @examId AND CandidateLoginId = @candidateLoginId 
	
	SELECT ExamName, RequestedPersonEmail, CandidateName, CandidateEmailId, CandidatePhone, ISNULL(TotalScore, 0) AS TotalScore, 
			ISNULL(GainScore, 0) AS GainScore, ISNULL(PercentageScore, 0) As PercentageScore, StartTime, EndTime, 
	    CASE WHEN d.PassingPercentage <= PercentageScore THEN 1 ELSE 0 END AS IsPassed
		FROM ExamCandidateAttempt a
		INNER JOIN CandidateLogin b ON a.CandidateLoginId = b.CandidateLoginId
		INNER JOIN CandidateLoginRequest c ON b.CandidateLoginRequestId = c.CandidateLoginRequestId
		INNER JOIN Exam d ON a.ExamId = d.ExamId
		WHERE a.Token = @token AND a.ExamId = @examId AND a.CandidateLoginId = @candidateLoginId 
		AND b.IsActive = 'Y' AND c.IsActive = 'Y' AND d.IsActive = 'Y'
END

