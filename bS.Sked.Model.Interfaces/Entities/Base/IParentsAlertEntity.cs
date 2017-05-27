using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Model.Interfaces.Entities.Base
{
   public interface IParentsAlertEntity
    {
        bool StopParentIfErrorOccurs { get; set; }
        bool StopParentIfWarningOccurs { get; set; }
    }
}
