using bS.Sked.Model.Interfaces.Entities.Base;

namespace bS.Sked.Models.Interfaces.Elements
{
    public interface IElementTypeModel : IPersisterEntity, IToggledEntity, IDescribedEntity, IPositionalEntity
    {
        string PersistingId { get; set; }
    }
}
