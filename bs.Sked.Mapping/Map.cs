using AutoMapper;
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
            Mapper.Initialize(config =>
            {
                //  config.ShouldMapField = fi => false;

                config.CreateMap<SmtpSettingViewModel, SmtpSettingModel>();
                config.CreateMap<SmtpSettingViewModel, ISmtpSettingModel>().ReverseMap();

            });
        }

        public static TDestination Map<TDestination>(object source) => AutoMapper.Mapper.Map<TDestination>(source);

        public static TDestination Map<TDestination>(object source, TDestination target)
        {
            return AutoMapper.Mapper.Map(source, target);
        }
        public static object Map(object source, Type sourceType, Type destinationType) => AutoMapper.Mapper.Map(source, sourceType, destinationType);


    }

    public class GuidTypeConverter : ITypeConverter<string, Guid>
    {
        public Guid Convert(string source, Guid destination, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source)) return Guid.NewGuid();
            return Guid.Parse(source);
        }
    }
}
