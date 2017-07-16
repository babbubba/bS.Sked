using bS.Sked.ViewModel.Elements.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Extensions.Common.ViewModel
{
    public class FromFlatFlieToTableElementViewModel : ExecutableElementBaseViewModel
    {
        public int SkipStartingRows { get; set; }
        public string SeparatorValue { get; set; }
        public int LimitToRows { get; set; }
        public string InFileObjectFileFullPath { get; set; }
        public string InFileObjectId { get; set; }

    }
}
