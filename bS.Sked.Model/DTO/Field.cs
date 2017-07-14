using bS.Sked.Model.Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Model.DTO
{
    public class Field : IField
    {
        public Field(object value)
        {
            Value = value;
        }

        public object Value { get; set; }


    }
}
