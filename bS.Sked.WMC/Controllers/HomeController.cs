using Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bS.Sked.WMC.Controllers
{
    public class HomeController : Controller
    {
        private static ILog log = LogManager.GetLogger<HomeController>();
        public HomeController()
        {
        }
        public ActionResult Index()
        {
            log.Debug("Entrato in Home");
            return View();
        }

        public ActionResult Dashboard()
        {
            log.Debug("Entrato in Dashboard");

            return View();
        }
    }
}