using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.WMC.Model.Interfaces
{
    public interface ISidebarItemModel   : ISidebarItemBase
    {
        SidebarItemIcon Icon { get; set; }
        Colours IconColour { get; set; }
        ISidebarItemLabelModel[] Labels { get; set; }
        string Link { get; set; }
        ISidebarItemModel ParentItem { get; set; }
        bool IsActive { get; set; }
        bool IsDisabled { get; set; }
    }
}
