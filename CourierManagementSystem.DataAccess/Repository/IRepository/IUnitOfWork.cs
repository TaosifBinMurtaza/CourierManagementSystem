using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICourierRepository CourierRepo { get; }
        IUserRepository UserRepo { get; }
        void Save();
    }
}
