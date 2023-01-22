using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZayWebSite.Context;
using ZayWebSite.Dtos.SliderDto;
using ZayWebSite.Extensions;
using ZayWebSite.Helpers;
using ZayWebSite.Models;

namespace ZayWebSite.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]

    public class SliderController : Controller
    {
        private readonly ZayDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        public SliderController(ZayDbContext context, IMapper mapper, IWebHostEnvironment env)
        {
            _context = context;
            _mapper = mapper;
            _env = env;
        }

        public IActionResult Index()
        {
           List<Slider> slider= _context.Sliders.Where(s=>!s.IsDeleted).ToList();
            List<SliderGetDto> getdtos=_mapper.Map<List<SliderGetDto>>(slider);
            return View(getdtos);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(SliderPostDto postDto)
        {
            Slider slider=_mapper.Map<Slider>(postDto);
            slider.Image = postDto.formFile.CreateFile(_env.WebRootPath, "assets/img");
            _context.Sliders.Add(slider);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Slider slider = _context.Sliders.Find(id);
            _context.Remove(slider);
            Helper.DeleteFile(_env.WebRootPath, "assets/img",slider.Image);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
