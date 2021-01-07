

-- This SP is used to delete exam
CREATE PROC DeleteExam(@examId int, @adminUserId nvarchar(20))
AS
BEGIN
	DECLARE @dt DateTime = GETDATE()

	UPDATE Exam Set IsActive = 'N', ModifiedBy = @adminUserId, ModifiedDate = @dt  WHERE ExamId = @examId AND IsActive = 'Y'
	
	SELECT @examId AS UpdatedId, 'Success' AS 'Status'
END

