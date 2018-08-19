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
    class RequestBusiness
    {
        IRequestDataAccess requestDataAccess;
        public RequestBusiness(IRequestDataAccess requestDataAccess)
        {
            this.requestDataAccess = requestDataAccess;
        }

        public  bool UpdateRequest()
        {
            //requestDataAccess.RequestId = 1;
            //requestDataAccess.UpdateRequest();
            return true;
        }
        public  bool DeleteRequest()
        {
            //requestDataAccess.DeleteRequest();
            return true;
        }
        public  Request GetRequest()
        {
            //requestDataAccess.GetRequest();
            return null;
        }
        public bool SaveRequest()
        {
            //requestDataAccess.SaveRequest();
            return true;
        }
    }
}
