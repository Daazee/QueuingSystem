using QueuingSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QueuingSystem.Abstractions.Service
{
    public interface IQueuesService
    {
        Task<Queues> GetItem(Guid id);
        Task<IEnumerable<Queues>> GetItems();
        Task<Queues> AddItem(Queues item);
        Task<Queues> UpdateItem(Queues item);
        Task<Queues> RemoveItem(int id);
        Queues GetTodaysLastRecord(); // get last record added today to increment the serial number by one
        Task<IEnumerable<Queues>> GetQueuesBySatus(int status);
        Task<IEnumerable<Queues>> GetTodaysQueuesBySatus(int status);
    }
}
