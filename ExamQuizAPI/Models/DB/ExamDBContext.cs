using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ExamQuizAPI.Models.DB
{
    public partial class ExamDBContext : DbContext
    {
        public ExamDBContext()
        {
        }

        public ExamDBContext(DbContextOptions<ExamDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminLogin> AdminLogins { get; set; }
        public virtual DbSet<AdminLoginToken> AdminLoginTokens { get; set; }
        public virtual DbSet<CandidateLogin> CandidateLogins { get; set; }
        public virtual DbSet<CandidateLoginRequest> CandidateLoginRequests { get; set; }
        public virtual DbSet<CandidateLoginToken> CandidateLoginTokens { get; set; }
        public virtual DbSet<ComplexityLevel> ComplexityLevels { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<ExamCandidate> ExamCandidates { get; set; }
        public virtual DbSet<ExamCandidateAttempt> ExamCandidateAttempts { get; set; }
        public virtual DbSet<ExamCandidateAttemptQuestion> ExamCandidateAttemptQuestions { get; set; }
        public virtual DbSet<ExamCandidateAttemptQuestionAnswer> ExamCandidateAttemptQuestionAnswers { get; set; }
        public virtual DbSet<ExamQuestion> ExamQuestions { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<QuestionOption> QuestionOptions { get; set; }
        public virtual DbSet<QuestionType> QuestionTypes { get; set; }

        public virtual DbSet<SpGetToken> GetToken { get; set; }
        public virtual DbSet<SpListExam> GetExamList { get; set; }
        public virtual DbSet<SpCandidateExamInfo> GetCandidateExamInformation { get; set; }
        public virtual DbSet<SpNextPrevQuestion> GetNextPrevQues { get; set; }
        public virtual DbSet<SpQuestionOptions> GetQuesOptions { get; set; }
        public virtual DbSet<SpCalculateMarks> CalMarks { get; set; }
        public virtual DbSet<SpAddCadidateLogins> AddCandidateLogins { get; set; }
        public virtual DbSet<SpDownloadCadidateLoginIds> DownloadCadidateLoginId { get; set; }
        public virtual DbSet<SpSearchRequests> SearchRequest { get; set; }
        public virtual DbSet<SpSearchRequests> ListRequestsByRequestedEmail { get; set; }
        public virtual DbSet<SpGetExam> GetExamDetails { get; set; }
        public virtual DbSet<SpSearchExams> SearchExamsDtl { get; set; }
        public virtual DbSet<SpGetQuestion> GetQuestionDtl { get; set; }
        public virtual DbSet<SpGetQuestionOptions> GetQuestionOptionsDtl { get; set; }
        public virtual DbSet<SpSearchQuestions> SearchQuestion { get; set; }
        public virtual DbSet<SpUpdateCommand> UpdatedRows { get; set; }
        public virtual DbSet<SpGetQuestionExam> QuestionExams { get; set; }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=ExamDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AdminLogin>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("AdminLogin");

                entity.Property(e => e.AdminLoginId).ValueGeneratedOnAdd();

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<AdminLoginToken>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("AdminLoginToken");

                entity.Property(e => e.AdminLoginTokenId).ValueGeneratedOnAdd();

                entity.Property(e => e.LoginEndTime).HasColumnType("datetime");

                entity.Property(e => e.LoginStartTime).HasColumnType("datetime");

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CandidateLogin>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CandidateLogin");

                entity.Property(e => e.CandidateLoginId).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ValidFrom).HasColumnType("date");

                entity.Property(e => e.ValidTo).HasColumnType("date");
            });

            modelBuilder.Entity<CandidateLoginRequest>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CandidateLoginRequest");

                entity.Property(e => e.CandidateLoginRequestId).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RequestDate).HasColumnType("datetime");

                entity.Property(e => e.RequestId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.RequestedPersonEmail)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<CandidateLoginToken>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CandidateLoginToken");

                entity.Property(e => e.CandidateLoginTokenId).ValueGeneratedOnAdd();

                entity.Property(e => e.LoginEndTime).HasColumnType("datetime");

                entity.Property(e => e.LoginStartTime).HasColumnType("datetime");

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ComplexityLevel>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ComplexityLevel");

                entity.Property(e => e.ComplexityLevel1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("ComplexityLevel");
            });

            modelBuilder.Entity<Exam>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Exam");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ExamId).ValueGeneratedOnAdd();

                entity.Property(e => e.ExamName)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.Instructions)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ExamCandidate>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ExamCandidate");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ExamCandidateId).ValueGeneratedOnAdd();

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ExamCandidateAttempt>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ExamCandidateAttempt");

                entity.Property(e => e.AttemptDate).HasColumnType("date");

                entity.Property(e => e.CandidateEmailId).HasMaxLength(250);

                entity.Property(e => e.CandidateName).HasMaxLength(100);

                entity.Property(e => e.CandidatePhone).HasMaxLength(12);

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.ExamCandidateAttemptId).ValueGeneratedOnAdd();

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExamCandidateAttemptQuestion>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AttemptTime).HasColumnType("datetime");

                entity.Property(e => e.ExamCandidateAttemptQuestionsId).ValueGeneratedOnAdd();

                entity.Property(e => e.IsAnswerCorrect)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<ExamCandidateAttemptQuestionAnswer>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ExamCandidateAttemptQuestionAnswersId).ValueGeneratedOnAdd();

                entity.Property(e => e.IsSelected)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<ExamQuestion>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ExamQuestion");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ExamQuestionId).ValueGeneratedOnAdd();

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Question");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Question1)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasColumnName("Question");

                entity.Property(e => e.QuestionId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<QuestionOption>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Option)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.QuestionOptionsId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<QuestionType>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("QuestionType");

                entity.Property(e => e.QuestionTypeDesc)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("QuestionTypeDesc");
            });

            //modelBuilder.Entity<SpGetAdminToken>();
            OnModelCreatingPartial(modelBuilder);
            
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public async Task<List<SpGetToken>> GetAdminToken(string userId, string password)
        {
            SpGetToken result = new SpGetToken();

            try
            {
               return await this.GetToken.FromSqlInterpolated<SpGetToken>($"Execute GetAdminToken {userId}, {password}").ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
      
        }

        public async Task<List<SpGetToken>> GetCandidateToken(string userId, string password)
        {
            SpGetToken result = new SpGetToken();

            try
            {
                return await this.GetToken.FromSqlInterpolated<SpGetToken>($"Execute GetCandidateToken {userId}, {password}").ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<List<SpListExam>> GetListExam(string userId)
        {
            SpGetToken result = new SpGetToken();

            try
            {
                return await this.GetExamList.FromSqlInterpolated<SpListExam>($"Execute GetListExam {userId}").ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<List<SpCandidateExamInfo>> GetCandidateExamInfo(int examId, string userId)
        {
            SpGetToken result = new SpGetToken();

            try
            {
                return await this.GetCandidateExamInformation.FromSqlInterpolated<SpCandidateExamInfo>($"Execute GetCandidateExamInfo {examId}, {userId}").ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<List<SpNextPrevQuestion>> GetNextPrevQuestion(int examId, string userId, string token, int seqNo)
        {
            SpGetToken result = new SpGetToken();

            try
            {
                return await this.GetNextPrevQues.FromSqlInterpolated<SpNextPrevQuestion>($"Execute GetNextPrevQuestion {examId}, {userId}, {token}, {seqNo}").ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<List<SpQuestionOptions>> GetQuestionOptions(int examId, string userId, string token, int seqNo)
        {
            SpGetToken result = new SpGetToken();

            try
            {
                return await this.GetQuesOptions.FromSqlInterpolated<SpQuestionOptions>($"Execute GetQuestionOptions {examId}, {userId}, {token}, {seqNo}").ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<List<SpCalculateMarks>> CalculateMarks(int examId, string userId, string token)
        {
            SpGetToken result = new SpGetToken();

            try
            {
                return await this.CalMarks.FromSqlInterpolated<SpCalculateMarks>($"Execute CalculateMarks {examId}, {userId}, {token}").ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<List<SpAddCadidateLogins>> AddCadidateLogins(string requestedPersonEmail, int noOfRequestedUserId, int noOfAttempt, string examIds, DateTime validFrom, DateTime validTo, string adminUserId)
        {
            SpGetToken result = new SpGetToken();

            try
            {
                return await this.AddCandidateLogins.FromSqlInterpolated<SpAddCadidateLogins>($"Execute AddCadidateLogins {requestedPersonEmail}, {noOfRequestedUserId}, {noOfAttempt}, {examIds}, {validFrom},{validTo}, {adminUserId}").ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<SpDownloadCadidateLoginIds>> DownloadCadidateLoginIds(int candidateLoginRequestId)
        {
            SpGetToken result = new SpGetToken();

            try
            {
                return await this.DownloadCadidateLoginId.FromSqlInterpolated<SpDownloadCadidateLoginIds>($"Execute DownloadCadidateLoginIds {candidateLoginRequestId}").ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<SpSearchRequests>> SearchRequests(string search)
        {
            SpGetToken result = new SpGetToken();

            try
            {
                return await this.SearchRequest.FromSqlInterpolated<SpSearchRequests>($"Execute SearchRequests {search}").ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<SpSearchRequests>> GetListRequestsByRequestedEmail(string requestedPersonEmail)
        {
            SpGetToken result = new SpGetToken();

            try
            {
                return await this.ListRequestsByRequestedEmail.FromSqlInterpolated<SpSearchRequests>($"Execute GetListRequestsByRequestedEmail {requestedPersonEmail}").ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<SpGetExam>> GetExam(int examId)
        {
            SpGetToken result = new SpGetToken();

            try
            {
                return await this.GetExamDetails.FromSqlInterpolated<SpGetExam>($"Execute GetExam {examId}").ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<SpSearchExams>> SearchExams(string search)
        {
            SpGetToken result = new SpGetToken();

            try
            {
                return await this.SearchExamsDtl.FromSqlInterpolated<SpSearchExams>($"Execute SearchExams {search}").ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<SpGetQuestion>> GetQuestion(int questionId)
        {
            SpGetToken result = new SpGetToken();

            try
            {
                return await this.GetQuestionDtl.FromSqlInterpolated<SpGetQuestion>($"Execute GetQuestion {questionId}").ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<QuestionType>> GetQuestionTypes()
        {
            SpGetToken result = new SpGetToken();

            try
            {
                return await this.QuestionTypes.FromSqlInterpolated<QuestionType>($"Execute GetQuestionTypes").ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<SpGetQuestionOptions>> GetQuestionOptions(int questionId)
        {
            SpGetToken result = new SpGetToken();

            try
            {
                return await this.GetQuestionOptionsDtl.FromSqlInterpolated<SpGetQuestionOptions>($"Execute GetQuestionOptions {questionId}").ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<SpSearchQuestions>> SearchQuestions(int examId, string search)
        {
            SpGetToken result = new SpGetToken();

            try
            {
                return await this.SearchQuestion.FromSqlInterpolated<SpSearchQuestions>($"Execute SearchQuestions {examId}, {search}").ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<SpUpdateCommand>> SubmitAnswers(int examId, string userId, string token, int seqNo, string selectedOptionIds)
        {
            SpGetToken result = new SpGetToken();

            try
            {
                return await this.UpdatedRows.FromSqlInterpolated<SpUpdateCommand>($"Execute SubmitAnswers {examId}, {userId}, {token}, {seqNo}, {selectedOptionIds}").ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<SpUpdateCommand>> DeleteRequestedLogin(int candidateLoginRequestId, string adminUserId)
        {
            SpGetToken result = new SpGetToken();

            try
            {
                return await this.UpdatedRows.FromSqlInterpolated<SpUpdateCommand>($"Execute DeleteRequestedLogin {candidateLoginRequestId},{adminUserId}").ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<SpUpdateCommand>> AddEditExam(int examId, string examName, int totalMarks, int passingPercentage, string instructions, int duration, string adminUserId)
        {
            SpGetToken result = new SpGetToken();

            try
            {
                return await this.UpdatedRows.FromSqlInterpolated<SpUpdateCommand>($"Execute AddEditExam {examId}, {examName}, {totalMarks}, {passingPercentage}, {instructions}, {duration}, {adminUserId}").ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<SpUpdateCommand>> DeleteExam(int examId, string adminUserId)
        {
            SpGetToken result = new SpGetToken();

            try
            {
                return await this.UpdatedRows.FromSqlInterpolated<SpUpdateCommand>($"Execute DeleteExam {examId}, {adminUserId}").ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<SpUpdateCommand>> AddEditQuestion(int questionId, int questionTypeId, string question, int noofOption, string examIds, string options, string adminUserId)
        {
            SpGetToken result = new SpGetToken();

            try
            {
                return await this.UpdatedRows.FromSqlInterpolated<SpUpdateCommand>($"Execute AddEditQuestion {questionId}, {questionTypeId}, {question}, {noofOption}, {examIds}, {options}, {adminUserId}").ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<SpGetQuestionExam>> GetQuestionExams(int questionId)
        {
            SpGetToken result = new SpGetToken();

            try
            {
                return await this.QuestionExams.FromSqlInterpolated<SpGetQuestionExam>($"Execute GetQuestionExams {questionId}").ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<SpUpdateCommand>> DeleteQuestion(int questionId, string adminUserId)
        {
            SpGetToken result = new SpGetToken();

            try
            {
                return await this.UpdatedRows.FromSqlInterpolated<SpUpdateCommand>($"Execute DeleteQuestion {questionId}, {adminUserId}").ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<SpUpdateCommand>> CandidateExamStart(int examId, string userId, string token, string candidateName, string candidateEmailId, string candidatePhone)
        {
            SpGetToken result = new SpGetToken();

            try
            {
                return await this.UpdatedRows.FromSqlInterpolated<SpUpdateCommand>($"Execute CandidateExamStart {examId}, {userId}, {token}, {candidateName}, {candidateEmailId}, {candidatePhone}").ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
