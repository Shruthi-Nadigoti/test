using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Elevator.Models.Master
{
    public class Floor
    {
        public Int32 FloorId{get; set;}
        [Required]
        [StringLength(50, ErrorMessage = "Max 50 characters")]
        public string FloorName { get; set; }
        public Int32 CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int32 ModifiedByUserId { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
