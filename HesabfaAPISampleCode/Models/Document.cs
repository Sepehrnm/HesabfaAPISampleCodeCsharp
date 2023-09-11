using HesabfaAPISampleCode.Models.Enumarations;

namespace HesabfaAPISampleCode.Models
{
    public class Document
    {
        public int Id { get; set; }
        public int Number { get; set; }     
        public int Reference { get; set; }       
        public DateTime Date { get; set; }     
        public string Description { get; set; }     
        public string Project { get; set; }   
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }      
        public DocumentStatus Status { get; set; }      
        public List<DocumentTransaction> Transactions { get; set; }
    }
}
