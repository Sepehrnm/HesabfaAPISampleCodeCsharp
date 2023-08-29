namespace HesabfaAPISampleCode.Models
{
    public class InvoiceItem
    {
        public string? Number { get; set; }
        public string? Reference { get; set; }
        public string? Date { get; set; }
        public string? DueDate { get; set; }
        public string? ContactCode { get; set; }
        public string? ContactTitle { get; set; }
        public string? Sum { get; set; }
        public string? Note { get; set; }
        public bool? Sent { get; set; }
        public int? InvoiceType { get; set; }
        public int? Status { get; set; }
        public string? Tag { get; set; }
        public decimal? Freight { get; set; }
        public int? WarehouseReceiptStatus { get; set; }
        public string? Project { get; set; }
        public int? SalesmanCode { get; set; }
        public decimal? SalesmanPercent { get; set; }
        public string? Currency { get; set; }
        public decimal? CurrencyRate { get; set; }
        public object InvoiceItems {get; set; }
    }
    public class ItemObject
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public int ItemType { get; set; }
        public string? Unit { get; set; }
        public string? Barcode { get; set; }
        public decimal Stock { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SellPrice { get; set; }
        public string? PurchasesTitle { get; set; }
        public string? SalesTitle { get; set; }
        public int NodeId { get; set; }
        public string? NodeName { get; set; }
        public string? NodeFamily { get; set; }
        public string? Tag { get; set; }
        public string? Description { get; set; }
        public string? ProductCode { get; set; }
        public bool Active { get; set; }
    }
}
