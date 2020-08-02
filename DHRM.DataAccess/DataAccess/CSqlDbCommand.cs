/*============================================================================
   Namespace        : DHRM.DataAccess
   Class            : CSqlDbCommand
   Author           : Sartaj @ DEVAKI Technologies                             
   Desc             : CSql DbCommand related operations
   Revision History : 
   ----------------------------------------------------------------------------
 *  Author:            Date:          Description:
 * 
 * 
   ----------------------------------------------------------------------------
================================================================================*/
using System.Collections.Generic;
using System.Data;

namespace DHRM.DataAccess
{
    public class CSqlDbCommand
    {
        #region Member Variables
        private CSqlDbParameterCollection _paramterCollection;
        #endregion

        #region Properties
        public string CommandText { get; set; }
        public CommandType CommandType { get; set; }
        public CommandReturnType CommandReturnType { get; set; }
        public int CommandTimeout { get; set; }
        public int ResultSetCount { get; set; }

        public CSqlDbParameterCollection Parameters
        {
            get { return _paramterCollection; }
            internal set
            {
                _paramterCollection = value;
            }
        }
        #endregion

        #region Sql Command Methods
        public virtual void AddWithValue(string paramterName, object value)
        {
            _paramterCollection.AddWithValue(paramterName, value);
        }


        public virtual void AddValuesRange(IDictionary<string, object> paramValuesDict)
        {
            foreach (var item in paramValuesDict)
            {
                _paramterCollection.AddWithValue(item.Key, item.Value);
            }
        }

        public CSqlDbCommand()
        {
            _paramterCollection = new CSqlDbParameterCollection();
        }
        public CSqlDbCommand(string commandText)
            : this()
        {
            this.CommandText = commandText;
        }
        public CSqlDbCommand(string commandText, CommandType cmdType)
            : this()
        {
            this.CommandText = commandText;
            this.CommandType = cmdType;
        }

        internal object ExecScalar(string p)
        {
            throw new System.NotImplementedException();
        }
        #endregion



    }
}
