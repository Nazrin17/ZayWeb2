using System.ComponentModel.DataAnnotations.Schema;

namespace ZayWebSite.Dtos.SliderDto
{
    public class SliderPostDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public IFormFile formFile { get; set; }
    }
}
