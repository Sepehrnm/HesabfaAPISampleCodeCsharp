namespace HesabfaAPISampleCode.Models
{
    public class Balancesheet
    {
        public object? Accounts { get; set; }
        public decimal Assets { get; set; }
        public decimal Liabilities { get; set; }
        public decimal Equity { get; set; }
        public decimal ProfitOrLoss { get; set; }
    }
}
