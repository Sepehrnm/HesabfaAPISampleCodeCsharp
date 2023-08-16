namespace HesabfaAPISampleCode.Models
{
    public class UserLog
    {
        public int? Id { get; set; }
        public string? DateTime { get; set; }
        public int? Action { get; set; }
        public int? ObjectId { get; set; }
        public string? ObjectType { get; set; }
        public string? Extra { get; set; }
        public bool? API { get; set; }
    }
}
