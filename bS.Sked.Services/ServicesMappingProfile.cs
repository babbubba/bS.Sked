using bs.Sked.Mapping;
using bS.Sked.Model.Elements;
using bS.Sked.Model.Interfaces.Elements;
using bS.Sked.Model.Jobs;
using bS.Sked.Model.Tasks;
using bS.Sked.ViewModel.Elements;
using bS.Sked.WMC.ViewModel;

namespace bS.Sked.Services
{
    public class ServicesMappingProfile : MapProfileBase
    {
        public ServicesMappingProfile()
        {

            CreateMap<SmtpSettingViewModel, SmtpSettingModel>();
            CreateMap<SmtpSettingViewModel, ISmtpSettingModel>().ReverseMap();

            CreateMap<Model.Elements.Base.ExecutableElementBaseModel, ViewModel.Interfaces.Elements.Base.IExecutableElementBaseViewModel>();


            CreateMap<JobModel, JobTeaserViewModel>();
            CreateMap<JobModel, JobAddViewModel>().ReverseMap();

            CreateMap<JobModel, JobDetailsViewModel>();
            CreateMap<TaskModel, TaskTeaserViewModel>();

        }
    }
}
