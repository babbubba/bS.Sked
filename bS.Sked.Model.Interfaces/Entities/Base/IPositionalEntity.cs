using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Model.Interfaces.Entities.Base
{
    public interface IPositionalEntity
    {
        /// <summary>
        /// Gets or sets the position in a collection.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        int Position { get; set; }
    }
}
