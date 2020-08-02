using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DHRM.BusinessEntity;

namespace DHRM.DataAccess.Context
{
    public class DocumentContext
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DHRM_COREEntities"].ConnectionString);
        public List<DocumentType> GetDocumenttype()
        {
            List<DocumentType> list = new List<DocumentType>();
            SqlCommand cmd = new SqlCommand();
            try
            {
                con.Open();
                cmd = new SqlCommand("sp_getDocumentType", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new DocumentType()
                    {
                        DocType_Code = dr["DocType_Code"].ToInt(),
                        DocType_Name = dr["DocType_Name"].ToStr(),
                        DocType_Scheme = dr["DocType_Scheme"].ToStr(),
                    });
                }
                con.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                con.Close();
                cmd.Dispose();
                throw;
            }

            return list;
        }
        public void SaveDocument(int DocCode, int DocType, string DocName, string FileTypes, string MaxFileSize, Boolean IsRequired)
        {

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_saveDocumentMaster";
                cmd.Parameters.Add(new SqlParameter("@DocCode", DocCode));
                cmd.Parameters.Add(new SqlParameter("@DocType", DocType));
                cmd.Parameters.Add(new SqlParameter("@DocName", DocName));
                cmd.Parameters.Add(new SqlParameter("@FileTypes", FileTypes));
                cmd.Parameters.Add(new SqlParameter("@MaxFileSize", MaxFileSize));
                cmd.Parameters.Add(new SqlParameter("@IsRequired", IsRequired));
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }

        }

        public DataTable GetDocumentMaster(int? DocCode)
        {
            DataTable dt = new DataTable();
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_getDocumentMasterById";
                cmd.Parameters.Add(new SqlParameter("@DocCode", DocCode));
                SqlDataAdapter adap = new SqlDataAdapter();
                adap.Fill(dt);
            }
            catch (Exception ex)
            {
            }
            return dt;
        }
    }
}
