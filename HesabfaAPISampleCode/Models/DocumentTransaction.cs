using HesabfaAPISampleCode.Models.Enumarations;

namespace HesabfaAPISampleCode.Models
{
    public class DocumentTransaction
    {
        public string AccountPath { get; set; }
        public string Description { get; set; }
        public string Info { get; set; }
        public decimal Amount { get; set; }
        public decimal CurrencyAmount { get; set; }
        public string Currency { get; set; }
        public TransactionType Type { get; set; }
        public string ContactCode { get; set; }
        public string ProductCode { get; set; }
        public string BankCode { get; set; }
        public string CashCode { get; set; }
        public string PettyCashCode { get; set; }

    }
}
