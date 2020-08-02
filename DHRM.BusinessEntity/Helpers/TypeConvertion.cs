using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHRM.BusinessEntity
{
    public static class TypeConvertion
    {
        public static string ToStr(this object val)
        {
            return val != null && val != DBNull.Value ? val.ToString() : string.Empty;
        }

        public static bool ToBoolean(this object val)
        {
            return val == null && val == DBNull.Value ? false : Convert.ToBoolean(val);
        }

        public static int ToInt(this object val)
        {
            int res = 0;
            int.TryParse(val.ToStr(), out res);
            return res;
        }
        public static DateTime ToDateTime(this object val)
        {
            DateTime datetime;
            DateTime.TryParse(val.ToString(), out datetime);
            return datetime;
        }
        public static DateTime? ToDateTimeNullable(this object val)
        {
            DateTime datetime;
            try
            {
                DateTime.TryParse(val.ToString(), out datetime);
            }
            catch (Exception ex)
            {
                return null;
            }
            return datetime;
        }

    }
}
