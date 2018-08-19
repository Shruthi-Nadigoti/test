using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Elevator.Models.Transactions
{
    public class Request
    {
        public Int32 RequestId { get; set; }
        public String ElevatorId { get; set; }
        public Int32 SourceFloorId { get; set; }
        public Int32 DestinationFloorId { get; set; }
        public DateTime RequestTime { get; set; }
        public DateTime SourceTime { get; set; }
        public DateTime DestinationTime { get; set; }
        public Int32 CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int32 ModifiedByUserId { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
