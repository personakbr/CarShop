using CarShop.Data.Interfaces;
using CarShop.Data.Models;
using CarShop.Pages;
using Microsoft.AspNetCore.Mvc;
using CarShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IAllCars _carRep;
        private readonly ShopCarts _shopCarts;

        public ShopCartController(IAllCars carRep, ShopCarts shopCarts)
        {
            _carRep = carRep;
            _shopCarts = shopCarts;
        }

        public ViewResult Index() //отображает опред. Html шаблон и отображает корзину 
        {
            var items = _shopCarts.GetShopItems();
            _shopCarts.listShopItems = items;

            var obj = new ShopCartViewModel
            {
                shopCarts = _shopCarts
            };

            return View(obj);
        }

        public RedirectToActionResult AddToCart(int ID) //Добавляет тавары в корзину и переадресовывает на другую страничку
        {
            var _item = _carRep.Cars.FirstOrDefault(i => i.ID == ID);//выбирает нужный товар из BD списка всех товаров
            if (_item != null) // выбрали ли мы объект
            {
                _shopCarts.AddTOCart(_item);
            }
            return RedirectToAction("Index");
        }
    }
    
}
