using bS.Wrapper.SignalRClient.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Wrapper.SignalRClient.Model
{
    public class SignalRClientContext : ISignalRClientContext
    {
        public string SignalServerUrl { get; set; }
    }
}
