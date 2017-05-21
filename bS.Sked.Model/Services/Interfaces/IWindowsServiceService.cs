using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Model.Services.Interfaces
{
    public interface IWindowsServiceService : IService
    {
        bool StartService(bool debug = false);
    }
}
