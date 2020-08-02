/*============================================================================
   Namespace        : DHRM.DataAccess
   Class            : ActivityContext
   Author           : Sartaj @ DEVAKI Technologies                             
   Desc             : DbActivity related operations
   Revision History : 
   ----------------------------------------------------------------------------
 *  Author:            Date:          Description:
 * 
 * 
   ----------------------------------------------------------------------------
================================================================================*/
using System.Configuration;
using System.Data.SqlClient;

namespace DHRM.DataAccess
{
    public static class DbActivity
    {
        /// <summary>
        /// Delaring Connection string
        /// </summary>
        /// <returns></returns>
        public static string ConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["LIMSConnectionString"].ConnectionString;
        }

        /// <summary>
        /// Open the Data Acess Connection
        /// </summary>
        /// <returns></returns>
        public static IDataAccess Open()
        {
            string connectionString = DbActivity.ConnectionString();
            IDataAccess dao = new SqlDataAccess(connectionString);
            dao.Initialize();
            return dao;
        }
        
        /// <summary>
        /// Dispose the connection
        /// </summary>
        /// <param name="dao"></param>
        public static void Close(IDataAccess dao)
        {
            dao.Dispose();
        }

    }
}
