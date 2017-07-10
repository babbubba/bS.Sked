using bs.Sked.Mapping;
using bS.Sked.CompositionRoot;
using bS.Sked.Data.Interfaces;
using bS.Sked.Extensions.Common.Model;
using bS.Sked.Extensions.Common.ViewModel;
using bS.Sked.Model.Elements;
using bS.Sked.Model.Elements.Properties;
using bS.Sked.Model.Interfaces.Entities.Base;
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
            var repository = CompositionRoot.CompositionRoot.Instance().Resolve<IRepository<IPersisterEntity>>();

            //CreateMap<IExecutableElementBaseViewModel, FromFlatFlieToTableElementModel>()
            //     .AfterMap((src, dest) =>
            //     {
            //         dest.ElementType = repository.GetQuery<ElementTypeModel>().Single(x => x.PersistingId == src.ElementTypePersistingId);
            //     });

            CreateMap<FromFlatFlieToTableElementViewModel, FromFlatFlieToTableElementModel>()
                .AfterMap((src, dest) =>
                {
                    dest.InFileObject = new FileSystemFileModel {  FileFullPath = src.InFileObjectFileFullPath };
                    dest.ElementType = repository.GetQuery<ElementTypeModel>().Single(x => x.PersistingId == src.ElementTypePersistingId);
                    dest.OutTableObject = new TableObjectModel();
                })
                .ReverseMap();

            //CreateMap<IExecutableElementBaseViewModel, FromFlatFlieToTableElementModel>().ReverseMap();

        }
    }
}
