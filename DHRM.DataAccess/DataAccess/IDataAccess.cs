/*============================================================================
   Namespace        : DHRM.DataAccess
   Class            : ActivityContext
   Author           : Sartaj @ DEVAKI Technologies                             
   Desc             : IDataAccess related operations
   Revision History : 
   ----------------------------------------------------------------------------
 *  Author:            Date:          Description:
 * 
 * 
   ----------------------------------------------------------------------------
================================================================================*/
using System;
using System.Data;
using System.Data.Common;


namespace DHRM.DataAccess
{
    /// <summary>
    /// different Data reader states
    /// </summary>
    public enum DataReaderState { None, Open, Close };

    public interface IDataAccess : IDisposable
    {
        /// <summary>
        /// DB Connection Initialization
        /// </summary>
        void Initialize();

        /// <summary>
        /// Get DataReader 
        /// </summary>
        DbDataReader DataReader
        {
            get;
        }

        /// <summary>
        /// SqlConnection
        /// </summary>
        DbConnection Connection
        {
            get;
            set;
        }

        /// <summary>
        /// Get or Set Database Connection String
        /// </summary>
        string ConnectionString
        {
            get;
            set;
        }

        /// <summary>
        /// Get output and input SQL paramter collection
        /// </summary>
        CSqlDbParameterCollection Parameters
        {
            get;
        }

        /// <summary>
        /// Get DB Transaction
        /// </summary>
        DbTransaction Transaction
        {
            get;
        }

        /// <summary>
        /// different Command type
        /// </summary>
        CommandType CommandType
        {
            get;
            set;
        }

        /// <summary>
        /// Begin Sql Transaction
        /// </summary>
        void BeginTrans();


        /// <summary>
        /// Commit Transaction
        /// </summary>
        void Commit();

        /// <summary>
        /// Rollback Transaction
        /// </summary>
        void Rollback();


        /// <summary>
        /// Get or Set Command Timeout
        /// </summary>
        int CommandTimeout
        {
            get;
            set;
        }


        /// <summary>
        /// Fill command result set into dataSet variable
        /// </summary>
        /// <param name="dataSet">DataSet object</param>
        /// <param name="commandName">Stored Procedure Name</param>
        /// <param name="paramters">SQL parameter colelction</param>
        void FillData(DataSet dataSet, CSqlDbCommand command);

        /// <summary>
        /// Execute Scalar
        /// </summary>
        /// <param name="commandName">Stored Procedure Name</param>
        /// <param name="paramters">SQL parameter colelction</param>
        /// <returns></returns>
        object ExecScalar(CSqlDbCommand command);

        /// <summary>
        /// Execute SQL Stored Procedure
        /// </summary>
        /// <param name="commandName">Stored Procedure Name</param>
        /// <param name="paramters">SQL parameter colelction</param>
        /// <returns></returns>
        int ExecCommand(CSqlDbCommand command);


        /// <summary>
        /// Close the connection object associated with the data reader.
        /// </summary>
        void CloseDataReader();

        /// <summary>
        /// Execute Reader
        /// </summary>
        /// <param name="procName">Procedure Name</param>
        /// <param name="sqlParams">SqlParameterCollection
        /// use the GetInitCollection() method to init the SqlparameterCollection.
        /// Eg: SqlParameterCollection sqlParams = GetInitCollection();
        /// </param>
        /// <returns></returns>
        void ExecReader(CSqlDbCommand command);

        /// <summary>
        /// Validating DBNull values
        /// </summary>
        /// <param name="parameters"></param>
        void ConvertNullToDBNull(DbParameterCollection parameters);

        /// <summary>
        /// Validating DBNull Values
        /// </summary>
        /// <param name="sReaderValue"></param>
        /// <returns></returns>
        object GetNullOrObject(object sReaderValue);

        /// <summary>
        /// Creating Command object
        /// </summary>
        /// <param name="commandText"></param>
        /// <returns></returns>
        CSqlDbCommand CreateCommand(string commandText);
        /// <summary>
        /// Creating Command object
        /// </summary>
        /// <returns></returns>
        CSqlDbCommand CreateCommand(string commandText, CSqlDbParameterCollection collection);
        /// <summary>
        /// Creating Command object
        /// </summary>
        /// <returns></returns>
        CSqlDbCommand CreateCommand(string commandText, CommandType cmdType, CSqlDbParameterCollection collection);
    }
}
