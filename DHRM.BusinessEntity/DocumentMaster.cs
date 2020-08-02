using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHRM.BusinessEntity
{
   public class DocumentMaster
    {
        public int DocCode { get; set; }
        public int DocType { get; set; }
        public string DocName { get; set; }
        public string FileTypes { get; set; }
        public int MaxFileSize { get; set; }
        public bool IsRequired { get; set; }
    }
   public class DocumentType
   { 
       public int DocType_Code { get; set; }
       public string DocType_Name { get; set; }
       public string DocType_Scheme { get; set; }
   }
   public class DocumentMasters
    {
        public List<DocumentMaster> DocumentMasterList = new List<DocumentMaster>();
    }
}
