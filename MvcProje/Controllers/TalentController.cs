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

    }
}