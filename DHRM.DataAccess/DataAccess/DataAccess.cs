/*============================================================================
   Namespace        : DHRM.DataAccess
   Class            : ActivityContext
   Author           : Sartaj @ DEVAKI Technologies                             
   Desc             : DataAccess related operations
   Revision History : 
   ----------------------------------------------------------------------------
 *  Author:            Date:          Description:
 * 
 * 
   ----------------------------------------------------------------------------
================================================================================*/
using System;
using System.Linq;
using System.Data.Common;
using System.Data;

namespace DHRM.DataAccess
{
    public abstract class DataAccess : IDataAccess, IDisposable
    {

        #region Properties

        public string DbParameterPrefix
        {
            get;
            set;
        }

        public virtual CSqlDbParameterCollection Parameters
        {
            get;
            protected set;
        }

        /// <summary>
        /// must be return null, if there's no transaction
        /// </summary>
        public abstract DbTransaction Transaction
        {
            get;
        }

        public abstract DbDataReader DataReader
        {
            get;
        }

        public int CommandTimeout
        {
            get;
            set;
        }

        public System.Data.CommandType CommandType
        {
            get;
            set;
        }

        public abstract DbConnection Connection
        {
            get;
            set;
        }

        public abstract string ConnectionString
        {
            get;
            set;
        }

        #endregion

        #region Methods

        #region Abstract Methods
        /// <summary>
        /// Initializing the Connection
        /// </summary>
        public abstract void Initialize();

        /// <summary>
        /// This call the underlying ExecuteReader and also it close the data reader.
        /// Since 3.5.1.7
        /// </summary>
        /// <param name="dbCommand"></param>
        public abstract void ExecReader(CSqlDbCommand dbCommand);

        /// <summary>
        /// This call the underlying ExecuteReader and also it close the data reader.
        /// Since 3.5.1.7
        /// </summary>
        /// <param name="dbCommand"></param>
        /// <param name="reader"></param>
        public void ExecReader(CSqlDbCommand dbCommand, Action<IDataReader> reader)
        {
            this.ExecReader(dbCommand);
            reader(this.DataReader);
            this.CloseDataReader();
        }

        /// <summary>
        /// Close Data Reader
        /// </summary>
        public abstract void CloseDataReader();

        /// <summary>
        /// Transaction Beginning
        /// </summary>
        public abstract void BeginTrans();

        /// <summary>
        /// Commit the transaction changes
        /// </summary>
        public abstract void Commit();

        /// <summary>
        /// Rollback the changes
        /// </summary>
        public abstract void Rollback();

        /// <summary>
        /// Fill Data into dataset
        /// </summary>
        /// <param name="dataSet"></param>
        /// <param name="command"></param>
        public abstract void FillData(System.Data.DataSet dataSet, CSqlDbCommand command);

        /// <summary>
        /// SQL ExecuteScalar 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public abstract object ExecScalar(CSqlDbCommand command);

        /// <summary>
        /// SQL Execute Command
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public abstract int ExecCommand(CSqlDbCommand command);

        /// <summary>
        /// Dipose the connection
        /// </summary>
        public abstract void Dispose(); 
        #endregion

        /// <summary>
        /// Checking the Null values if value is not there returning null values
        /// </summary>
        /// <param name="parameters"></param>
        public void ConvertNullToDBNull(DbParameterCollection parameters)
        {
            foreach (DbParameter param in parameters)
            {
                if (param.Value == null)
                    param.Value = DBNull.Value;
            }
        }

        /// <summary>
        /// Validating value
        /// </summary>
        /// <param name="sReaderValue"></param>
        /// <returns></returns>
        public object GetNullOrObject(object sReaderValue)
        {
            if (sReaderValue == DBNull.Value)
                return null;
            else
                return sReaderValue;
        }

        /// <summary>
        /// Fetch Output parameter values
        /// </summary>
        /// <param name="collection">DbParameterCollection</param>
        /// <param name="parameterPrefixText">parameter prefix Text</param>
        protected void GetOutputParamterValues(DbParameterCollection collection, string parameterPrefixText)
        {
            var dbparams = from DbParameter d in collection
                           where d.Direction == ParameterDirection.Output ||
                                 d.Direction == ParameterDirection.InputOutput
                           select new { ParamName = d.ParameterName, Value = d.Value };

            foreach (var param in dbparams)
            {
                Parameters.AddWithValue(param.ParamName.Substring(parameterPrefixText.Length), param.Value);
            }

        }

        /// <summary>
        /// Fetch Output Parameter values include input values
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="parameterPrefixText"></param>
        protected virtual void GetOutputParamterValuesIncludeInput(DbParameterCollection collection, string parameterPrefixText)
        {
            Parameters.Clear();
            foreach (DbParameter param in collection)
            {
                if (param.Direction == ParameterDirection.Output || param.Direction == ParameterDirection.InputOutput)
                {
                    Parameters.AddWithValue(param.ParameterName.Substring(parameterPrefixText.Length), param.Value);
                }
            }
        }

        /// <summary>
        ///  Release all allocated resources
        /// </summary>
        ~DataAccess()
        {
            try
            {
                this.Dispose();
            }
            catch { }
        }

        /// <summary>
        /// Create Sql Command
        /// </summary>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public CSqlDbCommand CreateCommand(string commandText)
        {
            var cmd = new CSqlDbCommand(commandText);
            Parameters = cmd.Parameters;
            return cmd;
        }

        /// <summary>
        /// Create Sql Command
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        public CSqlDbCommand CreateCommand(string commandText, CSqlDbParameterCollection collection)
        {
            var cmd = new CSqlDbCommand(commandText);
            cmd.Parameters = collection;
            Parameters = cmd.Parameters;
            return cmd;
        }

        /// <summary>
        /// /Create Sql Command
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="cmdType"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        public CSqlDbCommand CreateCommand(string commandText, CommandType cmdType, CSqlDbParameterCollection collection)
        {
            var cmd = new CSqlDbCommand(commandText, cmdType);
            cmd.Parameters = collection;
            Parameters = cmd.Parameters;
            return cmd;
        }

        #endregion




    }
}
