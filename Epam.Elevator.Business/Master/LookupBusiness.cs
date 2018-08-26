using System;
using Epam.Elevator.Models.Master;
using Epam.Elevator.DataAccess.Master.Interfaces;

namespace Epam.Elevator.Business.Master
{
    public class LookupBusiness 
    {
        ILookupDataAccess lookupDataAccess;
        public LookupBusiness(ILookupDataAccess lookupDataAccess)
        {
            this.lookupDataAccess = lookupDataAccess;
        }
        public bool UpdateLookup()
        {
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

        public int GetLookupId(string key, string value)
        {
            int lookupId=lookupDataAccess.GetLookupId(key,value);
            return lookupId;
        }

        public string GetLookupValue(int id)
        {
            String lookupValue = lookupDataAccess.GetLookupValue(id);
            return lookupValue;
        }
    }
}
