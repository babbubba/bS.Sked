using bS.Sked.WMC.Model.Interfaces;
using System.Collections.Generic;

namespace bS.Sked.WMC.Model.Interfaces
{
    public interface ISidebarItemTreeViewModel   : ISidebarItemBase
    {
        IList<ISidebarItemBase> Children { get; set; }
        SidebarItemIcon Icon { get; set; }
        Colours IconColour { get; set; }
        bool IsActive { get; set; }
        bool IsDisabled { get; set; }
        ISidebarItemLabelModel[] Labels { get; set; }
    }
}