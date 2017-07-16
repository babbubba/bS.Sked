using bS.Sked.ViewModel.Interfaces.Elements.Base;
using System;

namespace bS.Sked.ViewModel.Elements.Base
{
    public class ExecutableElementBaseViewModel : IExecutableElementBaseViewModel
    {
        public ExecutableElementBaseViewModel()
        {
            Id = Guid.Empty.ToString();
        }

        public string Id { get; set; }
        public string Description { get; set; }
        public string ElementTypeId { get; set; }
        public string ElementTypePersistingId { get; set; }
        public virtual bool IsActive { get; set; }
        public string Name { get; set; }
        public string ParentId { get; set; }
        public int Position { get; set; }
        public bool StopParentIfErrorOccurs { get; set; }
        public bool StopParentIfWarningOccurs { get; set; }
    }
}
