using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZayWebSite.Context;
using ZayWebSite.Models;

namespace ZayWebSite.Controllers
{
    public class AboutController : Controller
    {
        private readonly ZayDbContext _context;

        public AboutController(ZayDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ServiceSec serviceSec=_context.ServiceSec.Include(s=>s.Services).FirstOrDefault();
            return View(serviceSec);
        }
    }
}
