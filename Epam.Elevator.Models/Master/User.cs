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
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Int32 GenderId { get; set; }
        public String EmailId { get; set; }
        public String Address { get; set; }
        public Int32 CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int32 ModifiedByUserId { get; set; }
        public DateTime ModifiedDate { get; set; }
    
    }
}
