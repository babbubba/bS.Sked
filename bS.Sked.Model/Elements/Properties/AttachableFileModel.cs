using bS.Sked.Models.Interfaces.Elements.Properties;
using FluentNHibernate.Mapping;
using System;

namespace bS.Sked.Models.Elements.Properties
{
    public class AttachableFileModel : IAttachableFileModel
    {
        public virtual string CachedFullFilePath { get; set; }
        public virtual DateTime CreationDate { get; set; }
        public virtual bool EnableCache { get; set; }
        public virtual string FileFullPath { get; set; }
        public virtual string FileId { get; set; }
        public virtual Guid Id { get; set; }
        public virtual DateTime? UpdateDate { get; set; }
    }

    class AttachableFileModelMap : ClassMap<AttachableFileModel>
    {
        public AttachableFileModelMap()
        {
            Table("AttachableFiles");
            Id(x => x.Id).GeneratedBy.GuidComb().Column("Id");
            Map(x => x.CreationDate);
            Map(x => x.EnableCache);
            Map(x => x.FileFullPath);
            Map(x => x.FileId);
            Map(x => x.UpdateDate);
        }
    }
}
