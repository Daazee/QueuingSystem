using QueuingSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QueuingSystem.Abstractions.Service
{
    public interface IQueuesService
    {
        Task<Queues> GetItem(int id);
        Task<IEnumerable<Queues>> GetItems();
        Task<int> AddItem(Queues item);
        Task<int> UpdateItem(Queues item);
        Task<Queues> RemoveItem(int id);
    }
}
