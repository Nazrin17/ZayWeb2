namespace ZayWebSite.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public bool IsDeleted { get; set; }

    }
}
