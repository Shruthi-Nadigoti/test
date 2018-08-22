using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Elevator.Models.Master
{
    public class Elevator
    {
       
        public Int32 ElevatorId { get; set; }
        public String ElevatorName { get; set; }
        public Int32 MaxWeight { get; set; }
        public Int32 FloorDuration { get; set; }
        public Int32 MainStatusId { get; set; }
        public Int32 CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int32 ModifiedByUserId { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
