using System.ComponentModel.DataAnnotations.Schema;

namespace ZayWebSite.Dtos.CategoryDto
{
    public class CategoryPostDto
    {
        public string Name { get; set; }
        [NotMapped]
        public IFormFile formFile { get; set; }
    }
}
