using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Data.Models
{
    public class Car
    {
        [BindNever]
        public int ID { set; get; }

        [Display(Name = "Введите название машины")]
        [Required(ErrorMessage = "Заполните колонку с названием машины")]
        public string _name { set; get; }

        [Display(Name = "Короткое описание")]
        [Required(ErrorMessage = "Заполните колонку с коротким описанием")]
        public string _shortDesc { set; get; }


        [Display(Name = "Длинное описание машины")]
        [Required(ErrorMessage = "Заполните колонку с длинным описанием машины")]
        public string _longDesc { set; get; }

        [Display(Name = "укажите путь к картинке")]

        [Required(ErrorMessage = "Заполните колонку с добавлением картинки")]
        public string _img { set; get; }


        [Display(Name = "Укажите цену")]

        [Required(ErrorMessage = "Заполните колонку с ценой")]
        public ushort _price { set; get; }

        [BindNever]
        public bool _isFavourite { set; get; } //отображение на главной странице

        [BindNever]
        public bool _avaiLable { set; get; } //доступен ли автомобиль для продажи

        [BindNever]
        public int _categoryID { set; get; }

        [BindNever]
        public virtual Category Category { set; get; }
    }
}
