using bS.Sked.Model.Interfaces.Entities.Base;
using System;
using System.Data;

namespace bS.Sked.Data.Interfaces
{
    /// <summary>
    /// this contain the ORM Session and call factory to build/retrieve the right session for current config info (the connection string value)
    /// </summary>
    public interface IObjectContext 
        : 
        IDisposable
    {
        IObjectSet<T> CreateObjectSet<T>() where T : class, IPersisterEntity;

        void Flush();

        bool IsInActiveTransaction { get; }
        IGenericTransaction BeginTransaction();
        IGenericTransaction BeginTransaction(IsolationLevel isolationLevel);
        void TransactionalFlush();
        void TransactionalFlush(IsolationLevel isolationLevel);
    }
}
