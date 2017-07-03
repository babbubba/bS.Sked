using bS.Sked.Model.Interfaces.Entities.Base;
using System.Collections.Generic;

namespace bS.Sked.Model.Interfaces.Elements.Properties
{
    /// <summary>
    /// This rapresent the entity for a File that persist on the file system (at the moment)
    /// </summary>
    public interface IFileObject : IInterchangeablyEntity
    {
        string FilePersistingId { get; set; }
        string FileFullPath { get; set; }
    }

    /// <summary>
    /// Elements that implements this interface need a file in the input chain for the execution. For example the element 'Import Table from CSV' need it.
    /// </summary>
    public interface IInputFileObject : IPropertyInterface
    {
        IFileObject FileObject { get; set; }
    }

    /// <summary>
    /// Elements that implements this interface will return a file at the end of the execution.
    /// </summary>
    public interface IOutputFileObject : IPropertyInterface
    {
        IFileObject FileObject { get; set; }
    }

    /// <summary>
    /// The element that implement this interface will need one or more files in the input chain.
    /// </summary>
    public interface IInputFileObjectCollection : IPropertyInterface
    {
        Dictionary<string, IFileObject> FileObjects { get; set; }
    }


    /// <summary>
    /// The element that implement this interface will return one or more files in the output chain.
    /// </summary>
    public interface IOutputFileObjectCollection : IPropertyInterface
    {
        Dictionary<string, IFileObject> FileObjects { get; set; }
    }
}
