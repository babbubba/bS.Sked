using bS.Sked.ViewModel.Elements.Base;

namespace bS.Sked.Extensions.Common.ViewModel
{
    public class FromFlatFlieToTableElementViewModel : ExecutableElementBaseViewModel
    {
        public int SkipStartingDataRows { get; set; }
        public string SeparatorValue { get; set; }
        public int LimitToRows { get; set; }
        public string InFileObjectFileFullPath { get; set; }
        public string InFileObjectId { get; set; }
        public bool FirstRowHasHeader { get; set; }


    }
}
