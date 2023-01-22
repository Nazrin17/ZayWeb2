namespace ZayWebSite.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string Specification { get; set; }
        public bool  IsDeleted { get; set; }
        public List<ProductImage> Images { get; set; }
        public Product()
        {
            Images=new List<ProductImage> ();
        }
    }
}
