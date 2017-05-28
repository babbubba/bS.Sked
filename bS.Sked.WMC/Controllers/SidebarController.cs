using bS.Sked.Services.WMC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bS.Sked.WMC.Controllers
{
    public class SidebarController : Controller
    {
        private readonly LeftSidebarService service;

        public SidebarController(LeftSidebarService service)
        {
            this.service = service;
        }
        // GET: Sidebar
        public PartialViewResult LeftSidebar()
        {
            return PartialView("_LeftSidebar", service.Items());
        }
    }
}