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


        Context _context = new Context();
        ContactManager cm = new ContactManager(new EfContactDal());
        MessageManager mm = new MessageManager(new EfMessageDal());
        DraftManager draftManager = new DraftManager(new EfDraftDal());
       

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


            string p = (string)Session["WriterMail"];
            var writeridinfo = _context.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();

            var receiverMail = _context.Messages.Count(m => m.ReceiverMail == p).ToString();
            ViewBag.receiverMail = receiverMail;

            var senderMail = _context.Messages.Count(m => m.SenderMail == p).ToString();
            ViewBag.senderMail = senderMail;

            var contact = _context.Contacts.Count().ToString();
            ViewBag.contact = contact;

            var draft = _context.Drafts.Count().ToString();
            ViewBag.draft = draft;

            var readMessage = mm.GetList().Count();
            ViewBag.readMessage = readMessage;

            var unReadMessage = mm.GetListUnRead().Count();
            ViewBag.unReadMessage = unReadMessage;

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