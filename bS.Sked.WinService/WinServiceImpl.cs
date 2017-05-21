﻿using bS.Sked.CompositionRoot;
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
        private readonly bS.Sked.Services.WindowsServiceService service;
        private string WMCBaseUrl = "http://localhost:55393";

        public WinServiceImpl()
        {
            InitializeComponent();
            //this.service = service;
            this.service = CR.SingletonInstance().Resolve<Services.WindowsServiceService>(); ;
        }

        protected override async void OnStart(string[] args)
        {

            service.StartService();

        }

        protected override void OnStop()
        {
        }
    }
}
