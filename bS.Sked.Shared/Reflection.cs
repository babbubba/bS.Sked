using Common.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace bS.Sked.Shared
{
   public static class Reflection
    {
        private static readonly string[] fileNameScannerPattern = { "bS.Sked..Model.*.dll", "bS.Sked.ElementExtensions.*.Model.dll" };
        private static ILog log = LogManager.GetLogger("bS.Sked.Shared.Reflection");

        public static List<Assembly> GetORMMappingAssemblies(string[] foldersWhereLookingForDll, bool useCurrentdirectoryToo)
        {
            var currentDirectory = "";
            var candidateFiles = new List<string>();

            if (useCurrentdirectoryToo)
            {
                currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                log.Trace($"Looking for dlls to map in directory: {currentDirectory}.");
                candidateFiles.AddRange(Directory.EnumerateFiles(currentDirectory, "*.dll", SearchOption.AllDirectories));
            }

            if (foldersWhereLookingForDll != null)
            {
                foreach (var folder in foldersWhereLookingForDll)
                {
                    candidateFiles.AddRange(Directory.EnumerateFiles(folder, "*.dll", SearchOption.AllDirectories));
                }
            }

            log.Trace($"The following dlls wil be evaluated for dinamically mapping in ORM:\n{string.Join("\n", candidateFiles)}");

            var resultantAssemblies = new Dictionary<string, Assembly>();
            var allAssemblies = candidateFiles
                      .Where(filename => fileNameScannerPattern.Any(pattern => Regex.IsMatch(filename, pattern)))
                      .Select(Assembly.LoadFrom);

            foreach (var assembly in allAssemblies)
            {
                if (!resultantAssemblies.ContainsKey(assembly.FullName)) resultantAssemblies.Add(assembly.FullName, assembly);
                else resultantAssemblies[assembly.FullName] = assembly;
            }

            log.Trace($"The following {resultantAssemblies.Count} assemblies will be loaded dinamically and mapped in ORM:\n{string.Join("\n", resultantAssemblies.Select(x => x.Key))}");
            return resultantAssemblies.Select(x => x.Value).ToList();
        }

        public static IExecutableElementModel GetNewElementModel(string interfaceFqdn) //where Interface : IExecutableElementModel
        {
            return GetNewInstanceFromInterface<ExecutableElementBaseModel>(interfaceFqdn);
        }

        static IExecutableElementModel GetNewInstanceFromInterface<OutBaseType>(string interfaceStr) where OutBaseType : class, IExecutableElementModel
        {
            //var currentTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).Where(x=>x.IsPublic && x.FullName.Contains("eOrk3."));
            var currentTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).Where(x => x.IsPublic && x.FullName.Contains("eOrk3."));

            var interfaceType = Type.GetType(interfaceStr);
            //var interfaceType = currentTypes.FirstOrDefault(x => x.FullName == interfaceFqdn);// Type.GetType(interfaceFqdn);

            if (interfaceType == null) throw new ApplicationException($"Cannot find the interface: {interfaceStr}");

            Type tConcrete = null;
            foreach (Type t in currentTypes)
            {
                if (interfaceType.IsAssignableFrom(t) && !t.IsAbstract && !t.IsInterface)
                {
                    tConcrete = t;
                    break;
                }
            }
            var o = (tConcrete == null) ? null : Activator.CreateInstance(tConcrete);
            return o as OutBaseType; // WellKnow based abstract class
        }

        public interface IExecutableElementModel
        {
        }

        private class ExecutableElementBaseModel : IExecutableElementModel
        {
        }
    }
}
