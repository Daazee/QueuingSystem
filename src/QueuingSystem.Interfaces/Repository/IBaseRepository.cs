using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QueuingSystem.Abstractions.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetItem(Guid id);
        Task<IEnumerable<T>> GetItems();
        Task<T> AddItem(T item);
        Task<T> UpdateItem(T item);
        Task<T> RemoveItem(int id);
    }
}
