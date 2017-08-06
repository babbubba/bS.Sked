using bS.Sked.Model.Interfaces.Modules;
using bS.Sked.Model.MainObjects.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bS.Sked.Model.Interfaces.MainObjects;

namespace bS.Sked.Extensions.Common.Model
{
    public class CommonMainObjectModel : MainObjectBaseModel, IExtensionContext
    {
        public CommonMainObjectModel()
        {
            //TODO: Questa non dovrebbe essere utilizzata! Piuttosto usa il MainObject type che dovrebbe esistere nel db!
            ExtensionContextTypePID = StaticContent.commonMainObject;
        }

        public string ExtensionContextTypePID { get; set; }
        public IMainObjectModel MainObject { get; set; }

        public bool FinalizeContext()
        {
            return true;
        }

        public bool InitializeContext()
        {
            return true;
        }


    }
}
