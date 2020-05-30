using QueuingSystem.Abstractions.Repository;
using QueuingSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace QueuingSystem.DAL
{
    public class QueuesRepository : BaseRepository<Queues>, IQueuesRepository
    {
        public QueuesRepository()
        {

        }

        QueuingSystemContext context = ContextManager.GetContext();

        public Queues GetTodaysLastRecord()
        {
            return context.Queues.LastOrDefault(c => c.CreatedOn.Date == DateTime.Today.Date);
        }
        
        public async Task<IEnumerable<Queues>> GetTodaysQueuesBySatus(int status)
        {
            return context.Queues.Where(c => c.Status == status && c.CreatedOn.Date == DateTime.Today.Date).ToList();
        }

        public async Task<IEnumerable<Queues>> GetQueuesBySatus(int status)
        {
            return context.Queues.Where(c => c.Status == status).ToList();

        }
    }
}
