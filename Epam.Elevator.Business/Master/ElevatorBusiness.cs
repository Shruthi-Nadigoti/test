using Epam.Elevator.DataAccess.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElevatorModel=Epam.Elevator.Models.Master;
using Epam.Elevator.DataAccess.Master.Interfaces;
namespace Epam.Elevator.Business.Master
{
    public class ElevatorBusiness 
    {
        IElevatorDataAccess elevatorDataAccess;
        public ElevatorBusiness(IElevatorDataAccess elevatorDataAccess)
        {
            this.elevatorDataAccess = elevatorDataAccess;
        }
        public bool Create(ElevatorModel.Elevator elevator)
        {
            bool result = elevatorDataAccess.Create(elevator);
            return result;
        }

        public bool Update(ElevatorModel.Elevator elevator)
        {
            bool result = elevatorDataAccess.Update(elevator);
            return result;
        }

        public bool Delete(int elevatorId)
        {
            bool result = elevatorDataAccess.Delete(elevatorId);
            return result;
        }

        public List<ElevatorModel.Elevator> GetElevators()
        {
            List<ElevatorModel.Elevator> elevatorList = elevatorDataAccess.GetElevators();
            return elevatorList;
        }

        public List<ElevatorModel.Elevator> SearchElevators(string searchString)
        {
            List<ElevatorModel.Elevator> elevatorList = elevatorDataAccess.SearchElevators(searchString);
            return elevatorList;
        }
    }
}
