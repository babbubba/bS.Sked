using bS.Sked.Model.Interfaces.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Model.Interfaces.Triggers
{
    public interface ITriggerTypeModel : IPersisterEntity, IToggledEntity, IDescribedEntity, IPositionalEntity
    {
        string PersistingId { get; set; }
    }
}
