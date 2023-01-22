using ZayWebSite.Context;
using ZayWebSite.Models;
using ZayWebSite.Services.Interfaces;

namespace ZayWebSite.Services.Implementations
{
    public class SettingService : ISettingService
    {
        private readonly ZayDbContext _context;

        public SettingService(ZayDbContext context)
        {
            _context = context;
        }

        public Setting Get()
        {
            return _context.Settings.FirstOrDefault();
        }
    }
}
