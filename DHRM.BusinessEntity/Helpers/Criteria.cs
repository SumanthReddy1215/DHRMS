using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHRM.BusinessEntity
{
    public class Criteria
    {
        public Criteria()
        {
            PageCount = 10;
            PageNo = 1;
            SkipRecords = (PageNo - 1) * PageCount;
        }
        public object ID { get; set; }
        public int PageNo { get; set; }
        public int PageCount { get; set; }
        public Dictionary<string, object> Parameters;

        public int SkipRecords { get; private set; }

    }
}
