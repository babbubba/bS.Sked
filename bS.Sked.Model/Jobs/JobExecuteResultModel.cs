using bS.Sked.Model.Interfaces.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bS.Sked.Model.Interfaces.Entities.Base;
using bS.Sked.Model.Elements.Base;
using FluentNHibernate.Mapping;

namespace bS.Sked.Model.Jobs
{
    public class JobExecuteResultModel : ExecuteResultBaseModel, IJobExecuteResult
    {
     
    }

    class JobExecuteResultModelMap : SubclassMap<JobExecuteResultModel>
    {
        public JobExecuteResultModelMap()
        {
            DiscriminatorValue("JobInstanceMessage");

        }
    }
}
