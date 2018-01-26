using bS.Sked.ViewModel.Interfaces.Elements.Base;
using System;

namespace bS.Sked.ViewModel.Elements.Base
{
    public class ExecutableMainObjectBaseViewModel : IExecutableMainObjectBaseViewModel
    {
        public ExecutableMainObjectBaseViewModel()
        {
            Id = Guid.Empty.ToString();
        }

        public string Id { get; set; }
        public string Description { get; set; }
        public string MainObjectTypeId { get; set; }
        public string MainObjectTypePersistingId { get; set; }
        public virtual bool IsActive { get; set; }
        public string Name { get; set; }
    }
}
