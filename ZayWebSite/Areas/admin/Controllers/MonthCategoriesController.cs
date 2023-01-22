using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZayWebSite.Context;
using ZayWebSite.Dtos.CategoriesMonthDto;
using ZayWebSite.Dtos.SettingDto;
using ZayWebSite.Dtos.SliderDto;
using ZayWebSite.Models;

namespace ZayWebSite.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles ="Admin")]
    

    public class MonthCategoriesController : Controller
    {
        private readonly ZayDbContext _context;
        private readonly IMapper _mapper;


        public MonthCategoriesController(ZayDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IActionResult Index()
        { 
            CategoriesMonth categoriesMonth=_context.CategoriesMonths.FirstOrDefault();
            CategoriesMonthGetDto getDto=_mapper.Map<CategoriesMonthGetDto>(categoriesMonth);
            return View(getDto);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CategoriesMonthPostDto postDto)
        {
            CategoriesMonth cm = _mapper.Map<CategoriesMonth>(postDto);
            _context.CategoriesMonths.Add(cm);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Update()
        {
            CategoriesMonth categoriesMonth = _context.CategoriesMonths.FirstOrDefault();
            CategoriesMonthUpdateDto updateDto = new CategoriesMonthUpdateDto
            {
                getDto = _mapper.Map<CategoriesMonthGetDto>(categoriesMonth)
            };

            return View(updateDto);
        }
        [HttpPost]
        public IActionResult Update(CategoriesMonthUpdateDto updateDto)
        {
            CategoriesMonth categoriesm = _context.CategoriesMonths.FirstOrDefault();
             categoriesm = _mapper.Map<CategoriesMonth>(updateDto.postDto);
            _context.Update(categoriesm);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Delete()
        {
          CategoriesMonth cm=  _context.CategoriesMonths.FirstOrDefault();
            _context.Remove(cm);
            return RedirectToAction(nameof(Index));

        }


    }
}
