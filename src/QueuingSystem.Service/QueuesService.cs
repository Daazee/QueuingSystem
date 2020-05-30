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

        public async Task<Queues> AddItem(Queues item)
        {
            var todaysLastQueueRecord = GetTodaysLastRecord(); //to know the next serial number
            item.SerialNumber = todaysLastQueueRecord == null ? 1 : ++todaysLastQueueRecord.SerialNumber;
            item.ModifiedOn = item.CreatedOn = DateTime.Now;
            item.ModifiedBy = item.CreatedBy = "System";
            var result = await _queuesRepository.AddItem(item);
            return result;
        }

        public Task<Queues> GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Queues> GetItem(Guid id)
        {
            return await _queuesRepository.GetItem(id);
        }

        public async Task<IEnumerable<Queues>> GetItems()
        {
            return await _queuesRepository.GetItems();
        }

        public async Task<IEnumerable<Queues>> GetTodaysQueuesBySatus(int status)
        {
            return await _queuesRepository.GetTodaysQueuesBySatus(status);
        }

        public async Task<IEnumerable<Queues>> GetQueuesBySatus(int status)
        {
            return await _queuesRepository.GetQueuesBySatus(status);
        }
        
        public Queues GetTodaysLastRecord()
        {
           return _queuesRepository.GetTodaysLastRecord();
        }

        public Task<Queues> RemoveItem(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Queues> UpdateItem(Queues item)
        {
            var queue = await _queuesRepository.GetItem(item.QueueId);
            queue.Status = item.Status;
            queue.ModifiedOn = item.ModifiedOn = DateTime.Now;
            queue.ModifiedBy = item.ModifiedBy = "System";
            await _queuesRepository.UpdateItem(queue);
            return queue;
        }
    }
}
