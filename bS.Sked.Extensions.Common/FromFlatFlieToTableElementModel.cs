using bS.Sked.Model.Elements.Base;
using bS.Sked.Model.Elements.Properties;
using bS.Sked.Model.Interfaces.Elements.Properties;
using FluentNHibernate.Mapping;

namespace bS.Sked.Extensions.Common
{
    public class FromFlatFlieToTableElementModel : ExecutableElementBaseModel, IInputFileObject
    {
        public virtual string SourceFile { get; set; }
        public virtual int SkipFirstRows { get; set; }
        public virtual string SeparatorValue { get; set; }
        public virtual int LimitToRows { get; set; }
        public virtual IFileObject FileObject { get; set; }
    }

    class FromFlatFlieToTableElementModelMap : SubclassMap<FromFlatFlieToTableElementModel>
    {
        public FromFlatFlieToTableElementModelMap()
        {
            DiscriminatorValue(CommonInitializer.fromFlatFlieToTable);
            Map(x => x.SourceFile);
            Map(x => x.SkipFirstRows);
            Map(x => x.SeparatorValue);
            Map(x => x.LimitToRows);
            References<FileSystemFileModel>(x => x.FileObject);
        }
    }

}
