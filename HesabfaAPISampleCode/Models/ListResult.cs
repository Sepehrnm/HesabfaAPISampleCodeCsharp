namespace HesabfaAPISampleCode.Models
{
    public class ListResult<T>
    {
        public int TotalCount { get; set; }
        public int FilteredCount { get; set; }
        public int From { get; set; }
        public int To { get; set; }

        public List<T> List { get; set; }
    }
}
