using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Elevator.DataAccess.Transactions.Interfaces;
using Epam.Elevator.Models.Transactions;
namespace Epam.Elevator.DataAccess.Master
{
    public class ElevatorStatusDataAccess : IElevatorStatusDataAccess
    {
        public  bool UpdateElevatorStatus()
        {
            return true;
        }
        public  bool DeleteElevatorStatus()
        {
            return true;
        }
        public  ElevatorStatus GetElevatorStatus()
        {
            return null;
        }
        public  bool SaveElevatorStatus()
        {
            return true;
        }
    }
}
