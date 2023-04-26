using CarShop.Data.Interfaces;
using CarShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Data.Repository
{
    public class OdersRepository : IAllOrders
    {
        private readonly ApplicationDbContext _appDbContent; 
        private readonly ShopCarts _shopCarts;

        public OdersRepository(ApplicationDbContext appDbContent, ShopCarts shopCarts)
        {
            _appDbContent = appDbContent;
            _shopCarts = shopCarts;
        }


        public void CreateOrder(Order order)
        {
            order._orderTime = DateTime.Now; //устонавливаем время
            _appDbContent.orders.Add(order);

            var _items = _shopCarts.listShopItems;

            foreach(var el in _items)
            {
                var _orderDetail = new OrderDetail()
                {
                    _carID = el._car.ID,
                    _orderID = order.ID,
                    _price = el._car._price
                };
                _appDbContent.orderDet.Add(_orderDetail);
            }
            _appDbContent.SaveChanges();
        }
    }
}
