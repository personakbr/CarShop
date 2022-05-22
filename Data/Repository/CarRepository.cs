using CarShop.Data;
using CarShop.Data.Interfaces;
using CarShop.Data.Models;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Repository
{
    public class CarRepository : IAllCars
    {
        private readonly ApplicationDbContext _appDbContent;

        public CarRepository(ApplicationDbContext appDbContent)
        {
            _appDbContent = appDbContent;
        }
        public IEnumerable<Car> Cars => _appDbContent.car.Include(c => c.Category);

        public IEnumerable<Car> GetFavCars => _appDbContent.car.Where(p => p._isFavourite).Include(c => c.Category);

        public Car GetObjectCar(int _carID) => _appDbContent.car.FirstOrDefault(p => p.ID == _carID);


    }
}
