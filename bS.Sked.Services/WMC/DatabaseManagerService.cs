using bS.Sked.Model.Interfaces.Modules;
using bS.Sked.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Services.WMC
{
    public class DatabaseManagerService : ServiceBase
    {
        private IEnumerable<IExtensionModuleInitializer> _initializers;

        public DatabaseManagerService(IEnumerable<IExtensionModuleInitializer> initializers)
        {
            _initializers = initializers;
        }
        public bool InitOrUpdateDatabase()
        {
            foreach (var initializer in _initializers)
            {
              //  var suppElements = initializer.SupportedElements;
                initializer.InitElementTypes();
                initializer.InitContextTypes();
            }
            return true;
        }
    }
}
