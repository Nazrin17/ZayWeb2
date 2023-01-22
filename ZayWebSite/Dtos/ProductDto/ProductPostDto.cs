using System.ComponentModel.DataAnnotations.Schema;

namespace ZayWebSite.Dtos.ProductDto
{
    public class ProductPostDto
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string Specification { get; set; }
        [NotMapped]
        public List<IFormFile>  formFile { get; set; } 
    }
}
