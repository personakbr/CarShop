using CarShop.Data.Interfaces;
using CarShop.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Controllers
{
    public class CarsController : Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCategory;
        //поскольку связали интерфейсы и классы которые их реализуют,
        //то мы можем передавать повсюду итерфейсы и вместе с ними будет повсюду передаваться все данные внутри этих интерфейсов
        public CarsController(IAllCars _iallCars, ICarsCategory _iCarsCat)
        {
            _allCars = _iallCars;
            _allCategory = _iCarsCat;

        }
        public ViewResult List()
        {
            var _cars = _allCars.Cars;
            return View(_cars);
        }




        //возвращает HTML страничку
        //[Route("Cars/List")]
        //[Route("Cars/List/{category}")]
        //public ViewResult List(string category)
        //{
        //    string _category = category;
        //    IEnumerable<Car> _cars = null;
        //    string _currCategory = "";
        //    if (string.IsNullOrEmpty(category)) // если категория не заполненна то выводим все
        //    {
        //        _cars = _allCars.Cars.OrderBy(i => i.ID);
        //    }
        //    else
        //    {
        //        if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))// OrdinalIgnoreCase Игнорирует регистры
        //        {
        //            _cars = _allCars.Cars.Where(i => i.Category._categoryName.Equals("Электромобили")).OrderBy(i => i.ID);
        //            _currCategory = "Электромобили";
        //        }
        //        else if (string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase))  // OrdinalIgnoreCase Игнорирует регистры
        //        {
        //            _cars = _allCars.Cars.Where(i => i.Category._categoryName.Equals("Классические автомобили")).OrderBy(i => i.ID);
        //            _currCategory = "Автомобили с двигателем внутреннего сгорания";
        //        }



        //    }
        //var _carObj = new CarsListViewModel
        //{
        //    _allCars = _cars,

        //    _curCategory = _currCategory
        //};
        //ViewBag.title = "Auto_shop";

        //return View(_carObj);
    }
    }

