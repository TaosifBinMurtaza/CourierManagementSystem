using CourierManagementSystem.DataAccess.Repository.IRepository;
using CourierManagementSystem.Models;
using CourierManagementSystem.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace CourierManagementSystem.Web.Controllers
{
    public class CourierController : Controller
    {
        private readonly IUnitOfWork _unit;

        public CourierController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Courier obj)
        {
            if (ModelState.IsValid)
            {
                _unit.CourierRepo.Add(obj);
                _unit.Save();
                TempData["Success"] = "Courier has been created";
                return RedirectToAction("Index","Home");
            }
            return View(obj);
        }
        public IActionResult UpdateStatus(string id)
        {
            var result = _unit.CourierRepo.GetFisrtOrDefault(u => u.Id == id);
            return View(result);
        }
        [HttpPost]
        public IActionResult UpdateStatus(Courier obj)
        {
            
                obj.Status = "Delivered";
                obj.FinalDate = DateTime.Now;
                _unit.CourierRepo.Update(obj);
                _unit.Save();
                TempData["Success"] = "Delivery Status have been updated";
                return RedirectToAction("Index", "Home");
            
         
        }
      
        public IActionResult Delete(string id)
        {
            var result = _unit.CourierRepo.GetFisrtOrDefault(u => u.Id == id);
            _unit.CourierRepo.Remove(result);
            _unit.Save();
            TempData["Success"] = "Courier has been deleted";
            return RedirectToAction("Index", "Home");



        }
        public IActionResult Report()
        {
             
            var result= _unit.CourierRepo.GetAll()
                .GroupBy(u => new { u.OrderDate.Year, u.OrderDate.Month})
                .Select(group => new
                {              
                    Year=group.Key.Year,
                    Month=CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(group.Key.Month),
                    //Orders =group.OrderBy(u=>u.Id)
                    Total=group.Count()
                });

            return View(result);
            //return Json(new { data = result2 });


        }
    }
}
