using bS.Sked.Model.Interfaces.Modules;
using bS.Sked.Model.MainObjects.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bS.Sked.Model.Interfaces.MainObjects;
using FluentNHibernate.Mapping;


namespace bS.Sked.Extensions.Common.Model
{
    /// <summary>
    /// The Common Main Object used in the execution context o the elements implemented by Common Module.
    /// </summary>
    /// <seealso cref="bS.Sked.Model.MainObjects.Base.MainObjectBaseModel" />
    /// <seealso cref="bS.Sked.Model.Interfaces.Modules.IExtensionContext" />
    public class CommonMainObjectModel : MainObjectBaseModel, IExtensionContext
    {
        public CommonMainObjectModel()
        {
            ExtensionContextTypePID = StaticContent.commonMainObject;
            //ExtensionContextTypePID = this.MainObjectType.PersistingId;
        }

        public virtual string ExtensionContextTypePID { get; set; }
        public virtual IMainObjectModel MainObject { get; set; }

        public virtual bool FinalizeContext()
        {
            return true;
        }

        public virtual bool InitializeContext()
        {
            return true;
        }


    }
    class CommonMainObjectModelMap : SubclassMap<CommonMainObjectModel>
    {
        public CommonMainObjectModelMap()
        {
            DiscriminatorValue(StaticContent.commonMainObject);

        }

    }
}
