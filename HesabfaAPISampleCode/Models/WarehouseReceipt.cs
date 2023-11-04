namespace HesabfaAPISampleCode.Models;
using HesabfaAPISampleCode.Models.Enumarations;

public class WarehouseReceipt
{
    public int WarehouseCode { get; set; }
    public int InvoiceNumber { get; set; }
    public InvoiceType InvoiceType { get; set; }
    public DateTime? Date { get; set; }
    public string? Notes { get; set; }
    public int Freight { get; set; }
    public string? Delivery { get; set; }
    public string? Project { get; set; }
    public List<Item>? Items { get; set; }
}
public class Item
{
    public int ItemCode { get; set; }
    public decimal Quantity { get; set; }
    public string? Reference { get; set; }
    public string? Notes { get; set; }
}