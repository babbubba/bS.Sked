using eOrk3.Models.Interfaces.Base;
using System.Linq;

namespace bS.Sked.Data.Interfaces
{
    public interface IObjectSet<T> : IQueryable<T> where T : class
    {
        void Add(T item);
        void Update(T item);
        void Delete(T item);
    }
}
