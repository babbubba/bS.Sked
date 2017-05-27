using System;

namespace bS.Sked.Data.Interfaces
{
    public interface IGenericTransaction 
        : 
        IDisposable
    {
        void Commit();
        void Rollback();
    }
}
