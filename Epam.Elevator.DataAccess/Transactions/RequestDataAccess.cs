using Epam.Elevator.DataAccess.Transactions.Interfaces;
using Epam.Elevator.Models.Transactions;
namespace Epam.Elevator.DataAccess.Master
{
    public class RequestDataAccess : IRequestDataAccess
    {
        public  bool UpdateRequest()
        {
            return true;
        }
        public  bool DeleteRequest()
        {
            return true;
        }
        public Request GetRequest()
        {
            return null;
        }
        public bool SaveRequest()
        {
            return true;
        }
    }
}
