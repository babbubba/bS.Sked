using bS.Sked.Model.Interfaces.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Model.Interfaces.Modules
{
    public interface IExtensionModule
    {
        bool IsSupported(IExecutableElementModel executableElement);
        IExtensionExecuteResult Execute(IExtensionContext context, IExecutableElementModel executableElement);
    }
}
