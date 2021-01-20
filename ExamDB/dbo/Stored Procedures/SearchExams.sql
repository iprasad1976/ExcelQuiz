
-- This SP is used to exam detail
CREATE   PROC SearchExams(@search nvarchar(250))
AS
BEGIN
	SELECT ExamId, ExamName, TotalMarks, PassingPercentage, Instructions, Duration FROM Exam WHERE IsActive = 'Y' AND ExamName LIKE @search order by ExamName
END

