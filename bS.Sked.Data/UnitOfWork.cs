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