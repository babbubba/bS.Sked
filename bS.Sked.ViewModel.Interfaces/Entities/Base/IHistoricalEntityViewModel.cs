using System;

namespace bS.Sked.ViewModel.Interfaces.Entities.Base
{
    public interface IHistoricalEntityViewModel
    {
        string CreationDate { get; set; }
        string UpdateDate { get; set; }
    }
}
