using QueuingSystem.Abstractions.Repository;
using QueuingSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueuingSystem.DAL
{
    public class QueuesRepository : BaseRepository<Queues> , IQueuesRepository
    {
        public QueuesRepository()
        {

        }
    }
}
