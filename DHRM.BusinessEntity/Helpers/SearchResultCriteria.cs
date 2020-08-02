using System.Collections.Generic;
using System.Collections.Specialized;

namespace DHRM.BusinessEntity
{
    public class SearchResultCriteria<T>
    {

        public SearchResultCriteria()
        {
            RowsPerPage = RowsPerPage == 0 ? SearchResultCriteria.RowsPerPageGlobal : RowsPerPage;
            PageNo = 1;
            SkipRecords = (PageNo - 1) * RowsPerPage;
            NoRecordsFoundText = !string.IsNullOrEmpty(NoRecordsFoundText)
                ? NoRecordsFoundText : SearchResultCriteria.NoRecordsFountTextGlobal;
        }
        public int PageNo { get; set; }
        public int RowsPerPage { get; set; }
        public Dictionary<string, object> Parameters;
        public object InputObject { get; set; }

        public int SkipRecords { get; private set; }

        public List<T> List { get; set; }
        public int TotalRows { get; set; }
        public string NoRecordsFoundText { get; set; }

        public SearchResultCriteria<T> LoadGriedSetting(NameValueCollection queryString)
        {
            PageNo = queryString["Page"] != null ? queryString["Page"].ToInt() : 1;
            SkipRecords = (PageNo - 1) * RowsPerPage;
            return this;
        }
    }

    public class SearchResultCriteria
    {
        public static int RowsPerPageGlobal;
        public static string NoRecordsFountTextGlobal;
    }
}
