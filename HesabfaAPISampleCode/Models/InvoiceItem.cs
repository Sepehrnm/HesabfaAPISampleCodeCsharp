using HesabfaAPISampleCode.Models.Enumarations;

namespace HesabfaAPISampleCode.Models
{
    public class Invoice
    {
        public string? Number { get; set; }
        public string? Reference { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? DueDate { get; set; }
        public string? ContactCode { get; set; }
        public string? ContactTitle { get; set; }
        public decimal? Sum { get; set; }
        public string? Note { get; set; }
        public bool Sent { get; set; }
        public InvoiceType? InvoiceType { get; set; }
        public InvoiceStatuts? Status { get; set; }
        public string? Tag { get; set; }
        public decimal Freight { get; set; }
        public WarehouseReceiptStatus WarehouseReceiptStatus { get; set; }
        public string? Project { get; set; }
        public string? SalesmanCode { get; set; }
        public decimal SalesmanPercent { get; set; }
        public string? Currency { get; set; }
        public decimal? CurrencyRate { get; set; }
        public List<InvoiceItem>? InvoiceItems {get; set; }
    }

    public class InvoiceItem
    {
        public int RowNumber { get; set; }
        public string? Description { get; set; }
        public string? ItemCode { get; set; }
        public string? Unit { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Tax { get; set; }
    }
}
