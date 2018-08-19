using Epam.Elevator.Models.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Elevator.DataAccess.Master.Interfaces
{
    public interface IUserDataAccess
    {
        bool Create(User user);
        bool Update(User user);
        bool Delete(int userId);
        User Get(int userId);
        List<User> GetUsers();
    }
}
