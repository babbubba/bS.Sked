using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Models.Interfaces.Elements
{
    /// <summary>
    /// The interfacers that will implement this interface will rapresenting Entities with a specific direction (Input or Output) and a single or collection resultant type.
    /// For example an element that will be return a table will implement an Interface called IOutputTable (or IOutputTableCollection if it returns many tables) 
    /// that will implements this interface.
    /// Used for reflection, remind to add it if u add new Entities at the domain.
    /// </summary>
    public interface IPropertyInterface
    {
    }
}
