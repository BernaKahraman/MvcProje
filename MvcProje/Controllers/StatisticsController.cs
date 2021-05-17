using DataAccsessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics

        Context c = new Context();
        public ActionResult Index()
        {
            //Toplam kategori sayısı
            var deger1 = c.Categories.Count().ToString();
            ViewBag.CategoryCount = deger1;

            //Başlık tablosunda "yazılım" kategorisine ait başlık sayısı
            var deger2 = c.Headings.Count(x => x.Category.CategoryName == "Yazılım");
            ViewBag.Heading = deger2;

            //Yazar adında 'a' harfi geçen yazar sayısı
            var deger3 = c.Writers.Count(x => x.WriterName.Contains("a"));
            ViewBag.Writer = deger3;

            //En fazla başlığa sahip kategori adı
            var deger4 = c.Categories.Where(x => x.CategoryID == c.Headings.GroupBy(a => a.CategoryID).OrderByDescending(a => a.Count()).Select(a => a.Key).FirstOrDefault()).Select(x => x.CategoryName).FirstOrDefault();
            ViewBag.HeadingMax = deger4;

            //Kategori tablosunda durumu true olan kategoriler ile false olan kategoriler arasındaki sayısal fark
            var difference = c.Categories.Count(m => m.CategoryStatus == true) - c.Categories.Count(m => m.CategoryStatus == false);
            ViewBag.StatusDiffrerent = difference;


            return View();
           
        }
    }
}