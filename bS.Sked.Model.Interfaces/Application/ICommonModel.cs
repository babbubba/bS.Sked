using bS.Sked.Model.Interfaces.Entities.Base;
using System;

namespace bS.Sked.Model.Interfaces.Application
{
    public interface ICommonModel : IPersisterEntity, IHistoricalEntity
    {
        string PluginFolder { get; set; }
    }
}
