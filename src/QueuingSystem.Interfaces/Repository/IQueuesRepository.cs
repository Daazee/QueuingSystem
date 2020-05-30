using QueuingSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QueuingSystem.Abstractions.Repository
{
    public interface IQueuesRepository : IBaseRepository<Queues>
    {
        Queues GetTodaysLastRecord(); // get last record added today to increment the serial number by one
        Task<IEnumerable<Queues>> GetQueuesBySatus(int status);
        Task<IEnumerable<Queues>> GetTodaysQueuesBySatus(int status);
    }
}
