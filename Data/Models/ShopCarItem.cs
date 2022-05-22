using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Data.Models
{
    public class ShopCarItem
    {
        public int ID { get; set; }
        public Car _car { get; set; }
        public ushort _price { get; set; }

        public string _shopCarID { get; set; }
    }
}
