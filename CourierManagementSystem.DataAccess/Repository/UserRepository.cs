using CourierManagementSystem.DataAccess.Data;
using CourierManagementSystem.DataAccess.Repository.IRepository;
using CourierManagementSystem.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.DataAccess.Repository
{
    public class UserRepository:Repository<User>,IUserRepository
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db) : base(db)
        {

            _db = db;
        }

        public User Login(User obj)
        {
            var user = _db.Users.FirstOrDefault(u=>u.UserName==obj.UserName && u.Password==obj.Password);
            if (user == null)
            {
                return null;
            }
            else
                return user;
        }
    }
}
