using bS.Sked.Model.Interfaces.DTO;
using bS.Sked.Model.Interfaces.Elements;
using bS.Sked.ViewModel.Interfaces.Elements.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Model.Interfaces.Modules
{
    public interface IExtensionModule
    {
        bool IsSupported(string executableElementPersistingId);
        bool IsImplemented(string executableElementPersistingId);
        IExtensionExecuteResult Execute(IExtensionContext context, IExecutableElementModel executableElement);
        [Obsolete(message:"Use AddElement instead.")]
        IExecutableElementBaseViewModel AddNewElement(IExecutableElementBaseViewModel element);
        IExecutableElementBaseViewModel AddElement(string elementPID, IDictionary<string, IField> properties);

    }
}
