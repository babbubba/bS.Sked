using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.WinService
{
    public partial class WinServiceImpl : ServiceBase
    {
        private string WMCBaseUrl = "http://localhost:55393";

        public WinServiceImpl()
        {
            InitializeComponent();
        }

        protected override async void OnStart(string[] args)
        {
          
        }

        protected override void OnStop()
        {
        }
    }
}
