using bS.Sked.Model.Elements.Base;
using bS.Sked.Model.Interfaces.Elements;
using FluentNHibernate.Mapping;

namespace bS.Sked.Model.Elements
{
    public class ElementInstanceModel : ExecutableInstanceModel, IElementInstanceModel
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
