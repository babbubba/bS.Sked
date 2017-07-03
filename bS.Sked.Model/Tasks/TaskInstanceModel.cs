using bS.Sked.Model.Elements.Base;
using bS.Sked.Model.Interfaces.Tasks;
using FluentNHibernate.Mapping;

namespace bS.Sked.Model.Tasks
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
