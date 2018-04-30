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
                    vm.Tasks = GetJobTasks(id);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error retrieving job: " + ex.GetBaseException().Message);
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
                    vm = GetJobTasks(jobId);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error retrieving job's tasks: " +  ex.GetBaseException().Message);
                }
            }
            return PartialView("JobsTasks", vm);
        }

        private List<TaskTeaserViewModel> GetJobTasks(string jobId)
        {
            return _jobService.JobGetTasks(jobId).OrderBy(x => x.Position).ToList();
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
