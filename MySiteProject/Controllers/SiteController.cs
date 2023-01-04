using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySiteProject.Models.Context;
using MySiteProject.Models.Entities;

namespace MySiteProject.Controllers
{
    [AllowAnonymous]
    public class SiteController : Controller
    {
        MySiteContext db = new MySiteContext();
        public IActionResult Index()
        {
            ViewBag.aboutMe = db.AboutMes.OrderByDescending(x=>x.DescriptionDate).ToList();
            return View(db.ProjectInfos.OrderByDescending(x=>x.ProjectDate).ToList());
        }

        [HttpPost]
        public IActionResult Contact(Contact contact)
        {
            db.Contacts.Add(contact);
            db.SaveChanges();
            TempData["Message"] = "Form submission successful!";
            return Redirect("~/site/index#contact");
        }
    }
}
