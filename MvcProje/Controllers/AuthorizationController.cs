using BusinessLayer.Concrete;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class AuthorizationController : Controller
    {
        AdminManager adminmanager= new AdminManager(new EfAdminDal());
        RoleManager roleManager = new RoleManager(new EfRoleDal());
        Context _context = new Context();
        public ActionResult Index()
        {
            var adminvalues = adminmanager.GetList();
            return View(adminvalues);
        }

        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            List<SelectListItem> valueadminrole = (from c in roleManager.GetRoles()
                                                   select new SelectListItem
                                                   {
                                                       Text = c.RoleName,
                                                       Value = c.RoleId.ToString()

                                                   }).ToList();

            ViewBag.valueadmin = valueadminrole;

            var adminvalue = adminmanager.GetByID(id);
            return View(adminvalue);
        }
        [HttpPost]
        public ActionResult EditAdmin(Admin admin)
        {
            admin.AdminStatus = true;
            adminmanager.AdminUpdate(admin);
            return RedirectToAction("Index");
        }
    }
}



        //[HttpGet]
        //public ActionResult AddAdmin()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult AddAdmin(Admin p)
        //{
        //    adminmanager.AdminAdd(p);
        //    return RedirectToAction("Index");
        //}



        //[HttpGet]
        //public ActionResult EditAdmin(int id)
        //{
        //    var adminvalue = adminmanager.GetByID(id);
        //    return View(adminvalue);
        //}

        //[HttpPost]
        //public ActionResult EditAdmin(Admin p)
        //{
        //    adminmanager.AdminUpdate(p);
        //    return RedirectToAction("Index");
        //}
//    }
//}