using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using ZayWebSite.Context;
using ZayWebSite.Models;
using ZayWebSite.ViewModels;

namespace ZayWebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ZayDbContext _context;

        public HomeController(ZayDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        
        {
            List<Slider> sliders = _context.Sliders.ToList();
            CategoriesMonth categoriesMonth=_context.CategoriesMonths.Include(c=>c.Categories).FirstOrDefault();
            HomeVM homevm = new HomeVM
            {
                sliders = sliders,
                CategoriesMonth = categoriesMonth

            };
            return View(homevm);
        }

    }
}