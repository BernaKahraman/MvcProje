using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact

        ContactManager cm = new ContactManager(new EfContactDal());
        ContactValidator cv = new ContactValidator();
        Context _context = new Context();

        
        public ActionResult Index()
        {
            var contactvalues = cm.GetList();
            return View(contactvalues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactvalues = cm.GetByID(id);
            return View(contactvalues);

        }
        public PartialViewResult ContactPartial()
        {
            //toplam iletişim sayısı
            var ContactNumbers = _context.Contacts.Count();
            ViewBag.ContactNumbers = ContactNumbers;

            //Toplam gelen mesaj sayısı
            var GelenMesajSayisi = _context.Messages.Count(x => x.ReceiverMail == "admin@gmail.com");
            ViewBag.GelenMesajSayisi = GelenMesajSayisi;

            //Toplam gönderilen mesaj sayısı
            var GonderilenMesajSayisi = _context.Messages.Count(x => x.SenderMail == "admin@gmail.com");
            ViewBag.GonderilenMesajSayisi = GonderilenMesajSayisi;
            return PartialView();
        }
    }
        
}