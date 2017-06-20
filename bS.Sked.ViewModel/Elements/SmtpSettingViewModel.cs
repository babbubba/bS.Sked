using bS.Sked.ViewModel.Elements.Base;
using bS.Sked.ViewModel.Interfaces.Elements;
using bS.Sked.ViewModel.Interfaces.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.ViewModel.Elements
{
    public class SmtpSettingViewModel : PersisterToggledDescribedEnityBaseVieModel,  ISmtpSettingViewModel
    {
        [DisplayName("Is auth required")]
        public virtual bool IsAuthRequired { get; set; }
        [DisplayName("Is default")]
        public virtual bool IsDefault { get; set; }
        [DisplayName("Use SSL")]
        public virtual bool IsSslEnabled { get; set; }
        [DisplayName("Smtp password")]
        public virtual string SmtpAccountPassword { get; set; }
        [DisplayName("Smtp account")]
        public virtual string SmtpAccountUsername { get; set; }
        [DisplayName("Smtp server address or ip")]
        public virtual string SmtpServerAddressOrIp { get; set; }
        [DisplayName("Smtp server port")]
        public virtual int SmtpServerPort { get; set; }
    }
}


namespace bS.Sked.ViewModel.Elements.Base
{
    public abstract class PersisterEntityBaseViewModel : IPersisterEntityViewModel
    {
        public virtual string Id { get; set; }
    }

    public abstract class ToggledEntityBaseViewModel : IToggledEntityViewModel
    {
        [DisplayName("Is active")]
        public virtual bool IsActive { get; set; }
    }

    public abstract class DescribedEntityBaseViewModel : IDescribedEntityViewModel
    {
        public virtual string Description { get; set; }
        public virtual string Name { get; set; }
    }

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