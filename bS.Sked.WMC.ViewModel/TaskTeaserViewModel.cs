using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace bS.Sked.WMC.ViewModel
{
    public class TaskTeaserViewModel
    {

        public virtual DateTime CreationDate { get; set; }
        //public virtual string Description { get; set; }
        //public virtual IList<IExecutableElementModel> Elements { get; set; }
        public virtual string Id { get; set; }
        //public virtual IList<ITaskInstanceModel> Instances { get; set; }
        public virtual bool IsActive { get; set; }
        [Display(Name = "Last Execution")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy HH:mm}")]
        public virtual DateTime LastExecution { get; set; }
        public virtual string MainObjectName { get; set; }
        public virtual string Name { get; set; }
        public virtual string ParentJobId { get; set; }
        public virtual int Position { get; set; }
        //public virtual bool StopParentIfErrorOccurs { get; set; }
        //public virtual bool StopParentIfWarningOccurs { get; set; }
        //public virtual DateTime? UpdateDate { get; set; }
    }
}
