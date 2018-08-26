using System;
using System.Collections.Generic;
using ElevatorModel = Epam.Elevator.Models.Master;
namespace Epam.Elevator.DataAccess.Master.Interfaces
{
    public interface IElevatorDataAccess
    {
        /// <summary>
        /// Takes the Elevator object and insert into database
        /// </summary>
        /// <param name="elevator"></param>
        /// <returns></returns>
        bool Create(ElevatorModel.Elevator elevator);
        /// <summary>
        /// Takes the Elevator object and update it into database
        /// </summary>
        /// <param name="elevator"></param>
        /// <returns></returns>
        bool Update(ElevatorModel.Elevator elevator);
        /// <summary>
        /// Delete the elevator based on elevatorid that has been passed
        /// </summary>
        /// <param name="elevatorId"></param>
        /// <returns></returns>
        bool Delete(int elevatorId);
        /// <summary>
        /// Returns corresponding elevator object based on elevatorid 
        /// </summary>
        /// <param name="elevatorId"></param>
        /// <returns></returns>
        ElevatorModel.Elevator GetElevator(int elevatorId);
        /// <summary>
        /// Returns elevator list 
        /// </summary>
        /// <returns></returns>
        List<ElevatorModel.Elevator> GetElevators();
        /// <summary>
        /// Return elevator list that matches with string that passed
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        List<ElevatorModel.Elevator> SearchElevators(String searchString);
    }
}
