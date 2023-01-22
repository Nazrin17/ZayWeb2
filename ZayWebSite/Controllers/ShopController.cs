using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZayWebSite.Context;
using ZayWebSite.Models;

namespace ZayWebSite.Controllers
{
    
    public class ShopController : Controller
    {
        private readonly ZayDbContext _context;

        public ShopController(ZayDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Product> products=_context.Products.Include(p=>p.Images).ToList();
            return View(products);
        }
        public IActionResult Details(int id)
        {
            Product product =_context.Products.Include(p=>p.Images).FirstOrDefault(p=>p.Id==id);
            return View(product);
        }
    }
}
