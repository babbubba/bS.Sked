using bS.Sked.Model.Interfaces.Modules;
using bS.Sked.Model.MainObjects.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Extensions.Common
{
    public class CommonMainObjectModel : MainObjectBaseModel, IExtensionContext
    {

        public bool FinalizeContext()
        {
            throw new NotImplementedException();
        }

        public bool InitializeContext()
        {
            throw new NotImplementedException();
        }
    }
}
