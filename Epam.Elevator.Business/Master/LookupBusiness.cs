using Epam.Elevator.DataAccess.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Elevator.Models.Master;

namespace Epam.Elevator.Business.Master
{
    class LookupBusiness : Lookup
    {
        Lookup lookupDataAccess;
        public LookupBusiness(Lookup lookupDataAccess)
        {
            this.lookupDataAccess = lookupDataAccess;
        }
        public bool UpdateLookup()
        {
            lookupDataAccess.LookupId = 1;
           // lookupDataAccess.UpdateLookup();
            return true;
        }
        public bool DeleteLookup()
        {
           // lookupDataAccess.DeleteLookup();
            return true;
        }
        public Lookup GetLookup()
        {
            //lookupDataAccess.GetLookup();
            return null;
        }
        public  bool SaveLookup()
        {
            //lookupDataAccess.SaveLookup();
            return true;
        }
    }
}
