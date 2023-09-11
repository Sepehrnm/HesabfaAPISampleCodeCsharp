using HesabfaAPISampleCode.Models.Enumarations;
using NPOI.SS.Formula.Functions;

namespace HesabfaAPISampleCode.Models
{
    public class SaveContactRequest
    {
        public string? Code {get; set;}
        public string Name {get; set;}
        public string? Company {get; set;}
        public string? FirstName {get; set;}
        public string? LastName {get; set;}
        public int ContactType {get; set;}
        public string? NationalCode {get; set;}
        public string? EconomicCode {get; set;}
        public string? RegistrationNumber {get; set;}
        public string? Address {get; set;}
        public string? City {get; set;}
        public string? State {get; set;}
        public string? PostalCode {get; set;}
        public string? Phone {get; set;}
        public string? Fax {get; set;}
        public string? Mobile {get; set;}
        public string? Email {get; set;}
        public string? Website {get; set;}
        public string? Note {get; set;}
        public string? ContactCredit {get; set;}
        public int? TaxType {get; set;}
        public bool? Active { get; set; }
    }
}
