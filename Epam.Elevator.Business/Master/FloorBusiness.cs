using Epam.Elevator.DataAccess.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Elevator.Models.Master;
using Epam.Elevator.DataAccess.Master.Interfaces;

namespace Epam.Elevator.Business.Master
{
    public class FloorBusiness :IFloorDataAccess
    {
        IFloorDataAccess floorDataAccess;
        public FloorBusiness(IFloorDataAccess floorDataAccess)
        {
            this.floorDataAccess = floorDataAccess;
        }

        public bool Create(Floor floor)
        {
            bool result = floorDataAccess.Create(floor);
            return result;
        }

        public bool Delete(int floorId)
        {
            bool result = floorDataAccess.Delete(floorId);
            return result;
        }

        public List<Floor> GetFloors()
        {
            List<Floor> floorList = floorDataAccess.GetFloors();
            return floorList;
        }

        public List<Floor> SearchFloors(string searchString)
        {
            List<Floor> floorList = floorDataAccess.SearchFloors(searchString);
            return floorList;
        }

        public bool Update(int floorId)
        {
            bool result = floorDataAccess.Update(floorId);
            return result;
        }
    }
}