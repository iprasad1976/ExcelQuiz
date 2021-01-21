
-- Start Candidate Module

-- This SP is used to login screen for Candidate
--EXEC GetCandidateToken 'Test', 'Test'

CREATE   PROC GetCandidateToken
(
   @userId nvarchar(20),
   @password nvarchar(20)
)
AS
BEGIN
   DECLARE @candidateLoginId int = 0
   DECLARE @token varchar(50) = ''
   SELECT @candidateLoginId = CandidateLoginId FROM CandidateLogin  WHERE UserId = @userId AND Password = @password AND IsActive = 'Y' AND GETDATE() BETWEEN ValidFrom AND DATEADD(d, 1, ValidTo)
   IF @candidateLoginId > 0
   BEGIN
		SET @token = newid() 
		DECLARE @dt datetime = getdate()

		INSERT INTO CandidateLoginToken (CandidateLoginId, Token, LoginStartTime, LoginEndTime) values (@candidateLoginId, @token, @dt, DATEADD(HOUR, 8, @dt))
	END	
	
	SELECT @token AS Token, @dt As LoginStart, DATEADD(HOUR, 8, @dt) As LoginEnd
END

