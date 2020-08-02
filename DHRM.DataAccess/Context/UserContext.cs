using System.Linq;
using DHRM.BusinessEntity;
using AutoMapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;

namespace DHRM.DataAccess
{

    public class UserContext
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DHRM_COREEntities"].ConnectionString);

        public int SaveCompanyDetails(CompanyRegisterEntity CE)
        {
            SqlCommand cmd = null;
            int CompanyID = 0;
            try
            {
                con.Open();
                cmd = new SqlCommand("SP_SaveCompanyDetails", con);
                cmd.Parameters.AddWithValue("CompanyType", CE.CompanyType);
                cmd.Parameters.AddWithValue("CompanyName", CE.CompanyName);
                cmd.Parameters.AddWithValue("LogoName", CE.LogoName);
                cmd.Parameters.AddWithValue("StreetAddress1", CE.StreetAddress1);
                cmd.Parameters.AddWithValue("StreetAddress2", CE.StreetAddress2);
                cmd.Parameters.AddWithValue("City", CE.City);
                cmd.Parameters.AddWithValue("StateName", CE.StateName);
                cmd.Parameters.AddWithValue("CountryName", CE.CountryName);
                cmd.Parameters.AddWithValue("ZipCode", CE.ZipCode);
                cmd.Parameters.AddWithValue("ContactPerson", CE.ContactPerson);
                cmd.Parameters.AddWithValue("ContactPhone", CE.ContactPhone);
                cmd.Parameters.AddWithValue("ContactEmail", CE.ContactEmail);
                cmd.Parameters.AddWithValue("Logo", CE.Logo);
                cmd.CommandType = CommandType.StoredProcedure;
                CompanyID = cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                con.Close();
                cmd.Dispose();
                throw ex;
            }
            return CompanyID;
        }
        public List<CompanyRegisterEntity> GetCompanyList()
        {
            List<CompanyRegisterEntity> list = new List<CompanyRegisterEntity>();
            SqlCommand cmd = null;
            try
            {
                con.Open();
                cmd = new SqlCommand("USP_COMPANYLIST_CRUD", con);
                cmd.Parameters.AddWithValue("Action", "L");
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new CompanyRegisterEntity()
                    {
                        ID = dr["ID"].ToInt(),
                        CompanyName = dr["CompanyName"].ToStr(),
                        ContactEmail = dr["ContactEmail"].ToStr(),
                        City = dr["City"].ToStr(),
                        LogoName = dr["CompanyLogo"].ToStr(),
                        ContactPerson = dr["ContactPerson"].ToStr(),
                        ContactPhone = dr["ContactPhone"].ToStr(),
                        CountryID = dr["CountryID"].ToInt(),
                        CountryName = dr["CountryName"].ToStr(),
                        StateID = dr["StateID"].ToInt(),
                        StateName = dr["StateName"].ToStr(),
                        StreetAddress1 = dr["StreetAddress1"].ToStr(),
                        StreetAddress2 = dr["StreetAddress2"].ToStr(),
                        ZipCode = dr["ZipCode"].ToStr()
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

        //public bool ValidUser(string username, string password)
        //{
        //    bool result = false;
        //    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DHRM_COREEntities"].ConnectionString);
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = "select case when exists (select * from Membership  where MEM_UserName = 'admin' and MEM_Password = 'admin') then 1 else 0 end";
        //    cmd.CommandType = System.Data.CommandType.Text;
        //    cmd.Connection = con;
        //    SqlDataReader reader = cmd.ExecuteReader();
        //    while (reader.Read())
        //    {
        //    }

        //    return result;
        //}

        public UserInfoEntity GetUserInfo(string username, string password)
        {
            UserInfoEntity entity = new UserInfoEntity();
            SqlCommand cmd = null;
            try
            {
                con.Open();
                cmd = new SqlCommand("USP_GETUSERINFO", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60 * 60 * 10;
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Connection = con;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    entity.MEM_UserName = reader["MEM_UserName"].ToString();
                    entity.MEM_Password = reader["MEM_Password"].ToString();
                    entity.MEM_Email = reader["MEM_Email"].ToString();
                    entity.RoleName = reader["RoleName"].ToString();
                    entity.MEM_IsActive = reader["MEM_IsActive"].ToBoolean();
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
            return entity;
        }
        public List<DocumentType> GetCompanyType()
        {
            List<DocumentType> list = new List<DocumentType>();
            SqlCommand cmd = null;
            try
            {
                con.Open();
                cmd = new SqlCommand("select DT.DocType_Name,DT.DocType_Code   from tblDocumentType DT where DT.DocType_Scheme='Company Registration'", con);
                cmd.CommandType = CommandType.Text;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new DocumentType()
                    {
                        DocType_Code = dr["DocType_Code"].ToInt(),
                        DocType_Name = dr["DocType_Name"].ToStr(),

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
        public List<DocumentInfoEntity> GetDocumentTemp(int DocType)
        {
            List<DocumentInfoEntity> list = new List<DocumentInfoEntity>();
            SqlCommand cmd = null;
            try
            {
                con.Open();
                cmd = new SqlCommand("select DM.DocName,DM.DocCode,DM.DocType ,DM.MaxFileSize,DM.IsRequired,DM.FileTypes from tblDocumentType DT " +
                    "Inner join tblDocumentMaster  DM on DM.DocType=DT.DocType_Code " +
                    "where DT.DocType_Scheme='Company Registration' and DM.DocType=" + DocType + "", con);
                cmd.CommandType = CommandType.Text;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new DocumentInfoEntity()
                    {
                        DocName = dr["DocName"].ToStr(),
                        DocCode = dr["DocCode"].ToInt(),
                        DocType = dr["DocType"].ToInt(),
                        MaxFileSize = dr["MaxFileSize"].ToInt(),
                        IsRequired = dr["IsRequired"].ToBoolean(),
                        FileType = dr["FileTypes"].ToStr(),
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


        //public SearchResultCriteria<UserInfo> GetList(SearchResultCriteria<UserInfo> criteria)
        //{
        //    var searchObject = criteria.InputObject as UserInfoEntity;
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = "VW_GetUserInfo";
        //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //    cmd.Connection = con;
        //    var query = VW_GetUserInfo.AsQueryable();

        //    if (searchObject.ADMINID != 0)
        //    {
        //        int aid = searchObject.ADMINID.ToInt();
        //        query = query.Where(t => t.ADMINID == aid).AsQueryable();
        //    }
        //    if (searchObject.UNAME != null)
        //        query = query.Where(t => t.UNAME.StartsWith(searchObject.UNAME)).AsQueryable();

        //    if (searchObject.PWD != null)
        //        query = query.Where(t => t.PWD == searchObject.PWD).AsQueryable();

        //    if (searchObject.EMAILID != null)
        //        query = query.Where(t => t.EMAILID.StartsWith(searchObject.EMAILID)).AsQueryable();
        //    if (searchObject.STATUS != null)
        //        query = query.Where(t => t.STATUS == searchObject.STATUS).AsQueryable();
        //    if (searchObject.RoleName != null)
        //        query = query.Where(t => t.RoleName == searchObject.RoleName).AsQueryable();



        //    var list = query.Skip(criteria.SkipRecords)
        //        .Take(criteria.RowsPerPage).ToList();

        //    criteria.List = Mapper.Map<List<UserInfoEntity>>(list);

        //    criteria.TotalRows = query.Count();

        //}

        //    return criteria;
        //}



    }
}
