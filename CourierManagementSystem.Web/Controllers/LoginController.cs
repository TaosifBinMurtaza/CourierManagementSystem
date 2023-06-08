using CourierManagementSystem.DataAccess.Repository.IRepository;
using CourierManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourierManagementSystem.Web.Controllers
{
	public class LoginController : Controller
	{
        private readonly IHttpContextAccessor contx;
        private readonly IUnitOfWork _unit;
        public LoginController(IHttpContextAccessor contx, IUnitOfWork unit)
        {
            this.contx = contx;
            _unit = unit;
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(User obj)
		{
            var result=_unit.UserRepo.Login(obj);
            if(result !=null)
            {
                contx.HttpContext.Session.SetString("SessionUserName", result.UserName);
                if (result.Role=="Admin")
                {
                    return RedirectToAction("Index", "Home");
                }
                if (result.Role == "User")
                {
                    return RedirectToAction("Index", "User");
                }


            }

                //if(obj.UserName=="tao" && obj.Password=="123")
                //{
                //    contx.HttpContext.Session.SetString("SessionUserName",obj.UserName);
                //    return RedirectToAction("Index","Home");
                //}
            return View();
		}


	}
}
