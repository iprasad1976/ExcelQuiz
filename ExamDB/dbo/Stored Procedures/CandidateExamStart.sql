
-- This SP is used to Get list of assigned exam for Candidate
CREATE   PROC CandidateExamStart(@examId int, @userId nvarchar(20), @token varchar(50), @candidateName nvarchar(100), @candidateEmailId nvarchar(250), @candidatePhone nvarchar(12))
AS
BEGIN
	DECLARE @totalmarks int = 0, @candidateLoginId int = 0, @minQuestionMark int = 0, @totalQestions int = 0, @questionTypeId int = 0,
		@examCandidateAttemptId INT = 0, @counter int = 1, @questId int = 0, @markval int = 0, @examCandidateAttemptQuestionsId int = 0
	Declare @RandomQuestions Table(sqno int identity(1,1), questionId int, markValue int, questionTypeId int)
	Declare @RandomOptions Table(sqno int identity(1,1), questionOptionsId int)

	SELECT @candidateLoginId = CandidateLoginId FROM CandidateLogin WHERE UserId = @userId AND IsActive = 'Y'

	IF @candidateLoginId > 0
	BEGIN

		SELECT @totalmarks = TotalMarks FROM Exam WHERE ExamId = @examId AND IsActive = 'Y'
		SELECT @minQuestionMark = MIN(b.MarkValue), @totalQestions = Count(1) FROM Question a 
			INNER JOIN ExamQuestion b ON a.QuestionId = b.QuestionId 
				Where ExamId = @examId AND a.IsActive = 'Y' AND b.IsActive = 'Y'

  	   INSERT INTO [ExamCandidateAttempt] ([Token], [ExamId], [CandidateLoginId], [CandidateName], [CandidateEmailId], 
	     	[CandidatePhone], [AttemptDate], [CompleteAttempt], [StartTime], [EndTime], [TotalScore], [GainScore], [PercentageScore])
	    VALUES (@token, @examId, @candidateLoginId, @candidateName, @candidateEmailId, @candidatePhone, CAST(GETDATE() AS Date), 0, GETDATE(), NULL, @totalmarks, 0, 0)
	
		SET @examCandidateAttemptId = SCOPE_IDENTITY()

		-- Logic for picking random questions
		INSERT INTO @RandomQuestions(questionId, markValue, questionTypeId)
		SELECT a.QuestionId, a.MarkValue, a.QuestionTypeId FROM Question a 
				INNER JOIN ExamQuestion b ON a.QuestionId = b.QuestionId 
					Where ExamId = @examId AND a.IsActive = 'Y' AND b.IsActive = 'Y' ORDER BY newid() 
	
		WHILE(@totalmarks > 0 AND @totalQestions >= @counter)
		BEGIN

			SELECT  @questId = questionid, @markval = markValue, @questionTypeId = questionTypeId FROM @RandomQuestions WHERE sqno = @counter
			IF @totalmarks - @markval >= 0 
			BEGIN
				INSERT INTO ExamCandidateAttemptQuestions (ExamCandidateAttemptId, SeqNo, QuestionId)
					VALUES (@examCandidateAttemptId, @counter, @questId)
				
				SET @examCandidateAttemptQuestionsId = SCOPE_IDENTITY()

				IF(@questionTypeId <> 1)
				BEGIN
					INSERT INTO @RandomOptions(questionOptionsId)
						SELECT QuestionOptionsId FROM QuestionOptions WHERE QuestionId = @questId ORDER BY newid() 
				END
				ELSE 
				BEGIN
					INSERT INTO @RandomOptions(questionOptionsId)
						SELECT QuestionOptionsId FROM QuestionOptions WHERE QuestionId = @questId
				END
				INSERT INTO ExamCandidateAttemptQuestionAnswers (ExamCandidateAttemptQuestionsId, SlNo, QuestionOptionsId, IsSelected)
					SELECT @examCandidateAttemptQuestionsId, sqno, questionOptionsId, 'N' FROM @RandomOptions

				SET @totalmarks = @totalmarks - @markval
			END
		
			SET @counter = @counter + 1
		END
	END

	SELECT @examCandidateAttemptId AS UpdatedId, 'Success' AS 'Status'
END
