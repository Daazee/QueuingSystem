using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QueuingSystem.Abstractions.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetItem(int id);
        Task<IEnumerable<T>> GetItems();
        Task<int> AddItem(T item);
        Task<int> UpdateItem(T item);
        Task<T> RemoveItem(int id);
    }
}
