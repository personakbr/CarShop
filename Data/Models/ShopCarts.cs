using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Data.Models
{
    public class ShopCarts
    {
        private readonly ApplicationDbContext _appDbContent;

        public ShopCarts(ApplicationDbContext appDbContent)
        {
            _appDbContent = appDbContent;
        }
        public string shopCartID { get; set; }
        public List<ShopCarItem> listShopItems { get; set; }

        public static ShopCarts getCart(IServiceProvider service) //добавлял ли пользователь уже товары в карзину
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session; // создаём новую сессию
            var _context = service.GetService<ApplicationDbContext>();
            string shopCarID = session.GetString("CartID") ?? Guid.NewGuid().ToString(); //если не существует ID то мы создаём новое ID, если существует продолжаем движение


            session.SetString("CartID", shopCarID); //создём новую сессию с ключём CartID и значения shopCarID

            return new ShopCarts(_context) { shopCartID = shopCarID }; //есть ли сессия с работой корзины

        }
        public void AddTOCart(Car car) //функция для добавления в корзину
        {
            _appDbContent.shopCarItems.Add(new ShopCarItem
            {
                _shopCarID = shopCartID,
                _car = car,
                _price = car._price
            }
                );
            _appDbContent.SaveChanges();
        }

        //public void  Delete(ShopCarItem shopCar)
        //{
           
        //    //if (id == null)
        //    //{
        //    //    return ();
        //    //}
        //    var car =  listShopItems
        //        .FirstOrDefaultAsync(m => m == id);
          
        //    return View(actor);
        //}

        //// POST: Admin/ActorAdmin/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
           
        //    var car = await _appDbContent.shopCarItems. () ;
        //    _context.Actors.Remove(actor);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}
       
     

        public List<ShopCarItem> GetShopItems() //функция котороя отображает всю корзину
        {
            return _appDbContent.shopCarItems.Where(c => c._shopCarID == shopCartID).Include(s => s._car).ToList();
        }
    }
}
