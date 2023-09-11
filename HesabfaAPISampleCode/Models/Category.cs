namespace HesabfaAPISampleCode.Models
{
    public class Category
    {
        public CategoryItem Root { get; set; }
    }

    public class CategoryItem
    {
        public string Name { get; set; }
        public string FullPath { get; set; }
        public List<CategoryItem> Children { get; set; }
    }
}
