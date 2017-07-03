using bS.Sked.Model.Interfaces.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Model.Modules
{
    public class ExtensionExecuteResult : IExtensionExecuteResult
    {
        public bool IsSuccessfullyCompleted { get; set; }
        public string Message { get; set; }
        public string[] Errors { get; set; }
    }
}
