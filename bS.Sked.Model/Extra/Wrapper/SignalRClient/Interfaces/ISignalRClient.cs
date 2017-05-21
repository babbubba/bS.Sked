using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Model.Extra.Wrapper.SignalRClient.Interfaces
{
    public interface ISignalRClient
    {
        Task SendMessageAsync(ISignalRClientCommand command);
    }
}
