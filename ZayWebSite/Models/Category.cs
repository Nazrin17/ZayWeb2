namespace ZayWebSite.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public bool Isdeleted { get; set; }
        public CategoriesMonth CategoriesMonth { get; set; }
        public int CategoriesMonthId { get; set; }
    }
}
