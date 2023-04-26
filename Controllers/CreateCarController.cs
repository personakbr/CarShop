using CarShop.Data.Interfaces;
using CarShop.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Controllers
{
    public class CreateCarController: Controller
    {
        private readonly ICreateCar _allOrders;
        

        public CreateCarController(ICreateCar allOrders)
        {
            _allOrders = allOrders;
            
        }
        public IActionResult Checkout() //Шаблон, но над которым потом будут происходить какие-то действия
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Car order)
        {
           
            if (ModelState.IsValid)//Если все данные верно заполнены
            {
                _allOrders.CreateCars(order);
                return RedirectToAction("Complete");
            }
            return View(order);
        }
        public IActionResult Complete()
        {
            ViewBag.Message = "Звказ успешно оформлен";
            return View();
        }

    }
}
