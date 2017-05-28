using bS.Sked.WMC.Model.Interfaces;

namespace bS.Sked.WMC.Model
{
    public class SidebarItemLabelModel : ISidebarItemLabelModel
    {
        public SidebarItemLabelModel()
        {
            ElementType = "label";
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
