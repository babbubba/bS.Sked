using System;
using System.Data;
using bS.Sked.Data.Interfaces;
using Common.Logging;

namespace bS.Sked.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private static ILog log = LogManager.GetLogger<UnitOfWork>();

        private readonly IObjectContext objectContext;

        public UnitOfWork(
            IObjectContext objectContext)
        {
            this.objectContext = objectContext;
            log.Trace($"Unit Of Work for the context '{objectContext.GetHashCode()}' created.");
        }

        #region IUnitOfWork Members

        public IObjectContext ObjectContext
        {
            get
            {
                return objectContext;
            }
        }

        public void Flush()
        {
            objectContext.Flush();
            log.Trace($"Unit Of Work has flushed the context '{objectContext.GetHashCode()}'.");
        }

        public bool IsInActiveTransaction
        {
            get
            {
                return objectContext.IsInActiveTransaction;
            }
        }

        public IGenericTransaction BeginTransaction()
        {
            return objectContext.BeginTransaction();
        }

        public IGenericTransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            return objectContext.BeginTransaction(isolationLevel);
        }

        public void TransactionalFlush()
        {
            objectContext.TransactionalFlush();
        }

        public void TransactionalFlush(IsolationLevel isolationLevel)
        {
            objectContext.TransactionalFlush(isolationLevel);
        }

        #endregion IUnitOfWork Members

        #region IDisposable Members

        public void Dispose()
        {
            if (objectContext != null)
            {
                var h = objectContext.GetHashCode();
                objectContext.Dispose();
                log.Trace($"Unit Of Work has disposed the context '{h}'.");
            }

            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members
    }
}