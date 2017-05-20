using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Model.Extra.Wrapper.SignalRClient.Interfaces
{
    public interface ISignalRClientCommand
    {
        string SignalServerHub { get; set; }
        string SignalServerHubMethodToCall { get; set; }
        object[] SignalServerHubMethodParameters { get; set; }
    }
}
