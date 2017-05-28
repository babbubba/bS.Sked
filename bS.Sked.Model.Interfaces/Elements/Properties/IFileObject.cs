using bS.Sked.Model.Interfaces.Entities.Base;
using System;
using System.Collections.Generic;

namespace bS.Sked.Models.Interfaces.Elements.Properties
{
    /// <summary>
    /// This rapresent the entity for a File that persist on the file system (actually)
    /// </summary>
    public interface IFileObject : IInterchangeablyEntity
    {
        string FileId { get; set; }
        string FileFullPath { get; set; }
        string CachedFullFilePath { get; set; }
        bool EnableCache { get; set; }
    }

    /// <summary>
    /// Elements that implements this interface need a file in the input chain for the execution. For example the element 'Import Table from CSV' need it.
    /// </summary>
    public interface IInputFileObject : IPropertyInterface
    {
        //IFileObject GetInputFileObject();
        //void SetInputFileObject(string inputFile, bool useCache = false);
        //void SetInputFileObject(IFileObject inputFile);
        IFileObject FileObject { get; set; }
    }

    /// <summary>
    /// Elements that implements this interface will return a file at the end of the execution.
    /// </summary>
    public interface IOutputFileObject : IPropertyInterface
    {
        //IFileObject GetOutputFileObject();
        //void SetOutputFileObject(string outputFile, bool useCache = false);
        //void SetOutputFileObject(IFileObject outputFile);
        IFileObject FileObject { get; set; }
    }

    /// <summary>
    /// The element that implement this interface will need one or more files in the input chain.
    /// </summary>
    public interface IInputFileObjectCollection : IPropertyInterface
    {
        //IEnumerable<IFileObject> GetInputFileObjects();
        //void SetInputFileObjects(IEnumerable<IFileObject> inputFiles);
        //Guid AddInputFileObjects(string inputFile, bool useCache = false);
        //void DeleteInputFileObjects(Guid inputfileId);
        //void ClearInputFiles();
        Dictionary<string, IFileObject> FileObjects { get; set; }
    }


    /// <summary>
    /// The element that implement this interface will return one or more files in the output chain.
    /// </summary>
    public interface IOutputFileObjectCollection : IPropertyInterface
    {
        //IEnumerable<IFileObject> GetOutputFileObjects();
        //Guid AddOutputFileObjects(string inputFile, bool useCache = false);
        //void DeleteOutputFileObjects(Guid inputfileId);
        //void ClearOutputFiles();
        Dictionary<string, IFileObject> FileObjects { get; set; }
    }
}
