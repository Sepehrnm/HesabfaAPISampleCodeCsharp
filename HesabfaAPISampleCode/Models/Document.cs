namespace HesabfaAPISampleCode.Models
{
    public class Document
    {
        public int Id { get; set; }
        public int Number { get; set; }     
        public int Reference { get; set; }       
        public string? Date { get; set; }     
        public string? Description { get; set; }     
        public string? Project { get; set; }   
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }      
        public int Status { get; set; }      
        public object Transactions { get; set; }
    }
}
