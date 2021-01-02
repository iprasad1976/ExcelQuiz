using System.Data.Common;
using System.Data;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Collections.ObjectModel;

namespace ExcelQuiz.Repository.Framework
{
    public abstract class Dal<TDataContract> 
        where TDataContract : class
    {
        protected DbTransaction _transaction;

        /// <summary>
        /// Current running transaction
        /// </summary>
        /// <remarks></remarks>
        public DbTransaction ActiveTransaction
        {
            get { return _transaction; }
            set { _transaction = value; }
        }

        /// <summary>
        /// Core data access class.
        /// </summary>
        private SqlClient _db;

        public Dal()
        {
            _db = new SqlClient();
        }

        public Dal(DbTransaction currentTransaction)
        {
            _transaction = currentTransaction;
        }

        /// <summary>
        /// Common fuction where all the excption will get the first level treatment,
        /// like , logging anf trnslating.
        /// </summary>
        /// <param name="ex"></param>
        /// <remarks></remarks>
        protected void HandleDbException(Exception ex)
        {
            throw ex;
        }

        /// <summary>
        /// Converts a record to object.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        protected abstract TDataContract Construct(IDataReader reader);

        /// <summary>
        /// Converts a record to object.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        protected abstract TDataContract Construct(DataRow row);

        /// <summary>
        /// Executes the procedure and returns a singe rcords
        /// </summary>
        /// <param name="ProcedureName">Stored procedure name to execute</param>
        /// <param name="parameters">List of parameter</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public TDataContract FindOne(IStoredProcedure sp)
        {
            TDataContract result = null;

            using (DbCommand command = this._db.GetStoredProcCommand(sp.ProcedureName))
            {
                try
                {
                    this._db.OpenConnection();
                    if (sp.ResultSet == ResultSetType.SingleRecordSet)
                    {
                        using (IDataReader rdr = _db.ExecuteReader(command, sp.Parameters))
                        {
                            if (rdr.Read())
                            {
                                result = this.Construct(rdr);
                            }
                        }
                    }
                    else
                    {
                        DataSet resultSet = _db.ExecuteDataset(sp);

                        if (resultSet != null && resultSet.Tables.Count > 0)
                        {
                            result = Construct(resultSet.Tables[0].Rows[0]);
                            resultSet.Dispose();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex; // HandleDbException(ex);
                }
                finally
                {
                    this._db.CloseConnection();
                }
            }

            return result;
        }

        /// <summary>
        /// Executes the procedure and returns a multiple rcords
        /// </summary>
        /// <param name="ProcedureName">Stored procedure name to execute</param>
        /// <param name="parameters">List of parameter</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public List<TDataContract> Find(IStoredProcedure sp)
        {
            List<TDataContract> result = new List<TDataContract>();

            using (DbCommand command = this._db.GetStoredProcCommand(sp.ProcedureName))
            {
                try
                {
                    this._db.OpenConnection();

                    if (sp.ResultSet == ResultSetType.SingleRecordSet)
                    {
                        using (IDataReader rdr = _db.ExecuteReader(command, sp.Parameters))
                        {
                            while (rdr.Read())
                            {
                                result.Add(Construct(rdr));
                            }
                        }
                    }
                    else
                    {
                        DataSet resultSet = _db.ExecuteDataset(sp);

                        if (resultSet != null && resultSet.Tables.Count > 0)
                        {
                            result = (from DataRow row in resultSet.Tables[0].Rows
                                     select Construct(row)).ToList<TDataContract>()   ;
                            resultSet.Dispose();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;

                    // HandleDbException(ex);
                    //TODO:Log exception

                }
                finally
                {
                    this._db.CloseConnection();
                }
            }

            return result;
        }
        /// <summary>
        /// Executes the stored procedure and return the out param value as int.
        /// </summary>
        /// <param name="ProcedureName">Name of the procedure to execute</param>
        /// <param name="Parameters">Parameres to be passed for execution.</param>
        /// <param name="OutParamName">Return parameter</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public int Execute(string ProcedureName, List<DbParameter> Parameters, string OutParamName)
        {
            using (DbCommand command = this._db.CreateCommand())
            {
                command.CommandText = ProcedureName;

                try
                {
                    _db.OpenConnection();

                    if ((_transaction == null))
                    {
                        _db.ExecuteNonQuery(command, Parameters);
                    }
                    else
                    {
                        _db.ExecuteNonQuery(command, Parameters, this._transaction);
                    }
                }
                catch (System.Exception)
                {

                    //_db.CloseConnection();
                }
                finally
                {
                    _db.CloseConnection();
                }

                if (OutParamName != string.Empty)
                {
                    return (int)command.Parameters[OutParamName].Value;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Same as above but no retuen parameter value
        /// </summary>
        /// <param name="ProcedureName"></param>
        /// <param name="Parameters"></param>
        /// <remarks></remarks>
        public void Execute(string ProcedureName, List<DbParameter> Parameters)
        {
            Execute(ProcedureName, Parameters, string.Empty);
        }

        /// <summary>
        /// Same as above but no retuen parameter value
        /// </summary>
        /// <param name="ProcedureName"></param>
        /// <param name="Parameters"></param>
        /// <remarks></remarks>
        public int Execute(IStoredProcedure procedure)
        {
            int status = -1;

            using (DbCommand command = this._db.GetStoredProcCommand(procedure.ProcedureName ))
            {
                try
                {
                    _db.OpenConnection();
                    command.Parameters.AddRange(procedure.Parameters);

                    if (_transaction == null)
                        status = _db.ExecuteNonQuery(command);
                    else
                    {
                        command.Transaction = this._transaction;
                        status = _db.ExecuteNonQuery(command);
                    }
                }
                catch (System.Exception ex)
                {
                    string error = ex.Message;
                }
                finally
                {
                    _db.CloseConnection();
                }
            }

            return status;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public System.Data.Common.DbTransaction StartTransaction()
        {
            //DbConnection dbCon = db.OpenConnection();
            //_transaction = dbCon.BeginTransaction();
            return _transaction;
        }

        /// <summary>
        /// Commits transaction
        /// </summary>
        public void CommitTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Commit();
                _transaction.Dispose();
                _transaction = null;
            }
        }

        /// <summary>
        /// Commits transaction
        /// </summary>
        /// <param name="transaction"></param>
        /// <remarks></remarks>
        public void RollsTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
                _transaction.Dispose();
                _transaction = null;
            }
        }
    }
}

