namespace HesabfaAPISampleCode.Models
{
    public class Inventory
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NodeName { get; set; }
        public string? NodeFamily { get; set; }
        public string? MainUnit { get; set; }
        public string? SubUnit { get; set; }
        public string? ProductCode { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Opening { get; set; }
        public decimal? Increase { get; set; }
        public decimal? Decrease { get; set; }
    }
}
