using BusinessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
       ImageFileManager ifm = new ImageFileManager(new EfImageFileDal());
        public ActionResult Index()
        {
            var files = ifm.GetList();
            return View(files);
        }

        [HttpGet]
        public ActionResult ImageAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ImageAdd(ImageFile p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/AdminLTE-3.0.4/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.ImagePath = "/AdminLTE-3.0.4/Image/" + dosyaadi + uzanti;
                ifm.Add(p);
                return RedirectToAction("Index");
            }

            return View();

        }
    }
}