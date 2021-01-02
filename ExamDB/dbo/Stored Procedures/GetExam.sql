
-- This SP is used to exam detail
CREATE   PROC GetExam(@examId int)
AS
BEGIN
	SELECT ExamId, ExamName, TotalMarks, PassingPercentage, Instructions, Duration FROM Exam WHERE IsActive = 'Y' AND ExamId = @examId
END

