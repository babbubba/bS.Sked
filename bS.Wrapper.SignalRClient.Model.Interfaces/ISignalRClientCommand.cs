﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Wrapper.SignalRClient.Model.Interfaces
{
    public interface ISignalRClientCommand
    {
        string SignalServerHub { get; set; }
        string SignalServerHubMethodToCall { get; set; }
        object[] SignalServerHubMethodParameters { get; set; }
    }
}
