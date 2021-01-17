
-- End Candidate Module

-- Start Admin Module

-- This SP is used to login screen for Admin
--EXEC GetAdminToken 'Test', 'Test'

CREATE   PROC GetAdminToken
(
   @userId nvarchar(20),
   @password nvarchar(20)
)
AS
BEGIN
	DECLARE @adminLoginId int = 0
	DECLARE @token varchar(50) = ''
	SELECT @adminLoginId = AdminLoginId FROM AdminLogin  WHERE UserId = @userId AND Password = @password AND IsActive = 'Y'
   IF @adminLoginId > 0
   BEGIN
		SET @token = newid() 
		DECLARE @dt datetime = getdate()

		INSERT INTO AdminLoginToken (AdminLoginId, Token, LoginStartTime, LoginEndTime) values (@adminLoginId, @token, @dt, DATEADD(d, 1, @dt))
	END	
	
	SELECT @token AS Token, @dt As LoginStart, DATEADD(d, 1, @dt) As LoginEnd
END

