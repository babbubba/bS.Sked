using bS.Sked.Model.Interfaces.Entities.Base;
using bS.Sked.Models.Interfaces.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Models.Interfaces.MainObjects
{
    public interface IMainObjectTypeModel : IPersisterEntity, IDescribedEntity, IToggledEntity
    {
       string PersistingId { get; set; }
       string Properties { get; set; }
       string ReturnedProperties { get; set; }
       IList<IElementTypeModel> SupportedElementTypes { get; set; }
    }
}
      