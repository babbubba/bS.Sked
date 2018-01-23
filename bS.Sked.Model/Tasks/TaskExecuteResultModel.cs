using bS.Sked.Model.Interfaces.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bS.Sked.Model.Interfaces.Entities.Base;

namespace bS.Sked.Model.Tasks
{
    /// <summary>
    /// The resultant message by Task Excecution
    /// </summary>
    /// <seealso cref="bS.Sked.Model.Interfaces.Tasks.ITaskExecuteResult" />
    public class TaskExecuteResultModel : ITaskExecuteResult
    {
        public bool IsSuccessfullyCompleted { get; set ; }
        public string Message { get; set; }
        public string[] Errors { get; set; }
        public string SourceId { get; set; }
        public MessageTypeEnum MessageType { get ; set ; }
    }
}
