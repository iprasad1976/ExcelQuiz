
-- This SP is used to get list of Candidate for download or send email
CREATE   PROC DeleteRequestedLogin(@candidateLoginRequestId int, @adminUserId nvarchar(20))
AS
BEGIN
	Declare @dt datetime = getdate()

	IF NOT EXISTS (SELECT 1 FROM ExamCandidateAttempt a 
					INNER JOIN CandidateLogin b ON a.CandidateLoginId = b.CandidateLoginId
					INNER JOIN CandidateLoginRequest c ON b.CandidateLoginRequestId = c.CandidateLoginRequestId
					WHERE b.IsActive = 'Y' AND c.IsActive = 'Y' AND c.CandidateLoginRequestId = @candidateLoginRequestId)
	BEGIN

		UPDATE ExamCandidate  SET IsActive = 'N', ModifiedBy = @adminUserId, ModifiedDate = @dt 
			WHERE CandidateLoginId IN (SELECT CandidateLoginId FROM CandidateLogin b
											INNER JOIN CandidateLoginRequest c 
												ON b.CandidateLoginRequestId = c.CandidateLoginRequestId
										WHERE b.IsActive = 'Y' AND c.IsActive = 'Y' AND c.CandidateLoginRequestId = @candidateLoginRequestId)

		UPDATE CandidateLogin SET IsActive = 'N', ModifiedBy = @adminUserId, ModifiedDate = @dt 
			WHERE IsActive = 'Y' AND CandidateLoginRequestId 
				IN (SELECT CandidateLoginRequestId FROM CandidateLoginRequest WHERE IsActive = 'Y' 
							AND CandidateLoginRequestId = @candidateLoginRequestId)

		UPDATE CandidateLoginRequest SET IsActive = 'N', ModifiedBy = @adminUserId, ModifiedDate = @dt 
			WHERE IsActive = 'Y' AND CandidateLoginRequestId = @candidateLoginRequestId

	END

	SELECT @candidateLoginRequestId AS UpdatedId, 'Success' AS 'Status'
END

