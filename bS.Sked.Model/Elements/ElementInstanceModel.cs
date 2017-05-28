using bS.Sked.Models.Elements.Base;
using bS.Sked.Models.Interfaces.Elements;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Models.Elements
{
    public class ElementInstanceModel : ExecutableInstanceModel   , IElementInstanceModel
    {
    }

    class ElementInstanceModelMap : SubclassMap<ElementInstanceModel>
    {
        public ElementInstanceModelMap()
        {
            DiscriminatorValue("ElementInstance");

        }
    }
}
