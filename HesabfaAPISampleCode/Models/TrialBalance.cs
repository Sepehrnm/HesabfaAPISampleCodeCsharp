using HesabfaAPISampleCode.Models.Enumarations;

namespace HesabfaAPISampleCode.Models
{
    public class TrialBalance
    {
        public TrialAccount Account { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal Balance { get; set; }
        public BalanceType BalanceType { get; set; }
        public decimal OpeningDebit { get; set; }
        public decimal OpeningCredit { get; set; }
        public decimal RemainingDebit { get; set; }
        public decimal RemainingCredit { get; set; }
    }

    public class TrialAccount
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public AccountType AccountType { get; set; }
        public MainAccountType MainAccountType { get; set; }
    }
}

