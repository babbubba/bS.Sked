using System;
using System.Collections.Generic;
using bS.Sked.Models.Interfaces.Elements;
using bS.Sked.Models.Interfaces.Tasks;
using FluentNHibernate.Mapping;

namespace bS.Sked.Models.Elements.Base
{
    /// <summary>
    /// Base abstracted class for all the executing element of the Application
    /// </summary>
    public abstract class ExecutableElementBaseModel : IExecutableElementModel
    {
        /// <summary>
        /// The date of creation for this entity
        /// </summary>
        public virtual DateTime CreationDate { get; set; }
        public virtual string Description { get; set; }
        /// <summary>
        /// The element type
        /// </summary>
        public virtual IElementTypeModel ElementType { get; set; }
        public virtual Guid Id { get; set; }
        /// <summary>
        /// A list of instances of this element. 
        /// </summary>
        public virtual IList<IElementInstanceModel> Instances { get; set; }
        public virtual bool IsActive { get; set; }
        /// <summary>
        /// Last time when this element has been executed (anyway, if an instance is still running, this value indicates the last instance finish date)
        /// </summary>
        public virtual DateTime LastExecution { get; set; }
        public virtual string Name { get; set; }
        public virtual ITaskModel Parent { get; set; }
        public virtual int Position { get; set; }
        public virtual bool StopParentIfErrorOccurs { get; set; }
        public virtual bool StopParentIfWarningOccurs { get; set; }
        /// <summary>
        /// Last time the persister record for this entity was updated.
        /// </summary>
        public virtual DateTime? UpdateDate { get; set; }

    
    }

    class ExecutableElementBaseModelMap : ClassMap<ExecutableElementBaseModel>
    {
        public ExecutableElementBaseModelMap()
        {
            Table(nameof(Elements));
            Id(x => x.Id).GeneratedBy.GuidComb().Column("Id");
            Map(x => x.CreationDate);
            Map(x => x.Description);
            References<ElementTypeModel>(x => x.ElementType).Not.Nullable();
            HasMany<ElementInstanceModel>(x => x.Instances);//.KeyColumn("fkElementId");
            Map(x => x.IsActive);
            Map(x => x.LastExecution);
            Map(x => x.Name).Not.Nullable(); 
            Map(x => x.Position);
            Map(x => x.StopParentIfErrorOccurs);
            Map(x => x.StopParentIfWarningOccurs);
            Map(x => x.UpdateDate);
            DiscriminateSubClassesOnColumn("ElementTypePID");
        }
    }
}
