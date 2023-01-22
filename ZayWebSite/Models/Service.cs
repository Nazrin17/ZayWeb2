using Microsoft.Build.Framework;

namespace ZayWebSite.Models
{
    public class Service
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Icon { get; set; }
        public ServiceSec serviceSec { get; set; }
        public int serviceSecId { get; set; }
    }
}
