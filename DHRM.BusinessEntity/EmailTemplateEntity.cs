using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHRM.BusinessEntity
{
    public class EmailTemplateEntity
    {
        public int ID { get; set; }
        public string TemplateName { get; set; }
        public string TemplateBody { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public int MoverID { get; set; }
    }
}
