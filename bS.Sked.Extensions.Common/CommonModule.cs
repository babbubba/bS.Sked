﻿using bS.Sked.Model.Interfaces.Modules;
using System;
using System.Linq;
using bS.Sked.Model.Interfaces.Elements;

namespace bS.Sked.Extensions.Common
{
    public class CommonModule : IExtensionModule
    {
        public bool CanExecute(IExecutableElementModel executableElement)
        {
            var supportedElementTypes = new string[] 
            {
                "from-flat-flie-to-table",
                "from-db-query-to-table",
                "from-table-to-flie"
            };

            return supportedElementTypes.Contains(executableElement.ElementType.PersistingId);
        }

        public IExtensionExecuteResult Execute(IExtensionContext context, IExecutableElementModel executableElement)
        {
            throw new NotImplementedException();
        }
    }
}
