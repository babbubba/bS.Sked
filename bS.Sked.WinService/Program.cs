using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.WinService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            var service = new bS.Sked.Services.WindowsServiceService();

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new WinServiceImpl(service)
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
