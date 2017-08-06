using bS.Sked.Model.Interfaces.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Model.Jobs
{
    public class JobExecuteResultModel : IJobExecuteResult
    {
        public bool IsSuccessfullyCompleted { get; set; }
        public string Message { get; set; }
        public string[] Errors { get; set; }
        public string SourceId { get; set; }
    }
}
