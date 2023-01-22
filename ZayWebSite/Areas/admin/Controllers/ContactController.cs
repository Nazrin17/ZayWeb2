using Microsoft.AspNetCore.Mvc;
using ZayWebSite.Context;
using ZayWebSite.Models;

namespace ZayWebSite.Areas.admin.Controllers
{
    [Area("admin")]
    public class ContactController : Controller
    {
        private readonly ZayDbContext _context;

        public ContactController(ZayDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
           List<Contact> contacts= _context.Contact.Where(c=>!c.IsDeleted).ToList();
            return View(contacts);
        }
        public IActionResult Delete(int id)
        {
            Contact contact= _context.Contact.Where(c=>!c.IsDeleted).FirstOrDefault(c=>c.Id==id);
            contact.IsDeleted = true;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
