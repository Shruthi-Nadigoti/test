using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Elevator.Models.Master
{
    public class Lookup
    {
        public Int32 LookupId { get; set; }
        public String LookupKey { get; set; }
        public Int32 LookupValue { get; set; }
        public TimeSpan lookupText { get; set; }
        public Int32 MainStatusId { get; set; }
        public Int32 CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int32 ModifiedByUserId { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
