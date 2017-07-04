using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bS.Sked.Data
{
    /// <summary>
    /// Database Configuration for a repositories and units of work.
    /// </summary>
    public class DataContextConfigInfo
    {
        /// <summary>
        /// May be the Connection string for database like MySql or Sql Server or the file path for database like SqlLite.
        /// </summary>
        public string ConnectionString { get; set; }
        /// <summary>
        /// Eventually extra paths, pipe separated ('|'), where session factory has to look for dlls containing extra models. 
        /// </summary>
        public string ExtraDllModelFolders { get; set; }
        public string DbType { get; set; }
    }
}
