using bS.Sked.Data.Interfaces;
using bS.Sked.Model.Interfaces.Entities.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Model.Modules
{
    public abstract class ModuleActionbase
    {
        private readonly IRepository<IPersisterEntity> repository;
        private readonly string pid;
        private readonly string name;
        private readonly string description;

        public ModuleActionbase(IRepository<IPersisterEntity> repository, string pid, string name, string description)
        {
            if (string.IsNullOrWhiteSpace(pid))
            {
                throw new ArgumentException("message", nameof(pid));
            }

            this.repository = repository;
            this.pid = pid;
            this.name = name;
            this.description = description;
        }

      


    }
}
