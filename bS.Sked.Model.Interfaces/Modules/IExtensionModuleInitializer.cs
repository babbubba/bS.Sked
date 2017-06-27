namespace bS.Sked.Model.Interfaces.Modules
{
    public interface IExtensionModuleInitializer
    {
        string[] SupportedElements { get; set; }
        bool InitElementTypes();
        bool InitContextTypes();

    }
}
