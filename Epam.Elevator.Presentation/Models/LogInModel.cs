using System;
using System.ComponentModel.DataAnnotations;

namespace Epam.Elevator.Presentation.Models
{
    public class LogInModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "Max 50 characters")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$")]
        public String EmailId { set; get; }
        [Required]
        [StringLength(50, ErrorMessage = "Max 50 characters")]
        public String Password { set; get; }
    }
}