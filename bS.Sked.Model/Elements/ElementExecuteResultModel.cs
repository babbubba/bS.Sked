using bS.Sked.Model.Elements.Base;
using bS.Sked.Model.Interfaces.Elements;
using FluentNHibernate.Mapping;

namespace bS.Sked.Model.Elements
{
    public class ElementExecuteResultModel : ExecuteResultBaseModel, IElementExecuteResult
    {
      
    }

    class ElementExecuteResultModelMap : SubclassMap<ElementExecuteResultModel>
    {
        public ElementExecuteResultModelMap()
        {
            DiscriminatorValue("ElementInstanceMessage");

        }
    }
}
