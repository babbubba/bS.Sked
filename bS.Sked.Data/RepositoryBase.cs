/*
    The MIT License (MIT)

    Copyright (c) 2017 Fabio Cavallari (fcavallari@bsoft.it)

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in
    all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    THE SOFTWARE.

    (http://opensource.org/licenses/mit-license.php)
*/

using System.Linq;
using bS.Sked.Data.Interfaces;
using System.Data;
using bS.Sked.Model.Interfaces.Entities.Base;
using Common.Logging;

namespace bS.Sked.Data
{
    public class RepositoryBase<TBase> : IRepository<TBase> where TBase : class, IPersisterEntity
    {
        private static ILog log = LogManager.GetLogger<RepositoryBase<TBase>>();

        private readonly IUnitOfWork _mainUnitOfWork;

        public RepositoryBase(IUnitOfWork mainUnitOfWork)
        {
            _mainUnitOfWork = mainUnitOfWork;
            log.Trace($"Repository created for the Unit Of Work '{mainUnitOfWork.GetHashCode()}'.");
        }

        #region IRepository<TBase> Members

        public IQueryable<TImpl> GetQuery<TImpl>(IUnitOfWork uow) where TImpl : class, TBase
        {
            return uow.ObjectContext.CreateObjectSet<TImpl>();
        }

        public IQueryable<TImpl> GetQuery<TImpl>() where TImpl : class, TBase
        {
            return GetQuery<TImpl>(_mainUnitOfWork);
        }

        public void Add<TImpl>(TImpl item, IUnitOfWork uow) where TImpl : class, TBase
        {
            uow.ObjectContext.CreateObjectSet<TImpl>().Add(item);
        }

        public void Add<TImpl>(TImpl item) where TImpl : class, TBase
        {
            Add<TImpl>(item, _mainUnitOfWork);
            FlushIfMainUnitOfWorkIsNotInTransaction();
        }

        public void Update<TImpl>(TImpl item, IUnitOfWork uow) where TImpl : class, TBase
        {
            uow.ObjectContext.CreateObjectSet<TImpl>().Update(item);
        }

        public void Update<TImpl>(TImpl item) where TImpl : class, TBase
        {
            Update<TImpl>(item, _mainUnitOfWork);
            FlushIfMainUnitOfWorkIsNotInTransaction();
        }

        public void Delete<TImpl>(TImpl item, IUnitOfWork uow) where TImpl : class, TBase
        {
            uow.ObjectContext.CreateObjectSet<TImpl>().Delete(item);
        }

        public void Delete<TImpl>(TImpl item) where TImpl : class, TBase
        {
            Delete<TImpl>(item, _mainUnitOfWork);
            FlushIfMainUnitOfWorkIsNotInTransaction();
        }

        public bool IsInActiveTransaction
        {
            get
            {
                return _mainUnitOfWork.IsInActiveTransaction;
            }
        }

        public IGenericTransaction BeginTransaction(IUnitOfWork uow)
        {
            return uow.BeginTransaction();
        }

        public IGenericTransaction BeginTransaction()
        {
            return BeginTransaction(_mainUnitOfWork);
        }

        public IGenericTransaction BeginTransaction(IsolationLevel isolationLevel, IUnitOfWork uow)
        {
            return uow.BeginTransaction(isolationLevel);
        }

        public IGenericTransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            return BeginTransaction(isolationLevel, _mainUnitOfWork);
        }

        #endregion

        #region Private Methods

        private void FlushIfMainUnitOfWorkIsNotInTransaction()
        {
            if (!_mainUnitOfWork.IsInActiveTransaction) _mainUnitOfWork.Flush();
        }

        #endregion
    }

    #region Old Impl

    //public class RepositoryBase<TEntityBase>
    //    :
    //    bS.Sked.Data.Interface.IRepository<TEntityBase>
    //    where TEntityBase : class, MMLab.ObjectModel.Interface.IItemBase
    //{
    //    ISessionFactory SessionFactory = null;

    //    RepositoryConfigInfo ConfigInfo = null;

    //    public RepositoryBase(
    //        RepositoryConfigInfo configInfo)
    //    {            
    //        if (configInfo == null)
    //            throw new ArgumentNullException("configInfo");

    //        ConfigInfo = configInfo;

    //        SessionFactory = SessionFactoryInitializer.GetFactory(configInfo.ConfigFileName);            
    //    }

    //    #region IRepository<TEntityBase> Members

    //    public IList<TItem> FindAll<TItem>() where TItem : class, TEntityBase
    //    {
    //        using (ISession session = SessionFactory.OpenSession())
    //        {
    //            return session.QueryOver<TItem>().List();
    //        }
    //    }

    //    public IList<TItem> FindAll<TItem>(System.Linq.Expressions.Expression<Func<TItem, bool>> predicate) where TItem : class, TEntityBase
    //    {
    //        using (ISession session = SessionFactory.OpenSession())
    //        {
    //            return session.Query<TItem>().Where(predicate).ToList(); 
    //            //return session.QueryOver<TItem>().Where(predicate).List();
    //        }
    //    }       

    //    public TItem Find<TItem>(System.Linq.Expressions.Expression<Func<TItem, bool>> predicate) where TItem : class, TEntityBase
    //    {
    //        using (ISession session = SessionFactory.OpenSession())
    //        {
    //            return session.Query<TItem>().Where(predicate).SingleOrDefault();
    //            //return session.QueryOver<TItem>().Where(predicate).SingleOrDefault();
    //        }
    //    }

    //    public TItem FindById<TItem>(int id) where TItem : class, TEntityBase
    //    {
    //        using (ISession session = SessionFactory.OpenSession())
    //        {
    //            return session.Get<TItem>(id);
    //        }
    //    }

    //    public void SaveOrUpdate<TItem>(TItem item) where TItem : class, TEntityBase
    //    {
    //        using (ISession session = SessionFactory.OpenSession())
    //        using (ITransaction transaction = session.BeginTransaction())
    //        {
    //            session.SaveOrUpdate(item);
    //            transaction.Commit();
    //        }
    //    }

    //    public TItem FindByInternalCode<TItem>(string internalCode) where TItem : class, TEntityBase, MMLab.ObjectModel.Interface.IInternalCode
    //    {
    //        return Find<TItem>(x => x.InternalCode == internalCode);
    //    }

    //    #endregion
    //}

    #endregion
}
