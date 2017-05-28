using bS.Sked.Model.Interfaces.Entities.Base;
using bS.Sked.Models.Interfaces.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Models.Interfaces.Triggers
{
    public interface ITriggerModel : IPersisterEntity, IHistoricalEntity, IToggledEntity, IDescribedEntity, IExecutableEntity
    {
        DateTime? NextExecutionDate { get; set; }
        IList<IJobModel> Jobs { get; set; }
        ITriggerTypeModel TriggerType { get; set; }
        string GetCron();

    }
}
