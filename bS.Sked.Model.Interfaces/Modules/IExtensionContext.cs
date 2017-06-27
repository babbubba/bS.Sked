using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Model.Interfaces.Modules
{
    public interface IExtensionContext
    {
        bool InitializeContext();
        bool FinalizeContext();
    }
}
