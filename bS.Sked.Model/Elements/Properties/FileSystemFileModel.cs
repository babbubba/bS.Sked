using bS.Sked.Model.Interfaces.Elements.Properties;
using FluentNHibernate.Mapping;
using System;

namespace bS.Sked.Model.Elements.Properties
{
    public class FileSystemFileModel : IFileSystemFileModel
    {
        public virtual DateTime CreationDate { get; set; }
        public virtual string FileFullPath { get; set; }
        public virtual string FilePersistingId { get; set; }
        public virtual Guid Id { get; set; }
        public virtual DateTime? UpdateDate { get; set; }
    }

    class FileSystemFileModelMap : ClassMap<FileSystemFileModel>
    {
        public FileSystemFileModelMap()
        {
            Table("FileSystemFiles");
            Id(x => x.Id).GeneratedBy.GuidComb().Column("Id");
            Map(x => x.CreationDate);
            Map(x => x.FileFullPath);
            Map(x => x.FilePersistingId);
            Map(x => x.UpdateDate);
        }
    }
}
