using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
