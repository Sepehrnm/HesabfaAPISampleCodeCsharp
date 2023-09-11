using HesabfaAPISampleCode.Models.Enumarations;

namespace HesabfaAPISampleCode.Models
{
    public class ProductItem
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public ProductType ItemType { get; set; }
        public string Unit { get; set; }
        public decimal Stock { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SellPrice { get; set; }
        public string? PurchasesTitle { get; set; }
        public string? SalesTitle { get; set; }
        public string? NodeFamily { get; set; }
        public string? Tag { get; set; }
        public string? Description { get; set; }
        public string? ProductCode { get; set; }
        public bool? Active { get; set; }
    }
}
