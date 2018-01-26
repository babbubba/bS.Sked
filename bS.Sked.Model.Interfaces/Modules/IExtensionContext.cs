using bS.Sked.Model.Interfaces.MainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Model.Interfaces.Modules
{
    /// <summary>
    /// The Extension's execution context (tha handle the Task's Main Object)
    /// </summary>
    public interface IExtensionContext
    {
        ///// <summary>
        ///// Initialize the context if needed. It has to be executed only the first time it has called.
        ///// </summary>
        ///// <returns>It returns true if initialization succes or if it was already initialized otherwise it returns false.</returns>
        //bool InitializeContext();
        ///// <summary>
        ///// Finalizes the context.
        ///// </summary>
        ///// <returns></returns>
        //bool FinalizeContext();

        ///// <summary>
        ///// Gets or sets the extension context type persisting identifier.
        ///// </summary>
        ///// <value>
        ///// The extension context type pid.
        ///// </value>
        //string ExtensionContextTypePID { get; set; }

        ///// <summary>
        ///// Gets or sets the main object that this context owns.
        ///// </summary>
        ///// <value>
        ///// The main object.
        ///// </value>
        //IMainObjectModel MainObject { get; set; }

        ///// <summary>
        ///// Gets or sets the elements in this context.
        ///// </summary>
        ///// <value>
        ///// The elements.
        ///// </value>
        //IList<Elements.IExecutableElementModel> Elements { get; set; }
    }
}
