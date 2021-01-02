using System;
using System.Collections.Generic;
using ExcelQuiz.Repository.Framework;
using ExcelQuiz.Repository.Procedures;
using ExcelQuiz.Data;
using ExcelQuiz.Utilities;

namespace ExcelQuiz.Repository.Dal
{
    public class LoginDal : Dal<LoginInfo>
    {
        protected override LoginInfo Construct(System.Data.IDataReader reader)
        {
            return new LoginInfo() { Token = reader.GetString("Token"), LoginStart = reader.GetDateTime("LoginStart"), LoginEnd = reader.GetDateTime("LoginEnd") };
        }

        protected override LoginInfo Construct(System.Data.DataRow row)
        {
            throw new NotImplementedException();
        }

        public LoginInfo AdminLogin(string userId, string password)
        {
            LoginInfo loginInfo = null;

            GetAdminToken getAdminToken = new GetAdminToken();
            getAdminToken.Prepare(new LoginParam { UserId = userId, Password = password }); ;
            loginInfo = this.FindOne(getAdminToken);

            return loginInfo;
        }

        public LoginInfo CandidateLogin(string userId, string password)
        {
            LoginInfo loginInfo = null;

            GetCandidateToken getCandidateToken = new GetCandidateToken();
            getCandidateToken.Prepare(new LoginParam { UserId = userId, Password = password }); ;
            loginInfo = this.FindOne(getCandidateToken);

            return loginInfo;
        }
    }
}
