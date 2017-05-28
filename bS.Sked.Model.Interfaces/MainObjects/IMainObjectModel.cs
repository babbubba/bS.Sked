using bS.Sked.Model.Interfaces.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Models.Interfaces.MainObjects
{
    public interface IMainObjectModel : IPersisterEntity  , IToggledEntity, IDescribedEntity, IHistoricalEntity
    {
        IMainObjectTypeModel MainObjectType { get; set; }
    }
}
