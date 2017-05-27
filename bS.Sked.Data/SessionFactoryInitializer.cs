using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using System.Diagnostics;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Util;
using System.Reflection;
using System.IO;
using System.Text.RegularExpressions;
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

        private static ISessionFactory CreateNewFactory(string connectionString, string[] foldersWereLookingForDll)
        {
            ISessionFactory lResult = null;
            try
            {
                var MappingAssemblies = Shared.Reflection.GetORMMappingAssemblies(foldersWereLookingForDll, true);

                lResult = Fluently.Configure()
                 .Database(MySQLConfiguration.Standard.ConnectionString(connectionString))
                 .Mappings(m => MappingAssemblies.ForEach(a => m.FluentMappings.AddFromAssembly(a)))
                 .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(true, true))
                 .BuildSessionFactory();
            }
            catch (Exception ex)
            {
                {
                    log.Fatal($"Eccezione creando il SessionFactory per Nhibernate: {ex.GetBaseException().Message}", ex);
                    throw;
                }
            }

            return lResult;
        }

        public static ISessionFactory GetFactory(string connectionString, string[] foldersWereLookingForDll = null)
        {
            lock (typeof(SessionFactoryInitializer))
            {
                if (!FactoryDictionary.ContainsKey(connectionString))
                {
                    FactoryDictionary.Add(connectionString, CreateNewFactory(connectionString, foldersWereLookingForDll));
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
