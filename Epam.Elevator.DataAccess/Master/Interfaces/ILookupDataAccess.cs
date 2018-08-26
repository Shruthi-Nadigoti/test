using System;

namespace Epam.Elevator.DataAccess.Master.Interfaces
{
    public interface ILookupDataAccess
    {
        bool UpdateLookup();
        bool DeleteLookup();
        int GetLookupId(String key, String value);
        String GetLookupValue(int id);
        bool SaveLookup();
    }
}
