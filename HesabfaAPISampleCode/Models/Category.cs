namespace HesabfaAPISampleCode.Models
{
    public class Category
    {
        public string Name { get; set; }
        public string FullPath { get; set; }
        public Array Children { get; set; }
        public Object Root { get; set; }
    }
}
