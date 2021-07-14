using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messagevalidator = new MessageValidator();

        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];
            var MessageList = mm.GetListInbox(p);

            return View(MessageList);
        }

        public ActionResult Sendbox()
        {
            string p = (string)Session["WriterMail"];
            var messagelist = mm.GetListSendbox(p);
            return View(messagelist);
        }

        public ActionResult ReadMessage(string p)
        {
            string userEmail = (string)Session["WriterMail"];
            p = userEmail;
            var messagelist = mm.MessageRead(p);
            return View(messagelist);

        }

        public ActionResult NoReadMessage(string p)
        {
            string userEmail = (string)Session["WriterMail"];
            p = userEmail;
            var messagelist = mm.MessageNoRead(p);
            return View(messagelist);
        }

        public PartialViewResult MessageListMenu()
        {
            string userEmail = (string)Session["WriterMail"];
            var gelen = mm.GetListInbox(userEmail).Count;
            ViewBag.gelen = gelen;
            var giden = mm.GetListSendbox(userEmail).Count;
            ViewBag.giden = giden;
            var okundu = mm.MessageRead(userEmail).Count;
            ViewBag.okundu = okundu;
            var okunmadı = mm.MessageNoRead(userEmail).Count;
            ViewBag.okunmadı = okunmadı;
            return PartialView();
        }

        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);

        }
        public ActionResult Okundu(int id)
        {
            var values = mm.GetByID(id);
            values.MessageRead = true;
            mm.MessageUpdate(values);
            return RedirectToAction("Inbox");
        }

        public ActionResult GetSendboxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);

        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();

        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            string sender = (string)Session["WriterMail"];
            ValidationResult results = messagevalidator.Validate(p);
            if (results.IsValid)
            {
                p.SenderMail = sender;
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString().ToString());
                mm.MessageAdd(p);
                return RedirectToAction("SendBox");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }


    }
}