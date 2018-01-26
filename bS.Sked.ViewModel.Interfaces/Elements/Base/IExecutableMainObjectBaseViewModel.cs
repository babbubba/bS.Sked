using System.Collections;
using System.Collections.Generic;

namespace bS.Sked.ViewModel.Interfaces.Elements.Base
{
    public interface IExecutableMainObjectBaseViewModel
    {
        string Description { get; set; }
        string MainObjectTypeId { get; set; }
        string MainObjectTypePersistingId { get; set; }
        bool IsActive { get; set; }
        string Name { get; set; }
        string Id { get; set; }
    }
    
}