

-- This SP is used to delete question
CREATE   PROC DeleteQuestion(@questionId int, @adminUserId nvarchar(20))
AS
BEGIN
	DECLARE @dt DateTime = GETDATE()

	UPDATE Question Set IsActive = 'N', ModifiedBy = @adminUserId, ModifiedDate = @dt  WHERE QuestionId = @questionId AND IsActive = 'Y'
	UPDATE QuestionOptions Set IsActive = 'N', ModifiedBy = @adminUserId, ModifiedDate = @dt  WHERE QuestionId = @questionId AND IsActive = 'Y'

	SELECT @questionId AS UpdatedId, 'Success' AS 'Status'
END

