using HesabfaAPISampleCode.Models.Enumarations;

namespace HesabfaAPISampleCode.Models
{
    public class ProfitAndLossStatement
    {
        public List<ProfitAndLossAccount> Accounts { get; set; }
    }

    public class ProfitAndLossAccountItem
    {
        public string Name { get; set; }
        public string MainAccountType { get; set; }
        public DetailType DetailType { get; set; }
        public List<ProfitAndLossAccount> InventoryAdjustment { get; set; }
    }

    public class ProfitAndLossAccount
    {
        public ProfitAndLossAccountItem Account { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal TotalDebit { get; set; }
        public decimal TotalCredit { get; set; }
        public decimal Balance { get; set; }
        public decimal TotalBalance { get; set; }
        public List<ProfitAndLossAccount> Children { get; set; }
    }
}
