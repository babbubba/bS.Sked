using System;

namespace bS.Sked.Model.Interfaces.Entities.Base
{
    public interface IHistoricalEntity
    {
        DateTime CreationDate { get; set; }
        DateTime? UpdateDate { get; set; }
    }
}
