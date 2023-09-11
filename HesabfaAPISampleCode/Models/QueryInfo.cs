namespace HesabfaAPISampleCode.Models
{
    public class QueryInfo
    {
        public class FilterInfo
        {
            public FilterInfo()
            {
                Property = "";
                Operator = "";
                Value = null;
            }
            public string Property { get; set; }
            public string Operator { get; set; }
            public object Value { get; set; }
        }

        public QueryInfo()
        {
            SortBy = "";
            SortDesc = false;
            Take = 10;
            Skip = 0;
            Search = "";
            Filters = new List<FilterInfo>();
        }
        public string SortBy { get; set; }
        public bool SortDesc { get; set; }
        public int Take { get; set; } 
        public int Skip { get; set; }
        public string Search { get; set; }
        public List<FilterInfo> Filters { get; set; }
    }
}
