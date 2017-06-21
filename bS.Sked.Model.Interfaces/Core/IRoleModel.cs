using bS.Sked.Model.Interfaces.Entities.Base;

namespace bS.Sked.Model.Interfaces.Core
{
    public interface IRoleModel : IPersisterEntity, IHistoricalEntity, IDescribedEntity
    {
        string RoleName { get; set; }
    }
}