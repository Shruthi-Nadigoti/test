using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Elevator.Models.Transactions
{
    public class ElevatorStatus 
    {
        public Int32 ElevatorId { get; set; }
        public Int32 CurrentFloorId { get; set; }
        public Int32 StartFloorId { get; set; }
        public Int32 EndFloorId { get; set; }
        public Int32 StatusId { get; set; }
        public Int32 CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int32 ModifiedByUserId { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
