using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Model.Interfaces.Modules
{
public  interface IExtensionExecuteResult
    {
        bool IsSuccessfullyCompleted { get; set; }
        string Message { get; set; }
        string[] Errors { get; set; }
}
}
