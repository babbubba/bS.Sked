using bS.Sked.Model.Interfaces.Entities.Base;
using System;

namespace bS.Sked.Models.Interfaces.Application
{
    public interface ICommonModel : IPersisterEntity, IHistoricalEntity
    {
        string PluginFolder { get; set; }
    }
}
