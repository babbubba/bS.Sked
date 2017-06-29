using bs.Sked.Mapping;
using bS.Sked.Models.Elements;
using bS.Sked.Models.Interfaces.Elements;
using bS.Sked.ViewModel.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Services
{
    public class ServicesMappingProfile : MapProfileBase
    {
        public ServicesMappingProfile()
        {

            CreateMap<SmtpSettingViewModel, SmtpSettingModel>();
            CreateMap<SmtpSettingViewModel, ISmtpSettingModel>().ReverseMap();
        }
    }
}
