using AutoMapper;
using MessagePack;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZayWebSite.Context;
using ZayWebSite.Dtos.SettingDto;
using ZayWebSite.Models;

namespace ZayWebSite.Areas.admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class SettingController : Controller
    {
        private readonly ZayDbContext _context;
        private readonly IMapper _mapper;


        public SettingController(ZayDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            Setting setting = _context.Settings.FirstOrDefault();
            SettingGetDto getdto = _mapper.Map<SettingGetDto>(setting);
            return View(getdto);
        }
        
        public IActionResult Update()
        {
            Setting setting = _context.Settings.FirstOrDefault();
            SettingUpdateDto updateDto = new SettingUpdateDto
            {
                getDto = _mapper.Map<SettingGetDto>(setting)
            };
            
            return  View(updateDto);
        }
        [HttpPost]
        public IActionResult Update(SettingUpdateDto updateDto)
        {
            Setting setting=_context.Settings.FirstOrDefault();
            setting.Email = updateDto.postDto.Email;
            setting.Phone = updateDto.postDto.Phone;
            setting.Logo = updateDto.postDto.Logo;
            setting.Icon= updateDto.postDto.Icon;
            _context.Update(setting);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
    }
}
