using System.Collections;
using System.Collections.Generic;

namespace bS.Sked.ViewModel.Interfaces.Elements.Base
{
    public interface IExecutableElementBaseViewModel
    {
        string Description { get; set; }
        string ElementTypeId { get; set; }
        string ElementTypePersistingId { get; set; }
        bool IsActive { get; set; }
        string Name { get; set; }
        string ParentId { get; set; }
        int Position { get; set; }
        bool StopParentIfErrorOccurs { get; set; }
        bool StopParentIfWarningOccurs { get; set; }
    }
    
}