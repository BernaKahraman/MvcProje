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
        ContactManager cm = new ContactManager(new EfContactDal());
        MessageManager mm = new MessageManager(new EfMessageDal());
        ContactValidator cv = new ContactValidator();


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
        public PartialViewResult MessageListMenu()
        {
            string userEmail = (string)Session["AdminUserName"];
            var contactvalues = cm.GetList().Count();
            ViewBag.iletisim = contactvalues;
            var gelen = mm.GetListInbox(userEmail).Count;
            ViewBag.gelen = gelen;
            var giden = mm.GetListSendbox(userEmail).Count;
            ViewBag.giden = giden;
            var okundu = mm.MessageRead(userEmail).Count;
            ViewBag.okundu = okundu;
            var okunmadı = mm.MessageNoRead(userEmail).Count;
            ViewBag.okunmadı = okunmadı;
            return PartialView();

            ////toplam iletişim sayısı
            //var ContactNumbers = _context.Contacts.Count();
            //ViewBag.ContactNumbers = ContactNumbers;

            ////Toplam gelen mesaj sayısı
            //var GelenMesajSayisi = _context.Messages.Count(x => x.ReceiverMail == "admin2@gmail.com");
            //ViewBag.GelenMesajSayisi = GelenMesajSayisi;

            ////Toplam gönderilen mesaj sayısı
            //var GonderilenMesajSayisi = _context.Messages.Count(x => x.SenderMail == "admin2@gmail.com");
            //ViewBag.GonderilenMesajSayisi = GonderilenMesajSayisi;
            //return PartialView();


        }
    }
        
}