using bS.Sked.Model.Interfaces.Entities.Base;
using bS.Sked.Models.Interfaces.Elements;
using bS.Sked.Models.Interfaces.Jobs;
using bS.Sked.Models.Interfaces.MainObjects;
using System.Collections.Generic;

namespace bS.Sked.Models.Interfaces.Tasks
{
    public interface ITaskModel  : IPersisterEntity, IExecutableEntity, IHistoricalEntity, IToggledEntity, IDescribedEntity, IPositionalEntity, IParentsAlertEntity
    {
        IList<IExecutableElementModel> Elements { get; set; }
        IList<ITaskInstanceModel> Instances { get; set; }
        IMainObjectModel MainObject { get; set; }
        IJobModel ParentJob { get; set; }
    }

   
}
