using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        Context c = new Context();
        public ActionResult Index()
        {
            var q1 = c.Categories.Count().ToString();
            ViewBag.totalcat = q1;

            var q2 = c.Headings.Where(x => x.CategoryID == 19).Count().ToString();
            ViewBag.Totalheadingaboutyazilim = q2;

            var q3 = c.Writers.Where(x => x.WriterName.Contains("a") || x.WriterSurname.Contains("a")).Count().ToString();
            ViewBag.aharfigecenyazar = q3;

            var q4 = c.Headings.GroupBy(x => x.CategoryID).Where(x => x.Count() > 1).OrderByDescending(x => x.Count()).Select(x => x.Key).FirstOrDefault();
            var q4value = c.Categories.Where(x => x.CategoryID == q4).Select(x=>x.CategoryName).FirstOrDefault();
            ViewBag.enfazlabasligasahipkategori = q4value;

            var q5true = c.Categories.Where(x => x.CategoryStatus == true).Count();
            var q5false = c.Categories.Where(x => x.CategoryStatus == false).Count();

            ViewBag.fark = q5true-q5false;
            return View();
        }
    }
}