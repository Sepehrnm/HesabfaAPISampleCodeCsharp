namespace HesabfaAPISampleCode.Models
{
    public class WarehouseReceipt
    {
        public int WarehouseCode { get; set; }
        public int InvoiceNumber { get; set; }
        public int InvoiceType { get; set; }
        public string? Date { get; set; }
        public string? Notes { get; set; }
        public int Freight { get; set; }
        public string? Delivery { get; set; }
        public string? Project { get; set; }
        public object? Items { get; set; }
    }
}
