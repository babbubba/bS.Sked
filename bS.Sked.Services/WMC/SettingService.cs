using bs.Sked.Mapping;
using bS.Sked.Data.Interfaces;
using bS.Sked.Model.Interfaces.Entities.Base;
using bS.Sked.Models.Interfaces.Elements;
using bS.Sked.Services.Base;
using bS.Sked.ViewModel.Interfaces.Elements;
using System.Linq;

namespace bS.Sked.Services.WMC
{
    public class SettingService : ServiceBase
    {
        private readonly IRepository<IPersisterEntity> repository;

        public SettingService(IRepository<IPersisterEntity> repository)
        {
            this.repository = repository;
        }


        public ISmtpSettingViewModel[] SmtpSettingsAll => Mapping.Map<ISmtpSettingViewModel[]>(repository.GetQuery<ISmtpSettingModel>().ToArray());

        public void SmtpSettingsAdd(ISmtpSettingViewModel vM)
        {
            var t = repository.BeginTransaction();
            repository.Add(Mapping.Map<ISmtpSettingModel>(vM));
            t.Commit();
        }





    }
}
