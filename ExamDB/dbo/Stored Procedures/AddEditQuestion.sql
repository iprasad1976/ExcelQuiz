
-- This SP is used to Add or Edit question
CREATE   PROC [dbo].[AddEditQuestion](@questionId int, @questionTypeId int, @question nvarchar(1000), @noofOption int,
		@markValue int, @complexityLevelId int, @examIds varchar(1000), @options varchar(8000), @adminUserId nvarchar(20))
		--ExamIds like '1,2,4' and 
		--Operation A for Add, E for Edit, D for Delete

AS
BEGIN
DECLARE @Status VARCHAR(20) = 'Success'
BEGIN TRY
  BEGIN TRAN

  DECLARE @dt DateTime = GETDATE()
  DECLARE @optionTable Table (QuestionOptionId int, SlNo int, Options nvarchar(1000), IsCorrect char(1), Operation char(1)) 
  DECLARE @examIdsTable Table (ExamId int) 

  INSERT INTO @examIdsTable (ExamId)
	SELECT CAST(value AS INT) AS ExamId FROM string_split(@examIds, ',')

  DECLARE @xml Xml
  SELECT @xml = Cast(@options AS xml)

   INSERT INTO @optionTable (QuestionOptionId, SlNo, Options, IsCorrect, Operation)
      SELECT
      Options.value('(OptionId/text())[1]','INT') AS QuestionOptionId, 
      Options.value('(SlNo/text())[1]','INT') AS SlNo,
	  Options.value('(Text/text())[1]','VARCHAR(4000)') AS Options,
	  Options.value('(IsCorrect/text())[1]','BIT') AS IsCorrect,
	  Options.value('(Action/text())[1]','VARCHAR(1)') AS Operation
      FROM
      @xml.nodes('/Options/Option')AS TEMPTABLE(Options)

		
  --SELECT * FROM @optionTable

  IF @questionId = 0
  BEGIN
	INSERT INTO Question(QuestionTypeId, Question, NoOfOption, MarkValue, ComplexityLevelId, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, IsActive)
			VALUES (@questionTypeId, @question, @noofOption, @markValue, @complexityLevelId, @adminUserId, @dt, @adminUserId, @dt, 'Y')
	
	SET @questionId = SCOPE_IDENTITY()
	
	INSERT INTO ExamQuestion (ExamId, QuestionId, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, IsActive)
		SELECT ExamId, @questionId, @adminUserId, @dt, @adminUserId, @dt, 'Y' FROM @examIdsTable

	INSERT INTO QuestionOptions (QuestionId, SlNo, [Option], IsCorrect, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, IsActive)
		SELECT @questionId, SlNo, Options, IsCorrect, @adminUserId, @dt, @adminUserId, @dt, 'Y' FROM @optionTable 
  END
  ELSE
  BEGIN
		UPDATE Question SET Question = @question, QuestionTypeId = @questionTypeId, NoOfOption= @noofOption, MarkValue= @markValue, ComplexityLevelId= @complexityLevelId,
					ModifiedBy = @adminUserId, ModifiedDate = @dt WHERE IsActive = 'Y' AND QuestionId = @questionId

		UPDATE ExamQuestion SET ModifiedBy = @adminUserId, ModifiedDate = @dt, IsActive = 'N' 
				WHERE QuestionId = @questionId AND IsActive = 'Y' AND ExamId NOT IN (SELECT ExamId FROM @examIdsTable) 

		UPDATE ExamQuestion SET ModifiedBy = @adminUserId, ModifiedDate = @dt, IsActive = 'Y' 
				WHERE QuestionId = @questionId AND IsActive = 'Y' AND ExamId IN (SELECT ExamId FROM @examIdsTable) 

		INSERT INTO ExamQuestion (ExamId, QuestionId, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, IsActive)
				SELECT ExamId, @questionId, @adminUserId, @dt, @adminUserId, @dt, 'Y' FROM @examIdsTable 
						WHERE ExamId NOT IN (SELECT ExamId FROM ExamQuestion WHERE QuestionId = @questionId AND IsActive = 'Y')
	
		
		UPDATE a SET a.[Option] = b.Options, a.SlNo = b.SlNo, a.IsCorrect = b.IsCorrect, 
			a.ModifiedBy = @adminUserId, a.ModifiedDate = @dt, a.IsActive = 'Y' 
			FROM QuestionOptions a 
			INNER JOIN @optionTable b ON a.QuestionOptionsId = b.QuestionOptionId
			WHERE a.QuestionId = @questionId AND b.QuestionOptionId > 0 AND b.Operation = 'E'

		UPDATE a SET a.ModifiedBy = @adminUserId, a.ModifiedDate = @dt, a.IsActive = 'N' 
			FROM QuestionOptions a 
			INNER JOIN @optionTable b ON a.QuestionOptionsId = b.QuestionOptionId
			WHERE a.QuestionId = @questionId AND b.QuestionOptionId > 0 AND b.Operation = 'D'

		INSERT INTO QuestionOptions (QuestionId, SlNo, [Option], IsCorrect, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, IsActive)
			SELECT @questionId, SlNo, Options, IsCorrect, @adminUserId, @dt, @adminUserId, @dt, 'Y' FROM @optionTable WHERE Operation = 'A'
		
  END
  
	COMMIT
  END TRY
  BEGIN CATCH
	ROLLBACK
	SET @Status = 'Failed'
  END CATCH


  SELECT @questionId AS UpdatedId, @Status AS 'Status'

END