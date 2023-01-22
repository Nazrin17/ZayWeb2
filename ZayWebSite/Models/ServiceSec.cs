using Microsoft.Build.Framework;

namespace ZayWebSite.Models
{
    public class ServiceSec
    {

        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public List<Service> Services { get; set; }
    }

}
