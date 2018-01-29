using System;
using System.Collections.Generic;

namespace bS.Sked.Model.Interfaces.Entities.Base
{
    public interface IExecutableInstanceModel : IPersisterEntity, IExecutableEntity
    {
        DateTime? StartTime { get; set; }
        DateTime? EndTime { get; set; }
        bool IsSuccessfullyCompleted { get; set; }
        int HasErrors { get; set; }
        int HasWarnings { get; set; }
        int Progress { get; set; }
        string PersistingFullPath { get; set; }
        IList<IExecuteResult> ResultMessages { get; set; }
    }
}
