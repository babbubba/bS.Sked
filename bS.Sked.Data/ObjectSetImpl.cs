using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Linq;
using bS.Sked.Data.Interfaces;
using bS.Sked.Model.Interfaces.Entities.Base;
using bS.Sked.Shared.Extensions;

namespace bS.Sked.Data
{
    public class ObjectSetImpl<T>
        :
        IObjectSet<T> where T : class, IPersisterEntity
    {
        NHibernate.ISession _session;

        public ObjectSetImpl(
            NHibernate.ISession session)
        {
            _session = session;
        }

        #region IObjectSet<T> Members

        public void Add(T item)
        {
          // item = item.SetCreationDateIfNeeded();
           item.SetCreationDateIfNeeded();
                _session.Save(item);
        }

      

        public void Update(T item)
        {
           // item = item.SetUpdateDateIfNeeded();
            item.SetUpdateDateIfNeeded();
            _session.Update(item);
        }

        public void Delete(T item)
        {
            _session.Delete(item);
        }

        #endregion IObjectSet<T> Members

        #region IEnumerable<T> Members

        public IEnumerator<T> GetEnumerator()
        {
            return _session.Query<T>().GetEnumerator();
        }

        #endregion IEnumerable<T> Members

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _session.Query<T>().GetEnumerator();
        }

        #endregion IEnumerable Members

        #region IQueryable Members

        public Type ElementType
        {
            get
            {
                return _session.Query<T>().ElementType;
            }
        }

        public System.Linq.Expressions.Expression Expression
        {
            get
            {
                return _session.Query<T>().Expression;
            }
        }

        public IQueryProvider Provider
        {
            get
            {
                return _session.Query<T>().Provider;
            }
        }

        #endregion IQueryable Members
    }
}