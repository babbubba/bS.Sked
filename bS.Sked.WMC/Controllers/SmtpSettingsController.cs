using bS.Sked.Services.WMC;
using bS.Sked.ViewModel.Elements;
using bS.Sked.ViewModel.Interfaces.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bS.Sked.WMC.Controllers
{
    public class SmtpSettingsController : Controller
    {
        SettingService service;
        public SmtpSettingsController(SettingService service)
        {
            this.service = service;
        }
        // GET: Settings
        public ActionResult Index()
        {
            return View(service.SmtpSettingsAll);
        }

        public ActionResult Details(string id)
        {
            return View(service.SmtpSettingsGet(id));
        }


        public ActionResult Create()
        {
            return View(service.SmtpSettingsNew);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SmtpSettingViewModel vM)
        {
            try
            {
                service.SmtpSettingsAdd(vM);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(vM);
            }
            return View("Details", vM);         
        }


        public ActionResult Edit(string id)
        {
            return View(service.SmtpSettingsGet(id));
            //return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SmtpSettingViewModel vM)
        {
            try
            {
                service.SmtpSettingsUpdate(vM);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(vM);
            }
            return View("Details", vM);
        }
    }
}