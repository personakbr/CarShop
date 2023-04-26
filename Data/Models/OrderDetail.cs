using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Data.Models
{
    public class OrderDetail
    {
        public int ID { get; set; }
        public int _orderID { get; set; }

        public int _carID { get; set; }

        public int _price { get; set; }
        public virtual Car car { get; set; } //объект с которым мы работаем
        public virtual Order Order { get; set; } //заказ с которым мы работаем


    }
}
