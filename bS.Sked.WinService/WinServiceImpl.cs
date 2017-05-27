using bS.Sked.CompositionRoot;
using bS.Sked.Model.Services.Interfaces;
using System.ServiceProcess;

namespace bS.Sked.WinService
{
    public partial class WinServiceImpl : ServiceBase
    {
        private readonly IWindowsServiceService service;
        private string WMCBaseUrl = "http://localhost:55393";

        public WinServiceImpl()
        {
            InitializeComponent();
            this.service = CR.Instance().Resolve<IWindowsServiceService>(); 
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
