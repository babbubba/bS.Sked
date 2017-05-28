using bS.Sked.Model.Interfaces.Entities.Base;
using bS.Sked.Models.Interfaces.Elements.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Models.Interfaces.Elements
{
    public interface IEmailComponentModel : IPersisterEntity, IToggledEntity
    {
       bool AttachFromParent { get; set; }
       IList<IFileObject> Attachments { get; set; }
       string Message { get; set; }
       int Priority { get; set; }
       string RecipientsCC { get; set; }
       string RecipientsCCN { get; set; }
       string RecipientsTo { get; set; }
       string Sender { get; set; }
       ISmtpSettingModel SmtpSetting { get; set; }
       string Subject { get; set; }
    }
}
