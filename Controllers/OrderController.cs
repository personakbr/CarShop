using CarShop.Data.Interfaces;
using CarShop.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Controllers
{
    public class OrderController: Controller
    {
        private readonly IAllOrders _allOrders;
        private readonly ShopCarts _shopCarts;

        public OrderController(IAllOrders allOrders, ShopCarts shopCarts)
        {
            _allOrders = allOrders;
            _shopCarts = shopCarts;
        }
        public IActionResult Checkout() //Шаблон, но над которым потом будут происходить какие-то действия
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order) //Шаблон, но над которым потом будут происходить какие-то действия
        {
            _shopCarts.listShopItems = _shopCarts.GetShopItems();
            if (_shopCarts.listShopItems.Count==0)
            {
                ModelState.AddModelError("","Добавть товары в карзину покупок"); //выдает ошибку если нет товаров в карзине
            }

            if (ModelState.IsValid)//Если все данные верно заполнены
            {
                _allOrders.CreateOrder(order);
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
