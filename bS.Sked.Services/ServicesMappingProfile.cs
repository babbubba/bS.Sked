using bs.Sked.Mapping;
using bS.Sked.Model.Elements;
using bS.Sked.Model.Interfaces.Elements;
using bS.Sked.ViewModel.Elements;

namespace bS.Sked.Services
{
    public class ServicesMappingProfile : MapProfileBase
    {
        public ServicesMappingProfile()
        {

            CreateMap<SmtpSettingViewModel, SmtpSettingModel>();
            CreateMap<SmtpSettingViewModel, ISmtpSettingModel>().ReverseMap();

            CreateMap<Model.Elements.Base.ExecutableElementBaseModel, ViewModel.Interfaces.Elements.Base.IExecutableElementBaseViewModel>();

        }
    }
}
