using HesabfaAPISampleCode.Models.Enumarations;
using NPOI.Util;

namespace HesabfaAPISampleCode.Models
{
    public class ReceiptRequest
    {
        public ReceiptType Type { get; set; }
        public int Number { get; set; }
    }
}
