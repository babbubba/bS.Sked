using bs.Sked.Mapping;
using bS.Sked.Data.Interfaces;
using bS.Sked.Model.Interfaces.Entities.Base;
using bS.Sked.Models.Elements;
using bS.Sked.Models.Interfaces.Elements;
using bS.Sked.Services.Base;
using bS.Sked.ViewModel.Elements;
using bS.Sked.ViewModel.Interfaces.Elements;
using System;
using System.Collections.Generic;
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


        public IEnumerable<SmtpSettingViewModel> SmtpSettingsAll
        {
            get
            {
                return (Mapping.Map<IEnumerable<SmtpSettingViewModel>>(repository.GetQuery<ISmtpSettingModel>().ToArray())) ?? new List<SmtpSettingViewModel>();
            }
        }

        public SmtpSettingViewModel SmtpSettingsNew
        {
            get
            {
                return new SmtpSettingViewModel
                {
                    IsActive = true,
                    Name = "New Smtp Setting"
                };
            }
        }

        public SmtpSettingViewModel SmtpSettingsGet(string id)
        {
            return (Mapping.Map<SmtpSettingViewModel>(repository.GetQuery<ISmtpSettingModel>().SingleOrDefault(x => x.Id == Guid.Parse(id)))) ?? new SmtpSettingViewModel();
        }

        public void SmtpSettingsAdd(ISmtpSettingViewModel vM)
        {
            var t = repository.BeginTransaction();
            var model = Mapping.Map<SmtpSettingModel>(vM);
            repository.Add(model);
            t.Commit();
        }

        public void SmtpSettingsUpdate(ISmtpSettingViewModel vM)
        {
            var t = repository.BeginTransaction();
            var model = repository.GetQuery<SmtpSettingModel>().SingleOrDefault(x => x.Id == Guid.Parse(vM.Id));
            Mapping.Map(vM, model);
            repository.Update(model);
            t.Commit();
        }





    }
}
