using bS.Sked.Model.Interfaces.Entities.Base;
using bS.Sked.Model.Interfaces.Tasks;
using System.Collections.Generic;

namespace bS.Sked.Model.Interfaces.Elements
{
    public interface IExecutableElementModel : IPersisterEntity, IExecutableEntity, IHistoricalEntity, IToggledEntity, IDescribedEntity, IPositionalEntity, IParentsAlertEntity
    {
        IElementTypeModel ElementType { get; set; }
        IList<IElementInstanceModel> Instances { get; set; }
        ITaskModel Parent { get; set; }
    }
}
