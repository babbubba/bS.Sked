﻿using bS.Sked.Model.Interfaces.Entities.Base;

namespace bS.Sked.Model.Interfaces.Elements
{
    public interface IElementTypeModel : IPersisterEntity, IToggledEntity, IDescribedEntity, IPositionalEntity
    {
        string PersistingId { get; set; }
        string InputProperties { get; set; }
        string OutputProperties { get; set; }
    }
}
