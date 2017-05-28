using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.WMC.Model.Interfaces
{
    public interface ISidebarItemBase
    {
        string Text { get; set; }
        Colours TextColour { get; set; }
    }
}
