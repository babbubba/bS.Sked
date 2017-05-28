using bS.Sked.Models.Elements.Base;
using bS.Sked.Models.Interfaces.Tasks;
using FluentNHibernate.Mapping;

namespace bS.Sked.Models.Tasks
{
    public class TaskInstanceModel : ExecutableInstanceModel, ITaskInstanceModel
    {
    }

    class TaskInstanceModelMap : SubclassMap<TaskInstanceModel>
    {
        public TaskInstanceModelMap()
        {
            DiscriminatorValue("TaskInstance");
        }
    }
}
