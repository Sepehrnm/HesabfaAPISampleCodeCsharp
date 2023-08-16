namespace HesabfaAPISampleCode.Models
{
    public class TrialBalance
    {
        public TrialAccount Account { get; set; }

        public string AccountName
        {
            get { return Account?.Name; }
            set { Account.Name = value; }
        }

        public string AccountPath
        {
            get { return Account?.Path; }
            set { Account.Path = value; }
        }

        public int? AccountType
        {
            get { return Account?.AccountType; }
            set { Account.AccountType = value; }
        }

        public int? MainAccountType
        {
            get { return Account?.MainAccountType; }
            set { Account.MainAccountType = value; }
        }
        public decimal? Debit { get; set; }
        public decimal? Credit { get; set; }
        public decimal? Balance { get; set; }
        public int? BalanceType { get; set; }
        public decimal? OpeningDebit { get; set; }
        public decimal? OpeningCredit { get; set; }
        public decimal? RemainingDebit { get; set; }
        public decimal? RemainingCredit { get; set; }
    }

    public class TrialAccount
    {
        public string? Name { get; set; }
        public string? Path { get; set; }
        public int? AccountType { get; set; }
        public int? MainAccountType { get; set; }
    }
}

