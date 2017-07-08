using bS.Sked.ViewModel.Interfaces.Entities.Base;

namespace bS.Sked.ViewModel.Elements.Base
{
    public abstract class DescribedEntityBaseViewModel : IDescribedEntityViewModel
    {
        public virtual string Description { get; set; }
        public virtual string Name { get; set; }
    }
}
