using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MathewProject.Models;
using MathewProject.ViewModels;

namespace MathewProject.Controllers
{
    public class HomeController : Controller
    {
        private DiocesanDBEntities db = new DiocesanDBEntities();
        public ActionResult Index()
        {
            var viewmodel = new HomeViewModel();
            viewmodel.HomeCath = db.Cathedrals;
            viewmodel.HomeNews = db.Infoes.Where(x => x.InfoType.Equals("News"));
            viewmodel.HomeEvent = db.Infoes.Where(x => x.InfoType.Equals("Event"));
            viewmodel.HomeAnnouncement = db.Infoes.Where(x => x.InfoType.Equals("Announcement"));
            return View(viewmodel);
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "About the Catholic Diocess of Nsukka. . .";
            var viewmodel = new HomeViewModel();
            viewmodel.HomeCath = db.Cathedrals;
            return View(viewmodel);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact the Catholic Diocess of Nsukka!";

            return View();
        }
    }
}