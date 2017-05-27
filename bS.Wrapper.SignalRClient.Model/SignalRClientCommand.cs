using bS.Wrapper.SignalRClient.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Wrapper.SignalRClient.Model
{
    public class SignalRClientCommand : ISignalRClientCommand
    {
        public string SignalServerHub { get; set; }
       
        public object[] SignalServerHubMethodParameters { get; set; }

        public string SignalServerHubMethodToCall { get; set; }
    }
}
