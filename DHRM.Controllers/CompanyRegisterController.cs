using DHRM.WebHelper;
using System.Web.Mvc;
using DHRM.DataAccess;
using System;
using DHRM.BusinessEntity;
using TSoft.AppConfiguration;
using System.Collections.Generic;
using System.Web;
using System.IO;

namespace DHRM.Controllers
{
    public class CompanyRegisterController : BaseController
    {
        string DocumentsPath = System.Configuration.ConfigurationManager.AppSettings["DocumentsPath"];
        [HttpGet]
        public ActionResult Index(bool isBack = false)
        {
            CompanyRegisterEntity model = null;
            List<CompanyRegisterEntity> modelList = new List<CompanyRegisterEntity>();
            if (!isBack)
            {
                UserContext context = new UserContext();
                modelList = context.GetCompanyList();
            }
            else
            {
                ViewBag.SourceUrl = Url.Action("Index", "Dashboard");
                model = AppSettings.SessionManager.Get<CompanyRegisterEntity>("CompanyInfo");
            }

            //UserContext context = new UserContext();
            //var userInfo = context.GetUserInfo(username, password);
            //if (userInfo != null)
            //{
            //    AppSessionManager.UserInformation = userInfo;

            return View(model);
        }

        [HttpPost]
        public JsonResult Index(FormCollection fc)
        {
            var f = fc;

            CompanyRegisterEntity model = new CompanyRegisterEntity();
            model.CompanyType = fc["CompanyType"];
            model.CompanyName=fc["CompanyName"];
            model.LogoName=fc["CompanyLogo"];
            model.StreetAddress1=fc["StreetAddress1"];
            model.StreetAddress2=fc["StreetAddress2"];
            model.City=fc["City"];
            model.StateName=fc["StateName"];
            model.CountryName=fc["CountryName"];
            model.ZipCode=fc["ZipCode"];
            model.ContactPerson=fc["ContactPerson"];
            model.ContactEmail=fc["ContactEmail"];
            model.ContactPhone=fc["ContactPhone"];
            Byte[] bytes = null;
            for (int i = 0; i < Request.Files.Count; i++)
            {
                if (Request.Files.AllKeys[i].ToStr().ToUpper() == "LOGO")
                {
                    Stream fs = Request.Files[i].InputStream;
                    BinaryReader br = new BinaryReader(fs);
                    bytes = br.ReadBytes((Int32)fs.Length);
                }
            }
            model.Logo = bytes;
            UserContext context = new UserContext();
            var result=context.SaveCompanyDetails(model);

            return Json("OK");


            //for (int i = 0; i < Request.Files.Count; i++)
            //{
            //    if (Request.Files.AllKeys[i].ToStr().ToUpper() != "LOGO")
            //    {
            //        var file = Request.Files[i];
            //        var fileName = Path.GetFileName(file.FileName);
            //        var path = Path.Combine(Server.MapPath(DocumentsPath + "/CompanyDocuments/Logo"), fileName);
            //        if (!Directory.Exists(Server.MapPath("~/CompanyDocuments/Logo")))
            //        {
            //            Directory.CreateDirectory(Server.MapPath("~/CompanyDocuments/Logo"));
            //        }
            //        file.SaveAs(path);
            //    }

            //}
        }
        private string ViewImage(byte[] arrayImage)
        {

            string base64String = Convert.ToBase64String(arrayImage, 0, arrayImage.Length);

            return "data:image/png;base64," + base64String;

        }
        [HttpPost]
        public JsonResult GetCompanyType()
        {
            UserContext UC = new UserContext();
            var result = UC.GetCompanyType();
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetDocumentTemp(int DocType)
        {
            UserContext UC = new UserContext();
            var result = UC.GetDocumentTemp(DocType);
            return Json(result);
        }
    }
}
