using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ExcelQuiz.Data;
using ExcelQuiz.Repository.Framework;
namespace ExcelQuiz.Repository.Procedures
{
    internal class GetCandidateToken : StoredProcedure, IStoredProcedure<LoginParam>
    {
        internal GetCandidateToken()
            : base()
        {
            _ProcedureName = "GetCandidateToken";
        }

        #region IStoredProcedure<int> Members

        public void Prepare(LoginParam data)
        {
            _Parameters.Add(new SqlParameter("@userId", SqlDbType.NVarChar, 20) { Value = data.UserId });
            _Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar, 20) { Value = data.Password });
        }

        #endregion

        protected override void IntializeParameters()
        {
            //Intialize oly out paramteres.
            _Parameters = new List<SqlParameter>();
        }
    }
}
