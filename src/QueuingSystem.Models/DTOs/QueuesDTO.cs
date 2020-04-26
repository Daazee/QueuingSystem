using System;
using System.Collections.Generic;
using System.Text;

namespace QueuingSystem.Models.DTOs
{
    public class QueuesDTO
    {
        public Guid QueueId { get; set; }
        public string IdentifyingId { get; set; }
        public long SerialNumber { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public int Status { get; set; }
        public string StatusDisplay { get; }
    }
}
