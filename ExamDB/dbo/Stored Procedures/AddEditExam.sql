
-- This SP is used to Add or Edit exam
CREATE   PROC AddEditExam(@examId int, @examName nvarchar(1000), 
				@totalMarks int, @passingPercentage int, @instructions nvarchar(4000), @duration int, @adminUserId nvarchar(20))
AS
BEGIN
  DECLARE @dt DateTime = GETDATE()

  IF @examId = 0
  BEGIN
	INSERT INTO Exam (ExamName, TotalMarks, PassingPercentage, Instructions, Duration, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, IsActive)
			VALUES (@examName, @totalMarks, @passingPercentage, @instructions, @duration, @adminUserId, @dt, @adminUserId, @dt, 'Y')
    SET @examId = SCOPE_IDENTITY()
  END
  ELSE
  BEGIN
	UPDATE Exam SET ExamName = @examName, TotalMarks = @totalMarks, PassingPercentage = @passingPercentage, Instructions = @instructions,
			Duration = @duration, ModifiedBy = @AdminUserId, ModifiedDate = @dt WHERE IsActive = 'Y' AND ExamId = @examId
	
  END

  SELECT @examId AS UpdatedId, 'Success' AS 'Status'
END

