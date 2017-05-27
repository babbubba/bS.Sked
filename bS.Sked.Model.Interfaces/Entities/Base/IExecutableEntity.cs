using System;

namespace bS.Sked.Model.Interfaces.Entities.Base
{
    public interface IExecutableEntity
    {
        DateTime LastExecution { get; set; }
    }
}
