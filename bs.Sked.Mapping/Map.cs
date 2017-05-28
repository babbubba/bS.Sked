using bS.Sked.Models.Elements;
using bS.Sked.Models.Interfaces.Elements;
using bS.Sked.ViewModel.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bs.Sked.Mapping
{
    public static class Mapping
    {


        public static void RegisterMappings()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.ShouldMapField = fi => false;

            config.CreateMap<SmtpSettingViewModel, ISmtpSettingModel>().ReverseMap();

            });
        }

        public static TDestination Map<TDestination>(object source) => AutoMapper.Mapper.Map<TDestination>(source);

        public static object Map(object source, Type sourceType, Type destinationType) => AutoMapper.Mapper.Map(source, sourceType, destinationType);
    }
}
