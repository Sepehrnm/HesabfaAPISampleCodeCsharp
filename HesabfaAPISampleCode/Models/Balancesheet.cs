using HesabfaAPISampleCode.Models.Enumarations;

namespace HesabfaAPISampleCode.Models
{
    public class Balancesheet
    {
        public List<BlancesheetAccount> Accounts { get; set; }
        public decimal Assets { get; set; }
        public decimal Liabilities { get; set; }
        public decimal Equity { get; set; }
        public decimal ProfitOrLoss { get; set; }

    }

    public class BlancesheetAccountItem
    {
        public string Name { get; set; }
        public string MainAccountType { get; set; }
        public DetailType DetailType { get; set; }
    }

    public class BlancesheetAccount
    {
        public BlancesheetAccountItem Account { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal TotalDebit { get; set; }
        public decimal TotalCredit { get; set; }
        public decimal Balance { get; set; }
        public decimal TotalBalance { get; set; }
        public List<BlancesheetAccount> Children { get; set; }
    }
}
