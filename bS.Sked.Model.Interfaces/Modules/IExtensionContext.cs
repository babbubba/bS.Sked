using bS.Sked.Model.Interfaces.MainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Model.Interfaces.Modules
{
    public interface IExtensionContext
    {
        /// <summary>
        /// This initialize the context if needed. It will be executed only the first time it has called.
        /// </summary>
        /// <returns>it returns true if initialization succes or if it was already initialized otherwise it returns false.</returns>
        bool InitializeContext();
        bool FinalizeContext();

        string ExtensionContextTypePID { get; set; }

        IMainObjectModel MainObject { get; set; }
    }
}
