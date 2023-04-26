using CarShop.Data.Interfaces;
using CarShop.Data.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Data.Repository
{
    public class CreateCarRepository : ICreateCar
    {
        private readonly ApplicationDbContext _appDbContent;


        public CreateCarRepository(ApplicationDbContext appDbContent)
        {
            _appDbContent = appDbContent;

        }

        

        public void CreateCars(Car carCreate)
        {
            _appDbContent.car.Add(carCreate);
            _appDbContent.SaveChanges();
        }
    }
}
