using bS.Sked.Services.WMC;
using bS.Sked.WMC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bS.Sked.WMC.Controllers
{
    public class JobsController : Controller
    {
        private readonly JobService _jobService;

        public JobsController(JobService jobService)
        {
            this._jobService = jobService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(string id)
        {
            var vm = new JobDetailsViewModel();
            if (ModelState.IsValid)
            {
                try
                {
                    vm = _jobService.JobGetDetails(id);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(vm);
        }

        public ActionResult JobsTasks(string jobId)
        {
            var vm = new List<TaskTeaserViewModel>();
            if (ModelState.IsValid)
            {
                try
                {
                    vm = _jobService.JobGetTasks(jobId);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return PartialView("JobsTasks", vm);
        }

        // GET: Jobs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jobs/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Jobs/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Jobs/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Jobs/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Jobs/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
