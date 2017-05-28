using bS.Sked.Model.Interfaces.Entities.Base;
using bS.Sked.Models.Interfaces.Tasks;
using System.Collections.Generic;

namespace bS.Sked.Models.Interfaces.Elements
{
    public interface IExecutableElementModel : IPersisterEntity, IExecutableEntity, IHistoricalEntity, IToggledEntity, IDescribedEntity, IPositionalEntity, IParentsAlertEntity
    {
        IElementTypeModel ElementType { get; set; }
        IList<IElementInstanceModel> Instances { get; set; }
        ITaskModel Parent { get; set; }
    }
}
