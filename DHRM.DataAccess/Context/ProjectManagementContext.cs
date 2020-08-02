using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using DHRM.BusinessEntity;
using static System.Net.Mime.MediaTypeNames;

namespace DHRM.DataAccess.Context
{
    public class ProjectManagementContext
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DHRM_COREEntities"].ConnectionString);

        public List<Project> GetAllProjects()
        {
            List<Project> list = new List<Project>();
            SqlCommand cmd = new SqlCommand();
            try
            {
                con.Open();
                cmd = new SqlCommand("select * from tblProject", con);
                cmd.CommandType = CommandType.Text;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //string imreBase64Data = Convert.ToBase64String(ObjectToByteArray(dr["project_banner"]));
                    //string imgDataURL = string.Format("data:image/png;base64,{0}", imreBase64Data);

                    var base64 = Convert.ToBase64String(ObjectToByteArray(dr["project_banner"]));
                    var imgsrc = string.Format("data:image/jpg;base64,{0}", base64);
                    list.Add(new Project()
                    {
                        project_name = dr["project_name"].ToString(),
                        project_description = dr["project_description"].ToString(),
                        ImagePath = imgsrc,
                        project_start_date = Convert.ToDateTime(dr["project_start_date"]),
                        project_end_date = Convert.ToDateTime(dr["project_end_date"]),
                        project_remarks = dr["project_remarks"].ToString()
                    });
                }
                con.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                con.Close();
                cmd.Dispose();
                throw ex;
            }
            return list;
        }

        public byte[] ObjectToByteArray(object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        public List<string> GetCompaniesList()
        {
            List<string> list = new List<string>();
            SqlCommand cmd = new SqlCommand();
            try
            {
                con.Open();
                cmd = new SqlCommand("select ID,CompanyName from [tblCompany]", con);
                cmd.CommandType = CommandType.Text;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(dr["CompanyName"].ToString());
                }
                con.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                con.Close();
                cmd.Dispose();
                throw ex;
            }
            return list;
        }

        public bool SaveProject(Project project)
        {
            bool result = false;
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DHRM_COREEntities"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("insert into [tblProject](project_code,client_id,project_name,project_description,project_banner,project_start_date,project_end_date) values(@projectcode,@clientID,@projectName,@projectDescription,@projectBanner,@projectStartDate,@projectEndDate);", con);
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@projectcode", SqlDbType.NVarChar).Value = project.project_code;
                    cmd.Parameters.Add("@clientID", SqlDbType.NVarChar).Value = project.client_id;
                    cmd.Parameters.Add("@projectName", SqlDbType.NVarChar).Value = project.project_name;
                    cmd.Parameters.Add("@projectDescription", SqlDbType.NVarChar).Value = project.project_description;
                    cmd.Parameters.Add("@projectBanner", SqlDbType.Binary).Value = project.project_banner;
                    cmd.Parameters.Add("@projectStartDate", SqlDbType.Date).Value = project.project_start_date;
                    cmd.Parameters.Add("@projectEndDate", SqlDbType.Date).Value = project.project_end_date;

                    cmd.ExecuteNonQuery();
                    result = true;
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }
    }
}
