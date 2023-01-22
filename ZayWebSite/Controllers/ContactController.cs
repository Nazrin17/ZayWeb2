using Microsoft.AspNetCore.Mvc;
using ZayWebSite.Context;
using ZayWebSite.Models;

namespace ZayWebSite.Controllers
{
    public class ContactController : Controller
    {
        private readonly ZayDbContext _context;

        public ContactController(ZayDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return View()  ;
            };
                Contact newcontact = new Contact();
            newcontact.Subject = contact.Subject;
            newcontact.Email = contact.Email;
            newcontact.Name = contact.Name;
            newcontact.Message = contact.Message;
            _context.Contact.Add(newcontact);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
