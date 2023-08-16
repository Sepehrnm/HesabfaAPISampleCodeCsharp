namespace HesabfaAPISampleCode.Models
{
    public class TrialBalanceItem
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public decimal? Debit { get; set; }
        public decimal? Credit { get; set; }
        public decimal? Balance { get; set; }
        public int? BalanceType { get; set; }
    }
}
