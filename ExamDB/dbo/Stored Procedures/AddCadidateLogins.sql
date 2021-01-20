

-- This SP is used to create login credential for Candidate
--EXEC AddCadidateLogins 'prasad.indra@gmail.com', 'test', 5, 3, '1,2,4','2020/12/31', '2021/12/31'
CREATE   PROC AddCadidateLogins
(
  @requestedPersonEmail nvarchar(250), 
  @noOfRequestedUserId int,
  @noOfAttempt int,
  @examIds varchar(100), --1,2,3,4
  @validFrom date,
  @validTo date,
  @adminUserId nvarchar(20)
)
AS
BEGIN
	DECLARE @counter int = @noOfRequestedUserId
	Declare @guid varchar(50) = '', @userId varchar(20), @password varchar(20)
	Declare @dt datetime = getdate(), @reqCount int = 0
	Declare @candidateLoginRequestId int
	SELECT @reqCount = COUNT(1) FROM CandidateLoginRequest WHERE RequestedPersonEmail = @requestedPersonEmail 
	SET @reqCount = @reqCount + 1
	Declare @requestId varchar(20)
	SET @requestId = 'REQ' + REPLACE(STR(@reqCount,7),' ','0')
	
	INSERT INTO CandidateLoginRequest ([RequestId], [RequestDate], [RequestedPersonEmail], ValidFrom, ValidTo, NoofLoginRequest, NoofAttempt, [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive]) 
		VALUES (@requestId, @dt, @requestedPersonEmail, @validFrom, @validTo, @noOfRequestedUserId, @noOfAttempt, @adminUserId, @dt, @adminUserId, @dt, 'Y')

    SET @candidateLoginRequestId = SCOPE_IDENTITY()

	WHILE(@counter > 0)
	BEGIN
		
		SET @guid = newid()
		SET @userId = 'user@'+lower(substring(@guid, 1, CHARINDEX('-', @guid) -1))
		SET @password = 'pass@'+lower(right(@guid, charindex('-', reverse(@guid)) - 1))
		
		IF NOT EXISTS (SELECT 1 FROM CandidateLogin WHERE UserId = @userId AND Password = @password AND IsActive = 'Y') 
		BEGIN
			INSERT INTO CandidateLogin(CandidateLoginRequestId, UserId, [Password], ValidFrom, ValidTo, [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive]) 
			VALUES (@candidateLoginRequestId, @userId, @password, @validFrom, @validTo, @adminUserId, @dt, @adminUserId, @dt, 'Y')

			SET @counter = @counter - 1
		END
	 END

	 INSERT INTO ExamCandidate (ExamId, CandidateLoginId, TotalNoofAttempts, NoofAttempted, [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsActive]) 
		SELECT a.value AS ExamId, b.CandidateLoginId, @noOfAttempt, 0, @adminUserId, @dt, @adminUserId, @dt, 'Y'
			FROM STRING_SPLIT(@ExamIds, ',') a
			CROSS JOIN (SELECT CandidateLoginId FROM CandidateLogin WHERE CandidateLoginRequestId = @candidateLoginRequestId AND IsActive = 'Y') b

  SELECT RequestId, RequestDate, UserId, [Password], TotalNoofAttempts, ExamName, a.ValidFrom, a.ValidTo
		FROM CandidateLoginRequest a
		INNER JOIN CandidateLogin b ON a.CandidateLoginRequestId = b.CandidateLoginRequestId 
		INNER JOIN ExamCandidate c ON b.CandidateLoginId = c.CandidateLoginId
		INNER JOIN Exam d ON c.ExamId = d.ExamId 
			WHERE a.IsActive = 'Y' AND b.IsActive = 'Y' AND c.IsActive = 'Y' AND d.IsActive = 'Y'
			AND a.CandidateLoginRequestId = @candidateLoginRequestId
			ORDER BY b.CandidateLoginId, d.ExamId
END

