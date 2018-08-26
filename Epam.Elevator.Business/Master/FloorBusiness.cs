using System.Collections.Generic;
using Epam.Elevator.Models.Master;
using Epam.Elevator.DataAccess.Master.Interfaces;

namespace Epam.Elevator.Business.Master
{
    public class FloorBusiness 
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
        public Floor GetFloor(int floorId)
        {
            Floor floor = floorDataAccess.Get(floorId);
            return floor;
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

        public bool Update(Floor floor)
        {
            bool result = floorDataAccess.Update(floor);
            return result;
        }
    }
}