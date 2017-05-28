using System;
using bS.Sked.WMC.Model.Interfaces;

namespace bS.Sked.WMC.Model
{
    public class SidebarItemHeaderModel : ISidebarItemHeaderModel
    {
        public SidebarItemHeaderModel()
        {
            ElementType = "header";
        }
        public string ElementType { get; }
        public string TextColourString
        {
            get
            {
                return TextColour.ToString();
            }
        }
        public string Text { get; set; }
        public Colours TextColour { get; set; }
    }
}
