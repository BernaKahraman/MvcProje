using BusinessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class DraftController : Controller
    {
        DraftManager draftManager = new DraftManager(new EfDraftDal());

        // GET: Draft
        public ActionResult Draft()
        {
            var draftValues = draftManager.GetList();
            return View(draftValues);
        }

        public ActionResult GetDraftDetails(int id)
        {
            var draftValue = draftManager.GetByID(id);
            return View(draftValue);
        }

        [HttpGet]
        public ActionResult AddDraft()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDraft(Draft draft)
        {
            draft.DraftDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            draftManager.DraftAdd(draft);
            return RedirectToAction("Draft");
        }
    }
}