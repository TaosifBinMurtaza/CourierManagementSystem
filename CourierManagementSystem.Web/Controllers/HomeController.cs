using CourierManagementSystem.DataAccess.Repository.IRepository;
using CourierManagementSystem.Models;
using CourierManagementSystem.Models.ViewModels;
using CourierManagementSystem.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CourierManagementSystem.Web.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unit;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unit)
		{
			_logger = logger;
            _unit = unit;
        }

		public IActionResult Index(string term="", int currentPage = 1)
		{
			
			CourierVM courierVM=new CourierVM();

			if (term == "" || term == null)
			{
                courierVM.courier = _unit.CourierRepo.GetAll().OrderByDescending(u=>u.Status);

            }
			else
			{
                courierVM.courier = _unit.CourierRepo.GetAll().Where(u => u.Id.Contains(term));
            }
			var totalRecors = courierVM.courier.Count();
			var pageSize = 3;
			var totalPages = (int)Math.Ceiling(totalRecors /(double) pageSize);

            courierVM.courier= courierVM.courier.Skip((currentPage - 1) * pageSize).Take(pageSize);
			courierVM.CurrentPage = currentPage;
			courierVM.TotalPage =totalPages;
			courierVM.PageSize = pageSize;
			

            return View(courierVM);
			//return Json(new { data = courierVM });
		}

		public IActionResult Privacy()
		{
			return View();
		}
        public IActionResult Logout()
        {
            return RedirectToAction("Login","Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}