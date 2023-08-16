using System.Transactions;

namespace HesabfaAPISampleCode.Models
{
    public class ReceiptItem
    {
        public int? Id { get; set; }
        public int? Number { get; set; }
        public string? DateTime { get; set; }
        public string? Description { get; set; }
        public decimal? Amount { get; set; }
        public string? Currency { get; set; }
        public string? Project { get; set; }
        public List<ItemsArray>? Items { get; set; }
        public List<TransactionsArray>? Transactions { get; set; }

    }

    public class ItemsArray
    {
        public ContactObject? Contact { get; set; }
        public decimal? Amount { get; set; }
        public string? Description { get; set; }
    }

    public class TransactionsArray
    {
        public string? Cash { get; set; }
        public BankObject? Bank { get; set; }
        public string? PettyCash { get; set; }
        public string? Contact { get; set; }
        public string? Check { get; set; }
        public decimal? Amount { get; set; }
    }

    public class BankObject
    {
        public int? Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
    }

    public class ContactObject
    {
        public int? Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
    }
}
