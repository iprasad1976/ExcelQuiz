using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ExcelQuiz.Repository.Framework
{
    public enum ResultSetType
    {
        SingleRecordSet,
        MultipleRecordSet
    }

    public interface IStoredProcedure
    {
        string ProcedureName { get; }
        SqlParameter[] Parameters{get;}
        ResultSetType ResultSet { get; set; }
        void Prepare();
    }

    public interface IStoredProcedure<TParameter> : IStoredProcedure 
    {
        void Prepare(TParameter data);
    }

    public abstract class StoredProcedure : IStoredProcedure
    {
        protected string _ProcedureName;
        protected List<SqlParameter> _Parameters;

        public StoredProcedure()
        {
            IntializeParameters();
        }

        #region IStoredProcedure Members

        string IStoredProcedure.ProcedureName
        {
            get 
            { 
                return _ProcedureName ; 
            }
        }

        SqlParameter[] IStoredProcedure.Parameters
        {
            get 
            {
                if (_Parameters != null)
                {
                    return _Parameters.ToArray();
                }
                else
                {
                    return null;
                }
            }
        }

        #endregion

        protected abstract void IntializeParameters();

        protected SqlParameter CreateInParamter(string name, SqlDbType dataType, object value)
        {
            return new SqlParameter(name, dataType) { Value = value };
        }

        protected SqlParameter CreateInParamter(string name, object value)
        {
            return new SqlParameter(name, SqlDbType.Int) { Value = value };
        }

        // protected SqlParameter CreateOutParamter(string name, SqlDbType dataType)
        // {
            // return new SqlParameter(name, dataType, ParameterDirection.Output,);
        // }


        #region IStoredProcedure Members


        public void Prepare()
        {
           
        }

        protected SqlParameter GetByName(string name)
        {
            SqlParameter parameter = null;
            if (_Parameters != null)
            {
                parameter = _Parameters.Single<SqlParameter>(delegate(SqlParameter oraParameter) { return oraParameter.ParameterName == name; });
            }

            return parameter;
        }

        public ResultSetType ResultSet
        {
            get;
            set;
        }
        #endregion
    }
}

