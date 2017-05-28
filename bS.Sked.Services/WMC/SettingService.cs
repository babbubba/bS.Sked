using bS.Sked.Data.Interfaces;
using bS.Sked.Model.Interfaces.Entities.Base;
using bS.Sked.Models.Elements;
using bS.Sked.Models.Interfaces.Elements;
using bS.Sked.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Services.WMC
{
    public class SettingService : ServiceBase
    {
        private readonly IRepository<IPersisterEntity> repository;

        public SettingService(IRepository<IPersisterEntity> repository)
        {
            this.repository = repository;
        }

        public ISmtpSettingModel[] SmtpSettings
        {
            get
            {
                return repository.GetQuery<ISmtpSettingModel>().ToArray();
            }
        }

    }
}
