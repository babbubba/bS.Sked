using bS.Sked.Model.Interfaces.Elements.Properties;
using bS.Sked.Model.Interfaces.Entities.Base;
using System.Collections.Generic;

namespace bS.Sked.Model.Interfaces.Elements
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
