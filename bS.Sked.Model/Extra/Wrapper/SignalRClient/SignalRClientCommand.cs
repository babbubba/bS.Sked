using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Model.Extra.Wrapper.SignalRClient
{
    public class SignalRClientCommand : Interfaces.ISignalRClientCommand
    {
        public string SignalServerHub { get; set; }
       
        public object[] SignalServerHubMethodParameters { get; set; }

        public string SignalServerHubMethodToCall { get; set; }
    }
}
