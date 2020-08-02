using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
namespace DHRM.BusinessEntity
{
    public class DocumentInfoEntity
    {
        public DocumentInfoEntity()
        {
            Filetype_DTO = new FileType_DTO();
            IsRequired = false;
        }
        public int DocCode { get; set; }
        [Display(Name = "Document Type")]
        public int DocType { get; set; }
        [Display(Name = "Document Name")]
        public string DocName { get; set; }
        [Display(Name = "File Types")]
        public string FileType { get; set; }
        [Display(Name = "Max File Size")]
        public int MaxFileSize { get; set; }
        [Display(Name = "Is Required")]
        public Boolean IsRequired { get; set; }

        public DocumentType DocumentType_DTO { get; set; }
        [NotMapped]
        public List<DocumentType> DocumentTypeList { get; set; }
        public FileType_DTO Filetype_DTO { get; set; }
    }
    public class DocumentType
    {
        public int DocType_Code { get; set; }
        public string DocType_Name { get; set; }
        public string DocType_Scheme { get; set; }
    }
    public class DocumentMasters
    {
        public List<DocumentInfoEntity> DocumentMasterList = new List<DocumentInfoEntity>();
    }

    public class FileType_DTO
    {
        public FileType_DTO()
        {
            FileTypes = new List<SelectListItem>();
        }
        public List<SelectListItem> FileTypes { get; set; }
        public int[] FileTypeIds { get; set; }
    }


}
