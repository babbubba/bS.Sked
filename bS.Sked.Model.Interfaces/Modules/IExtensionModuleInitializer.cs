using System.Collections.Generic;

namespace bS.Sked.Model.Interfaces.Modules
{
    public interface IExtensionModuleInitializer
    {
        Dictionary<string, string> SupportedElements { get; set; }
        bool InitElementTypes();
        bool InitContextTypes();

    }
}
