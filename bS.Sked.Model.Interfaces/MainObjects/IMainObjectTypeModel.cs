using bS.Sked.Model.Interfaces.Entities.Base;
using bS.Sked.Model.Interfaces.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Model.Interfaces.MainObjects
{
    public interface IMainObjectTypeModel : IPersisterEntity, IDescribedEntity, IToggledEntity
    {
       string PersistingId { get; set; }
       string InputProperties { get; set; }
       string OutputProperties { get; set; }
       IList<IElementTypeModel> SupportedElementTypes { get; set; }
    }
}
      