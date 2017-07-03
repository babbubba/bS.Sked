/*
    The MIT License (MIT)

    Copyright (c) 2017 Fabio Cavallari (fcavallari@bsoft.it)

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in
    all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    THE SOFTWARE.

    (http://opensource.org/licenses/mit-license.php)
*/

using AutoMapper;
using bS.Sked.Model.Elements;
using bS.Sked.Model.Interfaces.Elements;
using bS.Sked.ViewModel.Elements;
using System;
using System.Linq;

namespace bs.Sked.Mapping
{
    public static class Mapping
    {
        public static void RegisterMappings()
        {
            var tc = AppDomain.CurrentDomain.GetAssemblies();
            var profileAssemblies = from p in AppDomain.CurrentDomain.GetAssemblies()
                                    where p.FullName.Contains(".Services")
                                    select p;
            Mapper.Initialize(config =>
            {
                // Add all assemblies with profiles in the assemblies
                config.AddProfiles(profileAssemblies.ToArray());

                // Extra optional default mapping
                //config.CreateMap<xxxSource, xxxDestination>();
                //config.CreateMap<xxxSource, xxxDestination>().ReverseMap();
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
