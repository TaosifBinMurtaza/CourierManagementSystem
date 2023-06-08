using CourierManagementSystem.DataAccess.Data;
using CourierManagementSystem.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            CourierRepo = new CourierRepository(_db);
            UserRepo = new UserRepository(_db);

        }
        public ICourierRepository CourierRepo { get; set; }

        public IUserRepository UserRepo { get; set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
