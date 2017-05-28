using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.ViewModel.Interfaces.Entities.Base
{
   public interface IParentsAlertEntityViewModel
    {
        bool StopParentIfErrorOccurs { get; set; }
        bool StopParentIfWarningOccurs { get; set; }
    }
}
