using System;

namespace bS.Sked.Data.Interfaces
{
    /// <summary>
    /// This rapresent an abstracted ORM Session and permit transactional operations.
    /// </summary>
    public interface IGenericTransaction 
        : 
        IDisposable
    {
        void Commit();
        void Rollback();
    }
}
