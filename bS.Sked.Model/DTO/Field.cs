using bS.Sked.Model.Interfaces.DTO;
using Common.Logging;
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

    public static class FieldExtension
    {
        static ILog log = LogManager.GetLogger(typeof(FieldExtension));
        public static T GetValue<T>(this IField val) 
        {
            var result = default(T);
            if (val.Value == null) return result;

            try
            {
                result = (T)val.Value;
            }
            catch (Exception ex)
            {
                log.Error($"Error converting value for field value '{val.Value.ToString()}'.", ex);
                throw;
            }
            return result;
        }

        //IDictionary<string, IField>
        public static T GetValue<T>(this IDictionary<string, IField> val, string fieldName)
        {
            var result = default(T);
            if (!val.ContainsKey(fieldName)) return result;

            if (val[fieldName].Value == null) return result;

            try
            {
                result = (T)val[fieldName].Value;
            }
            catch (Exception ex)
            {
                log.Error($"Error converting value for field value '{val[fieldName].Value.ToString()}'.", ex);
                throw;
            }
            return result;
        }

        public static void Add(this IDictionary<string, IField> val, string fieldName, object value)
        {
            val.Add(fieldName, new Field(value));
        }
    }
}
