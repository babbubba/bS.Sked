using bS.Sked.ViewModel.Interfaces.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.ViewModel.Elements.Base
{
    public abstract class PersisterToggledDescribedEnityBaseVieModel : IPersisterEntityViewModel, IToggledEntityViewModel, IDescribedEntityViewModel
    {
        protected PersisterToggledDescribedEnityBaseVieModel()
        {
            Id = Guid.Empty.ToString();
        }
        public virtual string Id { get; set; }
        [DisplayName("Is active")]
        public virtual bool IsActive { get; set; }
        public virtual string Description { get; set; }
        public virtual string Name { get; set; }
    }
}
