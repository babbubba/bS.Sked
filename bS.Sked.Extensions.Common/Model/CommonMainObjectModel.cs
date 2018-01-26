using bS.Sked.Model.Interfaces.Modules;
using bS.Sked.Model.MainObjects.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bS.Sked.Model.Interfaces.MainObjects;
using FluentNHibernate.Mapping;
using bS.Sked.Model.Interfaces.Elements;

namespace bS.Sked.Extensions.Common.Model
{
    /// <summary>
    /// The Common Main Object used in the execution context o the elements implemented by Common Module.
    /// </summary>
    /// <seealso cref="bS.Sked.Model.MainObjects.Base.MainObjectBaseModel" />
    public class CommonMainObjectModel : MainObjectBaseModel
    {

        /// <summary>
        /// Finalizes the context.
        /// </summary>
        /// <returns></returns>
        public override bool FinalizeContext()
        {
            return true;
        }

        /// <summary>
        /// Initializes the context.
        /// </summary>
        /// <returns></returns>
        public override bool InitializeContext()
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
