namespace HesabfaAPISampleCode.Models
{
    public class PaymentRequest
    {
        public int Type { get; set; }
        public int Number { get; set; }
        public string BankCode { get; set; }
        public string Date { get; set; }
        public int Amount { get; set; }
        public string TransactionNumber { get; set; }
        public string Description { get; set; }
        public int TransactionFee { get; set; }
    }
}
