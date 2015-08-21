using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            var db = new QuestionRecordsEntities();
            var data = db.QuestionMasters.Select(a => new QuestionDisplay()
            {
                QuestionEn = a.QueTitleEng,
                QuestionHI = a.QueTitleHindi,
                Options = a.QuestionDetails.ToList()
            }).ToList();


            return View(data);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}