using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Elevator.Models.Master
{
    public class User
    {
        public Int32 UserId { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Max 50 characters")]
        public String FirstName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Max 50 characters")]
        public String LastName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Max 50 characters")]
        public String Password { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Max 50 characters")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Max 50 characters")]
        public Enums.Gender Gender { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Max 50 characters")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$")]
        public String EmailId { get; set; }
        [Required]
        public String Address { get; set; }
        public Int32 CreatedByUserId { get; set; }
      //  [Range(typeof(DateTime),"01/01/1000","01/01/5000")]
        public DateTime CreatedDate { get; set; }
        public Int32 ModifiedByUserId { get; set; }
        public DateTime ModifiedDate { get; set; }
    
    }
}
