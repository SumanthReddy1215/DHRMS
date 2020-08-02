using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHRM.BusinessEntity
{
    public class UserInfoEntity
    {
        public int MEM_ID { get; set; }
        public string MEM_UserName { get; set; }
        public string MEM_Password { get; set; }
        public int MEM_RoleID { get; set; }
        public string MEM_FirstName { get; set; }
        public string MEM_LastName { get; set; }
        public string MEM_MobileNo { get; set; }
        public string MEM_Email { get; set; }
        public bool MEM_IsActive { get; set; }
        public Nullable<System.DateTime> MEM_LastLoginDateTime { get; set; }
        public string MEM_LastLoginIP { get; set; }
        public Nullable<int> MEM_LoginFailCount { get; set; }
        public Nullable<bool> MEM_EmailNotification { get; set; }
        public int MEM_CreatedBy { get; set; }
        public System.DateTime MEM_CreatedDateTime { get; set; }
        public string MEM_CreatedIP { get; set; }
        public string MEM_ModifiedBy { get; set; }
        public Nullable<System.DateTime> MEM_ModofiedDateTime { get; set; }
        public string MEM_ModofiedIP { get; set; }
        public string RoleName { get; set; }
    }
}
