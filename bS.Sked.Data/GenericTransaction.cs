using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bS.Sked.Data.Interfaces;

namespace bS.Sked.Data
{
    public class GenericTransaction : IGenericTransaction
    {
        private readonly NHibernate.ITransaction _transaction;

        public GenericTransaction(NHibernate.ITransaction transaction)
        {
            _transaction = transaction;
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public void Dispose()
        {
            _transaction.Dispose();
        }
    }
}
