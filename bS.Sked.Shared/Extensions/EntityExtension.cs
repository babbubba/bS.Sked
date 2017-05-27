using bS.Sked.Model.Interfaces.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Shared.Extensions
{
    public static class EntityExtension
    {
        public static T SetCreationDateIfNeeded<T>(this T item) where T : class, IPersisterEntity
        {
            var cItem = item as IHistoricalEntity;
            if (cItem != null && (cItem.CreationDate == null || cItem.CreationDate == DateTime.MinValue))
            {
                cItem.CreationDate = DateTime.Now;
                return cItem as T;
            }
            return item;
        }

        public static T SetUpdateDateIfNeeded<T>(this T item) where T : class, IPersisterEntity
        {
            var cItem = item as IHistoricalEntity;
            if (cItem != null)
            {
                cItem.UpdateDate = DateTime.Now;
                return cItem as T;
            }
            return item;
        }
    }
}
