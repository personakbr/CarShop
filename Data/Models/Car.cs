using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Data.Models
{
    public class Car
    {
        public int ID { set; get; }

        public string _name { set; get; }

        public string _shortDesc { set; get; }

        public string _longDesc { set; get; }

        public string _img { set; get; }

        public ushort _price { set; get; }

        public bool _isFavourite { set; get; } //отображение на главной странице

        public bool _avaiLable { set; get; } //доступен ли автомобиль для продажи

        public int _categoryID { set; get; }

        public virtual Category Category { set; get; }
    }
}
