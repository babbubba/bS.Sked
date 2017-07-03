using bS.Sked.Model.Interfaces.Elements;
using FluentNHibernate.Mapping;
using System;

namespace bS.Sked.Model.Elements
{
    public class SmtpSettingModel :  ISmtpSettingModel
    {
        public virtual string Description { get; set; }
        public virtual Guid Id { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual bool IsAuthRequired { get; set; }
        public virtual bool IsDefault { get; set; }
        public virtual bool IsSslEnabled { get; set; }
        public virtual string Name { get; set; }
        public virtual string SmtpAccountPassword { get; set; }
        public virtual string SmtpAccountUsername { get; set; }
        public virtual string SmtpServerAddressOrIp { get; set; }
        public virtual int SmtpServerPort { get; set; }
    }

    class SmtpSettingModelMap : ClassMap<SmtpSettingModel>
    {
        public SmtpSettingModelMap()
        {
            Table("SmtpSettings");
            Id(x => x.Id).GeneratedBy.GuidComb().Column("Id");
            Map(x => x.Description);
            Map(x => x.IsActive);
            Map(x => x.IsAuthRequired);
            Map(x => x.IsDefault);
            Map(x => x.IsSslEnabled);
            Map(x => x.Name);
            Map(x => x.SmtpAccountPassword);
            Map(x => x.SmtpAccountUsername);
            Map(x => x.SmtpServerAddressOrIp);
            Map(x => x.SmtpServerPort);
        }
    }
}
