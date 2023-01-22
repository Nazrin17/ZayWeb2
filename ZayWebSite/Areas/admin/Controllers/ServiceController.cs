using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ZayWebSite.Context;
using ZayWebSite.Dtos.ServiceDto;
using ZayWebSite.Models;

namespace ZayWebSite.Areas.admin.Controllers
{
    [Area("admin")]
    public class ServiceController : Controller
    {
        private readonly ZayDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        public ServiceController(ZayDbContext context, IMapper mapper, IWebHostEnvironment env)
        {
            _context = context;
            _mapper = mapper;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Service> services = _context.Services.ToList();
            List<ServiceGetDto> getdtos = _mapper.Map<List<ServiceGetDto>>(services);
            return View(getdtos);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ServicePostDto postDto)
        {
            Service service = _mapper.Map<Service>(postDto);
            ServiceSec servicesSec = _context.ServiceSec.FirstOrDefault();
            service.serviceSecId = servicesSec.Id;
            _context.Services.Add(service);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            Service service = _context.Services.Find(id);
            ServiceUpdateDto updateDto = new ServiceUpdateDto
            {
                getDto = _mapper.Map<ServiceGetDto>(service)
            };

            return View(updateDto);

        }
        [HttpPost]
        public IActionResult Update(ServiceUpdateDto updateDto)
        {
            Service service = _context.Services.Find(updateDto.getDto.Id);
            if (!ModelState.IsValid)
            {
                return View();
            }
            service.Name = updateDto.postDto.Name;
            service.Icon = updateDto.postDto.Icon;
            _context.Update(service);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            Service service = _context.Services.Find(id);
            _context.Services.Remove(service);
            //cat.Isdeleted = true;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
