using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZayWebSite.Context;
using ZayWebSite.Dtos.CategoryDto;
using ZayWebSite.Dtos.SettingDto;
using ZayWebSite.Dtos.SliderDto;
using ZayWebSite.Extensions;
using ZayWebSite.Helpers;
using ZayWebSite.Models;

namespace ZayWebSite.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles ="Admin")]

    public class CategoryController : Controller
    {
        private readonly ZayDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        public CategoryController(ZayDbContext context, IMapper mapper, IWebHostEnvironment env)
        {
            _context = context;
            _mapper = mapper;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Category> categories = _context.Categories.ToList();
            List<CategoryGetDto> getdtos = _mapper.Map<List<CategoryGetDto>>(categories);
            return View(getdtos);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CategoryPostDto postDto)
        {
            Category category = _mapper.Map<Category>(postDto);
            category.Image = postDto.formFile.CreateFile(_env.WebRootPath, "assets/img");
            CategoriesMonth categoriesMonth = _context.CategoriesMonths.FirstOrDefault();
            category.CategoriesMonthId = categoriesMonth.Id;
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id) {
            Category category = _context.Categories.Find(id);
            CategoryUpdateDto updateDto = new CategoryUpdateDto
            {
                getDto = _mapper.Map<CategoryGetDto>(category)
            };

            return View(updateDto);

        }
        [HttpPost]
        public IActionResult Update(CategoryUpdateDto updateDto)
        {
            Category category = _context.Categories.Find(updateDto.getDto.Id);
            category.Name = updateDto.postDto.Name;
            if(updateDto.postDto.formFile!= null)
            {
                Helper.DeleteFile(_env.WebRootPath, "assets/img", updateDto.postDto.formFile.FileName);
               category.Image= updateDto.postDto.formFile.CreateFile(_env.WebRootPath, "assets/img");
            }
            _context.Update(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            Category cat=_context.Categories.Find(id);
            _context.Categories.Remove(cat);
            //cat.Isdeleted = true;
            Helper.DeleteFile(_env.WebRootPath, "assets/img", cat.Image);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
