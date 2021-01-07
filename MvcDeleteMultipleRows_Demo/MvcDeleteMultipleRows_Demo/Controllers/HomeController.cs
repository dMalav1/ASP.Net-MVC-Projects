using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDeleteMultipleRows_Demo.Models;

namespace MvcDeleteMultipleRows_Demo.Controllers
{
    public class HomeController : Controller
    {
        private DBModel db = new DBModel();

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.ListEmployee = this.db.Employees.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection formCollection)
        {
            string[] ids = formCollection["ID"].Split(new char[] { ',' });
            foreach (string id in ids)
            {
                var employee = this.db.Employees.Find(int.Parse(id));
                this.db.Employees.Remove(employee);
                this.db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}