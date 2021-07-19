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
    public class TalentController : Controller
    {

        TalentManager tm = new TalentManager(new EfTalentDal());
        public ActionResult Index()
        {
            var values = tm.GetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Talent talent)
        {
            tm.TalentAdd(talent);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var result = tm.GetByID(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Update(Talent talent)
        {
            tm.TalentUpdate(talent);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var result = tm.GetByID(id);
            tm.TalentDelete(result);
            return RedirectToAction("Index");
        }
    }
}