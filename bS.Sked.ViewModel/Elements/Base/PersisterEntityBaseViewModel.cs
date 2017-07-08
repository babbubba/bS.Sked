using bS.Sked.ViewModel.Interfaces.Entities.Base;

namespace bS.Sked.ViewModel.Elements.Base
{
    public abstract class PersisterEntityBaseViewModel : IPersisterEntityViewModel
    {
        public virtual string Id { get; set; }
    }
}
