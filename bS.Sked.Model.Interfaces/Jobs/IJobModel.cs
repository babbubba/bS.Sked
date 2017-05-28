using bS.Sked.Model.Interfaces.Entities.Base;
using bS.Sked.Models.Interfaces.Elements;
using bS.Sked.Models.Interfaces.Tasks;
using bS.Sked.Models.Interfaces.Triggers;
using System;
using System.Collections.Generic;

namespace bS.Sked.Models.Interfaces.Jobs
{
    public interface IJobModel : IPersisterEntity, IExecutableEntity, IHistoricalEntity, IToggledEntity, IDescribedEntity, IPositionalEntity
    {
      bool IsExecuting { get; set; }
      IList<ITaskModel> Tasks { get; set; }
      IList<IJobInstanceModel> Instances { get; set; }
      IEmailComponentModel EmailComponent { get; set; }
      IList<ITriggerModel> Triggers { get; set; }
      DateTime? NextExecutionDate { get; set; }
    }
}
