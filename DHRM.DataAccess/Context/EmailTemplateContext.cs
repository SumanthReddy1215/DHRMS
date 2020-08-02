using System;
using System.Collections.Generic;
using System.Linq;
using DHRM.BusinessEntity;
using System.Threading.Tasks;

namespace DHRM.DataAccess.Context
{
    public class EmailTemplateContext
    {
        public EmailTemplateEntity GetTemplate(Criteria criteria)
        {
            EmailTemplateEntity emailTemplate = null;
            //using (var db = DbHelper.Open())
            //{
            //    int templateId = criteria.ID.ToInt();
            //    var template = db.EmailTemplates.SingleOrDefault(r => r.ID == templateId);
            //    emailTemplate = new EmailTemplateEntity()
            //    {
            //        ID = template.ID,
            //        TemplateName = template.TemplateName,
            //        TemplateBody = template.TemplateBody
            //    };

                return emailTemplate;
            //}
        }


    }
}
