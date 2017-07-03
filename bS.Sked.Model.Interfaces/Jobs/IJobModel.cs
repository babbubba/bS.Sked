using bS.Sked.Model.Interfaces.Entities.Base;
using bS.Sked.Model.Interfaces.Elements;
using bS.Sked.Model.Interfaces.Tasks;
using bS.Sked.Model.Interfaces.Triggers;
using System;
using System.Collections.Generic;

namespace bS.Sked.Model.Interfaces.Jobs
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
