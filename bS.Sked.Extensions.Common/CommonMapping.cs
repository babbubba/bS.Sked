using bs.Sked.Mapping;
using bS.Sked.CompositionRoot;
using bS.Sked.Data.Interfaces;
using bS.Sked.Extensions.Common.Model;
using bS.Sked.Extensions.Common.ViewModel;
using bS.Sked.Model.DTO;
using bS.Sked.Model.Elements;
using bS.Sked.Model.Elements.Properties;
using bS.Sked.Model.Interfaces.DTO;
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
            #region FromFlatFlieToTable Element

            //ViewModel -> Model (and reverse)
            CreateMap<FromFlatFlieToTableElementViewModel, FromFlatFlieToTableElementModel>()
                .BeforeMap((src, dest) =>
                {
                    if (src.InFileObjectId == null)
                    {
                        dest.InFileObject = new FileSystemFileModel { FileFullPath = src.InFileObjectFileFullPath };
                    }
                    else
                    {
                        var inputFileObj = repository.GetQuery<FileSystemFileModel>().SingleOrDefault(x => x.Id == Guid.Parse(src.InFileObjectId));
                        inputFileObj.FileFullPath = src.InFileObjectFileFullPath;
                        dest.InFileObject = inputFileObj;
                    }
                })
                .AfterMap((src, dest) =>
                {
                    dest.ElementType = repository.GetQuery<ElementTypeModel>().Single(x => x.PersistingId == src.ElementTypePersistingId);
                    dest.OutTableObject = new TableObjectModel();
                })
                .ReverseMap();

            // Properties Dictionary -> ViewModel
            CreateMap<Dictionary<string, IField>, FromFlatFlieToTableElementViewModel>()
                .AfterMap((src, dest) =>
                {
                    dest.Description = src.GetValue<string>("Description");
                    dest.ElementTypePersistingId = src.GetValue<string>("ElementTypePersistingId");
                    dest.InFileObjectFileFullPath = src.GetValue<string>("InFileObjectFileFullPath");
                    dest.InFileObjectId = src.GetValue<string>("InFileObjectId");
                    dest.IsActive = src.GetValue<bool>("IsActive");
                    dest.LimitToRows = src.GetValue<int>("LimitToRows");
                    dest.Name = src.GetValue<string>("Name");
                    dest.ParentId = src.GetValue<string>("ParentId");
                    dest.Position = src["Position"].GetValue<int>();
                    dest.SeparatorValue = src.GetValue<string>("SeparatorValue");
                    dest.SkipStartingRows = src.GetValue<int>("SkipStartingRows");
                    dest.StopParentIfErrorOccurs = src.GetValue<bool>("StopParentIfErrorOccurs");
                    dest.StopParentIfWarningOccurs = src.GetValue<bool>("StopParentIfWarningOccurs");
                });

            //  ViewModel -> Properties Dictionary 
            CreateMap<FromFlatFlieToTableElementViewModel, Dictionary<string, IField>>()
                .AfterMap((src, dest) =>
                {
                    if (dest == null) dest = new Dictionary<string, IField>();
                    dest.Add("Description", src.Description);
                    dest.Add("ElementTypePersistingId", src.ElementTypePersistingId);
                    dest.Add("InFileObjectFileFullPath", src.InFileObjectFileFullPath);
                    dest.Add("InFileObjectId", src.InFileObjectId);
                    dest.Add("IsActive", src.IsActive);
                    dest.Add("LimitToRows", src.LimitToRows);
                    dest.Add("Name", src.Name);
                    dest.Add("ParentId", src.ParentId);
                    dest.Add("Position", src.Position);
                    dest.Add("SeparatorValue", src.SeparatorValue);
                    dest.Add("SkipStartingRows", src.SkipStartingRows);
                    dest.Add("StopParentIfErrorOccurs", src.StopParentIfErrorOccurs);
                    dest.Add("StopParentIfWarningOccurs", src.StopParentIfWarningOccurs);
                });


            #endregion
        }
    }
}
