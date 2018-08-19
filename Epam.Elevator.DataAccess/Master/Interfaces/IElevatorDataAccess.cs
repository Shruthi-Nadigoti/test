using Epam.Elevator.Models.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElevatorModel = Epam.Elevator.Models.Master;
namespace Epam.Elevator.DataAccess.Master.Interfaces
{
    public interface IElevatorDataAccess
    {
        bool Create(ElevatorModel.Elevator elevator);
        bool Update(ElevatorModel.Elevator elevator);
        bool Delete(int elevatorId);
        //ElevatorModel.Elevator Get(int elevatorId);
        List<ElevatorModel.Elevator> GetElevators();
        List<ElevatorModel.Elevator> SearchElevators(String searchString);
    }
}
