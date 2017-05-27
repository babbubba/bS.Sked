using System.Linq;
using System.Data;

namespace bS.Sked.Data.Interfaces
{
    public interface IRepository<TItemBase>
        where TItemBase : class, bS.Sked.Model.Interfaces.Entities.Base.IPersisterEntity
    {
        IQueryable<TItem> GetQuery<TItem>() where TItem : class, TItemBase;
        IQueryable<TItem> GetQuery<TItem>(IUnitOfWork uow) where TItem : class, TItemBase;

        void Add<TItem>(TItem item) where TItem : class, TItemBase;
        void Add<TItem>(TItem item, IUnitOfWork uow) where TItem : class, TItemBase;

        void Update<TItem>(TItem item) where TItem : class, TItemBase;
        void Update<TItem>(TItem item, IUnitOfWork uow) where TItem : class, TItemBase;

        void Delete<TItem>(TItem item) where TItem : class, TItemBase;
        void Delete<TItem>(TItem item, IUnitOfWork uow) where TItem : class, TItemBase;

        bool IsInActiveTransaction { get; }
        IGenericTransaction BeginTransaction();
        IGenericTransaction BeginTransaction(IUnitOfWork uow);

        IGenericTransaction BeginTransaction(IsolationLevel isolationLevel);
        IGenericTransaction BeginTransaction(IsolationLevel isolationLevel, IUnitOfWork uow);
    }

}
