using bS.Sked.Data.Interfaces;
using bS.Sked.Model.Interfaces.Entities.Base;
using bS.Sked.Models.Interfaces.Jobs;
using bS.Sked.Services.Base;
using bS.Sked.WMC.Model.Interfaces;
using Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Services.WMC
{
    public class LeftSidebarService    : ServiceBase
    {
        private readonly IRepository<IPersisterEntity> repository;

        public LeftSidebarService(IRepository<IPersisterEntity> repository)
        {
            this.repository = repository;
        }
        public ISidebarItemBase[] Items()
        {
            var aResult = new List<ISidebarItemBase>();

            var query = repository.GetQuery<IJobModel>();


            return aResult.ToArray();
        }
    }

   
}
