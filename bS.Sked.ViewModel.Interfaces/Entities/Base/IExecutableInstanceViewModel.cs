using System;

namespace bS.Sked.ViewModel.Interfaces.Entities.Base
{
    public interface IExecutableInstanceModel : IPersisterEntityViewModel, IExecutableEntityViewModel
    {
        DateTime? StartTime { get; set; }
        DateTime? EndTime { get; set; }
        bool IsSuccessfullyCompleted { get; set; }
        int HasErrors { get; set; }
        int HasWarnings { get; set; }
        int Progress { get; set; }
        string PersistingFullPath { get; set; }
    }
}
