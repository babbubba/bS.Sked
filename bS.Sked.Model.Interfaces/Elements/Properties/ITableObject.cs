using bS.Sked.Model.Interfaces.Entities.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Model.Interfaces.Elements.Properties
{
    public interface ITableObject : IInterchangeablyEntity
    {
        DataTable Table { get; set; }
    }

    public interface IInputTableObject : IPropertyInterface
    {
        ITableObject InTableObject { get; set; }
    }

    public interface IOutputTableObject : IPropertyInterface
    {
        ITableObject OutTableObject { get; set; }
    }

    public interface IInputTableObjectCollection : IPropertyInterface
    {
        Dictionary<string, ITableObject> InTableObjects { get; set; }
    }
    public interface IOutputTableObjectCollection : IPropertyInterface
    {
        Dictionary<string, ITableObject> OutTableObjects { get; set; }
    }
}
