using BusinessLayer.Concrete;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content

        ContentManager cm = new ContentManager(new EfContentDal());
        public ActionResult Index()
        {
            return View();
        }

       
        public ActionResult GetAllContent(string p)
        {
            var values = cm.GetList(p);
            
            //var values = c.Contents.ToList();
            return View(values);
        }

        public ActionResult ContentByHeading(int id)
        {
            //bir id göre listeleme işlemi yapıcak
            var contentvalues = cm.GetListByHeadingID(id);
            return View(contentvalues);
        }
    }
}