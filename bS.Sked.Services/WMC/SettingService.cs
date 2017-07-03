using bs.Sked.Mapping;
using bS.Sked.Data.Interfaces;
using bS.Sked.Model.Elements;
using bS.Sked.Model.Interfaces.Elements;
using bS.Sked.Model.Interfaces.Entities.Base;
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


        public IEnumerable<SmtpSettingViewModel> SmtpSettingsAll()
        {
            return (Mapping.Map<IEnumerable<SmtpSettingViewModel>>(repository.GetQuery<ISmtpSettingModel>().ToArray())) ?? new List<SmtpSettingViewModel>();
        }

        public SmtpSettingViewModel SmtpSettingsEmpty
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

            // Set as default if this is the first one
            if (!repository.GetQuery<ISmtpSettingModel>().Any()) model.IsDefault = true;

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

        public void SmtpSettingsDelete(string id)
        {
            var t = repository.BeginTransaction();
            var model = repository.GetQuery<SmtpSettingModel>().SingleOrDefault(x => x.Id == Guid.Parse(id));
            repository.Delete(model);

            // If only one SMTP Setting exists after deletion we set it as default
            if (repository.GetQuery<ISmtpSettingModel>().Count() == 1) repository.GetQuery<ISmtpSettingModel>().Single().IsDefault = true;

            t.Commit();


        }





    }
}
