using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QueuingSystem.Models
{
    public class Queues
    {
        [Key]
        public Guid QueueId { get; set; }
        public string IdentifyingId { get; set; }
        public long SerialNumber { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public int Status { get; set; }
    }
}
