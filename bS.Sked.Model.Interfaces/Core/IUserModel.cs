using bS.Sked.Model.Interfaces.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Model.Interfaces.Core
{
    public interface IUserModel      : IPersisterEntity,  IHistoricalEntity, IToggledEntity, IDescribedEntity
    {
        string UserName { get; set; }
        string Password { get; set; }
        IList<IRoleModel> Roles { get; set; }
    }
}
