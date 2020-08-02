using DHRM.WebHelper;
using System.Web.Mvc;

using System;
using DHRM.BusinessEntity;
using TSoft.AppConfiguration;
using System.Collections.Generic;
using System.Data;
using DHRM.DataAccess.Context;


namespace DHRM.Controllers
{
    public class DocumentController : BaseController
    {
        DocumentContext objdb = new DocumentContext();

        [HttpGet]
        public ActionResult Index()
        {
            DocumentInfoEntity Doc = new DocumentInfoEntity();
            Doc.Filetype_DTO.FileTypes = GetFileTypeList();
            Doc.DocumentTypeList = new List<DocumentType>()
            {
            new DocumentType { DocType_Code = 0, DocType_Name = "Select" }
            };
            Doc.DocumentTypeList.AddRange(GetDocumentTypeList());

            return View(Doc);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(DocumentInfoEntity objplan, FormCollection collection)
        {

            DocumentInfoEntity Doc = new DocumentInfoEntity();
            Doc.Filetype_DTO.FileTypes = GetFileTypeList();
            Doc.DocumentTypeList = new List<DocumentType>()
            {
            new DocumentType { DocType_Code = 0, DocType_Name = "Select" }
            };
            Doc.DocumentTypeList.AddRange(GetDocumentTypeList());

            return View(Doc);
        }
        [NonAction]
        public static List<SelectListItem> GetFileTypeList()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = ".PDF".ToString(), Value = "1" });
            items.Add(new SelectListItem { Text = ".JPEG", Value = "2" });
            items.Add(new SelectListItem { Text = ".PNG", Value = "3" });
            items.Add(new SelectListItem { Text = ".XLSX", Value = "4" });
            return items;
        }
        [NonAction]
        public static List<DocumentType> GetDocumentTypeList()
        {
            DocumentContext Ctx = new DocumentContext();
            return Ctx.GetDocumenttype();
        }
        [NonAction]
        public SelectList ToSelectList(DataTable table, string valueField, string textField)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(new SelectListItem()
                {
                    Text = row[textField].ToString(),
                    Value = row[valueField].ToString()
                });
            }
            return new SelectList(list, "Value", "Text");
        }
        [HttpPost]
        public JsonResult GetDocumentType()
        {

            DocumentType objdoc = null;

            DataTable dt = new DataTable();
            // dt = objdb.GetDocumenttype();
            var result = objdb.GetDocumenttype();
            //ViewBag.DocList = ToSelectList(dt, "DocType_Code", "DocType_Name"); 
            return Json(result);


        }
        [HttpPost]
        public ActionResult SaveDocument(int DocCode, int DocType, string DocName, string FileTypes, string MaxFileSize, Boolean IsRequired)
        {
            DocumentInfoEntity objdoc = null;
            try
            {
                objdb.SaveDocument(DocCode, DocType, DocName, FileTypes, MaxFileSize, IsRequired);
            }
            catch (Exception ex)
            {
            }
            return View();
        }
        [HttpGet]
        public JsonResult GetDocumentDetails(int? DocCode)
        {
            DataTable dt = new DataTable();

            var result = objdb.GetDocumentMaster(DocCode);

            return Json(result);
        }
       
    }
}
