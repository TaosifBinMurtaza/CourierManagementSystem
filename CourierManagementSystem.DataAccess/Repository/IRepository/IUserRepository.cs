using CourierManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.DataAccess.Repository.IRepository
{
    public interface IUserRepository:IRepository<User>
    {
        User Login(User obj);
    }
}
