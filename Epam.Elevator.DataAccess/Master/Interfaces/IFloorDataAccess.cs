using Epam.Elevator.Models.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Elevator.DataAccess.Master.Interfaces
{
    public interface IFloorDataAccess
    {
        bool Create(Floor floor);
        bool Update(int floorId);
        bool Delete(int floorId);
        List<Floor> GetFloors();
        List<Floor> SearchFloors(String searchString);
    }
}
