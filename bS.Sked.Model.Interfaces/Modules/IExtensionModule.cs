using bS.Sked.Models.Interfaces.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Model.Interfaces.Modules
{
    public interface IExtensionModule
    {
        bool CanExecute();
        IExtensionExecuteResult Execute(IExtensionContext context, IExecutableElementModel executableElement);
    }
}
