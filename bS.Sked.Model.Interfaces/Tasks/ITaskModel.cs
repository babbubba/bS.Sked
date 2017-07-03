using bS.Sked.Model.Interfaces.Entities.Base;
using bS.Sked.Model.Interfaces.Elements;
using bS.Sked.Model.Interfaces.Jobs;
using bS.Sked.Model.Interfaces.MainObjects;
using System.Collections.Generic;

namespace bS.Sked.Model.Interfaces.Tasks
{
    public interface ITaskModel  : IPersisterEntity, IExecutableEntity, IHistoricalEntity, IToggledEntity, IDescribedEntity, IPositionalEntity, IParentsAlertEntity
    {
        IList<IExecutableElementModel> Elements { get; set; }
        IList<ITaskInstanceModel> Instances { get; set; }
        IMainObjectModel MainObject { get; set; }
        IJobModel ParentJob { get; set; }
    }

   
}
