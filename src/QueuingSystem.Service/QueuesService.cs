using QueuingSystem.Abstractions.Repository;
using QueuingSystem.Abstractions.Service;
using QueuingSystem.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QueuingSystem.Service
{
    public class QueuesService : IQueuesService
    {
        private IQueuesRepository _queuesRepository;
        public QueuesService(IQueuesRepository queuesRepository)
        {
            _queuesRepository = queuesRepository;
        }

        public async Task<int> AddItem(Queues item)
        {
            int result = await _queuesRepository.AddItem(item);
            return result;
        }

        public Task<Queues> GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Queues>> GetItems()
        {
            return await _queuesRepository.GetItems();
        }

        public Task<Queues> RemoveItem(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateItem(Queues item)
        {
            throw new NotImplementedException();
        }
    }
}
