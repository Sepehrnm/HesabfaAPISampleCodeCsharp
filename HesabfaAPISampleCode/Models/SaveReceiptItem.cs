namespace HesabfaAPISampleCode.Models
{
    public class SaveReceiptItem
    {
        public int Type { get; set; }
        public string Description { get; set; }
        public int BankCode { get; set; }
        public int ContactCode { get; set; }
        public decimal Amount { get; set; }
        public int Number { get; set; }

    }
}
