using System;
using bS.Sked.WMC.Model.Interfaces;

namespace bS.Sked.WMC.Model
{
    public class SidebarItemModel : ISidebarItemModel
    {
        public string Link { get; set; }
        public string Text { get; set; }
        public ISidebarItemLabelModel[] Labels { get; set; }
        public SidebarItemIcon Icon { get; set; }
        public Colours IconColour { get; set; }
        public Colours TextColour { get; set; }
        public ISidebarItemModel ParentItem { get; set; }
        public bool IsActive { get; set; }
        public bool IsDisabled { get; set; }
    }

  

  
}
