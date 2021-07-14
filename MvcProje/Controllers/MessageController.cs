using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
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
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messagevalidator = new MessageValidator();
       
        [Authorize]
        public ActionResult Inbox(string p)
        {
            string userEmail = (string)Session["AdminUserName"];
            p = userEmail;
            var messagelist = mm.GetListInbox(p);
            return View(messagelist);
        }
        public ActionResult ReadMessage(string p)
        {
            string userEmail = (string)Session["AdminUserName"];
            p = userEmail;
            var messagelist = mm.MessageRead(p);
            return View(messagelist);

        }
        public ActionResult Sendbox(string p)
        {
            string userEmail = (string)Session["AdminUserName"];
            p = userEmail;
            var messagelist = mm.GetListSendbox(p);
            return View(messagelist);
        }
        public ActionResult NoReadMessage(string p)
        {
            string userEmail = (string)Session["AdminUserName"];
            p = userEmail;
            var messagelist = mm.MessageNoRead(p);
            return View(messagelist);
        }
        public ActionResult GetInBoxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }

        public ActionResult GetSendBoxMessageDetails(int id)
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
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            ValidationResult results = messagevalidator.Validate(p);
            if (results.IsValid)
            {
                string userEmail = (string)Session["AdminUserName"];
                p.SenderMail = userEmail;
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAdd(p);
                return RedirectToAction("SendBox");
            }
            else
            {
                foreach (var x in results.Errors)
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }
            }
            return View();
        }



    }
}