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

