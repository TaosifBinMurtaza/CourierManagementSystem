
using CourierManagementSystem.DataAccess.Repository.IRepository;

using Microsoft.AspNetCore.Mvc;

namespace CourierManagementSystem.Web.Controllers
{
    public class UserController : Controller
    {

        private readonly IUnitOfWork _unit;
        public UserController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public IActionResult Index(string term)
        {
            var result = _unit.CourierRepo.GetFisrtOrDefault(u => u.Id == term);
            return View(result);
            //return Json(new { data = result });
        }
    }
}
