using CourierManagementSystem.DataAccess.Data;
using CourierManagementSystem.DataAccess.Repository.IRepository;
using CourierManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.DataAccess.Repository
{
    public class CourierRepository:Repository<Courier>,ICourierRepository
    {
        private readonly ApplicationDbContext _db;
        public CourierRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Courier obj)
        {
            var result=_db.Couriers.FirstOrDefault(c => c.Id == obj.Id);
            if (result != null)
            {
                result.Status=obj.Status;
                result.FinalDate=obj.FinalDate;
            }
            _db.Couriers.Update(result);
        }
    }
}
