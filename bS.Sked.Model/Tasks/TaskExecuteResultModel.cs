using bS.Sked.Model.Interfaces.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bS.Sked.Model.Interfaces.Entities.Base;
using bS.Sked.Model.Elements.Base;
using FluentNHibernate.Mapping;

namespace bS.Sked.Model.Tasks
{
    /// <summary>
    /// The resultant message by Task Excecution
    /// </summary>
    /// <seealso cref="bS.Sked.Model.Interfaces.Tasks.ITaskExecuteResult" />
    public class TaskExecuteResultModel : ExecuteResultBaseModel,  ITaskExecuteResult
    {

    }

    class TaskExecuteResultModelMap : SubclassMap<TaskExecuteResultModel>
    {
        public TaskExecuteResultModelMap()
        {
            DiscriminatorValue("TaskInstanceMessage");

        }
    }
}
