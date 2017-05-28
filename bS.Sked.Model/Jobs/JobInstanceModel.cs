using bS.Sked.Models.Elements.Base;
using bS.Sked.Models.Interfaces.Jobs;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Models.Jobs
{
    public class JobInstanceModel : ExecutableInstanceModel, IJobInstanceModel
    {
    }

    class JobInstanceModelMap : SubclassMap<JobInstanceModel>
    {
        public JobInstanceModelMap()
        {
            DiscriminatorValue("JobInstance");
        }
    }
}
