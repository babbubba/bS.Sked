using System;
using System.Data;

namespace bS.Sked.Data.Interfaces
{
    public interface IUnitOfWork
        :
        IDisposable
    {
        IObjectContext ObjectContext { get; }
        
        void Flush();

        bool IsInActiveTransaction { get; }
        IGenericTransaction BeginTransaction();
        IGenericTransaction BeginTransaction(IsolationLevel isolationLevel);
        void TransactionalFlush();
        void TransactionalFlush(IsolationLevel isolationLevel);
    }
}
