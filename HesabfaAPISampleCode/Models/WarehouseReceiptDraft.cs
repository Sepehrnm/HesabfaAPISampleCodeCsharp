using HesabfaAPISampleCode.Models.Enumarations;

namespace HesabfaAPISampleCode.Models
{
    public class WarehouseReceiptDraft
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string? InvoiceNumber { get; set; }
        public InvoiceType InvoiceType { get; set; }
        public int WarehouseCode { get; set; }
        public int DestinationWarehouseCode { get; set; }
        public DateTime? Date { get; set; }
        public string? Notes { get; set; }
        public string? Delivery { get; set; }
        public string? Freight { get; set; }
        public string? Project { get; set; }
        public bool Receiving { get; set; }
        public List<ItemObject>? Items { get; set; }
    }

    public class ItemObject
    {
        public string? ItemCode { get; set; }
        public string? Reference { get; set; }
        public string? Notes { get; set; }
        public decimal Quantity { get; set; }
        public ItemDetailed? Item { get; set; }
    }

    public class ItemDetailed
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Barcode { get; set; }
        public ProductType? ItemType { get; set; }
        public string? Unit { get; set; }
        public decimal Stock { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SellPrice { get; set; }
        public string? PurchasesTitle { get; set; }
        public string? SalesTitle { get; set; }
        public string? NodeFamily { get; set; }
        public string? Tag { get; set; }
        public string? Description { get; set; }
        public string? ProductCode { get; set; }
        public bool Active { get; set; }
    }
}
