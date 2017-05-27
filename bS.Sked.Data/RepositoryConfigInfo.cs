using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bS.Sked.Data
{
    public class RepositoryConfigInfo
    {
        public RepositoryConfigInfo(
            string configFileName)
        {
            ConfigFileName = configFileName;
        }

        #region Properties

        /// <summary>
        /// Ritorna o imposta il nome dell'assembly che contiene i mapping
        /// </summary>
        public string ConfigFileName
        {
            get;
            private set;
        }

        #endregion
    }
}
