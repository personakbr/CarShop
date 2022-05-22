using CarShop.Data;
using CarShop.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext applicationDbContext;
        public List<Car> Cars { get; set; }  
        public IndexModel(ApplicationDbContext db)
        {
            applicationDbContext = db;
        }


        public void OnGet()
        {
            Cars = applicationDbContext.car.ToList();
        }
    }
}
