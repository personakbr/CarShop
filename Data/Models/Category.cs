using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Data.Models
{
    public class Category
    {
        public int ID { set; get; }

        public string _categoryName { set; get; }

        public string _desc { set; get; }

        public List<Car> cars { set; get; } //какие товары входят в эту категорию
    }
}
