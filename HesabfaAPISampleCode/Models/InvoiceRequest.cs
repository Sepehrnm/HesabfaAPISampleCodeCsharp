using HesabfaAPISampleCode.Models.Enumarations;

namespace HesabfaAPISampleCode.Models
{
    public class InvoiceRequest
    {
        public int Number { get; set; }
        public InvoiceType Type { get; set; }
    }
}
