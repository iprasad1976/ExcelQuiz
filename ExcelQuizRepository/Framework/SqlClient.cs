//===============================================================================
// Created By Hamendra-Capgemini.
// Date-05.01.2009
//===============================================================================
using System;
using System.Data;
using System.Xml;
using System.Collections;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace ExcelQuiz.Repository.Framework
{
    /// <summary>
    /// </summary>

    public class SqlClient
    {
        //IConfigurationRoot GetConfiguration()
        //{
        //    var builder = new ConfigurationBuilder().
        //}
        #region DataMember & Constructors
        
        private SqlConnection _connection;

        public SqlClient()
        {
            _connection = new SqlConnection(this.SqlConnectionString);
        }
       
        #endregion

        #region Properties
        /// <summary>
        /// Get or Set SqlConnectionString Property
        /// </summary>
        private string SqlConnectionString
        {
            get
            {
                try
                {
                    //Read Connection string from Web.Config and return
                    if (ConfigurationManager.ConnectionStrings["ExcelQuizDB"] != null)
                    {
                        return ConfigurationManager.ConnectionStrings["ASUDB"].ToString();
                    }
                    else
                    {
                        return @"Data Source=ETCBDSQL350;Initial Catalog=ASU;User ID=_asuser;Password=asuser";
                    }
                }
                catch (ConfigurationException)
                {
                    throw;
                }
            }
        }


        #endregion

        #region Internal methods

        internal DbCommand CreateCommand()
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;

            return new SqlCommand();
        }

        internal IDataReader ExecuteReader(DbCommand command, List<DbParameter> parameters)
        {
            try
            {
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters.ToArray());
                }

                command.Connection = this._connection;
                return command.ExecuteReader();


            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal IDataReader ExecuteReader(DbCommand command)
        {
            try
            {
               
                command.Connection = this._connection;
                return command.ExecuteReader();
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal void OpenConnection()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
                //Later replace with soap header
            }
        }

        internal void CloseConnection()
        {
            if (_connection.State != ConnectionState.Closed)
            {
                _connection.Close();
            }
        }

        internal int ExecuteNonQuery(DbCommand command)
        {
            command.Connection = this._connection;
            return command.ExecuteNonQuery();
        }

        internal void ExecuteNonQuery(DbCommand command, List<DbParameter> Parameters)
        {
            if (Parameters != null)
            {
                command.Parameters.AddRange(Parameters.ToArray());
            }
            command.Connection = this._connection;
            command.ExecuteNonQuery();
        }

        internal void ExecuteNonQuery(DbCommand command, List<DbParameter> Parameters, DbTransaction dbTransaction)
        {

            command.Transaction = dbTransaction;
            command.Connection = this._connection;
            ExecuteNonQuery(command, Parameters);
        }

        #endregion

        public  void ExecuteNonQuery(CommandType commandType, string procedureName, SqlParameter[] sqlParam)
        {
            DbCommand command = CreateCommand();
            command.CommandType = commandType;
            command.CommandText = procedureName;
            command.Parameters.AddRange(sqlParam);
            command.Connection = this._connection;
            this.OpenConnection();
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
        
                if (command != null)
                {
                    command.Dispose();  
                }
                this.CloseConnection();
                throw ex;
            }
  

        }

        public SqlCommand GetStoredProcCommand(string spName)
        {
            SqlCommand command = new SqlCommand(spName);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            return command;
        }

        internal IDataReader ExecuteReader(DbCommand command, SqlParameter[] SqlParameter)
        {
            try
            {
                if (SqlParameter != null)
                {
                    command.Parameters.AddRange(SqlParameter);
                }

                command.Connection = this._connection;
                return command.ExecuteReader();


            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataSet ExecuteDataset(IStoredProcedure dbProcedure)
        {
            throw new NotImplementedException();
        }
    }

}
