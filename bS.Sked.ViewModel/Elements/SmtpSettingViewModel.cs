using bS.Sked.ViewModel.Elements.Base;
using bS.Sked.ViewModel.Interfaces.Elements;
using bS.Sked.ViewModel.Interfaces.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.ViewModel.Elements
{
    public class SmtpSettingViewModel : PersisterToggledDescribedEnityBaseVieModel,  ISmtpSettingViewModel
    {
        public virtual bool IsAuthRequired { get; set; }
        public virtual bool IsDefault { get; set; }
        public virtual bool IsSslEnabled { get; set; }
        public virtual string SmtpAccountPassword { get; set; }
        public virtual string SmtpAccountUsername { get; set; }
        public virtual string SmtpServerAddressOrIp { get; set; }
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
        public virtual bool IsActive { get; set; }
    }

    public abstract class DescribedEntityBaseViewModel : IDescribedEntityViewModel
    {
        public virtual string Description { get; set; }
        public virtual string Name { get; set; }
    }

    public abstract class PersisterToggledDescribedEnityBaseVieModel : IPersisterEntityViewModel, IToggledEntityViewModel, IDescribedEntityViewModel
    {
        public virtual string Id { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual string Description { get; set; }
        public virtual string Name { get; set; }
    }
}