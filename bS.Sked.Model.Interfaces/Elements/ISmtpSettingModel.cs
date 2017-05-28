using bS.Sked.Model.Interfaces.Entities.Base;
using System;

namespace bS.Sked.Models.Interfaces.Elements
{
    public interface ISmtpSettingModel : IPersisterEntity, IDescribedEntity, IToggledEntity
    {
        bool IsAuthRequired { get; set; }
        bool IsDefault { get; set; }
        bool IsSslEnabled { get; set; }
        string SmtpAccountPassword { get; set; }
        string SmtpAccountUsername { get; set; }
        string SmtpServerAddressOrIp { get; set; }
        int SmtpServerPort { get; set; }
    }
}