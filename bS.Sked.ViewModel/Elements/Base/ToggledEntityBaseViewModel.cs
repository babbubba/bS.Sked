using bS.Sked.ViewModel.Interfaces.Entities.Base;
using System.ComponentModel;

namespace bS.Sked.ViewModel.Elements.Base
{
    public abstract class ToggledEntityBaseViewModel : IToggledEntityViewModel
    {
        [DisplayName("Is active")]
        public virtual bool IsActive { get; set; }
    }
}
