using Epam.Elevator.Models.Master;
using System;
using System.Collections.Generic;

namespace Epam.Elevator.DataAccess.Master.Interfaces
{
    public interface IFloorDataAccess
    {
        /// <summary>
        /// Creates given Floor Object in Database
        /// </summary>
        /// <param name="floor"></param>
        /// <returns></returns>
        bool Create(Floor floor);
        /// <summary>
        /// Update gives Floor Object in Database
        /// </summary>
        /// <param name="floor"></param>
        /// <returns></returns>
        bool Update(Floor floor);
        /// <summary>
        /// Delete floor object based on floor id that passed
        /// </summary>
        /// <param name="floorId"></param>
        /// <returns></returns>
        bool Delete(int floorId);
        /// <summary>
        /// Returns the floor object based on floor id
        /// </summary>
        /// <param name="floorId"></param>
        /// <returns></returns>
        Floor Get(int floorId);
        /// <summary>
        /// Returns the floor list
        /// </summary>
        /// <returns></returns>
        List<Floor> GetFloors();
        /// <summary>
        /// Returns the list of floor that matches with the string
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        List<Floor> SearchFloors(String searchString);
    }
}
