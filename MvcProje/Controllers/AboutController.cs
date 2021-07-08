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
    public class AboutController : Controller
    {

        AboutManager abm = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            var aboutvalues = abm.GetList();
            return View(aboutvalues);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(About p)
        {
            abm.AboutAdd(p);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }

        public ActionResult AktifveyaPasifDurum(int id)
        {
            var aboutValue = abm.GetByID(id);

            if (aboutValue.AboutStatus == true)
            {
                aboutValue.AboutStatus = false;
            }
            else
            {
                aboutValue.AboutStatus = true;
            }
            abm.AboutUpdate(aboutValue);
            return RedirectToAction("Index");
        }
    }
}