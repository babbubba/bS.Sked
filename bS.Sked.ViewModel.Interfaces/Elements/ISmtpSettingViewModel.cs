using bS.Sked.ViewModel.Interfaces.Entities.Base;

namespace bS.Sked.ViewModel.Interfaces.Elements
{
    public interface ISmtpSettingViewModel    : IPersisterEntityViewModel, IDescribedEntityViewModel, IToggledEntityViewModel
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
