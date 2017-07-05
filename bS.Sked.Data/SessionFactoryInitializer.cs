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
using System.Collections.Generic;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;
using Common.Logging;

namespace bS.Sked.Data
{
    public sealed class SessionFactoryInitializer
    {
        private static ILog log = LogManager.GetLogger<SessionFactoryInitializer>();
        private static readonly Dictionary<string, ISessionFactory> FactoryDictionary;

        static SessionFactoryInitializer()
        {
            FactoryDictionary = new Dictionary<string, ISessionFactory>();
        }

        private static ISessionFactory CreateNewFactory(string connectionString, string[] foldersWereLookingForDll, string dbType)
        {
            ISessionFactory lResult = null;
            try
            {
                var MappingAssemblies = Shared.Reflection.GetORMMappingAssemblies(foldersWereLookingForDll, true);

                switch (dbType.ToLower())
                {
                    case "mysql":
                        lResult = Fluently.Configure()
                            .Database(MySQLConfiguration.Standard.ConnectionString(connectionString))
                            .Mappings(m => MappingAssemblies.ForEach(a => m.FluentMappings.AddFromAssembly(a)))
                            .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(true, true))
                            .BuildSessionFactory();
                        break;
                    case "sqlite":
                        lResult = Fluently.Configure()
                            .Database(SQLiteConfiguration.Standard.ConnectionString(connectionString))
                            .Mappings(m => MappingAssemblies.ForEach(a => m.FluentMappings.AddFromAssembly(a)))
                            .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(true, true))
                            .BuildSessionFactory();
                        break;
                    case "sql2012":
                        lResult = Fluently.Configure()
                            .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString))
                            .Mappings(m => MappingAssemblies.ForEach(a => m.FluentMappings.AddFromAssembly(a)))
                            .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(true, true))
                            .BuildSessionFactory();
                        break;
                    case "sql20008":
                        lResult = Fluently.Configure()
                            .Database(MsSqlConfiguration.MsSql2008.ConnectionString(connectionString))
                            .Mappings(m => MappingAssemblies.ForEach(a => m.FluentMappings.AddFromAssembly(a)))
                            .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(true, true))
                            .BuildSessionFactory();
                        break;
                }
               
            }
            catch (Exception ex)
            {
                {
                    log.Fatal($"Exception creating ORM SessionFactory: {ex.GetBaseException().Message}", ex);
                    throw;
                }
            }

            return lResult;
        }

        public static ISessionFactory GetFactory(string connectionString, string dbType, string[] foldersWereLookingForDll)
        {
            lock (typeof(SessionFactoryInitializer))
            {
                if (!FactoryDictionary.ContainsKey(connectionString))
                {
                    FactoryDictionary.Add(connectionString, CreateNewFactory(connectionString, foldersWereLookingForDll, dbType));
                    log.Trace($"New 'Factory Session Builder' has been created for the Connection String: {connectionString}");
                }
                else
                {
                    log.Trace($"Existing 'Factory Session Builder' has been found for the Connection String: {connectionString}");
                }

                return FactoryDictionary[connectionString];
            }
        }
    }
}
