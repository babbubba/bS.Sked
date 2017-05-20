using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Model.Extra.Wrapper.SignalRClient
{
    public class SignalRClientContext : Interfaces.ISignalRClientContext
    {
        public string SignalServerUrl { get; set; }
    }
}
