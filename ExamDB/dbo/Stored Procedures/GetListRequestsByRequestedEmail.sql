
-- This SP is used to get list of Candidate for download or send email
CREATE   PROC GetListRequestsByRequestedEmail(@requestedPersonEmail nvarchar(250))
AS
BEGIN
  SELECT CandidateLoginRequestId, RequestId, RequestDate, RequestedPersonEmail
		FROM CandidateLoginRequest 
			WHERE IsActive = 'Y' AND RequestedPersonEmail = @requestedPersonEmail
			ORDER BY RequestDate Desc, RequestId ASC
END

