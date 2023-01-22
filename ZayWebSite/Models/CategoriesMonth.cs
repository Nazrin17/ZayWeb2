namespace ZayWebSite.Models
{
    public class CategoriesMonth
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Category> Categories { get; set;}
    }
}
