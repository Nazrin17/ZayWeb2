using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZayWebSite.Context;
using ZayWebSite.Dtos.CategoryDto;
using ZayWebSite.Dtos.ProductDto;
using ZayWebSite.Extensions;
using ZayWebSite.Models;
using ZayWebSite.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace ZayWebSite.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]

    public class ProductController : Controller
    {
        private readonly ZayDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        public ProductController(ZayDbContext context, IMapper mapper, IWebHostEnvironment env)
        {
            _context = context;
            _mapper = mapper;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Product> products = _context.Products.Include(p=>p.Images).Where(s => !s.IsDeleted).ToList();
            List<ProductGetDto> getdtos = _mapper.Map<List<ProductGetDto>>(products);
            return View(getdtos);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductPostDto postDto)
        {
            Product product = _mapper.Map<Product>(postDto);
            foreach (var item in postDto.formFile)
            {
                ProductImage productImage = new ProductImage
                {
                    Product = product,
                    ProductId = product.Id,
                    Name = item.CreateFile(_env.WebRootPath, "assets/img")
                };
                product.Images.Add(productImage);
            }
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}

