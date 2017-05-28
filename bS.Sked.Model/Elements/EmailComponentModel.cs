using bS.Sked.Models.Interfaces.Elements;
using bS.Sked.Models.Interfaces.Elements.Properties;
using FluentNHibernate.Mapping;
using System.Collections.Generic;
using System;
using bS.Sked.Models.Elements.Properties;

namespace bS.Sked.Models.Elements
{
    public class EmailComponentModel : IEmailComponentModel
    {
        public virtual bool AttachFromParent { get; set; }
        public virtual IList<IFileObject> Attachments { get; set; }
        public virtual Guid Id { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual string Message { get; set; }
        public virtual int Priority { get; set; }
        public virtual string RecipientsCC { get; set; }
        public virtual string RecipientsCCN { get; set; }
        public virtual string RecipientsTo { get; set; }
        public virtual string Sender { get; set; }
        public virtual ISmtpSettingModel SmtpSetting { get; set; }
        public virtual string Subject { get; set; }
    }

    class EmailComponentModelMap : ClassMap<EmailComponentModel>
    {
        public EmailComponentModelMap()
        {
            Table("EmailComponents");
            Id(x => x.Id).GeneratedBy.GuidComb().Column("Id");
            Map(x => x.AttachFromParent);
            HasMany<AttachableFileModel>(x => x.Attachments);
            Map(x => x.IsActive);
            Map(x => x.Message);
            Map(x => x.Priority);
            Map(x => x.RecipientsCC);
            Map(x => x.RecipientsCCN);
            Map(x => x.RecipientsTo);
            Map(x => x.Sender);
            References<SmtpSettingModel>(x => x.SmtpSetting);
            Map(x => x.Subject);

        }
    }
}
