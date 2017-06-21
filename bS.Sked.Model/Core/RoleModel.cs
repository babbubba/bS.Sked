using bS.Sked.Model.Interfaces.Core;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Model.Core
{
    public class RoleModel : IRoleModel
    {
        public virtual DateTime CreationDate
        {
            get; set;
        }

        public virtual string Description
        {
            get; set;
        }

        public virtual string RoleName
        {
            get; set;
        }

        public virtual Guid Id
        {
            get; set;
        }

        public virtual string Name
        {
            get; set;
        }

        public virtual DateTime? UpdateDate
        {
            get; set;
        }
    }

    class RoleModelMap : ClassMap<RoleModel>
    {
        public RoleModelMap()
        {
            Table("Roles");
            Id(x => x.Id).GeneratedBy.GuidComb().Column("Id");
            Map(x => x.CreationDate);
            Map(x => x.Description);
            Map(x => x.Name);
            Map(x => x.UpdateDate);
            Map(x => x.RoleName);

        }

    }
}
