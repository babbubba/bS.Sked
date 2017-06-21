using bS.Sked.Model.Interfaces.Core;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Model.Core
{
    public class UserModel : IUserModel
    {
        public virtual DateTime CreationDate { get; set; }

        public virtual string Description { get; set; }

        public virtual Guid Id { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual string Name { get; set; }

        public virtual string Password { get; set; }

        public virtual IList<IRoleModel> Roles { get; set; }

        public virtual DateTime? UpdateDate { get; set; }

        public virtual string UserName { get; set; }
    }

    class UserModelMap : ClassMap<UserModel>
    {
        public UserModelMap()
        {
            Table("Users");
            Id(x => x.Id).GeneratedBy.GuidComb().Column("Id");
            Map(x => x.CreationDate);
            Map(x => x.Description);
            HasMany<RoleModel>(x => x.Roles);//.KeyColumn("fkTaskId");
            Map(x => x.IsActive);
            Map(x => x.Name);
            Map(x => x.UpdateDate);
            Map(x => x.UserName);

        }

    }
}