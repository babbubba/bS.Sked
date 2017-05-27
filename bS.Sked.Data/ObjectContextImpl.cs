using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using bS.Sked.Data.Interfaces;
using NHibernate.Linq;
using Common.Logging;
using bS.Sked.Model.Interfaces.Entities.Base;

namespace bS.Sked.Data
{
    /// <summary>
    /// this contain the ORM Session and call factory to build/retrieve the right session for current config info (the connection string value)
    /// </summary>
    public class ObjectContextImpl : IObjectContext
    {
        private static ILog log = LogManager.GetLogger<ObjectContextImpl>();

        NHibernate.ISession _session;
        NHibernate.ISessionFactory _sessionFactory;

        public ObjectContextImpl(
            DataContextConfigInfo configInfo)
        {
            _sessionFactory =
                SessionFactoryInitializer.GetFactory(
                    configInfo.ConnectionString, configInfo.ExtraDllModelFolders?.Split('|'));

            _session = _sessionFactory.OpenSession();
            log.Trace($"Session '{_session.GetHashCode()}' has been created.");


        }

        #region IObjectContext Members

        public void Flush()
        {
            _session.Flush();
            log.Trace("The contex has flushed the session.");

        }

        public IObjectSet<T> CreateObjectSet<T>() where T : class, IPersisterEntity
        {
            return new ObjectSetImpl<T>(_session);
        }

        public bool IsInActiveTransaction
        {
            get
            {
                return _session.Transaction.IsActive;
            }
        }

        public IGenericTransaction BeginTransaction()
        {
            log.Trace("The contex init a new session transaction.");
            return new GenericTransaction(_session.BeginTransaction());
        }

        public IGenericTransaction BeginTransaction(System.Data.IsolationLevel isolationLevel)
        {
            log.Trace("The contex init a new session isolated transaction.");
            return new GenericTransaction(_session.BeginTransaction(isolationLevel));
        }

        public void TransactionalFlush()
        {
            log.Trace("The contex executes a Transactional Flush.");
            TransactionalFlush(IsolationLevel.ReadCommitted);
        }

        public void TransactionalFlush(System.Data.IsolationLevel isolationLevel)
        {

            // $$$$$$$$$$$$$$$$ gns: take this, when making thread safe! $$$$$$$$$$$$$$
            //IUoWTransaction tx = UnitOfWork.Current.BeginTransaction(isolationLevel);

            IGenericTransaction tx = BeginTransaction(isolationLevel);
            try
            {
                //forces a flush of the current unit of work
                tx.Commit();
            }
            catch (Exception ex)
            {
                log.Error("Error committing in the transactional flush step. Tryng to rollback", ex);
                tx.Rollback();
                throw;
            }
            finally
            {
                tx.Dispose();
            }
        }

        #endregion IObjectContext Members

        #region IDisposable Members

        public void Dispose()
        {
            if (_session != null)
            {
                var s = _session.GetHashCode();
                _session.Dispose();
                log.Trace($"Session '{s}' has been disposed.");
            }

            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members
    }
}