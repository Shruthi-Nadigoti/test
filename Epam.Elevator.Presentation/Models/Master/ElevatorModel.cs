using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Elevator.Presentation.Master
{
    public class ElevatorModel
    {
       
        public Int32 ElevatorId { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Max 50 characters")]
        public String ElevatorName { get; set; }
        [Required]
        public Int32 MaxWeight { get; set; }
        [Required]
        public TimeSpan FloorDuration { get; set; }
        [Required]
        public Enums.MainStatus MainStatus { get; set; }
        public Int32 CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int32 ModifiedByUserId { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
