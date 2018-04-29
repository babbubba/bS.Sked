using System;

namespace bS.Sked.WMC.ViewModel
{
    public class JobTeaserViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime LastExecution { get; set; }
        public bool IsActive { get; set; }
        public virtual int Position { get; set; }
    }
}
