﻿using bs.Sked.Mapping;
using bS.Sked.Extensions.Common.Model;
using bS.Sked.Extensions.Common.ViewModel;
using bS.Sked.Model.Elements.Properties;
using bS.Sked.ViewModel.Interfaces.Elements.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Extensions.Common
{
    public class CommonMapping : MapProfileBase
    {
        public CommonMapping()
        {
            CreateMap<FromFlatFlieToTableElementViewModel, FromFlatFlieToTableElementModel>()
                .AfterMap((src, dest) =>
                {
                    dest.InFileObject = new FileSystemFileModel {  FileFullPath = src.InFileObjectFileFullPath };
                }
            )
                .ReverseMap();
            CreateMap<IExecutableElementBaseViewModel, FromFlatFlieToTableElementModel>().ReverseMap();

        }
    }
}
