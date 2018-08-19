using Epam.Elevator.DataAccess.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Elevator.Models.Transactions;
using Epam.Elevator.DataAccess.Transactions.Interfaces;

namespace Epam.Elevator.Business.Transactions
{
    class ElevatorStatusBusiness : ElevatorStatus
    {
        IElevatorStatusDataAccess elevatorStatusDataAccess;
        public ElevatorStatusBusiness(IElevatorStatusDataAccess elevatorStatusDataAccess)
        {
            this.elevatorStatusDataAccess = elevatorStatusDataAccess;
        }
        public bool UpdateElevatorStatus()
        {
            //elevatorStatusDataAccess.ElevatorId = 1;
           // elevatorStatusDataAccess.UpdateElevatorStatus();
            return true;
        }
        public bool DeleteElevatorStatus()
        {
            //elevatorStatusDataAccess.DeleteElevatorStatus();
            return true;
        }
        public  ElevatorStatus GetElevatorStatus()
        {
           // elevatorStatusDataAccess.GetElevatorStatus();
            return null;
        }
        public bool SaveElevatorStatus()
        {
           // elevatorStatusDataAccess.SaveElevatorStatus();
            return true;
        }
    }
}