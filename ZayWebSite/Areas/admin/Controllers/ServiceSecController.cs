using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using ZayWebSite.Context;
using ZayWebSite.Dtos.ServicesSec;
using ZayWebSite.Models;

namespace ZayWebSite.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class ServiceSecController : Controller
    {
        private readonly ZayDbContext _context;
        private readonly IMapper _mapper;


        public ServiceSecController(ZayDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            ServiceSec servicesSec = _context.ServiceSec.FirstOrDefault();
            ServicesSecGetDto getDto = _mapper.Map<ServicesSecGetDto>(servicesSec);
            return View(getDto);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ServicesSecPostDto postDto)
        {
            ServiceSec srvc = _mapper.Map<ServiceSec>(postDto);
            _context.ServiceSec.Add(srvc);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Update()
        {
            ServiceSec servicesSec = _context.ServiceSec.FirstOrDefault();
            ServicesSecUpdateDto updateDto = new ServicesSecUpdateDto
            {
                getDto = _mapper.Map<ServicesSecGetDto>(servicesSec)
            };

            return View(updateDto);
        }
        [HttpPost]
        public IActionResult Update(ServicesSecUpdateDto updateDto)
        {
            ServiceSec? servicesSec = _context.ServiceSec.FirstOrDefault(x=>x.Title==updateDto.getDto.Title);
            servicesSec.Title=updateDto.postDto.Title;
            servicesSec.Description = updateDto.postDto.Description;
            _context.Update(servicesSec);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete()
        {
            ServiceSec ss = _context.ServiceSec.FirstOrDefault();
            _context.Remove(ss);
            return RedirectToAction(nameof(Index));

        }

    }
}
