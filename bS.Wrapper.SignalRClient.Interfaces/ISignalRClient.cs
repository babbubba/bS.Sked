using bS.Wrapper.SignalRClient.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Wrapper.SignalRClient.Interfaces
{
    public interface ISignalRClient
    {
        Task SendMessageAsync(ISignalRClientCommand command);
    }
}
