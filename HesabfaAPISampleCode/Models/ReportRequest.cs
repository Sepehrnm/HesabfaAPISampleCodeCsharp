namespace HesabfaAPISampleCode.Models
{
    public class ReportRequest
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Project { get; set; }
    }

    public class ReportRequestWithAccountPath
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Project { get; set; }
        public string AccountPath { get; set; }
    }
}
